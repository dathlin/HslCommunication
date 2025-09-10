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
			textBox1.Text = @"V12.5.0
1. SiemensS7Server: 修复当客户端读取位的方式，读取不存在的DB块的时候，没有返回的异常，现在返回DB块不存在的消息。
2. Modbus: Modbus相关的协议类的属性StationCheckMatch，修复单次拼写错误，之前的是StationCheckMacth，如有使用该属性，升级时需要注意。
3. MelsecMcNet: 三菱的属性EnableWriteBitToWordRegister默认值调整为 true, DEMO界面的选项也自动为 true，可以写位到字寄存器地址。
4. WebSocketServer: 新增方法public void SendClientPayload( WebSocketSession session, byte[] payload ) 用来发送 byte[] 数据。
5. ModbusRtu: 优化RTU消息完整性校验的代码，现在支持了报文前面即使有三个干扰字节，也可以正确的识别报文并正确的提炼出数据。
6. IModbus: 新增属性DisableFunctionCode06，表示禁用功能码06，禁用之后使用10功能码来写入short, ushort 数据。
7. IEC104: 修复写入归一化设定值异常的bug，对应的IEC104虚拟服务器支持了单点遥控，双点遥控，归一化，标度化，短浮点，32位比特串的写入操作，并增加最大地址范围设置。
8. AllenBradleyNet: 在握手报文阶段，当碰到设备错误码1的时候，不再直接关闭返回，而是视为成功，继续操作，部分的PLC是可以继续通信的。
9. HttpServer: 新增一个启动的重载方法 public void Start( string prefix ), 可以输入 http://127.0.0.1:8000/ 来启动服务器。
10. NetPlainSocket: 优化普通客户端类，针对高频接收可能发生的数据错乱做了优化，新增byte[]的收发方法，官网完善相关的文档信息。
11. IDlt645: DLT645接口新增修改波特率的方法ChangeBaudRate，相关DEMO界面增加该测试功能，虚拟服务器支持这个功能码测试。
12. YRCHighEthernet: 新增加一个读取位置型变量的方法ReadPositionVariable，相关的测试界面添加测试功能。
13. DeviceServer: 包括基类CommunicationTcpServer新增属性LocalAddress，用于服务器端绑定本地的ip地址来启动服务，DEMO里所有的服务器界面调整优化。
14. AllenBradleyNet: 修复写入空字符串时实际成功，提醒失败的bug，修复CIPServer服务器返回数据报文命令头不匹配的bug。
15. LogNetDateTime: 时间日期存储的日志，路径地址支持输入格式化信息，达到动态的效果，具体参考官网。
16. Demo: Demo界面的点位变量监视表里，修复右键删除指定行不动作的问题，现在可以批量选择删除。JSON测试界面新增替换测试功能。
17. Demo: Demo界面新增企业用户相关的支持证书发布的功能，允许企业用户自己注册及发布证书，该证书可用于激活C#版及Java版本的hslcommunication。
18. Demo: 当测试界面写入数组数据到地址里的时候，修复生成的示例代码不正确的bug，涉及所有类型的数组写入操作。
19. Demo: 修复CIP协议特殊功能测试的界面，读取显示数据类型的时候，点击写入之后，提示类型错误的小bug。
20. Demo: 修复测试界面 DTU报文生成时，选中ASCII格式时，并且DTU的id小于11位数字的时候，创建的ASCII的注册包的显示异常问题。
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
