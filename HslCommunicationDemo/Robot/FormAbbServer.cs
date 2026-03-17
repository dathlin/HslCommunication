using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunication.Reflection;
using HslCommunication.Robot.ABB;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormAbbServer : HslFormContent
	{
		public FormAbbServer( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			comboBox1.DataSource = new string[]
			{
				"text/html",
				"text/plain",
				"text/xml",
				"application/xml",
				"application/json"
			};

			Language( Program.Language );
			button4.Enabled = false;

		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
			}
		}

		private void FormAbbServer_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button4_Click( null, EventArgs.Empty );
		}

		ABBWebApiServer httpServer;
		private void button1_Click( object sender, EventArgs e )
		{
			// 启动服务
			try
			{
				httpServer = new ABBWebApiServer( );
				httpServer.SetLoginAccount( textBox3.Text, textBox1.Text );
				httpServer.Start( int.Parse( textBox2.Text ) );
				httpServer.LogNet = new LogNetSingle( "" );
				httpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				httpServer.IsCrossDomain = checkBox1.Checked;             // 是否跨域的设置

				panel2.Enabled = true;
				button1.Enabled = false;
				button4.Enabled = true;
			}
			catch(Exception ex)
			{
				DemoUtils.ShowMessage( "Started Failed:" + ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 if(showLog) textBox4.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			 } ) );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			httpServer?.Close( );
			panel2.Enabled = false;
			button1.Enabled = true;
			button4.Enabled = false;
		}

		private void textBox4_TextChanged( object sender, EventArgs e )
		{

		}

		private bool showLog = true;

		private void linkLabel3_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			textBox4.Clear( );
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			// 停止
			showLog = false;
		}

		private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			// 继续
			showLog = true;
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCrossDomain, checkBox1.Checked );
			element.SetAttributeValue( DemoDeviceList.XmlContentType, comboBox1.SelectedIndex );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox1.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
			checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlCrossDomain ).Value );
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlContentType ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}


	#endregion

	/// <summary>
	/// ABB机器人的虚拟服务器，基于WebApi协议构建，可用于读取一些数据信息<br />
	/// The virtual server of ABB robot, built based on the WebApi protocol, can be used to read some data information
	/// </summary>
	/// <remarks>
	/// 本虚拟服务器实例化之后，就可以启动了，需要注意的是，程序需要管理员模式运行，否则启动服务的时候会报错，显示拒绝当前的操作。
	/// 支持和<see cref="ABBWebApiClient"/>进行测试通信。本服务器的运行需要商业授权支持，否则只能运行24小时。
	/// </remarks>
	public class ABBWebApiServer : HttpServer
	{
		/// <summary>
		/// 设置用户的登录信息，用户名和密码信息<br />
		/// Set user login information, user name and password information
		/// </summary>
		/// <param name="name">用户名</param>
		/// <param name="password">密码</param>
		[HslMqttApi]
		public void SetLoginAccount( string name, string password )
		{
			this.userName = name;
			this.password = password;
		}


		/// <inheritdoc cref="HttpServer.HandleRequest(HttpListenerRequest, HttpListenerResponse, byte[])"/>

#if NET20 || NET35
		protected override object HandleRequest( HttpListenerRequest request, HttpListenerResponse response,  byte[] data )
#else
		protected override async Task<object> HandleRequest( HttpListenerRequest request, HttpListenerResponse response, byte[] data )
#endif
		{
			string[] values = request.Headers.GetValues( "Authorization" );
			if (values == null || values.Length < 1 || string.IsNullOrEmpty( values[0] ))
			{
				response.StatusCode = 401;
				response.AddHeader( "WWW-Authenticate", "Basic realm=\"Secure Area\"" );
				return "";
			}

			string base64String = values[0].Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries )[1];
			string accountString = Encoding.UTF8.GetString( Convert.FromBase64String( base64String ) );
			string[] account = accountString.Split( new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries );
			if (account.Length < 2)
			{
				response.StatusCode = 401;
				response.AddHeader( "WWW-Authenticate", "Basic realm=\"Secure Area\"" );
				return "";
			}

			if (userName != account[0] || password != account[1])
			{
				response.StatusCode = 401;
				response.AddHeader( "WWW-Authenticate", "Basic realm=\"Secure Area\"" );

				LogNet?.WriteDebug( $"Account Check Failed:{account[0]}:{account[1]}" );
				return "";
			}



			if      (string.IsNullOrEmpty( request.RawUrl ) || request.RawUrl == "/")
			{
				return @"<html>
	<head>
		<title>Services</title>
		<base href= ""http://localhost/"" />
	</head>
	<body>
		<div class=""state"">
			<a href= """" rel=""self""/>
			<ul>
				<li class=""srvlst-service-li"" title=""ctrl"">
					<a href= ""ctrl"" rel=""self""> </a>
				</li>
				<li class=""srvlst-service-li"" title=""rw"">
					<a href= ""rw"" rel=""self""> </a>
				</li>
				<li class=""srvlst-service-li"" title=""progress"">
					<a href= ""progress"" rel=""self""> </a>
				</li>
				<li class=""srvlst-service-li"" title=""fileservice"">
					<a href= ""fileservice"" rel=""self""> </a>
				</li>
				<li class=""srvlst-service-li"" title=""users"">
					<a href= ""users"" rel=""self""> </a>
				</li>
				<li class=""srvlst-service-li"" title=""subscription"">
					<a href= ""subscription"" rel=""self""> </a>
				</li>
			</ul>
		</div>
	</body>
</html>";
			}
			else if (request.RawUrl == "/rw")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html>
<head>
<title>rw</title>
<base href= ""http://localhost/"" />
</head>
<body>
<div class=""state"">
<a href= ""rw"" rel=""self""/>
<ul>
<li class=""rwservice-li"" title=""cfg"">
<a href= ""rw/cfg"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""devices"">
<a href= ""rw/devices"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""dipc"">
<a href= ""rw/dipc"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""elog"">
<a href= ""rw/elog"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""iosystem"">
<a href= ""rw/iosystem"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""mastership"">
<a href= ""rw/mastership"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""motionsystem"">
<a href= ""rw/motionsystem"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""panel"">
<a href= ""rw/panel"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""rapid"">
<a href= ""rw/rapid"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""retcode"">
<a href= ""rw/retcode"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""Rim"">
<a href= ""rw/rim"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""system"">
<a href= ""rw/system"" rel=""self""/>
</li>
<li class=""rwservice-li"" title=""vision"">
<a href= ""rw/vision"" rel=""self""/>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/system")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>system</title>
<base href=""http://localhost/rw/system/""/>
</head>
<body>
<div class=""state"">
<a href="""" rel=""self""/>
<ul>
<li class=""sys-system-li"" title=""system"">
<span class=""major"">6</span>
<span class=""minor"">05</span>
<span class=""build"">0047</span>
<span class=""revision"">00</span>
<span class=""sub-revision"">00</span>
<span class=""buildtag"">Internal build 0047</span>
<span class=""robapi-compatibility-revision"">0</span>
<span class=""title"">RobotWare</span>
<span class=""type"">RobotWare</span>
<span class=""description"">Controller Software</span>
<span class=""date"">2016-11-25</span>
<span class=""mctimestamp"">#20:14:43/nov 24 2016#</span>
<span class=""name"">6.05.0047</span>
<span class=""rwversion"">6.05.0047</span>
<span class=""sysid"">{14C798C8-3C47-4E4C-8CD4-040EC9483A10}</span>
<span class=""starttm"">2016-12-09 T 17:47:42</span>
<span class=""rwversionname"">6.05.00.00 Internal build 0047</span>
</li>
<li class=""sys-options-li"" title=""options"">
<a href=""options"" rel=""self"" />
<ul>
<li class=""sys-option-li"" title=""0"">
<span class=""option"">RobotWare Base</span>
</li>
<li class=""sys-option-li"" title=""1"">
<span class=""option"">English</span>
</li>
<li class=""sys-option-li"" title=""2"">
<span class=""option"">614-1 FTP and NFS client</span>
</li>
<li class=""sys-option-li"" title=""3"">
<span class=""option"">616-1 PC Interface</span>
</li>
<li class=""sys-option-li"" title=""4"">
<span class=""option"">617-1 FlexPendant Interface</span>
</li>
<li class=""sys-option-li"" title=""5"">
<span class=""option"">623-1 Multitasking</span>
</li>
<li class=""sys-option-li"" title=""6"">
<span class=""option"">608-1 World Zones</span>
</li>
<li class=""sys-option-li"" title=""7"">
<span class=""option"">Motor Commutation</span>
</li>
<li class=""sys-option-li"" title=""8"">
<span class=""option"">Service Info System</span>
</li>
<li class=""sys-option-li"" title=""9"">
<span class=""option"">Calib. Pendelum RAPID</span>
</li>
<li class=""sys-option-li"" title=""10"">
<span class=""option"">Drive System 120/140/260/360/1200/1400/1520/1600</span>
</li>
<li class=""sys-option-li"" title=""11"">
<span class=""option"">IRB 140-5/0.8 Type A</span>
</li>
<li class=""sys-option-li"" title=""12"">
<span class=""option"">810-2 SafeMove</span>
</li>
<li class=""sys-energy-li"" title=""energy"">
<a href=""energy"" rel=""self""/>
</li>
<li class=""sys-license-li"" title=""license"">
<a href=""license"" rel=""self""/>
</li>
<li class=""sys-products-li"" title=""products"">
<a href=""products"" rel=""self""/>
</li>
</ul>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/panel")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
<html
xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>panel</title>
<base href=""http://localhost/rw/panel/""/>
</head>
<body>
<div class=""state"">
<a href="""" rel=""self""></a>
<a href=""?action=show"" rel=""action""></a>
<ul>
<li class=""pnl-ctrlstate-li"" title=""ctrlstate"">
<a href=""ctrlstate"" rel=""self""></a>
</li>
<li class=""pnl-opmode-li"" title=""opmode"">
<a href=""opmode"" rel=""self""></a>
</li>
<li class=""pnl-speedratio-li"" title=""speedratio"">
<a href=""speedratio"" rel=""self""></a>
</li>
<li class=""pnl-coldetstate-li"" title=""collisiondetectstate"">
<a href=""coldetstate"" rel=""self""></a>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/panel/speedratio")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>panel</title>
<base href= ""http://localhost/rw/panel/speedratio/"" />
</head>
<body>
<div class=""state"">
<a href= """" rel=""self""/>
<a href= ""?action=show"" rel=""action""/>
<ul>
<li class=""pnl-speedratio"" title=""speedratio"">
<span class=""speedratio"">100</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/panel/opmode")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>panel</title>
<base href= ""http://localhost/rw/panel/opmode/"" />
</head>
<body>
<div class=""state"">
<a href= """" rel=""self""/>
<a href= ""?action=show"" rel=""action""/>
<ul>
<li class=""pnl-opmode"" title=""opmode"">
<span class=""opmode"">MANR</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/panel/ctrlstate")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>panel</title>
<base href= ""http://localhost/rw/panel/ctrlstate/"" />
</head>
<body>
<div class=""state"">
<a href= """" rel=""self""/>
<a href= ""?action=show"" rel=""action""/>
<ul>
<li class=""pnl-ctrlstate"" title=""ctrlstate"">
<span class=""ctrlstate"">motoron</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
</head>
<body>
	<div class=""state"">
	<a href="""" rel=""self""/>
	<ul>
		<li class=""ios-networks-li"" title=""networks"">
			<a href=""networks"" rel=""self""/>
		</li>
		<li class=""ios-devices-li"" title=""devices"">
			<a href=""devices"" rel=""self""/>
		</li>
		<li class=""ios-signals-li"" title=""signals"">
			<a href=""signals"" rel=""self""/>
		</li>
	</ul>
	</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem/networks")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
</head>
<body>
	<div class=""state"">
	<a href=""networks"" rel=""self""/>
	<ul>
		<li class=""ios-network-li"" title=""Local"">
			<a href=""networks/Local"" rel=""self""></a>
			<a href=""devices?network=Local"" rel=""devices""></a>
			<span class=""name"">Local</span>
			<span class=""pstate"">running</span>
			<span class=""lstate"">started</span>
		</li>
		<li class=""ios-network-li"" title=""Virtual"">
			<a href=""networks/Virtual"" rel=""self""/>
			<a href=""devices?network=Virtual"" rel=""devices""/>
			<span class=""name"">Virtual</span>
			<span class=""pstate"">running</span>
			<span class=""lstate"">started</span>
		</li>
	</ul>
	</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem/devices")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
</head>
<body>
	<div class=""state"">
	<a href=""devices"" rel=""self""/>
	<a href= ""devices?action=show"" rel=""action""/>
	<ul>
	<li class=""ios-device-li"" title=""Local/DRV_1"">
		<a href=""devices/Local/DRV_1"" rel=""self""></a>
		<span class=""name"">DRV_1</span>
		<span class=""lstate"">enabled</span>
		<span class=""pstate"">running</span>
		<span class=""type"">DRV_1_TYPE</span>
		<span class=""address"">-</span>
	</li>
	<li class=""ios-device-li"" title=""Local/PANEL"">
		<a href=""devices/Local/PANEL"" rel=""self""></a>
		<span class=""name"">PANEL</span>
		<span class=""lstate"">enabled</span>
		<span class=""pstate"">running</span>
		<span class=""type"">PANEL_TYPE</span>
		<span class=""address"">-</span>
	</li>
	</ul>
	</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem/devices/D652_10" || request.RawUrl == "/rw/iosystem/devices/BK5250")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""en"" lang=""en"">
	<head><title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
</head>
<body>
<div class=""state"">
	<a href=""devices/Local/PANEL"" rel=""self""></a>
	<a href= ""devices/Local/PANEL?action=show"" rel=""action""></a>
	<ul>
	<li class=""ios-device"" title=""Local/PANEL"">
		<a href=""networks/Local""  rel=""network""/>
		<span class=""name"">PANEL</span>
		<span class=""lstate"">enabled</span>
		<span class=""pstate"">running</span>
		<span class=""address"">-</span>
		<span class=""indata"">1FFFE063</span>
		<span class=""inmask"">FFFFFFFF</span>
		<span class=""outdata"">0000000E</span>
		<span class=""outmask"">FFFFFFFF</span>
	</li>
	</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem/signals")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
</head>
<body>
	<div class=""state"">
	<a href=""signals"" rel=""self""/>
	<a href= ""signals?action=show"" rel=""action""/>
	<ul>
		<li class=""ios-signal-li"" title=""Local/DRV_1/DRV1TESTE2"">
			<a href=""signals/Local/DRV_1/DRV1TESTE2"" rel=""self""/>
			<span class=""name"">DRV1TESTE2</span>
			<span class=""type"">DO</span>
			<span class=""category"">safety</span>
			<span class=""lvalue"">0</span>
			<span class=""lstate"">simulated</span>
		</li>
		<li class=""ios-signal-li"" title=""Local/DRV_1/DRV1BRAKE"">
			<a href=""signals/Local/DRV_1/DRV1BRAKE"" rel=""self""/>
			<span class=""name"">DRV1BRAKE</span>
			<span class=""type"">DO</span>
			<span class=""category"">safety</span>
			<span class=""lvalue"">0</span>
			<span class=""lstate"">simulated</span>
		</li>
	</ul>
	</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/iosystem/signals/Local/DRV_1/DRV1K1")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html
  xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
  </head>
  <body>
	<div class=""state"">
	  <a href=""signals/Local/DRV_1/DRV1K1"" rel=""self""></a>
	  <a href=""signals/Local/DRV_1/DRV1K1?action=show"" rel=""action""></a>
	  <ul>
		<li class=""ios-signal"" title=""Local/DRV_1/DRV1K1"">
		  <a href=""devices/DRV_1"" rel=""device""></a>
		  <span class=""name"">DRV1K1</span>
		  <span class=""type"">DO</span>
		  <span class=""category"">safety</span>
		  <span class=""lvalue"">0</span>
		  <span class=""lstate"">not simulated</span>
		  <span class=""unitnm"">DRV_1</span>
		  <span class=""phstate"">valid</span>
		  <span class=""pvalue"">0</span>
		  <span class=""ltime-sec"">0</span>
		  <span class=""ltime-microsec"">0</span>
		  <span class=""ptime-sec"">0</span>
		  <span class=""ptime-microsec"">0</span>
		  <span class=""quality"">1</span>
		</li>
	  </ul>
	</div>
  </body>
</html>";
			}
			else if (request.RawUrl == "/rw/elog")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
	<html xmlns=""http://www.w3.org/1999/xhtml"">
	   <head>
		  <title>Elog</title>
		  <base href=""http://localhost:7777/rw/elog/""/>
	   </head>
	   <body>
		  <div class=""state"">
			 <a href=""?action=show"" rel=""action""></a> <a href="""" rel=""self""></a> 
			 <ul>
				<li class=""elog-domain-li"" title=""0""><a href=""0"" rel=""self""></a><span class=""numevts"">31</span> <span class=""buffsize"">1000</span> </li>
				<li class=""elog-domain-li"" title=""1""><a href=""1"" rel=""self""></a><span class=""numevts"">20</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""2""><a href=""2"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""3""><a href=""3"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""4""><a href=""4"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""5""><a href=""5"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""7""><a href=""7"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""8""><a href=""8"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""9""><a href=""9"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""10""><a href=""10"" rel=""self""></a><span class=""numevts"">2</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""11""><a href=""11"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""12""><a href=""12"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""15""><a href=""15"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""17""><a href=""17"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
			 </ul>
		 </div>
	</body>
	</html>";
			}
			else if (request.RawUrl == "/rw/elog/0?lang=zh&amp;resource=title" || request.RawUrl.StartsWith( "/rw/elog/") )
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
	<title>Elog</title>
	<base href=""http://localhost/rw/elog/""/>
  </head>
  <body>

	<div class=""state"">      
	  <a href=""0"" rel=""self""></a>    
	  <a href= ""0?action=show"" rel=""action""/>
	  <ul>                        
		<li class=""elog-message-li"" title=""/rw/elog/0/5"">
			<a href=""0/5"" rel=""self""></a>          
			<span class=""msgtype"">1</span>
			<span class=""code"">10015</span>
			<span class=""src-name"">MC0</span>
			<span class=""tstamp"">2013-09-08 T 11:22:09</span>
			<span class=""argc"">0</span> 
		</li>
		<li class=""elog-message-li"" title=""/rw/elog/0/4"">
			<a href=""0/4"" rel=""self""></a>          
			<span class=""msgtype"">1</span>
			<span class=""code"">10013</span>
			<span class=""src-name"">MC0</span>
			<span class=""tstamp"">2013-09-08 T 11:22:09</span>
			<span class=""argc"">0</span> 
		</li>
		<li class=""elog-message-li"" title=""/rw/elog/0/3"">
			<a href=""0/3"" rel=""self""></a>          
			<span class=""msg-type"">1</span>
			<span class=""code"">10002</span>
			<span class=""src-name"">MC0</span>
			<span class=""tstamp"">2013-09-08 T 11:22:07</span>
			<span class=""argc"">2</span> 
			<span class=""arg1"" type=""string"">TRAFO</span>
			<span class=""arg2"" type=""string"">trafo_dm1</span>
		</li>
	  </ul>       
	</div>
  </body>
</html>";
			}
			else if (request.RawUrl == "/rw/rapid")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>rapid</title>
