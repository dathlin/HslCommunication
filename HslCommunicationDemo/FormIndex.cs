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
			textBox1.Text = @"V11.3.2
1. WebsocketServer: 在发布Topic数据的时候，新增一个API，允许指定reatain属性，如果不指定，则用对象自己的设置。
2. InovanceHelper:汇川读取byte的方法新增错误异常捕获，返回失败的说明信息。
3. SiemensS7Server: 修复虚拟服务器在接收远程客户端的写入定时器，计数器时，地址偏移不正确的bug。
4. modbus: 当调用地址为 x=1;100 进行写入bool数据的时候，修复功能码不会自动修正为正确的默认功能码的bug。适用于 rtu, tcp, rtu overTcp
5. BeckhoffAdsServer: 修复当远程客户端读取M100.0 的bool类型时，指定长度大于1时，返回数据不正确的bug。
6. BeckhoffAdsNet: 修复在读写I,Q地址类型时，初始偏移位置不正确的bug，无论是字读写，还是位读写都测试通过。虚拟PLC侧自动识别偏移地址。
7. DLT645: 修复DLT645的1997及2007版本串口通信时，在某些特殊情况下通信速度慢导致接收数据长度不够引发异常的bug。
8. MegMeet: 新增麦格米特的PLC的通信类，底层使用Modbus协议，支持串口，网口，支持系列：MC80/MC100/MC200/MC280/MC200E
9. KeyenceDLEN1: 新增基恩士的以太网模块通信协议实现，主要用于各种传感器的数据读写操作，提供DEMO测试。
10. NetworkBase: NetworkBase基础通信基类，新增了一些基于SSL加密通信的报文收发的方法支持。
11. MqttClient: MqttClient支持了使用证书的方式进行通信，设置MqttConnectionOptions.CertificateFile为证书路径即可实现证书加密及校验，已和EMQX测试通过。
12. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
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
