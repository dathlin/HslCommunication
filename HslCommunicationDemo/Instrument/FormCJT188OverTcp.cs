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
using HslCommunication.Instrument.DLT;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunication.Instrument.CJT;
using HslCommunicationDemo.Instrument;

namespace HslCommunicationDemo
{
	public partial class FormCJT188OverTcp : HslFormContent
	{
		public FormCJT188OverTcp( )
		{
			InitializeComponent( );
		}

		private CJT188OverTcp cjt188 = null;
		private CJT188Control control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );

			control = new CJT188Control( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "CJT188 Read Demo";

				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label_address.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				textBox_password.Text = "Pwd:";
				textBox_op_code.Text = "Op Code:";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox_port.Text,out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			cjt188?.ConnectClose( );
			cjt188 = new CJT188OverTcp( textBox_station.Text );
			cjt188.IpAddress = textBox_ip.Text;
			cjt188.InstrumentType = Convert.ToByte( textBox_type.Text, 16 );
			cjt188.Port = port;
			cjt188.LogNet = LogNet;
			cjt188.EnableCodeFE = checkBox_enable_Fe.Checked;
			cjt188.StationMatch = checkBox_station_match.Checked;


			try
			{
				OperateResult connect = cjt188.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16
					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( cjt188, "90-1F", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( cjt188, "90-1F", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => cjt188.ReadFromCoreServer( m, true, false ), string.Empty, "68 00 00 00 00 00 01 68 11 04 00 00 00 00 10 16" );

					control.SetDevice( cjt188, "90-1F" );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
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
			cjt188.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate,  textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation,   textBox_station.Text );
			element.SetAttributeValue( "InstrumentType",      textBox_type.Text );
			element.SetAttributeValue( "StationMatch",        checkBox_station_match.Checked.ToString( ) );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text      = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, DemoDeviceList.XmlIpAddress, "192.168.0.100" );
			textBox_port.Text    = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			textBox_type.Text    = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, "InstrumentType", "19" );
			checkBox_station_match.Checked = HslCommunication.BasicFramework.SoftBasic.GetXmlValue( element, "StationMatch", false );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
