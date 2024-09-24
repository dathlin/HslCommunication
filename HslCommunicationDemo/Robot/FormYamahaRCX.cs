using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.YAMAHA;
using HslCommunication;
using HslCommunication.BasicFramework;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Robot
{
	public partial class FormYamahaRCX : HslFormContent
	{
		public FormYamahaRCX( )
		{
			InitializeComponent( );
		}

		private YamahaRCX yamahaRCX;
		private CodeExampleControl codeExampleControl;

		private async void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				// 连接
				yamahaRCX = new YamahaRCX( textBox1.Text, int.Parse( textBox2.Text ) );
				yamahaRCX.ConnectTimeOut = 2000;
				yamahaRCX.LogNet = this.LogNet;                                                // 设置之后支持界面显示日志信息

				button1.Enabled = false;
				OperateResult connect = await yamahaRCX.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					// 设置代码示例
					codeExampleControl.SetCodeText( "yamahaRCX", yamahaRCX );
				}
				else
				{
					button1.Enabled = true;
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void FormABBWebApi_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			yamahaRCX?.ConnectClose( );
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult reset = yamahaRCX.Reset( );
			if (reset.IsSuccess)
			{
				MessageBox.Show( "Reset success" );
			}
			else
			{
				MessageBox.Show( "Reset Faield:" + reset.Message );
			}

			textBox_code.Text = $"OperateResult reset = yamahaRCX.Reset( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult reset = yamahaRCX.Run( );
			if (reset.IsSuccess)
			{
				MessageBox.Show( "Run success" );
			}
			else
			{
				MessageBox.Show( "Run Faield:" + reset.Message );
			}

			textBox_code.Text = $"OperateResult run = yamahaRCX.Run( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult reset = yamahaRCX.Stop( );
			if (reset.IsSuccess)
			{
				MessageBox.Show( "Stop success" );
			}
			else
			{
				MessageBox.Show( "Stop Faield:" + reset.Message );
			}

			textBox_code.Text = $"OperateResult stop = yamahaRCX.Stop( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			OperateResult<int> motor = yamahaRCX.ReadMotorStatus( );
			if (motor.IsSuccess)
			{
				if (motor.Content == 0) textBox_result.Text = "0 -> 马达电源关闭;";
				else if(motor.Content == 1) textBox_result.Text = "1 -> 马达电源开启;";
				else if (motor.Content == 2) textBox_result.Text = "2 -> 马达电源开启＋所有机器人伺服开启";
				else textBox_result.Text = motor.Content + " -> 未知的状态";
			}
			else
			{
				MessageBox.Show( "Read Faield:" + motor.Message );
			}

			textBox_code.Text = $"OperateResult<int> motor = yamahaRCX.ReadMotorStatus( );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<int> mode = yamahaRCX.ReadModeStatus( );
			if (mode.IsSuccess)
			{
				textBox_result.Text = mode.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Faield:" + mode.Message );
			}

			textBox_code.Text = $"OperateResult<int> mode = yamahaRCX.ReadModeStatus( );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			OperateResult<float[]> joints = yamahaRCX.ReadJoints( );
			if (joints.IsSuccess)
			{
				textBox_result.Text = SoftBasic.ArrayFormat( joints );
			}
			else
			{
				MessageBox.Show( "Read Faield:" + joints.Message );
			}

			textBox_code.Text = $"OperateResult<float[]> joints = yamahaRCX.ReadJoints( );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			OperateResult<int> emergency = yamahaRCX.ReadEmergencyStatus( );
			if (emergency.IsSuccess)
			{
				if (emergency.Content == 0) textBox_result.Text = "0 -> 正常状态;";
				else if (emergency.Content == 1) textBox_result.Text = "1 -> 紧急停止状态;";
				else textBox_result.Text = emergency.Content + " -> 未知的状态";
			}
			else
			{
				MessageBox.Show( "Read Faield:" + emergency.Message );
			}

			textBox_code.Text = $"OperateResult<int> emergency = yamahaRCX.ReadEmergencyStatus( );";
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

		private void button_execute_Click( object sender, EventArgs e )
		{
			// 自定义的命令
			if (!int.TryParse(textBox_read_lines.Text, out int lines ))
			{
				MessageBox.Show( "Lines input wrong!" );
				return;
			}
			OperateResult<string[]> read = yamahaRCX.ReadCommand( textBox_read_command.Text, lines );
			if (read.IsSuccess)
			{
				textBox_result.Lines = read.Content;
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string[]> read = yamahaRCX.ReadCommand( \"{textBox_read_command.Text}\", {lines} );";
		}

		private void RenderJogResult( OperateResult result, string jog )
		{
			if (result.IsSuccess)
			{
				textBox_result.AppendText( DateTime.Now.ToString( ) + " " + jog + " Success" + Environment.NewLine );
			}
			else
			{
				MessageBox.Show( jog + " failed: " + result.Message );
			}
		}

		private void button10_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -1 ), "JOG 1-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -1 );";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 1 ), "JOG 1+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 1 );";
		}

		private void button13_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -2 ), "JOG 2-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -2 );";
		}

		private void button12_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 2 ), "JOG 2+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 2 );";
		}

		private void button15_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -3 ), "JOG 3-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -3 );";
		}

		private void button14_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 3 ), "JOG 3+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 3 );";
		}

		private void button17_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -4 ), "JOG 4-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -4 );";
		}

		private void button16_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 4 ), "JOG 4+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 4 );";
		}

		private void button19_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -5 ), "JOG 5-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -5 );";
		}

		private void button18_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 5 ), "JOG 5+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 5 );";
		}

		private void button21_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( -6 ), "JOG 6-" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( -6 );";
		}

		private void button20_Click( object sender, EventArgs e )
		{
			RenderJogResult( yamahaRCX.JogXY( 6 ), "JOG 6+" );

			textBox_code.Text = $"OperateResult result = yamahaRCX.JogXY( 6 );";
		}
	}
}
