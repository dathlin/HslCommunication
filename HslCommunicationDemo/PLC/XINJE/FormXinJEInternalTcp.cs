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
using HslCommunication.Profinet.XINJE;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormXinJEInternalTcp : HslFormContent
	{
		public FormXinJEInternalTcp( )
		{
			InitializeComponent( );
			xinJE = new XinJEInternalNet( );
		}


		private XinJEInternalNet xinJE = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.XINJE.Helper.GetXinJEInternalAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "XINJE Read PLC Demo";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label_station.Text = "Station:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			xinJE?.ConnectClose( );
			xinJE = new XinJEInternalNet( );
			xinJE.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( xinJE );
				xinJE.Station = byte.Parse( textBox_station.Text );
				OperateResult connect = DeviceConnectPLC( xinJE );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );

					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( xinJE, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( xinJE, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => xinJE.ReadFromCoreServer(m, hasResponseData: true, usePackAndUnpack: false ), string.Empty, string.Empty );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( xinJE, nameof( xinJE.Station ) );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
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
			xinJE.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( xinJE );
		}



		#endregion

		#region 测试使用

		private void test3( )
		{
			short d100_short = xinJE.ReadInt16( "D100" ).Content;
			ushort d100_ushort = xinJE.ReadUInt16( "D100" ).Content;
			int d100_int = xinJE.ReadInt32( "D100" ).Content;
			uint d100_uint = xinJE.ReadUInt32( "D100" ).Content;
			long d100_long = xinJE.ReadInt64( "D100" ).Content;
			ulong d100_ulong = xinJE.ReadUInt64( "D100" ).Content;
			float d100_float = xinJE.ReadFloat( "D100" ).Content;
			double d100_double = xinJE.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = xinJE.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			xinJE.Write( "D100", (short)5 );
			xinJE.Write( "D100", (ushort)5 );
			xinJE.Write( "D100", 5 );
			xinJE.Write( "D100", (uint)5 );
			xinJE.Write( "D100", (long)5 );
			xinJE.Write( "D100", (ulong)5 );
			xinJE.Write( "D100", 5f );
			xinJE.Write( "D100", 5d );
			// length should Multiples of 2 
			xinJE.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			OperateResult<byte[]> read = xinJE.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = xinJE.ByteTransform.TransInt32( read.Content, 0 );
				float temp = xinJE.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = xinJE.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			OperateResult<UserType> read = xinJE.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			xinJE.WriteCustomer( "D100", new UserType( ) );

			xinJE.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

		}


		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
