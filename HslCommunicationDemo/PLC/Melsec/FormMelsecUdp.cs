﻿using System;
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
using HslCommunicationDemo.PLC.Melsec;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormMelsecUdp : HslFormContent
	{
		public FormMelsecUdp( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private MelsecMcUdp melsec_net = null;
		private McQna3EControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			control = new McQna3EControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetMcAddress( advance: true ) );
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
				checkBox_string_reverse.Text = "string reverse by word";
			}
			else
			{
				checkBox_EnableWriteBitToWordRegister.Text = "支持使用位写入字寄存器(实际读字，修改位，写字)";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			melsec_net?.ConnectClose( );
			melsec_net = new MelsecMcUdp( );

			try
			{
				this.pipeSelectControl1.IniPipe( melsec_net );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
				return;
			}

			melsec_net.LogNet = LogNet;
			melsec_net.EnableWriteBitToWordRegister = checkBox_EnableWriteBitToWordRegister.Checked;
			melsec_net.ByteTransform.IsStringReverseByteWord = checkBox_string_reverse.Checked;
			//melsec_net.LocalBinding = new System.Net.IPEndPoint( System.Net.IPAddress.Any, 20000 );  // 如果需要固定本地的端口20000的例子
			//melsec_net.GetPipeSocket( ).SetMultiPorts( new int[] { port, 6001 } );
			OperateResult connect = DeviceConnectPLC( melsec_net );
			if (connect.IsSuccess)
			{
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );
				// 设置子控件的读取能力
				userControlReadWriteDevice1.SetReadWriteNet( melsec_net, "D100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsec_net, "D100", string.Empty );
				userControlReadWriteDevice1.BatchRead.SetReadRandom( melsec_net.ReadRandom, "D100;W100;D500" );
				userControlReadWriteDevice1.BatchRead.SetReadWordRandom( melsec_net.ReadRandom, "D100;W100;D500" );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsec_net.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				control.SetDevice( melsec_net, "D100", DemoUtils.PlcDeviceName );

				// 示例代码
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( melsec_net, nameof( MelsecMcUdp.EnableWriteBitToWordRegister ), "ByteTransform.IsStringReverseByteWord" );
			}
			else
			{
				DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
					"Error: " + connect.ErrorCode );
			}

		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( melsec_net );
			melsec_net?.ConnectClose( );
		}

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = melsec_net.ReadBool( "M100", 10 );
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

		private void test2( )
		{
			bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
			OperateResult read = melsec_net.Write( "M100", values );
			if (read.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
			}
		}


		private void test3( )
		{
			short d100_short = melsec_net.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsec_net.ReadUInt16( "D100" ).Content;
			int d100_int = melsec_net.ReadInt32( "D100" ).Content;
			uint d100_uint = melsec_net.ReadUInt32( "D100" ).Content;
			long d100_long = melsec_net.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsec_net.ReadUInt64( "D100" ).Content;
			float d100_float = melsec_net.ReadFloat( "D100" ).Content;
			double d100_double = melsec_net.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsec_net.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			melsec_net.Write( "D100", (short)5 );
			melsec_net.Write( "D100", (ushort)5 );
			melsec_net.Write( "D100", 5 );
			melsec_net.Write( "D100", (uint)5 );
			melsec_net.Write( "D100", (long)5 );
			melsec_net.Write( "D100", (ulong)5 );
			melsec_net.Write( "D100", 5f );
			melsec_net.Write( "D100", 5d );
			// length should Multiples of 2 
			melsec_net.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = melsec_net.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = melsec_net.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsec_net.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsec_net.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = melsec_net.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsec_net.WriteCustomer( "D100", new UserType( ) );

			melsec_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

		}

		// private MelsecMcAsciiNet melsec_ascii_net = null;

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "EnableWriteBitToWordRegister", checkBox_EnableWriteBitToWordRegister.Text );
			element.SetAttributeValue( "IsStringReverseByteWord", checkBox_string_reverse.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.UdpPipe );
			checkBox_EnableWriteBitToWordRegister.Checked = GetXmlValue( element, "EnableWriteBitToWordRegister", false, bool.Parse );
			checkBox_string_reverse.Checked               = GetXmlValue( element, "IsStringReverseByteWord", false, bool.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}

}
