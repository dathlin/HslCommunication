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
			textBox1.Text = @"V12.8.1
1. ModbusRtuOverTcp: 修复ModbusRtuOverTcp里属性StationCheckMatch拼写不正确的bug，如有使用，升级的时候修改下名称。
2. MelsecHelper: 修复三菱MC协议的ASCII格式通信类下，输入ZR地址后生成报文时实际进制不正确的bug，Server端也适配了解析十六进制地址报文。实际输入还是十进制。
3. OrientalMotorEipNet: 新增加东方马达的基于连接的隐式IO-EIP通信协议，可以和马达/机器人控制器通信，demo界面显示可以读写的数据块，方便操作。
4. SiemensS7Plus: 修复大部分PLC型号读取失败的bug，修复数据解析不正确的bug，修复写入成功后再读取失败的bug，Demo界面优化，支持映射地址读取。
5. SiemensS7Plus: 修复SiemensS7Plus类针对结构体嵌套时，点位的字符串地址，物理地址映射不正确的bug，新增属性BrowseTagNameOnConnect, 默认为false
6. SiemensS7Plus: 修复方法名单词拼写错误的问题，BrowerDB 方法名修改为 BrowseDB 方法名。
7. MemobusTcpServer: 支持了G地址的数据，支持了客户端远程读写G地址，例如 G100
8. TcpForward: 新增属性OnlyShowLength用来表示记录报文数据时，是否只存储保存长度信息，方便测试，修复DEMO界面上输入错误的ip地址，直接崩溃的bug。
9. LogBase: 优化存储日志信息到文件的代码，提高缓存队列有很多日志情况的效率。
10. WebsocketServer: websocket服务器支持了部分浏览器因为跨域的问题，导致连接失败的问题，将检测请求头的Origin属性，并返回允许连接的信息给客户端。
11. Active: 激活部分的代码优化，提升了激活的性能，在某些特殊的系统情况下，激活耗时大幅度下降。
12. Demo: 开始设备定时读写时增加提示成功，失败次数，菜单设置新增'定时读写失败继续'，勾选后，失败不在停止弹窗，继续读写操作。
13. Demo: 修复双击节点展开等非设备节点的位置，也会打开PLC设备协议窗体的bug。
14. Demo: 地址示例的控件优化，当传入字典地址示例时，自动根据关键字创建单选框，切换选择时，自动切换不同的地址示例表，方便大量地址归类，检索。
15. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
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
