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
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormOmronHostLink : HslFormContent
	{
		public FormOmronHostLink( )
		{
			InitializeComponent( );
			omronHostLink = new OmronHostLink( );
			// omronHostLink.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private OmronHostLink omronHostLink = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			panel2.Enabled = false;

			Language( Program.Language );

			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
			comboBox2.SelectedIndex = 2;
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
				label24.Text = "Unit Num";
				label25.Text = "Net Num";
				label23.Text = "PC Net Num";

				label1.Text = "Station:";
				label3.Text = "Parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label21.Text = "Address:";
				label29.Text = "Com:";
				label28.Text = "BaudRate:";
				label27.Text = "DataBit:";
				label26.Text = "StopBit:";

				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";

				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox19.Text, out int baudRate ))
			{
				MessageBox.Show( DemoUtils.BaudRateInputWrong );
				return;
			}

			if (!int.TryParse( textBox18.Text, out int dataBits ))
			{
				MessageBox.Show( DemoUtils.DataBitsInputWrong );
				return;
			}

			if (!int.TryParse( textBox2.Text, out int stopBits ))
			{
				MessageBox.Show( DemoUtils.StopBitInputWrong );
				return;
			}

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

			omronHostLink?.Close( );
			omronHostLink = new OmronHostLink( );

			try
			{
				omronHostLink.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox2.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox2.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );
				omronHostLink.UnitNumber = Station;
				omronHostLink.SID = SID;
				omronHostLink.DA2 = DA2;
				omronHostLink.SA2 = SA2;
				omronHostLink.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;


				omronHostLink.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteOp1.SetReadWriteNet( omronHostLink, "D100", false );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			omronHostLink.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( omronHostLink, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = omronHostLink.ReadBase( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
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
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox19.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox18.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPCUnitNumber, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDeviceId, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox19.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox18.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox2.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlPCUnitNumber ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlDeviceId ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
