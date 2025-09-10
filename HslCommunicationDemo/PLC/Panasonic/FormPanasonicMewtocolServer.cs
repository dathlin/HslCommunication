﻿using System;
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
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Mewtocol Server";
			}


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Panasonic.Helper.GetMewtocolAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;

		}

		private void button5_Click( object sender, EventArgs e )
		{
			if (mewtocolServer != null)
			{
				try
				{
					mewtocolServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, mewtocolServer,this.sslServerControl1, nameof( mewtocolServer.Station ) );
				}
				catch (Exception ex)
				{
					HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
				}
			}
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private HslCommunication.Profinet.Panasonic.PanasonicMewtocolServer mewtocolServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		//private Timer timer;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				mewtocolServer = new HslCommunication.Profinet.Panasonic.PanasonicMewtocolServer( );                       // 实例化对象
				mewtocolServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				mewtocolServer.OnDataReceived += BusTcpServer_OnDataReceived;
				mewtocolServer.Station        = byte.Parse( textBox_station.Text );

				sslServerControl1.InitializeServer( mewtocolServer );
				if (this.serverSettingControl1.ServerStart( mewtocolServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( mewtocolServer, "D100" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", mewtocolServer, this.sslServerControl1, nameof( mewtocolServer.Station ) );
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
			mewtocolServer?.CloseSerialSlave( );
			mewtocolServer?.ServerClose( );
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
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			this.userControlReadWriteServer1.GetDataTable( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.userControlReadWriteServer1.LoadDataTable( element );
			this.textBox_station.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "238", m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}


	}
}
