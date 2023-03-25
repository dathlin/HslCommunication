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
using HslCommunication.Profinet.Keyence;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Keyence;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceNanoSerialOverTcp : HslFormContent
	{
		public FormKeyenceNanoSerialOverTcp( )
		{
			InitializeComponent( );
			keyence = new KeyenceNanoSerialOverTcp( );
		}


		private KeyenceNanoSerialOverTcp keyence = null;
		private NanoControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
			control = new NanoControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence Read PLC Demo";

				label27.Text = "Ip:";
				label26.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label1.Text = "Station:";
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

			if (!byte.TryParse( textBox3.Text, out byte station ))
			{
				MessageBox.Show( "Station int wrong, it needs 0 - 255" );
				return;
			}


			keyence?.ConnectClose( );
			keyence = new KeyenceNanoSerialOverTcp( );
			keyence.IpAddress = textBox1.Text;
			keyence.Port = port;
			keyence.Station = station;
			keyence.UseStation = checkBox1.Checked;
			keyence.LogNet = LogNet;

			try
			{
				OperateResult connect = keyence.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( keyence, "DM100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( keyence, "DM100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => keyence.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					// 特殊读取
					control.SetDevice( keyence, "DM100" );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
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
			keyence.ConnectClose( );
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
