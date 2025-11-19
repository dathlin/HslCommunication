using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.ModBus;
using HslCommunication.Profinet;
using HslCommunication.Profinet.AllenBradley;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.AllenBrandly;

namespace HslCommunicationDemo
{
	public partial class FormOmronCipServer : HslFormContent
	{
		public FormOmronCipServer( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}



		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Omron Cip Virtual Server [support single value]";
				checkBox1.Text = "Create Tag when write";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.AllenBrandly.Helper.GetCIPAddressExamples( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );

			tagsListControl = new CipTagsListControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( tagsListControl, false, CipTagsListControl.GetTitle( ) );

			this.serverSettingControl1.buttonStartAction = button1_Click;
			this.serverSettingControl1.buttonCloseAction = button11_Click;
			this.serverSettingControl1.buttonSerialAction = button5_Click;
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			CheckTableDataChanged( this.userControlReadWriteServer1, e );
			if (e.Cancel) return;

			if (this.serverSettingControl1.ButtonStart.Enabled == false) button11_Click( null, EventArgs.Empty );
		}

		#region Server Start

		private HslCommunication.Profinet.Omron.OmronCipServer cipServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private CipTagsListControl tagsListControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{

				cipServer = new HslCommunication.Profinet.Omron.OmronCipServer( );                       // 实例化对象
				cipServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
				cipServer.CreateTagWithWrite = checkBox1.Checked;
				this.sslServerControl1.InitializeServer( cipServer );

				short[] d = new short[20];
				float[] a1 = new float[20];
				for (int i = 0; i < d.Length; i++)
				{
					d[i] = (short)(i + 1);
					a1[i] = d[i];
				}

				if (this.serverSettingControl1.ServerStart( cipServer ) == false) return;
				//cipServer.AddTagValue( "TEST2", new bool[10000] );
				cipServer.AddTagValue( "A", (short)10 );
				cipServer.AddTagValue( "A1", a1 );
				cipServer.AddTagValue( "B", 123 );
				cipServer.AddTagValue( "C", 123f );
				cipServer.AddTagValue( "D", d );
				cipServer.AddTagValue( "E", true );
				cipServer.AddTagValue( "F", "12345", 100 );
				cipServer.AddTagValue( "G", new string[5] { "123", "123456", string.Empty, "abcd", "测试" }, 50 );
				cipServer.AddTagValue( "AB.C", new short[] { 1, 2, 3, 4, 5 } );
				cipServer.AddTagValue( "M", new uint[] { 1, 2, 3, 4 } );
				cipServer.AddTagValue( "REAL500", new float[50] );
				cipServer.AddTagValue( "N", 100L );

				if (this.saveTags.Count > 0)
				{
					foreach (var tag in this.saveTags)
					{
						cipServer.AddTagValue( tag.Name, tag );
					}
				}
				userControlReadWriteServer1.SetEnable( true );
				userControlReadWriteServer1.SetReadWriteServer( cipServer, "A", 1 );
				tagsListControl.SetDevice( cipServer );

				// 设置示例代码
				codeExampleControl.SetCodeText( "server", "", cipServer, this.sslServerControl1, nameof( cipServer.CreateTagWithWrite ) );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			userControlReadWriteServer1.Close( );
			cipServer?.ServerClose( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			cipServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
			this.serverSettingControl1.ButtonSerial.Enabled = false;

			// 设置示例代码
			codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, cipServer, this.sslServerControl1, nameof( cipServer.CreateTagWithWrite ) );

		}

		private void BusTcpServer_OnDataReceived( object sender, object source, byte[] receive )
		{
			// 我们可以捕获到接收到的客户端的modbus报文
			// 如果是TCP接收的
			if (source is HslCommunication.Core.Net.AppSession session)
			{
				// 获取当前客户的IP地址
				string ip = session.IpAddress;
			}

			// 如果是串口接收的
			if (source is System.IO.Ports.SerialPort serialPort)
			{
				// 获取当前的串口的名称
				string portName = serialPort.PortName;
			}
		}

		#endregion

		private void userControlReadWriteServer1_Load( object sender, EventArgs e )
		{

		}


		private List<AllenBradleyItemValue> saveTags = new List<AllenBradleyItemValue>( );

		public override void SaveXmlParameter( XElement element )
		{
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "CreateTagWithWrite", checkBox1.Checked );
			this.userControlReadWriteServer1.GetDataTable( element );

			foreach (var tag in this.cipServer.TagValueDict)
			{
				XElement item = tag.Value.ToXml( );
				item.SetAttributeValue( "Name", tag.Key );
				element.Add( item );
			}
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			checkBox1.Checked = GetXmlValue( element, "CreateTagWithWrite", false, bool.Parse );
			this.userControlReadWriteServer1.LoadDataTable( element );

			saveTags = new List<AllenBradleyItemValue>( );
			foreach (var item in element.Elements( nameof( AllenBradleyItemValue ) ))
			{
				AllenBradleyItemValue itemValue = new AllenBradleyItemValue( );
				itemValue.LoadByXml( item );
				saveTags.Add( itemValue );
			}
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
