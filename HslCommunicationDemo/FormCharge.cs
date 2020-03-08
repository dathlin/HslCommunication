using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormCharge : HslFormContent
	{
		public FormCharge( )
		{
			InitializeComponent( );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			FormLoad.OpenWebside( linkLabel1.Text );
		}

		private void FormCharge_Load( object sender, EventArgs e )
		{
			textBox1.Text = @"V9.0.3
1. 修复汇川PLC的地址示例文档写错的bug。
2. IReadWriteNet标准化字符串读写操作，新增定制编码的字符串读写。netDeviceBase移除之前的writeunicode的方法。这点如果有使用，谨慎更新。
3. 串口基类和UDP基类的数据交互方法新增日志记录，对发送的数据和接收的数据写入debug等级的日志。
4. 数据服务器（主要是三菱虚拟plc，西门子虚拟plc，modbus服务器等）实现IReadWriteNet接口。
5. 关于ab-plc，新增MicroCip协议，适用于Micro800系列读写操作。
6. 关于序号生成器类SoftIncrement，重置最大值的方法名称更新，添加了重置当前值，重置初始值，支持反向序列，跳跃序列的功能，详细参考api文档。
7. 文件的服务器类，新增一些日志记录，关于文件何时被读取，何时读取结束的日志信息，等级为debug。
8. NuGet组件更新，json组件更新到12.0.3版本，IO.port更新到4.7.0版本。单元测试框架更新。
9. Demo的redis示例，支持不同的db块选择，当你选择数据后自动切换，键值类数据增加格式化显示。
10. NetworkBase: 网络基类的连接服务器改为如果连接立即失败(500ms内)，将会休眠100ms后，立即再尝试一次，提高连接的成功率。影响范围为所有客户端类。
11. 三菱二进制MC协议：地址里面新增标签访问，缓冲存储器访问，扩展的地址访问的方式，目前开放二进制的mc协议，欢迎测试，顺利的话，完善写入和ascii格式的。
12. 大量的代码注释添加，主流的常用的代码添加中英文注释，后续逐步全都改为中英文，方便国外客户阅读。
13. 240元的普通vip群的激活码时间调整，改为20年，中间软件重启一次，就又是20年，感谢大家的理解和支持。
14. http://www.hslcommunication.cn/MesDemo 官网的地址以后作为优秀的MES产品展示平台，欢迎大家关注。";
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
			FormCharge_Load( sender, e );
		}
	}
}
