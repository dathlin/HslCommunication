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
using HslCommunication.Profinet.Fuji;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFujiSPHNet : HslFormContent
	{
		public FormFujiSPHNet( )
		{
			InitializeComponent( );
			fujiSPB = new FujiSPHNet( );
		}


		private FujiSPHNet fujiSPB = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );
			comboBox1.DataSource = SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = fujiSPB.ByteTransform.DataFormat;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Fuji.Helper.GetSPHAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );

		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if(this.fujiSPB != null)
			{
				if(comboBox1.SelectedItem is HslCommunication.Core.DataFormat dataformat)
				{
					this.fujiSPB.ByteTransform.DataFormat = dataformat;
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Fuji Read PLC Demo";
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
			this.fujiSPB?.ConnectClose( );
			this.fujiSPB = new FujiSPHNet( );
			this.fujiSPB.LogNet = LogNet;
			this.fujiSPB.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;

			try
			{
				this.pipeSelectControl1.IniPipe( fujiSPB );
				fujiSPB.ConnectionID = byte.Parse( textBox15.Text );
				OperateResult connect = DeviceConnectPLC( fujiSPB );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );

					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// userControlReadWriteOp1.SetReadWriteNet( fujiSPB, "M1.1000", true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( fujiSPB, "M1.1000", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( fujiSPB, "M1.1000", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => fujiSPB.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( fujiSPB, nameof( fujiSPB.ConnectionID ), "ByteTransform.DataFormat" );
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
			fujiSPB.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( fujiSPB );
		}

		#endregion

		#region 测试使用

		private void test3( )
		{
			short d100_short = fujiSPB.ReadInt16( "D100" ).Content;
			ushort d100_ushort = fujiSPB.ReadUInt16( "D100" ).Content;
			int d100_int = fujiSPB.ReadInt32( "D100" ).Content;
			uint d100_uint = fujiSPB.ReadUInt32( "D100" ).Content;
			long d100_long = fujiSPB.ReadInt64( "D100" ).Content;
			ulong d100_ulong = fujiSPB.ReadUInt64( "D100" ).Content;
			float d100_float = fujiSPB.ReadFloat( "D100" ).Content;
			double d100_double = fujiSPB.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = fujiSPB.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			fujiSPB.Write( "D100", (short)5 );
			fujiSPB.Write( "D100", (ushort)5 );
			fujiSPB.Write( "D100", 5 );
			fujiSPB.Write( "D100", (uint)5 );
			fujiSPB.Write( "D100", (long)5 );
			fujiSPB.Write( "D100", (ulong)5 );
			fujiSPB.Write( "D100", 5f );
			fujiSPB.Write( "D100", 5d );
			// length should Multiples of 2 
			fujiSPB.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = fujiSPB.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = fujiSPB.ByteTransform.TransInt32( read.Content, 0 );
				float temp = fujiSPB.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = fujiSPB.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = fujiSPB.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			fujiSPB.WriteCustomer( "D100", new UserType( ) );

			fujiSPB.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

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
