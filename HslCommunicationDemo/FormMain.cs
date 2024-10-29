using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Core;
using HslCommunication.Profinet.Siemens;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;

namespace HslCommunicationDemo
{
	public partial class FormMain : System.Windows.Forms.Form
	{
		public static Color ThemeColor = Color.FromArgb( 64, 64, 64 );

		public FormMain( )
		{
			InitializeComponent( );
			Form = this;
			logNet = new LogNetSingle( string.Empty );

			showMsToolStripMenuItem.Click += ShowMsToolStripMenuItem_Click;
		}

		public static bool ShowMs { get; set; }
		private void ShowMsToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if (FormMain.ShowMs)
			{
				showMsToolStripMenuItem.Image = null;
			}
			else
			{
				showMsToolStripMenuItem.Image = Properties.Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
			}
			FormMain.ShowMs = !FormMain.ShowMs;
		}

		#region Form Load Close Inni

		private void FormLoad_Load( object sender, EventArgs e )
		{
			LoadActive( );                                                                  // 加载激活状态
			dockPanel1.Theme = vS2015BlueTheme1;
			logRender = new DemoControl.FormLogRender( logNet );                            // 显示日志的窗体

			ThemeColor = menuStrip1.BackColor;
			verisonToolStripMenuItem.Text = "Version: " + HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( );

			if (Settings1.Default.language == 1)
			{
				if (System.Globalization.CultureInfo.CurrentCulture.ToString( ).StartsWith( "zh" ))
				{
					Program.Language = 1;
					Language( Program.Language );
				}
				else
				{
					HslCommunication.StringResources.SeteLanguageEnglish( );
					Program.Language = 2;
					Language( Program.Language );
				}
			}
			else
			{
				Program.Language = 2;
				HslCommunication.StringResources.SeteLanguageEnglish( );
				Language( Program.Language );
			}

			support赞助ToolStripMenuItem.Click += Support赞助ToolStripMenuItem_Click;



			ImageList imageList = new ImageList( );
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageSize = new Size( 16, 16 );
			imageList.Images.Add( "Method_636",       Properties.Resources.Method_636 );        // 0
			imageList.Images.Add( "ab",               Properties.Resources.ab );                // 1
			imageList.Images.Add( "fujifilm",         Properties.Resources.fujifilm );          // 2
			imageList.Images.Add( "HslCommunication", Properties.Resources.HslCommunication );  // 3
			imageList.Images.Add( "idcard",           Properties.Resources.idcard );            // 4
			imageList.Images.Add( "inovance",         Properties.Resources.inovance );          // 5
			imageList.Images.Add( "keyence",          Properties.Resources.keyence );           // 6
			imageList.Images.Add( "ls",               Properties.Resources.ls );                // 7
			imageList.Images.Add( "melsec",           Properties.Resources.melsec );            // 8
			imageList.Images.Add( "modbus",           Properties.Resources.modbus );            // 9
			imageList.Images.Add( "omron",            Properties.Resources.omron );             // 10
			imageList.Images.Add( "panasonic",        Properties.Resources.panasonic );         // 11
			imageList.Images.Add( "redis",            Properties.Resources.redis );             // 12
			imageList.Images.Add( "schneider",        Properties.Resources.schneider );         // 13
			imageList.Images.Add( "siemens",          Properties.Resources.siemens );           // 14
			imageList.Images.Add( "debug",            Properties.Resources.debug );             // 15
			imageList.Images.Add( "barcode",          Properties.Resources.barcode );           // 16
			imageList.Images.Add( "mqtt",             Properties.Resources.mqtt );              // 17
			imageList.Images.Add( "toledo",           Properties.Resources.toledo );            // 18
			imageList.Images.Add( "robot",            Properties.Resources.robot );             // 19
			imageList.Images.Add( "beckhoff",         Properties.Resources.beckhoff );          // 20
			imageList.Images.Add( "abb",              Properties.Resources.abb );               // 21
			imageList.Images.Add( "fatek",            Properties.Resources.fatek );             // 22
			imageList.Images.Add( "kuka",             Properties.Resources.kuka );              // 23
			imageList.Images.Add( "efort",            Properties.Resources.efort );             // 24
			imageList.Images.Add( "fanuc",            Properties.Resources.fanuc );             // 25
			imageList.Images.Add( "Class_489",        Properties.Resources.Class_489 );         // 26
			imageList.Images.Add( "zkt",              Properties.Resources.zkt );               // 27
			imageList.Images.Add( "websocket",        Properties.Resources.websocket );         // 28
			imageList.Images.Add( "yaskawa",          Properties.Resources.yaskawa );           // 29
			imageList.Images.Add( "xinje",            Properties.Resources.xinje );             // 30
			imageList.Images.Add( "yokogawa",         Properties.Resources.yokogawa );          // 31
			imageList.Images.Add( "delta",            Properties.Resources.delta );             // 32
			imageList.Images.Add( "ge",               Properties.Resources.ge );                // 33
			imageList.Images.Add( "yamatake",         Properties.Resources.Yamatake );          // 34
			imageList.Images.Add( "rkc",              Properties.Resources.rkc );               // 35
			imageList.Images.Add( "vigor",            Properties.Resources.vigor );             // 36
			imageList.Images.Add( "iec",              Properties.Resources.iec );               // 37
			imageList.Images.Add( "turck",            Properties.Resources.Turck );             // 38
			imageList.Images.Add( "toyota",           Properties.Resources.toyota );            // 39
			imageList.Images.Add( "SerialPort",       Properties.Resources.SerialPort );        // 40
			imageList.Images.Add( "NetworkAdapter",   Properties.Resources.NetworkAdapter );    // 41
			imageList.Images.Add( "bin",              Properties.Resources.bin );               // 42
			imageList.Images.Add( "wecon",            Properties.Resources.wecon );             // 43
			imageList.Images.Add( "megmeet",          Properties.Resources.megmeet );           // 44
			imageList.Images.Add( "invt",             Properties.Resources.invt );              // 45
			imageList.Images.Add( "http",             Properties.Resources.http );              // 46

			panelLeft = new FormPanelLeft( this.dockPanel1, imageList, this.logNet );
			panelLeft.FormClosing += PanelLeft_FormClosing;
			panelLeft.Show( dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft );

			panelSave = new FormSaveList( this.dockPanel1, imageList, this.logNet, panelLeft.IconImageIndex );
			panelSave.FormClosing += PanelLeft_FormClosing;
			panelSave.Show( dockPanel1, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft );

			if (panelSave.LoadDeviceList( ))
				panelSave.Activate( );
			else
				panelLeft.Activate( );

			if (Program.ShowAuthorInfomation)
			{
				FormIndex formIndex = new FormIndex( );
				formIndex.Show( dockPanel1, DockState.Document );
				// new FormHslMap( ).Show( dockPanel1 );
			}
			else
			{
				this.Text = "调试工具";
			}

			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );

