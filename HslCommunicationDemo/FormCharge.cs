using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
			timer1s = new Timer( );
			timer1s.Tick += Timer1s_Tick;
			timer1s.Interval = 500;
			timer1s.Start( );
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
				if (tick == 0) hslLedDisplay1.DisplayText = $"{hour.ToString("D2")}:{min.ToString("D2")}";
				else hslLedDisplay1.DisplayText = $"{hour.ToString( "D2" )} {min.ToString( "D2" )}";
			}
		}

		private void SetUpdayeInfo( )
		{
			textBox1.Text = @"V9.1.0
1. MQTT: 服务器增加定时检测客户端在线情况，超过设置的时间不活跃，强制下线，开放OnlineSession属性，获取在线客户端，查看ip，端口，在线时间等信息。
2. WebSocket: 服务器开放OnlineSession属性，获取在线客户端，查看ip，端口，在线时间等信息。
3. Language: 组件的语言系统修复设置英文后，无法切换回中文的bug。
4. SoftBasic: 添加SpliceByteArray(params byte[][] bytes)方法，用来将任意个byte[]进行拼接成一个byte[]。
5. SoftBasic: 添加BoolOnByteIndex方法，用来获取byte数据的指定位的bool值。
6. Panasonic: 松下的mc地址和串口地址统一表示方式：R101=R10.1=[10*16+1]，R10.F=R10.15(这两种表示方式都可以)
7. 发布基于HSL扩展组件HslCppExtension，将写入的重载方法名按照类型重写一遍，方便C++调用。
8. VC++的demo示例，新增写入数据的例子，基于扩展组件HslCppExtension实现，详细参照demo源代码。
9. SoftBasic: 针对byte数组的切割，选择头，尾，中间，移除头，尾的方法全部更改成泛型版本，方法名字已经变更，如果有调用，谨慎更新。
10. FanucInterfaceNet: 新增读取fanuc机器人的通讯类，支持读写任意地址数据的功能，详细参考api文档，写入操作谨慎测试。
11. FanucRobotServer: 新增fanuc机器人的虚拟服务器，方便进行测试，初始数据来自真实机器人，支持D,I,Q,AI,AQ,M数据区。
12. Fanuc: 目前测试通过的型号为R-30iB mate plus，其他型号暂时不清楚支持范围。
13. 代码注释优化，api文档大量的更新，添加一些示例代码，包含如果检测状态，长短连接，使用前请仔细阅读下面的信息：http://api.hslcommunication.cn/
14. http://www.hslcommunication.cn/MesDemo 官网的地址以后作为优秀的MES产品展示平台，欢迎大家关注。
15. 三年磨一剑，直插工业互联网的心脏。软件开发之艰辛，如人饮水冷暖自知。感谢所有支持的朋友。";
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
