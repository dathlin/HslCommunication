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

namespace HslCommunicationDemo
{
	public partial class FormYRC1000 : HslFormContent
	{
		public FormYRC1000( )
		{
			InitializeComponent( );
		}


		private YRC1000TcpNet YRC1000Tcp = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.DataSource = new string[] { "基坐标", "机器坐标", "用户1", "用户2", "用户3", "用户4", "用户5", "用户6", "用户7", "用户8", "用户9", "用户10" };
			comboBox1.SelectedIndex = 0;
			Language( Program.Language );
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
				label6.Text = "address:";
				label7.Text = "result:";

				button_read_string.Text = "r-string";


				label10.Text = "Address:";
				label9.Text = "Value:";

				button14.Text = "w-string";

				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
				label22.Text = "Parameter name of robot";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
		}

		/// <summary>
		/// 统一的读取结果的数据解析，显示
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="result"></param>
		/// <param name="address"></param>
		/// <param name="textBox"></param>
		private void readResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
		{
			if (result.IsSuccess)
			{
				textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
			}
			else
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Read Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
			}
		}

		/// <summary>
		/// 统一的数据写入的结果显示
		/// </summary>
		/// <param name="result"></param>
		/// <param name="address"></param>
		private void writeResultRender( OperateResult result, string address )
		{
			if (result.IsSuccess)
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
			}
			else
			{
				MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
			}
		}


		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( "端口输入格式不正确！" );
				return;
			}
			
			YRC1000Tcp?.ConnectClose( );
			YRC1000Tcp = new YRC1000TcpNet( textBox1.Text, port );

			try
			{
				OperateResult connect = await YRC1000Tcp.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( "连接成功！" );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;

					textBox_code.Text = $"YRC1000TcpNet YRC1000Tcp = new YRC1000TcpNet( \"{textBox1.Text}\", {port} );";
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

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			YRC1000Tcp.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 单数据读取测试
		
		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			readResultRender( await YRC1000Tcp.ReadStringAsync( textBox3.Text ), textBox3.Text, textBox4 );

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadString( \"{textBox3.Text}\" )";
		}

		#endregion

		#region 单数据写入测试
		
		private async void button14_Click( object sender, EventArgs e )
		{
			// string写入
			try
			{
				writeResultRender( await YRC1000Tcp.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );

				textBox_code.Text = $"OperateResult write = YRC1000Tcp.Write( \"{textBox8.Text}\", \"{textBox7.Text}\" );";
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		#endregion


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

		private void button3_Click( object sender, EventArgs e )
		{
			// 报警信息
			OperateResult<string> read = YRC1000Tcp.ReadALARM( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadALARM( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 关节坐标
			OperateResult<string> read = YRC1000Tcp.ReadPOSJ( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadPOSJ( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 姿态坐标
			OperateResult<YRCRobotData> read = YRC1000Tcp.ReadPOSC( comboBox1.SelectedIndex, true );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<YRCRobotData> read = YRC1000Tcp.ReadPOSC( {comboBox1.SelectedIndex}, true );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 状态读取
			OperateResult<bool[]> read = YRC1000Tcp.ReadStats( );
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

			textBox_code.Text = $"OperateResult<bool[]> read = YRC1000Tcp.ReadStats( );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 程序名读取
			OperateResult<string> read = YRC1000Tcp.ReadJSeq( );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + "程序名，行编号，步编号: "  + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadJSeq( );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 字节变量读取
			OperateResult<string> read = YRC1000Tcp.ReadByteVariable( textBox5.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadByteVariable( \"{textBox5.Text}\" );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 整型读取
			OperateResult<string> read = YRC1000Tcp.ReadIntegerVariable( textBox5.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadIntegerVariable( \"{textBox5.Text}\" );";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// 双整型读取
			OperateResult<string> read = YRC1000Tcp.ReadDoubleIntegerVariable( textBox5.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadDoubleIntegerVariable( \"{textBox5.Text}\" );";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 实数读取
			OperateResult<string> read = YRC1000Tcp.ReadRealVariable( textBox5.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadRealVariable( \"{textBox5.Text}\" );";
		}

		private void button12_Click( object sender, EventArgs e )
		{
			// 字符串读取
			OperateResult<string> read = YRC1000Tcp.ReadStringVariable( textBox5.Text );
			if (read.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = YRC1000Tcp.ReadStringVariable( \"{textBox5.Text}\" );";
		}

		private void button13_Click( object sender, EventArgs e )
		{
			// HOLD ON
			OperateResult op = YRC1000Tcp.Hold( true );
			if (op.IsSuccess)
			{
				MessageBox.Show( "HOLD ON Success" );
			}
			else
			{
				MessageBox.Show( "HOLD ON Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Hold( true );";
		}

		private void button15_Click( object sender, EventArgs e )
		{
			// HOLD OFF
			OperateResult op = YRC1000Tcp.Hold( false );
			if (op.IsSuccess)
			{
				MessageBox.Show( "HOLD OFF Success" );
			}
			else
			{
				MessageBox.Show( "HOLD OFF Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Hold( false );";
		}

		private void button16_Click( object sender, EventArgs e )
		{
			// RESET
			OperateResult op = YRC1000Tcp.Reset( );
			if (op.IsSuccess)
			{
				MessageBox.Show( "RESET Success" );
			}
			else
			{
				MessageBox.Show( "RESET Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Reset( );";
		}

		private void button17_Click( object sender, EventArgs e )
		{
			// Cancel
			OperateResult op = YRC1000Tcp.Cancel( );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Cancel Success" );
			}
			else
			{
				MessageBox.Show( "Cancel Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Cancel( );";
		}

		private void button21_Click( object sender, EventArgs e )
		{
			// SVON ON
			OperateResult op = YRC1000Tcp.Svon( true );
			if (op.IsSuccess)
			{
				MessageBox.Show( "SVON ON Success" );
			}
			else
			{
				MessageBox.Show( "SVON ON Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Svon( true );";
		}

		private void button22_Click( object sender, EventArgs e )
		{
			// SVON OFF
			OperateResult op = YRC1000Tcp.Svon( false );
			if (op.IsSuccess)
			{
				MessageBox.Show( "SVON OFF Success" );
			}
			else
			{
				MessageBox.Show( "SVON OFF Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Svon( false );";
		}

		private void button18_Click( object sender, EventArgs e )
		{
			// 启动程序
			OperateResult op = YRC1000Tcp.Start( textBox6.Text );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Start Success" );
			}
			else
			{
				MessageBox.Show( "Start Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Start( \"{textBox6.Text}\" );";
		}

		private void button19_Click( object sender, EventArgs e )
		{
			// 删除程序
			OperateResult op = YRC1000Tcp.Delete( textBox6.Text );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Delte Success" );
			}
			else
			{
				MessageBox.Show( "Delte Failed: " + op.Message );
			}

			textBox_code.Text = $"OperateResult op = YRC1000Tcp.Delete( \"{textBox6.Text}\" );";
		}

		private void button20_Click( object sender, EventArgs e )
		{
			// 设定主程序
			OperateResult op = YRC1000Tcp.SetMJ( textBox6.Text );
			if (op.IsSuccess)
			{
				MessageBox.Show( "Set Success" );
			}
			else
			{
				MessageBox.Show( "Set Failed: " + op.Message );
			}


			textBox_code.Text = $"OperateResult op = YRC1000Tcp.SetMJ( \"{textBox6.Text}\" );";
		}
	}
	
}
