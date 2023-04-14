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
using HslCommunication.Profinet.Keyence;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Melsec;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceBinary : HslFormContent
	{
		public FormKeyenceBinary( )
		{
			InitializeComponent( );
			keyence_net = new KeyenceMcNet( );
		}


		private KeyenceMcNet keyence_net = null;
		private McQna3EControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			
			Language( Program.Language );
			control = new McQna3EControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label22.Text = "M100 D100 X1A0 Y1A0";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			keyence_net.IpAddress = textBox1.Text;
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			keyence_net.Port = port;
			keyence_net.ConnectClose( );
			keyence_net.LogNet = LogNet;
			keyence_net.EnableWriteBitToWordRegister = checkBox_EnableWriteBitToWordRegister.Checked;

			try
			{
				OperateResult connect = keyence_net.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( keyence_net, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( keyence_net, "D100", string.Empty );
					userControlReadWriteDevice1.BatchRead.SetReadRandom( keyence_net.ReadRandom, "D100;W100;D500" );
					userControlReadWriteDevice1.BatchRead.SetReadWordRandom( keyence_net.ReadRandom, "D100;W100;D500" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => keyence_net.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					// 特殊读取
					control.SetDevice( keyence_net, "D100" );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + ":" + connect.Message );
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
			keyence_net.ConnectClose( );
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
			OperateResult<bool[]> read = keyence_net.ReadBool( "M100", 10 );
			if(read.IsSuccess)
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

		private void test2( )
		{
			// the next we want write data
			bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
			OperateResult read = keyence_net.Write( "M100", values );
			if (read.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
			}
		}


		private void test3( )
		{
			// These are the underlying operations that ignore validation of success
			short d100_short = keyence_net.ReadInt16( "D100" ).Content;
			ushort d100_ushort = keyence_net.ReadUInt16( "D100" ).Content;
			int d100_int = keyence_net.ReadInt32( "D100" ).Content;
			uint d100_uint = keyence_net.ReadUInt32( "D100" ).Content;
			long d100_long = keyence_net.ReadInt64( "D100" ).Content;
			ulong d100_ulong = keyence_net.ReadUInt64( "D100" ).Content;
			float d100_float = keyence_net.ReadFloat( "D100" ).Content;
			double d100_double = keyence_net.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = keyence_net.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			// These are the underlying operations that ignore validation of success
			keyence_net.Write( "D100", (short)5 );
			keyence_net.Write( "D100", (ushort)5 );
			keyence_net.Write( "D100", 5 );
			keyence_net.Write( "D100", (uint)5 );
			keyence_net.Write( "D100", (long)5 );
			keyence_net.Write( "D100", (ulong)5 );
			keyence_net.Write( "D100", 5f );
			keyence_net.Write( "D100", 5d );
			// length should Multiples of 2 
			keyence_net.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = keyence_net.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = keyence_net.ByteTransform.TransInt32( read.Content, 0 );
				float temp = keyence_net.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = keyence_net.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = keyence_net.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			keyence_net.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			keyence_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "EnableWriteBitToWordRegister", this.checkBox_EnableWriteBitToWordRegister.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			checkBox_EnableWriteBitToWordRegister.Checked = GetXmlValue( element, "EnableWriteBitToWordRegister", false, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
