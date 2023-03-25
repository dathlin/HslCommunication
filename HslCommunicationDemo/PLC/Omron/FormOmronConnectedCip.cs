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
using HslCommunication.Profinet.Omron;
using HslCommunication;
using HslCommunication.Profinet.AllenBradley;
using System.Xml.Linq;
using HslCommunicationDemo.PLC.AllenBrandly;

namespace HslCommunicationDemo
{
	public partial class FormOmronConnectedCip : HslFormContent
	{
		public FormOmronConnectedCip( )
		{
			InitializeComponent( );
			omronCipNet = new OmronConnectedCipNet( "192.168.0.110" );
		}


		private OmronConnectedCipNet omronCipNet = null;
		private AllenBrandlyControl control;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );
			control = new AllenBrandlyControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label22.Text = "plc tag name";
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

			omronCipNet.IpAddress = textBox1.Text;
			omronCipNet.Port = port;
			omronCipNet.LogNet = LogNet;
			omronCipNet.ConnectTimeOut = 5000;

			omronCipNet.SetPersistentConnection( );

			try
			{
				OperateResult connect = omronCipNet.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( omronCipNet, "A1", true, 1 );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( omronCipNet, "A1", string.Empty );
					userControlReadWriteDevice1.BatchRead.SetReadRandom( omronCipNet.Read, "A1;A2    Length input \"1;1\"" );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronCipNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => omronCipNet.ReadCipFromServer( m ), "CIP", "CIP Message, example: " );
					// TODO EIP及CIP的例子填充

					control.SetDevice( omronCipNet, "A1" );
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
			OperateResult close = omronCipNet.ConnectClose( );
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
