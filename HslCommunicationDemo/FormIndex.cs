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

		private void FormCharge_Load( object sender, EventArgs e )
		{
			SetUpdayeInfo( );

			if(Program.Language == 2)
			{
				Text = "Start Page";
			}

		}

		private void SetUpdayeInfo( )
		{
			textBox1.Text = @"V10.4.0
1. Delta:台达系列的PLC类重命名，新增PLC系列，可选DVP系列和AS系列，相当于新增了对AS300的支持，如果用到，谨慎更新。
2. WebSocketServer: 原先订阅的操作使用header来完成，新增客户端从url添加订阅主题，例如：ws://127.0.0.1:1883/HslSubscribes=A,B
3. AllenBradleyPcccNet:新增AB的CIP协议PCCC格式的通信，测试适用ab1400，地址格式为 N7:5, I:0/2, F2:0 等
4. AllenBradleyPcccServer: 新增PCCC的虚拟服务器功能，可以配合客户端进行通信的测试，支持基本的地址。
5. MC-A3C: 修复A3C的服务器在格式4的情况下，返回写入操作的控制代码错误的bug，应该为06，写成了02。
6. 三菱的A3C协议的读取字数据及位数据长度自动切割，可以输入理论最大长度，修复校验是否写入成功确提示失败的bug。
7. NetworkDataServerBase:串口接收增加最小接收时间，默认是20，表示20毫秒，如果重写了报文结束检查，则可以设置大一点。
8. NetworkServerBase: 基础服务器对象新增属性EnableIPv6，当设置为true的时候，则使用IPv6协议进行数据通信和访问。
9. 所有的TCP及UDP的相关的客户端通信类的 IP 地址设置，都支持了 IPv6 地址，所以目前IP地址支持 IPv4 和 IPv6 及 网址。
10. Demo:fanuc机器人的测试界面写入数据操作进行提示相关的确认，防止手抖不小心写入导致机器人运行不正常。
11. Demo，所有的设备通信类，新增一个支持的设备列表功能，大家可以手动添加支持的列表，方便别人查看支持的型号，请大家务必真实填写。
12. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
13. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
		MessageBox.Show( " + "\"Active Failed! it can only use 24 hours\"" + @" );
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
