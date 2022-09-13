using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.Instrument.IEC;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormIEC104 : HslFormContent
	{
		public FormIEC104( )
		{
			InitializeComponent( );
		}

		private IEC104 iec104 = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "DLT645 Read Demo";

				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label21.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";

				label11.Text = "Address:";
				label12.Text = "length:";
				button_read_batch.Text = "Bulk Read";
				label13.Text = "Results:";

				groupBox3.Text = "Bulk Read test";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			button1.Enabled = false;
			iec104?.ConnectClose( );
			iec104 = new IEC104( textBox3.Text, port );
			iec104.OnIEC104MessageReceived += Iec104_IEC104MessageReceived;
			iec104.LogNet = LogNet;
			try
			{
				OperateResult connect = await iec104.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteOp1.SetReadWriteNet( iec104, "0", true );
					userControlReadWriteOp1.Enabled = false;
					button_read_batch.Enabled = false;
				}
				else
				{
					button1.Enabled = true;
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void Iec104_IEC104MessageReceived( object sender, IEC104MessageEventArgs e )
		{
			if (!checkBox1.Checked)
			{
				Invoke( new Action( ( ) =>
				  {
					  if (e.TypeID == IEC104.TypeID.M_ME_TF_1)
					  {
						  // 带时标的测量值浮点数
						  if (e.InfoObjectCount == 1)
						  {
							  try
							  {
								  IecValueObject<float> obj = IecValueObject<float>.PraseFloat( e.Body, 0 );
								  textBox10.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff  " ) + $"Float, Address[{obj.Address}] 品质[{obj.Quality}] 值[{obj.Value}] 时标[{obj.Time}]" + Environment.NewLine );
							  }
							  catch
							  {
								  textBox10.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff  " ) + $"Float failed, Source: {e.ASDU.ToHexString( ' ' )}" + Environment.NewLine );
							  }
							  return;
						  }
					  }
					  textBox10.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff " ) + "Source: " + e.ASDU.ToHexString( ' ' ) + Environment.NewLine );
				  } ) );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			iec104.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( iec104, textBox6, textBox9, textBox10 );
		}

		#endregion

		#region 报文读取测试

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult send = iec104.SendFrameIMessage( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) );
			if (!send.IsSuccess)
				MessageBox.Show( "Send Failed：" + send.ToMessageShowString( ) );
			//OperateResult<byte[]> read = iec104.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) );
			//if (read.IsSuccess)
			//{
			//    textBox10.AppendText( DateTime.Now.ToString() + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content ) + Environment.NewLine );
			//}
			//else
			//{
			//    MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			//}
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			textBox4.Text = HslCommunication.Instrument.IEC.Helper.IECHelper.GetAbsoluteTimeScale( DateTime.Now, true ).ToHexString( ' ' );
		}

		private void button_u_start_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x07);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}
		}

		private void button_u_stop_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x13);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}
		}

		private void button_u_test_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x43);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}
		}
	}
}
