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
	public partial class FormCimonServer : HslFormContent
	{
		public FormCimonServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "Cimon Virtual Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Cimon.Helper.GetCimonAddress( ) );
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


		private HslCommunication.Profinet.Cimon.CimonServer cimonServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				cimonServer = new HslCommunication.Profinet.Cimon.CimonServer();                       // 实例化对象
				cimonServer.FrameNo = byte.Parse( textBox_frameNo.Text );
				cimonServer.OnDataReceived += BusTcpServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( cimonServer );
				if (this.serverSettingControl1.ServerStart( cimonServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( cimonServer, "D100" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", cimonServer, this.sslServerControl1, nameof( cimonServer.FrameNo ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			userControlReadWriteServer1.Close( );
			cimonServer?.ServerClose( );
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
			if (cimonServer != null)
			{
				try
				{
					cimonServer.StartSerialSlave(this.serverSettingControl1.TextBox_Serial.Text);
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, cimonServer, this.sslServerControl1, nameof( cimonServer.FrameNo ) );
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
			this.serverSettingControl1.SaveXmlParameter( element );
			this.sslServerControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "FrameNo", textBox_frameNo.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			textBox_frameNo.Text = GetXmlValue( element, "FrameNo", "1", m => m );
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
