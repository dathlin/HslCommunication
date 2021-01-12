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
using HslCommunication.ModBus;
using System.Threading;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormCipServer : HslFormContent
	{
		public FormCipServer( )
		{
			InitializeComponent( );
		}



		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;


			if(Program.Language == 2)
			{
				Text = "Cip Virtual Server [support single value]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			cipServer?.ServerClose( );
		}

		#region Server Start

		private HslCommunication.Profinet.AllenBradley.AllenBradleyServer cipServer;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			try
			{

				cipServer = new HslCommunication.Profinet.AllenBradley.AllenBradleyServer( );                       // 实例化对象
				cipServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
				
				cipServer.ServerStart( port );
				cipServer.AddTagValue( "A", (short)10 );
				cipServer.AddTagValue( "A1", (short)1000 );
				cipServer.AddTagValue( "B", 123 );
				cipServer.AddTagValue( "C", 123f );
				cipServer.AddTagValue( "D", new short[] { 1,2,3,4,5 } );
				cipServer.AddTagValue( "E", true );
				cipServer.AddTagValue( "F", "12345", 100 );
				cipServer.AddTagValue( "G", new string[5] { "123", "123456", string.Empty, "abcd", "测试" }, 100 );
				cipServer.AddTagValue( "AB.C", new short[] { 1, 2, 3, 4, 5 } );
				cipServer.AddTagValue( "M", new uint[] { 12345678, 34567, 567890, 1234567 } );
				cipServer.AddTagValue( "REAL500", new float[500] );

				button1.Enabled = false;
				panel2.Enabled = true;
				button11.Enabled = true;
				userControlReadWriteServer1.SetReadWriteServer( cipServer, "A", 1 );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			cipServer?.ServerClose( );
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived( object sender, byte[] receive )
		{
			// 可以对接收到的数据进行二次处理
		}

		#endregion

		private void userControlReadWriteServer1_Load( object sender, EventArgs e )
		{

		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
