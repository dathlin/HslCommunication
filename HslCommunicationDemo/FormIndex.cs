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
				hslLedDisplay1.Visible = false;
				hslTitle1.TextLeft = "";
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
			textBox1.Text = @"V9.3.0
1.Networkbase：核心网络底层的错误码调整，当读写操作因为网络问题失败时，返回错误码为负数-1，如果连续读写失败，就一直递减。
2. OmronConnectedCipNet: 地址解析修改为全部上29 00 报文。
3. FileNet: 两种文件服务器支持删除多个文件和删除文件夹的所有文件功能，客户端同步适配，初步测试通过。
4. NetSimplifyClient: 新增一个构造方法，可以传入IPAddress类型的ip地址。
5. MqttSyncClient: 新增一个构造方法，可以传入IPAddress类型的ip地址。
6. MqttClient: 修复一个连接反馈信号，解析判断服务器状态错误的bug，该bug导致MqttClient连接不是中国移动的OneNet物联网框架。
7. FFT: 傅立叶变换FFTValue方法添加一个可选参数，是否二次开放，波形中的毛刺频段会更加明显。
8. HttpServer: webapi的服务器完善注释，添加一个端口号的属性，获取当前配置端口号信息。
9. Active: 当前库激活失效的时候，返回的错误消息，携带当前的通信对象的实例化个数，方便查找授权失败的原因。
10. Abb机器人：abb机器人支持读取程序执行状态，任务列表功能，伺服状态，机器人位置数据。
11. ABB虚拟机器人：新增一个abb机器人的虚拟webapi的服务器，可以用来测试和ABB客户端的通信。
12. Demo: 数据转换的界面，新增一个显示指定的文件的二进制的内容的功能。当demo激活成功时，不显示时间及授权信息。
13. 新增一篇全新的博文，介绍基于HSL的大一统网络架构实现，满足发布订阅，一对多通信，webapi等：https://www.cnblogs.com/dathlin/p/13416030.html。
14. 官网备案成功了，地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。
16. HSL的目标是打造成工业互联网的利器，工业大数据的基础，打造边缘计算平台。企业终身授权费：8000元(不含税)。";
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
