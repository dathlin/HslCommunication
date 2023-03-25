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
using HslCommunication;
using HslCommunication.Profinet.Yokogawa;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Yokogawa;

namespace HslCommunicationDemo
{
	public partial class FormYokogawaLinkTcp : HslFormContent
	{
		public FormYokogawaLinkTcp( )
		{
			InitializeComponent( );
			yokogawa = new YokogawaLinkTcp( );
			yokogawa.ConnectTimeOut = 2000;
		}


		private YokogawaLinkTcp yokogawa = null;
		private YokogawaLinkControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
			control = new YokogawaLinkControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Yokogawa Read PLC Demo";

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

			if (!byte.TryParse( textBox16.Text, out byte cpu ))
			{
				MessageBox.Show( "Cpu Number input wrong！" );
				return;
			}
			
			yokogawa.IpAddress = textBox1.Text;
			yokogawa.Port = port;
			yokogawa.CpuNumber = cpu;
			yokogawa.LogNet = LogNet;

			OperateResult connect = yokogawa.ConnectServer( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				//userControlReadWriteOp1.SetReadWriteNet( yokogawa, "D100", false );

				// 设置基本的读写信息
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( yokogawa, "D100", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( yokogawa, "D100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => yokogawa.ReadFromCoreServer( m, hasResponseData: true, usePackAndUnpack: false ), string.Empty, string.Empty );

				control.SetDevice( yokogawa, "D100" );
			}
			else
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			yokogawa.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUnitNumber, textBox16.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlUnitNumber ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
