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
			textBox1.Text = @"V12.8.3
1. OmronFinsUdp: 属性SID信息改为自增的属性，每次读写数据的时候进行自增操作，最大为255，然后重置为0，继续自增操作。
2. Authorization: 激活方法SetAuthorizationCode检测传入的激活码，如果长度大于100，则使用证书激活的方式，并返回激活是否成功。
3. MqttClient: 连接参数类MqttConnectionOptions新增属性LocalBinding，可以用来绑定本机的ip或是端口号，Demo界面新增一个more标签用来设置更多的信息。
4. ILogNet: 日志接口及对象新增属性MaxCacheCount，用于控制临时缓存队列的最大数量，默认为1000万，超出该值时将会丢弃最新的日志，防止极端情况崩溃。
5. FtpServer: Ftp服务器在客户端上传文件的时候，如果文件已经存在，先判断文件是否有写入权限再执行实际上传操作。
6. FtpClient: FTP客户端在上传或下载文件的时候，最终传输数据完成的时候，再次判断是否5XX错误码，从而修复某些特殊的情况提示上传成功但是实际失败的异常。
7. MelsecA1E: 修复二进制及ASCII格式的协议，使用字读取位地址时，当长度很大导致分批次读取时，后面的偏移地址不正确的bug。
8. PipeSerialPort: 串口管道SleepTime优化，当接收数据的前五次循环里，使用十分之一的SleepTime值来休眠，兼顾回复数据比较快的设备，可以快速收到数据。
9. Demo: Demo程序里的台达，汇川，信捷测试界面，连接成功后，系列的下拉框调整为禁用，断开连接后可以重新选择。
10. Demo: 数据点位表控件如果配置了单个byte类型的数据之后，修复双击写入时，对于西门子S7协议等支持单个byte读写的情况，仍然提示失败的bug。
11. Demo: 修复企业用户专属的证书界面，当查看已经注册的证书的时候，实际的起始日期，结束日期显示不正确的bug。
12. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
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
