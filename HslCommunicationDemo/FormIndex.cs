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
			textBox1.Text = @"V11.2.0
1. SoftBasic: 新增对url字符串编码和解码的方法，UrlEncode及UrlDecode方法，主要是中文和%开头的互转，代码参考微软实现。例如 AB好 和 AB%E5%A5%BD 互转
2. HttpServer: 新增委托HandleFileUpload，当客户端上传文件时触发，然后获取到文件名和内容，可以自己进行存储，目前仅支持单个文件上传。
3. DLT645-2007: 网口串口代码优化，相同的逻辑代码提炼，并增加属性 DLTType，返回枚举：DLT645Type.DLT2007
4. DLT645With1997: 新增 DLT645/1997 协议的实现，使用ReadDouble来读取相关的数据，例如地址：B6-11 读取电压A数据。
5. DLT645With1997OverTcp: 新增 DLT645/1997 网口透传实现的版本，使用TCP/IP通信并数据交互，使用方法和 DLT645With1997 一致。
6. SiemensPPI: 优化西门子PPI协议数据接收时完整性判断，数据一旦接收完成，立即返回。因为在某些特殊情况下，数据接收不完整时会发生异常。
7. SiemensPPIOverTcp: 接收数据时循环接收，并判断数据完整性，数据一旦接收完成，立即返回，增加循环超时时间，为ReceiveTimeout。
8. CJT188: 新增CJT188-2004的水表（燃气表）协议，使用ReadDouble 和 ReadStringArray通信，地址示例：90-1F读取当前的累积流量，同时添加网口透传的版本。
9. FanucSeries0i: fanuc的机床新增属性OperatePath，默认为1，当机床为多路径的时候，可以设置为2，然后对路径2进行相关的操作，例如读取报警，读取程序。
10. MqttServer: 优化安全性，当没有指定RSA密钥时，针对每个连接的客户端对象，都创建随机的RSA密钥，来提升安全性。
11. ILogNet: 日志类接口新增属性HourDeviation，如果需要日志记录时进行时间偏移操作，可以设置该属性实现，如果为-8，就是所有时间往前挪8小时。
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
