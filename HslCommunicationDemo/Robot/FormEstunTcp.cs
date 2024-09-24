using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Robot.Estun;
using HslCommunication;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Robot
{
	public partial class FormEstunTcp : HslFormContent
	{
		public FormEstunTcp( )
		{
			InitializeComponent( );
		}

		private EstunTcpNet estun;
		private CodeExampleControl codeExampleControl;


		private void FormEstunTcp_Load( object sender, EventArgs e )
		{
			estun = new EstunTcpNet( );

			panel2.Enabled = false;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}

		private async void button1_Click( object sender, EventArgs e )
		{
			try
			{
				estun = new EstunTcpNet( textBox1.Text, int.Parse( textBox2.Text ) );
				estun.ConnectTimeOut = 2000;
				estun.Station = byte.Parse( textBox_station.Text );

				OperateResult connect = await estun.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					codeExampleControl.SetCodeText( "robot", estun, nameof( estun.Station ) );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
				}
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			estun?.ConnectClose( );
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private void button_read_short_Click( object sender, EventArgs e )
		{
			// 读取数据内容
			OperateResult<EstunData> read = estun.ReadRobotData( );
			if (read.IsSuccess)
			{
				EstunData data = read.Content;
				label12.BackColor = data.ErrorStatus ? SystemColors.Control : Color.Tomato;
				label13.BackColor = data.ErrorStatus ? Color.Tomato : SystemColors.Control;

				label15.BackColor = data.EnableStatus ? SystemColors.Control : Color.Tomato;
				label14.BackColor = data.EnableStatus ? Color.Tomato : SystemColors.Control;

				label18.BackColor = data.RunStatus ? SystemColors.Control : Color.Tomato;
				label17.BackColor = data.RunStatus ? Color.Tomato : SystemColors.Control;

				label22.BackColor = data.ProgramRunStatus ? SystemColors.Control : Color.Tomato;
				label21.BackColor = data.ProgramRunStatus ? Color.Tomato : SystemColors.Control;

				label25.BackColor = data.RobotMoving ? SystemColors.Control : Color.Tomato;
				label24.BackColor = data.RobotMoving ? Color.Tomato : SystemColors.Control;

				label39.BackColor = data.ManualMode ? Color.Tomato : SystemColors.Control;
				label37.BackColor = data.AutoMode ? Color.Tomato : SystemColors.Control;
				label36.BackColor = data.RemoteMode ? Color.Tomato : SystemColors.Control;

				label40.Text = data.GlobalSpeedValue.ToString( );
				label46.Text = data.ProjectName;
				label2.Text = "0x" + data.RobotCommandStatus.ToString( "X" );
				label5.Text = data.ReadWriteFlag.ToString( );

				textBox8.Text = data.DO.ToArrayString( );
				textBox9.Text = data.DI.ToArrayString( );
				textBox10.Text = data.AO.ToArrayString( );
				textBox11.Text = data.AI.ToArrayString( );

			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<EstunData> read = estun.ReadRobotData( );";
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 启动程序
			OperateResult start = estun.RobotStartPrograme( );
			if (start.IsSuccess)
			{
				MessageBox.Show( "启动成功！" );
			}
			else
			{
				MessageBox.Show( "启动失败！" + start.Message );
			}

			textBox_code.Text = $"OperateResult start = estun.RobotStartPrograme( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 停止程序
			OperateResult stop = estun.RobotStopPrograme( );
			if (stop.IsSuccess)
			{
				MessageBox.Show( "停止成功！" );
			}
			else
			{
				MessageBox.Show( "停止失败！" + stop.Message );
			}

			textBox_code.Text = $"OperateResult stop = estun.RobotStopPrograme( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 机器人错误复位
			OperateResult reset = estun.RobotResetError( );
			if (reset.IsSuccess)
			{
				MessageBox.Show( "复位成功！" );
			}
			else
			{
				MessageBox.Show( "复位失败！" + reset.Message );
			}

			textBox_code.Text = $"OperateResult reset = estun.RobotResetError( );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 状态指令集重置
			OperateResult reset = estun.RobotCommandStatusRestart( );
			if (reset.IsSuccess)
			{
				MessageBox.Show( "重置成功！" );
			}
			else
			{
				MessageBox.Show( "重置失败！" + reset.Message );
			}

			textBox_code.Text = $"OperateResult reset = estun.RobotCommandStatusRestart( );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 卸载程序文件
			OperateResult unload = estun.RobotUnregisterProject( );
			if (unload.IsSuccess)
			{
				MessageBox.Show( "卸载成功！" );
			}
			else
			{
				MessageBox.Show( "卸载失败！" + unload.Message );
			}

			textBox_code.Text = $"OperateResult unload = estun.RobotUnregisterProject( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 加载工程文件
			OperateResult load = estun.RobotLoadProject( textBox3.Text );
			if (load.IsSuccess)
			{
				MessageBox.Show( "加载成功！" );
			}
			else
			{
				MessageBox.Show( "加载失败！" + load.Message );
			}

			textBox_code.Text = $"OperateResult load = estun.RobotLoadProject( \"{textBox3.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 加载全局速度
			OperateResult set = estun.RobotSetGlobalSpeedValue( short.Parse( textBox4.Text ) );
			if (set.IsSuccess)
			{
				MessageBox.Show( "加载成功！" );
			}
			else
			{
				MessageBox.Show( "加载失败！" + set.Message );
			}

			textBox_code.Text = $"OperateResult set = estun.RobotSetGlobalSpeedValue( short.Parse( \"{textBox4.Text}\" ) );";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// 强制下载0x801命令
			OperateResult write = estun.Write( "36", (short)0x801 );
			if (write.IsSuccess)
			{
				MessageBox.Show( "下载成功！" );
			}
			else
			{
				MessageBox.Show( "下载失败！" );
			}

			textBox_code.Text = $"OperateResult write = estun.Write( \"36\", (short)0x801 );";
		}

		private void panel2_Paint( object sender, PaintEventArgs e )
		{

		}
	}
}
