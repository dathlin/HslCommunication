using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Fuji;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFujiSPHServer : HslFormContent
	{
		public FormFujiSPHServer( )
		{
			InitializeComponent( );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "SPH Virtual Server";
				label3.Text = "Port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict sph protocol and only supports perfect communication with HSL components.";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Fuji.Helper.GetSPHAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			fujiSPHServer?.ServerClose( );
		}

		#region Server Start

		private FujiSPHServer fujiSPHServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				fujiSPHServer = new FujiSPHServer( );                       // 实例化对象
				fujiSPHServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );     // 如果客户端1个小时不通信，就关闭连接
				fujiSPHServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( fujiSPHServer );
				fujiSPHServer.ServerStart( port );
				userControlReadWriteServer1.SetReadWriteServer( fujiSPHServer, "M1.100" );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", fujiSPHServer, "ByteTransform.DataFormat" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			fujiSPHServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void MelsecMcServer_OnDataReceived( object sender,  object source, byte[] receive )
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
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;

			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