<base href=""http://localhost:7777/rw/rapid/""/>
</head>
<body>
<div class=""state""> <a href="""" rel=""self"">
</a> <ul> <li class=""rap-tasks-li"" title=""tasks""> <a href=""tasks"" rel=""self"">
</a> </li> <li class=""rap-symbols-li"" title=""symbols""> <a href=""symbols"" rel=""self"">
</a> </li> <li class=""rap-execution-li"" title=""execution""> <a href=""execution"" rel=""self"">
</a> </li> <li class=""rap-uiinstr-li"" title=""uiinstr""> <a href=""uiinstr"" rel=""self"">
</a> </li> <li class=""rap-taskselection-li"" title=""taskselection""> <a href=""taskselection"" rel=""self"">
</a> </li> <li class=""rap-modules-li"" title=""modules""> <a href=""modules?task=T_ROB1"" rel=""self"">
</a> </li> <li class=""rap-program-li"" title=""program""> <a href=""tasks/T_ROB1/program"" rel=""self"">
</a> </li> <li class=""rap-symbol-properties-li"" title=""symbol-properties""> <a href=""symbol/properties/RAPID/T_ROB1/user/reg1"" rel=""self"">
</a> </li> <li class=""rap-symbol-object-li"" title=""symbol-object""> <a href=""symbols/RAPID/T_ROB1/mainmodule?info=object-list-ext&amp;type=DataDecls"" rel=""self"">
</a> </li> <li class=""rap-symbol-data-li"" title=""symbol-data""> <a href=""symbol/data/RAPID/T_ROB1/user/reg1"" rel=""self"">
</a> </li> <li class=""rap-task-li"" title=""task""> <a href=""tasks/T_ROB1"" rel=""self"">
</a> </li> <li class=""rap-program-pcp-li"" title=""program-pcp""> <a href=""tasks/T_ROB1/pcp"" rel=""self"">
</a> </li> <li class=""rap-program-counter-position-li"" title=""program-counter-position""> <a href=""tasks/T_ROB1/execution"" rel=""self"">
</a> </li> <li class=""rap-module-li"" title=""module""> <a href=""modules/mymodule/?task=T_ROB1"" rel=""self"">
</a> </li> <li class=""rap-motion-li"" title=""motion""> <a href=""tasks/T_ROB1/motion"" rel=""self"">
</a> </li> <li class=""rap-AliasIO-li"" title=""AliasIO""> <a href=""aliasio?start=0"" rel=""self"">
</a> </li> </ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/rapid/execution")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
	<html xmlns=""http://www.w3.org/1999/xhtml"">
	<head>
		<title>rapid</title>
		<base href=""http://localhost/rw/rapid/""/>
	</head>
	<body>
		<div class=""state"">
			<a href=""execution"" rel=""self""></a>
			<a href=""execution?action=show"" rel=""action""></a>
			<ul>
				<li class=""rap-execution"" title=""execution"">
					<span class=""ctrlexecstate"">stopped</span>
					<span class=""cycle"">forever</span>
				</li>
			</ul>
		</div>
	</body>
	</html>";
			}
			else if (request.RawUrl == "/rw/rapid/tasks")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>rapid</title>
<base href=""http://127.0.0.1/rw/rapid/""/>
</head>
<body>
<div class=""state"">
<a href=""tasks"" rel=""self""/>
<a href= ""tasks?action=show"" rel=""action""/>
<ul>
<li class=""rap-task-li"" title=""T_ROB1"">
<a href= ""tasks/T_ROB1"" rel=""self""/>
<span class=""name"">T_ROB1</span>
<span class=""type"">norm</span>
<span class=""taskstate"">link</span>
<span class=""excstate"">read</span>
<span class=""active"">On</span>
<span class=""motiontask"">TRUE</span>
</li>
<li class=""rap-task-li"" title=""T_ROB2"">
<a href= ""tasks/T_ROB2"" rel=""self""/>
<span class=""name"">T_ROB2</span>
<span class=""type"">norm</span>
<span class=""taskstate"">link</span>
<span class=""excstate"">read</span>
<span class=""active"">On</span>
<span class=""motiontask"">TRUE</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/rapid/tasks/T_ROB1")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html
  xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
    <title>rapid</title>
    <base href=""http://localhost:7778/rw/rapid/""/>
  </head>
  <body>
    <div class=""state"">
      <a href=""tasks/T_ROB1"" rel=""self""></a>
      <a href=""tasks/T_ROB1?action=show"" rel=""action""></a>
      <ul>
        <li class=""rap-task"" title=""T_ROB1"">
         <a href=""tasks/T_ROB1/program"" rel=""program""></a>
          <a href=""modules?task=T_ROB1"" rel=""modules""></a>
          <span class=""name"">T_ROB1</span>
          <span class=""type"">norm</span>
          <span class=""taskstate"">linked</span>
          <span class=""excstate"">ready</span>
          <span class=""active"">On</span>
          <span class=""motiontask"">TRUE</span>
          <span class=""tasktype"">Normal</span>
          <span class=""trust"">None</span>
          <span class=""taskID"">1</span>
          <span class=""execmode"">unknown</span>
          <span class=""exectype"">None</span>
          <span class=""prodentrypt"">main</span>
          <span class=""bind_ref"">True</span>
          <span class=""task_in_forgnd"">True</span>
          <a href=""http://localhost:7777/rw/retcode?code=-1073442809"" rel=""error"" class=""execlevel""/>
        </li>
      </ul>
    </div>
  </body>
</html>";
			}
			else if (request.RawUrl == "/rw/rapid/symbol/data/RAPID/T_ROB1/user/nCurProgIndex")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>rapid</title>
<base href=""http://127.0.0.1:80/rw/rapid/""/>
</head>
<body>
<div class=""state"">
<ul>
<li class=""rap-data"" title=""RAPID/T_ROB1/nCurProgIndex""> 
<span class=""value"">1.1</span>
</li>
<a href=""http://127.0.0.1:80/rw/retcode?code=-1073414145"" rel=""error"" class=""pgmname_ret2""/>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
	<head>
		<title>motionsystem</title>
		<base href=""http://localhost/rw/""/>
	</head>
	<body>
		<div class=""state"">
			<a href=""motionsystem"" rel=""self""/>
			<a href=""motionsystem?action=show"" rel=""action""/>
			<ul>
				<li class=""ms"" title=""motionsystem"">
					<span class=""change-count"">2</span>
					<span class=""mechunit-name"">ROB_1</span>
					<span class=""poll-rate"">60</span>
					<span class=""modal-payload-mode"">ON</span>
					<span class=""absacc-active"">ON</span>
				</li>
				<li class=""ms-change-count-li"" title=""change-count"">
					<a href=""motionsystem/checkchangecount"" rel=""self""/>
				</li>
				<li class=""ms-mechunit-li"" title=""mechunit"">
					<a href=""motionsystem/mechunits"" rel=""self""/>
				</li>
				<li class=""ms-errorstate-li"" title=""errorstate"">
				<a href=""motionsystem/errorstate"" rel=""self""/>
				</li>
				<li class=""ms-motionsupervision-li"" title=""motionsupervision"">
					<a href=""motionsystem/motionsupervision"" rel=""self""/>
				</li>
				<li class=""ms-pathsupervision-li"" title=""pathsupervision"">
				 <a href=""motionsystem/pathsupervision"" rel=""self""/>
				</li>
				<li class=""ms-nonmotion-execution-mode-li"" title=""nonmotion-execution-mode"">
				 <a href= ""motionsystem/nonmotionexecution"" rel=""self""/>
				</li>
			</ul>
		</div>
	</body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/mechunits")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
	   <title>motionsystem</title>
	   <base href=""http://localhost/rw/motionsystem/""/>
   </head>
   <body>
	   <div class=""state"">
		   <a href=""mechunits"" rel=""self""/>
		   <ul>
			   <li class=""ms-mechunit-li"" title=""ROB_1"">
				   <a href=""mechunits/ROB_1"" rel=""self""/>
				   <span class=""mode"">Activated</span>
				   <span class=""activation-allowed"">True</span>
				   <span class=""drive-module"">0</span>
			   </li>
			   <li class=""ms-mechunit-li"" title=""CNV1"">
				   <a href=""mechunits/CNV1"" rel=""self""/>
				   <span class=""mode"">Deactivated</span>
				   <span class=""activation-allowed"">False</span>
				   <span class=""drive-module"">0</span>
			   </li>
		   </ul>
	   </div>
   </body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/mechunits/ROB_1")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
	   <title>motionsystem</title>
	   <base href=""http://localhost/rw/motionsystem/mechunits/""/>
   </head>
   <body>
	   <div class=""state"">
		   <a href=""ROB_1"" rel=""self""/>
		   <a href=""ROB_1?action=show"" rel=""action""/>
		   <ul>
			   <li class=""ms-mechunit"" title=""ROB_1"">
				   <span class=""tool-name"">tool0</span>
				   <span class=""wobj-name"">wobj0</span>
				   <span class=""payload-name"">load0</span>
				   <span class=""total-payload-name"">load0</span>
				   <span class=""mode"">Activated</span>
				   <span class=""jog-mode"">Cartesian</span>
				   <a href=""http://{{host}}/rw/retcode?code={{task_retcode}}"" rel=""error"" class=""task-name""/>
				   <span class=""axes"">6</span>
				   <span class=""axes-total"">6</span>
				   <span class=""type"">TCPROBOT</span>
				   <span class=""coord-system"">Base</span>
				   <span class=""status"">Synchronized</span>
				   <span class=""is-integrated-unit"">NoIntegratedUnit</span>
				   <span class=""has-integrated-unit"">NoIntegratedUnit</span>
			   </li>
			   <li class=""ms-mechunit-pjoints-li"" title=""pjoints"">
				   <a href=""ROB_1/pjoints"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-robtarget-li"" title=""robtarget"">
				   <a href=""ROB_1/robtarget"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-jointtarget-li"" title=""jointtarget"">
				   <a href=""ROB_1/jointtarget"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-cartesian-li"" title=""cartesian"">
				   <a href=""ROB_1/cartesian"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-axes-li"" title=""axes"">
				   <a href=""ROB_1/axes"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-complianceleadthrough"" title=""complianceleadthrough"">
				   <a href=""ROB_1?resource=lead-through"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-baseframe-li"" title=""baseframe"">
				   <a href=""ROB_1/baseframe"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-smbdata-li"" title=""smbdata"">
				   <a href=""ROB_1/smbdata"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-motorcalib-li"" title=""motorcalib"">
				   <a href=""ROB_1/motorcalib"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-jointtarget-li"" title=""jointtarget"">
				<a href=""ROB_1/jointtarget"" rel=""self""/>
			   </li>
			   <li class=""ms-mechunit-robtargets-li"" title=""robtargets"">
			   <a href=""ROB_1/robtarget"" rel=""self""/>
			   </li>
		   </ul>
	   </div>
   </body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/mechunits/ROB_1/robtarget")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html>
<head>
<title>motionsystem</title>
<base href= ""http://localhost/rw/motionsystem/mechunits/ROB_1/robtarget/"" />
</head>
<body>
<div class=""state"">
<ul>
<li class=""ms-robtargets"" title=""ROB_1"">
<span class=""x"">515</span>
<span class=""y"">0</span>
<span class=""z"">712</span>
<span class=""q1"">0.7071068</span>
<span class=""q2"">0</span>
<span class=""q3"">0.7071068</span>
<span class=""q4"">0</span>
<span class=""cf1"">0</span>
<span class=""cf4"">0</span>
<span class=""cf6"">0</span>
<span class=""cfx"">0</span>
<span class=""eax_a"">8.999999e+009</span>
<span class=""eax_b"">8.999999e+009</span>
<span class=""eax_c"">8.999999e+009</span>
<span class=""eax_d"">8.999999e+009</span>
<span class=""eax_e"">8.999999e+009</span>
<span class=""eax_f"">8.999999e+009</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/mechunits/ROB_1/jointtarget")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html>
<head>
<title>motionsystem</title>
<base href= ""http://localhost/rw/motionsystem/mechunits/ROB_1/jointtarget/"" />
</head>
<body>
<div class=""state"">
<ul>
<li class=""ms-jointtarget"" title=""ROB_1"">
<span class=""rax_1"">1</span>
<span class=""rax_2"">2</span>
<span class=""rax_3"">3</span>
<span class=""rax_4"">4</span>
<span class=""rax_5"">5</span>
<span class=""rax_6"">6</span>
<span class=""eax_a"">7</span>
<span class=""eax_b"">8</span>
<span class=""eax_c"">9</span>
<span class=""eax_d"">10</span>
<span class=""eax_e"">11</span>
<span class=""eax_f"">12</span>
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/mechunits/ROB_1/axes")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
       <title>motionsystem</title>
       <base href=""http://localhost/rw/motionsystem/mechunits/ROB_1/""/>
   </head>
   <body>
       <div class=""state"">
           <a href=""axes"" rel=""self""/>
           <ul>
               <li class=""ms-mechunit-axes"" title=""axes"">
                   <span class=""axes"">6</span>
               </li>
               <li class=""ms-mechunit-axis-li"" title=""axis"">
                   <a href=""axes/1"" rel=""self""/>
                   <a href=""axes/2"" rel=""self""/>
                   <a href=""axes/3"" rel=""self""/>
                   <a href=""axes/4"" rel=""self""/>
                   <a href=""axes/5"" rel=""self""/>
                   <a href=""axes/6"" rel=""self""/>
               </li>
           </ul>
       </div>
   </body>
</html>";
			}
			else if (request.RawUrl.StartsWith( "/rw/motionsystem/mechunits/ROB_1/axes/" ))
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
       <title>motionsystem</title>
       <base href=""http://localhost/rw/motionsystem/mechunits/ROB_1/axes""/>
   </head>
   <body>
       <div class=""state"">
           <a href=""1?resource=axis-pose"" rel=""self""/>
           <ul>
               <li class=""ms-mechunit-axispose"" title=""axispose"">
                   <span class=""x""></span>
                   <span class=""y""></span>
                   <span class=""z""></span>
                   <span class=""q1""></span>
                   <span class=""q2""></span>
                   <span class=""q3""></span>
                   <span class=""q4""></span>
               </li>
           </ul>
       </div>
   </body>
</html>";
			}
			else if (request.RawUrl == "/rw/motionsystem/errorstate")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html>
	<head>
		<title>motionsystem</title>
		<base href= ""http://localhost/rw/motionsystem/"" />
	</head>
	<body>
		<div class=""state"">
			<a href= ""errorstate"" rel=""self""/>
			<ul>
				<li class=""ms-errorstate"" title=""errorstate"">
					<span class=""err-state"">HPJ_OK</span>
					<span class=""err-count"">0</span>
				</li>
			</ul>
		</div>
	</body>
</html>";
			}
			else if (request.RawUrl == "/rw/cfg")
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
	<head>
	<title>cfg</title> 
		<base href=""http://localhost/rw/""/>
	</head>
	<body>
		<div class=""state"">
			<a href=""cfg"" rel=""self"" class=""cfg""></a> 
			<a href=""cfg?action=show"" rel=""action""></a>
			<ul>
				<li class=""cfg-domain-li"" title=""EIO"">
					<a href=""cfg/EIO"" rel=""self""></a>
				</li>
				<li class=""cfg-domain-li"" title=""MMC"">
					<a href=""cfg/MMC"" rel=""self""></a>
				</li>
				<li class=""cfg-domain-li"" title=""MOC"">
					<a href=""cfg/MOC"" rel=""self""></a>
				</li>
				<li class=""cfg-domain-li"" title=""PROC"">
					<a href=""cfg/PROC"" rel=""self""></a>
				</li>
				<li class=""cfg-domain-li"" title=""SIO"">
					<a href=""cfg/SIO"" rel=""self""></a>
				</li>
				<li class=""cfg-domain-li"" title=""SYS""> 
					<a href=""cfg/SYS"" rel=""self""></a>
				</li>
			</ul>
		</div>
	</body>
</html>";
			}
			else if (request.RawUrl == "/rw/dipc")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
 <html xmlns=""http://www.w3.org/1999/xhtml"">
	<head>
		<title>RobAPI2 DIPC</title>
		<base href= ""http://localhost/rw/"" />
	</head>
	<body>
		<div class=""state"">
			<a href= ""dipc"" rel=""self""/>
			<a href= ""dipc?action=show"" rel=""action""/>
			<ul>
				<li class=""dipc-info-li"" title=""info"">
					<span class=""max-body-size"">444</span>
					<span class=""max-pkg-size"">5000</span>
				</li>
				<li class=""dipc-queue-li"" title=""PyInternalslot0"">
					<a href= ""dipc/PyInternalslot0"" rel=""self""/>
				</li>
				<li class=""dipc-queue-li"" title=""PyExternalslot1"">
					<a href= ""dipc/PyExternalslot1"" rel=""self""/>
				</li>
				<li class=""dipc-queue-li"" title=""RimDispatcher"">
					<a href= ""dipc/RimDispatcher"" rel=""self""/>
				</li>           
			</ul>
		</div>
	</body>
</html>";
			}
			else if (request.RawUrl == "/rw/elog")
			{
				return @"    <?xml version=""1.0"" encoding=""utf-8""?>
	<html xmlns=""http://www.w3.org/1999/xhtml"">
	   <head>
		  <title>Elog</title>
		  <base href=""http://localhost:7777/rw/elog/""/>
	   </head>
	   <body>
		  <div class=""state"">
			 <a href=""?action=show"" rel=""action""></a> <a href="""" rel=""self""></a> 
			 <ul>
				<li class=""elog-domain-li"" title=""0""><a href=""0"" rel=""self""></a><span class=""numevts"">31</span> <span class=""buffsize"">1000</span> </li>
				<li class=""elog-domain-li"" title=""1""><a href=""1"" rel=""self""></a><span class=""numevts"">20</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""2""><a href=""2"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""3""><a href=""3"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""4""><a href=""4"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""5""><a href=""5"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""7""><a href=""7"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""8""><a href=""8"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""9""><a href=""9"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""10""><a href=""10"" rel=""self""></a><span class=""numevts"">2</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""11""><a href=""11"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""12""><a href=""12"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""15""><a href=""15"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
				<li class=""elog-domain-li"" title=""17""><a href=""17"" rel=""self""></a><span class=""numevts"">0</span> <span class=""buffsize"">20</span> </li>
			 </ul>
		  </div>
	   </body>
	</html>";
			}
			else if (Regex.IsMatch( request.RawUrl, @"/rw/iosystem/signals/[\s\S]+/[\s\S]+/[\s\S]+" ))
			{
				return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<html
  xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
	<title>io</title>
	<base href=""http://localhost/rw/iosystem/""/>
  </head>
  <body>
	<div class=""state"">
	  <a href=""signals/Local/DRV_1/DRV1CHAIN2"" rel=""self""></a>
	  <a href=""signals/Local/DRV_1/DRV1CHAIN2?action=show"" rel=""action""></a>
	  <ul>
		<li class=""ios-signal"" title=""Local/DRV_1/DRV1CHAIN2"">
		  <a href=""devices/DRV_1"" rel=""device""></a>
		  <span class=""name"">DRV1CHAIN2</span>
		  <span class=""type"">DO</span>
		  <span class=""category"">safety</span>
		  <span class=""lvalue"">0</span>
		  <span class=""lstate"">not simulated</span>
		  <span class=""unitnm"">DRV_1</span>
		  <span class=""phstate"">valid</span>
		  <span class=""pvalue"">0</span>
		  <span class=""ltime-sec"">0</span>
		  <span class=""ltime-microsec"">0</span>
		  <span class=""ptime-sec"">0</span>
		  <span class=""ptime-microsec"">0</span>
		  <span class=""quality"">1</span>
		</li>
	  </ul>
	</div>
  </body>
</html>";
			}
			else if (request.RawUrl == "/fileservice")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
