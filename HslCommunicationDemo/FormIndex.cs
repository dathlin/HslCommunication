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
			textBox1.Text = @"V9.2.4
1. Mewtocol: 松下的串口协议修复LD寄存器无法访问的bug，输入LD100，如果只输入L100，就是线圈。
2. Modbus: 修复写入寄存器指定位bool失败的bug，写入true的掩码改为 FF FE，00 01
3. Modbus：在ModbusRtuOverTcp里填写掩码写入的api方法。
4. ab-plc：CIP协议解析标签地址的编码从ASCII编码修改为UTF-8编码，支持中文的标签名访问。
5. omron-plc：CIP协议解析标签地址的编码从ASCII编码修改为UTF-8编码，支持中文的标签名访问。
6. Websocket: 连接的请求标头修改为GET ws://127.0.0.1:8800/ HTTP/1.1  就是带IP地址及端口信息
7. Redis：Redis的客户端添加对集合和有序集合操作的相关API方法，基本支持了所有需要的操作信息，单元测试通过。
8. Demo: 所有DEMO写入数据操作，新增Hex写入，输入1A 1B等十六进制数据，然后底层调用Write(string, byte[])方法。
9. Demo：Redis的功能菜单新增一个测试界面，用来同步两个不同的redis的数据，也可以同一个redis不同的db块数据。
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
