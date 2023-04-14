using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication.Profinet.Melsec;
using System.Threading;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormMelsecAsciiUdp : HslFormContent
	{
		public FormMelsecAsciiUdp( )
		{
			InitializeComponent( );
			melsec_net = new MelsecMcAsciiUdp( );
		}


		private MelsecMcAsciiUdp melsec_net = null;


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
				label21.Text = "Address:";
				label22.Text = "M100 D100 X1A0 Y1A0";
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
			melsec_net.IpAddress = textBox1.Text;
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			melsec_net.LogNet = LogNet;
			melsec_net.Port = port;
			melsec_net.EnableWriteBitToWordRegister = checkBox_EnableWriteBitToWordRegister.Checked;

			button2.Enabled = true;
			button1.Enabled = false;
			panel2.Enabled = true;

			// 设置子控件的读取能力
			userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( melsec_net, "D100", false );
			// 设置批量读取
			userControlReadWriteDevice1.BatchRead.SetReadWriteNet( melsec_net, "D100", string.Empty );
			userControlReadWriteDevice1.BatchRead.SetReadRandom( melsec_net.ReadRandom, "D100;W100;D500" );
			userControlReadWriteDevice1.BatchRead.SetReadWordRandom( melsec_net.ReadRandom, "D100;W100;D500" );
			// 设置报文读取
			userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => melsec_net.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "EnableWriteBitToWordRegister", checkBox_EnableWriteBitToWordRegister.Text );
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
