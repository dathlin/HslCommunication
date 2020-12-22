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
			textBox1.Text = @"V9.6.0
1. YokogawaLink: 异步的方法添加和完善，虚拟PLC侧支持Special:100开头的地址，表示特殊模块寄存器，从而支持各种类型的读写。
2. LogStatistics, LogValueLimit: 两个数据日志分析类支持获取指定时间段的数据，数据存储文件格式重新设计，为不兼容更新。
3. LogStatisticsDict, LogValueLimitDict: 新增数据日志分析的词典类，用来统计多个数据的不同时间段的使用情况。
4. 所有的基于tcp的plc，机器人，redis, mqtt, websocket等通讯类的ip地址支持直接输入域名，会自动调用Dns.GetIpAddress来解析。
5. MqttRpcApi: MRpc的API特性支持应用在属性上，不需要传递参数，直接获取属性的值，在demo上显示的小图标不一样。PLC的通讯类的基本属性在MRPC公开。
6. MelsecFxLinks: 支持读取PLC的型号，读写数据的地址支持了站号指定，地址可以写成[s=2;D100]，方便多站号读取。
7. AllenBradleyNet: 地址支持slot参数，例如：slot=2;AAA ，也可以不携带，这个是可选的
8. FatekProgram, FujiSPB, XGBCnet, MelsecA3CNet1, OmronHostLink, OmronHostLinkCMode, PanasonicMewtocol, SiemensPPI，信捷，汇川类及其透传类支持地址携带站号，例如 s=2;D100
9. FujiSPBServer: 新增富士PLC的虚拟服务器，支持串口和网口，原先的富士PLC存在bug，不能读取，欢迎网友对富士PLC测试。
10. HttpServer: 删除原先的HttpGet和HttpPost特性，改用MRPC的特性，支持注册webapi服务，使用方式和MRPC类似，demo增加httpsclient可浏览接口，https://www.cnblogs.com/dathlin/p/14170802.html
11. HttpServer, MqttServer: 服务器端支持接口调用的次数统计，支持客户端查询接口调用情况，demo客户端实现mqttclient,方便服务器管理在线客户端信息。
12. 其他优化改进，如果有网友发现bug，配合作者测试并修复bug，将根据实际情况给与现金红包奖励。
13. 普通VIP的个人使用不再限制100个PLC对象，连续运行时间调整为10年，高级的一些API限制商用，参考注释是否带[商业授权]字样。
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
