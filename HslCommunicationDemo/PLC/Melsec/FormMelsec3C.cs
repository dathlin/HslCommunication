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
using System.IO.Ports;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Melsec;

namespace HslCommunicationDemo
{
	public partial class FormMelsec3C : HslFormContent
	{
		public FormMelsec3C( )
		{
			InitializeComponent( );
		}


		private MelsecA3CNet melsecA3C = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_format.SelectedIndex = 0;
			comboBox_format.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox_sumcheck.CheckedChanged += CheckBox1_CheckedChanged;

			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetMcAddress( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (melsecA3C != null)
			{
				melsecA3C.SumCheck = checkBox_sumcheck.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (melsecA3C != null)
			{
				melsecA3C.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";
				button1.Text = "Open";
				button2.Text = "Close";
				label21.Text = "Address:";
				label2.Text = "Format:";
			}
			else
			{
				checkBox_EnableWriteBitToWordRegister.Text = "支持使用位写入字寄存器(实际读字，修改位，写字)";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close

		
		private void button1_Click( object sender, EventArgs e )
		{
			melsecA3C?.Close( );
			melsecA3C = new MelsecA3CNet( );
			melsecA3C.LogNet = LogNet;
			melsecA3C.EnableWriteBitToWordRegister = checkBox_EnableWriteBitToWordRegister.Checked;
			try
			{
				this.pipeSelectControl1.IniPipe( melsecA3C );
				melsecA3C.Station = byte.Parse( textBox15.Text );
				melsecA3C.SumCheck = checkBox_sumcheck.Checked;
				melsecA3C.Format = int.Parse( comboBox_format.SelectedItem.ToString( ) );

				OperateResult open = DeviceConnectPLC( melsecA3C );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					userControlReadWriteDevice1.SetEnable( true );

					// 设置基本的读写信息
					userControlReadWriteDevice1.SetReadWriteNet( melsecA3C, "D100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsecA3C, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsecA3C.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					// 设置示例的代码
					this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
					codeExampleControl.SetCodeText( melsecA3C, nameof( melsecA3C.Station ), nameof( melsecA3C.EnableWriteBitToWordRegister ), nameof( melsecA3C.SumCheck ),
						nameof( melsecA3C.Format ) );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
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
			melsecA3C.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
			this.pipeSelectControl1.ExtraCloseAction( melsecA3C );
		}

		

		#endregion

		#region Use Exmaple

		private void test1()
		{
			// 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

			// if we want read M100-M109, so we can do like this
			OperateResult<bool[]> read = melsecA3C.ReadBool( "M100", 10 );
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

		private void test2()
		{
			// the next we want write data
			bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
			OperateResult read = melsecA3C.Write( "M100", values );
			if (read.IsSuccess)
			{
				// success
			}
			else
			{
				// failed
			}
		}


		private void test3()
		{
			// These are the underlying operations that ignore validation of success
			short d100_short = melsecA3C.ReadInt16( "D100" ).Content;
			ushort d100_ushort = melsecA3C.ReadUInt16( "D100" ).Content;
			int d100_int = melsecA3C.ReadInt32( "D100" ).Content;
			uint d100_uint = melsecA3C.ReadUInt32( "D100" ).Content;
			long d100_long = melsecA3C.ReadInt64( "D100" ).Content;
			ulong d100_ulong = melsecA3C.ReadUInt64( "D100" ).Content;
			float d100_float = melsecA3C.ReadFloat( "D100" ).Content;
			double d100_double = melsecA3C.ReadDouble( "D100" ).Content;
			// need to specify the text length
			string d100_string = melsecA3C.ReadString( "D100", 10 ).Content;
		}
		private void test4()
		{
			// These are the underlying operations that ignore validation of success
			melsecA3C.Write( "D100", (short)5 );
			melsecA3C.Write( "D100", (ushort)5 );
			melsecA3C.Write( "D100", 5 );
			melsecA3C.Write( "D100", (uint)5 );
			melsecA3C.Write( "D100", (long)5 );
			melsecA3C.Write( "D100", (ulong)5 );
			melsecA3C.Write( "D100", 5f );
			melsecA3C.Write( "D100", 5d );
			// length should Multiples of 2 
			melsecA3C.Write( "D100", "12345678" );
		}


		private void test5()
		{
			// The complex situation is that you need to parse the byte array yourself.
			// Here's just one example.
			OperateResult<byte[]> read = melsecA3C.Read( "D100", 10 );
			if (read.IsSuccess)
			{
				int count = melsecA3C.ByteTransform.TransInt32( read.Content, 0 );
				float temp = melsecA3C.ByteTransform.TransSingle( read.Content, 4 );
				short name1 = melsecA3C.ByteTransform.TransInt16( read.Content, 8 );
				string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
			}
		}

		private void test6()
		{
			// Custom types of Read and write situations in which type usertype need to be implemented in advance.
			// 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

			OperateResult<UserType> read = melsecA3C.ReadCustomer<UserType>( "D100" );
			if (read.IsSuccess)
			{
				UserType value = read.Content;
			}
			// write value
			melsecA3C.WriteCustomer( "D100", new UserType( ) );

			// Sets an instance operation for the log.
			melsecA3C.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( "EnableWriteBitToWordRegister", checkBox_EnableWriteBitToWordRegister.Text );
			element.SetAttributeValue( "Sumcheck", checkBox_sumcheck.Checked );
			element.SetAttributeValue( "MelsecFormat", comboBox_format.SelectedIndex );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox_EnableWriteBitToWordRegister.Checked = GetXmlValue( element, "EnableWriteBitToWordRegister", false, bool.Parse );
			checkBox_sumcheck.Checked = GetXmlValue( element, "Sumcheck", checkBox_sumcheck.Checked, bool.Parse );
			comboBox_format.SelectedIndex = GetXmlValue( element, "MelsecFormat", comboBox_format.SelectedIndex, int.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
