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
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.AllenBrandly;
using HslCommunication.Profinet.AllenBradley;

namespace HslCommunicationDemo
{
	public partial class FormCipServer : HslFormContent
	{
		public FormCipServer( )
		{
			InitializeComponent( );

			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
			DemoUtils.SetPanelAnchor( panel1, panel2 );

			checkBox_log_analysis.CheckedChanged += CheckBox_log_analysis_CheckedChanged;
		}

		private void CheckBox_log_analysis_CheckedChanged( object sender, EventArgs e )
		{
			if (cipServer != null)
			{
				cipServer.AnalysisLogMessage = checkBox_log_analysis.Checked;
			}
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (cipServer != null)
			{
				cipServer.CreateTagWithWrite = checkBox1.Checked;
			}
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Cip Virtual Server [support single value]";
				checkBox1.Text = "Create Tag when write";
				checkBox_log_analysis.Text = "Log Analysis";
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

			if (this.serverSettingControl1.ButtonStart.Enabled == false)
			{
				button11_Click( null, EventArgs.Empty );
			}
		}

		#region Server Start

		private HslCommunication.Profinet.AllenBradley.AllenBradleyServer cipServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;
		private CipTagsListControl tagsListControl;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{

				cipServer = new HslCommunication.Profinet.AllenBradley.AllenBradleyServer( );                       // 实例化对象
				cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
				cipServer.CreateTagWithWrite = checkBox1.Checked;
				cipServer.AnalysisLogMessage = checkBox_log_analysis.Checked;
				this.sslServerControl1.InitializeServer( cipServer );
				short[] d = new short[20];
				float[] a1 = new float[30];
				for (int i = 0; i < d.Length; i++)
				{
					d[i] = (short)(i + 1);
					a1[i] = d[i];
				}

				userControlReadWriteServer1.SetReadWriteServerLog( cipServer );

				this.sslServerControl1.InitializeServer( cipServer );
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

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", cipServer, this.sslServerControl1, nameof( cipServer.CreateTagWithWrite ), nameof( cipServer.AnalysisLogMessage ) );
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
			if (cipServer != null)
			{
				cipServer.StartSerialSlave( this.serverSettingControl1.TextBox_Serial.Text );
				this.serverSettingControl1.ButtonSerial.Enabled = false;

				// 设置示例的代码
				codeExampleControl.SetCodeText( "server", this.serverSettingControl1.TextBox_Serial.Text, cipServer, nameof( cipServer.CreateTagWithWrite ), nameof( cipServer.AnalysisLogMessage ) );
			}
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
			element.SetAttributeValue( "AnalysisLogMessage", checkBox_log_analysis.Checked );
			this.sslServerControl1.SaveXmlParameter( element );
			this.serverSettingControl1.SaveXmlParameter( element );
			element.SetAttributeValue( nameof( HslCommunication.Profinet.AllenBradley.AllenBradleyServer.CreateTagWithWrite ), checkBox1.Checked );
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
			this.checkBox_log_analysis.Checked = GetXmlValue( element, "AnalysisLogMessage", false, bool.Parse );
			this.sslServerControl1.LoadXmlParameter( element );
			this.serverSettingControl1.LoadXmlParameter( element );
			checkBox1.Checked = GetXmlValue( element, nameof( HslCommunication.Profinet.AllenBradley.AllenBradleyServer.CreateTagWithWrite ), false, bool.Parse );

			saveTags = new List<AllenBradleyItemValue>( );
			foreach (var item in element.Elements( nameof( AllenBradleyItemValue ) ))
			{
				AllenBradleyItemValue itemValue = new AllenBradleyItemValue( );
				itemValue.LoadByXml( item );
				saveTags.Add( itemValue );
			}
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void serverSettingControl1_Load( object sender, EventArgs e )
		{

		}
	}
}
