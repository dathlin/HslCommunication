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
			textBox1.Text = @"V11.1.0
1. SiemensS7Net: 新增ReadDate，WriteDate的功能方法，实现了对日期类型的变量的读写操作，PLC测标记为D#2022-8-19
2. SecsHsms: 客户端和服务器的程序，都支持了字符串编码属性设置，可以支持其他的编码，默认的编码调整为Default，主要是支持了中文的消息。
3. FanucInterfaceNet: fanuc机器人的地址支持了直接的地址，Bool地址支持：SDO, SDI, RDI, RDO, UI, UO, SI, SO ,字单位地址支持：GI, GO, D。修复日志重复记录。
4. OmronFinsNet: OmronFinsNet，OmronFinsUdp, OmronHostLink, OmronHostLinkOverTcp支持0104功能码，批量读取随机字地址，使用方法 Read(string[])
5. OmronFinsServer: fins虚拟服务器支持了0104随机读取地址的功能码，对代码进行了优化，提炼了重复的代码。
6. MqttRpcDevice: 新增基于MQTT-RPC接口的设备对象，用来访问使用MQTTServer注册plc对象为RPC接口的设备，让单连接的PLC瞬间支持N连接，参考：https://www.cnblogs.com/dathlin/p/16632767.html
7. Toledo: 托利多电子秤增加通信报文日志记录，支持了扩展模式下的输出格式，并对数据分析增加异常捕获，日志记录。优化串口的通信接收，增加是否配置和校验的属性。
8. MqttClient: 每个订阅的主题升级为SubscribeTopic类对象，携带一个事件，支持每个主题绑定不同的事件内容。方便子窗体使用同一个MqttClient对象订阅不同的主题并触发不同的事件。
9. SiemensS7Server: 优化字符串的读写操作，支持WString字符串的读写，自动使用S7格式的字符串，在demo写入字符串数据的时候，客户端也可以正确的读取。
10. ILogNet: ILogNet日志接口新增一个属性LogStxAsciiCode用来配置是否在每条日志开头记录0x02的ASCII码字符，默认为true，设置false后也就无法使用hsl自带的日志分析工具。
11. RedisClient: redis客户端类支持了集群的服务器情况，当标签A在另一个服务器时，redisclient会自动连接到对应的服务器进行获取。
12. FanucSeries0i: fanuc机床的通信类支持了ReadOperatorMessage方法，用来读取机床的操作信息。
13. MqttServer: 修复Mqtt服务器在进行订阅结果反馈时，没有将topic主题的Qos也返回的bug，在某些情况下，客户端会引发异常。
14. NetworkDataServerBase: 新增加属性ForceSerialReceiveOnce，默认为false，当多个modbusserver使用485总线串到一起时，需要设置为true
15, Iec104: 修复连接失败的bug，修复在I帧消息号返回接收的id信息数量不正确的bug，现在可以正确的接收设备的数据。
16. Demo界面新增一个各种校验码测试的界面，主要用于测试CRC16，LRC，FCS（异或校验）,ACC(和校验)，欧姆龙的Fins协议Demo界面上支持配置字符串是否翻转。
17. Json: 依赖的json组件 Newtonsoft.Json 更新到最新的 v13.0.1 版本。
18. 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication
19. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
