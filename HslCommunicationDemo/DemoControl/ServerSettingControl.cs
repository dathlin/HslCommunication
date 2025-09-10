using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class ServerSettingControl : UserControl
	{
		public ServerSettingControl( )
		{
			InitializeComponent( );

			comboBox_tcp_udp.SelectedIndex = 0;
			comboBox_ipv4.SelectedIndex = 0;

			toolTip1 = new ToolTip( );
			this.toolTip1.SetToolTip( label3, "支持输入两个端口(6000:6001)，同时开启TCP及UDP，如果只输入一个端口号(BOTH)的话，UDP端口就是TCP+1" );
		}

		private void ServerSettingControl_Load( object sender, EventArgs e )
		{

			if (Program.Language == 2)
			{
				label3.Text = "Port:";
				label4.Text = "Ip:";
				button_start.Text = "Start";
				button_close.Text = "Close";
				label14.Text = "Serial:";
				button_start_sertial.Text = "Start";
			}

			this.button_close.Enabled = false;
			this.button_start_sertial.Enabled = false;
		}
		[Browsable(false)]
		public Button ButtonStart => this.button_start;
		[Browsable( false )]
		public Button ButtonClose => this.button_close;
		[Browsable( false )]
		public Button ButtonSerial => this.button_start_sertial;

		[Browsable( false )]
		public TextBox TextBox_Serial => this.textBox_serialPort;

		[Description( "获取或设置当前的端口号信息" )]
		[DefaultValue( "502" )]
		public string TextPort
		{
			get => this.textBox_port.Text;
			set => this.textBox_port.Text = value;
		}

		[Description( "获取或设置使用TCP,UDP,还是都使用" )]
		[DefaultValue( 0 )]
		public int TcpUdpIndex
		{
			get => this.comboBox_tcp_udp.SelectedIndex;
			set => this.comboBox_tcp_udp.SelectedIndex = value;
		}

		[Description( "获取或设置当前是否使用IPv4，还是IPv6" )]
		[DefaultValue( 0 )]
		public int IpV4V6
		{
			get => this.comboBox_ipv4.SelectedIndex;
			set => this.comboBox_ipv4.SelectedIndex = value;
		}

		[Description( "当前串口的默认信息" )]
		public string TextSerialInfo
		{
			get => this.textBox_serialPort.Text;
			set => this.textBox_serialPort.Text = value;
		}

		public bool ServerStart( DeviceServer deviceServer )
		{
			int port1 = 0;
			int port2 = 0;
			if (textBox_port.Text.Contains( ";" ) || textBox_port.Text.Contains( ":" ) || textBox_port.Text.Contains( "-" ))
			{
				string[] ports = textBox_port.Text.Split( new char[] { ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries );
				if (ports.Length >= 1)
				{
					if (!int.TryParse( ports[0], out port1 ))
					{
						DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
						return false;
					}

					if (!int.TryParse( ports[1], out port2 ))
					{
						DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
						return false;
					}
				}
			}
			else
			{
				if (!int.TryParse( textBox_port.Text, out port1 ))
				{
					DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
					return false;
				}
				port2 = port1 + 1;
			}

			deviceServer.ActiveTimeSpan = TimeSpan.FromHours( 1 );                            // 1小时不通信就断开
			deviceServer.EnableIPv6 = comboBox_ipv4.SelectedIndex == 1;                       // 是否开启IPv6
			if (!string.IsNullOrEmpty( textBox_local_ip.Text.Trim( ) ))
			{
				deviceServer.LocalAddress = System.Net.IPAddress.Parse( textBox_local_ip.Text );
			}

			if (comboBox_tcp_udp.SelectedIndex == 0)
			{
				deviceServer.ServerStart( port1, modeTcp: true );
			}
			else if (comboBox_tcp_udp.SelectedIndex == 1)
			{
				deviceServer.ServerStart( port1, modeTcp: false );
			}
			else
			{
				deviceServer.ServerStart( port1, port2 );
			}

			this.button_start.Enabled = false;
			this.button_close.Enabled = true;
			this.button_start_sertial.Enabled = true;
			return true;
		}

		public Action<object, EventArgs> buttonStartAction { get; set; }

		private void button_start_Click( object sender, EventArgs e )
		{
			buttonStartAction?.Invoke( sender, e );
		}

		public Action<object, EventArgs> buttonCloseAction { get; set; }

		private void button_close_Click( object sender, EventArgs e )
		{
			buttonCloseAction?.Invoke( sender, e );
			this.button_start.Enabled = true;
			this.button_close.Enabled = false;
			this.button_start_sertial.Enabled = false;
		}

		public Action<object, EventArgs> buttonSerialAction { get; set; }
		private void button_start_sertial_Click( object sender, EventArgs e )
		{
			buttonSerialAction?.Invoke( sender, e );
		}


		private ToolTip toolTip1;



		public void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( "TcpUdpBoth", comboBox_tcp_udp.SelectedIndex );
			element.SetAttributeValue( "IpV4V6", comboBox_ipv4.SelectedIndex );
			element.SetAttributeValue( "LocalIp", textBox_local_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCom, textBox_serialPort.Text );
		}
		public void LoadXmlParameter( XElement element )
		{
			textBox_port.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlPort, textBox_port.Text, m => m );
			comboBox_tcp_udp.SelectedIndex = HslFormContent.GetXmlValue( element, "TcpUdpBoth", 0, int.Parse );
			comboBox_ipv4.SelectedIndex = HslFormContent.GetXmlValue( element, "IpV4V6", 0, int.Parse );
			textBox_local_ip.Text = HslFormContent.GetXmlValue( element, "LocalIp", "", m => m );
			textBox_serialPort.Text = HslFormContent.GetXmlValue( element, DemoDeviceList.XmlCom, textBox_serialPort.Text, m => m );
		}
	}
}
