using System;
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
	public partial class FormDLT645With1997Server : HslFormContent
	{
		public FormDLT645With1997Server( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );

			checkBox_station_match.CheckedChanged += CheckBox_station_match_CheckedChanged;
			checkBox_enableFE.CheckedChanged += CheckBox_enableFE_CheckedChanged;
			checkBox_string_reverse.CheckedChanged += CheckBox3_CheckedChanged;
		}

		private void CheckBox_enableFE_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.EnableCodeFE = checkBox_enableFE.Checked;
			}
		}

		private void CheckBox_station_match_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.StationMatch = checkBox_station_match.Checked;
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.StringReverse = checkBox_string_reverse.Checked;
			}
		}
		private void FormDLT645Server_Load( object sender, EventArgs e )
		{

			if (Program.Language == 2)
			{
				Text = "DLT645 Virtual Server";
				checkBox_string_reverse.Text = "str-reverse";
			}
			else
			{
				checkBox_station_match.Text = "是否站号匹配";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.DLTHelper.GetDlt6451997Address( ) );
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
			CheckTableDataChanged( this.userControlReadWriteServer1, e );
			if (e.Cancel) return;

			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private DLT645With1997Server dLT645Server;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				dLT645Server = new DLT645With1997Server( );                       // 实例化对象
				dLT645Server.Station = textBox1.Text;
				dLT645Server.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				dLT645Server.OnDataReceived += BusTcpServer_OnDataReceived;
				dLT645Server.StringReverse = checkBox_string_reverse.Checked;
				dLT645Server.EnableCodeFE = checkBox_enableFE.Checked;
				dLT645Server.StationMatch = checkBox_station_match.Checked;

				this.sslServerControl1.InitializeServer( dLT645Server );
				if (this.serverSettingControl1.ServerStart( dLT645Server ) == false) return;

				userControlReadWriteServer1.SetReadWriteServer( dLT645Server, "B6-11" );
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", dLT645Server, this.sslServerControl1, nameof( dLT645Server.Station ), nameof( dLT645Server.StringReverse ), nameof( dLT645Server.EnableCodeFE ), nameof( dLT645Server.StationMatch ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			dLT645Server?.CloseSerialSlave( );
			dLT645Server?.ServerClose( );
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
			if (dLT645Server != null)
			{
				try
				{
					OperateResult open = dLT645Server.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
					if (!open.IsSuccess)
					{
						DemoUtils.ShowMessage( "Start Failed：" + open.Message );
						return;
					}
					this.serverSettingControl1.ButtonSerial.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, dLT645Server, this.sslServerControl1, nameof( dLT645Server.Station ), nameof( dLT645Server.StringReverse ), nameof( dLT645Server.EnableCodeFE ), nameof( dLT645Server.StationMatch ) );
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
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox_string_reverse.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
			element.SetAttributeValue( "EnableFE", checkBox_enableFE.Checked );
			element.SetAttributeValue( "StationMatch", checkBox_station_match.Checked );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			checkBox_string_reverse.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			textBox1.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "1", m => m );
			checkBox_enableFE.Checked = GetXmlValue( element, "EnableFE", false, bool.Parse );
			checkBox_station_match.Checked = GetXmlValue( element, "StationMatch", false, bool.Parse );
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
