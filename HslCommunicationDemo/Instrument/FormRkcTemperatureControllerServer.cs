﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.FATEK;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Instrument.DLT;

namespace HslCommunicationDemo
{
	public partial class FormRkcTemperatureControllerServer : HslFormContent
	{
		public FormRkcTemperatureControllerServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormDLT645Server_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "RkcTemperature Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.RkcHelper.GetRkcAddress( ) );
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


		private HslCommunication.Instrument.RKC.TemperatureControllerServer rkcServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				rkcServer = new HslCommunication.Instrument.RKC.TemperatureControllerServer( );                       // 实例化对象
				rkcServer.Station = byte.Parse( textBox1.Text );
				rkcServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				rkcServer.OnDataReceived += BusTcpServer_OnDataReceived;

				this.sslServerControl1.InitializeServer( rkcServer );
				if (this.serverSettingControl1.ServerStart( rkcServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( rkcServer, "M1" );
				userControlReadWriteServer1.ReadWriteOpControl.EnableRKC( );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", rkcServer, nameof( rkcServer.Station ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			rkcServer?.CloseSerialSlave( );
			rkcServer?.ServerClose( );
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
			if (rkcServer != null)
			{
				try
				{
					rkcServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, rkcServer, nameof( rkcServer.Station ) );
				}
				catch(Exception ex)
				{
					DemoUtils.ShowMessage( "Start Failed：" + ex.Message );
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Start tcp server first please!" );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			this.userControlReadWriteServer1.LoadDataTable( element );
			this.textBox1.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "1", m => m );
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
