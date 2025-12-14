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
using System.Xml.Linq;
using HslCommunicationDemo.Modbus;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
	public partial class FormModbus : HslFormContent
	{
		public FormModbus()
		{
			InitializeComponent( );

			DemoUtils.SetPanelAnchor( panel1, panel2 );
			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
			checkBox_DisableFunctionCode06.CheckedChanged +=CheckBox_DisableFunctionCode06_CheckedChanged;
		}

		private void CheckBox_DisableFunctionCode06_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpClient != null)
			{
				busTcpClient.DisableFunctionCode06 = checkBox_DisableFunctionCode06.Checked;
			}
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpClient != null)
			{
				busTcpClient.AddressStartWithZero = checkBox1.Checked;
			}
		}

		private ModbusTcpNet busTcpClient = null;
		private ModbusControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private StationSearchControl stationSearchControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.SelectedIndex = 2;

			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

			Language( Program.Language );
			this.pipeSelectControl1.SetButtonReference( button1, button2 );

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
				Text = "Modbus Tcp Read Demo";

				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";

				checkBox2.Text = "Check Message ID";
				label_BroadcastStation.Text = "BroadcastStat:";
				label_batch_length.Text = "BatchLen:";
			}
			else if (language == 1)
			{
				checkBox_DisableFunctionCode06.Text = "禁用功能码06";
			}
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busTcpClient != null)
			{
				switch (comboBox1.SelectedIndex)
				{
					case 0: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.ABCD;break;
					case 1: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default:break;
				}
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busTcpClient != null)
			{
				busTcpClient.IsStringReverse = checkBox3.Checked;
			}
		}


		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteDevice1, e );
			if (e.Cancel) return;

			if (button1.Enabled == false) button2_Click( sender: null, EventArgs.Empty );
		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			// 连接
			if(!byte.TryParse(textBox15.Text,out byte station))
			{
				DemoUtils.ShowMessage( "Station input is wrong！" );
				return;
			}

			busTcpClient?.ConnectClose( );
			busTcpClient = new ModbusTcpNet( );
			busTcpClient.Station = station;
			busTcpClient.AddressStartWithZero = checkBox1.Checked;
			busTcpClient.IsCheckMessageId = checkBox2.Checked;
			busTcpClient.StationCheckMatch = checkBox_station_check.Checked;
			busTcpClient.DisableFunctionCode06 = checkBox_DisableFunctionCode06.Checked;
			busTcpClient.LogNet = LogNet;
			if (!string.IsNullOrEmpty( textBox_BroadcastStation.Text ))
				busTcpClient.BroadcastStation = int.Parse( textBox_BroadcastStation.Text );
			if (!string.IsNullOrEmpty( textBox_batch_length.Text ))
				busTcpClient.WordReadBatchLength = int.Parse( textBox_batch_length.Text );

			ComboBox1_SelectedIndexChanged( null, new EventArgs( ) );  // 设置数据服务
			busTcpClient.IsStringReverse = checkBox3.Checked;

			try
			{
				this.pipeSelectControl1.IniPipe( busTcpClient );
				OperateResult connect = DeviceConnectPLC( busTcpClient );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( busTcpClient, "100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( busTcpClient, "100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busTcpClient.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busTcpClient.ReadFromCoreServer( m ), "Modbus Core", "Example: 01 03 00 00 00 02" );
					control.SetDevice( busTcpClient, "100" );

					stationSearchControl.SetModbus( busTcpClient );

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.ModbusDeviceName );
					List<string> paras = new List<string>( );
					paras.Add( nameof( busTcpClient.Station ) );
					paras.Add( nameof( busTcpClient.IsStringReverse ) );
					paras.Add( nameof( busTcpClient.DataFormat ) );
					if (busTcpClient.BroadcastStation != -1) paras.Add( nameof( busTcpClient.BroadcastStation ) );
					if (busTcpClient.IsCheckMessageId == false) paras.Add( nameof( busTcpClient.IsCheckMessageId ) );
					if (busTcpClient.AddressStartWithZero == false) paras.Add( nameof( busTcpClient.AddressStartWithZero ) );
					if (busTcpClient.WordReadBatchLength != 120) paras.Add( nameof( busTcpClient.WordReadBatchLength ) );
					if (busTcpClient.StationCheckMatch == false) paras.Add( nameof( busTcpClient.StationCheckMatch ) );
					if (busTcpClient.DisableFunctionCode06) paras.Add( nameof( busTcpClient.DisableFunctionCode06 ) );

					codeExampleControl.SetCodeText( DemoUtils.ModbusDeviceName, busTcpClient, paras.ToArray( ) );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode);
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
			this.pipeSelectControl1.ExtraCloseAction( busTcpClient );
			busTcpClient?.ConnectClose( );
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation,                     textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero,        checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat,                  comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse,               checkBox3.Checked );
			element.SetAttributeValue( nameof( ModbusTcpNet.BroadcastStation ),       textBox_BroadcastStation.Text );
			element.SetAttributeValue( nameof( ModbusTcpNet.StationCheckMatch ),      checkBox_station_check.Checked );
			element.SetAttributeValue( nameof( ModbusTcpNet.WordReadBatchLength ),    textBox_batch_length.Text );
			element.SetAttributeValue( nameof( ModbusTcpNet.DisableFunctionCode06 ),  checkBox_DisableFunctionCode06.Checked );
			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox15.Text                         = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox1.Checked                      = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
			comboBox1.SelectedIndex                = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox3.Checked                      = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
			textBox_BroadcastStation.Text          = GetXmlValue( element, nameof( ModbusTcpNet.BroadcastStation ), "", m => m );
			checkBox_station_check.Checked         = GetXmlValue( element, nameof( ModbusTcpNet.StationCheckMatch ), true, bool.Parse );
			textBox_batch_length.Text              = GetXmlValue( element, nameof( ModbusTcpNet.WordReadBatchLength ), "", m => m );
			checkBox_DisableFunctionCode06.Checked = GetXmlValue( element, nameof( ModbusTcpNet.DisableFunctionCode06 ), false, bool.Parse );

			if ( this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
