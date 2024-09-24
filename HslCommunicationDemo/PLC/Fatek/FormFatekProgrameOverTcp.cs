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
using HslCommunication.Profinet.FATEK;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Fatek;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFatekProgrameOverTcp : HslFormContent
	{
		public FormFatekProgrameOverTcp( )
		{
			InitializeComponent( );
			fatekProgram = new FatekProgramOverTcp( );
		}


		private FatekProgramOverTcp fatekProgram = null;
		private FatekProgrameControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			control = new FatekProgrameControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Fatek.Helper.GetDeviceAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "FATEK Read PLC Demo[OverTcp]";
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

			fatekProgram?.ConnectClose( );
			fatekProgram = new FatekProgramOverTcp( );
			fatekProgram.LogNet = LogNet;

			try
			{
				fatekProgram.Station = byte.Parse( textBox15.Text );
				this.pipeSelectControl1.IniPipe( fatekProgram );
				OperateResult connect = DeviceConnectPLC( fatekProgram );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );

					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( fatekProgram, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( fatekProgram, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => fatekProgram.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					control.SetDevice( fatekProgram, "D100" );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( fatekProgram, nameof( fatekProgram.Station ) );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode );
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
			fatekProgram.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( fatekProgram );
		}

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = fatekProgram.ReadBool( "M100", 10 );
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
			short d100_short = fatekProgram.ReadInt16( "D100" ).Content;
			ushort d100_ushort = fatekProgram.ReadUInt16( "D100" ).Content;
			int d100_int = fatekProgram.ReadInt32( "D100" ).Content;
			uint d100_uint = fatekProgram.ReadUInt32( "D100" ).Content;
			long d100_long = fatekProgram.ReadInt64( "D100" ).Content;
			ulong d100_ulong = fatekProgram.ReadUInt64( "D100" ).Content;
			float d100_float = fatekProgram.ReadFloat( "D100" ).Content;
			double d100_double = fatekProgram.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = fatekProgram.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			fatekProgram.Write( "D100", (short)5 );
			fatekProgram.Write( "D100", (ushort)5 );
			fatekProgram.Write( "D100", 5 );
			fatekProgram.Write( "D100", (uint)5 );
			fatekProgram.Write( "D100", (long)5 );
			fatekProgram.Write( "D100", (ulong)5 );
			fatekProgram.Write( "D100", 5f );
			fatekProgram.Write( "D100", 5d );
			// length should Multiples of 2 
			fatekProgram.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = fatekProgram.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = fatekProgram.ByteTransform.TransInt32( read.Content, 0 );
				float temp = fatekProgram.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = fatekProgram.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = fatekProgram.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			fatekProgram.WriteCustomer( "D100", new UserType( ) );

			fatekProgram.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
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
