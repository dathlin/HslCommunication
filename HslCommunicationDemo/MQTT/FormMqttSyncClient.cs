using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.MQTT;
using HslCommunication;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	#region FormMqttSyncClient


	public partial class FormMqttSyncClient : HslFormContent
	{
		public FormMqttSyncClient( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			panel4.Enabled = false;
			button2.Enabled = false;

			Language( Program.Language );
			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine",        Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489",             Properties.Resources.Class_489 );
			imageList.Images.Add( "Enum_582",              Properties.Resources.Enum_582 );             // string
			imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );   // 数组
			imageList.Images.Add( "Method_636",            Properties.Resources.Method_636 );         // 哈希
			imageList.Images.Add( "Module_648",            Properties.Resources.Module_648 );         // 集合
			imageList.Images.Add( "Structure_507",         Properties.Resources.Structure_507 );   // 有序集合

			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
			treeView1.Nodes[1].ImageKey = "VirtualMachine";
			treeView1.Nodes[1].SelectedImageKey = "VirtualMachine";

			panel5.Visible = false;
			panel2.Dock = DockStyle.Fill;
			panel5.Dock = DockStyle.Fill;
		}

		private void Language( int language )
		{
			if (language == 1)
			{

			}
			else
			{
				Text = "Mqtt Sync Client [RPC remote call client]";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label7.Text = "Topic:";
				label9.Text = "Payload:";
				button3.Text = "Read";
				button4.Text = "Clear";
				label12.Text = "R-Topic:";
				label5.Text = "R-Payload:";
				button3.Text = "Read";
				hslProgress1.TextRenderFormat = "Send {0}%";
				hslProgress2.TextRenderFormat = "Receive {0}%";
				label6.Text = "Client ID:";
				label2.Text = "UserName:";
				label4.Text = "Password:";
				label11.Text = "Spend-Time:";
				button8.Text = "Refresh";
			}
		}

		private MqttSyncClient mqttSyncClient;

		private async void button1_Click( object sender, EventArgs e )
		{
			// 连接
			MqttConnectionOptions options = new MqttConnectionOptions( )
			{
				IpAddress = textBox1.Text,
				Port = int.Parse( textBox2.Text ),
				ClientId = textBox3.Text,
			};
			if(!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty( textBox10.Text ))
			{
				options.Credentials = new MqttCredential( textBox9.Text, textBox10.Text );
			}

			button1.Enabled = false;
			mqttSyncClient = new MqttSyncClient( options );
			OperateResult connect = await mqttSyncClient.ConnectServerAsync( );

			if(connect.IsSuccess)
			{
				panel2.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
				panel4.Enabled = true;
				panel2.Enabled = true;
				MqttRpcApiRefresh( treeView1.Nodes[0] );
				TopicsRefresh( treeView1.Nodes[1] );
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				button1.Enabled = true;
				MessageBox.Show( connect.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			panel4.Enabled = false;

			mqttSyncClient.ConnectClose( );
		}

		private void SendProgressReport(long already, long total )
		{
			// already : 已发送的字节数
			// total : 总计发送的字节数
			if (InvokeRequired)
			{
				Invoke( new Action<long, long>( SendProgressReport ), already, total );
				return;
			}

			hslProgress1.Value = (int)(already * 100 / total);
		}

		private void ReceiveProgressReport( long already, long total )
		{
			// already : 已接收的字节数
			// total : 总计接收的字节数
			if (InvokeRequired)
			{
				Invoke( new Action<long, long>( ReceiveProgressReport ), already, total );
				return;
			}

			hslProgress2.Value = (int)(already * 100 / total);
		}


		private async void button3_Click( object sender, EventArgs e )
		{
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button3.Enabled = false;
			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync(
				textBox5.Text, Encoding.UTF8.GetBytes( textBox4.Text ),
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) );
			button3.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) ); return; }


			// 此处应该修改demo里的RPC接口的默认参数功能
			if (mqttRpcApiInfos != null)
			{
				MqttRpcApiInfo api = mqttRpcApiInfos.FirstOrDefault( m => m.ApiTopic == textBox5.Text );
				if (api != null)
				{
					api.ExamplePayload = textBox4.Text;
				}
			}

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg;
		}


		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 大批量数据上传的情况
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button5.Enabled = false;

			// 编造一条1M的数据
			byte[] buffer = new byte[1024 * 1024];
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = 0x30;
			}

			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync( textBox5.Text, buffer,
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) ) ;
			button5.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Rend Failed:" + read.Message ); return; }

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg;
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			hslProgress1.Value = 0;
			hslProgress2.Value = 0;
			DateTime start = DateTime.Now;
			button6.Enabled = false;
			OperateResult<string, byte[]> read = await mqttSyncClient.ReadAsync(
				"C", Encoding.UTF8.GetBytes( textBox4.Text ),
				new Action<long, long>( SendProgressReport ), null,
				new Action<long, long>( ReceiveProgressReport ) );
			button6.Enabled = true;

			textBox7.Text = (int)(DateTime.Now - start).TotalMilliseconds + " ms";
			if (!read.IsSuccess) { MessageBox.Show( "Rend Failed:" + read.Message ); return; }

			textBox6.Text = read.Content1;
			string msg = Encoding.UTF8.GetString( read.Content2 );
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

			textBox8.Text = msg?.Length > 10000 ? msg.Substring( 0, 10000 ) + "..." : msg;
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<MqttRpcApiInfo[]> read = mqttSyncClient.ReadRpcApis( );
			if (read.IsSuccess)
			{
				textBox8.Text = read.Content.ToJsonString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			MqttRpcApiRefresh( treeView1.Nodes[0] );
			TopicsRefresh( treeView1.Nodes[1] );
		}

		public void UpdateMqttTopicMessage( MqttClientApplicationMessage message )
		{
			textBox19.Text = message.ClientId;
			textBox14.Text = message.UserName;
			label18.Text = message.CreateTime.ToString( );
			textBox16.Text = message.Topic;
			label8.Text = message.QualityOfServiceLevel.ToString( );
			string msg = Encoding.UTF8.GetString( message.Payload );

			if (radioButton6.Checked)
			{
				try
				{
					msg = XElement.Parse( msg ).ToString( );
				}
				catch
				{

				}
			}
			else if (radioButton1.Checked)
			{
				try
				{
					msg = Newtonsoft.Json.Linq.JObject.Parse( msg ).ToString( );
				}
				catch
				{

				}
			}

			textBox17.Text = msg?.Length > 10000 ? msg.Substring( 0, 10000 ) + "..." : msg;
		}

		MqttRpcApiInfo[] mqttRpcApiInfos;

		private void MqttRpcApiRefresh( TreeNode rootNode )
		{
			rootNode.Nodes.Clear( );
			// 加载所有的键值信息
			OperateResult<MqttRpcApiInfo[]> read = mqttSyncClient.ReadRpcApis( );
			if (!read.IsSuccess) return;


			mqttRpcApiInfos = read.Content;
			// 填充tree
			foreach (var item in read.Content)
			{
				AddTreeNode( rootNode, item.ApiTopic, item.ApiTopic, item );
			}

			rootNode.Expand( );
		}

		private void TopicsRefresh( TreeNode rootNode )
		{

			rootNode.Nodes.Clear( );
			// 加载所有的键值信息
			OperateResult<string[]> read = mqttSyncClient.ReadRetainTopics( );
			if (!read.IsSuccess) return;

			// 填充tree
			foreach (var item in read.Content)
			{
				AddTopicTreeNode( rootNode, item, item );
			}

			rootNode.Expand( );
		}

		private void AddTopicTreeNode( TreeNode parent, string key, string infactKey )
		{
			int index = key.IndexOf( '/' );
			if (index <= 0)
			{
				// 不存在冒号
				TreeNode node = new TreeNode( $"{key}" );
				node.Tag = infactKey;
				node.ImageKey = "Enum_582";
				node.SelectedImageKey = "Enum_582";
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
					AddTopicTreeNode( node, key.Substring( index + 1 ), infactKey );
					parent.Nodes.Add( node );
				}
				else
				{
					AddTopicTreeNode( node, key.Substring( index + 1 ), infactKey );
				}
			}
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

		private async void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			if(node.SelectedImageKey == "VirtualMachine")
			{
				if(node.Text == "Rpc Apis")
				{
					panel5.Visible = false;
					panel2.Visible = true;
				}
				else
				{
					panel5.Visible = true;
					panel2.Visible = false;
				}
			}
			else if(node.Tag is MqttRpcApiInfo apiInfo)
			{
				panel5.Visible = false;
				panel2.Visible = true;

				textBox5.Text = apiInfo.ApiTopic;
				textBox4.Text = apiInfo.ExamplePayload;
				textBox12.Text = apiInfo.CalledCount.ToString( );
				textBox13.Text = apiInfo.SpendTotalTime.ToString( "F2" );
				label15.Text = apiInfo.Description;


				OperateResult<long[]> read = mqttSyncClient.ReadRpcApiLog( apiInfo.ApiTopic );
				if (read.IsSuccess)
				{
					long[] data = read.Content.SelectLast( 7 );
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
			else if(node.Tag is string topic)
			{
				panel5.Visible = true;
				panel2.Visible = false;

				hslProgress3.Value = 0;
				OperateResult<MqttClientApplicationMessage> message = await mqttSyncClient.ReadTopicPayloadAsync( topic, ReceiveTopicProgressReport );
				if (!message.IsSuccess)
				{
					MessageBox.Show( "Failed: " + message.Message );
				}
				else
				{
					UpdateMqttTopicMessage( message.Content );
				}
			}
		}
		private void ReceiveTopicProgressReport( long already, long total )
		{
			// already : 已接收的字节数
			// total : 总计接收的字节数
			if (InvokeRequired)
			{
				Invoke( new Action<long, long>( ReceiveProgressReport ), already, total );
				return;
			}

			hslProgress3.Value = (int)(already * 100 / total);
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCompanyID, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox3.Text = element.Attribute( DemoDeviceList.XmlCompanyID ).Value;
			textBox9.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}


	#endregion
}
