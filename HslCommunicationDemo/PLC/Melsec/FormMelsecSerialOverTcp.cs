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
using HslCommunication.Profinet.Melsec;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Melsec;

namespace HslCommunicationDemo
{
	public partial class FormMelsecSerialOverTcp : HslFormContent
	{
		public FormMelsecSerialOverTcp( )
		{
			InitializeComponent( );
			melsec_net = new MelsecFxSerialOverTcp( );
		}


		private MelsecFxSerialOverTcp melsec_net = null;
		private MelsecSerialControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

			control = new MelsecSerialControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (melsec_net != null)
			{
				melsec_net.IsNewVersion = checkBox1.Checked;
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";

				checkBox1.Text = "New Version Message?";
				checkBox_got.Text = "Use Got";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
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

			melsec_net?.ConnectClose( );
			melsec_net              = new MelsecFxSerialOverTcp( );
			melsec_net.IpAddress    = textBox1.Text;
			melsec_net.Port         = port;
			melsec_net.IsNewVersion = checkBox1.Checked;
			melsec_net.UseGOT       = checkBox_got.Checked;
			melsec_net.LogNet       = LogNet;
			try
			{
				OperateResult connect = melsec_net.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置基本的读写信息
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( melsec_net, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsec_net, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsec_net.ReadFromCoreServer( m ), string.Empty, string.Empty );
					control.SetDevice( melsec_net, "D100" );
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
			melsec_net.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		

		#endregion

		#region Use Exmaple

		private void test1()
		{
			// 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

			// if we want read M100-M109, so we can do like this
			OperateResult<bool[]> read = melsec_net.ReadBool( "M100", 10 );
			if (read.IsSuccess)
			{
				bool m100 = read.Content[0];
				// and so on
				// ...
				// then
				bool m109 = read.Content[9];
			}
			else
			{
				// failed, the follow operation is output the wrong msg
				Console.WriteLine( "Read failed: " + read.ToMessageShowString( ) );
			}
		}


		private void test3()
		{
			// These are the underlying operations that ignore validation of success
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
		private void test4()
		{
			// These are the underlying operations that ignore validation of success
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


		private void test5()
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = melsec_net.Read( "D100", 10 );
			if (read.IsSuccess)
			{
				int count = melsec_net.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsec_net.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsec_net.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6()
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = melsec_net.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsec_net.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			melsec_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button_active_plc_Click( object sender, EventArgs e )
		{
			OperateResult active = melsec_net.ActivePlc( );
			if (active.IsSuccess)
			{
				MessageBox.Show( "Active Successful" );
			}
			else
			{
				MessageBox.Show( "Failed: " + active.ToMessageShowString( ) );
			}
		}
	}
}
