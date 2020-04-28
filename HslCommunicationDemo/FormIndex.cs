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
			textBox1.Text = @"V9.2.0
1. HttpServer: 当客户端发起request请求的时候，在日志记录的时候记录当前的请求的方式，GET,POST,OPTION等等。
2. MQTT: mqtt的消息等级追加一个新的等级，为OnlyTransfer等级，用来表示只发送服务器，不触发发布操作。
3. MqttServer: 配合Qos等级为OnlyTransfer时，进行相关的适配操作，并触发消息接收的事件。
4. MqttSyncClient: 新增MQTT的同步访问的客户端，协议头标记为HUSL，向HSL的mqtt服务器进行数据请求并等待反馈。尚未添加心跳程序。
5. MqttServer: 适配同步客户端实现功能，当客户端为同步客户端的时候，调试心跳验证。
6. 至此，HSL的MQTT协议已经是兼容几大网络功能了，在线客户端管理，消息发布订阅，消息普通收发，同步网络访问。
7. IByteTransform接口属性新增IsStringReverseByteWord，相当于从ReverseByWord挪过来了，默认为false，如果为true，在解析字符串的时候将两两字节颠倒。
8. Omron: 欧姆的fins-tcp及fins-udp及hostlink的IByteTransform接口IsStringReverseByteWord调整为true默认颠倒。
9. SerialBase: 串口基类的打开串口方法调整返回类型OperateResult，在串口数据读取之前增加打开串口的Open方法，串口类也只需要一直读就可以了。
10. NetworkDoubleBase, SerialDeviceBase, NetworkUdpDeviceBase及相关的继承类，对所有的泛型进行了擦除，一律采用接口实现，之后将统一java,python代码。
11. FreedomTcp,FreedomUdp,FreeSerial: 添加基于自由协议的tcp，udp，串口协议，可以自由配置IByteTransform接口，可用来读取一些不常见的协议。
12. Omron-cip: 读写字符串仍然没有测试通过，请暂时不要调用。
13. SiemensS7: 单次读取之前是按照200字节进行拆分的，现在根据s7协议返回的报文来自动调整，1200系列是220字节，1500系列是920字节，其他等待测试。
14. 官网的备案失效了，重新备案需要点时间，请访问 http://118.24.36.220/ 然后去顶部的菜单找相应的入口。
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
