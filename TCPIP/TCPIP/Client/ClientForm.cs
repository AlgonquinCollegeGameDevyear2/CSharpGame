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

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient clientConnection = null;
        private NetworkStream NetStream = null;

        //Member variables for final
        private char m_Stone = ' ';
        private char[] m_StonePlacement = null;

        public ClientForm()
        {
            InitializeComponent();

            m_StonePlacement[9] = new char();
            for (int i = 0; i < 9; i++)
            {
                m_StonePlacement[i] = '-';
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] data = new Byte[1024];
                //Convert the text to bytes
                data = Encoding.ASCII.GetBytes("");//TextMessage.Text);
                //Use the stream to write the data
                NetStream.Write(data, 0, data.GetLength(0));
            }
            catch( Exception ex)
            {
                MessageBox.Show("Unable to send data");
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Open a connection to the server
                clientConnection = new TcpClient(
                        ServerIPAddress.Text,
                        Convert.ToInt32(PortNumber.Text));
                //Get the stream to read/write to the network
                NetStream = clientConnection.GetStream();
                Byte[] bytes = new Byte[1024];
                NetStream.Read(bytes, 0, bytes.GetLength(0));
                char[] charsFromServer = Encoding.ASCII.GetChars(bytes);
                m_Stone = charsFromServer[0];
                //Update the connection status
                ConnectionStatus.Text = "Connected";
                //Create the thread to get the data from server
                //Through the NetStream.Read() function
                Thread serverTHread = new Thread(new ThreadStart(ServerProcessHandler));
                serverTHread.Start();
            }
            catch( Exception ex)
            {
                ConnectionStatus.Text = "Failed to connect";
            }
        }
        private void ServerProcessHandler( )
        {
            bool Running = true;
            Byte[] data = new Byte[1024];
            string ips = string.Empty;

            while( Running == true)
            {
                int bytes = NetStream.Read(data, 0, 1024);
                ips = Encoding.ASCII.GetString(data, 0, bytes);
                UPdateOnlineUsersLB(ips);
            }
        }



        private delegate void UpdateOnlineUsersDel(string ips);
        private void UPdateOnlineUsersLB( string ips)
        {
            if (this.InvokeRequired)
            {
                UpdateOnlineUsersDel UpdateDel =
                    new UpdateOnlineUsersDel(UPdateOnlineUsersLB);
                this.Invoke(UpdateDel, new object[] { ips });
            }
            else
            {
                string[] Listofips = ips.Split(':');
                //ListOfServerUsers.Items.Clear();
                foreach (string ip in Listofips)
                {
                    //ListOfServerUsers.Items.Add(ip);
                }
            }
        }
    
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientConnection != null)
                {
                    clientConnection.Close();
                    NetStream.Close();
                    ConnectionStatus.Text = "Disconnected";
                }
            }
            catch( Exception ex)
            {
                ConnectionStatus.Text = "Unable to disconnect";
            }
        }

        private void sendStonePlacement(int position)
        {
            m_StonePlacement[position] = m_Stone;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
