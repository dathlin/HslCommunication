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
			textBox1.Text = @"V12.8.2
1. PipeMqttClient: 修复MQTT管道再一开始连接MQTT失败的时候，设置管道的时候，直接发生异常的bug，现在还同时支持了断线重连恢复的功能。
2. PipeMqttClient: 修复MQTT管道在异步通信的情况下，直接调用接收数据得方法，但是提示功能未实现得bug。
3. CimonServer: 修复Cimon协议虚拟服务器读写F, Z, S地址不正常的bug，还支持了数据块的存储，重新加载的功能。
4. HslStruct: 读取原始字节自动解析结构体的特性里，针对bool类型数值及数组，支持了设置BoolMode属性，表示解析bool时是否根据字反转再解析操作。
5. FanucSeries0i: fanuc机床类新增SetCurrentProgram设置主程序重载方法，传入路径字符串，例如//CNC_MEM/USER/PATH1/O000，新增Reset重置方法，Demo界面直接测试。
6. MemobusTcpServer: 支持了远程客户端针对G地址的bool读写操作，服务器端也支持了对G地址的bool读写，地址示例: G100.0
7. CJT188Helper: CJT188协议修复读取失败的问题，Demo界面增加数据列表显示，可以方便的显示当前常用的数据及单位信息，串口及串口透传类均优化。
8. SiemensS7Plus: 标签是非结构体的数组的时候，支持了索引地址访问，例如 ""A"".""B""[1]，Demo界面浏览标签列表时，选中非结构体数组时，支持显示结构体列表信息。
9. Doc: 官网的在线文档增加 ReadStruct 针对bool属性位偏移的解释说明，针对SiemensS7Plus协议读写数组的功能说明。
10. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
11. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权";
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
		DemoUtils.ShowMessage( " + "\"授权失败！当前程序只能使用24小时！\"" + @" );
		return; // 激活失败就退出系统
	}

	// English For example
	if(!HslCommunication.Authorization.SetAuthorizationCode( " + "\"Your Active Code\"" + @" ))
	{
		DemoUtils.ShowMessage( " + "\"Active Failed! it can only use 24 hours\"" + @" );
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

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel2.Text );
		}
	}
}
