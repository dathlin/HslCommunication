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
using HslCommunication.Instrument.RKC;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormRkcTemperatureControllerOverTcp : HslFormContent
	{
		public FormRkcTemperatureControllerOverTcp( )
		{
			InitializeComponent( );
		}


		private TemperatureControllerOverTcp rkc = null;
		private SpecialFeaturesControl control;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );

			control = new SpecialFeaturesControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "RKC CD/CH digital temperature controller";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				label21.Text = "station";
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
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if (!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "Station input wrong！" );
				return;
			}

			rkc?.ConnectClose( );
			rkc = new TemperatureControllerOverTcp( );
			rkc.Station = station;
			rkc.IpAddress = textBox1.Text;
			rkc.Port = port;
			rkc.LogNet = LogNet;

			try
			{
				OperateResult connect = rkc.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( rkc, "M1", true );
					userControlReadWriteDevice1.ReadWriteOp.EnableRKC( );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( rkc, "M1", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => rkc.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					control.SetDevice( rkc, "M1" );
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
			rkc.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
