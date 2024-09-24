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
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
	public partial class FormOmron : HslFormContent
	{
		public FormOmron( )
		{
			InitializeComponent( );
			omronFinsNet = new OmronFinsNet( );
			omronFinsNet.ConnectTimeOut = 2000;
			// omronFinsNet.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private OmronFinsNet omronFinsNet = null;
		private FinsTcpControl control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;

			comboBox_plcType.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Profinet.Omron.OmronPlcType>( );
			comboBox_plcType.SelectedItem = HslCommunication.Profinet.Omron.OmronPlcType.CSCJ;

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
				label24.Text = "Unit Num";
				label23.Text = "PC Net Num";

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
			if (!byte.TryParse( textBox16.Text, out byte DA2 ))
			{
				MessageBox.Show( "PLC DA2 input wrong！" );
				return;
			}

			try
			{
				this.pipeSelectControl1.IniPipe( omronFinsNet );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
				return;
			}

			omronFinsNet.DA2 = DA2;
			omronFinsNet.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
			omronFinsNet.PlcType = (OmronPlcType)comboBox_plcType.SelectedItem;
			omronFinsNet.LogNet = LogNet;
			omronFinsNet.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
			omronFinsNet.ReceiveUntilEmpty = checkBox_receive_until_empty.Checked;

			OperateResult connect = DeviceConnectPLC( omronFinsNet );
			if (connect.IsSuccess)
			{
				MessageBox.Show( StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				userControlReadWriteDevice1.SetEnable( true );

				textBox15.Text = omronFinsNet.SA1.ToString( );
				textBox3.Text = omronFinsNet.DA1.ToString( );

				// 设置子控件的读取能力
				userControlReadWriteDevice1.SetReadWriteNet( omronFinsNet, "D100", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( omronFinsNet, "D100", string.Empty );
				// userControlReadWriteDevice1.BatchRead.SetReadRandom( omronFinsNet.ReadRandom );
				userControlReadWriteDevice1.BatchRead.SetReadWordRandom( omronFinsNet.Read, "D100;A100;C100;H100" );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronFinsNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronFinsNet.ReadFromCoreServer( m ), "Fins Core", "example: 01 01 B1 00 0A 00 00 01" );
				control.SetDevice( omronFinsNet, "D100" );

				// 设置示例代码
				this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
				codeExampleControl.SetCodeText( omronFinsNet, nameof( omronFinsNet.PlcType ), nameof( omronFinsNet.DA2 ), nameof( omronFinsNet.ReceiveUntilEmpty ), 
					"ByteTransform.DataFormat", "ByteTransform.IsStringReverseByteWord" );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + " " + connect.ToMessageShowString( ) );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			omronFinsNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( omronFinsNet );
		}
		

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( "ReceiveUntilEmpty", checkBox_receive_until_empty.Checked );
			element.SetAttributeValue( "IsStringReverseByteWord", checkBox_isstringreverse.Checked );
			element.SetAttributeValue( "OmronType", comboBox_plcType.SelectedIndex );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox_receive_until_empty.Checked = GetXmlValue( element, "ReceiveUntilEmpty", checkBox_receive_until_empty.Checked, bool.Parse );
			checkBox_isstringreverse.Checked = GetXmlValue( element, "IsStringReverseByteWord", checkBox_isstringreverse.Checked, bool.Parse );
			comboBox_plcType.SelectedIndex = GetXmlValue( element, "OmronType", comboBox_plcType.SelectedIndex, int.Parse );

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
			bool D100_7 = omronFinsNet.ReadBool( "D100.7" ).Content;  // 读取D100.7是否通断，注意D100.0等同于D100
			short short_D100 = omronFinsNet.ReadInt16( "D100" ).Content; // 读取D100组成的字
			ushort ushort_D100 = omronFinsNet.ReadUInt16( "D100" ).Content; // 读取D100组成的无符号的值
			int int_D100 = omronFinsNet.ReadInt32( "D100" ).Content;         // 读取D100-D101组成的有符号的数据
			uint uint_D100 = omronFinsNet.ReadUInt32( "D100" ).Content;      // 读取D100-D101组成的无符号的值
			float float_D100 = omronFinsNet.ReadFloat( "D100" ).Content;   // 读取D100-D101组成的单精度值
			long long_D100 = omronFinsNet.ReadInt64( "D100" ).Content;      // 读取D100-D103组成的大数据值
			ulong ulong_D100 = omronFinsNet.ReadUInt64( "D100" ).Content;   // 读取D100-D103组成的无符号大数据
			double double_D100 = omronFinsNet.ReadDouble( "D100" ).Content; // 读取D100-D103组成的双精度值
			string str_D100 = omronFinsNet.ReadString( "D100", 5 ).Content;// 读取D100-D104组成的ASCII字符串数据

			// 写入操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
			omronFinsNet.Write( "D100", (byte)0x33 );            // 写单个字节
			omronFinsNet.Write( "D100", (short)12345 );          // 写双字节有符号
			omronFinsNet.Write( "D100", (ushort)45678 );         // 写双字节无符号
			omronFinsNet.Write( "D100", (uint)3456789123 );      // 写双字无符号
			omronFinsNet.Write( "D100", 123.456f );              // 写单精度
			omronFinsNet.Write( "D100", 1234556434534545L );     // 写大整数有符号
			omronFinsNet.Write( "D100", 523434234234343UL );     // 写大整数无符号
			omronFinsNet.Write( "D100", 123.456d );              // 写双精度
			omronFinsNet.Write( "D100", "K123456789" );          // 写ASCII字符串

			OperateResult<byte[]> read = omronFinsNet.Read( "D100", 5 );
			{
				if (read.IsSuccess)
				{
					// 此处需要根据实际的情况来自定义来处理复杂的数据
					short D100 = omronFinsNet.ByteTransform.TransInt16( read.Content, 0 );
					short D101 = omronFinsNet.ByteTransform.TransInt16( read.Content, 2 );
					short D102 = omronFinsNet.ByteTransform.TransInt16( read.Content, 4 );
					short D103 = omronFinsNet.ByteTransform.TransInt16( read.Content, 6 );
					short D104 = omronFinsNet.ByteTransform.TransInt16( read.Content, 7 );
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
