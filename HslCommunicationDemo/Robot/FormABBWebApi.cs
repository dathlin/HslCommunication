using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Robot
{
	public partial class FormABBWebApi : HslFormContent
	{
		public FormABBWebApi( )
		{
			InitializeComponent( );
		}

		private ABBWebApiClient webApiClient;
		private CodeExampleControl codeExampleControl;


		private void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				webApiClient = new ABBWebApiClient( textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text );
				panel2.Enabled = true;
				button_close.Enabled = true;
				button_open.Enabled = false;


				// 设置示例代码
				codeExampleControl.SetCodeText( webApiClient );
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
			}
		}

		private void button_close_Click( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button_close.Enabled = false;
			button_open.Enabled = true;
		}

		private async void Button2_Click( object sender, EventArgs e )
		{
			if(comboBox1.SelectedIndex == 0)
			{
				OperateResult<string> read = await webApiClient.ReadStringAsync( textBox5.Text );
				if (read.IsSuccess)
				{
					textBox6.Text = read.Content;
					webBrowser1.DocumentText = read.Content;
				}
				else
				{
					MessageBox.Show( "Read Failed:" + read.Message );
				}
			}
			else
			{
				OperateResult write = await webApiClient.WriteAsync( textBox5.Text, textBox7.Text );
				if (write.IsSuccess)
				{
					MessageBox.Show( "Write Success" );
				}
				else
				{
					MessageBox.Show( "Read Failed:" + write.Message );
				}
			}
		}

		private void FormABBWebApi_Load( object sender, EventArgs e )
		{
			button_close.Enabled = false;
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton2_CheckedChanged;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private void RadioButton2_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton2.Checked)
			{
				textBox_web_text.Visible = false;
				webBrowser1.Visible = true;
			}
		}

		private void RadioButton1_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton1.Checked)
			{
				textBox_web_text.Visible = true;
				webBrowser1.Visible = false;
			}
		}

		private async Task RenderWebUrl( string url, bool get = true )
		{
			textBox_url_read.Text = url;
			DateTime start = DateTime.Now;
			OperateResult<string> read_web = await webApiClient.ReadStringAsync( textBox_url_read.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (read_web.IsSuccess)
			{
				textBox_web_text.Text = read_web.Content;
				webBrowser1.DocumentText = read_web.Content;
			}
		}

		private async void Button3_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetErrorStateAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/motionsystem/errorstate" );
			}
		}

		private async void Button4_Click( object sender, EventArgs e )
		{
			string unit = string.IsNullOrEmpty( textBox_mechunit.Text ) ? "ROB_1" : textBox_mechunit.Text;
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetJointTargetAsync( unit );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( $"url=/rw/motionsystem/mechunits/{unit}/jointtarget" );
			}
		}

		private async void Button5_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetSpeedRatioAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/speedratio" );
			}
		}

		private async void Button6_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetOperationModeAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/opmode" );
			}
		}

		private async void Button7_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetCtrlStateAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/ctrlstate" );
			}
		}

		private async void Button8_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIOInAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/D652_10" );
			}
		}

		private async void Button9_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIOOutAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/D652_10" );
			}
		}

		private async void Button11_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIO2InAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/BK5250" );
			}
		}

		private async void Button10_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIO2OutAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/BK5250" );
			}
		}

		private async void button_io_signal_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetAnIOSignalAsync( textBox_io_network.Text, textBox_io_unit.Text, textBox_io_signal.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( $"url=/rw/iosystem/signals/{textBox_io_network.Text}/{textBox_io_unit.Text}/{textBox_io_signal.Text}" );
			}
		}

		private async void Button12_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetLogAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/elog/0?lang=zh&amp;resource=title" );
			}
		}

		private async void button13_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetSystemAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/system" );
			}
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRobotTargetAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/motionsystem/mechunits/ROB_1/robtarget" );
			}
		}

		private async void button15_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetServoEnableAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/signals/Local/DRV_1/DRV1K1" );
			}
		}

		private async void button16_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRapidExecutionAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/rapid/execution" );
			}
		}

		private async void button17_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRapidTasksAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/rapid/tasks" );
			}
		}

		private async void button18_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<double[]> read = webApiClient.GetUserValue( textBox_user_value_name.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content.ToJsonString( );

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( textBox_user_value_name.Text.StartsWith( "url=", StringComparison.OrdinalIgnoreCase ) ? 
					textBox_user_value_name.Text : "url=/rw/rapid/symbol/data/RAPID/T_ROB1/user/" + textBox_user_value_name.Text );
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox4.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox4.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
