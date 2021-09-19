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
using System.Xml.Linq;
using System.IO.Ports;

namespace HslCommunicationDemo
{
    public partial class FormOmronHostLinkServer : HslFormContent
    {
        public FormOmronHostLinkServer( )
        {
            InitializeComponent( );
            omronFinsServer = new HslCommunication.Profinet.Omron.OmronHostLinkServer( );                       // 实例化对象
            omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.DataSource = SerialPort.GetPortNames( );

            if(Program.Language == 2)
            {
                Text = "Omron Virtual Server [data support, d, a, h, c, w]";
                label3.Text = "port:";
                button1.Text = "Start Server";
                button11.Text = "Close Server";
                label11.Text = "This server is not a strict fins protocol and only supports perfect communication with HSL components.";
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
            omronFinsServer?.ServerClose( );
        }

        private HslCommunication.Profinet.Omron.OmronHostLinkServer omronFinsServer;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            try
            {
                omronFinsServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
                omronFinsServer.ServerStart( port );

                userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
                button1.Enabled = false;
                panel2.Enabled = true;
                button11.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button5_Click( object sender, EventArgs e )
        {
            if(comboBox1.SelectedItem == null) { MessageBox.Show( "There is none serial port to use, try later!" ); return; }
            try
            {
                omronFinsServer.StartSerialSlave( comboBox1.SelectedItem.ToString( ), 9600, 7, Parity.Even, StopBits.One );

                userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
                button5.Enabled = false;
                panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
        private void button11_Click( object sender, EventArgs e )
        {
            // 停止服务
            omronFinsServer?.ServerClose( );
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

        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }

	}
}
