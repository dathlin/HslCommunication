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
	public partial class FormCharge : HslFormContent
	{
		public FormCharge( )
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

		private static DateTime StartTime = DateTime.Now;
		int tick = 0;
		private void Timer1s_Tick( object sender, EventArgs e )
		{
			tick++;
			if (tick == 2) tick = 0;

			TimeSpan ts = DateTime.Now - StartTime;
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
			textBox1.Text = @"V9.1.1
1. feat(SAM): 身份证阅读器修复在某些状态下接受数据不完整的bug，将校验数据的完整性。
2. feat(ab-plc): 虚拟服务器的地址支持小数点的形式，支持单个的bool读写，支持string的读写操作，和客户端的体验一致。
3. feat(softbasic): 方法针对数组切割的方法，增加扩展方法支持，byte[] a; byte[] b= a.RemoveBegin(2);意思就是移除最前面的2个元素。
4. feat(softbasic): Hex字符串和byte[]的转化也支持扩展方法。byte[] a.ToHexString()。
5. feat(melsec): 三菱的a-1e协议之前的，x,y地址采用8进制，先修改为自定义，如果要八进制，地址前面加0，例如X017，如果不加就是十六进制，例如X17，默认十六进制，升级需注意。
6. feat(melsec): 三菱的a-1e协议增加了F报警继电器，B链接继电器，W链接寄存器，定时器和计数器的线圈，触点，当前值的读取，地址参见api文档说明。
7. feat(melsec): 添加a-1e协议的ASCII版本，地址格式和二进制版本是一致的，支持的地址类型也是一致的，还未仔细测试，欢迎老铁们测试。
8. feat(melsec): 三菱的mc虚拟服务器支持二进制和ascii，实例化的时候选择，支持和HSL组件自身的通讯。
9. lsis: cnet和fenet地址的解析bug修复，感谢埃及朋友的支持。
10. 代码注释优化，使用前请仔细阅读下面的信息：http://api.hslcommunication.cn/
11. http://www.hslcommunication.cn/MesDemo 官网的地址以后作为优秀的MES产品展示平台，欢迎大家关注。
12. HSL的目标是打造成工业互联网的利器，工业大数据的基础，打造边缘计算平台。企业授权费：8000元，欢迎老铁们询价。";
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
