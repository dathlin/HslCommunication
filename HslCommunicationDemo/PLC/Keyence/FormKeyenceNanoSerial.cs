using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Profinet.Melsec;
using HslCommunication;
using HslCommunication.Profinet.Keyence;
using System.Xml.Linq;
using System.IO.Ports;
using HslCommunicationDemo.PLC.Keyence;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceNanoSerial : HslFormContent
	{
		public FormKeyenceNanoSerial( )
		{
			InitializeComponent( );
			keyenceNanoSerial = new KeyenceNanoSerial( );
		}


		private KeyenceNanoSerial keyenceNanoSerial = null;
		private NanoControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new NanoControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Keyence.Helper.GetKeyenceKvAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence Read PLC Demo";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label2.Text = "Station:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close

		
		private void button1_Click( object sender, EventArgs e )
		{
			if(!byte.TryParse(textBox3.Text,out byte station ))
			{
				MessageBox.Show( "Station int wrong, it needs 0 - 255" );
				return;
			}

			keyenceNanoSerial?.Close( );
			keyenceNanoSerial = new KeyenceNanoSerial( );
			keyenceNanoSerial.UseStation = checkBox1.Checked;
			keyenceNanoSerial.Station = station;
			keyenceNanoSerial.LogNet = LogNet;
			try
			{
				this.pipeSelectControl1.IniPipe( keyenceNanoSerial );
				OperateResult open = DeviceConnectPLC( keyenceNanoSerial );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( keyenceNanoSerial, "DM100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( keyenceNanoSerial, "DM100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => keyenceNanoSerial.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					// 特殊读取
					control.SetDevice( keyenceNanoSerial, "DM100" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( keyenceNanoSerial, nameof( keyenceNanoSerial.UseStation ), nameof( keyenceNanoSerial.Station ) );
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
			keyenceNanoSerial.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( keyenceNanoSerial );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "UseStation", checkBox1.Checked );
			element.SetAttributeValue( "Station", textBox3.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			this.checkBox1.Checked = GetXmlValue( element, "UseStation", this.checkBox1.Checked, bool.Parse );
			this.textBox3.Text = GetXmlValue( element, "Station", textBox3.Text, m => m );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
