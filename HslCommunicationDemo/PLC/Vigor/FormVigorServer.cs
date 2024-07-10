using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Vigor;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormVigorServer : HslFormContent
	{
		public FormVigorServer( )
		{
			InitializeComponent( );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "Vigor Virtual Server";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";

				label14.Text = "Com:";
				button5.Text = "Open Com";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Vigor.Helper.GetVigorAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			vigorServer?.ServerClose( );
		}

		#region Server Start


		private VigorServer vigorServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_port.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				vigorServer = new VigorServer( );                       // 实例化对象
				vigorServer.Station = int.Parse( textBox_station.Text );
				vigorServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				vigorServer.OnDataReceived += BusTcpServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( vigorServer );
				// add some accounts
				// vigorServer.AddAccount( "admin", "123456" );
				// vigorServer.AddAccount( "hsl", "test" );

				userControlReadWriteServer1.SetReadWriteServer( vigorServer, "D100" );
				vigorServer.ServerStart( port );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", vigorServer, nameof( vigorServer.Station ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			vigorServer?.CloseSerialSlave( );
			vigorServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
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
			if (vigorServer != null)
			{
				try
				{
					vigorServer.StartSerialSlave( textBox_serial.Text );
					button5.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", textBox_serial.Text, vigorServer, nameof( vigorServer.Station ) );
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
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCom, textBox_serial.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox_serial.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox_station.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "0", m => m );

			this.userControlReadWriteServer1.LoadDataTable( element );
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
