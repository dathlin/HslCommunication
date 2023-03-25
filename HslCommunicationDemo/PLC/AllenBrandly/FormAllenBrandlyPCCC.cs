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
using HslCommunication.Profinet.AllenBradley;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormAllenBrandlyPCCC : HslFormContent
	{
		public FormAllenBrandlyPCCC( )
		{
			InitializeComponent( );
			allenBradleyNet = new AllenBradleyPcccNet( "192.168.0.110" );
		}


		private AllenBradleyPcccNet allenBradleyNet = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "AllenBrandly CIP PCCC Read PLC Demo";
				label1.Text = "Ip:";
				label2.Text = "Fit to:";
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

			allenBradleyNet.IpAddress = textBox1.Text;
			allenBradleyNet.Port = port;
			allenBradleyNet.LogNet = LogNet;

			try
			{
				OperateResult connect = allenBradleyNet.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( allenBradleyNet, "A9:0", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( allenBradleyNet, "A9:0", "A9:0   B9:0   N9:0   F9:0   S:0   ST1:0" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => allenBradleyNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
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
			allenBradleyNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
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
	}
}
