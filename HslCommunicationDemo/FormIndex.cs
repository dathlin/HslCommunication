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
			textBox1.Text = @"V9.3.2
1. KeyenceNanoSerial: 修复读写R寄存器时，提示地址格式异常的BUG，已经测试通过。
2. MelsecMcUdpServer: 新增三菱MC协议的UDP虚拟PLC，支持数据读写，支持二进制和ASCII格式。
3. OmronFinsUdpServer: 新增欧姆龙Fins协议的UDP的虚拟PLC，支持数据读写操作。
4. MqttServer: 修复MQTT服务器在客户端发送批量订阅的时候，服务器会触发BUG的问题。
5. ConnectPool&lt;TConnector&gt;类代码注释优化，新增连接次数峰值属性。
6. RedisSubscribe: 订阅服务器重新设计，订阅实现事件触发，支持手动订阅，取消订阅操作。
7. RedisClient: 支持了订阅的操作，当订阅的时候，创建订阅的实例化对象，应该在连接参数设置之后再进行订阅。
8. RedisClientPool：新增Redis连接池类，默认不限制连接数量，使用起来和普通的RedisClient一样，适合一个项目实例化一个对象。
9. MqttSyncClientPool: 新增MqttSyncClient的连接池版本类，默认不限制连接数量，用起来和普通的MqttSyncClient一样。
10. LogNetFileSize: 根据文件大小的日志类，实例化时支持设置允许存在的文件上限，如果设置为10，只保留最新的10个日志文件。
11. LogNetDateTime: 根据日期的日志类，实例化时支持设置允许存在的文件上限，如果设置为按天存储，上限为10，就是保留10天的日志。
12. AllenBradleySLCNet: 新增AB PLC的数据访问类，适合比较老的AB PLC，测试通过的是1747系列。地址格式为A9:0
13. AllenBradleyNet: 读写bool值的时候，不带下标访问单bool数据，如果需要访问bool数组，就需要带下标访问，例如：A[0]。
14. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
15. 本软件已经申请软件著作权，软著登字第5219522号，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
