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
			textBox1.Text = @"V10.2.2
1. NetworkDoubleBase: 在异步的网络通信方法中，原来的同步锁会在特殊的情况下导致UI线程卡死，所以改为异步锁，相关继承类也修改。
2. HslReflectionHelper: 通过HslDeviceAddressAttribute反射Read，Write的读写自定义对象的功能支持对byte类型的读写操作，需要通信对象本身支持才能成功读写。
3. SerialBase: 新增protect级别的AtLeastReceiveLength变量，用来表示从串口中至少接收的字节长度信息，一般为1。
4. IReadWriteNet: 新增api支持ReadCustomer( string address, T obj )，允许传入实例对象，对属性进行赋值，方便wpf进行数据绑定操作。
5. NetworkWebApiBase: 新增属性UseEncodingISO，在访问某些特殊的API的时候，会发生异常""The character set provided in ContentType is invalid....""，这时候本属性设置为true即可。
6. Cip: 欧姆龙cip及rockwell的cip支持读取plc型号的方法ReadPlcType()，omron的cip重新设计了WriteTag，对于0xD1类型数据，支持偶数个写入操作。
7. SiemensPPI: 修复writebyte方法的api接口名称还未注册的问题, 和串口透传类的相关代码优化，精简。
8. MelsecFxSerial: AtLeastReceiveLength变量设置为2，和串口透传类的相关代码优化，精简。
9. MqttServer: 新增属性：TopicWildcard，当设置为true时，支持主题订阅通配符，使用#,+来订阅多个主题的功能。具体参考该属性的API文档。
10. demo: 修复demo的HTTPClient界面浏览在linux创建的Webapi服务器的api列表功能失败的bug，使用HttpWebRequest来实现。
11. demo: rsa加密解密算法测试界面实现签名和验签操作。签名算法可选SHA1，SHA256, SHA512, MD5等等。
12. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
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
		MessageBox.Show( " + "\"授权失败！当前程序只能使用8小时！\"" + @" );
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
