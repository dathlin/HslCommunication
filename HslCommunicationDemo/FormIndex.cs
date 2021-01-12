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
			textBox1.Text = @"V9.6.1
1. Lsis XGK: 修复部分的问题，感谢埃及朋友提供的支持。
2. FujiSPB: 修复未在net20, net35, net standard项目里添加的bug。
3. MqttServer和HttpServer: 注册API的方法支持对静态方法的注册，注册时传入类型对象即可。
4. Modbus: tcp, rtu, ascii, rtu over tcp在读写int,uint,float,double,long,ulong时支持动态指定dataformat，地址示例：format=BADC;100
5. MqttServer: 扩展MQTT的子协议FILE，支持文件的上传，下载，删除，查看信息，权限控制操作，支持获取上传下载网速监控。
6. MqttSyncClient: 扩展文件的方法接口，支持上传，下载，删除，遍历文件操作，每个操作都是短连接的，使用的全新的socket对象。
7. SiemensS7Net: 修复西门子s7协议某些情况数据批量写入失败的bug，原因来自PDU长度信息不对。
8. DLT645: 修复一些问题，已经测试通过，新增 DLT645OverTcp，感谢 QQ：542023033 提供的技术支持。
9. FanucInterface: 机器人的解析数据时，当shift_jis编码不存在时，将会引发异常，现在自动替换UTF8
10. HslCommunication: 所有的异步通信代码优化，优化超时检测机制，现在大大提升了服务器的高并发的能力，异步通信的性能。
11. AllenBradleyNet及OmronCipNet协议支持 UINT, UDINT, ULING类型的写入，对应的C#的类型是 ushort, uint, ulong
12. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
13. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
