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
using HslCommunicationDemo.Modbus;

namespace HslCommunicationDemo
{
	public partial class FormModbusAsciiOverTcp : HslFormContent
	{
		public FormModbusAsciiOverTcp( )
		{
			InitializeComponent( );
		}


		private ModbusAsciiOverTcp busAsciiClient = null;
		private ModbusControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.SelectedIndex = 2;

			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

			Language( Program.Language );
			control = new ModbusControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Modbus Ascii OverTcp Read Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (busAsciiClient != null)
			{
				switch (comboBox1.SelectedIndex)
				{
					case 0: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.ABCD;break;
					case 1: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: busAsciiClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default:break;
				}
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (busAsciiClient != null)
			{
				busAsciiClient.IsStringReverse = checkBox3.Checked;
			}
		}
		

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			// 连接
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}


			if(!byte.TryParse(textBox15.Text,out byte station))
			{
				MessageBox.Show( "Station input is wrong！" );
				return;
			}

			busAsciiClient?.ConnectClose( );
			busAsciiClient = new ModbusAsciiOverTcp( textBox1.Text, port, station );
			busAsciiClient.AddressStartWithZero = checkBox1.Checked;
			busAsciiClient.LogNet = LogNet;


			ComboBox1_SelectedIndexChanged( null, new EventArgs( ) );  // 设置数据服务
			busAsciiClient.IsStringReverse = checkBox3.Checked;

			try
			{
				OperateResult connect = busAsciiClient.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置子控件的读取能力
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( busAsciiClient, "100", false );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( busAsciiClient, "100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busAsciiClient.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => busAsciiClient.ReadFromCoreServer( ModbusInfo.TransModbusCoreToAsciiPackCommand( m ), true, false ), "Modbus Core", "example: 01 03 00 00 00 01" );

					control.SetDevice( busAsciiClient, "100" );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			busAsciiClient.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );

			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );

			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlAddressStartWithZero ).Value );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			checkBox3.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlStringReverse ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
