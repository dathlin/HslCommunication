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


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			panel2.Enabled = false;

			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
				label24.Text = "Unit Num";
				label23.Text = "PC Net Num";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";

				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";

				checkBox1.Text = "change SA1 value after read failed";

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
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			if (!byte.TryParse( textBox15.Text, out byte SA1 ))
			{
				MessageBox.Show( "SA1 Input Wrong！" );
				return;
			}


			if (!byte.TryParse( textBox16.Text, out byte DA2 ))
			{
				MessageBox.Show( "PLC DA2 input wrong！" );
				return;
			}
			
			omronFinsNet.IpAddress = textBox1.Text;
			omronFinsNet.Port = port;
			omronFinsNet.SA1 = SA1;
			omronFinsNet.DA2 = DA2;
			omronFinsNet.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;
			omronFinsNet.IsChangeSA1AfterReadFailed = checkBox1.Checked;

			// OperateResult connect = OperateResult.CreateSuccessResult( ); 
			OperateResult connect = omronFinsNet.ConnectServer( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteOp1.SetReadWriteNet( omronFinsNet, "D100", true );
			}
			else
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			omronFinsNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( omronFinsNet, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = omronFinsNet.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlNetNumber, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlChangeSA1, checkBox1.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlNetNumber ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlChangeSA1 ).Value );
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
			omronFinsNet.Write( "D100", "K123456789" );// 写ASCII字符串

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
