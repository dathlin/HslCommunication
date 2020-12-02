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
using HslCommunication.Profinet.LSIS;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormLsisFEnetV2 : HslFormContent
	{
		public FormLsisFEnetV2( )
		{
			InitializeComponent( );
			fastEnet = new XGBFastEnetV2( );
		}


		private XGBFastEnetV2 fastEnet = null;

		

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			Language( Program.Language );

			cboxModel.DataSource = Enum.GetNames( typeof( LSCpuInfo ) );
			cboxCompanyID.SelectedIndex = 0;
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Lsis Read PLC Demo";
			   

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";

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
			// 连接
			if (!System.Net.IPAddress.TryParse( textBox1.Text, out System.Net.IPAddress address ))
			{
				MessageBox.Show( DemoUtils.IpAddressInputWrong );
				return;
			}

			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if(!byte.TryParse(textBox12.Text, out byte slot ))
			{
				MessageBox.Show( DemoUtils.SlotInputWrong );
				return;
			}

			fastEnet.IpAddress = textBox1.Text;
			fastEnet.Port = port;
			fastEnet.SlotNo = slot;
			fastEnet.SetCpuType = cboxModel.Text;
			fastEnet.CompanyID = cboxCompanyID.Text;

			try
			{
				OperateResult connect = fastEnet.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					userControlReadWriteOp1.SetReadWriteNet( fastEnet, "MB100", true );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
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
			fastEnet.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			DemoUtils.BulkReadRenderResult( fastEnet, textBox6, textBox9, textBox10 );
		}



		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
				OperateResult<byte[]> read = fastEnet.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCpuType, cboxModel.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, cboxCompanyID.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox12.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			cboxModel.Text = element.Attribute( DemoDeviceList.XmlCpuType ).Value;
			cboxCompanyID.Text = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox12.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
