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
			textBox1.Text = @"V11.0.2
1. LogNet: 修复日志对象在配置了LogThreadID=False时，控制台输出界面仍然显示线程号信息的bug。
2. AllenBradleyServer: 新增属性CreateTagWithWrite，当手动设置为true时，从服务器端写入不存在的标签将根据写入的类型自动创建标签。
3. NetworkUdpBase: udp的通信基类修复某些设备通信情况下每9次通信就会跟随一次失败的bug，原因来自不停的创建socket，现在修改为连接正常就不重新创建socket
4. AllenBradleyServer: ab虚拟plc修复写入short的类型分配不正确的bug，并且增加一个创建byte字节数组的标签的方法接口。
5. AllenBradleyNet: 修复同步方法ReadString(string address); 读取字符串返回数据乱码的bug，原因来自调用了基类的字符串解析。
6. DLT645: 大面积优化，支持了更多的地址读取，支持了一个地址多个数据读取，修复了部分数据(如电流，功率因数等)不识别正负号的bug。
7. PipeSocket: 端口号信息由int型调整为数组，使用SetMultiPorts方法可以设置多个端口号信息，当PLC对象重连时，就会切换端口号，循环反复使用指定的端口号信息。
8. PipeSocket: 多端口号使用方法为 plc.GetPipeSocket( ).SetMultiPorts( new int[] {6000, 6001} ); 实例化之后调用一次即可。
9. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
10. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
