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
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.Core.Net;
using HslCommunicationDemo.PLC.Siemens;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormSiemensDTU : HslFormContent
	{
		public FormSiemensDTU( )
		{
			InitializeComponent( );
		}


		private SiemensS7Net siemensTcpNet = null;
		private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;
		private SiemensS7Control control;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.SelectedIndex = 0;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			Language( Program.Language );

			control = new SiemensS7Control( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( control );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( Helper.GetSiemensS7Address( ) );
			userControlReadWriteDevice1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			siemensPLCSelected = comboBox1.SelectedItem.ToString( ) == "S1200" ? SiemensPLCS.S1200 :
				comboBox1.SelectedItem.ToString( ) == "S1500" ? SiemensPLCS.S1500 :
				comboBox1.SelectedItem.ToString( ) == "S300" ? SiemensPLCS.S300 :
				comboBox1.SelectedItem.ToString( ) == "S400" ? SiemensPLCS.S400 :
				comboBox1.SelectedItem.ToString( ) == "S200" ? SiemensPLCS.S200 :
				SiemensPLCS.S200Smart;
			if (siemensPLCSelected == SiemensPLCS.S400)
			{
				textBox15.Text = "0";
				textBox16.Text = "3";
			}
			else if (siemensPLCSelected == SiemensPLCS.S1200)
			{
				textBox15.Text = "0";
				textBox16.Text = "0";
			}
			else if (siemensPLCSelected == SiemensPLCS.S300)
			{
				textBox15.Text = "0";
				textBox16.Text = "2";
			}
			else if (siemensPLCSelected == SiemensPLCS.S1500)
			{
				textBox15.Text = "0";
				textBox16.Text = "0";
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";

				label3.Text = "Port:";
				button1.Text = "Create";
				button2.Text = "Disconnect";
			}
		}
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Alien Server

		/**************************************************************************************************
		 * 
		 *    说明：异形服务器的创建，为异形Modbus-Tcp客户端的创建提供必要的网络支撑
		 * 
		 **************************************************************************************************/

		private NetworkAlienClient networkAlien = null;

		private void NetworkAlienStart( int port )
		{
			networkAlien = new NetworkAlienClient( );
			networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
			networkAlien.ServerStart( port );
		}

		private void NetworkAlien_OnClientConnected( AlienSession session )
		{
			if (session.DTU == siemensTcpNet.ConnectionId)
			{
				siemensTcpNet.ConnectServer( session );
				Invoke( new Action( ( ) =>
				{
					userControlReadWriteDevice1.SetEnable( true );
					button2.Enabled = true;
				} ) );
			}
		}

		#endregion

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( "端口输入不正确！" );
				return;
			}

			siemensTcpNet = new SiemensS7Net( siemensPLCSelected, "127.0.0.1" );
			siemensTcpNet.LogNet = LogNet;
			if (siemensPLCSelected != SiemensPLCS.S200Smart)
			{
				siemensTcpNet.Rack = byte.Parse( textBox15.Text );
				siemensTcpNet.Slot = byte.Parse( textBox16.Text );
			}

			try
			{
				siemensTcpNet.ConnectionId = textBox1.Text; // 设置唯一的ID
				NetworkAlienStart( port );
				siemensTcpNet.ConnectServer( null );        // 切换为异形客户端，并等待服务器的连接。

				// 设置子控件的读取能力
				userControlReadWriteDevice1.SetReadWriteNet( siemensTcpNet, "M100", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( siemensTcpNet, "M100", string.Empty );
				userControlReadWriteDevice1.BatchRead.SetReadRandom( siemensTcpNet.Read, "M100;M200;DB1.0;Q0" );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => siemensTcpNet.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

				control.SetDevice( siemensTcpNet, "M100" );

				MessageBox.Show( "等待服务器的连接！" );
				button1.Enabled = false;
				button2.Enabled = true;


				List<string> parameters = new List<string>( );
				parameters.Add( nameof( siemensTcpNet.ConnectionId ) );
				if (siemensPLCSelected != SiemensPLCS.S200Smart)
				{
					parameters.Add( nameof( siemensTcpNet.Rack ) );
					parameters.Add( nameof( siemensTcpNet.Slot ) );
				}

				// 设置代码示例
				codeExampleControl.SetCodeText( siemensTcpNet, parameters.ToArray( ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}

		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			siemensTcpNet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
		}
		
		#endregion

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private long successCount = 0;
		private System.Windows.Forms.Timer timer;


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( "DTU", textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlRack, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox16.Text );
			element.SetAttributeValue( "PlcType", comboBox1.SelectedIndex );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( "DTU" ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlRack ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( "PlcType" ).Value );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
