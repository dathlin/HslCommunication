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
using HslCommunication.Profinet.Panasonic;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Panasonic;

namespace HslCommunicationDemo
{
	public partial class FormPanasonicBinary : HslFormContent
	{
		public FormPanasonicBinary( )
		{
			InitializeComponent( );
			panasonic_net = new PanasonicMcNet( );
		}


		private PanasonicMcNet panasonic_net = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetMCAddressExamples( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Panasonic Read PLC Demo";
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
			panasonic_net.ConnectClose( );
			panasonic_net.LogNet = LogNet;


			try
			{
				this.pipeSelectControl1.IniPipe( panasonic_net );
				OperateResult connect = DeviceConnectPLC( panasonic_net );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );
					//userControlReadWriteOp1.SetReadWriteNet( panasonic_net, "D100", true );

					// 设置子控件的读取能力
					userControlReadWriteDevice1.SetReadWriteNet( panasonic_net, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( panasonic_net, "D100", string.Empty );
					userControlReadWriteDevice1.BatchRead.SetReadRandom( panasonic_net.ReadRandom, "D100;D200;D500" );
					userControlReadWriteDevice1.BatchRead.SetReadWordRandom( panasonic_net.ReadRandom, "D100;D200;D500" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => panasonic_net.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					// 设置示例代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( panasonic_net );
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
			panasonic_net.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( panasonic_net );
		}

		
		#endregion

		#region Use Exmaple

		private void test1()
		{
			// 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

			// if we want read M100-M109, so we can do like this
			OperateResult<bool[]> read = panasonic_net.ReadBool( "M100", 10 );
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
			OperateResult read = panasonic_net.Write( "M100", values );
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
			short d100_short = panasonic_net.ReadInt16( "D100" ).Content;
			ushort d100_ushort = panasonic_net.ReadUInt16( "D100" ).Content;
			int d100_int = panasonic_net.ReadInt32( "D100" ).Content;
			uint d100_uint = panasonic_net.ReadUInt32( "D100" ).Content;
			long d100_long = panasonic_net.ReadInt64( "D100" ).Content;
			ulong d100_ulong = panasonic_net.ReadUInt64( "D100" ).Content;
			float d100_float = panasonic_net.ReadFloat( "D100" ).Content;
			double d100_double = panasonic_net.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = panasonic_net.ReadString( "D100", 10 ).Content;
		}
		private void test4( )
		{
			// These are the underlying operations that ignore validation of success
			panasonic_net.Write( "D100", (short)5 );
			panasonic_net.Write( "D100", (ushort)5 );
			panasonic_net.Write( "D100", 5 );
			panasonic_net.Write( "D100", (uint)5 );
			panasonic_net.Write( "D100", (long)5 );
			panasonic_net.Write( "D100", (ulong)5 );
			panasonic_net.Write( "D100", 5f );
			panasonic_net.Write( "D100", 5d );
			// length should Multiples of 2 
			panasonic_net.Write( "D100", "12345678" );
		}


		private void test5( )
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = panasonic_net.Read( "D100", 10 );
			if(read.IsSuccess)
			{
				int count = panasonic_net.ByteTransform.TransInt32( read.Content, 0 );
				float temp = panasonic_net.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = panasonic_net.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6( )
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = panasonic_net.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			panasonic_net.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			panasonic_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}
		
		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
