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
using System.IO;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFujiSPBServer : HslFormContent
	{
		public FormFujiSPBServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
			comboBox1.SelectedIndex = 3;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

			if (Program.Language == 2)
			{
				Text = "Fuji SPB Server";
				checkBox3.Text = "str-reverse";
			}


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Fuji.Helper.GetSPBAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (sPBServer != null)
			{
				switch(comboBox1.SelectedIndex)
				{
					case 0: sPBServer.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: sPBServer.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: sPBServer.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: sPBServer.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}	
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (sPBServer != null)
			{
				sPBServer.IsStringReverse = checkBox3.Checked;
			}
		}
		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteServer1, e );
			if (e.Cancel) return;

			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start


		private FujiSPBServer sPBServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				sPBServer = new FujiSPBServer( );                       // 实例化对象
				sPBServer.Station = int.Parse( textBox1.Text );
				sPBServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				sPBServer.OnDataReceived += BusTcpServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( sPBServer );
				sPBServer.IsStringReverse = checkBox3.Checked;
				userControlReadWriteServer1.SetReadWriteServer( sPBServer, "D100" );

				ComboBox1_SelectedIndexChanged( sender, e );            // 设置 DataFormat

				if (this.serverSettingControl1.ServerStart( sPBServer ) == false) return;
				userControlReadWriteServer1.SetEnable( true );

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", sPBServer, this.sslServerControl1, nameof( sPBServer.Station ), nameof( sPBServer.DataFormat ), nameof( sPBServer.IsStringReverse ) );
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
			sPBServer?.ServerClose( );
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
			if (sPBServer != null)
			{
				try
				{
					sPBServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
					this.serverSettingControl1.ButtonSerial.Enabled = false;
					// 设置代码示例
					codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, sPBServer, nameof( sPBServer.Station ) );
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
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			this.userControlReadWriteServer1.GetDataTable( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			textBox1.Text = GetXmlValue( element, DemoDeviceList.XmlStation, "1", m => m );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			comboBox1.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, 3, int.Parse );
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
