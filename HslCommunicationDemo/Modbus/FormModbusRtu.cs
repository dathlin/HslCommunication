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
using HslCommunication.Serial;
using HslCommunicationDemo.DemoControl;
using System.Runtime.Remoting.Contexts;

namespace HslCommunicationDemo
{
	public partial class FormModbusRtu : HslFormContent
	{
		public FormModbusRtu( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );

			checkBox_DisableFunctionCode06.CheckedChanged +=CheckBox_DisableFunctionCode06_CheckedChanged;
		}

		private void CheckBox_DisableFunctionCode06_CheckedChanged( object sender, EventArgs e )
		{
			if (busRtuClient != null)
			{
				busRtuClient.DisableFunctionCode06 = checkBox_DisableFunctionCode06.Checked;
			}
		}

		private ModbusRtu busRtuClient = null;
		private ModbusControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private StationSearchControl stationSearchControl;

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

			stationSearchControl = new StationSearchControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( stationSearchControl, false, StationSearchControl.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );


		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Modbus Rtu Read Demo";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label_BroadcastStation.Text = "BroadcastStat:";
				label_batch_length.Text = "BatchLen:";
			}
			else
			{
				checkBox_DisableFunctionCode06.Text = "禁用功能码06";
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busRtuClient != null)
			{
				busRtuClient.IsStringReverse = checkBox3.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busRtuClient != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busRtuClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}


		private void FormModbusRtu_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteDevice1, e );
			if (e.Cancel) return;

			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		

		#region Connect And Close


		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse(textBox15.Text, out byte station))
			{
				DemoUtils.ShowMessage( "Station input wrong！" );
				return;
			}

			busRtuClient?.Close( );
			busRtuClient = new ModbusRtu( station );
			busRtuClient.AddressStartWithZero = checkBox1.Checked;
			busRtuClient.LogNet = LogNet;
			busRtuClient.Crc16CheckEnable = checkBox_crc16.Checked;
			busRtuClient.StationCheckMatch = checkBox_station_check.Checked;
			busRtuClient.DisableFunctionCode06 = checkBox_DisableFunctionCode06.Checked;
			if (!string.IsNullOrEmpty( textBox_BroadcastStation.Text ))
				busRtuClient.BroadcastStation = int.Parse( textBox_BroadcastStation.Text );
			if (!string.IsNullOrEmpty( textBox_batch_length.Text ))
				busRtuClient.WordReadBatchLength = int.Parse( textBox_batch_length.Text );

			ComboBox2_SelectedIndexChanged( null, new EventArgs( ) );
			busRtuClient.IsStringReverse = checkBox3.Checked;

			try
			{
				this.pipeSelectControl1.IniPipe( busRtuClient );
				OperateResult open = DeviceConnectPLC( busRtuClient );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( busRtuClient, "100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( busRtuClient, "100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busRtuClient.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busRtuClient.ReadFromCoreServer( SoftCRC16.CRC16( m ), true, false ), "No CRC", "with no crc16, example: 01 03 00 00 00 01" );

					control.SetDevice( busRtuClient, "100" );
					stationSearchControl.SetModbus( busRtuClient );

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.ModbusDeviceName );
					List<string> paras = new List<string>( );
					paras.Add( nameof( busRtuClient.Station ) );
					paras.Add( nameof( busRtuClient.IsStringReverse ) );
					paras.Add( nameof( busRtuClient.DataFormat ) );
					paras.Add( nameof( busRtuClient.IsClearCacheBeforeRead ) );
					if (busRtuClient.Crc16CheckEnable == false) paras.Add( nameof( busRtuClient.Crc16CheckEnable ) );
					if (busRtuClient.StationCheckMatch == false) paras.Add( nameof( busRtuClient.StationCheckMatch ) );
					if (busRtuClient.BroadcastStation != -1) paras.Add( nameof( busRtuClient.BroadcastStation ) );
					if (busRtuClient.AddressStartWithZero == false) paras.Add( nameof( busRtuClient.AddressStartWithZero ) );
					if (busRtuClient.WordReadBatchLength != 120) paras.Add( nameof( busRtuClient.WordReadBatchLength ) );
					if (busRtuClient.DisableFunctionCode06) paras.Add( nameof( busRtuClient.DisableFunctionCode06 ) );

					codeExampleControl.SetCodeText( DemoUtils.ModbusDeviceName, busRtuClient, paras.ToArray( ) );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( busRtuClient );
			busRtuClient.Close( );
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
			element.SetAttributeValue( "CRC16", checkBox_crc16.Checked );
			element.SetAttributeValue( "StationCheckMacth", checkBox_station_check.Checked );
			element.SetAttributeValue( nameof( ModbusRtu.BroadcastStation ), textBox_BroadcastStation.Text );
			element.SetAttributeValue( nameof( ModbusRtu.DisableFunctionCode06 ), checkBox_DisableFunctionCode06.Checked );

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
			checkBox_crc16.Checked = GetXmlValue( element, "CRC16", checkBox_crc16.Checked, bool.Parse );
			checkBox_station_check.Checked = GetXmlValue( element, "StationCheckMacth", checkBox_station_check.Checked, bool.Parse );
			checkBox_DisableFunctionCode06.Checked = GetXmlValue( element, nameof( ModbusRtu.DisableFunctionCode06 ), false, bool.Parse );
			textBox_BroadcastStation.Text = GetXmlValue( element, nameof( ModbusRtu.BroadcastStation ), "", m => m );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
