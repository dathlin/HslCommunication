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

namespace HslCommunicationDemo
{
    public partial class FormPanasonicMewtocolServer : HslFormContent
    {
        public FormPanasonicMewtocolServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;


            if(Program.Language == 2)
            {
                Text = "Mewtocol Server [data support]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict Mewtocol protocol and only supports perfect communication with HSL components.";
            }
            //timer = new Timer( );
            //timer.Interval = 1000;
            //timer.Tick += Timer_Tick;
            //timer.Start( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            if (mewtocolServer != null)
            {
                try
                {
                    mewtocolServer.StartSerialSlave( textBox1.Text );
                    button2.Enabled = false;
                }
                catch (Exception ex)
                {
                    HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
                }
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            mewtocolServer?.ServerClose( );
        }

        #region Server Start


        private HslCommunication.Profinet.Panasonic.PanasonicMewtocolServer mewtocolServer;
        private Timer timer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {

                mewtocolServer = new HslCommunication.Profinet.Panasonic.PanasonicMewtocolServer( );                       // 实例化对象
                mewtocolServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                mewtocolServer.OnDataReceived += BusTcpServer_OnDataReceived;
                mewtocolServer.Station        = 238;
                mewtocolServer.ServerStart( port );

                userControlReadWriteServer1.SetReadWriteServer( mewtocolServer, "D100" );
                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            mewtocolServer?.ServerClose( );
            button1.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, object source, byte[] receive )
        {
            // 我们可以捕获到接收到的客户端的modbus报文
            // 如果是TCP接收的
            if (source is HslCommunication.Core.Net.AppSession session)
            {
                // 获取当前客户的IP地址
                string ip = session.IpAddress;
            }

            // 如果是串口接收的
            if (source is System.IO.Ports.SerialPort serialPort)
            {
                // 获取当前的串口的名称
                string portName = serialPort.PortName;
            }
        }

		#endregion

	}
}