			newVersionToolStripMenuItem.Visible = false;
			activeToolStripMenuItem.Click += ActiveToolStripMenuItem_Click;

			toolStripMenuItem_HomePage.Visible = Program.ShowAuthorInfomation;
			toolStripMenuItem_ApiDoc.Visible   = Program.ShowAuthorInfomation;
			免责条款ToolStripMenuItem.Visible  = Program.ShowAuthorInfomation;
		}

		private void PanelLeft_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = true;
		}

		private void FormSelect_FormClosing( object sender, FormClosingEventArgs e )
		{
			mqttClient?.ConnectClose( );
		}

		private void FormLoad_Shown( object sender, EventArgs e )
		{
			System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
		}

		private void ThreadPoolCheckVersion( object obj )
		{
			System.Threading.Thread.Sleep( 100 );
			mqttClient = new HslCommunication.MQTT.MqttClient( new HslCommunication.MQTT.MqttConnectionOptions( )
			{
				IpAddress = "118.24.36.220",
				Port = 1883,
				ClientId = "HslDemo"
			} );
			mqttClient.ConnectServer( );
			HslCommunication.Enthernet.NetSimplifyClient simplifyClient = new HslCommunication.Enthernet.NetSimplifyClient( "118.24.36.220", 18467 );
			HslCommunication.OperateResult<HslCommunication.NetHandle, string> read = simplifyClient.ReadCustomerFromServer( 1, HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( ) );
			if (read.IsSuccess)
			{
				HslCommunication.BasicFramework.SystemVersion version = new HslCommunication.BasicFramework.SystemVersion( read.Content2 );
				if (version > HslCommunication.BasicFramework.SoftBasic.FrameworkVersion)
				{
					// 有更新
					Invoke( new Action( ( ) =>
					{
						bool tip = File.Exists( Path.Combine( Application.StartupPath, "newVersionIngored.txt" ) );
						if (!tip)
						{
							using (FormNewVerison form = new FormNewVerison( ))
							{
								if (form.ShowDialog( "Version Check", "New version on server：" + read.Content2 + Environment.NewLine + " Start update?" ) == DialogResult.Yes)
								{
									NewVersionToolStripMenuItem_Click( null, new EventArgs( ) );
								}
								if (form.NewVersionIngored)
								{
									File.WriteAllText( Path.Combine( Application.StartupPath, "newVersionIngored.txt" ), string.Empty, Encoding.UTF8 );
								}
								else
								{
									File.Delete( Path.Combine( Application.StartupPath, "newVersionIngored.txt" ) );
								}
							}
						}
						else
						{
							newVersionToolStripMenuItem.Visible = true;
							newVersionToolStripMenuItem.Click += NewVersionToolStripMenuItem_Click;
						}
					} ) );
				}
			}

			try
			{
				cur = Process.GetCurrentProcess( );
				curpcp = new PerformanceCounter( "Process", "Working Set - Private", cur.ProcessName );
			}
			catch
			{

			}
		}

		private void LoadActive( )
		{
			try
			{
				string activePath = System.IO.Path.Combine( Application.StartupPath, "active.txt" );
				if (File.Exists( activePath ))
				{
					System.IO.FileInfo fileInfo = new System.IO.FileInfo( activePath );
					string key = fileInfo.CreationTime.ToString( "yyyy-MM-dd-mm-ss" );
					HslCommunication.Core.Security.AesCryptography aesCryptography = new HslCommunication.Core.Security.AesCryptography( key + key );

					string hsl = Encoding.UTF8.GetString( aesCryptography.Decrypt( File.ReadAllBytes( activePath ) ) );
					bool active = false;

					// 判断两种不同的激活方式
					if (hsl.Length < 100)
						active = HslCommunication.Authorization.SetAuthorizationCode( hsl );
					else
						active = HslCommunication.Authorization.SetHslCertificate( Convert.FromBase64String( hsl ) ).IsSuccess;
					if (active)
					{
						activeToolStripMenuItem.Text = "Actived!";
						activeToolStripMenuItem.ForeColor = Color.Lime;
					}
					else
					{
						System.IO.File.Delete( activePath );
					}
				}
			}
			catch( Exception ex )
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "HslCommunication 测试工具";
				免责条款ToolStripMenuItem.Text = "全国使用分布";
				toolStripMenuItem_CommunicationLog.Text = "报文日志";
				toolStripMenuItem_ApiDoc.Text = "API 文档";
				//授权ToolStripMenuItem.Text = "授权";
				deleteDeviceToolStripMenuItem.Text = "删除设备";
				toolStripMenuItem_language.Text = "语言(&L)";
				toolStripMenuItem_HomePage.Text = "官方网站";
				toolStripMenuItem_Debug.Text = "调试(&D)";
				toolStripMenuItem_Help.Text = "帮助(&H)";
				toolStripMenuItem_Doc.Text = "开发文档";
				toolStripMenuItem_SerialPort.Text = "串口调试";
				ecologyToolStripMenuItem.Text = "大生态(&E)";
				toolStripMenuItem_byteTransform.Text = "字节变换";
				regexRegularToolStripMenuItem.Text = "正则表达式";
			}
			else
			{
				Text = "HslCommunication Test Tool";
				toolStripMenuItem_CommunicationLog.Text = "MsgLog";
				免责条款ToolStripMenuItem.Text = "China Map";
				toolStripMenuItem_ApiDoc.Text = "API Doc";
				//授权ToolStripMenuItem.Text = "Authorize";
				toolStripMenuItem_language.Text = "Language(&L)";
				toolStripMenuItem_HomePage.Text = "HomePage";
				toolStripMenuItem_Debug.Text = "Debug(&D)";
				toolStripMenuItem_Help.Text = "Help(&H)";
				toolStripMenuItem_Doc.Text = "Document";
				toolStripMenuItem_SerialPort.Text = "SerialPort";
				ecologyToolStripMenuItem.Text = "Ecology(&E)";
				showMsToolStripMenuItem.Text = "Time Show Ms";
				toolStripMenuItem_byteTransform.Text = "ByteTransform";
				regexRegularToolStripMenuItem.Text = "RegexRegular";

			}
		}

		#endregion

		#region Menu Click

		private void ActiveToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using (FormActive form = new FormActive( ))
			{
				form.ShowDialog( );
				LoadActive( );
			}
		}

		private void Support赞助ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using (FormSupport form = new FormSupport( ))
			{
				form.ShowDialog( );
			}
		}
		private void Timer_Tick( object sender, EventArgs e )
		{
			if(curpcp != null)
			{
				string RamInfo = (curpcp.NextValue( ) / MB_DIV).ToString( "F1" ) + "MB";
				label2.Text = "Ram: " + RamInfo;
			}
			long current = Interlocked.Exchange( ref HslCommunication.HslTimeOut.TimeoutDealCount, 0 );
			label1.Text = $"Timeout:{HslCommunication.HslTimeOut.TimeOutCheckCount}/{current}  Lock:{SimpleHybirdLock.SimpleHybirdLockCount}  Wait:{SimpleHybirdLock.SimpleHybirdLockWaitCount}";
		}


		private void toolStripMenuItem_CommunicationLog_Click( object sender, EventArgs e )
		{
			if (this.logRender == null || this.logRender.IsDisposed)
				logRender = new DemoControl.FormLogRender( logNet );

			bool finish = false;
			foreach (var item in dockPanel1.Panes)
			{
				if (item.DockState == DockState.Document)
				{
					this.logRender.Show( item, DockAlignment.Bottom, 0.3d );
					finish = true;
					break;
				}
			}
			if (!finish)
				this.logRender.Show( dockPanel1, DockState.DockBottom );
		}

		private void OpenWebside( string url )
		{
			try
			{
				System.Diagnostics.Process.Start( url );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void blogsToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.cnblogs.com/dathlin/p/7703805.html" );
		}

		private void webSideToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hslcommunication.cn/" );
		}

		private void toolStripMenuItem_Doc_Click_1( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hsltechnology.cn/Doc/HslCommunication" );
		}

		private void 简体中文ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 简体中文
			HslCommunication.StringResources.SetLanguageChinese( );
			Program.Language = 1;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save( );
			Language( Program.Language );
			panelLeft?.SetLanguage( );
			panelSave?.SetLanguage( );
			MessageBox.Show( "已选择中文" );
		}

		private void englishToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// English
			HslCommunication.StringResources.SeteLanguageEnglish( );
			Program.Language = 2;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save( );
			Language( Program.Language );
			panelLeft?.SetLanguage( );
			panelSave?.SetLanguage( );
			MessageBox.Show( "Select English!" );
		}

		private void toolStripMenuItem_HomePage_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hsltechnology.cn" );
		}

		private void toolStripMenuItem_SourceCode_Click( object sender, EventArgs e )
		{
			OpenWebside( "https://github.com/dathlin/HslCommunication" );
		}
		private void 免责条款ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			new FormHslMap( ).Show( dockPanel1 );
		}

		private void ecologyToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://www.hsltechnology.cn/Home/Ecology" );
		}

		private void toolStripMenuItem_ApiDoc_Click( object sender, EventArgs e )
		{
			OpenWebside( "http://api.hslcommunication.cn" );
		}

		private void authorization授权ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			new FormCharge( ).Show( dockPanel1 );
		}

		private void toolStripMenuItem_SerialPort_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderSerialDebug( );
		}

		private void toolStripMenuItem_tcpUDP_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderTCPDebug( );
		}

		private void toolStripMenuItem_tcpUdpServer_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderTCPServerDebug( );
		}

		private void toolStripMenuItem_serial2Tcp_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderSerial2TcpDebug( );
		}

		private void toolStripMenuItem_tcp2Tcp_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderTCP2TcpDebug( );
		}


		private void toolStripMenuItem_byteTransform_Click( object sender, EventArgs e )
		{
			panelLeft?.RenderByteTransformDebug( );
		}

		private void NewVersionToolStripMenuItem_Click( object sender, EventArgs e )
		{
			try
			{
				if (System.IO.File.Exists( Path.Combine( Application.StartupPath, "Upgrade.exe" ) ))
				{
					Process.Start( Path.Combine( Application.StartupPath, "Upgrade.exe" ) );
				}
				else if (System.IO.File.Exists( Path.Combine( Application.StartupPath, "AutoUpdate.exe" ) ))
				{
					Process.Start( Path.Combine( Application.StartupPath, "AutoUpdate.exe" ) );
				}
				else
				{
					Process.Start( Path.Combine( Application.StartupPath, "软件自动更新.exe" ) );
				}
				System.Threading.Thread.Sleep( 50 );
				Close( );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "更新软件丢失，无法启动更新： " + ex.Message );
			}
		}

		private void regexRegularToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 正则表达式
			panelLeft?.RenderRegexDebug( );
		}

		#endregion

		#region Private Member

		public FormSaveList GetPanelLeft( ) => this.panelSave;

		public void ShowDockForm( DockContent dockContent )
		{
			dockContent.Show( dockPanel1 );
		}

		private HslCommunication.MQTT.MqttClient mqttClient;
		private System.Windows.Forms.Timer timer;
		private Process cur = null;
		private PerformanceCounter curpcp = null;
		private const int MB_DIV = 1024 * 1024;
		private FormPanelLeft panelLeft;
		private FormSaveList panelSave;


		public static FormMain Form { get; set; }
		public static Type[] formTypes = Assembly.GetExecutingAssembly( ).GetTypes( );
		private ILogNet logNet;
		private DemoControl.FormLogRender logRender;



		#endregion

	}

	public class FormSiemensS1200 : FormSiemens
	{
		public FormSiemensS1200( ) : base( SiemensPLCS.S1200 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-1200";
		}
	}
	public class FormSiemensS1500 : FormSiemens
	{
		public FormSiemensS1500( ) : base( SiemensPLCS.S1500 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-1500";
		}
	}
	public class FormSiemensS300 : FormSiemens
	{
		public FormSiemensS300( ) : base( SiemensPLCS.S300 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-300";
		}
	}

	public class FormSiemensS400 : FormSiemens
	{
		public FormSiemensS400( ) : base( SiemensPLCS.S400 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-400";
		}
	}

	public class FormSiemensS200 : FormSiemens200
	{
		public FormSiemensS200( ) : base( SiemensPLCS.S200 )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-200";
		}
	}
	public class FormSiemensS200Smart : FormSiemens200
	{
		public FormSiemensS200Smart( ) : base( SiemensPLCS.S200Smart )
		{

		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			this.userControlHead1.ProtocolInfo = "s7-200Smart";
		}
	}
}
