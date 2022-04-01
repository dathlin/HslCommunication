using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.IO;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormSiemensPPIServer : HslFormContent
    {
        public FormSiemensPPIServer( )
        {
            InitializeComponent( );
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            if (Program.Language == 2)
            {
                Text = "Siemens PPI Server[supports serial and tcp]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";

                label14.Text = "Com:";
                button5.Text = "Open Com";
            }
        }

        
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            ppiServer?.ServerClose( );
        }

        #region Server Start


        private SiemensPPIServer ppiServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            try
            {
                ppiServer                = new SiemensPPIServer( );                       // 实例化对象
                ppiServer.Station        = byte.Parse( textBox1.Text );
                ppiServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                ppiServer.OnDataReceived += BusTcpServer_OnDataReceived;

                userControlReadWriteServer1.SetReadWriteServer( ppiServer, "M100" );
                ppiServer.ServerStart( port );

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
            ppiServer?.ServerClose( );
            button1.Enabled = true;
            button5.Enabled = true;
            button11.Enabled = false;
        }

        private void BusTcpServer_OnDataReceived( object sender, object source, byte[] modbus )
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

        private void button5_Click( object sender, EventArgs e )
        {
            // 启动串口
            if (ppiServer != null)
            {
                try
                {
                    ppiServer.StartSerialSlave( textBox10.Text );
                    button5.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show( "Start Failed：" + ex.Message );
                }
            }
            else
            {
                MessageBox.Show( "Start tcp server first please!" );
            }
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlCom, textBox10.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox10.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

		private void panel1_Paint( object sender, PaintEventArgs e )
		{

		}
	}
}
