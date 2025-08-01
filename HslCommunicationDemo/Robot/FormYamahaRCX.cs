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
using HslCommunication.Core.Pipe;
using System.Net.Sockets;
using System.Threading;

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

		private void FormYamahaRCX_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		private async void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				yamahaRCX = new YamahaRCX( );
				try
				{
					this.pipeSelectControl1.IniPipe( yamahaRCX );
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage( ex );
					return;
				}
				// 连接
				yamahaRCX.LogNet = this.LogNet;                                                // 设置之后支持界面显示日志信息

				button1.Enabled = false;
				OperateResult connect = await yamahaRCX.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					// 设置代码示例
					codeExampleControl.SetCodeText( "yamahaRCX", yamahaRCX );
				}
				else
				{
					button1.Enabled = true;
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
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

			AddCommandInfo( "自动模式", "@AUTO", "@AUTO", "" );
			AddCommandInfo( "编程模式", "@PROGRAM", "", "" );
			AddCommandInfo( "手动模式", "", "@MANUAL", "" );
			AddCommandInfo( "获取脉冲坐标值", "@? WHERE", "@? WHERE", "" );
			AddCommandInfo( "获取毫米坐标值", "@? WHRXY", "@? WHRXY", "" );
			AddCommandInfo( "程序停止", "@STOP", "@STOP", "" );
			AddCommandInfo( "JOG X 正方向", "@JOG X+", "@JOGXY 1+", "" );
			AddCommandInfo( "JOG X 负方向", "@JOG X-", "@JOGXY 1-", "" );
			AddCommandInfo( "JOG Y 正方向", "@JOG Y+", "@JOGXY 2+", "" );
			AddCommandInfo( "JOG Y 负方向", "@JOG Y-", "@JOGXY 2-", "" );
			AddCommandInfo( "JOG R 正方向", "@JOG R+", "@JOGXY 4+", "" );
			AddCommandInfo( "JOG R 负方向", "@JOG R-", "@JOGXY 4-", "" );
			AddCommandInfo( "JOG Z 正方向", "@JOG Z+", "@JOGXY 3+", "" );
			AddCommandInfo( "JOG Z 负方向", "@JOG Z-", "@JOGXY 3-", "" );
			AddCommandInfo( "改变机器人速度", "@MSPEED #", "@MSPEED #", "例如 @MSPEED 50, 默认机器人编号1, #代表数字" );
			AddCommandInfo( "改变机器人加速度", "@ACCEL #", "@ACCEL #", "#代表数字" );
			AddCommandInfo( "改变机器人减速度", "@DECEL #", "@DECEL #", "#代表数字" );
			AddCommandInfo( "设置左手系", "@ARMTYP 1,1", "@ARMSEL 2", "" );
			AddCommandInfo( "设置右手系", "@ARMTYP 0,0", "@ARMSEL 1", "" );
			AddCommandInfo( "设置单位为毫米", "@UNIT 1", "", "" );
			AddCommandInfo( "设置单位为脉冲", "@UNIT 0", "", "" );
			AddCommandInfo( "得到当前的手系", "@? ARM", "@? ARMCND", "" );
			AddCommandInfo( "等待机械臂停稳", "@WAIT ARM", "", "" );
			AddCommandInfo( "是否已经回原点", "@? ABSRST", "@? ORIGIN", "" );
			AddCommandInfo( "伺服是否上电", "@? SERVO", "@? SERVO", "" );
			AddCommandInfo( "是否急停状态", "@? EMG", "@? EMG", "" );
			AddCommandInfo( "当前模式", "@? MOD", "@? MODE", "" );
			AddCommandInfo( "伺服上电", "@SERVO ON", "@MOTOR ON", "" );
			AddCommandInfo( "伺服断电", "@SERVO OFF", "@MOTOR OFF", "" );
			AddCommandInfo( "伺服自由", "@SERVO FREE", "@MOTOR FREE", "" );
			AddCommandInfo( "回原点", "@ABSRST", "@ORIGIN", "" );
			AddCommandInfo( "机器人开始停止", "@RUN", "@RUN", "" );
			AddCommandInfo( "机器人运行停止", "@STOP", "@STOP", "" );
			AddCommandInfo( "移动到指定位置", "@MOVE P,X Y R Z 0 0", "@MOVE P,X Y R Z 0 0", "" );
			AddCommandInfo( "写入点位到控制器", "@P#=X Y R Z 0 0", "@P#=X Y R Z 0 0", "#代表数字" );
			AddCommandInfo( "清除内部报警状态", "", "@ALMRST", "" );
			AddCommandInfo( "示教点位", "@TEACH #", "@TCHXY #", "#代表数字" );
			AddCommandInfo( "获取任务运行状态", "", "@? TSKMON", "R:执行中，U:暂时休止, S:停止状态" );
			AddCommandInfo( "读机器人输入", "@?DI2()", "@?DI2()", "" );
			AddCommandInfo( "读机器人输出", "@?DO2()", "@?DO2()", "" );
			AddCommandInfo( "写机器人输出", "@DO2()=#", "@DO2()=#", "#代表数字" );



			dataGridView1.Rows[0].Cells[0].Selected = false;
		}

		private void AddCommandInfo( string name, string cmdCX240, string cmdCX340, string des )
		{
			int rowIndex = dataGridView1.Rows.Add( );
			DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];

			dgvr.Cells[0].Value = name;
			dgvr.Cells[1].Value = cmdCX240;
			dgvr.Cells[2].Value = cmdCX340;
			dgvr.Cells[3].Value = des;
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
				DemoUtils.ShowMessage( "Reset success" );
			}
			else
			{
				DemoUtils.ShowMessage( "Reset Faield:" + reset.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult reset = yamahaRCX.Reset( );" );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult reset = yamahaRCX.Run( );
			if (reset.IsSuccess)
			{
				DemoUtils.ShowMessage( "Run success" );
			}
			else
			{
				DemoUtils.ShowMessage( "Run Faield:" + reset.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult run = yamahaRCX.Run( );" );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult reset = yamahaRCX.Stop( );
			if (reset.IsSuccess)
			{
				DemoUtils.ShowMessage( "Stop success" );
			}
			else
			{
				DemoUtils.ShowMessage( "Stop Faield:" + reset.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult stop = yamahaRCX.Stop( );" );
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
				DemoUtils.ShowMessage( "Read Faield:" + motor.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<int> motor = yamahaRCX.ReadMotorStatus( );" );
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
				DemoUtils.ShowMessage( "Read Faield:" + mode.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<int> mode = yamahaRCX.ReadModeStatus( );" );
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
				DemoUtils.ShowMessage( "Read Faield:" + joints.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<float[]> joints = yamahaRCX.ReadJoints( );" );
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
				DemoUtils.ShowMessage( "Read Faield:" + emergency.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<int> emergency = yamahaRCX.ReadEmergencyStatus( );" );
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button_execute_Click( object sender, EventArgs e )
		{
			// 自定义的命令
			OperateResult<string[]> read = yamahaRCX.ReadCommand( textBox_read_command.Text );
			if (read.IsSuccess)
			{
				textBox_result.Lines = read.Content;
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<string[]> read = yamahaRCX.ReadCommand( \"{textBox_read_command.Text}\" );" );
		}

		private void RenderJogResult( OperateResult result, string jog )
		{
			if (result.IsSuccess)
			{
				textBox_result.AppendText( DateTime.Now.ToString( ) + " " + jog + " Success" + Environment.NewLine );
			}
			else
			{
				DemoUtils.ShowMessage( jog + " failed: " + result.Message );
			}
		}

		private void StartJogXY( JogMoveCmd cmd )
		{
			textBox_result.Text = DateTime.Now.ToString( ) + " Start Jog" + Environment.NewLine;
			ThreadPool.QueueUserWorkItem( new WaitCallback( new Action<object>( m =>
			{
				JogMoveCmd jogMoveCmd = m as JogMoveCmd;
				yamahaRCX.SendJogXY( jogMoveCmd.JogIndex );
				while (jogMoveCmd.MoveEnable)
				{
					HslCommunication.Core.HslHelper.ThreadSleep( 100 );
					yamahaRCX.CommunicationPipe.Send( new byte[] { 0x16 } );
				}
				OperateResult<byte[]> finish = yamahaRCX.ReadFromCoreServer( new byte[0], hasResponseData: true, usePackAndUnpack: true );
				Invoke( new Action( ( ) =>
				{
					if (finish.IsSuccess)
						textBox_result.AppendText( "Finish Jog: " + Encoding.UTF8.GetString( finish.Content ) );
					else
						DemoUtils.ShowMessage( "Operate failed: " + finish.Message );
				} ) );
			} ) ), cmd );
			this.codeExampleControl.ReaderReadCode( $@"
yamahaRCX.SendJogXY( {cmd.JogIndex} );
while ([MoveEnable])
{{
	HslCommunication.Core.HslHelper.ThreadSleep( 100 );
	yamahaRCX.CommunicationPipe.Send( new byte[] {{ 0x16 }} );
}}
OperateResult<byte[]> finish = yamahaRCX.ReadFromCoreServer( new byte[0], hasResponseData: true, usePackAndUnpack: true );" );
		}

		private JogMoveCmd jogEnabled = new JogMoveCmd( ) { JogIndex = -1 };

		private void button10_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -1 ), "JOG 1-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -1 );" );
			}
		}

		private void button10_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -1;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		private void button10_MouseUp( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.MoveEnable = false;
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 1 ), "JOG 1+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 1 );" );
			}
		}

		private void button11_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 1;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}


		private void button13_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -2 ), "JOG 2-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -2 );" );
			}
		}

		private void button13_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -2;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}


		private void button12_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 2 ), "JOG 2+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 2 );" );
			}
		}

		private void button12_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 2;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		private void button15_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -3 ), "JOG 3-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -3 );" );
			}
		}

		private void button15_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -3;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		private void button14_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 3 ), "JOG 3+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 3 );" );
			}
		}

		private void button14_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 3;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		private void button17_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -4 ), "JOG 4-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -4 );" );
			}
		}

		private void button17_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -4;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		private void button16_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 4 ), "JOG 4+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 4 );" );
			}
		}

		private void button16_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 4;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}
		private void button19_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -5 ), "JOG 5-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -5 );" );
			}
		}

		private void button19_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -5;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}
		private void button18_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 5 ), "JOG 5+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 5 );" );
			}
		}

		private void button18_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 5;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}
		private void button21_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( -6 ), "JOG 6-" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( -6 );" );
			}
		}

		private void button21_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = -6;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}
		private void button20_Click( object sender, EventArgs e )
		{
			if (!checkBox_keepmove.Checked)
			{
				RenderJogResult( yamahaRCX.JogXY( 6 ), "JOG 6+" );
				this.codeExampleControl.ReaderReadCode( $"OperateResult result = yamahaRCX.JogXY( 6 );" );
			}
		}

		private void button20_MouseDown( object sender, MouseEventArgs e )
		{
			if (checkBox_keepmove.Checked && e.Button == MouseButtons.Left)
			{
				jogEnabled.JogIndex = 6;
				jogEnabled.MoveEnable = true;
				StartJogXY( jogEnabled );
			}
		}

		public void ReadDI( int index )
		{
			OperateResult<bool[]> read = yamahaRCX.ReadDI( index );
			if (read.IsSuccess)
			{
				textBox_result.Text = read.Content.ToArrayString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read Faield:" + read.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<bool[]> read = yamahaRCX.ReadDI( {index} )" );
		}

		private void button22_Click( object sender, EventArgs e )
		{
			// DI0
			ReadDI( 0 );
		}

		private void button23_Click( object sender, EventArgs e )
		{
			// DI1
			ReadDI( 1 );
		}

		private void button24_Click( object sender, EventArgs e )
		{
			// DI2
			ReadDI( 2 );
		}

		public void ReadDO( int index )
		{
			OperateResult<bool[]> read = yamahaRCX.ReadDO( index );
			if (read.IsSuccess)
			{
				textBox_result.Text = read.Content.ToArrayString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read Faield:" + read.Message );
			}

			this.codeExampleControl.ReaderReadCode( $"OperateResult<bool[]> read = yamahaRCX.ReadDO( {index} )" );
		}

		private void button27_Click( object sender, EventArgs e )
		{
			// DO0
			ReadDO( 0 );
		}

		private void button26_Click( object sender, EventArgs e )
		{
			// DO1
			ReadDO( 1 );
		}

		private void button25_Click( object sender, EventArgs e )
		{
			// DO2
			ReadDO( 2 );
		}

	}

	public class JogMoveCmd
	{
		public int JogIndex { get; set; }

		public bool MoveEnable {  get; set; }
	}
}
