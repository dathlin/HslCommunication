using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Core.Net;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.MQTT;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Threading;

namespace HslCommunicationDemo
{
	public partial class FormHttpClient : HslFormContent
	{
		public FormHttpClient( )
		{
			InitializeComponent( );
		}

		private NetworkWebApiBase webApiClient;

		private async void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				webApiClient = new NetworkWebApiBase( textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text );
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				webApiClient.UseHttps = checkBox1.Checked;
				webApiClient.UseEncodingISO = checkBox2.Checked;
				await MqttRpcApiRefresh( treeView1.Nodes[0] );
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			button1.Enabled = true;
			button2.Enabled = false;
		}
		private void FormABBWebApi_Load( object sender, EventArgs e )
		{
			if(Program.Language == 1)
				label6.Text = "Body传入参数，如果是GET模式的话，参数需要通过地址传送，例如 GetA?id=5&&name=job";
			else
				label6.Text = "Body input parameters, if it is in GET mode, the parameters need to be transmitted through the address, such as GetA?id=5&&name=job";

			comboBox2.DataSource = new string[]
			{
				"none",
				"text/plain",
				"application/javascript",
				"application/json",
				"text/html",
				"application/xml"
			};

			button2.Enabled = false;
			panel2.Enabled = false;
			comboBox1.DataSource = new HttpMethod[] {
				HttpMethod.Get, HttpMethod.Post, HttpMethod.Put, HttpMethod.Delete, HttpMethod.Options,
				HttpMethod.Head, HttpMethod.Trace};
			comboBox1.SelectedIndex = 0;

			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine", Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
			imageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );             // string
			imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );   // 数组
			imageList.Images.Add( "Method_636", Properties.Resources.Method_636 );         // 哈希
			imageList.Images.Add( "Module_648", Properties.Resources.Module_648 );         // 集合
			imageList.Images.Add( "Structure_507", Properties.Resources.Structure_507 );   // 有序集合

			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";

		}

		private async void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if (node.Tag is MqttRpcApiInfo apiInfo)
			{
				textBox9.Text                  = apiInfo.ApiTopic;
				textBox5.Text                  = apiInfo.ExamplePayload;
				textBox12.Text                 = apiInfo.CalledCount.ToString( );
				textBox13.Text                 = apiInfo.SpendTotalTime.ToString( "F2" );
				textBox_api_description.Text   = apiInfo.Description;
				textBox_api_sign.Text          = apiInfo.MethodSignature;
				if(apiInfo.HttpMethod.ToUpper() == "GET" )
					comboBox1.SelectedItem = HttpMethod.Get;
				else if (apiInfo.HttpMethod.ToUpper( ) == "POST")
					comboBox1.SelectedItem = HttpMethod.Post;

				OperateResult<string> read = await ReadFromServer( this.webApiClient, new HttpMethod( "HSL" ), "Logs/" + apiInfo.ApiTopic, "" );
				if (read.IsSuccess)
				{
					try
					{
						if (!string.IsNullOrEmpty( read.Content ) && read.Content != "null")
						{
							long[] data = JArray.Parse( read.Content ).ToObject<long[]>( ).SelectLast( 7 );
							int[] ydata = new int[7];
							string[] xdata = new string[7];
							for (int i = 0; i < 7; i++)
							{
								ydata[i] = (int)data[i];
								xdata[i] = DateTime.Now.AddDays( i - 6 ).ToString( "M-d" );
								hslBarChart1.SetDataSource( ydata, xdata );
							}
						}
						else
						{
							hslBarChart1.SetDataSource( new int[7] );
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show( ex.Message + Environment.NewLine + read.Content );
					}
				}
			}
		}

		MqttRpcApiInfo[] mqttRpcApiInfos;


		private async Task<MqttRpcApiInfo[]> ReadMqttRpcApiInfo( NetworkWebApiBase webApiBase )
		{
			string url = $"{(checkBox1.Checked ? "https" : "http")}://{webApiBase.IpAddress}:{webApiBase.Port}/Apis";
			try
			{
				using (HttpRequestMessage request = new HttpRequestMessage( new HttpMethod( "HSL" ), url ))
				{
					using (HttpResponseMessage response = await webApiBase.Client.SendAsync( request ))
					using (HttpContent content = response.Content)
					{
						response.EnsureSuccessStatusCode( );
						string result = await content.ReadAsStringAsync( );

						return JArray.Parse( result ).ToObject<MqttRpcApiInfo[]>( );
					}
				}
			}
			catch
			{
				//HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
				return null;
			}
		}

		private MqttRpcApiInfo[] ReadMqttRpcApiInfo2( )
		{
			try
			{
				string url = $"{(checkBox1.Checked ? "https" : "http")}://{webApiClient.IpAddress}:{webApiClient.Port}/Apis";
				var httpWebRequest = (HttpWebRequest)WebRequest.Create( url );
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.KeepAlive = false;
				httpWebRequest.AllowAutoRedirect = true;
				httpWebRequest.CookieContainer = new CookieContainer( );
				httpWebRequest.Accept = "application/json, text/javascript, */*; q=0.01";
				httpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36";

				if (!string.IsNullOrEmpty( textBox3.Text ))
					httpWebRequest.Credentials = new NetworkCredential( textBox3.Text, textBox4.Text );
				httpWebRequest.Method = "HSL";
				httpWebRequest.Timeout = 10_000;
				string result = "";
				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse( );

				using (var streamReader = new StreamReader( httpResponse.GetResponseStream( ) ))
				{
					result = streamReader.ReadToEnd( );
				}
				return JArray.Parse( result ).ToObject<MqttRpcApiInfo[]>( );

			}
			catch
			{
				return null;
			}
		}

		private bool isTest = false;
		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private long successCount = 0;


		private async void button7_Click( object sender, EventArgs e )
		{
			// 进行测试操作，开启4个线程
			if(isTest)
			{
				thread_status = 4;
				failed = 0;
				thread_time_start = DateTime.Now;
				new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
				new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
				new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
				new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
				button7.Enabled = false;
			}
			else
			{
				MqttRpcApiInfo[] apis = await ReadMqttRpcApiInfo( webApiClient );
				if (apis != null)
				{
					textBox8.Text = JArray.FromObject( apis ).ToString( );
				}
			}
		}

		private async void thread_test1( )
		{
			string url = textBox9.Text;
			string body = textBox5.Text;
			int count = 10000;
			while (count > 0)
			{
				OperateResult<string> read = await webApiClient.PostAsync( url, new { id = count }.ToJsonString( ) );
				if (!read.IsSuccess) failed++;
				else
				{
					if (read.Content != (count + 1).ToString( )) failed++;
				}
				count--;
				successCount++;
			}
			thread_end( );
		}

		private void thread_end( )
		{
			if (Interlocked.Decrement( ref thread_status ) == 0)
			{
				// 执行完成
				Invoke( new Action( ( ) =>
				{
					label2.Text = successCount.ToString( );
					button7.Enabled = true;
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}

		private async Task<OperateResult<string>> ReadFromServer( NetworkWebApiBase webApiBase, HttpMethod httpMethod, string url, string body )
		{
			if (url.StartsWith( "http://", StringComparison.OrdinalIgnoreCase ) || url.StartsWith( "https://", StringComparison.OrdinalIgnoreCase ))
			{

			}
			else
			{
				url = $"{(checkBox1.Checked ? "https" : "http")}://{webApiBase.Host}:{webApiBase.Port}/{(url.StartsWith( "/" ) ? url.Substring( 1 ) : url)}";
			}

			label_url.Text = url;
			//textBox8.Text = url;
			try
			{
				using (HttpRequestMessage request = new HttpRequestMessage( httpMethod, url ))
				{
					if (httpMethod != HttpMethod.Get)
					{
						request.Content = new StringContent( body );
						string contentType = comboBox2.SelectedItem == null ? comboBox2.Text : comboBox2.SelectedItem.ToString( );
						if(contentType!="none")
							request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue( contentType );
					}
					if (!string.IsNullOrEmpty( textBox3.Text ))
					{
						request.Headers.Add( "Authorization", "Basic " + Convert.ToBase64String( Encoding.UTF8.GetBytes( textBox3.Text + ":" + textBox4.Text ) ) );
					}

					using (HttpResponseMessage response = await webApiBase.Client.SendAsync( request ))
					{
						using (HttpContent content = response.Content)
						{
							response.EnsureSuccessStatusCode( );
							return OperateResult.CreateSuccessResult( await content.ReadAsStringAsync( ) );
						}
					}
				}
			}
			catch (Exception ex)
			{
				//HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
				return new OperateResult<string>( ex.Message + Environment.NewLine + "Url: " + url );
			}
		}

		private async Task MqttRpcApiRefresh( TreeNode rootNode )
		{
			rootNode.Nodes.Clear( );
			// 加载所有的键值信息
			mqttRpcApiInfos = await Task.Run( ( ) => ReadMqttRpcApiInfo2( ) );//  await ReadMqttRpcApiInfo( webApiClient ); 
			if (mqttRpcApiInfos == null) return;

			// 填充tree
			foreach (var item in mqttRpcApiInfos)
			{
				AddTreeNode( rootNode, item.ApiTopic, item.ApiTopic, item );
			}

			rootNode.Expand( );
		}

		private async void button8_Click( object sender, EventArgs e )
		{
			await MqttRpcApiRefresh( treeView1.Nodes[0] );
		}

		private void AddTreeNode( TreeNode parent, string key, string infactKey, MqttRpcApiInfo mqttRpc )
		{
			int index = key.IndexOf( '/' );
			if (index <= 0)
			{
				// 不存在冒号
				TreeNode node = new TreeNode( $"{key}" );
				node.Tag = mqttRpc;
				node.ImageKey = mqttRpc.IsMethodApi ? "Method_636" : "Enum_582";
				node.SelectedImageKey = mqttRpc.IsMethodApi ? "Method_636" : "Enum_582";
				parent.Nodes.Add( node );
			}
			else
			{
				TreeNode node = null;
				for (int i = 0; i < parent.Nodes.Count; i++)
				{
					if (parent.Nodes[i].Text == key.Substring( 0, index ))
					{
						node = parent.Nodes[i];
						break;
					}
				}

				if (node == null)
				{
					node = new TreeNode( key.Substring( 0, index ) );
					node.ImageKey = "Class_489";
					node.SelectedImageKey = "Class_489";
					AddTreeNode( node, key.Substring( index + 1 ), infactKey, mqttRpc );
					parent.Nodes.Add( node );
				}
				else
				{
					AddTreeNode( node, key.Substring( index + 1 ), infactKey, mqttRpc );
				}
			}
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			button3.Enabled = false;
			OperateResult<string> read = await ReadFromServer( webApiClient, (HttpMethod)comboBox1.SelectedItem, textBox9.Text, textBox5.Text );


			button3.Enabled = true;
			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) ); return; }


			// 此处应该修改demo里的RPC接口的默认参数功能
			if (mqttRpcApiInfos != null)
			{
				MqttRpcApiInfo api = mqttRpcApiInfos.FirstOrDefault( m => m.ApiTopic == textBox5.Text );
				if (api != null)
				{
					api.ExamplePayload = textBox5.Text;
				}
			}

			string msg = read.Content;
			if (radioButton4.Checked)
			{
				try
				{
					msg = System.Xml.Linq.XElement.Parse( msg ).ToString( );
				}
				catch
				{

				}
			}
			else if (radioButton5.Checked)
			{
				try
				{
					msg = Newtonsoft.Json.Linq.JObject.Parse( msg ).ToString( );
				}
				catch
				{

				}
			}
			else if (radioButton_response_hex.Checked)
			{
				msg = Encoding.UTF8.GetBytes( msg ).ToHexString( ' ' );
			}

			textBox8.Text = msg;
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox4.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox4.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
