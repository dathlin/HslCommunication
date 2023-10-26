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
			textBox1.Text = @"V11.6.4
1. ByteTransformHelper: 一个转换的静态辅助方法GetSuccessResultFromOther增加异常的捕获，防止在一些极其特殊的情况下导致异常然后奔溃。
2. IReadWriteMc: MC协议的接口新增属性TargetIOStation，用来表示目标模块IO编号，默认0x03FF, 表示管理的CPU，当访问多CPU时，需要设置本值。
3. ABBWebApiClient: abb机器人的类新增接口GetUserValue，用来获取用户自定义的一些数据内容，返回double[]，demo增加测试功能。
4. ModbusRtu: rtu报文的解析新增加对头部干扰码的支持，就算报文前跟了一个字节的无用报文，现在也可以正确的解析，也适用于rtuovertcp.
5. MqttServer: 文件引擎新删除整个目录的接口方法，重命名目录的接口方法，MqttSyncClient代码优化，并且添加配套的接口实现。
6. HttpServer: 新增Action类型属性ApiCalledAction，当一个接口调用完之后触发，可以获得该接口一些调用信息，方便二次处理。
7. BeckhoffAdsNet: 新增加ReadStruct<T>( string address )方法及WriteStruct<T>( string address, T value )针对struct类型的对象读写。
8. Demo: 在所有的PLC设备的读写测试的控件里，在点击了byte类型的读取时，支持了设置长度大于1的情况下，批量读取了byte数据，显示为十进制数据。
9. Demo: DEMO中的所有的PLC测试界面优化，在没有连接PLC的情况下，也可以切换选项卡查看地址示例。
10. Nuget: netstandard框架的项目依赖的System.IO.Ports组件版本从7.0降级为6.0，原因是7.0在某些特殊的ARM硬件里存在问题。
11. HslHelper: 方法CalculateBitStartIndex优化匹配代码，使用了正则表达式进行判断，提升程序速度。
12. SerialBase: 串口基类，网口基类的一点点代码优化，针对及其特殊情况的一点异常捕获。
13. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
14. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
