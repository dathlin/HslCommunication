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

namespace HslCommunicationDemo.Robot
{
	public partial class FormYamahaRCX : HslFormContent
	{
		public FormYamahaRCX( )
		{
			InitializeComponent( );
		}

		private YamahaRCX yamahaRCX;

		private async void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				// 连接
				yamahaRCX = new YamahaRCX( textBox1.Text, int.Parse( textBox2.Text ) );
				yamahaRCX.ConnectTimeOut = 2000;

				button1.Enabled = false;
				OperateResult connect = await yamahaRCX.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( "连接成功" );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				else
				{
					button1.Enabled = true;
					MessageBox.Show( "连接失败" );
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
		}

		private void button6_Click( object sender, EventArgs e )
		{
			OperateResult<int> motor = yamahaRCX.ReadMotorStatus( );
			if (motor.IsSuccess)
			{
				if (motor.Content == 0) textBox6.Text = "0 -> 马达电源关闭;";
				else if(motor.Content == 1) textBox6.Text = "1 -> 马达电源开启;";
				else if (motor.Content == 2) textBox6.Text = "2 -> 马达电源开启＋所有机器人伺服开启";
				else textBox6.Text = motor.Content + " -> 未知的状态";
			}
			else
			{
				MessageBox.Show( "Read Faield:" + motor.Message );
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<int> mode = yamahaRCX.ReadModeStatus( );
			if (mode.IsSuccess)
			{
				textBox6.Text = mode.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Faield:" + mode.Message );
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			OperateResult<float[]> joints = yamahaRCX.ReadJoints( );
			if (joints.IsSuccess)
			{
				textBox6.Text = SoftBasic.ArrayFormat( joints );
			}
			else
			{
				MessageBox.Show( "Read Faield:" + joints.Message );
			}
		}

		private void button9_Click( object sender, EventArgs e )
		{
			OperateResult<int> emergency = yamahaRCX.ReadEmergencyStatus( );
			if (emergency.IsSuccess)
			{
				if (emergency.Content == 0) textBox6.Text = "0 -> 正常状态;";
				else if (emergency.Content == 1) textBox6.Text = "1 -> 紧急停止状态;";
				else textBox6.Text = emergency.Content + " -> 未知的状态";
			}
			else
			{
				MessageBox.Show( "Read Faield:" + emergency.Message );
			}
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
