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
using HslCommunication;
using HslCommunication.Profinet.Omron;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.PLC.Omron
{
	public partial class FormOmronHostLinkOverTcp : HslFormContent
	{
		public FormOmronHostLinkOverTcp( )
		{
			InitializeComponent( );
			omronHostLink = new OmronHostLinkOverTcp( );
			// omronHostLink.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private OmronHostLinkOverTcp omronHostLink = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;

			Language( Program.Language );


			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetOmronAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
				label24.Text = "DA2";
				label25.Text = "SA2";
				label23.Text = "SID";

				label1.Text = "Station:";
				button1.Text = "Open";
				button2.Text = "Close";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse( textBox1.Text, out byte Station ))
			{
				MessageBox.Show( "PLC Station input wrong！" );
				return;
			}

			if (!byte.TryParse( textBox15.Text, out byte SID ))
			{
				MessageBox.Show( "PLC SID input wrong！" );
				return;
			}


			if (!byte.TryParse( textBox16.Text, out byte DA2 ))
			{
				MessageBox.Show( "PLC DA2 input wrong！" );
				return;
			}

			if (!byte.TryParse( textBox17.Text, out byte SA2 ))
			{
				MessageBox.Show( "PC SA2 input wrong" );
				return;
			}

			omronHostLink?.ConnectClose( );
			omronHostLink = new OmronHostLinkOverTcp( );
			omronHostLink.LogNet = LogNet;

			try
			{
				this.pipeSelectControl1.IniPipe( omronHostLink );
				
				omronHostLink.UnitNumber = Station;
				omronHostLink.SID = SID;
				omronHostLink.DA2 = DA2;
				omronHostLink.SA2 = SA2;
				omronHostLink.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;

				OperateResult connect = DeviceConnectPLC( omronHostLink );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );

					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( omronHostLink, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( omronHostLink, "D100", string.Empty );
					// userControlReadWriteDevice1.BatchRead.SetReadRandom( omronFinsNet.ReadRandom );
					userControlReadWriteDevice1.BatchRead.SetReadWordRandom( omronHostLink.Read, "D100;A100;C100;H100" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronHostLink.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronHostLink.ReadFromCoreServer( m ), "Fins Core", "example: 01 01 B1 00 0A 00 00 01" );

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( omronHostLink, nameof( omronHostLink.UnitNumber ), nameof( omronHostLink.SID ), nameof( omronHostLink.DA2 ),
						nameof( omronHostLink.SA2 ), "ByteTransform.DataFormat" );
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
			omronHostLink.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( omronHostLink );
		}
		
		#endregion

		private void test()
		{
			// 读取操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
			bool D100_7 = omronHostLink.ReadBool( "D100.7" ).Content;  // 读取D100.7是否通断，注意D100.0等同于D100
			short short_D100 = omronHostLink.ReadInt16( "D100" ).Content; // 读取D100组成的字
			ushort ushort_D100 = omronHostLink.ReadUInt16( "D100" ).Content; // 读取D100组成的无符号的值
			int int_D100 = omronHostLink.ReadInt32( "D100" ).Content;         // 读取D100-D101组成的有符号的数据
			uint uint_D100 = omronHostLink.ReadUInt32( "D100" ).Content;      // 读取D100-D101组成的无符号的值
			float float_D100 = omronHostLink.ReadFloat( "D100" ).Content;   // 读取D100-D101组成的单精度值
			long long_D100 = omronHostLink.ReadInt64( "D100" ).Content;      // 读取D100-D103组成的大数据值
			ulong ulong_D100 = omronHostLink.ReadUInt64( "D100" ).Content;   // 读取D100-D103组成的无符号大数据
			double double_D100 = omronHostLink.ReadDouble( "D100" ).Content; // 读取D100-D103组成的双精度值
			string str_D100 = omronHostLink.ReadString( "D100", 5 ).Content;// 读取D100-D104组成的ASCII字符串数据

			// 写入操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
			omronHostLink.Write( "D100", (byte)0x33 );            // 写单个字节
			omronHostLink.Write( "D100", (short)12345 );          // 写双字节有符号
			omronHostLink.Write( "D100", (ushort)45678 );         // 写双字节无符号
			omronHostLink.Write( "D100", (uint)3456789123 );      // 写双字无符号
			omronHostLink.Write( "D100", 123.456f );              // 写单精度
			omronHostLink.Write( "D100", 1234556434534545L );     // 写大整数有符号
			omronHostLink.Write( "D100", 523434234234343UL );     // 写大整数无符号
			omronHostLink.Write( "D100", 123.456d );              // 写双精度
			omronHostLink.Write( "D100", "K123456789" );// 写ASCII字符串

			OperateResult<byte[]> read = omronHostLink.Read( "D100", 5 );
			{
				if (read.IsSuccess)
				{
					// 此处需要根据实际的情况来自定义来处理复杂的数据
					short D100 = omronHostLink.ByteTransform.TransInt16( read.Content, 0 );
					short D101 = omronHostLink.ByteTransform.TransInt16( read.Content, 2 );
					short D102 = omronHostLink.ByteTransform.TransInt16( read.Content, 4 );
					short D103 = omronHostLink.ByteTransform.TransInt16( read.Content, 6 );
					short D104 = omronHostLink.ByteTransform.TransInt16( read.Content, 7 );
				}
				else
				{
					// 发生了异常
				}
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPCUnitNumber, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDeviceId, textBox15.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlPCUnitNumber ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlDeviceId ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
