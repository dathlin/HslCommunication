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
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.Core.Pipe;
using HslCommunicationDemo.PLC.Siemens;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormSiemens : HslFormContent
	{
		public FormSiemens( SiemensPLCS siemensPLCS )
		{
			InitializeComponent( );
			siemensPLCSelected = siemensPLCS;
			siemensTcpNet = new SiemensS7Net( siemensPLCS );


			control = new SiemensS7Control( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetSiemensS7Address( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			randomWriteControl = new SiemensS7WriteControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( randomWriteControl, false, Program.Language == 1 ? "离散写入" : "Random Write" );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private SiemensS7Net siemensTcpNet = null;
		private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;
		private SiemensS7Control control;
		private SiemensS7WriteControl randomWriteControl;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			if (siemensPLCSelected == SiemensPLCS.S400)
			{
				textBox_rack.Text = "0";
				textBox_slot.Text = "3";
			}
			else if(siemensPLCSelected == SiemensPLCS.S1200)
			{
				textBox_rack.Text = "0";
				textBox_slot.Text = "0";
			}
			else if (siemensPLCSelected == SiemensPLCS.S300)
			{
				textBox_rack.Text = "0";
				textBox_slot.Text = "2";
			}
			else if (siemensPLCSelected == SiemensPLCS.S1500)
			{
				textBox_rack.Text = "0";
				textBox_slot.Text = "0";
			}

			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";

				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label_info.Text = "not set if not clear, change slot if always failed";
			}
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		
		#region Connect And Close
		
		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				this.pipeSelectControl1.IniPipe( siemensTcpNet );
				siemensTcpNet.Rack = byte.Parse( textBox_rack.Text );
				siemensTcpNet.Slot = byte.Parse( textBox_slot.Text );

				if (!string.IsNullOrEmpty( textBox_connectType.Text )) siemensTcpNet.ConnectionType = byte.Parse( textBox_connectType.Text );
				if (!string.IsNullOrEmpty( textBox_localTSAP.Text )) siemensTcpNet.LocalTSAP = int.Parse( textBox_localTSAP.Text );
				siemensTcpNet.LogNet = LogNet;


				OperateResult connect = DeviceConnectPLC( siemensTcpNet );
				if (connect.IsSuccess)
				{
					textBox_pdu.Text = siemensTcpNet.PDULength.ToString( );
					DemoUtils.ShowMessage( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( siemensTcpNet, "M100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( siemensTcpNet, "M100", string.Empty );
					userControlReadWriteDevice1.BatchRead.SetReadRandom( siemensTcpNet.Read, "M100;M200;DB1.0;Q0" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => siemensTcpNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					control.SetDevice( siemensTcpNet, "M100" );
					randomWriteControl.SetDevice( siemensTcpNet, "M100" );

					List<string> parameters = new List<string>( );
					parameters.Add( nameof( siemensTcpNet.Rack ) );
					parameters.Add( nameof( siemensTcpNet.Slot ) );
					if (!string.IsNullOrEmpty( textBox_connectType.Text )) parameters.Add( nameof( siemensTcpNet.ConnectionType ) );
					if (!string.IsNullOrEmpty( textBox_localTSAP.Text )) parameters.Add( nameof( siemensTcpNet.LocalTSAP ) );

					// 设置代码示例
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( siemensTcpNet, parameters.ToArray( ) );
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
			this.pipeSelectControl1.ExtraCloseAction( siemensTcpNet );
			siemensTcpNet.ConnectClose( );
		}
		
		#endregion

		#region 测试功能代码


		private void Test1( )
		{
			OperateResult<bool> read = siemensTcpNet.ReadBool( "M100.4" );
			if (read.IsSuccess)
			{
				bool m100_4 = read.Content;
			}
			else
			{
				// failed
				string err = read.Message;
			}

			OperateResult write = siemensTcpNet.Write( "M100.4", true );
			if (write.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
				string err = write.Message;
			}
		}

		private void Test2( )
		{
			byte m100_byte = siemensTcpNet.ReadByte( "M100" ).Content;
			short m100_short = siemensTcpNet.ReadInt16( "M100" ).Content;
			ushort m100_ushort = siemensTcpNet.ReadUInt16( "M100" ).Content;
			int m100_int = siemensTcpNet.ReadInt32( "M100" ).Content;
			uint m100_uint = siemensTcpNet.ReadUInt32( "M100" ).Content;
			float m100_float = siemensTcpNet.ReadFloat( "M100" ).Content;
			double m100_double = siemensTcpNet.ReadDouble( "M100" ).Content;
			string m100_string = siemensTcpNet.ReadString( "M100", 10 ).Content;

			HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );

		}

		private void Test3()
		{
			// 读取操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
			bool M100_7 = siemensTcpNet.ReadBool( "M100.7" ).Content;  // 读取M100.7是否通断，注意M100.0等同于M100
			byte byte_M100 = siemensTcpNet.ReadByte( "M100" ).Content; // 读取M100的值
			short short_M100 = siemensTcpNet.ReadInt16( "M100" ).Content; // 读取M100-M101组成的字
			ushort ushort_M100 = siemensTcpNet.ReadUInt16( "M100" ).Content; // 读取M100-M101组成的无符号的值
			int int_M100 = siemensTcpNet.ReadInt32( "M100" ).Content;         // 读取M100-M103组成的有符号的数据
			uint uint_M100 = siemensTcpNet.ReadUInt32( "M100" ).Content;      // 读取M100-M103组成的无符号的值
			float float_M100 = siemensTcpNet.ReadFloat( "M100" ).Content;   // 读取M100-M103组成的单精度值
			long long_M100 = siemensTcpNet.ReadInt64( "M100" ).Content;      // 读取M100-M107组成的大数据值
			ulong ulong_M100 = siemensTcpNet.ReadUInt64( "M100" ).Content;   // 读取M100-M107组成的无符号大数据
			double double_M100 = siemensTcpNet.ReadDouble( "M100" ).Content; // 读取M100-M107组成的双精度值
			string str_M100 = siemensTcpNet.ReadString( "M100", 10 ).Content;// 读取M100-M109组成的ASCII字符串数据

			// 写入操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
			siemensTcpNet.Write( "M100.7", true );                // 写位，注意M100.0等同于M100
			siemensTcpNet.Write( "M100", (byte)0x33 );            // 写单个字节
			siemensTcpNet.Write( "M100", (short)12345 );          // 写双字节有符号
			siemensTcpNet.Write( "M100", (ushort)45678 );         // 写双字节无符号
			siemensTcpNet.Write( "M100", 123456789 );             // 写双字有符号
			siemensTcpNet.Write( "M100", (uint)3456789123 );      // 写双字无符号
			siemensTcpNet.Write( "M100", 123.456f );              // 写单精度
			siemensTcpNet.Write( "M100", 1234556434534545L );     // 写大整数有符号
			siemensTcpNet.Write( "M100", 523434234234343UL );     // 写大整数无符号
			siemensTcpNet.Write( "M100", 123.456d );              // 写双精度
			siemensTcpNet.Write( "M100", "K123456789" );// 写ASCII字符串

			OperateResult<byte[]> read = siemensTcpNet.Read( "M100", 10 );
			{
				if(read.IsSuccess)
				{
					byte m100 = read.Content[0];
					byte m101 = read.Content[1];
					byte m102 = read.Content[2];
					byte m103 = read.Content[3];
					byte m104 = read.Content[4];
					byte m105 = read.Content[5];
					byte m106 = read.Content[6];
					byte m107 = read.Content[7];
					byte m108 = read.Content[8];
					byte m109 = read.Content[9];
				}
				else
				{
					// 发生了异常
				}
			}
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlRack, textBox_rack.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox_slot.Text );
			element.SetAttributeValue( "ConnectType", textBox_connectType.Text );
			element.SetAttributeValue( "LocalTSAP",   textBox_localTSAP.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox_rack.Text = element.Attribute( DemoDeviceList.XmlRack ).Value;
			textBox_slot.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
			textBox_connectType.Text = GetXmlValue( element, "ConnectType", string.Empty, m => m );
			textBox_localTSAP.Text   = GetXmlValue( element, "LocalTSAP",   string.Empty, m => m );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
