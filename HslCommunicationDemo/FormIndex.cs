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
			textBox1.Text = @"V12.5.3
1. WebSocketHelper: websocket消息支持了数据压缩的情况，当收到压缩的payload数据的时候，会自动根据压缩标记位来解压缩数据信息。
2. WebSocketClient: 新增属性SupportDeflate, AutoDecompress用来控制是否要求服务器不支持压缩，以及数据压缩的情况下，对压缩数据进行手动解析的功能。
3. BeckhoffAdsNet: 新增加一个方法 ClearTagsCache 用来清除当前PLC里所有的缓存的标签内存偏移地址的字典。
4. Ftpclient: 添加了Ftp的客户端，支持文件上传，文件下载(支持进度报告)，文件删除，目录查列表，删除文件夹，创建文件夹，重命名文件夹，重命名文件功能。
5. NetPlainSocket: 普通TCP类优化接收数据逻辑，并添加CreateNewMessage委托用来绑定消息类，官网对应的文档内容优化。
6. AllenBradleyServer: 开放服务器的数据词典属性TagValueDict，DEMO界面的CIP服务器增加查看所有数据词典的功能，保存加载时自动保存数据词典的数据。
7. AllenBradleyPcccNet: 实现了读取bool数组的功能方法，实际使用读字，解析出位的方式，同步方法，异步方法都支持该操作。
8. Modbus: 修复DataFormat为BADC、DCBA时，写入bool数组到字寄存器的时候，高地位不正确的bug，影响范围包括rtu, rtuovertcp, ascii, modbustcp。
9. DLT645With1997: 及DLT645With1997OverTcp支持int32类型的读写方法，实际是读写double方法强制转int实现。
10. Demo: fanuc机床的测试界面启动按钮增加是否启动的确认，防止误操作，优化部分信息提示中英文结合。
11. Demo: 串口管道设置属性新增读取前是否清除缓存IsClearCacheBeforeRead，默认false，modbusrtu测试界面移除这个属性的配置改到管道里配置。
12. Demo: Demo的设备测试界面，当添加或是修改了点位变量表或是数据模拟表，没有保存直接关闭窗体的时候，增加弹窗提示操作。
13. Demo: 设备测试界面的数据模拟功能块，当配置写入数据是字符串的时候，字符串写入支持设置编码，脚本例子新增加一个字符串的例子。
14. Demo: 读取数据显示的界面，显示16进制及二进制的方式也对数组读取及写入也有效，主要针对short, ushort, int. uint, long, ulong。
15. Demo: 主界面的设备列表新增搜索功能，可以快速搜索到需要的协议，然后在程序关闭的时候支持记忆功能，记录打开的是协议列表还是保存列表。
16. Demo: 修复DEMO界面使用MQTT管道的时候，反复关闭重新打开，会导致重新创建MQTTClient对象的bug，这个属于DEMO的bug，库本身没问题。
17. 新官网：http://www.hsltechnology.cn:7900/，还有全新的使用文档的地址(V12版本升级说明)：http://www.hsltechnology.cn:7900/Doc/HslCommunication
18. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
