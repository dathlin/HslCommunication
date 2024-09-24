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
using HslCommunication.Robot.YASKAWA;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormYRCHighEthernet : HslFormContent
	{
		public FormYRCHighEthernet( )
		{
			InitializeComponent( );
		}


		private YRCHighEthernet yrc = null;
		private CodeExampleControl codeExampleControl;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.DataSource = new string[] { "基坐标", "机器坐标", "用户1", "用户2", "用户3", "用户4", "用户5", "用户6", "用户7", "用户8", "用户9", "用户10" };
			comboBox1.SelectedIndex = 0;
			Language( Program.Language );


			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "YASKAWA Robot Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label7.Text = "result:";


				label10.Text = "Address:";
				label9.Text = "Value:";

				tabPage1.Text = "Single Data Read test";
				tabPage2.Text = "Single Data Write test";
				label22.Text = "Parameter name of robot";

				label_code.Text = "Code:";
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
				MessageBox.Show( "端口输入格式不正确！" );
				return;
			}
			
			yrc = new YRCHighEthernet( textBox1.Text, port );
			yrc.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
			//YRC1000Tcp.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

			try
			{
				MessageBox.Show( "打开UDP成功！" );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "robot", yrc );
				textBox_code.Text = $"YRCHighEthernet yrc = new YRCHighEthernet( \"{textBox1.Text}\", {port} );";
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 textBox4.AppendText( e.HslMessage.ToString( ) );
			 } ) );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}


		#endregion

		#region XML Setting

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

		#endregion

		#region ButtonClick

		private void button14_Click( object sender, EventArgs e )
		{
			OperateResult<int> command = DemoUtils.ParseInt( textBox_command.Text );
			if (!command.IsSuccess)
			{
				MessageBox.Show( "Command input wrong: " + command.Message );
				return;
			}

			OperateResult<int> dataAddress = DemoUtils.ParseInt( textBox_dataAddress.Text );
			if (!dataAddress.IsSuccess)
			{
				MessageBox.Show( "Data Address input wrong: " + dataAddress.Message );
				return;
			}

			OperateResult<int> dataAttribute = DemoUtils.ParseInt( textBox_dataAttribute.Text );
			if (!dataAttribute.IsSuccess)
			{
				MessageBox.Show( "单元编号输入错误:" + dataAttribute.Message );
				return;
			}

			OperateResult<int> handle = DemoUtils.ParseInt( textBox_dataHandle.Text );
			if (!handle.IsSuccess)
			{
				MessageBox.Show( "处理请求输入错误:" + dataAttribute.Message );
				return;
			}

			byte[] dataPart = string.IsNullOrEmpty( textBox_dataPart.Text ) ? new byte[0] : textBox_dataPart.Text.ToHexBytes( );
			OperateResult<byte[]> read = yrc.ReadCommand( (ushort)command.Content, (ushort)dataAddress.Content, (byte)dataAttribute.Content, (byte)handle.Content, dataPart );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read failed: " + read.Message );
				return;
			}

			if (radioButton1.Checked)
			{
				textBox7.Text = read.Content.ToHexString( );
			}
			else
			{
				textBox7.Text = HslCommunication.BasicFramework.SoftBasic.GetAsciiStringRender( read.Content );
			}

			textBox_code2.Text = $"OperateResult<byte[]> read = yrc.ReadCommand( {command.Content}, {dataAddress.Content}, {dataAttribute.Content}, {handle.Content}, \"{textBox_dataPart.Text}\".ToHexBytes( ) );";
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 报警信息
			OperateResult<YRCAlarmItem[]> read = yrc.ReadAlarms( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<YRCAlarmItem[]> read = yrc.ReadAlarms( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 关节坐标
			OperateResult<string[]> read = yrc.ReadPose( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string[]> read = yrc.ReadPose( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 姿态坐标
			OperateResult<YRCRobotData> read = yrc.ReadPOSC( comboBox1.SelectedIndex, true );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<YRCRobotData> read = yrc.ReadPOSC( {comboBox1.SelectedIndex}, true );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 状态读取
			OperateResult<bool[]> read = yrc.ReadStats( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine +
					"[ 0] 单步              " + read.Content[0] + Environment.NewLine +
					"[ 1] 1循环             " + read.Content[1] + Environment.NewLine +
					"[ 2] 自动连续          " + read.Content[2] + Environment.NewLine +
					"[ 3] 运行中            " + read.Content[3] + Environment.NewLine +
					"[ 4] 运转中            " + read.Content[4] + Environment.NewLine +
					"[ 5] 示教              " + read.Content[5] + Environment.NewLine +
					"[ 6] 在线              " + read.Content[6] + Environment.NewLine +
					"[ 7] 命令模式          " + read.Content[7] + Environment.NewLine +
					"[ 9] 示教编程器HOLD中   " + read.Content[9] + Environment.NewLine +
					"[10] 外部HOLD中        " + read.Content[10] + Environment.NewLine +
					"[11] 命令HOLD中        " + read.Content[11] + Environment.NewLine +
					"[12] 发生警报          " + read.Content[12] + Environment.NewLine +
					"[13] 发生错误          " + read.Content[13] + Environment.NewLine +
					"[14] 伺服ON            " + read.Content[14] + Environment.NewLine;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<bool[]> read = yrc.ReadStats( );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 程序名读取
			OperateResult<string[]> read = yrc.ReadJSeq( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine +
					"[0]程序名: "     + read.Content[0] + Environment.NewLine +
					"[1]行编号: "     + read.Content[1] + Environment.NewLine +
					"[2]步编号: "     + read.Content[2] + Environment.NewLine +
					"[3]速度超出值: " + read.Content[3] + Environment.NewLine;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string[]> read = yrc.ReadJSeq( );"; 
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 字节变量读取
			DemoUtils.ReadResultRender( yrc.ReadByteVariable( ushort.Parse( textBox5.Text ) ), textBox5.Text, textBox4 );

			textBox_code.Text = $"OperateResult<byte> read = yrc.ReadByteVariable( ushort.Parse( \"{textBox5.Text}\" ) )";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 整型读取
			DemoUtils.ReadResultRender( yrc.ReadIntegerVariable( ushort.Parse( textBox5.Text ) ), textBox5.Text, textBox4 );

			textBox_code.Text = $"OperateResult<short> read = yrc.ReadIntegerVariable( ushort.Parse( \"{textBox5.Text}\" ) )";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// 双整形读取
			DemoUtils.ReadResultRender( yrc.ReadDoubleIntegerVariable( ushort.Parse( textBox5.Text ) ), textBox5.Text, textBox4 );

			textBox_code.Text = $"OperateResult<int> read = yrc.ReadDoubleIntegerVariable( ushort.Parse( \"{textBox5.Text}\" ) )";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 实数读取
			DemoUtils.ReadResultRender( yrc.ReadRealVariable( ushort.Parse( textBox5.Text ) ), textBox5.Text, textBox4 );

			textBox_code.Text = $"OperateResult<float> read = yrc.ReadRealVariable( ushort.Parse( \"{textBox5.Text}\" ) )";
		}

		private void button12_Click( object sender, EventArgs e )
		{
			// 字符串读取
			DemoUtils.ReadResultRender( yrc.ReadStringVariable( ushort.Parse( textBox5.Text ) ), textBox5.Text, textBox4 );

			textBox_code.Text = $"OperateResult<string> read = yrc.ReadStringVariable( ushort.Parse( \"{textBox5.Text}\" ) )";
		}

		private void button19_Click( object sender, EventArgs e )
		{
			// 字符串写入
			DemoUtils.WriteResultRender( yrc.WriteStringVariable( ushort.Parse( textBox3.Text ), textBox6.Text ), textBox3.Text );

			textBox_code.Text = $"OperateResult write = yrc.WriteStringVariable( ushort.Parse( \"{textBox3.Text}\" ), \"{textBox6.Text}\" )";
		}

		private void button20_Click( object sender, EventArgs e )
		{
			// 整形写入
			try
			{
				DemoUtils.WriteResultRender( yrc.WriteIntegerVariable( ushort.Parse( textBox3.Text ), short.Parse( textBox6.Text ) ), textBox3.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Write Failed: " + ex.Message );
			}

			textBox_code.Text = $"OperateResult write = yrc.WriteIntegerVariable( ushort.Parse( \"{textBox3.Text}\" ), short.Parse( \"{textBox6.Text}\" ) )";
		}

		private void button26_Click( object sender, EventArgs e )
		{
			// 双整型写入
			try
			{
				DemoUtils.WriteResultRender( yrc.WriteDoubleIntegerVariable( ushort.Parse( textBox3.Text ), int.Parse( textBox6.Text ) ), textBox3.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Write Failed: " + ex.Message );
			}

			textBox_code.Text = $"OperateResult write = yrc.WriteDoubleIntegerVariable( ushort.Parse( \"{textBox3.Text}\" ), int.Parse( \"{textBox6.Text}\" ) )";
		}

		private void button27_Click( object sender, EventArgs e )
		{
			// 实数写入
			try
			{
				DemoUtils.WriteResultRender( yrc.WriteRealVariable( ushort.Parse( textBox3.Text ), float.Parse( textBox6.Text ) ), textBox3.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Write Failed: " + ex.Message );
			}

			textBox_code.Text = $"OperateResult write = yrc.WriteRealVariable( ushort.Parse( \"{textBox3.Text}\" ), float.Parse( \"{textBox6.Text}\" ) )";
		}

		private void button28_Click( object sender, EventArgs e )
		{
			// 字节写入
			try
			{
				DemoUtils.WriteResultRender( yrc.WriteByteVariable( ushort.Parse( textBox3.Text ), byte.Parse( textBox6.Text ) ), textBox3.Text );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Write Failed: " + ex.Message );
			}

			textBox_code.Text = $"OperateResult write = yrc.WriteByteVariable( ushort.Parse( \"{textBox3.Text}\" ), byte.Parse( \"{textBox6.Text}\" ) )";
		}

		private void button13_Click( object sender, EventArgs e )
		{
			// HOLD ON
			OperateResult op = yrc.Hold( true );
			if (op.IsSuccess)
			{
				MessageBox.Show( "HOLD ON Success" );
			}
			else
			{
				MessageBox.Show( "HOLD ON Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Hold( true );";
		}

		private void button15_Click( object sender, EventArgs e )
		{
			// HOLD OFF
			OperateResult op = yrc.Hold( false );
			if (op.IsSuccess)
			{
				MessageBox.Show( "HOLD OFF Success" );
			}
			else
			{
				MessageBox.Show( "HOLD OFF Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Hold( false );";
		}

		private void button16_Click( object sender, EventArgs e )
		{
			// RESET
			OperateResult op = yrc.Reset( );
			if (op.IsSuccess)
			{
				MessageBox.Show( "RESET Success" );
			}
			else
			{
				MessageBox.Show( "RESET Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Reset( );";
		}

		private void button17_Click( object sender, EventArgs e )
		{
			// Cancel
			OperateResult op = yrc.Cancel( );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Cancel Success" );
			}
			else
			{
				MessageBox.Show( "Cancel Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Cancel( );";
		}

		private void button21_Click( object sender, EventArgs e )
		{
			// SVON ON
			OperateResult op = yrc.Svon( true );
			if (op.IsSuccess)
			{
				MessageBox.Show( "SVON ON Success" );
			}
			else
			{
				MessageBox.Show( "SVON ON Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Svon( true );";
		}

		private void button22_Click( object sender, EventArgs e )
		{
			// SVON OFF
			OperateResult op = yrc.Svon( false );
			if (op.IsSuccess)
			{
				MessageBox.Show( "SVON OFF Success" );
			}
			else
			{
				MessageBox.Show( "SVON OFF Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Svon( false );";
		}

		private void button18_Click( object sender, EventArgs e )
		{
			// 启动程序
			OperateResult op = yrc.Start( );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Start Success" );
			}
			else
			{
				MessageBox.Show( "Start Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = yrc.Start( );";
		}


		private void button23_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = yrc.ReadManagementTime( 1 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = yrc.ReadManagementTime( 1 );";
		}

		private void button24_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = yrc.ReadManagementTime( 10 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = yrc.ReadManagementTime( 10 );";
		}

		private void button25_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = yrc.ReadManagementTime( 210 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = yrc.ReadManagementTime( 210 );";
		}

		private void button32_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = yrc.ReadManagementTime( 110 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = yrc.ReadManagementTime( 110 );";
		}
		private void button31_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = yrc.ReadManagementTimeSpan( 1 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = yrc.ReadManagementTimeSpan( 1 );";
		}

		private void button30_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = yrc.ReadManagementTimeSpan( 10 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = yrc.ReadManagementTimeSpan( 10 );";
		}

		private void button29_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = yrc.ReadManagementTimeSpan( 210 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = yrc.ReadManagementTimeSpan( 210 );";
		}

		private void button33_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = yrc.ReadManagementTimeSpan( 110 );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = yrc.ReadManagementTimeSpan( 110 );";
		}
		#endregion



	}

}
