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
				DemoUtils.ShowMessage( "端口输入格式不正确！" );
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
					DemoUtils.ShowMessage( StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
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

			textBox_code.Text = $"OperateResult<string> read = keyence.ReadCustomer( \"{textBox3.Text}\" );   // 自定义命令";
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
			DemoUtils.ReadResultRender( keyence.ReadBarcode( ), "ReadBarcode", textBox4 );
			textBox_code.Text = "OperateResult<string> read = keyence.ReadBarcode( );   // 读取条码信息";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.Reset( ) );
			textBox_code.Text = "OperateResult result = keyence.Reset( );  // 复位命令";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.OpenIndicator( ) );
			textBox_code.Text = "OperateResult result = keyence.OpenIndicator( );  // 打开指示灯";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.CloseIndicator( ) );
			textBox_code.Text = "OperateResult result = keyence.CloseIndicator( );  // 关闭指示灯";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadVersion( ), "ReadVersion", textBox4 );
			textBox_code.Text = "OperateResult<string> read = keyence.ReadVersion( );   // 读取版本号";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadCommandState( ), "ReadCommandState", textBox4 );
			textBox_code.Text = "OperateResult<string> read = keyence.ReadCommandState( );   // 读取命令状态，none:不处理；wait：等待设置反映；update：正在更新";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadErrorState( ), "ReadErrorState", textBox4 );
			textBox_code.Text = "OperateResult<string> read = keyence.ReadErrorState( );   // 读取错误状态";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			DemoUtils.ReadResultRender( keyence.ReadRecord( ), "ReadRecord", textBox4 );
			textBox_code.Text = "OperateResult<int[]> read = keyence.ReadRecord( );   // 读取扫码器的扫码记录，返回数组数据，分别是成功次数，失败次数，ERROR次数，稳定次数，时机输入次数";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.Lock( ) );
			textBox_code.Text = "OperateResult result = keyence.Lock( );  // 锁定扫码设备";
		}

		private void button12_Click( object sender, EventArgs e )
		{
			DemoUtils.WriteResultRender( keyence.UnLock( ) );
			textBox_code.Text = "OperateResult result = keyence.UnLock( );  // 解除锁定扫码设备";
		}
	}
	
}
