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
using System.Xml.Linq;
using System.IO.Ports;
using HslCommunicationDemo.PLC.Melsec;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormMelsecLinks : HslFormContent
	{
		public FormMelsecLinks( )
		{
			InitializeComponent( );
			melsecSerial = new MelsecFxLinks( );
		}

		private MelsecFxLinks melsecSerial = null;
		private FxLinksControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			try
			{
				comboBox_format.SelectedIndex = 0;
			}
			catch
			{
			}

			Language( Program.Language );

			control = new FxLinksControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetFxLinksAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Station:";
				label22.Text = "TimeOut:";
				checkBox1.Text = "SumCheck?";

				label2.Text = "Format:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			melsecSerial?.Close( );
			melsecSerial = new MelsecFxLinks( );
			melsecSerial.LogNet = LogNet;
			
			try
			{
				this.pipeSelectControl1.IniPipe( melsecSerial );
				melsecSerial.Station = byte.Parse( textBox15.Text );
				melsecSerial.WaittingTime = byte.Parse( textBox18.Text );
				melsecSerial.SumCheck = checkBox1.Checked;
				melsecSerial.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );

				OperateResult open = DeviceConnectPLC( melsecSerial );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( melsecSerial, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsecSerial, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsecSerial.ReadFromCoreServer( m ), string.Empty, string.Empty );
					control.SetDevice( melsecSerial, "D100" );

					// 设置示例的代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( melsecSerial, nameof( melsecSerial.Station ), nameof( melsecSerial.WaittingTime ), nameof( melsecSerial.SumCheck ), nameof( melsecSerial.Format ) );
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
			melsecSerial.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( melsecSerial );
		}

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = melsecSerial.ReadBool( "M100", 10 );
			if(read.IsSuccess)
			{
				bool m100 = read.Content[0];
				// and so on
				bool m109 = read.Content[9];
			}
			else
			{
				// failed
			}
		}
		

		private void test3( )
		{
			short d100_short = melsecSerial.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsecSerial.ReadUInt16( "D100" ).Content;
			int d100_int = melsecSerial.ReadInt32( "D100" ).Content;
			uint d100_uint = melsecSerial.ReadUInt32( "D100" ).Content;
			long d100_long = melsecSerial.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsecSerial.ReadUInt64( "D100" ).Content;
			float d100_float = melsecSerial.ReadFloat( "D100" ).Content;
			double d100_double = melsecSerial.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsecSerial.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			melsecSerial.Write( "D100", (short)5 );
			melsecSerial.Write( "D100", (ushort)5 );
			melsecSerial.Write( "D100", 5 );
			melsecSerial.Write( "D100", (uint)5 );
			melsecSerial.Write( "D100", (long)5 );
			melsecSerial.Write( "D100", (ulong)5 );
			melsecSerial.Write( "D100", 5f );
			melsecSerial.Write( "D100", 5d );
			// length should Multiples of 2 
			melsecSerial.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = melsecSerial.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = melsecSerial.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsecSerial.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsecSerial.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = melsecSerial.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsecSerial.WriteCustomer( "D100", new UserType( ) );

			melsecSerial.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

		}

		// private MelsecMcAsciiNet melsec_ascii_net = null;

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox18.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSumCheck, checkBox1.Checked );
			element.SetAttributeValue( "MelsecFormat", comboBox_format.SelectedIndex );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox18.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlSumCheck ).Value );
			comboBox_format.SelectedIndex = GetXmlValue( element, "MelsecFormat", comboBox_format.SelectedIndex, int.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
