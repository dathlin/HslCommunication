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
using System.Threading;
using HslCommunication.Profinet.Inovance;
using System.Xml.Linq;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.PLC.Common;

namespace HslCommunicationDemo
{
	public partial class FormInovanceTcpNet : HslFormContent
	{
		public FormInovanceTcpNet( )
		{
			InitializeComponent( );
		}


		private InovanceTcpNet inovanceH3UTcp = null;
		private SpecialFeaturesControl control;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.SelectedIndex = 2;
			comboBox4.DataSource = SoftBasic.GetEnumValues<InovanceSeries>( );
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

			Language( Program.Language );
			control = new SpecialFeaturesControl( );
			this.userControlReadWriteDevice1.AddSpecialFunctionTab( control );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "InovanceTcp Read Demo";

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
			if (inovanceH3UTcp != null)
			{
				switch (comboBox1.SelectedIndex)
				{
					case 0: inovanceH3UTcp.DataFormat = HslCommunication.Core.DataFormat.ABCD;break;
					case 1: inovanceH3UTcp.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: inovanceH3UTcp.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: inovanceH3UTcp.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default:break;
				}
			}
		}

		private void CheckBox3_CheckedChanged( object sender, EventArgs e )
		{
			if (inovanceH3UTcp != null)
			{
				inovanceH3UTcp.IsStringReverse = checkBox3.Checked;
			}
		}
		

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
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

			inovanceH3UTcp?.ConnectClose( );
			inovanceH3UTcp = new InovanceTcpNet( textBox1.Text, port, station );
			inovanceH3UTcp.AddressStartWithZero = checkBox1.Checked;
			inovanceH3UTcp.Series = (InovanceSeries)comboBox4.SelectedItem;

			ComboBox1_SelectedIndexChanged( null, new EventArgs( ) );  // 设置数据服务
			inovanceH3UTcp.IsStringReverse = checkBox3.Checked;
			inovanceH3UTcp.LogNet = LogNet;

			try
			{
				OperateResult connect = inovanceH3UTcp.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled  = true;

					// 设置基本的读写信息
					userControlReadWriteDevice1.ReadWriteOp.SetReadWriteNet( inovanceH3UTcp, "D100", true );
					// 设置批量读取
					userControlReadWriteDevice1.BatchRead.SetReadWriteNet( inovanceH3UTcp, "D100", string.Empty );
					// 设置报文读取
					userControlReadWriteDevice1.MessageRead.SetReadSourceBytes( m => inovanceH3UTcp.ReadFromCoreServer( m, true, false ), string.Empty, string.Empty );

					control.SetDevice( inovanceH3UTcp, "D100" );
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
			inovanceH3UTcp.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox15.Text );
			element.SetAttributeValue( DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( DemoDeviceList.XmlStringReverse, checkBox3.Checked );
			element.SetAttributeValue( nameof( InovanceSeries ), (InovanceSeries)comboBox4.SelectedItem );
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
			if (element.Attribute( nameof( InovanceSeries ) ) != null)
				comboBox4.SelectedItem = SoftBasic.GetEnumFromString<InovanceSeries>( element.Attribute( nameof( InovanceSeries ) ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
