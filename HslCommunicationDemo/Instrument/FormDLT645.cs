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

namespace HslCommunicationDemo
{
	public partial class FormDLT645 : HslFormContent
	{
		public FormDLT645( )
		{
			InitializeComponent( );
		}

		private DLT645 dLT645 = null;
		private DLT645Control control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new DLT645Control( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.DLTHelper.GetDlt645Address( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "DLT645 Read Demo";
				label_address.Text = "station";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			dLT645?.Close( );
			dLT645 = new DLT645( textBox_station.Text, textBox_password.Text, textBox_op_code.Text );
			dLT645.LogNet = LogNet;
			dLT645.EnableCodeFE = checkBox_enable_Fe.Checked;


			try
			{
				this.pipeSelectControl1.IniPipe( dLT645 );
				OperateResult open = DeviceConnectPLC( dLT645 );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16
					//userControlReadWriteOp1.SetReadWriteNet( dLT645, "00-00-00-00", false );

					userControlReadWriteDevice1.SetReadWriteNet( dLT645, "00-00-00-00", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( dLT645, "00-00-00-00", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => dLT645.ReadFromCoreServer( m, true, false ), string.Empty, "68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16" );

					control.SetDevice( dLT645, "00-00-00-00" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( "dlt" );
					codeExampleControl.SetCodeText( "dlt", dLT645, nameof( dLT645.Station ), nameof( dLT645.EnableCodeFE ), nameof( dLT645.Password ), nameof( dLT645.OpCode ) );
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
			dLT645.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( dLT645 );
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox_password.Text );
			element.SetAttributeValue( "OpCode", textBox_op_code.Text );
			element.SetAttributeValue( "FeHead", checkBox_enable_Fe.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox_password.Text = GetXmlValue( element, DemoDeviceList.XmlPassword, textBox_password.Text, m => m );
			textBox_op_code.Text = GetXmlValue( element, "OpCode", textBox_op_code.Text, m => m );
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
