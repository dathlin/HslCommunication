using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.MQTT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo
{
	public partial class FormHttpClient : HslFormContent
	{
		public FormHttpClient( )
		{
			InitializeComponent( );

			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine",        Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489",             Properties.Resources.Class_489 );
			imageList.Images.Add( "Enum_582",              Properties.Resources.Enum_582 );                // string
			imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );   // 数组
			imageList.Images.Add( "Method_636",            Properties.Resources.Method_636 );              // 哈希
			imageList.Images.Add( "Module_648",            Properties.Resources.Module_648 );              // 集合
			imageList.Images.Add( "Structure_507",         Properties.Resources.Structure_507 );           // 有序集合

			treeView1.ImageList = imageList;
			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.MouseClick += TreeView1_MouseClick;

			codeExampleControl = new DemoControl.CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl1, codeExampleControl, false, DemoControl.CodeExampleControl.GetTitle( ) );
		}

		private void TreeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode node = treeView1.GetNodeAt( e.Location );
				if (node != null && node.Tag is MqttRpcApiInfo apiInfo)
				{
					treeView1.SelectedNode = node;
					if (apiInfo.Tag != null)
					{
						contextMenuStrip1.Show( treeView1, e.Location );
					}
				}
			}
		}

		private NetworkWebApiBase webApiClient;
		private string buildString = string.Empty;
		private bool hasTreeViewChanged = false;
		private HslCommunicationDemo.DemoControl.CodeExampleControl codeExampleControl;

		private async void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				webApiClient = new NetworkWebApiBase( textBox1.Text, int.Parse( textBox2.Text ), textBox3.Text, textBox4.Text );
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				webApiClient.UseHttps = checkBox1.Checked;
				webApiClient.UseEncodingISO = checkBox2.Checked;
				if (!string.IsNullOrEmpty( textBox_timeout.Text ))
				{
					webApiClient.Timeout = int.Parse( textBox_timeout.Text );
				}

				StringBuilder stringBuilder = new StringBuilder( );
				stringBuilder.Append( $"HslCommunication.Core.Net.NetworkWebApiBase webApiClient = new NetworkWebApiBase( \"{textBox1.Text}\", int.Parse(\"{textBox2.Text}\"), \"{textBox3.Text}\", \"{textBox4.Text}\" );" );
				if (checkBox1.Checked)
				{
					stringBuilder.Append( Environment.NewLine );
					stringBuilder.Append( $"webApiClient.UseHttps = {checkBox1.Checked.ToString( ).ToLower( )};" );
				}
				if (checkBox2.Checked)
				{
					stringBuilder.Append( Environment.NewLine );
					stringBuilder.Append( $"webApiClient.UseEncodingISO = {checkBox2.Checked.ToString( ).ToLower( )};" );
				}
				if (!string.IsNullOrEmpty( textBox_timeout.Text ))
				{
					stringBuilder.Append( Environment.NewLine );
					stringBuilder.Append( $"webApiClient.Timeout = {textBox_timeout.Text};" );
				}
				stringBuilder.Append( Environment.NewLine );
				stringBuilder.Append( Environment.NewLine );
				this.buildString = stringBuilder.ToString( );
				codeExampleControl.RenderExampleCode( stringBuilder );

				await MqttRpcApiRefresh( treeView1.Nodes[0] );
				tabControl2.SelectTab( tabPage4 );
			}
			catch(Exception ex)
			{
				DemoUtils.ShowMessage( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			button1.Enabled = true;
			button2.Enabled = false;
		}
		private void FormABBWebApi_Load( object sender, EventArgs e )
		{
			this.codeExampleControl.ShowTextBox( showSingleTextBox: true );

			if (Program.Language == 1)
			{
				label6.Text = "Body传入参数，如果是GET模式的话，参数需要通过地址传送，例如 GetA?id=5&&name=job";
				tabPage1.Text = "请求结果";
				tabPage6.Text = "特殊功能";
				label_content_length.Text = "字符串长度:";
			}
			else
			{
				button_request.Text = "Request";
				label6.Text = "Body input parameters, if it is in GET mode, the parameters need to be transmitted through the address, such as GetA?id=5&&name=job";
				button4.Text = "Clear";
				label11.Text = "Time-cost:";
				button8.Text = "Refresh";
				label24.Text = "[Sign]";
				label15.Text = "[Decs]";
				label_content_length.Text = "string-length:";
			}

			comboBox2.DataSource = new string[]
			{
				"none",
				"text/plain",
				"application/javascript",
				"application/json",
				"text/html",
				"application/xml",
				"multipart/form-data"
			};

			button2.Enabled = false;
			panel2.Enabled = false;
			comboBox1.DataSource = new HttpMethod[] {
				HttpMethod.Get, HttpMethod.Post, HttpMethod.Put, HttpMethod.Delete, HttpMethod.Options,
				HttpMethod.Head, HttpMethod.Trace};
			comboBox1.SelectedIndex = 0;

			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
			treeView1.Nodes[1].ImageKey = "VirtualMachine";
			treeView1.Nodes[1].SelectedImageKey = "VirtualMachine";

			dataGridView1.Location = textBox_body.Location;
			dataGridView1.Size = new Size( textBox_body.Size.Width, textBox_body.Size.Height );
			dataGridView1.Anchor = textBox_body.Anchor;

			dataGridView1.Visible = false;
		}

		private async void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if (node.Tag is MqttRpcApiInfo apiInfo)
			{
				textBox9.Text                  = apiInfo.ApiTopic;
				textBox_body.Text                  = apiInfo.ExamplePayload;
				textBox12.Text                 = apiInfo.CalledCount.ToString( );
				textBox13.Text                 = apiInfo.SpendTotalTime.ToString( "F2" );
				textBox_api_description.Text   = apiInfo.Description;
				textBox_api_sign.Text          = apiInfo.MethodSignature;
				if(apiInfo.HttpMethod.ToUpper() == "GET" )
					comboBox1.SelectedItem = HttpMethod.Get;
				else if (apiInfo.HttpMethod.ToUpper( ) == "POST")
					comboBox1.SelectedItem = HttpMethod.Post;

				if (apiInfo.Tag is HttpExtraParameter extra)
				{
					if (extra.ContentType == 0)
						radioButton_body_none.Checked = true;
					else if (extra.ContentType == 1)
						radioButton_body_form.Checked = true;
					else
						radioButton_body_string.Checked = true;
					radioButton_body_none_Click( radioButton_body_none, EventArgs.Empty );
					dataGridView1.Rows.Clear( );
					if (extra.Tables != null)
					{
						foreach (var item in extra.Tables)
						{
							int index = dataGridView1.Rows.Add( );
							dataGridView1.Rows[index].Cells[0].Value = item.Attribute( "Key" )?.Value;
							dataGridView1.Rows[index].Cells[1].Value = item.Attribute( "Value" )?.Value;
							dataGridView1.Rows[index].Cells[2].Value = item.Attribute( "Desc" )?.Value;
						}
					}
					return;
				}
				else
				{
					radioButton_body_string.Checked = true;
				}

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
						DemoUtils.ShowMessage( ex.Message + Environment.NewLine + read.Content );
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
					richTextBox1.Text = JArray.FromObject( apis ).ToString( );
				}
			}
		}

		private async void thread_test1( )
		{
			string url = textBox9.Text;
			string body = textBox_body.Text;
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
					DemoUtils.ShowMessage( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}

		private string GetHttpMethodCode( HttpMethod httpMethod )
		{
			if (httpMethod.Method.Equals( "GET", StringComparison.OrdinalIgnoreCase ))     return "HttpMethod.Get";
			if (httpMethod.Method.Equals( "POST", StringComparison.OrdinalIgnoreCase ))    return "HttpMethod.Post";
			if (httpMethod.Method.Equals( "Put", StringComparison.OrdinalIgnoreCase ))     return "HttpMethod.Put";
			if (httpMethod.Method.Equals( "Delete", StringComparison.OrdinalIgnoreCase ))  return "HttpMethod.Delete";
			if (httpMethod.Method.Equals( "Options", StringComparison.OrdinalIgnoreCase )) return "HttpMethod.Options";
			if (httpMethod.Method.Equals( "Trace", StringComparison.OrdinalIgnoreCase ))   return "HttpMethod.Trace";
			if (httpMethod.Method.Equals( "Head", StringComparison.OrdinalIgnoreCase ))    return "HttpMethod.Head";
			return $"new HttpMethod( \"{httpMethod.Method}\" )";
		}

		private void RequestResultAppend(StringBuilder sb)
		{
			sb.AppendLine( $"if (request.IsSuccess)" );
			sb.AppendLine( "{" );
			sb.AppendLine( "    Console.WriteLine( \"结果：\" + request.Content );" );
			sb.AppendLine( "}" );
			sb.AppendLine( "else" );
			sb.AppendLine( "{" );
			sb.AppendLine( "    Console.WriteLine( \"失败：\" + request.ToMessageShowString( ) );" );
			sb.AppendLine( "}" );
		}

		private async Task<OperateResult<string>> ReadFromServer( NetworkWebApiBase webApiBase, HttpMethod httpMethod, string url, string body )
		{
			textBox_url_example.Text = webApiBase.GetEntireUrl( url );
			string contentType = comboBox2.SelectedItem == null ? comboBox2.Text : comboBox2.SelectedItem.ToString( );
			string bodyContent = string.IsNullOrEmpty( body ) ? "\"\"" : JsonConvert.SerializeObject( body );
			if (httpMethod.Method.Equals( "GET", StringComparison.OrdinalIgnoreCase )) bodyContent = "\"\"";

			StringBuilder code = new StringBuilder( this.buildString ); // \"{body}\"
			code.AppendLine( $"OperateResult<string> request = await webApiClient.RequestAsync( {GetHttpMethodCode( httpMethod )}, \"{url}\", {bodyContent}, \"{contentType}\" );" );
			RequestResultAppend( code );

			codeExampleControl.RenderExampleCode( code );
			return await webApiBase.RequestAsync( httpMethod, url, body, contentType );
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
			if (key.StartsWith( "http://", StringComparison.OrdinalIgnoreCase ) || key.StartsWith( "https://", StringComparison.OrdinalIgnoreCase ))
			{
				index = key.IndexOf( '/', 8 );
			}
			if (index <= 0)
			{
				// 不存在分割符号
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


		private string getJPropertValue( JProperty jProperty )
		{
			if (jProperty.Value.Type == JTokenType.Array)
			{
				JArray jArray = (JArray)jProperty.Value;
				StringBuilder sb = new StringBuilder( $"{jProperty.Name}=" );
				for (int i = 0; i < jArray.Count; i++)
				{
					sb.Append( jArray[i] );
					if (i < jArray.Count - 1) sb.Append( ";" );
				}
				return sb.ToString( );
			}
			else
			{
				return $"{jProperty.Name}={jProperty.Value}";
			}	
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			button_request.Enabled = false;

			HttpMethod httpMethod = (HttpMethod)comboBox1.SelectedItem;
			string url = textBox9.Text;
			if (httpMethod == HttpMethod.Get && !url.Contains( "?" ) && !string.IsNullOrEmpty( textBox_body.Text))
			{
				try
				{
					JObject json = JObject.Parse( textBox_body.Text );
					url += "?" + string.Join( "&", json.Properties( ).Select( m => getJPropertValue( m ) ) );
				}
				catch
				{

				}
			}

			OperateResult<string> read = null;

			if (radioButton_body_none.Checked)
			{
				read = await ReadFromServer( webApiClient, httpMethod, url, null );
			}
			else if (radioButton_body_string.Checked)
			{
				read = await ReadFromServer( webApiClient, httpMethod, url, textBox_body.Text );
			}
			else
			{
				StringBuilder code = new StringBuilder( buildString );
				// 1. 构建 form-data 内容
				MultipartFormDataContent formData = new MultipartFormDataContent( );
				code.AppendLine( "MultipartFormDataContent formData = new MultipartFormDataContent( );" );

				// 添加普通字符串参数（参数名：key，值：value）
				for( int i = 0; i < dataGridView1.Rows.Count; i++ )
				{
					DataGridViewRow row = dataGridView1.Rows[i];

					if (row.IsNewRow) continue;
					if (row.Cells[0].Value == null) continue;

					string key = row.Cells[0].Value != null ? row.Cells[0].Value.ToString( ) : string.Empty;
					string value = row.Cells[1].Value != null ? row.Cells[1].Value.ToString( ) : string.Empty;

					formData.Add( new StringContent( value, Encoding.UTF8 ), key );
					code.AppendLine( $"formData.Add( new StringContent( {JsonConvert.SerializeObject( value )}, Encoding.UTF8 ), \"{key}\" );" );
				}

				read = await webApiClient.RequestAsync( httpMethod, url, formData );
				code.AppendLine( $"OperateResult<string> request = await webApiClient.RequestAsync( {GetHttpMethodCode( httpMethod )}, \"{url}\", formData );" );
				RequestResultAppend( code );
				textBox_url_example.Text = webApiClient.GetEntireUrl( url );
				codeExampleControl.RenderExampleCode( code );
			}

			button_request.Enabled = true;
			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { DemoUtils.ShowMessage( "Read Failed:" + read.ToMessageShowString( ) ); return; }


			// 此处应该修改demo里的RPC接口的默认参数功能
			if (mqttRpcApiInfos != null)
			{
				MqttRpcApiInfo api = mqttRpcApiInfos.FirstOrDefault( m => m.ApiTopic == textBox_body.Text );
				if (api != null)
				{
					api.ExamplePayload = textBox_body.Text;
				}
			}

			string msg = read.Content;
			label_content_length.Text = Program.Language == 1 ? "字符串长度: " + msg.Length : "string-length: " + msg.Length;

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

			richTextBox1.Text = msg;
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox4.Text );
			element.SetAttributeValue( "UseHttps", checkBox1.Checked );
			element.SetAttributeValue( "UseEncodingISO", checkBox2.Checked );
			element.SetAttributeValue( "Timeout", textBox_timeout.Text );

			// 存储用户保存的接口信息
			foreach( MqttRpcApiInfo api in userSaveApis.Values )
			{
				XElement apiElement = new XElement( "UserSaveApi" );
				apiElement.SetAttributeValue( "ApiTopic", api.ApiTopic );
				apiElement.SetAttributeValue( "Description", api.Description );
				apiElement.SetAttributeValue( "MethodSignature", api.MethodSignature );
				apiElement.SetAttributeValue( "ExamplePayload", api.ExamplePayload );
				apiElement.SetAttributeValue( "HttpMethod", api.HttpMethod );
				if (api.Tag is HttpExtraParameter extra)
				{
					XElement extraElement = new XElement( "HttpExtraParameter" );
					extraElement.SetAttributeValue( "ContentType", extra.ContentType );
					foreach (var table in extra.Tables)
					{
						extraElement.Add( table );
					}
					apiElement.Add( extraElement );
				}
				element.Add( apiElement );
			}

			this.hasTreeViewChanged = false;
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox4.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
			checkBox1.Checked    = GetXmlValue( element, "UseHttps", false, bool.Parse );
			checkBox2.Checked    = GetXmlValue( element, "UseEncodingISO", false, bool.Parse );
			textBox_timeout.Text = GetXmlValue( element, "Timeout", "", m => m );

			// 读取用户保存的接口信息
			var apiElements = element.Elements( "UserSaveApi" );
			if (apiElements != null)
			{
				foreach (var apiElement in apiElements)
				{
					MqttRpcApiInfo apiInfo = new MqttRpcApiInfo( );
					apiInfo.ApiTopic        = GetXmlValue( apiElement, "ApiTopic", "", m => m );
					apiInfo.Description     = GetXmlValue( apiElement, "Description", "", m => m );
					apiInfo.MethodSignature = GetXmlValue( apiElement, "MethodSignature", "", m => m );
					apiInfo.ExamplePayload  = GetXmlValue( apiElement, "ExamplePayload", "", m => m );
					apiInfo.HttpMethod      = GetXmlValue( apiElement, "HttpMethod", "GET", m => m );
					apiInfo.IsMethodApi     = true;
					var extraElement = apiElement.Element( "HttpExtraParameter" );
					if (extraElement != null)
					{
						HttpExtraParameter extra = new HttpExtraParameter( );
						extra.ContentType = GetXmlValue( extraElement, "ContentType", 0, int.Parse );
						extra.Tables = new List<XElement>( );
						var tableElements = extraElement.Elements( "FormTableItem" );
						if (tableElements != null)
						{
							foreach (var tableElement in tableElements)
							{
								extra.Tables.Add( tableElement );
							}
						}
						apiInfo.Tag = extra;
					}

					if (!userSaveApis.ContainsKey( apiInfo.ApiTopic ))
						userSaveApis.Add( apiInfo.ApiTopic, apiInfo );
					else
						userSaveApis[apiInfo.ApiTopic] = apiInfo;
				}
			}
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			try
			{
				JObject json = JObject.Parse( textBox_body.Text );
				Clipboard.SetText( JsonConvert.SerializeObject( json.ToString( Newtonsoft.Json.Formatting.None ) ) );
			}
			catch(Exception ex)
			{
				DemoUtils.ShowMessage( "JObject.Parse failed: " + ex.Message );
			}
		}

		private void radioButton_body_none_Click( object sender, EventArgs e )
		{
			if (radioButton_body_form.Checked)
			{
				dataGridView1.Visible = true;
				textBox_body.Visible = false;
			}
			else if (radioButton_body_string.Checked)
			{
				textBox_body.Visible= true;
				dataGridView1.Visible = false;
			}
		}

		private void button_Save_Click( object sender, EventArgs e )
		{
			// 将当前的请求方法保存到用户列表里
			MqttRpcApiInfo rpcApiInfo = new MqttRpcApiInfo( );
			rpcApiInfo.HttpMethod = ((HttpMethod)comboBox1.SelectedItem).Method;
			rpcApiInfo.ApiTopic = textBox9.Text;
			rpcApiInfo.MethodSignature = textBox_api_sign.Text;
			rpcApiInfo.Description = textBox_api_description.Text;
			rpcApiInfo.ExamplePayload = textBox_body.Text;

			HttpExtraParameter httpExtraParameter = new HttpExtraParameter( );
			httpExtraParameter.ContentType = radioButton_body_none.Checked ? 0 : radioButton_body_form.Checked ? 1 : 2;
			httpExtraParameter.Tables = new List<XElement>( );
			if (dataGridView1.Rows.Count > 0)
			{
				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					DataGridViewRow row = dataGridView1.Rows[i];
					if (row.IsNewRow) continue;
					if (row.Cells[0].Value == null) continue;

					XElement xml = new XElement( "FormTableItem" );
					xml.SetAttributeValue( "Key", row.Cells[0].Value );
					xml.SetAttributeValue( "Value", row.Cells[1].Value );
					xml.SetAttributeValue( "Desc", row.Cells[2].Value );

					httpExtraParameter.Tables.Add( xml );
				}
			}

			rpcApiInfo.Tag = httpExtraParameter;
			if (userSaveApis.ContainsKey( rpcApiInfo.ApiTopic ))
				userSaveApis[rpcApiInfo.ApiTopic] = rpcApiInfo;
			else
				userSaveApis.Add(rpcApiInfo.ApiTopic, rpcApiInfo);

			MqttRpcApiRefresh( treeView1.Nodes[1], userSaveApis.Values.ToList( ) );
			this.hasTreeViewChanged = true;
		}

		private void MqttRpcApiRefresh( TreeNode rootNode, List<MqttRpcApiInfo> apis )
		{
			rootNode.Nodes.Clear( );
			// 填充tree
			foreach (var item in apis)
			{
				AddTreeNode( rootNode, item.ApiTopic, item.ApiTopic, item );
			}

			rootNode.Expand( );
		}
		private Dictionary<string, MqttRpcApiInfo> userSaveApis = new Dictionary<string, MqttRpcApiInfo>( );

		private void FormHttpClient_Shown( object sender, EventArgs e )
		{
			if (userSaveApis.Count > 0)
			{
				MqttRpcApiRefresh( treeView1.Nodes[1], userSaveApis.Values.ToList( ) );
			}
		}

		private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// 点击了删除操作
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if (node.Tag is MqttRpcApiInfo apiInfo)
			{
				if ( apiInfo.Tag != null && userSaveApis.ContainsKey( apiInfo.ApiTopic ))
				{
					if (userSaveApis.Remove( apiInfo.ApiTopic ))
					{
						node.Remove( );
						this.hasTreeViewChanged = true;
					}
				}
			}
		}

		private void FormHttpClient_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (this.hasTreeViewChanged)
			{
				if (Program.Language == 1)
				{
					if (MessageBox.Show( "当前窗口界面的用户API列表还没有保存，请确认是否退出？", "关闭确认", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
						return;
					}
				}
				else
				{
					// 英文
					if (MessageBox.Show( "The list of user apis in the current window interface has not been saved yet. Please confirm whether to exit?", "Exit Check", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
						return;
					}
				}
			}

			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
	}

	public class HttpExtraParameter
	{
		public int ContentType { get; set; }

		public List<XElement> Tables { get; set; }
	}
}
