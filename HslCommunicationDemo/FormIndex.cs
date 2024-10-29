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
			textBox1.Text = @"V12.1.2
1. FujiSPBServer: DataFormat属性值修改为和客户端一致，DEMO界面上可以调整该值，修复英文界面下显示文本不正确的问题。
2. XinJEServer: 支持输入 D，SD, HD 格式的地址，针对客户端使用XinJE专用协议的时候有效，如果用modbus协议的客户端，则还是输入modbus的地址
3. SiemensS7Helper: 修复写入字符串的方法里，判断字节长度超出PLC最大设置定值时，字符串长度获取不正确的bug。
4. MqttClient: 新增加一个属性 Tag, 可以用来携带任意的自定义对象，方便客户端做一些个性化的处理。
5. Melsec: 三菱MC协议增加错误码17165的错误描述及解决办法，解决办法是将用户认证功能设置为禁用。
6. LogNet: 日志类方法HslMessageFormat修改为虚方法，重写这个方法即可以实现存储时自定义的格式，DEMO界面在英文模式下显示英文，显示按钮的代码。
7. MQTTServer: 新增方法UnRegisterMqttRpcApi用于卸载当前已经注册的指定接口，方便用于动态控制接口，此处的卸载是批量的。
8. HttpServer: 新增方法UnRegisterHttpRpcApi用于卸载当前已经注册的某些接口，重复注册的时候将会覆盖旧的接口内容。
9. SimpleHybirdLock: 新增进入锁的时间，当获取锁对象字符串的时候，输出当前锁的状态以及占用锁的时间。
10. MqttServer: 修复ClientVerification事件签名里密码单词拼写不正确的bug。
11. OmronFinsServer: 欧姆龙的FINS虚拟服务器支持了客户端使用 E9 这种地址的数据读写操作，不过所有的EM地址，E地址都使用同一个数据块。
12. SecsServer: Secs服务器日志记录改为直接记录原始二进制的报文，修复服务器创建中文字符串格式的SecsValue时，长度显示不正确的bug。
13. DLT645Server: 修复当StationMatch属性为true时，无论站号是否匹配都返回的bug，现在只有站号一直才支持读写数据操作。
14. HslDeviceAddressAttribute: 新增字符串编码的属性，当类型是字符串有效，支持字符串数组，修复长度为0时应用于西门子读取字符串时读取字符串不正确的bug。
15. Inovance: 汇川的PLC在AM系列下，读取MB1005单数地址的字符串时，也支持进行读取操作。
16. IModbus: 所有Modbus设备新增属性BroadcastStation，设置0-255后，使用该站号时将不检测返回的报文，直接返回成功，ModbusServer适配站号0不返回数据。
17. OmronFinsUdp: 属性SID信息不再进行自增操作，将由用户手动设置，然后demo界面支持手动设置操作。
18. Demo: 批量读取的界面，新增是否字反转操作，方便部分的PLC可以看到一些特殊的数据情况。
19. Demo: Secs服务器英文界面优化，西门子Smart200测试界面增加随机写入测试，并直接输出示例代码。
20. Demo: MQTT测试界面增加正则过滤功能。设备类的测试界面添加数据模拟的功能，可以写入一些脚本实现的规律数据。
21. Demo: HttpClient测试界面的ContentType修改为可输入。Secs界面修复英文环境下，标签名称不正确的问题
22. Demo: 设备测试界面的读取功能，支持勾选屏蔽重复的值，只有数据变化的时候，才在读取界面里显示，重复就显示重复次数，菜单调试下新增设置显示毫秒时间的功能。
23. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
24. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
