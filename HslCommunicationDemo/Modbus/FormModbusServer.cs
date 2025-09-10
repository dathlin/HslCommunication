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
using System.IO;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
	public partial class FormModbusServer : HslFormContent
	{
		public FormModbusServer( )
		{
			InitializeComponent( );

			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox2.SelectedIndex = 2;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox_remote_write.CheckedChanged += CheckBox1_CheckedChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
			checkBox_maskcode.CheckedChanged += CheckBox_maskcode_CheckedChanged;

			if (Program.Language == 2)
			{
				Text = "Modbus Virtual Server";
				checkBox3.Text = "str-reverse";
				checkBox_remote_write.Text = "Remote write";
				checkBox_RtuOverTcp.Text = "Rtu Msg";
				label2.Text = "Least Time:";
			}
			else
			{
				checkBox_station_isolation.Text = "站号数据隔离";
			}


			addressExampleControl = new AddressExampleControl( );

			addressExampleControl.SetAddressExample( HslCommunicationDemo.Modbus.Helper.GetModbusAddressExamples( ).RemoveLast( 4 ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}

		private void CheckBox_maskcode_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpServer != null)
			{
				busTcpServer.EnableWriteMaskCode = checkBox_maskcode.Checked;
			}
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpServer != null)
			{
				busTcpServer.EnableWrite = checkBox_remote_write.Checked;
			}
		}


		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busTcpServer != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busTcpServer.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpServer != null)
			{
				busTcpServer.IsStringReverse = checkBox3.Checked;
			}
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			busTcpServer?.ServerClose( );
		}

		#region Server Start


		private HslCommunication.ModBus.ModbusTcpServer busTcpServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse( textBox_station.Text, out byte station ))
			{ 
				DemoUtils.ShowMessage( "Station input wrong!" );
				return;
			}

			try
			{
				busTcpServer = new HslCommunication.ModBus.ModbusTcpServer( );                       // 实例化对象
				busTcpServer.ActiveTimeSpan           = TimeSpan.FromHours( 1 );
				busTcpServer.OnDataReceived           += BusTcpServer_OnDataReceived;
				busTcpServer.EnableWrite              = checkBox_remote_write.Checked;
				busTcpServer.Station                  = station;
				busTcpServer.StationDataIsolation     = checkBox_station_isolation.Checked;
				busTcpServer.UseModbusRtuOverTcp      = checkBox_RtuOverTcp.Checked;
				busTcpServer.EnableWriteMaskCode      = checkBox_maskcode.Checked;
				busTcpServer.ForceSerialReceiveOnce   = checkBox_forceReceiveOnce.Checked;

				ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
				busTcpServer.IsStringReverse = checkBox3.Checked;

				this.sslServerControl1.InitializeServer( busTcpServer );
				if (this.serverSettingControl1.ServerStart( busTcpServer ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( busTcpServer, "100", deviceName: "modbusServer" );
				userControlReadWriteServer1.SetEnable( true );


				// 设置示例代码
				codeExampleControl.SetCodeText( "modbusServer", string.Empty, busTcpServer, this.sslServerControl1,
					nameof( busTcpServer.EnableWrite ), 
					nameof( busTcpServer.EnableIPv6 ),
					nameof( busTcpServer.Station ),
					nameof( busTcpServer.StationDataIsolation ), 
					nameof( busTcpServer.UseModbusRtuOverTcp ),
					nameof( busTcpServer.IsStringReverse ),
					nameof( busTcpServer.EnableWriteMaskCode ),
					nameof( busTcpServer.DataFormat ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			busTcpServer?.CloseSerialSlave( );
			busTcpServer?.ServerClose( );
			this.userControlReadWriteServer1.Close( );
		}

		private void BusTcpServer_OnDataReceived( object sender, PipeSession source, byte[] modbus )
		{
			// 我们可以捕获到接收到的客户端的modbus报文
			// 如果是TCP接收的
			if (source.Communication is PipeTcpNet session)
			{
				// 获取当前客户的IP地址
				string ip = session.IpAddress;
			}

			// 如果是串口接收的
			if (source.Communication is PipeSerialPort serialPort)
			{
				// 获取当前的串口的名称
				string portName = serialPort.GetPipe( ).PortName;
			}
		}

		#endregion

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			if (busTcpServer != null)
			{
				try
				{
					busTcpServer.SerialReceiveAtleastTime = Convert.ToInt32( textBox_time_min.Text );
					busTcpServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置示例代码
					codeExampleControl.SetCodeText( "modbusServer", this.serverSettingControl1.TextBox_Serial.Text, busTcpServer, this.sslServerControl1,
						nameof( busTcpServer.EnableWrite ),
						nameof( busTcpServer.EnableIPv6 ),
						nameof( busTcpServer.Station ),
						nameof( busTcpServer.StationDataIsolation ),
						nameof( busTcpServer.UseModbusRtuOverTcp ),
						nameof( busTcpServer.IsStringReverse ),
						nameof( busTcpServer.DataFormat ),
						nameof( busTcpServer.SerialReceiveAtleastTime ) );
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
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
			element.SetAttributeValue( "RtuOverTcp", checkBox_RtuOverTcp.Checked );
			element.SetAttributeValue( "RemoteWrite", checkBox_remote_write.Checked );
			element.SetAttributeValue( "StationIsolation", checkBox_station_isolation.Checked );
			element.SetAttributeValue( "Station", textBox_station.Text );
			element.SetAttributeValue( "MaskCode", checkBox_maskcode.Checked );
			element.SetAttributeValue( "SerialReceiveAtleastTime", textBox_time_min.Text );

			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			checkBox_RtuOverTcp.Checked = GetXmlValue( element, "RtuOverTcp", false, bool.Parse );
			checkBox_remote_write.Checked = GetXmlValue( element, "RemoteWrite", true, bool.Parse );
			checkBox_station_isolation.Checked = GetXmlValue( element, "StationIsolation", false, bool.Parse );
			textBox_station.Text = GetXmlValue( element, "Station", "1", m => m );
			checkBox_maskcode.Checked = GetXmlValue( element, "MaskCode", true, bool.Parse );
			textBox_time_min.Text = GetXmlValue( element, "SerialReceiveAtleastTime", textBox_time_min.Text, m => m );

			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
