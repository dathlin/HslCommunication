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
			textBox1.Text = @"V12.3.3
1. DLT645的1997及2007协议新增属性CheckDataId，默认为true，表示检查读取返回报文中的数据ID信息，修复在某些特殊情况下报文接收不正确的bug。
2. 新增DLT1997的虚拟服务器类DLT645With1997Server，支持常见地址的写入读取，修复DLT1997写入数据时报文组包不正常的bug，现在可以正确的写入。
3. OmronCipServer: 修复欧姆龙CIP虚拟服务器在相应基于连接的CIP协议报文时，针对数组索引访问时，返回数据的bug，之前会全部返回，现在只返回读取的数据。
4. CIPServer，包含ab的CIP服务器及欧姆龙的CIP服务器，在返回客户端报文时，复制客户端的context数据头内容，然后直接返回给客户端。
5. Omron: 修复OmronHostLink协议，FinsTcpNet，FinsUdp类在读写DR, IR地址的bool数据时，读写数据表现不正确的bug。
6. Modbus: 所有modbus测试界面功能里，新增站号搜索功能，自动的发报文匹配对应站号，包括tcp.rtu, ascii,及其透传模式都支持测试，直接搜索站号 0 - 255方便快速查找。
7. PanasonicHelper: 松下的PLC地址 DT 区的地址同时支持 D100， DT100 两种表示方式，表示同一个地址。
8. AllenBradleyNet: 新增属性ContextCheck，默认false，当设置true的时候，将自增Senderontext属性当为消息id，接收消息匹配处理。
9. 优化网络socket在异步接收数据的时候，频繁创建方法委托实例的小问题，在很多PLC同时高频通信的时候，会存在句柄持续增大的问题。
10. ToyoPuc: 支持了bool数组的写入，支持了prg=1;M102 开头的地址的bool写入功能，通过读字修改位，写字来实现。
11. ModbusTcpNet: 新增属性 StationCheckMacth 表示是否对站号进行检查操作。消息接收优化，支持某些特殊的不规范的消息结构报文。
12. AllenBradleyNet: AB的PLC新增属性ReadArrayUseSegment，表示当读取数组的时候，是否使用52片段功能码读取，默认为true，表示使用52功能码。
13. KeyenceNano: 针对基恩士的上位链路协议的DM,CM,EM,FM,ZF,VM这种字地址支持了位读写操作，格式为 DM100.0 这种带小数点，然后bool读写操作。
14. DTU: DEMO中DTU的默认端口调整为10010，支持了长度信息使用ASCII字符表示，注册包支持输出ASCII字符，方便部分只支持ASCII配置的DTU设备。
15. Demo: 虚拟PLC的数据存储加载代码优化，然后DEMO测试上支持定时存储虚拟PLC的数据到文件。
16. Demo: DEMO界面的DEBUG界面优化了显示数据，显示了发送数据次数，接收数据次数信息，压力测试控件界面优化。
17. Demo: 新增加一个PING ip地址的测试界面，可以设置线程数量来快速确定可以访问的，在线的ip地址。
18. Demo：曲线界面优化，数据表界面支持设置曲线颜色，样式，粗细。纯曲线界面支持对多个曲线设置颜色，样式，粗细。
19. Demo: demo菜单新增一个选项，是否固定测试界面大小，当程序运行在分辨率特别低的显示器的时候，可以设置该属性来显示滚动条。
20. Demo: 所有的通信测试界面优化，当测试通信的窗体在没有正常关闭连接的情况下，直接点击叉号关闭PLC测试界面，原来的连接会被自动的关闭，服务器也会自动的关闭端口。
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
	}
}
