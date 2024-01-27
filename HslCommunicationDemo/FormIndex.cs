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
			textBox1.Text = @"V11.8.0
1. SiemensS7Server: 西门子PLC的虚拟服务器，当客户端连接的时候握手报文也进行输出到日志上面。
2. OpenProtocolNet: 新增属性RevisonOnConnected，用来设置连接初始化时的MID0001的revison信息，如果小于0，初始化连接时则不使用MID0001
3. AdsHelper: 倍福的ADS协议里的部分错误码提示的消息附带一些建议的解决方法，可以快速查找问题。
4. SiemensS7Helper: s7协议里如果执行写入wstring类型的字符串时，当检测到字符串最大长度为0时，自动分配254长度的字符串。
5. MC1EServer: MC协议的虚拟服务器及MC1EServer的虚拟服务器支持了S0,F0 地址，也支持远程客户端读写该地址。
6. MqttRpc: 在Mqtt服务器注册了RPC服务器接口后，当注册的自定义的接口方法本身发生异常时，增加提供原始异常相关的本文及堆栈信息。
7. SiemensS7Net: S7协议新增对地址 SM0.0 的支持，在200系列上测试成功。 新增 PIW0,  PQW0 外设地址，在S7-300上测试成功。
8. HslReflectionHelper: 解析HslStructAttribute特性时，类型为字符串时，修复编码为GB2312，但是编码设置异常的bug，现在自动忽略大小写。
9. OmronFinsTcpServer: 虚拟PLC支持了CF地址及DR地址类型的读写操作。
10. OmronCipServer: 当服务器创建了bool[]数组的标签时，修复客户端读写该标签不一致的bug。
11. IEC104: 104规约总召唤方法的传送原因默认值改为06，新增属性Station表示单元公共地址，并在DEMO上可设置。
12. ABBWebApiClient: abb机器人代码优化精简，部分接口自动解析更多的数据，demo测试界面显示优化，同时显示解析结果和html文本。
13. OmronFinsUdp: 报文里的SID字段每次通信将自增1，然后校验返回报文是否一致，虚拟服务器适配客户端。
14. OmronFinsNetHelper: Fins协议针对EndCode结束码判断增加网络异常标记位判断，直接返回读写失败及错误消息。
15. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
16. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
