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
			textBox1.Text = @"V12.3.2
1. LogNetBase: 优化了日志组件在设置属性ConsoleOutput输出到控制台时的性能，减少颜色重复设置，连续日志批量输出，输出性能增加5倍以上。
2. EcFanMachine: 新增一个特殊的协议EcFanMachine: FFU 用EC 风机风机通信协议，支持风机的转速控制，风机的地址设置，风机的状态读取等功能
3. EmergencyState: 风机对象优化，读取数据时支持返回应急状态，然后DEMO优化，MQTT服务器界面主题优化，AB-CIP读取显示类型备注。
4. ILogNet: 日志接口接口ILogNet新增属性ConsoleColorEnable，默认为true，表示控制台输出时不同等级日志颜色不一样，设置false关闭颜色。
5. LogNetManagment: 日志按照时间及大小存储时的文件名的开头字符串信息可以修改，设置属性 LogFileHeadString 即可。
6. MelsecFxSerialServer: 新增对05报文的的回复，新增对客户端修改波特率的命令的支持，根据客户端的命令来自动设置波特率。
7. InovanceSeries: 汇川的系列新增子系列 Easy，但是实际的modbus地址映射和H5U是一致的，DEMO界面可以选择新添加的系列内容。
8. LogNetBase: 日志基础类，修复在存储日志信息到文件的时候，如果文件的目录被删除导致日志存储不会恢复的bug，现在会自动重新创建文件夹。
9. InovanceHelper: 汇川AM系列支持bool读取MD地址，例如 MD100.0  等同于 MW200.0 地址
10. S7Message: 西门子S7协议在接收PLC返回的报文的时候，新增对报文的消息id检查操作，检查和发送是否一致，虚拟服务器配套修改。
11. DEMO: demo上写入数据的测试方法支持了地址重复的情况，例如想写100个short全部都是0的数组，地址里输入 [0*100] 即可。
12. DEMO: demo读写byte,short,ushort,int,uint,long,ulong类型时，支持使用16进制的数据格式读写，使用16进制时，暂时只支持正整数。
13. Demo: Demo界面上设备的读写测试界面新增一个小框框，点击可以隐藏读写按钮测试界面，让特殊功能测试界面最大化。
14. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn/Doc/HslCommunication
15. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
