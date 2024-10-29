using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.FATEK;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using HslCommunication.Instrument.DLT;

namespace HslCommunicationDemo
{
	public partial class FormDLT645Server : HslFormContent
	{
		public FormDLT645Server( )
		{
			InitializeComponent( );

			checkBox_station_match.CheckedChanged += CheckBox_station_match_CheckedChanged;
			checkBox_enableFE.CheckedChanged += CheckBox_enableFE_CheckedChanged;
			checkBox_string_reverse.CheckedChanged += CheckBox3_CheckedChanged;
		}

		private void CheckBox_enableFE_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.EnableCodeFE = checkBox_enableFE.Checked;
			}
		}

		private void CheckBox_station_match_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.StationMatch = checkBox_station_match.Checked;
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (dLT645Server != null)
			{
				dLT645Server.StringReverse = checkBox_string_reverse.Checked;
			}
		}
		private void FormDLT645Server_Load( object sender, EventArgs e )
		{

			if (Program.Language == 2)
			{
				Text = "DLT645 Virtual Server[supports TCP and Serial";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";

				label14.Text = "Com:";
				button5.Text = "Open Com";
				checkBox_string_reverse.Text = "str-reverse";
			}
			else
			{
				checkBox_station_match.Text = "是否站号匹配";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.Instrument.DLTHelper.GetDlt645Address( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		
		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			dLT645Server?.ServerClose( );
		}

		#region Server Start


		private DLT645Server dLT645Server;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				dLT645Server = new DLT645Server( );                       // 实例化对象
				dLT645Server.Station = textBox1.Text;
				dLT645Server.ActiveTimeSpan = TimeSpan.FromHours( 1 );
				dLT645Server.OnDataReceived += BusTcpServer_OnDataReceived;
				dLT645Server.StringReverse = checkBox_string_reverse.Checked;
				dLT645Server.EnableCodeFE = checkBox_enableFE.Checked;
				dLT645Server.StationMatch = checkBox_station_match.Checked;
				this.sslServerControl1.InitializeServer( dLT645Server );
				userControlReadWriteServer1.SetReadWriteServer( dLT645Server, "02-01-01-00" );
				dLT645Server.ServerStart( port );

				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;


				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", dLT645Server, nameof( dLT645Server.Station ), nameof( dLT645Server.StringReverse ), nameof( dLT645Server.EnableCodeFE ), nameof( dLT645Server.StationMatch ) );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}


		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			dLT645Server?.ServerClose( );
			dLT645Server?.CloseSerialSlave( );
			button1.Enabled = true;
			button5.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived( object sender, object source, byte[] modbus )
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

		private void button5_Click( object sender, EventArgs e )
		{
			// 启动串口
			if (dLT645Server != null)
			{
				try
				{
					OperateResult open = dLT645Server.StartSerialSlave( textBox10.Text );
					if (!open.IsSuccess)
					{
						MessageBox.Show( "Start Failed：" + open.Message );
						return;
					}
					button5.Enabled = false;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", textBox10.Text, dLT645Server, nameof( dLT645Server.Station ), nameof( dLT645Server.StringReverse ), nameof( dLT645Server.EnableCodeFE ), nameof( dLT645Server.StationMatch ) );
				}
				catch(Exception ex)
				{
					MessageBox.Show( "Start Failed：" + ex.Message );
				}
			}
			else
			{
				MessageBox.Show( "Start tcp server first please!" );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCom, textBox10.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox_string_reverse.Checked );


			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			checkBox_string_reverse.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );

			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void panel1_Paint( object sender, PaintEventArgs e )
		{

		}
	}
}
