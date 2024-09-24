using HslCommunication;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo.MQTT
{
	public partial class FormMqttRpcDevice : HslFormContent
	{
		public FormMqttRpcDevice( )
		{
			InitializeComponent( );
		}

		private void FormMqttRpcDevice_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			panel2.Enabled = false;
			button2.Enabled = false;

			codeExampleControl = new CodeExampleControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private MqttRpcDevice rpc;
		private CodeExampleControl codeExampleControl;

		private async void button1_Click( object sender, EventArgs e )
		{
			// 连接
			MqttConnectionOptions options = new MqttConnectionOptions( )
			{
				IpAddress = textBox_ip.Text,
				Port = int.Parse( textBox2.Text ),
				ClientId = textBox3.Text,
				UseRSAProvider = checkBox_rsa.Checked,
			};
			if (!string.IsNullOrEmpty( textBox9.Text ) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
			}

			button1.Enabled = false;
			rpc = new MqttRpcDevice( options, textBox_deviceTopic.Text );
			OperateResult connect = await rpc.ConnectServerAsync( );

			if (connect.IsSuccess)
			{
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				this.userControlReadWriteDevice1.SetReadWriteNet( rpc, "100", true, 10 );
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );

				// 设置代码示例
				codeExampleControl.SetCodeText( rpc, nameof( rpc.DeviceTopic ) );
			}
			else
			{
				button1.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
					"Error: " + connect.ErrorCode );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			rpc.ConnectClose( );
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort,      textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName,  textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword,  textBox10.Text );
			element.SetAttributeValue( "DeviceTopic",               textBox_deviceTopic.Text );

			this.userControlReadWriteDevice1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text            = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text            = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text            = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox9.Text            = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text           = element.Attribute( DemoDeviceList.XmlPassword ).Value;
			textBox_deviceTopic.Text = element.Attribute( "DeviceTopic" ).Value;

			if (this.userControlReadWriteDevice1.LoadDataTable( element ) > 0)
				this.userControlReadWriteDevice1.SelectTabDataTable( );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
