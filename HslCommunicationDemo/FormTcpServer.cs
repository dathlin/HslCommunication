using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Net;

namespace HslCommunicationDemo
{
    public partial class FormTcpServer : HslFormContent
    {
        public FormTcpServer( )
        {
            InitializeComponent( );
        }

        private void FormTcpDebug_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            timer = new Timer( );
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            timer.Start( );

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "TCP/IP调试助手";
                label1.Text = "Ip地址：";
                label3.Text = "端口号：";
                button1.Text = "启动";
                button2.Text = "关闭";
                label6.Text = "数据发送区：";
                checkBox1.Text = "是否使用二进制通信";
                label7.Text = "数据接收区：";
                checkBox3.Text = "是否显示发送数据";
                checkBox4.Text = "是否显示时间";
                button3.Text = "发送数据";
                label8.Text = "已选择数据字节数：";
            }
            else
            {
                Text = "TCP/IP Debug Tools";
                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Start";
                button2.Text = "Close";
                label6.Text = "Data sending Area:";
                checkBox1.Text = "Whether to use binary communication";
                label7.Text = "Data receiving Area:";
                checkBox3.Text = "Whether to display send data";
                checkBox4.Text = "Whether to show time";
                button3.Text = "Send Data";
                label8.Text = "Number of data bytes selected:";
            }
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            if (!string.IsNullOrEmpty( textBox6.Text ))
            {
                string select = textBox6.SelectedText;
                if (!string.IsNullOrEmpty( select ))
                {
                    if (checkBox1.Checked)
                    {
                        // 二进制
                        byte[] bytes = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( select );
                        label8.Text = Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:" + bytes.Length;
                    }
                    else
                    {
                        label8.Text = Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:" + select.Length;
                    }
                }
            }
        }

        private Socket socketCore = null;
        private byte[] buffer = new byte[2048];
        private Timer timer;
        private List<ClientSession> sockets = new List<ClientSession>( );

        private void button1_Click( object sender, EventArgs e )
        {
            // 连接服务器
            try
            {
                socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
                socketCore.Bind( new IPEndPoint( 0, int.Parse( textBox2.Text ) ) );
                socketCore.Listen( 500 );//单次允许最后请求500个，足够小型系统应用了
                socketCore.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), socketCore );

                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;

                MessageBox.Show( HslCommunication.StringResources.Language.ConnectServerSuccess );
            }
            catch (Exception ex)
            {
                MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message );
            }
        }

        /// <summary>
        /// 异步传入的连接申请请求
        /// </summary>
        /// <param name="iar">异步对象</param>
        protected void AsyncAcceptCallback( IAsyncResult iar )
        {
            //还原传入的原始套接字
            if (iar.AsyncState is Socket server_socket)
            {
                Socket client = null;
                ClientSession session = new ClientSession( );
                try
                {
                    // 在原始套接字上调用EndAccept方法，返回新的套接字
                    client = server_socket.EndAccept( iar );

                    session.Socket = client;
                    session.EndPoint = (IPEndPoint)client.RemoteEndPoint;

                    client.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), session );

                    lock (session)
                    {
                        sockets.Add( session );
                    }

                    Invoke( new Action( ( ) =>
                    {
                        textBox6.AppendText( "Client Online[" + session.EndPoint.Address.ToString( ) + "]" + Environment.NewLine );
                        lock (lockObject)
                        {
                            comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
                        }
                    } ) );
                }
                catch (ObjectDisposedException)
                {
                    // 服务器关闭时候触发的异常，不进行记录

                    lock (lockObject)
                    {
                        sockets.Remove( session );
                    }
                    return;
                }
                catch
                {
                    // 有可能刚连接上就断开了，那就不管
                    lock (lockObject)
                    {
                        sockets.Remove( session );
                    }
                    client?.Close( );
                }


                server_socket.BeginAccept( new AsyncCallback( AsyncAcceptCallback ), server_socket );
            }
        }


        private void button2_Click( object sender, EventArgs e )
        {
            socketCore?.Close( );
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;
        }

        private void ReceiveCallBack( IAsyncResult ar )
        {
            if (ar.AsyncState is ClientSession client)
            {
                try
                {
                    int length = client.Socket.EndReceive( ar );

                    if (length == 0)
                    {
                        Invoke( new Action( ( ) =>
                        {
                            client.Socket.Close( );
                            lock (lockObject)
                            {
                                sockets.Remove( client );
                                comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
                            }
                            textBox6.AppendText( "Client Offline[" + client.EndPoint.Address.ToString( ) + "]" + Environment.NewLine );
                        } ) );
                        return;
                    };

                    client.Socket.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), client );

                    byte[] data = new byte[length];
                    Array.Copy( buffer, 0, data, 0, length );
                    Invoke( new Action( ( ) =>
                    {
                        string msg = string.Empty;
                        if (checkBox1.Checked)
                        {
                            msg = SoftBasic.ByteToHexString( data, ' ' );
                        }
                        else
                        {
                            msg = Encoding.ASCII.GetString( data );
                        }

                        if (checkBox4.Checked)
                        {
                            textBox6.AppendText( $"[{DateTime.Now:HH:mm:ss.fff}] [{client.EndPoint}] [{(Program.Language == 1 ? "收" : "R")}]   " + msg + Environment.NewLine );
                        }
                        else
                        {
                            textBox6.AppendText( $"[{client.EndPoint}] [{(Program.Language == 1 ? "收" : "R")}]   " + msg + Environment.NewLine );
                        }

                    } ) );
                }
                catch (ObjectDisposedException)
                {
                    Invoke( new Action( ( ) =>
                    {
                        lock (lockObject)
                        {
                            sockets.Remove( client );
                            comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
                        }
                    } ) );
                }
                catch
                {
                    Invoke( new Action( ( ) =>
                    {
                        lock (lockObject)
                        {
                            sockets.Remove( client );
                            comboBox1.DataSource = sockets.Select( m => m.EndPoint.ToString( ) ).ToArray( );
                        }
                        textBox6.AppendText( Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote" + Environment.NewLine );
                    } ) );
                }
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            // 发送数据
            byte[] send = null;
            if (checkBox1.Checked)
            {
                send = SoftBasic.HexStringToBytes( textBox5.Text );
            }
            else
            {
                string str = textBox5.Text.Replace( "\\n", "\n" ).Replace( "\\r", "\r" );
                send = Encoding.ASCII.GetBytes( str );
            }

            if (checkBox3.Checked)
            {
                // 显示发送信息
                if (checkBox4.Checked)
                {
                    textBox6.AppendText( "[" + DateTime.Now.ToString( "HH:mm:ss.fff" ) + (Program.Language == 1 ? "] [" + comboBox1.Text + "] [发]   " : "] [" + comboBox1.Text + "] [S]   ") + 
                        (checkBox1.Checked ? SoftBasic.ByteToHexString( send, ' ' ) : Encoding.ASCII.GetString( send ) ) + Environment.NewLine );
                }
                else
                {
                    textBox6.AppendText( (Program.Language == 1 ? "[" + comboBox1.Text + "] [发]   " : "[" + comboBox1.Text + "] [S]   ") +
                        (checkBox1.Checked ? SoftBasic.ByteToHexString( send, ' ' ) : Encoding.ASCII.GetString( send )) + Environment.NewLine );
                }
            }
            try
            {
                lock (lockObject)
                {
                    for (int i = 0; i < sockets.Count; i++)
                    {
                        if (sockets[i].EndPoint.ToString( ) == comboBox1.Text)
                        {
                            sockets[i].Socket.Send( send, 0, send.Length, SocketFlags.None );
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void button4_Click( object sender, EventArgs e )
        {
            HslCommunication.Robot.EFORT.ER7BC10 eR7BC10 = new HslCommunication.Robot.EFORT.ER7BC10( "192.168.0.100", 8008 );
            textBox5.Text = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( eR7BC10.GetReadCommand( ), ' ' );
        }


        private object lockObject = new object( );
    }

    class ClientSession
	{
        public Socket Socket { get; set; }

        public IPEndPoint EndPoint { get; set; }

        public override string ToString( ) => EndPoint.ToString( );
    }
}
