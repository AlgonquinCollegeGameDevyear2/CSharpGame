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
        private char[] m_StonePlacement = new char[9];
        private bool isMyTurn = false;

        public ClientForm()
        {
            InitializeComponent();

            
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
                if (charsFromServer[0] == 'S')
                {
                    setAsSpectator();
                }
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

        private delegate void UpdateOnlineUsersDel(string num);
        private void UPdateOnlineUsersLB(string num)
        {
            if (this.InvokeRequired)
            {
                UpdateOnlineUsersDel UpdateDel =
                    new UpdateOnlineUsersDel(UPdateOnlineUsersLB);
                this.Invoke(UpdateDel, new object[] { num });
            }
            else
            {
                string[] DataFromServer = num.Split('~');
                //ListOfServerUsers.Items.Clear();
                try
                {
                    int numberFromServer = Int32.Parse(DataFromServer[0]);
                    switch (numberFromServer)
                    {
                        case 0:
                            Button1.Text = DataFromServer[1];
                            Button1.Enabled = false;
                            break;
                        case 1:
                            Button2.Text = DataFromServer[1];
                            Button2.Enabled = false;
                            break;
                        case 2:
                            Button3.Text = DataFromServer[1];
                            Button3.Enabled = false;
                            break;
                        case 3:
                            button4.Text = DataFromServer[1];
                            button4.Enabled = false;
                            break;
                        case 4:
                            button5.Text = DataFromServer[1];
                            button5.Enabled = false;
                            break;
                        case 5:
                            button6.Text = DataFromServer[1];
                            button6.Enabled = false;
                            break;
                        case 6:
                            button7.Text = DataFromServer[1];
                            button7.Enabled = false;
                            break;
                        case 7:
                            button8.Text = DataFromServer[1];
                            button8.Enabled = false;
                            break;
                        case 8:
                            button9.Text = DataFromServer[1];
                            button9.Enabled = false;
                            break;
                        default:
                            break;
                    }
                    if (DataFromServer[2] == "true" && m_Stone == 'X')
                    {
                        isMyTurn = true;
                    }
                    else if (DataFromServer[2] == "false" && m_Stone == 'O')
                    {
                        isMyTurn = true;
                    }
                    else { }
                }
                catch (Exception ex)
                {

                }
                try
                {

                    if (DataFromServer[0] == "true" && m_Stone == 'X')
                    {
                        isMyTurn = true;
                    }
                    else if (DataFromServer[0] == "false" && m_Stone == 'O')
                    {
                        isMyTurn = true;
                    }
                    else { }
                }
                catch (Exception ex) { }
            }
        }
    
        private void setAsSpectator()
        {
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
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
            Byte[] bytes = new Byte[1024];
            m_StonePlacement[position] = m_Stone;
            bytes = Encoding.ASCII.GetBytes(position.ToString() + '~' + m_Stone);
            NetStream.Write(bytes, 0, bytes.GetLength(0));
            isMyTurn = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(0);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(1);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(2);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(3);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(4);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(5);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(6);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(7);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isMyTurn == true)
            {
                sendStonePlacement(8);
            }
        }
    }
}
