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
			textBox1.Text = @"V11.7.0
1. SiemensS7Net: 西门子的用于计数的消息id在重连plc的时候，自动重置为1，然后重新开始计数。
2. DLT645: DLT645协议新增对返回的站号检查是否一致的功能，如果刚好站号倒序，则也认为一致。优化消息接收，即使报文前面跟了几个字节的无用信息。
3. ModbusRtuOverTcp: 优化通信机制，对于单次接收的报文支持了更多的容错，如果CRC校验失败，不再关闭当前的socket连接操作。
4. MqttServer: 当客户端订阅一个主题之后，如果这个主题属于消息驻留的主题，给当前客户端返回的消息里增加Retain=true标记，方便客户端标记。
5. MqttServer: 注册MRPC的接口时，如果之前已经有相关的接口注册，现在改为直接覆盖，然后变量参数名自动适配 value 和 values，这两个没找到就相互替换名称。
6. DLT645Server: 新增DLT645-2007协议虚拟仪表实现，支持一些常见的数据的简单测试，例如电压，电流，频率，时间等信息。
7. Newtonsoft.Json, NET20项目，NET35项目，NET451项目对JSON库的引用调整SpecificVersion为 False
8. Demo: 地址示例的表格支持右键弹出上下文菜单，点击复制地址，即可复制当前的地址信息。
9. Demo: 数据点位表控件DataTableControl修复虚拟服务器不能刷新数据的bug，新增了双击值表格写入数据的功能。
10. Demo: 修复DEMO服务器的部分ip地址获取网址解析不出数据的bug，所有的襄阳地址均改为襄樊，方便旧版地址显示。
11. MqttClient: 不兼容更新，收到MQTT的事件签名OnMqttMessageReceived修改为MqttMessageReceiveDelegate( MqttClient client, MqttApplicationMessage message );支持携带Retain信息。
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
