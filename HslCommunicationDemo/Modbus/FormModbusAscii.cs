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
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.Modbus;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormModbusAscii : HslFormContent
	{
		public FormModbusAscii( )
		{
			InitializeComponent( );

			checkBox_station_check.CheckedChanged += CheckBox_station_check_CheckedChanged;
		}


		private ModbusAscii busAsciiClient = null;
		private ModbusControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox2.SelectedIndex = 2;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

			Language( Program.Language );
			control = new ModbusControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetModbusAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteDevice1.SetEnable( false );
		}



		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Modbus Ascii Read Demo";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
                label_BroadcastStation.Text = "BroadcastStat:";
            }
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busAsciiClient != null)
			{
				busAsciiClient.IsStringReverse = checkBox3.Checked;
			}
		}

		private void CheckBox_station_check_CheckedChanged( object sender, EventArgs e )
		{
			if (busAsciiClient != null)
			{
				busAsciiClient.StationCheckMacth = checkBox_station_check.Checked;
			}
		}


		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busAsciiClient != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "station input wrong！" );
				return;
			}

			busAsciiClient?.Close( );
			busAsciiClient = new ModbusAscii( station );
			busAsciiClient.AddressStartWithZero = checkBox1.Checked;
			busAsciiClient.LogNet = LogNet;
			busAsciiClient.StationCheckMacth = checkBox_station_check.Checked;
			if (!string.IsNullOrEmpty( textBox_BroadcastStation.Text ))
				busAsciiClient.BroadcastStation = int.Parse( textBox_BroadcastStation.Text );

			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
			busAsciiClient.IsStringReverse = checkBox3.Checked;

			try
			{
				this.pipeSelectControl1.IniPipe( busAsciiClient );
				OperateResult open = DeviceConnectPLC( busAsciiClient );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( busAsciiClient, "100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( busAsciiClient, "100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busAsciiClient.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busAsciiClient.ReadFromCoreServer( ModbusInfo.TransModbusCoreToAsciiPackCommand( m ), true, false ), "Modbus Core", "example: 01 03 00 00 00 01" );

					control.SetDevice( busAsciiClient, "100" );

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.ModbusDeviceName );
					codeExampleControl.SetCodeText( DemoUtils.ModbusDeviceName, busAsciiClient, nameof( busAsciiClient.AddressStartWithZero ), nameof( busAsciiClient.IsStringReverse ),
						nameof( busAsciiClient.DataFormat ), nameof( busAsciiClient.Station ), nameof( busAsciiClient.StationCheckMacth ), nameof( busAsciiClient.BroadcastStation ) );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			busAsciiClient.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( busAsciiClient );
		}

		

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
			element.SetAttributeValue( nameof( ModbusAscii.StationCheckMacth ), checkBox_station_check.Checked );
			element.SetAttributeValue( nameof( ModbusAscii.BroadcastStation ), textBox_BroadcastStation.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
			comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			checkBox_station_check.Checked = GetXmlValue( element, nameof( ModbusAscii.StationCheckMacth ), checkBox_station_check.Checked, bool.Parse );
			textBox_BroadcastStation.Text = GetXmlValue( element, nameof( ModbusAscii.BroadcastStation ), "", m => m );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
