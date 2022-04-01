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
			textBox1.Text = @"V10.6.0
1. ModbusHelper: 修复ReadBoolHelper在Modbus继承类里进行了自定义地址转换，导致读字地址的位失败，例如汇川AM系列读取M240.1的bool数据失败
2. LSisServer: 修复基于Cnet串口协议的通讯时，客户端使用SB连续读取指令读取长度大于9时，服务器对长度解析失败导致读取失败的bug。
3. GroupFileContainer: 新增获取所有文件的下载次数总和的属性，名称为：TotalDownloadTimes。
4. SerialPort: 新增串口的扩展方法IniSerialByFormatString，支持格式化的初始串口信息，例如 COM3-9600-8-N-1，简单明了。ModbusServer界面支持串口参数配置，支持配置最短接收时间配置。
5. MelsecFxLinksServer: 三菱Fxlinks虚拟服务器，修复远程客户端在读取位地址（例如M100）的字数据时，返回错误失败的bug。
6. HslReflectionHelper: MRPC及Webapi注册的方法接口功能中，支持参数类型为自定义类型数组的参数，例如Student[]，不支持List{Student}。
7. MqttServer: 文件读写功能的引擎中，遍历所有子目录统计信息时，可选参数是否携带返回最新的一个文件的信息，客户端做了相关的适配，参数支持。
8. XGBFastEnet: 修复向PLC读取数据到时候，类型指定不正确的bug，之前无论是什么类型，都会设置为0，PLC从而值返回一个字节长度的数据。
9. Mewtocol: 松下Mewtocol协议，当读写字单位超出协议限制时，自动升级为扩展协议标识，标记字符为 < (小于号), 服务器读写长度根据实际限制，支持扩展协议标识。
10. NetworkDoubleBase: 新增受保护的属性UseServerActivePush，只要设置为True，就可以将当前的连接切换为既支持设备主动发送，又支持同步访问的客户端，使用信号同步器来支持问答通信。
11. SiemensPPIServer: 新增PPI Server类，支持TCP以及串口的通讯，PPI的串口和网口透传类客户端增加读取PLC类型的功能方法。
12. SiemensS7Server: 修复客户端读取数据时，返回客户端FF04的数据内容时，位长度信息赋值不正确的bug，这会导致某些客户端发生数据异常。
13. SiemensPPI: 西门子PPI协议优化，读取bool[]的功能方法调整为先读取字，再解析出位数据信息，以此来支持批量读取位。
14. XinJETcpNet: 信捷的modbustcp协议新增当某些地址超过临界范围时，自动升级modbus协议到信捷内部TCP协议，以此访问到更大范围的数据内容，并支持了临界地址的跨地址访问，自动切割重组。
15. XinJEInternalNet: 新增完全的信捷内部协议实现的TCP通信，可以读取更大范围的数据内容，比如D200000地址，支持的地址参考API文档。
16. DeltaDvp: 修复台达系列在进行读取D寄存器的位的时候，也即是时 ReadBool(""D100.1"") 方法时，地址无法识别的bug，现在可以正确的读到D100的位信息。
17. FanucSeries0i: 新增WriteRData的接口方法，新增读写PMC数据的方法，ReadPMCData及WritePMCData，与R数据的读写类似，都是字节操作的方法。
18. IReadWriteDevice: 扩充方法支持，支持ReadFromCoreServer(List{byte[]})的读取的方法支持，支持多个报文读取，结果打包返回。
19. BeckhoffAdsNet: 倍福通信类新增是否使用自动AMS属性，默认为false，设置为true时，网络初始化时从server端加载相关的NETID参数信息，目前在twincat3上成功测试。
20. BeckhoffAdsNet: 修复ReadBool数组时，返回的长度都是8的倍数的bug。属性UseServerActivePush调整为True，支持PLC方主动推送数据信息。
21. BeckhoffAdsNet: 修改读取bool时地址机制，地址支持小数点，例如M100.2 ，所以M800等于M100.0， 修复读取数组时值解析不正确的bug， 修复写入bool数组失败的bug。
22. BeckhoffAdsNet: 修复直接SetPersistentConnection设置长连接无法读取的bug，以及掉线后，继续读写一直失败的bug。
23. BeckhoffAdsNet: 修复倍福服务器重启后继续读写标签变量一直失败的bug，原因来自倍福重启导致标签内存地址变更，但是缓存还是一直使用旧的。
24. SecsHsms: 新增secs协议的hsms实现，初步实现了主动方，也即是客户端，支持了一个通用的接口和数据，ReadSecsMessage方法。
25. 官网地址： http://www.hslcommunication.cn/ 官网的界面全新设计过，感谢浏览关注。
26. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
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
