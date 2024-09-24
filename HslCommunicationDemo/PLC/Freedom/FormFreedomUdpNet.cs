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
using HslCommunication.Profinet.Freedom;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormFreedomUdpNet : HslFormContent
	{
		public FormFreedomUdpNet( )
		{
			InitializeComponent( );
			freedom = new FreedomUdpNet( );
		}


		private FreedomUdpNet freedom = null;
		private CodeExampleControl codeExampleControl;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			Language( Program.Language );


			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteDevice1.SetEnable( false );
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (freedom != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Free protocol access based on Udp ip";

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



		private void button1_Click( object sender, EventArgs e )
		{
			freedom.IpAddress = textBox_ip.Text;

			if (!int.TryParse( textBox_port.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}
			freedom.LogNet = LogNet;

			freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );

			ComboBox2_SelectedIndexChanged( null, null );
			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;

			freedom.Port = port;

			button1.Enabled = false;
			MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
			button2.Enabled = true;
			button1.Enabled = false;
			userControlReadWriteDevice1.SetEnable( true );

			userControlReadWriteDevice1.SetReadWriteNet( freedom, "", true );
			// 设置批量读取
			userControlReadWriteDevice1.BatchRead.SetReadWriteNet( freedom, "", string.Empty );
			// 设置报文读取
			userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => freedom.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

			// 设置代码示例
			this.userControlReadWriteDevice1.SetDeviceVariableName( DemoUtils.PlcDeviceName );
			codeExampleControl.SetCodeText( freedom, nameof( freedom.ByteTransform ) );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			userControlReadWriteDevice1.SetEnable( false );
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );

			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;

			comboBox2.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, 0, int.Parse );
			checkBox3.Checked = GetXmlValue( element, DemoDeviceList.XmlStringReverse, false, bool.Parse );

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}


	}

}
