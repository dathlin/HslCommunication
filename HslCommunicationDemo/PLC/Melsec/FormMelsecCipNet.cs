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
using HslCommunication.Profinet.AllenBradley;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormMelsecCipNet : HslFormContent
	{
		public FormMelsecCipNet( )
		{
			InitializeComponent( );
			cip = new MelsecCipNet( "192.168.0.110" );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private MelsecCipNet cip = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			panel2.Enabled = false;

			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "AllenBrandly Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				button3.Text = "Build";
				label2.Text = "Start:";

				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "CIP reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";

				label22.Text = "Tag name, if the bool array is of type int, access begin with \"i=\"";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}

			if (!byte.TryParse( textBox15.Text, out byte slot ))
			{
				DemoUtils.ShowMessage( DemoUtils.SlotInputWrong );
				return;
			}

			cip.IpAddress = textBox_ip.Text;
			cip.Port = port;
			cip.Slot = slot;
			cip.LogNet = LogNet;

			try
			{
				OperateResult connect = cip.ConnectServer( );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteOp1.SetReadWriteNet( cip, "A1", true, 1 );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
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
			cip.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			try
			{
				// OperateResult write = allenBradleyNet.Write( "Array", new short[] { 101, 102, 103, 104, 105, 106 } );

				// OperateResult<short[]> readResult = allenBradleyNet.ReadInt16( "Array", 300 );

				OperateResult<byte[]> read = null;
				if (!textBox6.Text.Contains( ";" ))
				{
					// DemoUtils.ShowMessage( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( new string[] { textBox6.Text }, new int[] { int.Parse(textBox9.Text) } ).Content , ' ') );
					read = cip.ReadSegment( textBox6.Text, ushort.Parse( textBox12.Text ), ushort.Parse( textBox9.Text ) );
				}
				else
				{
					//DemoUtils.ShowMessage( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( textBox6.Text.Split( ';' ) ).Content, ' ' ) );
					read = cip.Read( textBox6.Text.Split( ';' ) );
				}

				if (read.IsSuccess)
				{
					textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					DemoUtils.ShowMessage( "Read failed：" + read.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Read failed：" + ex.Message );
			}
		}

		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = cip.ReadCipFromServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed：" + read.ToMessageShowString( ) );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = cip.ReadEipFromServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed：" + read.ToMessageShowString( ) );
			}
		}

		#endregion

		private void Button3_Click( object sender, EventArgs e )
		{
			try
			{
				//    OperateResult write = allenBradleyNet.Write( "Array", new short[] { 101, 102, 103, 104, 105, 106 } );

				// OperateResult<short[]> readResult = allenBradleyNet.ReadInt16( "Array", 300 );

				//DemoUtils.ShowMessage( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( new string[] { textBox6.Text }, new int[] { int.Parse(textBox9.Text) } ).Content , ' ') );
				byte[] read = AllenBradleyHelper.PackRequestReadSegment( textBox6.Text, ushort.Parse( textBox12.Text ), ushort.Parse( textBox9.Text ) );

				textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read, ' ' );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Build failed：" + ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<bool[]> read = cip.ReadBoolArray( textBox3.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = $"Result[{DateTime.Now:HH:mm:ss}]：" + HslCommunication.BasicFramework.SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed：" + read.ToMessageShowString( ) );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
