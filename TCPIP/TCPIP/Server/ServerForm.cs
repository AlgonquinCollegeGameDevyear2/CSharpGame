using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//required namespaces
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server
{
    public partial class ServerForm : Form
    {
        private Thread ServerThread = null;
        private bool ThreadRunning = false;
        private const int COMMAND_PORT = 8080;
        private TcpListener serverListener = null;
        List<Thread> ListOfConnections = new List<Thread>();
        List<Socket> ListOfUsers = new List<Socket>();


        //Member variables to be used for final
        private short m_UserCount = 0;
        private char[] m_StonePlacement = new char[9];
        private bool playerOnesTurn = true;

        public ServerForm()
        {
            InitializeComponent();
            IPHostEntry IPHost =
                Dns.GetHostByName(Dns.GetHostName());

            this.Text = "TCP/IP Server - " +
                IPHost.AddressList[0].ToString();

            //Initialize for final
            for (int i = 0; i < 9; i++)
            {
                m_StonePlacement[i] = '-';
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ServerThread = new Thread(new ThreadStart(ServerListener));
            ThreadRunning = true;
            ServerThread.Start();
            StartButton.Enabled = false;
        }

        private void ServerListener()
        {
            serverListener = new TcpListener(COMMAND_PORT);
            serverListener.Start();
            
            while( ThreadRunning == true)
            {
                while( serverListener.Pending() == false)
                {
                    if (ThreadRunning == false)
                        break;
                }
                if (ThreadRunning == false)
                    continue;
                //A connection is detected - Accept it
                Socket clientConnection = serverListener.AcceptSocket();

                Byte[] bytes = new Byte[1024];
                if (m_UserCount == 0)
                {
                    bytes = Encoding.ASCII.GetBytes("X");//X and O are stone types
                    m_UserCount++;
                }
                else if (m_UserCount == 1)
                {
                    bytes = Encoding.ASCII.GetBytes("O");
                    m_UserCount++;
                }
                else
                {
                    bytes = Encoding.ASCII.GetBytes("S");//S for spectator
                }
                NetworkStream netStream = new NetworkStream(clientConnection);
                netStream.Write(bytes, 0, bytes.GetLength(0));

                //CHeck if conntected
                if( clientConnection.Connected == true)
                {   
                    //update connection list
                    UpdateConnectionList(clientConnection);
                    //Pass the connection to a process thread
                    Thread ConnectionThread =
                        new Thread(() => ProcessHandler(clientConnection));
                    ConnectionThread.Start();
                    ListOfConnections.Add(ConnectionThread);
                    //Add the socket to a list of sockets
                    ListOfUsers.Add(clientConnection);
                    //Call the broadcast function
                    AssignPlayerTurn();
                    Broadcast();
                }
            }
        }

        private void AssignPlayerTurn()
        {
            Byte[] bytes = new Byte[1024];
            foreach (Socket sockets in ListOfUsers)
            {
                NetworkStream netStream = new NetworkStream(sockets);
                if (playerOnesTurn == true)
                {
                    bytes = Encoding.ASCII.GetBytes("true");
                    playerOnesTurn = false;
                }
                else
                {
                    bytes = Encoding.ASCII.GetBytes("false");
                    playerOnesTurn = true;
                }
                netStream.Write(bytes, 0, bytes.GetLength(0));
            }
        }

        private delegate void UpdateConnectionDel(Socket client);
        private void UpdateConnectionList( Socket client)
        {
            if (this.InvokeRequired)
            {
                UpdateConnectionDel UpdateDel =
                    new UpdateConnectionDel(UpdateConnectionList);
                this.Invoke(UpdateDel, new object[] { client });
            }
            else
                ConnectionList.Items.Add(client.RemoteEndPoint.ToString());
        }

        private void ProcessHandler( Socket client)
        {
            //the code here is specific to communicating
            //with the connected client only
            NetworkStream NetStream = new NetworkStream(client);
            Byte[] data = new Byte[1024];
            bool Running = true;
            string Message = string.Empty;

            while( Running == true)
            {
                int BytesReceived = NetStream.Read(data, 0, 1024);
                Message = Encoding.ASCII.GetString(data, 0, BytesReceived);
                UpdateMessageList(
                    client.RemoteEndPoint.ToString() +
                    ">>>>" + Message);
                if( Message == "SHUTDOWN")
                {
                    NetStream.Close();
                    client.Close();
                    Running = false;
                    continue;                       
                }
                else
                {
                    Byte[] bytes = new Byte[1024];
                    if (playerOnesTurn == true)
                    {
                        bytes = Encoding.ASCII.GetBytes(Message + "~" + "true");
                        playerOnesTurn = false;
                    }
                    else
                    {
                        bytes = Encoding.ASCII.GetBytes(Message + "~" + "false");
                        playerOnesTurn = true;
                    }
                    foreach (Socket sockets in ListOfUsers)
                    {
                        NetworkStream netStream = new NetworkStream(sockets);
                        netStream.Write(bytes, 0, bytes.GetLength(0));
                    }
                }
            }
        }

        private delegate void UpdateMessageDel(string message);
        private void UpdateMessageList( string message )
        {
            if (this.InvokeRequired)
            {
                UpdateMessageDel UpdateDel =
                    new UpdateMessageDel(UpdateMessageList);
                this.Invoke(UpdateDel, new object[] { message });
            }
            else
                ClientMessages.Items.Add(message);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ThreadRunning = false;
            serverListener.Stop();
            StartButton.Enabled = true;
            //Shutdown all the connection threads 
            foreach (Thread th in ListOfConnections)
                th.Abort();
        }
        private void Broadcast( )
        {
            string ListOfIps = string.Empty;

            foreach( Socket client in ListOfUsers)
            {
                ListOfIps += ((client.RemoteEndPoint) as IPEndPoint).Address.ToString();
                ListOfIps += ":";
            }
            //10.50.1.2:10.50.20.4:.....
            //Iterate thru the list again and use netstream.write to send the 
            //ListOfIps string.
            //Dont forget to encode to Bytes.
            Byte[] data = new Byte[1024];
            data = Encoding.ASCII.GetBytes(ListOfIps);

            foreach( Socket client in ListOfUsers)
            {
                NetworkStream netStream = new NetworkStream(client);
                netStream.Write(data, 0, data.GetLength(0));
            }

        }
    }
}
