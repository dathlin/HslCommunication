using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo
{
	public partial class FormIndex : HslFormContent
	{
		public FormIndex( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel1.Text );
		}

		private Timer timer1s;

		private void FormCharge_Load( object sender, EventArgs e )
		{
			SetUpdayeInfo( );

			if(Program.Language == 2)
			{
				Text = "Start Page";
			}

			if (Program.IsActive)
			{
				hslLedDisplay1.DisplayText = "-----";
			}
			else
			{
				timer1s = new Timer( );
				timer1s.Tick += Timer1s_Tick;
				timer1s.Interval = 500;
				timer1s.Start( );
			}
		}

		int tick = 0;
		private void Timer1s_Tick( object sender, EventArgs e )
		{
			tick++;
			if (tick == 2) tick = 0;

			TimeSpan ts = DateTime.Now - Program.StartTime;
			double remain = 8d - ts.TotalHours;
			if (remain < 0) hslLedDisplay1.DisplayText = "00:00";
			else
			{
				int hour = (int)remain;
				int min = 59 - ts.Minutes;
				if (tick == 0) hslLedDisplay1.DisplayText = $"{hour:D2}:{min:D2}";
				else hslLedDisplay1.DisplayText = $"{hour:D2} {min:D2}";
			}
		}

		private void SetUpdayeInfo( )
		{
			textBox1.Text = @"V9.1.3
1. HslExtension: 完善一些转化的api，方便数组和字符串转化，完善对象转JSON字符串。
2. LogNet：消息格式化文本的消息等级追随HSL的语言设定，如果是中文，就显示调试，信息，警告，错误，致命。
3. Redis: 修复ExpireKey，生存时间参数丢失的bug，完善了说明文档。
4. OmronCip: 欧姆龙的CIP协议的类库，修复数组读取的bug，修复字符串写入bug，字符串写入还需要测试。
5. Toledo：新增托利多电子秤的串口类及网口服务器类，方便接收标准的数据流，等待测试。
6. Java：增加了单元测试的内容，对一些已经完成的类添加单元测试。
7. Python：实现了python版本的HslCommunication程序，基于pyqt实现，初步添加了一些PLC的调试界面。
8. 代码注释优化，使用前请仔细阅读下面的信息：http://api.hslcommunication.cn/
9. http://www.hslcommunication.cn/MesDemo 官网的地址以后作为优秀的MES产品展示平台，欢迎大家关注。
10. HSL的目标是打造成工业互联网的利器，工业大数据的基础，打造边缘计算平台。企业终身授权费：8000元。";
		}


		private void ShowActiveCode( )
		{
			textBox1.Text = @"/// <summary>
/// 应用程序的主入口点。
/// </summary>
[STAThread]
static void Main( )
{
	// 中文授权示例
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"你的激活码\"" + @" ))
	{
		MessageBox.Show( " + "\"授权失败！当前程序只能使用8小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		MessageBox.Show( " + "\"Active Failed! it can only use 8 hours\"" + @" );
		return;  // quit if active failed
	}
	Application.EnableVisualStyles( );
	Application.SetCompatibleTextRenderingDefault( false );
	Application.Run( new Form1( ) );
}";
		}

		private void label15_Click( object sender, EventArgs e )
		{
			ShowActiveCode( );
		}

		private void label14_Click( object sender, EventArgs e )
		{
			SetUpdayeInfo( );
		}
	}
}
