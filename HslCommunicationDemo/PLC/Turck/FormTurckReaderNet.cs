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
using HslCommunication.Profinet.Turck;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.LogNet;
using HslCommunicationDemo.Control;

namespace HslCommunicationDemo
{
	public partial class FormTurckReaderNet : HslFormContent
	{
		public FormTurckReaderNet( )
		{
			InitializeComponent( );
			reader_net = new ReaderNet( );
			//reader_net.LogNet = new LogNetSingle( "" );
			//reader_net.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			  {
				  textBox3.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			  } ) );
		}

		private ReaderNet reader_net = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

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



		private async void button1_Click( object sender, EventArgs e )
		{
			reader_net.IpAddress = textBox1.Text;
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			reader_net.Port = port;

			reader_net.ConnectClose( );

			button1.Enabled = false;
			reader_net.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = await reader_net.ConnectServerAsync( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				userControlReadWriteOp1.SetReadWriteNet( reader_net, "100", false );
			}
			else
			{
				MessageBox.Show( connect.Message + Environment.NewLine + "ErrorCode: " + connect.ErrorCode );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			reader_net.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( reader_net, textBox6, textBox9, textBox10 );
		}

		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = reader_net.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
		

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = reader_net.ReadRFIDInfo( );
			if (read.IsSuccess)
			{
				label2.Text = "UID: " + reader_net.UID;
				label4.Text = "BytesOfBlock: " + reader_net.BytesOfBlock;
				label5.Text = "NumberOfBlock: " + reader_net.NumberOfBlock;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}
		}

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

	}

}
