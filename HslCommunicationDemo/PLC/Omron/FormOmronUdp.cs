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
using HslCommunicationDemo.PLC.Omron;
using HslCommunicationDemo.DemoControl;
using System.Net;

namespace HslCommunicationDemo
{
	public partial class FormOmronUdp : HslFormContent
	{
		public FormOmronUdp( )
		{
			InitializeComponent( );
		}


		private OmronFinsUdp omronFinsUdp = null;
		private FinsTcpControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;


			comboBox_plcType.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Profinet.Omron.OmronPlcType>( );
			comboBox_plcType.SelectedItem = HslCommunication.Profinet.Omron.OmronPlcType.CSCJ;
			button2.Enabled = false;

			Language( Program.Language );

			control = new FinsTcpControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );


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
				label23.Text = "PC Net Num";
				button1.Text = "Create";
				button2.Text = "Close";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!byte.TryParse( textBox_sa1.Text, out byte SA1 ))
			{
				MessageBox.Show( "SA1 Input Wrong！" );
				return;
			}

			if (!byte.TryParse( textBox_gct.Text, out byte gct ))
			{
				MessageBox.Show( "GCT Input Wrong！" );
				return;
			}

			if (!byte.TryParse( textBox_sid.Text, out byte sid ))
			{
				MessageBox.Show( "SID Input Wrong！" );
				return;
			}


			omronFinsUdp = new OmronFinsUdp( );
			omronFinsUdp.LogNet = LogNet;
			omronFinsUdp.SA1 = SA1;
			omronFinsUdp.GCT = gct;
			omronFinsUdp.SID = sid;



			userControlReadWriteDevice1.SetEnable( true );


			if ( !string.IsNullOrEmpty( textBox_da1.Text ) )
			{
				if (!byte.TryParse( textBox_da1.Text, out byte da1 ))
				{
					MessageBox.Show( "DA1 Input Wrong！" );
					return;
				}
				omronFinsUdp.DA1 = da1;
			}
			omronFinsUdp.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
			omronFinsUdp.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
			omronFinsUdp.PlcType = (OmronPlcType)comboBox_plcType.SelectedItem;

			try
			{
				this.pipeSelectControl1.IniPipe( omronFinsUdp );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}

			OperateResult open = DeviceConnectPLC( omronFinsUdp );
			if (open.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				// 设置子控件的读取能力
				userControlReadWriteDevice1.SetReadWriteNet( omronFinsUdp, "D100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( omronFinsUdp, "D100", string.Empty );
				// userControlReadWriteDevice1.BatchRead.SetReadRandom( omronFinsNet.ReadRandom );
				userControlReadWriteDevice1.BatchRead.SetReadWordRandom( omronFinsUdp.Read, "D100;A100;C100;H100" );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronFinsUdp.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronFinsUdp.ReadFromCoreServer( m ), "Fins Core", "example: 01 01 B1 00 0A 00 00 01" );
				control.SetDevice( omronFinsUdp, "D100" );

				// 设置示例代码
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( omronFinsUdp, nameof( omronFinsUdp.PlcType ), nameof( omronFinsUdp.SA1 ), nameof( omronFinsUdp.GCT ), nameof( omronFinsUdp.DA1 ), nameof( omronFinsUdp.SID ),
					"ByteTransform.DataFormat", "ByteTransform.IsStringReverseByteWord" );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
					"Error: " + open.ErrorCode );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			userControlReadWriteDevice1.SetEnable( false );
			button1.Enabled = true;
			button2.Enabled = false;
			omronFinsUdp.CommunicationPipe?.CloseCommunication( );
			this.pipeSelectControl1.ExtraCloseAction( omronFinsUdp );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlNetNumber, textBox_sa1.Text );
			element.SetAttributeValue( "DA1", textBox_da1.Text );
			element.SetAttributeValue( "GCT", textBox_gct.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox_isstringreverse.Checked );
			element.SetAttributeValue( "OmronType", comboBox_plcType.SelectedIndex );
			element.SetAttributeValue( "SID", textBox_sid.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.UdpPipe );
			textBox_sa1.Text = element.Attribute( DemoDeviceList.XmlNetNumber ).Value;
			textBox_da1.Text = GetXmlValue( element, "DA1", textBox_da1.Text, m => m );
			textBox_gct.Text = GetXmlValue( element, "GCT", textBox_gct.Text, m => m );
			textBox_sid.Text = GetXmlValue( element, "SID", textBox_sid.Text, m => m );
			checkBox_isstringreverse.Checked = GetXmlValue( element, DemoDeviceList.XmlStringReverse, checkBox_isstringreverse.Checked, bool.Parse );
			comboBox_plcType.SelectedIndex = GetXmlValue( element, "OmronType", comboBox_plcType.SelectedIndex, int.Parse );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void test()
		{
			// 读取操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
			bool D100_7 = omronFinsUdp.ReadBool( "D100.7" ).Content;  // 读取D100.7是否通断，注意D100.0等同于D100
			short short_D100 = omronFinsUdp.ReadInt16( "D100" ).Content; // 读取D100组成的字
			ushort ushort_D100 = omronFinsUdp.ReadUInt16( "D100" ).Content; // 读取D100组成的无符号的值
			int int_D100 = omronFinsUdp.ReadInt32( "D100" ).Content;         // 读取D100-D101组成的有符号的数据
			uint uint_D100 = omronFinsUdp.ReadUInt32( "D100" ).Content;      // 读取D100-D101组成的无符号的值
			float float_D100 = omronFinsUdp.ReadFloat( "D100" ).Content;   // 读取D100-D101组成的单精度值
			long long_D100 = omronFinsUdp.ReadInt64( "D100" ).Content;      // 读取D100-D103组成的大数据值
			ulong ulong_D100 = omronFinsUdp.ReadUInt64( "D100" ).Content;   // 读取D100-D103组成的无符号大数据
			double double_D100 = omronFinsUdp.ReadDouble( "D100" ).Content; // 读取D100-D103组成的双精度值
			string str_D100 = omronFinsUdp.ReadString( "D100", 5 ).Content;// 读取D100-D104组成的ASCII字符串数据

			// 写入操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
			omronFinsUdp.Write( "D100", (byte)0x33 );            // 写单个字节
			omronFinsUdp.Write( "D100", (short)12345 );          // 写双字节有符号
			omronFinsUdp.Write( "D100", (ushort)45678 );         // 写双字节无符号
			omronFinsUdp.Write( "D100", (uint)3456789123 );      // 写双字无符号
			omronFinsUdp.Write( "D100", 123.456f );              // 写单精度
			omronFinsUdp.Write( "D100", 1234556434534545L );     // 写大整数有符号
			omronFinsUdp.Write( "D100", 523434234234343UL );     // 写大整数无符号
			omronFinsUdp.Write( "D100", 123.456d );              // 写双精度
			omronFinsUdp.Write( "D100", "K123456789" );// 写ASCII字符串

			OperateResult<byte[]> read = omronFinsUdp.Read( "D100", 5 );
			{
				if (read.IsSuccess)
				{
					// 此处需要根据实际的情况来自定义来处理复杂的数据
					short D100 = omronFinsUdp.ByteTransform.TransInt16( read.Content, 0 );
					short D101 = omronFinsUdp.ByteTransform.TransInt16( read.Content, 2 );
					short D102 = omronFinsUdp.ByteTransform.TransInt16( read.Content, 4 );
					short D103 = omronFinsUdp.ByteTransform.TransInt16( read.Content, 6 );
					short D104 = omronFinsUdp.ByteTransform.TransInt16( read.Content, 7 );
				}
				else
				{
					// 发生了异常
					// 
				}
			}
		}

	}
}
