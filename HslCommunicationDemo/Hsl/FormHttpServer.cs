using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using HslCommunication;
using System.Net;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Profinet.AllenBradley;
using HslCommunication.Reflection;
using HslCommunication.Core;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Xml.Linq;
using HslCommunication.BasicFramework;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Policy;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet

	public partial class FormHttpServer : HslFormContent
	{
		public FormHttpServer( )
		{
			InitializeComponent( );

			checkBox_show_body.CheckedChanged += CheckBox_show_body_CheckedChanged;
			checkBox_show_header.CheckedChanged += CheckBox_show_header_CheckedChanged; ;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			codeExampleControl.ShowTextBox( true );
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
			listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
			tabControl1.SelectTab( 1 );
		}

		private void ListBox1_SelectedValueChanged( object sender, EventArgs e )
		{
			if (listBox1.SelectedItem is UserWebApis apis)
			{
				textBox_api.Text = apis.Name;
				textBox_body.Text = apis.Body;
				comboBox1.SelectedItem = apis.ContentType;
			}
		}
		private void CheckBox_show_body_CheckedChanged( object sender, EventArgs e )
		{
			if (this.httpServer != null)
			{
				this.httpServer.LogHttpBody = checkBox_show_body.Checked;
			}
		}

		private void CheckBox_show_header_CheckedChanged( object sender, EventArgs e )
		{
			if (this.httpServer != null)
			{
				this.httpServer.LogHttpHeader = checkBox_show_header.Checked;
			}
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				button_clear.Text = "Clear";
				button_stop.Text = "Stop";
				checkBox_show_body.Text = "Show Body Content?";
				checkBox_show_header.Text = "Show Header Content?";
				label8.Text = "Get the info below when requesting";
				tabPage3.Text = "Registered";
				label11.Text = "List of registered devices:";
				button_device_add.Text = "Add Device";
				button_device_remove.Text = "Remove";
			}
		}

		private HttpServer httpServer;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			// 启动服务
			try
			{
				httpServer = new HttpServer( );
				if (checkBox_https.Checked)
				{
					httpServer.UseHttps( );
				}

				if (textBox2.Text.StartsWith( "http", StringComparison.OrdinalIgnoreCase ) )
					httpServer.Start( textBox2.Text );
				else
					httpServer.Start( int.Parse( textBox2.Text ) );
				httpServer.HandleRequestFunc = HandleRequest;
				httpServer.HandleFileUpload = HandleFileUpload;
				httpServer.IsCrossDomain = checkBox_IsCrossDomain.Checked;               // 是否跨域的设置
				httpServer.RegisterHttpRpcApi( "", this );                               // 注册当前窗体的接口到服务器的接口上去
				httpServer.RegisterHttpRpcApi( "TimeOut", typeof( HslTimeOut ) );        // 注册的类的静态方法和静态属性
				httpServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				httpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;

				httpServer.DealWithHttpListenerRequest = DealWithHttpListenerRequest;    // 自定义处理请求的接口，比如增加认证信息
				if (checkBox2.Checked) httpServer.SetLoginAccessControl( new HslCommunication.MQTT.MqttCredential[] {
				new HslCommunication.MQTT.MqttCredential("admin", "123456")} );

				panel2.Enabled = true;
				button1.Enabled = false;

				StringBuilder code = new StringBuilder( );
				code.AppendLine( "HttpServer httpServer = new HttpServer( );" );
				if (checkBox_https.Checked) code.AppendLine( "httpServer.UseHttps( );" );
				if (textBox2.Text.StartsWith( "http", StringComparison.OrdinalIgnoreCase ))
					code.AppendLine( $"httpServer.Start( \"{textBox2.Text}\" );" );
				else
					code.AppendLine( $"httpServer.Start( int.Parse( \"{textBox2.Text}\" ) );" );
				code.AppendLine( $"httpServer.IsCrossDomain = {checkBox_IsCrossDomain.Checked.ToString( ).ToLower( )};" );
				if (checkBox2.Checked)
					code.AppendLine( $"httpServer.SetLoginAccessControl( new HslCommunication.MQTT.MqttCredential[] {{ new HslCommunication.MQTT.MqttCredential(\"admin\", \"123456\")}} );" );
				code.AppendLine( $"// httpServer.RegisterHttpRpcApi( \"TimeOut\", typeof( HslTimeOut ) );        // 注册的类的静态方法和静态属性" );
				code.AppendLine( $"// httpServer.RegisterHttpRpcApi( \"Modbus\", modbus );                               // 注册Modbus对象到RPC接口" );
				code.AppendLine( $"// httpServer.HandleRequestFunc = HandleRequest;  // HandleRequest为方法 private object HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )" );

				codeExampleControl.RenderExampleCode( code );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( "Started Failed:" + ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			try
			{
				if (this.isStop == false)
				{
					Invoke( new Action( ( ) =>
					{
						textBox_log.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
					} ) );
					return;
				}
			}
			catch
			{

			}
		}

		private void DealWithHttpListenerRequest( HttpListenerRequest request, ISessionContext session )
		{
			// 获取ClientID信息
			string[] values = request.Headers.GetValues( "ClientID" );
			if (values?.Length > 0)
			{
				session.ClientId = values[0];
			}
		}

		private Dictionary<string, UserWebApis> userApis = new Dictionary<string, UserWebApis>();

		private void RenderGetPost( )
		{
			listBox1.SelectedValueChanged -= ListBox1_SelectedValueChanged;
			listBox1.DataSource = userApis.Values.ToList();
			listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
		}

		[HslMqttApi( HttpMethod = "POST" )]
		public OperateResult CheckAccount( ISessionContext session, string name, string password )
		{
			if (string.IsNullOrEmpty( session.ClientId ))
			{
				if (name != "admin") return new OperateResult( "用户名错误" );
				if (password != "123456") return new OperateResult( "密码错误" );
				return OperateResult.CreateSuccessResult( );
			}
			else
			{
				return new OperateResult( "ClientID: " + session.ClientId );
			}
		}

		[HslMqttApi( HttpMethod = "GET" )]
		public OperateResult CheckAccountChinese( string name, string password )
		{
			if (name != "张三") return new OperateResult( "用户名错误" );
			if (password != "123456") return new OperateResult( "密码错误" );
			return OperateResult.CreateSuccessResult( );
		}

		[HslMqttApi( HttpMethod = "GET" )]
		public OperateResult 检查AccountChinese( string name, string password )
		{
			if (name != "张三") return new OperateResult( "用户名错误" );
			if (password != "123456") return new OperateResult( "密码错误" );
			return OperateResult.CreateSuccessResult( );
		}

		[HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
		public async Task<short> ReadDatabaseAsync( string abc = "123" )
		{
			await Task.Delay( 1000 );
			return await Task.FromResult( short.Parse( abc ) );
		}

		[HslMqttApi( "异步的读取方法，需要传入字符串的值" )]
		public Task WriteDatabaseAsync( string abc = "123" )
		{
			return Task.Delay( 500 );
		}

		[HslMqttApi( HttpMethod = "GET" )]
		public int GetHslCommunication( int id )
		{
			return id + 1;
		}

		[HslMqttApi( HttpMethod = "PUT" )]
		public int PutHslCommunication( int id )
		{
			return id + 1;
		}

		[HslMqttApi( HttpMethod = "POST" )]
		public int GetTest( int id )
		{
			return id + 1;
		}

		[HslMqttApi( HttpMethod = "PUT" )]
		public int PutTest( int id )
		{
			return HslHelper.HslRandom.Next( 1000 );
		}

		[HslMqttApi( HttpMethod = "POST" )]
		public string GetJObjectTest( JObject json )
		{
			return json.ToString( );
		}

		[HslMqttApi( HttpMethod = "POST" )]
		public string RequestHeaderTest( HttpListenerRequest request, int a )
		{
			return request.RawUrl + ":" + request.LocalEndPoint + " -> " + a;
		}


		[HslMqttApi( "读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度" )]
		public short ReadFloat( ISessionContext context, string address, short length = 12345 )
		{
			// 这里举例，只控制账户hsl才能有效
			if (context?.UserName != "hsl") return -100;
			return (short)HslHelper.HslRandom.Next( 10000 );
		}

		[HslMqttApi( "读取设备的Int32信息，address: 设备的地址 length: 读取的数据长度" )]
		public string ReadInt32( ISessionContext context, string address )
		{
			return address + ":" + HslHelper.HslRandom.Next( 10000 );
		}

		[HslMqttApi( "读取设备的信息，address: 设备的地址 length: 读取的数据长度" )]
		public OperateResult<int, string> ReadABC( string address )
		{
			return OperateResult.CreateSuccessResult(HslHelper.HslRandom.Next( 1000 ), "成功:" + address );
		}

		// 处理文件信息
		private string HandleFileUpload( HttpListenerRequest request, HttpListenerResponse response, HttpUploadFile file )
		{
			// 也可以获取 request.RawUrl 来获取客户端上传的url信息，例如 /Upload/File/ 才能上传文件之类的
			File.WriteAllBytes( System.IO.Path.Combine( Application.StartupPath, file.FileName ), file.Content );
			return $"GET/POST File";
		}

		// 处理请求信息
		private object HandleRequest( HttpListenerRequest request, HttpListenerResponse response, string data )
		{
			if (request.RawUrl.StartsWith( "/FormHttpServer/" ))
			{
				// /FormHttpServer/CheckAccount            { "name" : "admin", "password" : "123456" }
				return HttpServer.HandleObjectMethod( request, request.RawUrl, data, this, action: null ).Result;
			}
			else
			{
				if (request.RawUrl == "/images/Doc/HslCommChapter3-6-6.png")    // 一个回复图片的例子
				{
					byte[] buffer = File.ReadAllBytes( "D:\\HslCommChapter6-1-4.png" );
					response.ContentType = "image/png";
					return buffer;
				}
				else if (userApis.ContainsKey( request.RawUrl ))
				{
					if (request.HttpMethod == userApis[request.RawUrl].HttpMethod)
					{
						response.AddHeader( "Content-type", $"{userApis[request.RawUrl].ContentType}; charset=utf-8" );
						return userApis[request.RawUrl].Body;
					}
					else
					{
						return $"GET/POST Wrong";
					}
				}
				return "Undefined Apis";
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 设置GET
			UserWebApis userWebApis = new UserWebApis()
			{
				Name = textBox_api.Text,
				HttpMethod = "GET",
				ContentType = comboBox1.SelectedItem.ToString(),
				Body = textBox_body.Text,
			};

			if (userApis.ContainsKey(userWebApis.Name))
				userApis[userWebApis.Name] = userWebApis;
			else
				userApis.Add(userWebApis.Name, userWebApis);

			RenderGetPost();
		}

		private void Button7_Click( object sender, EventArgs e )
		{
			// POST
			UserWebApis userWebApis = new UserWebApis()
			{
				Name = textBox_api.Text,
				HttpMethod = "POST",
				ContentType = comboBox1.SelectedItem.ToString(),
				Body = textBox_body.Text,
			};

			if (userApis.ContainsKey(userWebApis.Name))
				userApis[userWebApis.Name] = userWebApis;
			else
				userApis.Add(userWebApis.Name, userWebApis);

			RenderGetPost();
		}

		private void button_delete_Click( object sender, EventArgs e )
		{
			// Delete
			if (userApis.ContainsKey(textBox_api.Text))
				userApis.Remove(textBox_api.Text);

			RenderGetPost();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 请求
			webBrowser1.Url = new Uri( textBox1.Text );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			httpServer?.Close( );
			panel2.Enabled = false;
			button1.Enabled = true;
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue("IsCrossDomain", checkBox_IsCrossDomain.Checked);
			element.SetAttributeValue("LoginAccessControl", checkBox2.Checked);

			if (this.userApis.Count > 0)
			{
				foreach (UserWebApis item in this.userApis.Values)
				{
					element.Add(item.ToXml());
				}
			}
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox_IsCrossDomain.Checked = SoftBasic.GetXmlValue(element, "IsCrossDomain", false);
			checkBox2.Checked = SoftBasic.GetXmlValue(element, "LoginAccessControl", false);

			foreach(XElement item in element.Elements(nameof(UserWebApis)))
			{
				UserWebApis userWebApis = new UserWebApis();
				userWebApis.LoadByXml(item);

				if (userApis.ContainsKey(userWebApis.Name))
					userApis[userWebApis.Name] = userWebApis;
				else
					userApis.Add(userWebApis.Name, userWebApis);
			}

			RenderGetPost();
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}


		private void userControlHead1_Load( object sender, EventArgs e )
		{

		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				System.Diagnostics.Process.Start( linkLabel1.Text );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button_clear_Click( object sender, EventArgs e )
		{
			textBox_log.Clear( );
		}

		private bool isStop = false;

		private void button_stop_Click( object sender, EventArgs e )
		{
			if (isStop)
			{
				button_stop.Text = Program.Language == 1 ? "暂停" : "Stop";
				isStop = false;
			}
			else
			{
				button_stop.Text = Program.Language == 1 ? "继续" : "Start";
				isStop = true;
			}
		}
		private void button_device_add_Click( object sender, EventArgs e )
		{
			// 新增注册设备
			using (FormRunDeviceSelect form = new FormRunDeviceSelect( ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					httpServer?.RegisterHttpRpcApi( form.SelectedDevice.ApiName, form.SelectedDevice.Device );
					int index = dataGridView1.Rows.Add( );
					dataGridView1.Rows[index].Cells[0].Value = form.SelectedDevice.Guid;

					if (!string.IsNullOrEmpty( form.SelectedDevice.ApiName ))
						dataGridView1.Rows[index].Cells[1].Value = form.SelectedDevice.ApiName;
					else
						dataGridView1.Rows[index].Cells[1].Value = $"[{form.SelectedDevice.Name}]";

					dataGridView1.Rows[index].Cells[2].Value = form.SelectedDevice.Device.ToString( );
					dataGridView1.Rows[index].Tag = form.SelectedDevice;
				}
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 删除注册设备
			if (dataGridView1.SelectedRows.Count > 0)
			{
				var device = dataGridView1.SelectedRows[0].Tag as DemoDeviceItem;
				if (device != null)
				{
					httpServer?.UnRegisterHttpRpcApi( device.ApiName, device.Device );
					dataGridView1.Rows.RemoveAt( dataGridView1.SelectedRows[0].Index );
				}
			}
		}
	}

	public class UserWebApis
	{
		/// <summary>
		/// 获取或设置当前的接口名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 获取或设置当前接口的方式，GET，POST
		/// </summary>
		public string HttpMethod { get; set; }

		/// <summary>
		/// 获取或设置当前接口的内容样式
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// 获取或设置当前接口的主体数据
		/// </summary>
		public string Body { get; set; }

		public override string ToString() => $"[{HttpMethod}] {Name}";

		public XElement ToXml()
		{
			XElement element = new XElement(nameof(UserWebApis));
			element.SetAttributeValue(nameof(Name), Name);
			element.SetAttributeValue(nameof(HttpMethod), HttpMethod);
			element.SetAttributeValue(nameof(ContentType), ContentType);
			element.SetAttributeValue(nameof(Body), Body);
			return element;
		}


		public void LoadByXml(XElement element)
		{
			Name = SoftBasic.GetXmlValue(element, nameof(Name), Name);
			HttpMethod = SoftBasic.GetXmlValue(element, nameof(HttpMethod), HttpMethod);
			ContentType = SoftBasic.GetXmlValue<string>(element, nameof(ContentType), ContentType);
			Body = SoftBasic.GetXmlValue<string>(element, nameof(Body), Body);
		}
	}


	#endregion
}
