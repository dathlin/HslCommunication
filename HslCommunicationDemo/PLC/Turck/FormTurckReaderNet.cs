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
using HslCommunicationDemo.PLC.Common;

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

		private ReaderNet reader_net = null;
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
				Text = "Melsec Read PLC Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
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
			reader_net.LogNet = LogNet;

			button1.Enabled = false;
			reader_net.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = await reader_net.ConnectServerAsync( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				//userControlReadWriteOp1.SetReadWriteNet( reader_net, "100", false );

				// 设置基本的读写信息
				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( reader_net, "100", false );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( reader_net, "100", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => reader_net.ReadFromCoreServer( m ), string.Empty, string.Empty );

				control.SetDevice( reader_net, "100" );
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
