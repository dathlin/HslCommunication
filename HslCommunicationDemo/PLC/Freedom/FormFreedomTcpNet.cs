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

namespace HslCommunicationDemo
{
	public partial class FormFreedomTcpNet : HslFormContent
	{
		public FormFreedomTcpNet( )
		{
			InitializeComponent( );
			freedom = new FreedomTcpNet( );
		}


		private FreedomTcpNet freedom = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );


			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
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
				Text = "Free protocol access based on Tcp ip";

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
			freedom.IpAddress = textBox_ip.Text;

			if (!int.TryParse( textBox_port.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}
			freedom.LogNet = LogNet;

			if (radioButton1.Checked) freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );
			if (radioButton2.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );
			if (radioButton3.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseWordTransform( );

			ComboBox2_SelectedIndexChanged( null, null );
			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;

			freedom.Port = port;

			freedom.ConnectClose( );

			button1.Enabled = false;
			freedom.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = await freedom.ConnectServerAsync( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( freedom, "", true );
				// 设置批量读取
				userControlReadWriteDevice1.BatchRead.SetReadWriteNet( freedom, "", string.Empty );
				// 设置报文读取
				userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => freedom.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
			}
			else
			{
				MessageBox.Show( connect.Message );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			freedom.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );

			if      (radioButton1.Checked) element.SetAttributeValue( "ByteTransform", 1 );
			else if (radioButton2.Checked) element.SetAttributeValue( "ByteTransform", 2 );
			else if (radioButton3.Checked) element.SetAttributeValue( "ByteTransform", 3 );

			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;

			int index = GetXmlValue( element, "ByteTransform", 1, int.Parse );
			if (index == 1) radioButton1.Checked = true;
			else if (index == 2) radioButton2.Checked = true;
			else if (index == 3) radioButton3.Checked = true;

			comboBox2.SelectedIndex = GetXmlValue( element, DemoDeviceList.XmlDataFormat, 0, int.Parse );
			checkBox3.Checked = GetXmlValue( element, DemoDeviceList.XmlStringReverse, false, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}

}
