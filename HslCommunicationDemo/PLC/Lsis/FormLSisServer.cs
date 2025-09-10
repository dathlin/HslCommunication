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
using HslCommunication.Profinet.LSIS;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormLSisServer : HslFormContent
	{
		public FormLSisServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			cboxModel.DataSource = Enum.GetNames(typeof(LSCpuInfo));

			if (Program.Language == 2)
			{
				Text = "LSis Virtual Server" ;
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Lsis.Helper.GetLsisCnetAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = Button5_Click;
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private HslCommunication.Profinet.LSIS.LSisServer lSisServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				lSisServer = new HslCommunication.Profinet.LSIS.LSisServer();                       // 实例化对象
				lSisServer.SetCpuType = cboxModel.Text;
				lSisServer.OnDataReceived += BusTcpServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( lSisServer );
				if (this.serverSettingControl1.ServerStart( lSisServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( lSisServer, "MB100" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", lSisServer, this.sslServerControl1, nameof( lSisServer.SetCpuType ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			lSisServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
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

		private void Button5_Click(object sender, EventArgs e)
		{
			// 启动串口
			if (lSisServer != null)
			{
				try
				{
					lSisServer.StartSerialSlave(this.serverSettingControl1.TextBox_Serial.Text);
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, lSisServer, this.sslServerControl1, nameof( lSisServer.SetCpuType ) );
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage("Start Failed：" + ex.Message);
				}
			}
			else
			{
				DemoUtils.ShowMessage("Start tcp server first please!");
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlCpuType, cboxModel.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			cboxModel.Text = element.Attribute( DemoDeviceList.XmlCpuType ).Value;
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
