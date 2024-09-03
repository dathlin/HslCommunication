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
			textBox1.Text = @"V12.1.0
1. FanucRobotServer: 修复客户端读取M,I,Q数据区的时候，服务器从内存数据区取数据时偏移量不正确的bug。
2. SecsHsmsServer: 新增属性DeviceId，当调用方法 PublishSecsMessage 时使用该属性指定的设备ID信息来主动发送客户端。
3. OmronFinsServer: 虚拟PLC支持了读取plc型号及plc状态的功能码，修复如果遇到不支持的功能码时候直接奔溃的bug，现在返回错误的命令。
4. FanucSeries0i: 新增加接口读取刀组寿命ReadToolInfoByGroup，读取正在使用的刀组号ReadUseToolGroupId，以及清除刀组ClearToolGroup。
5. HttpServer: 注册API接口时从之前的只支持GET/POST的方式，现在可以随意的支持其他的文本了，例如PUT
6. DeviceServer: 虚拟服务器基类针对ReadFromCoreServer进行异常捕获，避免一些特殊情况下乱七八糟的数据导致虚拟服务异常奔溃。
7. FormLogNetView: 新增属性OpenDialogDefaultPath，设置一个路径后，日志窗体点击打开文件时，将会默认打开该路径。
8. SoftAuthorize: 授权相关类的实例化方法新增参数useHDD用来指示是否使用HDD参数信息，设置false可以避免插拔U盘导致机器码变化。
9. Dtu: 重新设计的DTU功能，新增DTU管道，支持TCP,UDP,串口的设备直接变为DTU模式的设备，并直接支持从云上访问，原先的TCP管道删除AlienSession属性。
10. DEMO界面的管道新增DTU管道选择，可以直接测试，TCP,串口调试界面支持直接转转远程DTU，文档地址：http://www.hsltechnology.cn/Doc/HslCommunication?chapter=HslCommChapter4-18
11. CommunicationServer: 新增属性SessionsMax，用来设置服务器当前支持的最大会话数量，默认为uint.MaxValue
12. Inovance: 汇川的AM系列的modbus地址，支持 MB100 地址，内部将自动转为字地址，所以必须为偶数开头。
13. HttpServer: 新增方法UseHttps( )用来启动https，具体文档参考：http://www.hsltechnology.cn/Doc/HslCommunication?chapter=HslCommChapter6-5
14. SiemensS7: S7虚拟服务器模拟真实PLC，读取结果数据大于226字节时返回错误码，优化SiemensS7Net的离散读取方法，现在地址传入任意个数或是任意长度，就能正确的分割读取，然后结果合并。
15. DeviceSerialPort: 修复串口设备基类里，当管道设置了非PipeSerialPort串口管道时，调用打开方法Open()时，仍然打开原串口的bug。
16. PipeMoxa: 新增一个基于MOXA公司开发的串口库的一个串口管道，在某些情况下比微软官方自带的串口好用，具体参考官网文档。
17. MqttHelper: 直接捕获ParseMqttClientApplicationMessage解析的异常，防止一些乱七八糟情况下报文不对导致直接程序奔溃的bug。
18. DEMO: 西门子的测试界面的时间，字符串等读写按钮增加光标悬停提示，提示调用的方法名称，方便大家使用。
19. Demo: 修复创建示例代码功能中，如果碰到PipeTcpNet管道时，如果属性UseServerActivePush为true时，示例代码没有生成该文本的bug。
20. Demo: 修复TCP、UDP调试界面下，当使用了定时发送之后，远程连接强制断开后，一直提示会话为空的bug。
21. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
22. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
