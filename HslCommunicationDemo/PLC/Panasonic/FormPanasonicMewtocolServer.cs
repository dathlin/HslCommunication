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
using HslCommunicationDemo.DemoControl;
using System.Xml.Linq;

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
			if(Program.Language == 2)
			{
				Text = "Mewtocol Server [data support]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button2.Text = "Start Serial";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict Mewtocol protocol and only supports perfect communication with HSL components.";
			}


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Panasonic.Helper.GetMewtocolAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			if (mewtocolServer != null)
			{
				try
				{
					mewtocolServer.StartSerialSlave( textBox_serial.Text );
					button2.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", textBox_serial.Text, mewtocolServer, nameof( mewtocolServer.Station ) );
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
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		//private Timer timer;

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
				sslServerControl1.InitializeServer( mewtocolServer );
				userControlReadWriteServer1.SetReadWriteServer( mewtocolServer, "D100" );
				mewtocolServer.ServerStart( port );
				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", mewtocolServer, nameof( mewtocolServer.Station ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			mewtocolServer?.CloseSerialSlave( );
			mewtocolServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button2.Enabled = true;
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


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "Serial", textBox_serial.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox_serial.Text = GetXmlValue( element, "Serial", textBox_serial.Text, m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}


	}
}
