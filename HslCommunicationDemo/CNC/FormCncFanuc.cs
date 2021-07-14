using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.CNC.Fanuc;
using HslCommunication;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region FormMqttSyncClient


	public partial class FormCncFanuc : HslFormContent
	{
		public FormCncFanuc( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			textBox7.Text = System.IO.Path.Combine( Application.StartupPath, "O6.txt" );

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "Fanuc 0i-mf Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label12.Text = "Receive:";
			}
		}

		private FanucSeries0i fanuc;

		private async void button1_Click( object sender, EventArgs e )
		{
			fanuc?.ConnectClose( );
			fanuc = new FanucSeries0i( textBox1.Text, int.Parse( textBox2.Text ) );

			button1.Enabled = false;
			OperateResult connect = await fanuc.ConnectServerAsync( );

			if(connect.IsSuccess)
			{
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				button1.Enabled = true;
				MessageBox.Show( connect.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			fanuc.ConnectClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<SysStatusInfo> read= fanuc.ReadSysStatusInfo( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<SysAlarm[]> read = fanuc.ReadSystemAlarm( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<SysAllCoors> read = fanuc.ReadSysAllCoors( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button6_Click( object sender, EventArgs e )
		{
			OperateResult<int[]> read = fanuc.ReadProgramList( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string, int> read = fanuc.ReadSystemProgramCurrent( );
			if (read.IsSuccess)
			{
				textBox8.Text = "程序名：" + read.Content1 + Environment.NewLine + "程序号：" + read.Content2;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			OperateResult<double, double> read = fanuc.ReadSpindleSpeedAndFeedRate( );
			if (read.IsSuccess)
			{
				textBox8.Text = "主轴转速：" + read.Content1 + Environment.NewLine + "进给倍率：" + read.Content2;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button9_Click( object sender, EventArgs e )
		{
			OperateResult<double[]> read = fanuc.ReadFanucAxisLoad( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button10_Click( object sender, EventArgs e )
		{
			OperateResult<CutterInfo[]> read = fanuc.ReadCutterInfos( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = fanuc.ReadCurrentForegroundDir( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button22_Click( object sender, EventArgs e )
		{
			// 系统语言
			OperateResult<ushort> read = fanuc.ReadLanguage( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString() + Environment.NewLine +
					"此处举几个常用值 0: 英语 1: 日语 2: 德语 3: 法语 4: 中文繁体 6: 韩语 15: 中文简体 16: 俄语 17: 土耳其语";
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}
		private void button12_Click( object sender, EventArgs e )
		{
			OperateResult<double[]> read = fanuc.ReadDeviceWorkPiecesSize( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button13_Click( object sender, EventArgs e )
		{
			OperateResult<int> read = fanuc.ReadAlarmStatus( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void ReadTimeData( int type )
		{
			OperateResult<long> read = fanuc.ReadTimeData( type );
			if (read.IsSuccess)
			{
				textBox8.Text = $"{read.Content / 3600} H {read.Content % 3600 / 60} M {read.Content % 3600 % 60} S";
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}
		private void button14_Click( object sender, EventArgs e )
		{
			// 开机时间
			ReadTimeData( 0 );
		}

		private void button15_Click( object sender, EventArgs e )
		{
			// 运行时间
			ReadTimeData( 1 );
		}

		private void button16_Click( object sender, EventArgs e )
		{
			// 切割时间
			ReadTimeData( 2 );
		}

		private void button17_Click( object sender, EventArgs e )
		{
			// 空闲时间
			ReadTimeData( 3 );
		}

		private void button24_Click( object sender, EventArgs e )
		{
			// 当前的程序
			OperateResult<string> read = fanuc.ReadCurrentProgram( );
			if (read.IsSuccess)
			{
				textBox8.Text = "程序内容：" + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private async void button28_Click( object sender, EventArgs e )
		{
			// 读取程序
			if (!ushort.TryParse( textBox9.Text, out ushort programNum ))
			{
				MessageBox.Show( "主程序号输入错误！" );
				return;
			}
			button28.Enabled = false;
			OperateResult<string> read = await fanuc.ReadProgramAsync( programNum );
			button28.Enabled = true;
			if (read.IsSuccess)
			{
				textBox8.Text = "程序内容：" + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "读取失败！" + read.ToMessageShowString( ) );
			}
		}

		private void button29_Click( object sender, EventArgs e )
		{
			// 删除程序
			if (!ushort.TryParse( textBox9.Text, out ushort programNum ))
			{
				MessageBox.Show( "主程序号输入错误！" );
				return;
			}

			OperateResult read = fanuc.DeleteProgram( programNum );
			if (read.IsSuccess)
			{
				textBox8.Text = "删除程序成功！";
			}
			else
			{
				MessageBox.Show( "删除失败！" + read.ToMessageShowString( ) );
			}
		}
		private void button25_Click( object sender, EventArgs e )
		{
			// 设置为主程序
			if (!ushort.TryParse( textBox6.Text, out ushort programNum ))
			{
				MessageBox.Show( "主程序号输入错误！" );
				return;
			}
			OperateResult set = fanuc.SetCurrentProgram( programNum );
			if (set.IsSuccess)
			{
				MessageBox.Show( "设置主程序成功！" );
			}
			else
			{
				MessageBox.Show( "设置主程序失败！" + set.Message );
			}
		}

		private async void button27_Click( object sender, EventArgs e )
		{
			if (!System.IO.File.Exists( textBox7.Text ))
			{
				MessageBox.Show( "文件不存在!" );
				return;
			}
			// 下载程序
			button27.Enabled = false;
			OperateResult write = await fanuc.WriteProgramFileAsync( textBox7.Text );
			button27.Enabled = true;
			if (write.IsSuccess)
			{
				MessageBox.Show( "下载成功！" );
			}
			else
			{
				MessageBox.Show( "下载失败！" + write.Message );
			}
		}
		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult start = fanuc.StartProcessing( );
			if (start.IsSuccess)
			{
				MessageBox.Show( "启动成功！" );
			}
			else
			{
				MessageBox.Show( "启动失败！"  + start.ToMessageShowString());
			}
		}
		private void button18_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox3.Text, out int address ))
			{
				MessageBox.Show( "宏变量地址输入错误！" );
				return;
			}
			OperateResult<double> read = fanuc.ReadSystemMacroValue( address );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button19_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = fanuc.ReadCurrentDateTime( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( "yyyy-MM-dd HH:mm:ss" );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button20_Click( object sender, EventArgs e )
		{
			// 已加工数量
			OperateResult<int> read = fanuc.ReadCurrentProduceCount( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button21_Click( object sender, EventArgs e )
		{
			// 总加工数量
			OperateResult<int> read = fanuc.ReadExpectProduceCount( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button23_Click( object sender, EventArgs e )
		{
			// 读R数据
			OperateResult<byte[]> read = fanuc.ReadRData( int.Parse( textBox4.Text ), int.Parse( textBox5.Text ) );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToHexString( ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}


	#endregion
}
