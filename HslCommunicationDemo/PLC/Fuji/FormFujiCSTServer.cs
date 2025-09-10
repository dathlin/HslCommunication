﻿using System;
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
	public partial class FormFujiCSTServer : HslFormContent
	{
		public FormFujiCSTServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "FujiCST Virtual Server";
			}


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Fuji.Helper.GetCSTNAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start

		private FujiCommandSettingTypeServer fujiSPHServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				fujiSPHServer = new FujiCommandSettingTypeServer( );                       // 实例化对象
				fujiSPHServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );     // 如果客户端1个小时不通信，就关闭连接
				fujiSPHServer.OnDataReceived += MelsecMcServer_OnDataReceived;
				fujiSPHServer.DataSwap = checkBox1.Checked;

				this.sslServerControl1.InitializeServer( fujiSPHServer );
				if (this.serverSettingControl1.ServerStart( fujiSPHServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( fujiSPHServer, "BD100" );
				userControlReadWriteServer1.SetEnable( true );


				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", fujiSPHServer, this.sslServerControl1, nameof( fujiSPHServer.DataSwap ) );
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
			fujiSPHServer?.ServerClose( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			fujiSPHServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
			this.serverSettingControl1.ButtonSerial.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, fujiSPHServer, this.sslServerControl1, nameof( fujiSPHServer.DataSwap ) );

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
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "DataSwap", checkBox1.Checked );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.userControlReadWriteServer1.LoadDataTable( element );
			checkBox1.Checked = GetXmlValue( element, "DataSwap", false, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
