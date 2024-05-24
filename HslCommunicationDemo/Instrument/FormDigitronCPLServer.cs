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
	public partial class FormDigitronCPLServer : HslFormContent
	{
		public FormDigitronCPLServer( )
		{
			InitializeComponent( );
			digitronServer = new HslCommunication.Profinet.Yamatake.DigitronCPLServer( );                       // 实例化对象
			digitronServer.OnDataReceived += BusTcpServer_OnDataReceived;
			digitronServer.Station = 1;
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Yamatake CPL DigitronIK Virtual Server";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}
			userControlReadWriteServer1.SetEnable( false );
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			digitronServer?.ServerClose( );
		}

		private HslCommunication.Profinet.Yamatake.DigitronCPLServer digitronServer;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			try
			{
				digitronServer.Station = byte.Parse( textBox_station.Text );
				digitronServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				this.sslServerControl1.InitializeServer( digitronServer );
				digitronServer.ServerStart( port );
				digitronServer.EnableWrite = checkBox1.Checked;

				userControlReadWriteServer1.SetReadWriteServer( digitronServer, "100" );
				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}


		private void button5_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult open = digitronServer.StartSerialSlave( textBox_serial.Text );
				if (!open.IsSuccess) 
				{
					MessageBox.Show( open.Message );
					return;
				}

				userControlReadWriteServer1.SetReadWriteServer( digitronServer, "100" );
				button5.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}
		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			digitronServer?.CloseSerialSlave( );
			digitronServer?.ServerClose( );
			button1.Enabled = true;
			button5.Enabled = true;
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
			if (source is SerialPort serialPort)
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
