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
	public partial class FormMelsecSerial : HslFormContent
	{
		public FormMelsecSerial( )
		{
			InitializeComponent( );
		}


		private MelsecFxSerial melsecSerial = null;
		private MelsecSerialControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new MelsecSerialControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetFxSerialAddress( ) );
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
				checkBox_newVersion.Text = "New Version Message?";
				checkBox_changeAuto.Text = "Change PLC BaudRate?";
				userControlHead1.ProtocolInfo = "fx serial protocol";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close

		
		private void button1_Click( object sender, EventArgs e )
		{
			melsecSerial?.Close( );
			melsecSerial = new MelsecFxSerial( );
			melsecSerial.IsNewVersion = checkBox_newVersion.Checked;
			melsecSerial.AutoChangeBaudRate = checkBox_changeAuto.Checked;
			melsecSerial.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( melsecSerial );
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
					codeExampleControl.SetCodeText( melsecSerial, nameof( melsecSerial.IsNewVersion ), nameof( melsecSerial.AutoChangeBaudRate ) );
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

		#region Use Exmaple

		private void test1()
		{
			// 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

			// if we want read M100-M109, so we can do like this
			OperateResult<bool[]> read = melsecSerial.ReadBool( "M100", 10 );
			if (read.IsSuccess)
			{
				bool m100 = read.Content[0];
				// and so on
				// ...
				// then
				bool m109 = read.Content[9];
			}
			else
			{
				// failed, the follow operation is output the wrong msg
				Console.WriteLine( "Read failed: " + read.ToMessageShowString( ) );
			}
		}


		private void test3()
		{
			// These are the underlying operations that ignore validation of success
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
		private void test4()
		{
			// These are the underlying operations that ignore validation of success
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


		private void test5()
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = melsecSerial.Read( "D100", 10 );
			if (read.IsSuccess)
			{
				int count = melsecSerial.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsecSerial.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsecSerial.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6()
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = melsecSerial.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsecSerial.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			melsecSerial.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}

		#endregion



		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "NewVersion", checkBox_newVersion.Checked );
			element.SetAttributeValue( "ChangeAuto", checkBox_changeAuto.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			checkBox_newVersion.Checked = GetXmlValue( element, "NewVersion", checkBox_newVersion.Checked, bool.Parse );
			checkBox_changeAuto.Checked = GetXmlValue( element, "ChangeAuto", checkBox_changeAuto.Checked, bool.Parse );
			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
