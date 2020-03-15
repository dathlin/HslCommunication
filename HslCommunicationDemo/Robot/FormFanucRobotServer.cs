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
    public partial class FormFanucRobotServer : HslFormContent
    {
        public FormFanucRobotServer( )
        {
            InitializeComponent( );
        }

        private void FormFanucRobotServer_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            if(Program.Language == 2)
            {
                Text = "Fanuc Robot Server";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict fanuc protocol and only supports perfect communication with HSL components.";

                label1.Text = "log:";
                checkBox1.Text = "Display received data";
                label16.Text = "Client-Online:";
            }
        }
        
        
        
        private System.Windows.Forms.Timer timerSecond;

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            fanucRobotServer?.ServerClose( );
        }

        #region Server Start


        private HslCommunication.Robot.FANUC.FanucRobotServer fanucRobotServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            try
            {

                fanucRobotServer = new HslCommunication.Robot.FANUC.FanucRobotServer( );                             // 实例化对象
                //fanucRobotServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "logs.txt" );                  // 配置日志信息
                //fanucRobotServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
                fanucRobotServer.OnDataReceived += BusTcpServer_OnDataReceived;

                fanucRobotServer.ServerStart( port );

                userControlReadWriteOp1.SetReadWriteNet( fanucRobotServer, "D0" );
                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;

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
            fanucRobotServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void TimerSecond_Tick( object sender, EventArgs e )
        {
            label15.Text = fanucRobotServer.OnlineCount.ToString( ) ;
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



        private string timerAddress = string.Empty;
        private long timerValue = 0;
        private System.Windows.Forms.Timer timerWrite = null;


    }
}
