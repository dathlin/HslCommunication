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
			textBox1.Text = @"V13.0.0
1. OperateResult: 操作结果类新增属性 Tag，用于绑定自定义的任意对象，相当于轻松携带多数据返回结果。
2. OpenProtocolNet: 优化报文的数据接收，当出现接收到乱七八糟的报文数据时候，进行日志记录，修复直接程序崩溃的bug。
3. BinaryCommunication: 所有通信设备的基类里，添加属性AutoReConnect，表示在链接断开后，下次读写是否进行自动重连操作，默认为true，Demo界面支持配置测试。
4. ModbusTcpServer: 修复0x17功能码时读写存在异常时，结果客户端仍然成功的bug，优化0x15写入数据到文件区时，返回客户端报文规则和Modbus官方约定不一致的问题。
5. OpenProtocolNet: 当收到设备推送的订阅的数据以及返回数据的时候，也进行报文的记录，然后优化示例代码的生成，输出事件及连接的代码。
6. MelsecA3CNet: 三菱的串口的A3C类新增消息完整性验证，防止部分情况读取大量地址数据的时候只接收部分的bug，以及报文日志记录调整为ASCII。
7. Melsec: 新增加三菱的4C帧协议实现，包含MelsecA4CNet，MelsecA4CNetOverTcp 类，已经对应的服务器 MelsecA4CServer，支持格式1，2，3，4，5，支持是否和校验。
8. LsisServer: 修复客户端读写MX1000地址解析不一样的bug，修复客户端读取很长的地址数据，返回的报文长度信息不正确的bug。增加单元测试。
9. CommunicationServer: 优化虚拟设备的串口从站接收数据的逻辑，没有接收到数据指定时间再算超时，优化MelsecA3CServer及MelsecA4CServer数据包完整性的判断。
10. MelsecFxSerial: 三菱的编程口协议里，配置新版协议时，执行写入bool数组到位继电器的时候，调整为读字修改位写字操作，这样就可以支持任意长度的数据写入操作。3U上测试成功。
11. NetSupport: 优化异步的数据接收和发送方法，改为BeginReceive来实现，提升在高并发下频繁通信时的性能及稳定性表现，异步超时部分的内容采用双重保证。
12. HslCommunication: 大量的PLC协议类优化，代码精简，添加完善的单元测试，并且测试通过，NET20,NET35,NET Standard项目添加缺失得InovanceEasyNetServer类，之前忘记添加了。
13. DevicePluginNet: 新增插件设备类，用户只需要开发自己的dll，实现几个方法就可以实现一个插件，并且导入到Demo测试工具里测试和使用。
14. HslcommunicationSkill: 推出全新的skill，只要从官网下载skill安装到智能体里面，立即化身hslcommunication专家，回答各种问题或是帮助写hsl标准代码。
15. Demo: PLC设备测试完整报文通信的时候，支持选择HEX格式报文或是ASCII报文，方便部分ASCII格式通信的协议进行完整的报文通信。
16. Demo: Demo程序在生成PLC的实例化代码的时候，顺便生成连接方法，主要针对TCP及串口的情况生成连接PLC或是打开串口的代码，方便参考。
17. Demo: TCP/UDP/串口 调试的界面，在数据显示区域的右侧新增加一个搜索框，支持对数据显示区的数据搜索操作，从上到下，直接结束为止。
18. Demo: 顶部菜单栏新增加插件市场，可以在插件市场搜索上传的插件，然后企业用户（后续开放个人用户）可以上传插件到市场方便其他人下载。
19. Demo: Demo新增加MCP服务，只要开启服务后，连接设备成功，AI智能体使用skill就可以从demo获取到PLC真实的数据，从而进行AI善长的领域数据分析。
20. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
21. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
