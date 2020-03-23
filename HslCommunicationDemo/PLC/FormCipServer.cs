using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;

namespace HslCommunicationDemo
{
    public partial class FormCipServer : HslFormContent
    {
        public FormCipServer( )
        {
            InitializeComponent( );
        }



        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            if(Program.Language == 2)
            {
                Text = "Cip Virtual Server [support single value]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
                button4.Text = "Connecting Alien client";

                button8.Text = "Load";
                button9.Text = "Save";
                button10.Text = "Timed writing";
                label1.Text = "log:";
                checkBox1.Text = "Display received data";
                label16.Text = "Client-Online:";
            }
        }
        
        
        
        private System.Windows.Forms.Timer timerSecond;

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            cipServer?.ServerClose( );
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender( string address )
        {
            MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
        }


        #region Server Start

        private HslCommunication.Profinet.AllenBradley.AllenBradleyServer cipServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            try
            {

                cipServer = new HslCommunication.Profinet.AllenBradley.AllenBradleyServer( );                       // 实例化对象
                //s7NetServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "logs.txt" );                  // 配置日志信息
                //s7NetServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
                
                cipServer.ServerStart( port );
                cipServer.AddTagValue( "A", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "A1", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "B", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[4],
                    IsArray = false,
                    TypeLength = 4
                } );
                cipServer.AddTagValue( "C", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[4],
                    IsArray = false,
                    TypeLength = 4
                } );
                cipServer.AddTagValue( "D", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[10],
                    IsArray = true,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "E", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[2],
                    IsArray = false,
                    TypeLength = 2
                } );
                cipServer.AddTagValue( "F", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[100],
                    IsArray = false,
                    TypeLength = 1
                } );
                cipServer.AddTagValue( "AB.C", new HslCommunication.Profinet.AllenBradley.AllenBradleyItemValue( )
                {
                    Buffer = new byte[10],
                    IsArray = true,
                    TypeLength = 2
                } );

                button1.Enabled = false;
                panel2.Enabled = true;
                button4.Enabled = true;
                button11.Enabled = true;
                userControlReadWriteOp1.SetReadWriteNet( cipServer, "A", false );

                timerSecond?.Dispose( );
                timerSecond = new System.Windows.Forms.Timer( );
                timerSecond.Interval = 1000;
                timerSecond.Tick += TimerSecond_Tick;
                timerSecond.Start( );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            cipServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void TimerSecond_Tick( object sender, EventArgs e )
        {
            label15.Text = cipServer.OnlineCount.ToString( ) ;
        }

        private void BusTcpServer_OnDataReceived( object sender, byte[] receive )
        {
            if (!checkBox1.Checked) return;

            if (InvokeRequired)
            {
                BeginInvoke( new Action<object,byte[]>( BusTcpServer_OnDataReceived ), sender, receive );
                return;
            }

            textBox1.AppendText( "Received：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( receive, ' ' ) + Environment.NewLine );
        }

        /// <summary>
        /// 当有日志记录的时候，触发，将日志信息也在主界面进行输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke( new Action<object, HslCommunication.LogNet.HslEventArgs>( LogNet_BeforeSaveToFile ), sender, e );
                    return;
                }

                textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
            }
            catch
            {
                return;
            }
        }



        #endregion


        private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            HslCommunication.BasicFramework.FormSupport form = new HslCommunication.BasicFramework.FormSupport( );
            form.ShowDialog( );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            // 连接异形客户端
            using (FormInputAlien form = new FormInputAlien( ))
            {
                if (form.ShowDialog( ) == DialogResult.OK)
                {
                    OperateResult connect = cipServer.ConnectHslAlientClient( form.IpAddress, form.Port, form.DTU );
                    if (connect.IsSuccess)
                    {
                        MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    }
                    else
                    {
                        MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
                    }
                }
            }
        }
        

        private void button9_Click( object sender, EventArgs e )
        {
            // 将服务器的数据池存储起来
            if (cipServer != null)
            {
                cipServer.SaveDataPool( "123.txt" );
                MessageBox.Show( "Save file finish" );
            }
        }

        private void button8_Click( object sender, EventArgs e )
        {
            // 从文件加载服务器的数据池
            if (cipServer != null)
            {
                if (System.IO.File.Exists( "123.txt" ))
                {
                    cipServer.LoadDataPool( "123.txt" );
                    MessageBox.Show( "Load data finish" );
                }
                else
                {
                    MessageBox.Show( "File is not exist！" );
                }
            }
        }


        private Random random = new Random( );
        private string timerAddress = string.Empty;
        private long timerValue = 0;
        private System.Windows.Forms.Timer timerWrite = null;
        private void button10_Click( object sender, EventArgs e )
        {
            // 定时写
            timerWrite = new System.Windows.Forms.Timer( );
            timerWrite.Interval = 300;
            timerWrite.Tick += TimerWrite_Tick;
            timerWrite.Start( );
            timerAddress = "A";
            button10.Enabled = false;
        }

        private void TimerWrite_Tick( object sender, EventArgs e )
        {
            ushort value = (ushort)(Math.Sin( 2 * Math.PI * timerValue / 100 ) * 100 + 100);
            cipServer.Write( timerAddress, value );
            timerValue++;
        }

    }
}
