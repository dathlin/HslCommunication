using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using System.Threading.Tasks;

namespace HslCommunicationDemo.Robot
{
	public partial class FormABBWebApi : HslFormContent
	{
		public FormABBWebApi( )
		{
			InitializeComponent( );

			imageList = new ImageList( );
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageSize = new Size( 16, 16 );
			imageList.Images.Add( "folder_Closed_16xLG", Properties.Resources.folder_Closed_16xLG );
			imageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );
		}

		private ABBWebApiClient webApiClient;
		private CodeExampleControl codeExampleControl;
		private ImageList imageList;


		private void FormABBWebApi_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		private void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				webApiClient = new ABBWebApiClient( textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text );
				panel2.Enabled = true;
				button_close.Enabled = true;
				button_open.Enabled = false;


				// 设置示例代码
				codeExampleControl.SetCodeText( webApiClient );
			}
			catch(Exception ex)
			{
				DemoUtils.ShowMessage( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
			}
		}

		private void button_close_Click( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button_close.Enabled = false;
			button_open.Enabled = true;
		}

		private async void Button2_Click( object sender, EventArgs e )
		{
			if(comboBox1.SelectedIndex == 0)
			{
				OperateResult<string> read = await webApiClient.ReadStringAsync( textBox5.Text );
				if (read.IsSuccess)
				{
					textBox6.Text = read.Content;
					webBrowser1.DocumentText = read.Content;
				}
				else
				{
					DemoUtils.ShowMessage( "Read Failed:" + read.Message );
				}
			}
			else
			{
				OperateResult write = await webApiClient.WriteAsync( textBox5.Text, textBox7.Text );
				if (write.IsSuccess)
				{
					DemoUtils.ShowMessage( "Write Success" );
				}
				else
				{
					DemoUtils.ShowMessage( "Read Failed:" + write.Message );
				}
			}
		}

		private void FormABBWebApi_Load( object sender, EventArgs e )
		{
			button_close.Enabled = false;
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton2_CheckedChanged;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl2, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			treeView1.ImageList = imageList;
		}

		private void RadioButton2_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton2.Checked)
			{
				textBox_web_text.Visible = false;
				webBrowser1.Visible = true;
			}
		}

		private void RadioButton1_CheckedChanged( object sender, EventArgs e )
		{
			if (radioButton1.Checked)
			{
				textBox_web_text.Visible = true;
				webBrowser1.Visible = false;
			}
		}

		private async Task RenderWebUrl( string url, bool get = true )
		{
			textBox_url_read.Text = url;
			DateTime start = DateTime.Now;
			OperateResult<string> read_web = await webApiClient.ReadStringAsync( textBox_url_read.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (read_web.IsSuccess)
			{
				textBox_web_text.Text = read_web.Content;
				webBrowser1.DocumentText = read_web.Content;
			}
			else
			{
				DemoUtils.ShowMessage( "Read Failed:" + read_web.Message );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.ReadStringAsync( \"{textBox_url_read.Text}\" );" );
		}

		private async void Button3_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetErrorStateAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/motionsystem/errorstate" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetErrorStateAsync( );" );
		}

		private async void Button4_Click( object sender, EventArgs e )
		{
			string unit = string.IsNullOrEmpty( comboBox2.Text ) ? "ROB_1" : comboBox2.Text;
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetJointTargetAsync( unit );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( $"url=/rw/motionsystem/mechunits/{unit}/jointtarget" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetJointTargetAsync( \"{unit}\" );" );
		}

		private async void Button5_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetSpeedRatioAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/speedratio" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetSpeedRatioAsync( );" );
		}

		private async void Button6_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetOperationModeAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/opmode" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetOperationModeAsync( );" );
		}

		private async void Button7_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetCtrlStateAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/panel/ctrlstate" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetCtrlStateAsync( );" );
		}

		private async void Button8_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIOInAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/D652_10" );
			}
			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetIOInAsync( );" );
		}

		private async void Button9_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIOOutAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/D652_10" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetIOOutAsync( );" );
		}

		private async void Button11_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIO2InAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/BK5250" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetIO2InAsync( );" );
		}

		private async void Button10_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetIO2OutAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/devices/BK5250" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetIO2OutAsync( );" );
		}

		private async void button_io_signal_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetAnIOSignalAsync( textBox_io_network.Text, textBox_io_unit.Text, textBox_io_signal.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( $"url=/rw/iosystem/signals/{textBox_io_network.Text}/{textBox_io_unit.Text}/{textBox_io_signal.Text}" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetAnIOSignalAsync( \"{textBox_io_network.Text}\", \"{textBox_io_unit.Text}\", \"{textBox_io_signal.Text}\" );" );
		}

		private async void Button12_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetLogAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/elog/0?lang=zh&amp;resource=title" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetLogAsync( );" );
		}

		private async void button1_Click_1( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string[]> read = await webApiClient.GetMechunitsAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content.ToArrayString( );
				comboBox2.DataSource = read.Content;
				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/motionsystem/mechunits" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string[]> read = await webApiClient.GetMechunitsAsync( );" );
		}

		private async void button13_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetSystemAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/system" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetSystemAsync( );" );
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			string unit = string.IsNullOrEmpty( comboBox2.Text ) ? "ROB_1" : comboBox2.Text;

			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRobotTargetAsync( unit );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/motionsystem/mechunits/ROB_1/robtarget" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetRobotTargetAsync( \"{unit}\" );" );
		}

		private async void button15_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetServoEnableAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/iosystem/signals/Local/DRV_1/DRV1K1" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetServoEnableAsync( );" );
		}

		private async void button16_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRapidExecutionAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/rapid/execution" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetRapidExecutionAsync( );" );
		}

		private async void button17_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<string> read = await webApiClient.GetRapidTasksAsync( );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content;

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( "url=/rw/rapid/tasks" );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<string> read = await webApiClient.GetRapidTasksAsync( );" );
		}

		private async void button18_Click( object sender, EventArgs e )
		{
			DateTime start = DateTime.Now;
			OperateResult<double[]> read = webApiClient.GetUserValue( textBox_user_value_name.Text );
			label_time_cost.Text = DemoUtils.GetTimeCost( start );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
			else
			{
				textBox6.Text = read.Content.ToJsonString( );

				// 为了方便调试，显示URL，并显示web文本的请求结果
				await RenderWebUrl( textBox_user_value_name.Text.StartsWith( "url=", StringComparison.OrdinalIgnoreCase ) ? 
					textBox_user_value_name.Text : "url=/rw/rapid/symbol/data/RAPID/T_ROB1/user/" + textBox_user_value_name.Text );
			}

			codeExampleControl.RenderReadResultCode( $"OperateResult<double[]> read = webApiClient.GetUserValue( \"{textBox_user_value_name.Text}\" );" );
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

		#region 浏览API接口相关的

		private async void button19_Click( object sender, EventArgs e )
		{
			treeView1.Nodes.Clear( );
			await BroeseNode( treeView1.Nodes, "/", null );
		}

		private async Task BroeseNode( TreeNode treeNode )
		{
			string href = "/";
			if (treeNode.Tag is AbbNodeInfo nodeInfo)
			{
				href = nodeInfo.Href;
			}

			TreeNodeCollection treeNodeCollection = treeNode.Nodes;
			await BroeseNode( treeNodeCollection, href, treeNode );
		}

		private async void treeView1_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			// 节点展开之前
			TreeNode treeNode = e.Node;
			if (treeNode.Nodes.Count == 1 && treeNode.Nodes[0].Tag == null)
			{
				treeNode.Nodes.Clear( );
				// 浏览
				await BroeseNode( treeNode );
			}
		}

		private XElement GetChildXml( XElement parent, string name )
		{
			XElement child = parent.Element( name );
			if (child == null)
			{
				foreach (var item in parent.Elements( ))
				{
					if (item.Name.LocalName == name)
					{
						child = item;
						break;
					}
				}
			}
			return child;
		}

		private async Task BroeseNode( TreeNodeCollection treeNodeCollection, string href, TreeNode parentNode )
		{
			OperateResult<string> read = await webApiClient.ReadStringAsync( "url=" + href );
			if (read.IsSuccess)
			{
				XElement xml = XElement.Parse( read.Content );

				// 先找到设备数据对象
				XElement bodyXml = GetChildXml( xml, "body" );
				if (bodyXml == null)
				{
					// 还是为空，直接找第二个
					int i = 0;
					foreach( XElement element in xml.Elements( ))
					{
						i++;
						if (i == 2)
						{
							bodyXml = element;
							break;
						}
					}
				}
				XElement dataXml = GetChildXml( bodyXml, "div" );
				if ( dataXml == null )
				{
					dataXml = bodyXml.Elements( ).FirstOrDefault( );
				}
				if (dataXml.Name.LocalName == "body")
				{
					dataXml = GetChildXml(dataXml, "div" );
				}

				// 判断是否是链接对象
				if (dataXml.Elements( ).First( ).Name.LocalName == "a")
				{
					XElement list = GetChildXml( dataXml, "ul" );
					int listCount = 0;
					foreach( var itemXml in list.Elements( ) )
					{
						if (itemXml.Name.LocalName == "li")
						{
							listCount++;
							XAttribute classAttr = itemXml.Attribute( "class" );
							XAttribute titleAttr = itemXml.Attribute( "title" );
							if (classAttr != null && classAttr.Value.EndsWith( "-li" ))
							{
								// 这是一个目录，找到实际的href
								string hrefItem = titleAttr.Value;
								XElement linkXml = GetChildXml( itemXml, "a" );
								if (linkXml != null) hrefItem = linkXml.Attribute( "href" ).Value;

								if (hrefItem.LastIndexOf( "/" ) >= 0)
								{
									hrefItem = hrefItem.Substring( hrefItem.LastIndexOf( "/" ) + 1 );
								}

								AbbNodeInfo abbNodeInfo = new AbbNodeInfo( );
								abbNodeInfo.Title = titleAttr.Value;
								if (href.EndsWith( "/" )) abbNodeInfo.Href = href + hrefItem;
								else abbNodeInfo.Href = href + "/" + hrefItem;

								TreeNode node = new TreeNode( abbNodeInfo.Title );
								node.Tag = abbNodeInfo;
								node.ImageKey = "folder_Closed_16xLG";
								node.SelectedImageKey = "folder_Closed_16xLG";
								treeNodeCollection.Add( node );

								node.Nodes.Add( "" );
							}
							else
							{
								textBox9.Text = itemXml.ToString( );
								if (parentNode != null)
								{
									if (parentNode.Tag is AbbNodeInfo info)
									{
										if (string.IsNullOrEmpty( info.Content ))
											info.Content = dataXml.ToString( );
									}
								}
							}
						}
					}

					if (listCount == 0)
					{
						// 没有找到li对象，直接显示出结果
						textBox8.Text = "url=" + href;
						textBox9.Text = dataXml.ToString( );
						if (parentNode != null)
						{
							parentNode.ImageKey = "Enum_582";
							parentNode.SelectedImageKey = "Enum_582";

							if (parentNode.Tag is AbbNodeInfo info)
							{
								if (string.IsNullOrEmpty( info.Content ))
									info.Content = dataXml.ToString( );
							}
						}
					}
				}
				else
				{
					// 不是链接，显示出结果
					textBox8.Text = "url=" + href;
					textBox9.Text = dataXml.ToString( );

					if (parentNode != null)
					{
						parentNode.ImageKey = "Enum_582";
						parentNode.SelectedImageKey = "Enum_582";

						if (parentNode.Tag is AbbNodeInfo info)
						{
							if (string.IsNullOrEmpty( info.Content ))
								info.Content = dataXml.ToString( );
						}
					}
				}
			}
			else
			{
				DemoUtils.ShowMessage( "Read Failed:" + read.Message );
			}
		}



		#endregion

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if (e.Node == null) return;
			if (e.Node.Tag is AbbNodeInfo info)
			{
				textBox8.Text = info.Href;
				textBox9.Text = info.Content;
			}
		}
	}

	public class AbbNodeInfo
	{
		public string Title { get; set; }

		public string Href { get; set; }

		public string Content { get; set; }
	}
}
