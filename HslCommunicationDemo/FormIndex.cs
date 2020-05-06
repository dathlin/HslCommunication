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
			textBox1.Text = @"V9.2.1
1. Toledo: 托利多电子秤的字节触发的时候，传递出来携带原始的字节数组，方便自行处理，Demo界面优化，显示信息更加完善。
2. Lsis: Lsis的PLC通信类修复一些bug，感谢埃及朋友的提供的技术支持。
3. MqttSyncClient: 新增ReadString方法，以字符串的形式来和服务器交互，默认编码UTF8，当然也可以自己指定编码，本质还是读取字节数据。
4. WebsocketClient: websocket的客户端类，重新设计异常重连，网络异常时触发 OnNetworkError 事件，用户应该捕获事件，然后在事件里重连服务器，直到成功为止。
5. MqttClient: Mqtt客户端类，重新设计异常重连，网络异常时触发 OnNetworkError 事件，用户应该捕获事件，然后在事件里重连服务器，直到成功为止。
6. MqttSyncClient: 支持读取数据的进度回调功能，支持三种进度报告，数据上传到服务器的进度报告，服务器处理进度报告，数据返回到客户端的进度报告。
7. PanasonicMewtocol: 修复注释错误，L区的数据也可以进行L100F，L2.3访问。
8. DLT645: 初步添加电力规约协议的串口实现，目前只实现了读取数据，还未测试，等待后续的测试完善。
9. Omron-cip: 读写字符串仍然没有测试通过，请暂时不要调用。
10. 官网的备案失效了，重新备案需要点时间，请访问 http://118.24.36.220/ 然后去顶部的菜单找相应的入口。
11. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。
12. HSL的目标是打造成工业互联网的利器，工业大数据的基础，打造边缘计算平台。企业终身授权费：8000元(不含税)。";
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
