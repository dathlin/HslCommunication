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
			textBox1.Text = @"V10.6.1
1. MelsecMcRNet: 修复McType属性设置不正确的bug，导致依然使用普通的mc协议来进行通信，因为R系列MC协议地址不一样。
2. ModbusServer: ModbusServer增加属性StationCheck，默认为True，对请求的客户端的站号进行检查操作，也可以设置false，不检查站号一致。
3. BeckhoffAdsNet: 新增支持批量读取的方法Read( string[] address, ushort[] length )，完善了API文档说明，可以一次性读取多个标签信息，需要自行解析。
4. BeckhoffAdsNet： 修改默认的端口为851，主要用于TWINCAT3，当没有设置 NETID 时，直接连接PLC的话，自动升级为自动获取NETID信息。
5. BeckhoffAdsNet: 重写实现新的Read{T}(), 一次性读取所有的类型数据，然后自动解析赋值到对象的属性，在API文档上增加示例的代码。
6. SiemensPPI: 西门子PPI协议修复输入M5这种只有两个字符的地址的时候，地址解析报异常的bug，同样也适用于SiemensPPIOverTcp
7. KeyenceNano: 基恩士上位链路协议优化，地址重新设计，修复B,VB,W的十六进制地址解析异常的bug，FM地址不正确解析的bug。
8. KeyenceNano: 上位链路协议读取支持自动切割，根据不同的地址切割出不同的长度信息，一般都是256长度切割，虚拟服务器也进行了地址修复和长度限制适配。
9. OmronFinsUdp: 欧姆龙Finsudp协议的DA1（PLC节点号）调整为0x00，自动获取，在demo测试界面，增加GCT和SID的参数设置，一般默认就好。
10. FanucSeries0i: 读取R数据的接口重新设计，修改为ReadPMCData，地址支持G,F,Y,X,A,R,T,K,C,D,E 例如R1200，写入也是一样，具体看demo演示。
11. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
12. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
		MessageBox.Show( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
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
