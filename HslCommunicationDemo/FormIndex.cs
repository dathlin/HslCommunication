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
			textBox1.Text = @"V9.5.0
1. AllenBradleyNet: ReadBool方法默认读取单bool类型变量，如果要读取int类型的bool数组，采用""i=""开头表示，例如""i=A[10]""
2. NetworkDataServerBase: 新增一个属性ActiveTimeSpan，可以设置激活时间间隔，默认24小时，锁优化，其他的继承实现的服务器都进行了设置。
3. NetworkDeviceBase: Read<T>修改为虚方法，支持继承进行重写，基于特性的类注释完善。
4. Siemenss7net: ReadString(string address, ushort length)读取字符串时，如果长度为0，就读取西门子格式的字符串。
5. OperateResult: 扩充泛型方法，Check, Convert, Then，实现了结果链，简化代码。参考：https://www.cnblogs.com/dathlin/p/13863115.html
6. FanucSeries0i: 修复数控机床在读取0i-mf状态时导致长度不够的bug。
7. IReadWriteNet: 新增wait方法接口，用于等待一些信号到达指定的值，支持扫描频率设置，超时设置。例如 Wait(""M100.0"", true, 500, 10000)等待这个信号为true为止。
8. MqttServer: 支持调用ReportOperateResult返回错误信息及错误码给客户端，MqttSyncClient会自动识别报文，然后IsSuccess自动适应，网络不会断开。
9. MqttSyncClient: 支持设置接收超时时间，默认是60秒，之前是5秒，而且不能更改。
10. MqttServer: 支持注册远程RPC的API接口，自动解析json参数，自动调用已经注册的接口自动返回是否成功，MqttSyncClient也支持遍历服务器的接口列表。详细：https://www.cnblogs.com/dathlin/p/13864866.html
11. SiemensS7Net: 通信类实现ReadBool(""M100"", 10); 批量读bool方法，通过读Byte间接实现。
12. OmronHostLinkCModeOverTcp: 新增欧姆龙的通讯类，Cmode模式的以太网透传实现。
13. PLC: 所以的PLC实现了HslMqttApi特性支持，从而在MqttServer里可以直接注册，然后对外开放读写接口操作。
14. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
