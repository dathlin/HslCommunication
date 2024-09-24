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
			textBox1.Text = @"V12.1.1
1. DeviceSerialPort: 修复当设置了非PipeSerialPort串口管道的时候，调用 IsOpen( ) 结果返回不正确的bug。
2. DeviceServer: 新增方法 ServerStart( int tcpPort, int udpPort ), 用来同时启动TCP服务和UDP服务，三菱的DEMO测试增加启动功能测试。
3. CommunicationServer: 修复服务器的类再只启动UDP服务器的情况下，服务器侧进行关闭操作时，引发后台线程异常的bug。
4. MqttServer: 当客户端连接上来的时候，指定了keepAlive后，客户端的ActiveTimeSpan调整为1.5倍的keepAlive值，防止其他客户端极其特殊情况下可能误判下线。
5. DLT645: DLT645-2007的串口网口类新增跳闸方法Trip( DateTime validTime )及合闸允许方法SwitchingOn( DateTime validTime )
6. LSCnet: 进行了优化，全部使用连续读取的功能实现，添加携带站号的接口IReadWriteDeviceStation， LSCnet实现了该接口。
7. SecsValue: 新增加ToSourceCode( )方法，获取获取该对象的源代码表示方式，用于DEMO程序自动生成发数据的源代码。
8. Demo: 在PLC测试界面上的管道的功能当选择了DTU管道时，设备连接上来的时候，修复ID匹配不正确的bug。
9. Demo: PLC测试界面上的读写按钮操作，都会在下面的示例代码里面显示出实际的代码情况，一些特殊功能测试的界面全部添加点击按钮生成示例代码，包括机床，机器人界面。
10. SecsGem: Secs的服务器测试界面和客户端测试界面，功能码列表均支持了编辑和添加删除，然后点击保存连接的时候，自动将全部的功能码列表进行了存储，方便后续测试。
11. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
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
