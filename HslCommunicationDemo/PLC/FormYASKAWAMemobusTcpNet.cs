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
using HslCommunication;
using HslCommunication.Profinet.YASKAWA;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormYASKAWAMemobusTcpNet : HslFormContent
	{
		public FormYASKAWAMemobusTcpNet( )
		{
			InitializeComponent( );
			// omronHostLink.LogNet = new HslCommunication.LogNet.LogNetSingle( "omron.log.txt" );
		}


		private MemobusTcpNet memobus = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>( );
			comboBox1.SelectedItem = HslCommunication.Core.DataFormat.CDAB;
			panel2.Enabled = false;

			Language( Program.Language );

		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Yaskawa Read PLC Demo";

				label1.Text = "Station:";
				button1.Text = "Open";
				button2.Text = "Close";
				label29.Text = "Ip:";
				label28.Text = "Port:";

				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";

				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		
		#region Connect And Close


		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox19.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if (!byte.TryParse( textBox_cpu_from.Text, out byte cpuFrom ))
			{
				MessageBox.Show( "PLC cpuFrom input wrong！" );
				return;
			}

			if (!byte.TryParse ( textBox_cpu_to.Text, out byte cpuTo ))
			{
				MessageBox.Show( "PLC cpuTo input wrong！" );
				return;
			}

			memobus?.ConnectClose( );
			memobus = new MemobusTcpNet( );
			memobus.IpAddress = textBox20.Text;
			memobus.Port = port;
			memobus.CpuFrom = cpuFrom;
			memobus.CpuTo = cpuTo;
			memobus.LogNet = LogNet;

			try
			{
				memobus.ByteTransform.DataFormat = (HslCommunication.Core.DataFormat)comboBox1.SelectedItem;

				OperateResult connect = memobus.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );

					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteOp1.SetReadWriteNet( memobus, "100", true );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.Message );
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
			memobus.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}
		
		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( memobus, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = memobus.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}


		#endregion
		
		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox20.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox19.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex );
			element.SetAttributeValue( "cpu_from", textBox_cpu_from.Text );
			element.SetAttributeValue( "cpu_to", textBox_cpu_to.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox20.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox19.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlDataFormat ).Value );
			textBox_cpu_from.Text = element.Attribute( "cpu_from" ).Value;
			textBox_cpu_to.Text = element.Attribute( "cpu_to" ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
