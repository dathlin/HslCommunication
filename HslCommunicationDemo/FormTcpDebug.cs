using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormTcpDebug : HslFormContent
    {
        public FormTcpDebug( )
        {
            InitializeComponent( );
        }

        private void FormTcpDebug_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            timer = new System.Windows.Forms.Timer( );
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
                button1.Text = "连接";
                button2.Text = "关闭连接";
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
                button1.Text = "Connect";
                button2.Text = "Disconnect";
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
                if(!string.IsNullOrEmpty(select))
                {
                    if (checkBox1.Checked)
                    {
                        // 二进制
                        byte[] bytes = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( select );
                        label8.Text = Program.Language == 1? "已选择数据字节数：" : "Number of data bytes selected:" + bytes.Length;
                    }
                    else
                    {
                        label8.Text = Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:" + select.Length;
                    }
                }
            }
        }

        private Socket socketCore = null;
        private bool connectSuccess = false;
        private byte[] buffer = new byte[2048];
        private System.Windows.Forms.Timer timer;

        private void button1_Click( object sender, EventArgs e )
        {
            // 连接服务器
            try
            {
                socketCore?.Close( );
                socketCore = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
                connectSuccess = false;
                new System.Threading.Thread( ( ) =>
                {
                    System.Threading.Thread.Sleep( 2000 );
                    if (!connectSuccess) socketCore?.Close( );
                } ).Start( );
                socketCore.Connect( System.Net.IPAddress.Parse( HslCommunication.Core.HslHelper.GetIpAddressFromInput( textBox1.Text ) ), int.Parse( textBox2.Text ) );
                connectSuccess = true;

                socketCore.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), socketCore );
                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;

                MessageBox.Show( HslCommunication.StringResources.Language.ConnectServerSuccess );
            }
            catch(Exception ex)
            {
                MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message );
            }
        }


        private void button2_Click( object sender, EventArgs e )
        {
            socketCore?.Close( );
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void ReceiveCallBack( IAsyncResult ar )
        {
            try
            {
                int length = socketCore.EndReceive( ar );
                socketCore.BeginReceive( buffer, 0, 2048, SocketFlags.None, new AsyncCallback( ReceiveCallBack ), socketCore );

                if (length == 0) return;

                byte[] data = new byte[length];
                Array.Copy( buffer, 0, data, 0, length );
                Invoke( new Action( ( ) =>
                {
                    string msg = string.Empty;
                    if (checkBox1.Checked)
                    {
                        msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( data, ' ' );
                    }
                    else
                    {
                        msg = Encoding.ASCII.GetString( data );
                    }


                    if (checkBox4.Checked)
                    {
                        textBox6.AppendText( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + (Program.Language == 1 ? "][收]   ": "][R]   ") + msg + Environment.NewLine );
                    }
                    else
                    {
                        textBox6.AppendText( (Program.Language == 1 ? "][收]   " : "][R]   ") + msg + Environment.NewLine );
                    }

                } ) );
            }
            catch(ObjectDisposedException)
            {

            }
            catch
            {
                Invoke( new Action( ( ) =>
                {
                    MessageBox.Show( Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote" );
                    panel2.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = false;
                } ) );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            // 发送数据
            byte[] send = null;
            if (checkBox1.Checked)
            {
                send = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox5.Text );
            }
            else
            {
                send = Encoding.ASCII.GetBytes( textBox5.Text.Replace( "\\n", "\r\n" ) );
            }

            if (checkBox2.Checked)
            {
                send = HslCommunication.BasicFramework.SoftBasic.SpliceArray( send, new byte[] { 0x0A } );
            }

            if (checkBox3.Checked)
            {
                // 显示发送信息
                if (checkBox4.Checked)
                {
                    textBox6.AppendText( "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + (Program.Language == 1 ? "][发]   " : "][S]   ") + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( send, ' ' ) + Environment.NewLine );
                }
                else
                {
                    textBox6.AppendText( (Program.Language == 1 ? "][发]   " : "][S]   ") + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( send, ' ' ) + Environment.NewLine );
                }
            }
            try
            {
                socketCore?.Send( send, 0, send.Length, SocketFlags.None );
            }
            catch(Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void button4_Click( object sender, EventArgs e )
        {
            HslCommunication.Robot.EFORT.ER7BC10 eR7BC10 = new HslCommunication.Robot.EFORT.ER7BC10( "192.168.0.100",8008 );
            textBox5.Text = HslCommunication.BasicFramework.SoftBasic.ByteToHexString( eR7BC10.GetReadCommand( ), ' ' );
        }

        #region Toledo Test

        private void button6_Click( object sender, EventArgs e )
        {
            if (button6.BackColor != Color.Green)
            {
                toledoThread = true;
                button6.BackColor = Color.Green;
                new System.Threading.Thread( new System.Threading.ThreadStart( ToledoTest ) ) { IsBackground = true }.Start( );
            }
            else
            {
                toledoThread = false;
                button6.BackColor = SystemColors.Control;
            }
        }

        private bool toledoThread = false;
        private Random random = new Random( );
        private float toledoWeight = 30f;

        private void ToledoTest( )
        {
            while (toledoThread)
            {
                System.Threading.Thread.Sleep( 30 );

                byte[] send = "02 2C 30 20 20 20 33 38 36 32 20 20 20 30 30 30 0D".ToHexBytes( );
                toledoWeight += random.Next( 200 ) / 100f - 1;
                if (toledoWeight < 0) toledoWeight = 5f;
                if (toledoWeight > 100) toledoWeight = 95f;
                string tmp = toledoWeight.ToString( "F2" ).Replace( ".", "" ).PadLeft( 6, ' ' );
                Encoding.ASCII.GetBytes( tmp ).CopyTo( send, 4 );

                try
                {
                    socketCore?.Send( send, 0, send.Length, SocketFlags.None );
                }
                catch (Exception ex)
                {
                    HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
                    return;
                }
            }
        }

		#endregion

		private void button5_Click( object sender, EventArgs e )
		{
            textBox6.Clear( );
		}
	}
}
