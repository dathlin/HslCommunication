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
	public partial class FormMelsecLinksOverTcp : HslFormContent
	{
		public FormMelsecLinksOverTcp( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private MelsecFxLinksOverTcp melsec = null;
		private FxLinksControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_format.SelectedIndex = 0;
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
				label2.Text = "Format";
				userControlHead1.ProtocolInfo = "fxlinks over tcp";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{

			melsec?.ConnectClose( );
			melsec = new MelsecFxLinksOverTcp( );

			melsec.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( melsec );
				melsec.Station = byte.Parse( textBox15.Text );
				melsec.WaittingTime = byte.Parse( textBox18.Text );
				melsec.SumCheck = checkBox1.Checked;
				melsec.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );

				OperateResult connect = DeviceConnectPLC( melsec );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( melsec, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsec, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsec.ReadFromCoreServer( m ), string.Empty, string.Empty );
					control.SetDevice( melsec, "D100" );

					// 设置示例的代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( melsec, nameof( melsec.Station ), nameof( melsec.WaittingTime ), nameof( melsec.SumCheck ), nameof( melsec.Format ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
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
			this.pipeSelectControl1.ExtraCloseAction( melsec );
			melsec?.ConnectClose( );
		}

		

		#endregion

		#region 测试使用

		private void test1()
		{
			OperateResult<bool[]> read = melsec.ReadBool( "M100", 10 );
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
			short d100_short = melsec.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsec.ReadUInt16( "D100" ).Content;
			int d100_int = melsec.ReadInt32( "D100" ).Content;
			uint d100_uint = melsec.ReadUInt32( "D100" ).Content;
			long d100_long = melsec.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsec.ReadUInt64( "D100" ).Content;
			float d100_float = melsec.ReadFloat( "D100" ).Content;
			double d100_double = melsec.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsec.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			melsec.Write( "D100", (short)5 );
			melsec.Write( "D100", (ushort)5 );
			melsec.Write( "D100", 5 );
			melsec.Write( "D100", (uint)5 );
			melsec.Write( "D100", (long)5 );
			melsec.Write( "D100", (ulong)5 );
			melsec.Write( "D100", 5f );
			melsec.Write( "D100", 5d );
			// length should Multiples of 2 
			melsec.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = melsec.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = melsec.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsec.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsec.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = melsec.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsec.WriteCustomer( "D100", new UserType( ) );

			melsec.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
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
