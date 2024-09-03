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

namespace HslCommunicationDemo
{
	#region FormSimplifyNet

	public partial class FormHttpServer : HslFormContent
	{
		public FormHttpServer( )
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
			listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
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

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
			}
		}

		private AllenBradleyPcccNet pcccNet;
		private SiemensS7Net siemens;
		private HttpServer httpServer;

		private void button1_Click( object sender, EventArgs e )
		{
			// 启动服务
			//try
			//{
			// 注册两个PLC为服务接口的示例
			siemens = new SiemensS7Net( SiemensPLCS.S1200, "127.0.0.1" );
			pcccNet = new AllenBradleyPcccNet( "127.0.0.1" );

			httpServer = new HttpServer( );
			if (checkBox_https.Checked)
			{
				httpServer.UseHttps( );
			}
			httpServer.Start( int.Parse( textBox2.Text ) );
			httpServer.HandleRequestFunc = HandleRequest;
			httpServer.HandleFileUpload = HandleFileUpload;
			httpServer.IsCrossDomain = checkBox_IsCrossDomain.Checked;               // 是否跨域的设置
			httpServer.RegisterHttpRpcApi( "", this );                               // 注册当前窗体的接口到服务器的接口上去
			httpServer.RegisterHttpRpcApi( "Siemens", siemens );                     // 注册一个西门子PLC的服务接口的示例
			httpServer.RegisterHttpRpcApi( "TimeOut", typeof( HslTimeOut ) );        // 注册的类的静态方法和静态属性
			httpServer.RegisterHttpRpcApi( "PCCC", pcccNet );
			httpServer.DealWithHttpListenerRequest = DealWithHttpListenerRequest;    // 自定义处理请求的接口，比如增加认证信息
			if (checkBox2.Checked) httpServer.SetLoginAccessControl( new HslCommunication.MQTT.MqttCredential[] {
				new HslCommunication.MQTT.MqttCredential("admin", "123456")} );

			panel2.Enabled = true;
			button1.Enabled = false;
			//}
			//catch(Exception ex)
			//{
			//	MessageBox.Show( "Started Failed:" + ex.Message );
			//}
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
				MessageBox.Show( ex.Message );
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
