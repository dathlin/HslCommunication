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
using HslCommunication.Profinet.Vigor;
using HslCommunication;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Vigor;

namespace HslCommunicationDemo
{
	public partial class FormVigorSerial : HslFormContent
	{
		public FormVigorSerial( )
		{
			InitializeComponent( );
			vigor = new VigorSerial( );
		}


		private VigorSerial vigor = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetVigorAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Vigor Read PLC Demo";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			vigor?.Close( );
			vigor = new VigorSerial( );
			vigor.LogNet = LogNet;
			
			try
			{
				this.pipeSelectControl1.IniPipe( vigor );
				vigor.Station = byte.Parse( textBox15.Text );


				OperateResult open = DeviceConnectPLC( vigor );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( vigor, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( vigor, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => vigor.ReadFromCoreServer( m ), string.Empty, string.Empty );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( vigor, nameof( vigor.Station ) );
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
			vigor.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( vigor );
		}

		

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = vigor.ReadBool( "M100", 10 );
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
			short d100_short = vigor.ReadInt16( "D100" ).Content;
			ushort d100_ushort = vigor.ReadUInt16( "D100" ).Content;
			int d100_int = vigor.ReadInt32( "D100" ).Content;
			uint d100_uint = vigor.ReadUInt32( "D100" ).Content;
			long d100_long = vigor.ReadInt64( "D100" ).Content;
			ulong d100_ulong = vigor.ReadUInt64( "D100" ).Content;
			float d100_float = vigor.ReadFloat( "D100" ).Content;
			double d100_double = vigor.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = vigor.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			vigor.Write( "D100", (short)5 );
			vigor.Write( "D100", (ushort)5 );
			vigor.Write( "D100", 5 );
			vigor.Write( "D100", (uint)5 );
			vigor.Write( "D100", (long)5 );
			vigor.Write( "D100", (ulong)5 );
			vigor.Write( "D100", 5f );
			vigor.Write( "D100", 5d );
			// length should Multiples of 2 
			vigor.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = vigor.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = vigor.ByteTransform.TransInt32( read.Content, 0 );
				float temp = vigor.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = vigor.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = vigor.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			vigor.WriteCustomer( "D100", new UserType( ) );

			vigor.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

		}


		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