<html
  xmlns=""http://www.w3.org/1999/xhtml"">
  <head>
   <title>File Service</title>
   <base href=""http://10.140.60.61/fileservice/"" />
  </head>
  <body>
   <div class=""state"">
	 <a href="""" rel=""self""></a>
	 <ul>
	   <li class=""fs-device"" title=""hd0a"">
		 <a href="""" rel=""parent""></a>
		 <a href=""hd0a"" rel=""self""></a>
		 <span class=""fs-device-type"">fixed</span>
		 <span class=""fs-free-space"">873164800</span>
		 <span class=""fs-total-space"">2068717568</span>
		 <span class=""fs-enabled"">true</span>
		 <span class=""fs-readonly"">false</span>
	   </li>
	 </ul>
   </div>
  </body>
</html>";
			}
			else if (request.RawUrl == "/ctrl")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
 <html
   xmlns=""http://www.w3.org/1999/xhtml"">
   <head>
   <title>controller</title>
   <base href=""http://localhost:7777/ctrl/"" />
   </head>
   <body>
   <div class=""state"">
	 <a href="""" rel=""self""></a>
	 <a href=""?action=show"" rel=""action""></a>
	 <ul>
	   <li class=""ctrl-clock-info-li"" title=""clock"">
		 <a href=""clock"" rel=""self""></a>
		 <span class=""datetime"">2019-07-25 T 10:45:38</span>
	   </li>
	   <li class=""ctrl-identity-info-li"" title=""identity"">
		 <a href=""identity"" rel=""self""></a>
		 <span class=""ctrl-name"">IN-L-7010273</span>
		 <span class=""ctrl-type"">Virtual Controller</span>
		 <span class=""ctrl-level"">System Level</span>
	   </li>
	   <li class=""ctrl-system-info-li"" title=""system"">
		 <a href=""system"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-network-info-li"" title=""network"">
		 <a href=""network"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-backup-info-li"" title=""backup"">
		 <a href=""backup"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-compress-info-li"" title=""compress"">
		 <a href=""compress"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-safety-info-li"" title=""safety"">
		 <a href=""safety"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-options-info-li"" title=""options"">
		 <a href=""options"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-compatibility-info-li"" title=""compatibility"">
		 <a href=""compatibility"" rel=""self""></a>
	   </li>
	   <li class=""ctrl-virtualtime-info-li"" title=""virtualtime"">
		 <a href=""virtualtime"" rel=""self""></a>
	   </li>
	 </ul>
   </div>
   </body>
</html>";
			}
			else if (request.RawUrl == "/users")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml""> <head>
<title>ROBAPI2 User</title> <base href=""http://localhost/users/"" /> 
</head>
<body>
<div class=""state""> <a href="""" rel=""self"">
</a>
<a href=""?action=show"" rel=""action"">
</a> <a href=""grants"" rel=""grants"">
</a>
	<ul>        
<li class=""user-rmmp-li"" title=""rmmp""> 
<a href=""rmmp"" rel=""self""></a> 
</li> 
<li class=""user"" title=""Default User""> 
<span class=""name"">Default User</span> 
</li>
</ul>
</div>
</body>
</html>";
			}
			else if (request.RawUrl == "/subscription")
			{
				return @"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title> Create Subscription </title>
<base href=""http://localhost/subscription/""/>
</head>
<body>
<div class=""state"">
<form method=""post"" action="""" id=""subscribe"">
<fieldset class=""sub-resource"">
<input type=""checkbox"" name=""resources"" value=""1""/>
<input class=""res"" type=""text"" name=""1"" maxlength=""500""/>
<select class=""sub-priority"" name=""1-p"">
<option value=""0"" selected=""selected"">
</option>
<option value=""1"">
</option>
<option value=""2"">
</option>
</select>
</fieldset>
</form>
</div>
</body>
</html>";
			}



#if NET20 || NET35
			return base.HandleRequest( request, response, data );
#else
				return await base.HandleRequest( request, response, data );
#endif
		}


		private string userName = "Default User";
		private string password = "robotics";

		/// <inheritdoc/>
		public override string ToString( ) => $"ABBWebApiServer[{Port}]";

	}
}
