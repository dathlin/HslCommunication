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
using HslCommunicationDemo.Instrument;

namespace HslCommunicationDemo
{
	public partial class FormDLT698TcpNet : HslFormContent
	{
		public FormDLT698TcpNet( )
		{
			InitializeComponent( );
		}

		private DLT698TcpNet dLT698 = null;
		private DLT698Control control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );
			control = new DLT698Control( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "DLT698 Read Demo";

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

			dLT698?.ConnectClose( );
			dLT698 = new DLT698TcpNet( textBox_ip.Text, port, textBox_station.Text);
			dLT698.LogNet = LogNet;
			dLT698.UseSecurityResquest = checkBox_useSecurityResquest.Checked;

			try
			{
				OperateResult connect = dLT698.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( dLT698, "20-00-02-00", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( dLT698, "20-00-02-00", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => dLT698.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => dLT698.ReadByApdu( m ), "Apdu", "Apdu Message: 05 01 01 20 10 02 00 00" );

					control.SetDevice( dLT698, "20-00-02-00" );
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
			dLT698.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
			element.SetAttributeValue( "UseSecurityResquest", checkBox_useSecurityResquest.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox_useSecurityResquest.Checked = GetXmlValue( element, "UseSecurityResquest", true, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
