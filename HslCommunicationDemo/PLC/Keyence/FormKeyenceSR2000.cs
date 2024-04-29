using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Keyence;
using System.Threading;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceSR2000 : HslFormContent
	{
		public FormKeyenceSR2000( )
		{
			InitializeComponent( );
		}


		private KeyenceSR2000SeriesTcp keyence = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			panel2.Enabled = false;
			
			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence SR2000 Code Reader Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label6.Text = "address:";
				label7.Text = "result:";

				button_read_string.Text = "r-string";


				groupBox1.Text = "Single Data Read test";
				label22.Text = "";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( "端口输入格式不正确！" );
				return;
			}
			
			keyence?.ConnectClose( );
			keyence = new KeyenceSR2000SeriesTcp( textBox_ip.Text, port );
			keyence.LogNet = LogNet;
			try
			{
				OperateResult connect = await keyence.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( "连接成功！" );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
				}
				else
				{
					MessageBox.Show( "连接失败！" );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private async void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			await keyence.ConnectCloseAsync( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 单数据读取测试
		

		private void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			DemoUtils.ReadResultRender( keyence.ReadCustomer( textBox3.Text ), textBox3.Text, textBox4 );
		}


		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadBarcode(), "ReadBarcode", textBox4 );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.Reset( ) );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.OpenIndicator( ) );
		}

		private void button6_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.CloseIndicator( ) );
		}

		private void button7_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadVersion( ), "ReadVersion", textBox4 );
		}

		private void button8_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadCommandState( ), "ReadCommandState", textBox4 );
		}

		private void button9_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadErrorState( ), "ReadErrorState", textBox4 );
		}

		private void button10_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadRecord( ), "ReadRecord", textBox4 );
		}

		private void button11_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.Lock( ) );
		}

		private void button12_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.UnLock( ) );
		}
	}
	
}
