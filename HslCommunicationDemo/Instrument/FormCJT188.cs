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
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunication.Instrument.CJT;
using HslCommunication.Instrument.CJT.Helper;
using HslCommunicationDemo.Modbus;
using HslCommunicationDemo.Instrument;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormCJT188 : HslFormContent
	{
		public FormCJT188( )
		{
			InitializeComponent( );
		}

		private CJT188 cjt188 = null;
		private CJT188Control control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			control = new CJT188Control( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.CJT188Helper.GetCJT188Address( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "CJT188 Read Demo";
				label_address.Text = "station";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			cjt188?.Close( );
			cjt188 = new CJT188( textBox_station.Text );
			cjt188.LogNet = LogNet;
			cjt188.InstrumentType = Convert.ToByte( textBox_type.Text, 16 );
			cjt188.EnableCodeFE = checkBox_enable_Fe.Checked;


			try
			{
				this.pipeSelectControl1.IniPipe( cjt188 );
				OperateResult open = DeviceConnectPLC( cjt188 );
				if (open.IsSuccess)
				{
					userControlReadWriteDevice1.SetEnable( true );
					button1.Enabled = false;
					panel2.Enabled = true;

					// 68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16
					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( cjt188, "90-1F", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( cjt188, "90-1F", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => cjt188.ReadFromCoreServer( m, true, false ), string.Empty, "68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16" );

					control.SetDevice( cjt188, "90-1F" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( "cjt" );
					codeExampleControl.SetCodeText( "cjt", cjt188, nameof( cjt188.Station ), nameof( cjt188.InstrumentType ), nameof( cjt188.EnableCodeFE ) );
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
			cjt188.Close( ); 
			userControlReadWriteDevice1.SetEnable( false );
			button1.Enabled = true;
			panel2.Enabled = false;
			this.pipeSelectControl1.ExtraCloseAction( cjt188 );
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( "InstrumentType", textBox_type.Text );
			element.SetAttributeValue( "FeHead", checkBox_enable_Fe.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox_type.Text = GetXmlValue( element, "InstrumentType", textBox_type.Text, m => m );
			checkBox_enable_Fe.Checked = GetXmlValue( element, "FeHead", checkBox_enable_Fe.Checked, bool.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
