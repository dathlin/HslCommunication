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
using System.Threading;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormOmronServer : HslFormContent
	{
		public FormOmronServer( )
		{
			InitializeComponent( );

			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

			checkBox_isstringreverse.CheckedChanged += CheckBox_isstringreverse_CheckedChanged;
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void CheckBox_isstringreverse_CheckedChanged( object sender, EventArgs e )
		{
			if (omronFinsServer != null) omronFinsServer.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (omronFinsServer != null) omronFinsServer.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Omron Virtual Server [data support, d, a, h, c, w]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Omron.Helper.GetOmronAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		private HslCommunication.Profinet.Omron.OmronFinsServer omronFinsServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}


			try
			{
				omronFinsServer = new HslCommunication.Profinet.Omron.OmronFinsServer( );                       // 实例化对象
				omronFinsServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
				omronFinsServer.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
				omronFinsServer.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
				this.sslServerControl1.InitializeServer( omronFinsServer );
				omronFinsServer.ServerStart( port );

				userControlReadWriteServer1.SetReadWriteServer( omronFinsServer, "D100" );
				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置示例代码
				codeExampleControl.SetCodeText( "server", "", omronFinsServer, nameof( omronFinsServer.ActiveTimeSpan ), nameof( omronFinsServer.DataFormat ), "ByteTransform.IsStringReverseByteWord" );
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
