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
using HslCommunication.Robot.KUKA;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormKukaTcp : HslFormContent
	{
		public FormKukaTcp( )
		{
			InitializeComponent( );
		}


		private KukaTcpNet kuka = null;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			
			Language( Program.Language );

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Kuka Robot Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "address:";
				label7.Text = "result:";

				button_read_string.Text = "r-string";


				label10.Text = "Address:";
				label9.Text = "Value:";

				button14.Text = "w-string";

				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
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
			
			kuka?.ConnectClose( );
			kuka = new KukaTcpNet( textBox1.Text, port );

			try
			{
				OperateResult connect = await kuka.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					// 设置代码示例
					codeExampleControl.SetCodeText( "robot", kuka );
					textBox_code.Text = $"KukaTcpNet kuka = new KukaTcpNet( \"{textBox1.Text}\", {port} );";
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

		private async void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			await kuka.ConnectCloseAsync( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 单数据读取测试
		

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			DemoUtils.ReadResultRender( await kuka.ReadStringAsync( textBox3.Text ), textBox3.Text, textBox4 );
			textBox_code.Text = $"OperateResult<string> read = kuka.ReadString( \"{textBox3.Text}\" )";
		}


		#endregion

		#region 单数据写入测试
		

		private async void button14_Click( object sender, EventArgs e )
		{
			// string写入
			try
			{
				DemoUtils.WriteResultRender( await kuka.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
			textBox_code.Text = $"OperateResult write = kuka.Write( \"{textBox8.Text}\", \"{textBox7.Text}\" )";
		}

		#endregion

		private async void button3_Click( object sender, EventArgs e )
		{
			// 启动程序
			OperateResult result = await kuka.StartProgramAsync( textBox5.Text );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Start Success" );
			}
			else
			{
				MessageBox.Show( "Start Failed:" + result.Message );
			}

			textBox_code.Text = $"OperateResult result = kuka.StartProgram( \"{textBox5.Text}\" );";
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			// 复位程序
			OperateResult result = await kuka.ResetProgramAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Reset Success" );
			}
			else
			{
				MessageBox.Show( "Reset Failed:" + result.Message );
			}

			textBox_code.Text = $"OperateResult result = kuka.ResetProgram( );";
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 停止程序
			OperateResult result = await kuka.StopProgramAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Reset Success" );
			}
			else
			{
				MessageBox.Show( "Reset Failed:" + result.Message );
			}

			textBox_code.Text = $"OperateResult result = kuka.StopProgram( );";
		}



		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
	
}
