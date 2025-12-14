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
using HslCommunication.Instrument.DLT;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.Instrument;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Instrument.Temperature;

namespace HslCommunicationDemo
{
	public partial class FormYuDianAIBus : HslFormContent
	{
		public FormYuDianAIBus( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}

		private YuDianAIBus yudian = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			this.pipeSelectControl1.SetButtonReference( button1, button2 );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( GetAddressExample( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				label_address.Text = "Station";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteDevice1, e );
			if (e.Cancel) return;

			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			yudian?.Close( );
			yudian = new YuDianAIBus( );
			yudian.Station = byte.Parse( textBox_station.Text );
			yudian.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( yudian );
				OperateResult open = DeviceConnectPLC( yudian );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					userControlReadWriteDevice1.SetReadWriteNet( yudian, "10", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( yudian, "10", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => yudian.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );


					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( "yudian" );
					codeExampleControl.SetCodeText( "yudian", yudian, nameof( yudian.Station ) );
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
			this.pipeSelectControl1.ExtraCloseAction( yudian );
			yudian.Close( );
		}
		
		#endregion
		
		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );


			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;


			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
		public static DeviceAddressExample[] GetAddressExample( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "0", "给定值",   false, false, "读short, 单位同测量值，读4个short分别表示PV,SV,状态,参数值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "1", "HIAL上限报警",   false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "2", "LoAL下限报警",   false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "3", "dHAL正偏差报警", false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "4", "dLAL负偏差报警", false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "5", "AHYS报警回差",   false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "6", "CtrL控制方式",   false, false, "读short, 0，ONOFF；1，APID；2，nPID；3，PoP；4，SoP",   fill: true, unit:"", dataType: "short" ),
				new DeviceAddressExample( "7", "P比例带",        false, false, "读short, 单位同测量值",   fill: true, unit:"0.1℃", dataType: "short" ),
				new DeviceAddressExample( "8", "I 积分时间",     false, false, "读short，单位: 秒",   fill: true, unit:"秒", dataType: "short" ),
				new DeviceAddressExample( "9", "d 微分时间",     false, false, "读short 单位: 0.1秒",   fill: true, unit:"0.1秒", dataType: "short" ),
				new DeviceAddressExample( "10", "CtI控制周期",     false, false, "读short 单位: 0.1秒",   fill: true, unit:"0.1秒", dataType: "short" ),
				new DeviceAddressExample( "22", "Addr 通讯地址",    false, false, "读short",   fill: true, unit:"", dataType: "short" ),
				new DeviceAddressExample( "47", "已运行时间",    false, false, "读short, 0.1分或0.1小时，由PAF参数决定",   fill: true, unit:"", dataType: "short" ),
			};
		}
	}
}
