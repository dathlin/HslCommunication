using HslCommunication;
using HslCommunication.Secs.Types;
using HslCommunication.Secs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HslCommunicationDemo.FormSecsGem;

namespace HslCommunicationDemo.PLC.Secs
{
	public partial class FormSecsHsmsServer : HslFormContent
	{
		public FormSecsHsmsServer( )
		{
			InitializeComponent( );
		}

		private void FormSecsHsmsServer_Load( object sender, EventArgs e )
		{
			comboBox1.SelectedIndex = 1;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

			StringBuilder stringBuilder = new StringBuilder( "Example：" );
			stringBuilder.Append( new SecsValue( (sbyte)1 ) );
			stringBuilder.Append( new SecsValue( (byte)2 ) );
			stringBuilder.Append( new SecsValue( (short)3 ) );
			stringBuilder.Append( new SecsValue( (ushort)4 ) );
			stringBuilder.Append( new SecsValue( (int)5 ) );
			stringBuilder.Append( new SecsValue( (uint)6 ) );
			stringBuilder.Append( new SecsValue( (long)7 ) );
			stringBuilder.Append( new SecsValue( (ulong)8 ) );
			stringBuilder.Append( new SecsValue( (float)9 ) );
			stringBuilder.Append( new SecsValue( (double)10 ) );
			stringBuilder.Append( new SecsValue( "ABC" ) );
			stringBuilder.Append( new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ) );
			stringBuilder.Append( new SecsValue( true ) );
			//stringBuilder.Append( new SecsValue( new object[] { (short)3, "ABC" } ) );
			textBox_example.Text = stringBuilder.ToString();

			TreeNode s1Node = new TreeNode( "S1" );
			AddTree( s1Node, new SecsTreeItem( 1, 1,  true,  new SecsValue( new object[] { "MDLN", "SOFTRev" } ), "Are You Online" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 3,  true,  new SecsValue( new object[] { (uint)1, (uint)2 } ), "Selected Equipment Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 5,  true,  new SecsValue( new object[] { (uint)1, (uint)2 } ), "Formatted Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 7,  false, new SecsValue( new object[] { new object[] { "AlarmsEnabled", "0" } } ), "Fixed Form Request" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 9,  true,  new SecsValue( new object[] { new byte[] { 0x01 }, new byte[] { 0x01 } } ), "Material Transfer Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 11, true,  new SecsValue( new object[] { new object[] { "SVID", "SVNAME", "UNITS" } } ), "Status Variable Namelist" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 13, true,  
				new SecsValue( new object[] { new byte[] { 0x01 }, new object[0] } ), "Establish Communications",
				SecsValue.EmptyListValue( ) ) );
			AddTree( s1Node, new SecsTreeItem( 1, 15, true,  new SecsValue( new byte[] { 0x01 } ), "Request OFF-LINE" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 17, true,  new SecsValue( new byte[] { 0x01 } ), "Request ON-LINE" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 19, true,  
				new SecsValue( new object[] { new object[] { new object[] { "ATTRDATA1", "ATTRDATA2" } }, new object[] { new object[] { (uint)4, "ERRTEXT" } } } ), "Get Attribute",
				new SecsValue( new object[] { "A Carrier", new object[] { "Job0001" }, new object[] { "SourceURL" } } ) ) );
			AddTree( s1Node, new SecsTreeItem( 1, 21, true,  new SecsValue( new object[] { new object[]{ "VID", "DVVALNAME", "Units" } } ), "Data Variable Namelist" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 23, true,  new SecsValue( new object[] { new object[] { (uint)123, "ProcessStateUpdate", new object[] { "810" } } } ), "Collection Event Namelist Request" ) );
			treeView1.Nodes.Add( s1Node );

			TreeNode s2Node = new TreeNode( "S2" );
			AddTree( s2Node, new SecsTreeItem( 2, 1,  false, 
				new SecsValue( new byte[] { 0x01, 0x02 } ), "Service Program Load Inquire",
				new SecsValue( new object[] { "bin007", (uint)322 } ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 3,  false, 
				new SecsValue( (uint)199 ), "Service Program Send",
				new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 5,  false, 
				new SecsValue( new byte[] { 0x01, 0x02 } ), "Service Program Load Request",
				new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 7,  false, 
				new SecsValue( (uint)0 ), "Service Program Run Send",
				new SecsValue( "bin007" ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 9,  false, 
				new SecsValue( "shutdown -i5 -g0 -y" ), "Service Program Results Request",
				new SecsValue( "bin007" ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 11, false, new SecsValue( "bin007" ), "Service Program Directory Request" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 13, true,  new SecsValue( new object[] { "1", "2" } ), "Equipment Constant Request" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 15, true,  new SecsValue( new byte[] { 0x00 } ), "New Equipment Constant Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 17, true,  new SecsValue( "2022121708371902" ), "Date and Time Request" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 19, true,  new SecsValue( (ushort)0 ), "Reset/Initialize Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 21, true,  new SecsValue( new byte[] { 0x00 } ), "Remote Command Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 23, true,  new SecsValue( new byte[] { 0x00 } ), "Trace Initialize Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 25, true,  
				new SecsValue( new byte[] { 0x00, 0x01, 0x03, 0x03, 0x0a, 0x0d, 0x1b, 0x5d, 0x18, 0x18, 0x18, 0x1a, 0x04, 0x13, 0x7f, 0x80, 0xfe, 0xff } ), "Trace Initialize Send", 
				new SecsValue( new byte[] { 0x00, 0x01, 0x03, 0x03, 0x0a, 0x0d, 0x1b, 0x5d, 0x18, 0x18, 0x18, 0x1a, 0x04, 0x13, 0x7f, 0x80, 0xfe, 0xff } ) ) );
			AddTree( s2Node, new SecsTreeItem( 2, 27, true, new SecsValue( new byte[] { 0x00 } ), "Initiate Processing Request" ) );
			treeView1.Nodes.Add( s2Node );

			TreeNode s3Node = new TreeNode( "S3" );
			AddTree( s3Node, new SecsTreeItem( 3, 1, true, new SecsValue( new object[] { new byte[] { 0x00 }, new object[] { new object[] { new byte[] { 0x00 }, new byte[] { 0x18 }, "ee052793.1" } } } ), "Material Status Request" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 3, true, new SecsValue( new object[] { new byte[] { 0x00 }, new object[] { new object[] { (uint)286, new byte[] { 0x18 }, "ee052793.1" } } } ), "Time to Completion Data" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 5, true, 
				SecsValue.EmptySecsValue( ), "Time to Completion Data",
				new SecsValue( new object[] { new byte[] { 0x01 }, new byte[] { 0x018 } } ) ) );
			AddTree( s3Node, new SecsTreeItem( 3,7, true,
				SecsValue.EmptySecsValue( ), "Material Lost Send",
				new SecsValue( new object[] { new byte[] { 0x01 }, new byte[] { 0x018 }, "ee052793.1" } ) ) );
			AddTree( s3Node, new SecsTreeItem( 3, 9, true,
				SecsValue.EmptySecsValue( ), "Matl ID Equate Send",
				new SecsValue( new object[] { "ee052793.1", "1" } ) ) );
			AddTree( s3Node, new SecsTreeItem( 3, 11, true,
				SecsValue.EmptySecsValue( ), "Matl ID Request",
				new SecsValue( (byte)1 ) ) );
			AddTree( s3Node, new SecsTreeItem( 3, 13, true, new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Matl ID Send" ) );
			treeView1.Nodes.Add( s3Node );


			TreeNode s4Node = new TreeNode( "S4" );
			AddTree( s4Node, new SecsTreeItem( 4, 1, true, 
				new SecsValue( new byte[] { 0x00 } ), "Ready to Send Materials",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 3, false,
				SecsValue.EmptySecsValue( ), "Send Material",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 5, false,
				SecsValue.EmptySecsValue( ), "Handshake Complete",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 7, false,
				SecsValue.EmptySecsValue( ), "Not Ready to Send",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 9, false,
				SecsValue.EmptySecsValue( ), "Stuck in Sender",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 11, false,
				SecsValue.EmptySecsValue( ), "Stuck in Receiver",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 13, false,
				SecsValue.EmptySecsValue( ), "Send Incomplete Timeout",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 15, false,
				SecsValue.EmptySecsValue( ), "Material Received",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			AddTree( s4Node, new SecsTreeItem( 4, 17, true,
				new SecsValue( new byte[] { 0x00 } ), "Ready to Send Materials",
				new SecsValue( new object[] { (byte)1, "ee052793.1" } ) ) );
			treeView1.Nodes.Add( s4Node );

			TreeNode s5Node = new TreeNode( "S5" );
			AddTree( s5Node, new SecsTreeItem( 5, 1, true,
				SecsValue.EmptySecsValue( ), "Alarm Report Send",
				new SecsValue( new object[] { new byte[] { 0x00 }, (uint)1000, "sensor timeout at load elevator" } ) ) );
			AddTree( s5Node, new SecsTreeItem( 5, 3, true, new SecsValue( new object[] { (byte)0 } ), "Enable/Disable Alarm Send" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 5, true, new SecsValue( new object[] { new object[] { (byte)0, (uint)1000, "sensor timeout at load elevator" } } ), "List Alarms Request" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 7, true, new SecsValue( new object[] { new object[] { (byte)0, (uint)1000, "sensor timeout at load elevator" } } ), "List Enabled Alarm Request" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 9, true,
				SecsValue.EmptySecsValue( ), "Exception Post Notify", 
				new SecsValue( new object[] { DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").Replace("-",""), "out of ink", "ALARM", "ink not sensed at nozzle inlet", new object[] { "manually insert new ink cartridge" } } )
				) ); 
			AddTree( s5Node, new SecsTreeItem( 5, 11, true,
				SecsValue.EmptySecsValue( ), "Exception Clear Notify",
				new SecsValue( new object[] { DateTime.Now.ToString( "yyyy-MM-dd-HH-mm-ss" ).Replace( "-", "" ), "out of ink", "ALARM", "ink not sensed at nozzle inlet" } )
				) );
			treeView1.Nodes.Add( s5Node );

			TreeNode s6Node = new TreeNode( "S6" );
			AddTree( s6Node, new SecsTreeItem( 6, 1, true,
				SecsValue.EmptySecsValue( ), "Trace Data Send",
				new SecsValue( new object[] { "1", (uint)10, DateTime.Now.ToString( "yyyy-MM-dd-HH-mm-ss" ).Replace( "-", "" ), new object[] { (byte)65 } } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 3, true,
				SecsValue.EmptySecsValue( ), "Discrete Variable Data Send",
				new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { new object[] { "12", new object[] { new object[] { (uint)10, "54" } } } } } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 5, true,
				SecsValue.EmptySecsValue( ), "Multi-block Data Send Inquire",
				new SecsValue( new object[] { (uint)1, (uint)649 } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 7, true, new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { "12", new object[] { new object[] { (uint)10, "54" } } } } ), "Data Transfer Request" ) );
			AddTree( s6Node, new SecsTreeItem( 6, 9, true,
				SecsValue.EmptySecsValue( ), "Formatted Variable Send",
				new SecsValue( new object[] { new byte[] { 0x02 }, (uint)1, (uint)4050, new object[] { new object[] { "12", new object[] { "54" } } } } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 11, true,
				SecsValue.EmptySecsValue( ), "Event Report Send",
				new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { new object[] { (uint)1, new object[] { "0" } } } } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 13, true,
				SecsValue.EmptySecsValue( ), "Annotated Event Report Send",
				new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { new object[] { (uint)1, new object[] { new object[] { "810", "0" } } } } } ) ) );
			AddTree( s6Node, new SecsTreeItem( 6, 15, true, new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { new object[] { (uint)1, new object[] { "0" } } } } ), "Event Report Request" ) );

			treeView1.Nodes.Add( s6Node );


			treeView1.AfterSelect += TreeView1_AfterSelect;
			timer = new Timer( );
			timer.Tick += Timer_Tick;
			timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (this.server != null)
				listBox1.DataSource = this.server.GetOnlineSessions;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if(server != null)
			{
				switch (comboBox1.SelectedIndex)
				{
					case 0: server.StringEncoding = Encoding.ASCII; break;
					case 1: server.StringEncoding = Encoding.Default; break;
					case 2: server.StringEncoding = Encoding.UTF8; break;
					case 3: server.StringEncoding = Encoding.Unicode; break;
					case 4: server.StringEncoding = Encoding.GetEncoding( "gb2312" ); break;
				}
			}
		}

		private void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if (e.Node.Tag is SecsTreeItem treeItem)
			{
				textBox_stream.Text   = treeItem.S.ToString( );
				textBox_function.Text = (treeItem.F + 1).ToString( );

				textBox_device_s.Text = treeItem.S.ToString( );
				textBox_device_f.Text = treeItem.F.ToString( );

				if (treeItem.Value != null)
					textBox_data_back.Text = treeItem.Value.ToXElement( ).ToString( );
				else
					textBox_data_back.Text = string.Empty;


				if (treeItem.ValueSingular != null)
				{
					textBox_device_send.Text = treeItem.ValueSingular.ToXElement( ).ToString( );
				}
				else
				{
					textBox_device_send.Text = string.Empty;
				}
			}
		}

		public void AddTree( TreeNode treeNode, SecsTreeItem treeItem )
		{
			TreeNode child = new TreeNode( $"S{treeItem.S}F{treeItem.F}{(treeItem.W ? "W" : "")} {treeItem.Description}" );
			child.Tag = treeItem;
			treeNode.Nodes.Add( child );
		}


		private SecsHsmsServer server;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				server = new SecsHsmsServer( );
				server.OnSecsMessageReceived += Server_OnSecsMessageReceived;
				server.ServerStart( int.Parse( textBox_port.Text ) );
				ComboBox1_SelectedIndexChanged( comboBox1, e );

				button1.Enabled = false;
				button11.Enabled = true;
			}
			catch ( Exception ex)
			{
				MessageBox.Show( "Start failed: " + ex.Message );
			}
		}

		private void Server_OnSecsMessageReceived( object sender, HslCommunication.Core.Net.AppSession session, SecsMessage message )
		{
			SecsMessage secsMessage = null;
			foreach (TreeNode treeNode in treeView1.Nodes)
			{
				foreach(TreeNode childNode in treeNode.Nodes)
				{
					if (childNode.Tag is SecsTreeItem treeItem)
					{
						if (treeItem.S == message.StreamNo &&
							treeItem.F == message.FunctionNo)
						{

							server.SendByCommand( session, message, message.StreamNo, (byte)(message.FunctionNo + 1), treeItem.Value );
							secsMessage = new SecsMessage( );
							secsMessage.StringEncoding = server.StringEncoding;
							secsMessage.StreamNo = message.StreamNo;
							secsMessage.FunctionNo = (byte)(message.FunctionNo + 1);
							secsMessage.Data = treeItem.Value == null ? new byte[0] : treeItem.Value.ToSourceBytes( server.StringEncoding );
							break;
						}
					}
				}
			}

			// 收到客户端发来的数据的时候触发的事件
			if (!checkBox1.Checked)
			{
				Invoke( new Action( ( ) =>
				{
					textBox_log.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " Receive Data：" + message.ToString( ) + Environment.NewLine );
					if (secsMessage != null)
					{
						textBox_log.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " Send Back Data：" + secsMessage.ToString( ) + Environment.NewLine );
					}
				} ) );
			}

		}

		private void button_save_tree_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is SecsTreeItem treeItem)
			{
				treeItem.Value = new SecsValue( System.Xml.Linq.XElement.Parse( textBox_data_back.Text ) );
				MessageBox.Show( "保存成功！" );
			}
		}

		private void button25_Click( object sender, EventArgs e )
		{
			// 发布数据出去
			OperateResult publish = server.PublishSecsMessage( byte.Parse( textBox_stream.Text ), byte.Parse( textBox_function.Text ),
				string.IsNullOrEmpty( textBox_data_back.Text ) ? null : new SecsValue( System.Xml.Linq.XElement.Parse( textBox_data_back.Text ) ) );

			if (publish.IsSuccess)
			{
				textBox_log.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " Send Data：" +
					$"S{textBox_stream.Text}F{textBox_function.Text}" + Environment.NewLine + textBox_data_back.Text + Environment.NewLine );
			}
			else
			{
				MessageBox.Show( "Failed: " + publish.Message );
			}
		}

		private void button_device_send_Click( object sender, EventArgs e )
		{
			OperateResult publish = server.PublishSecsMessage( byte.Parse( textBox_device_s.Text ), byte.Parse( textBox_device_f.Text ),
				string.IsNullOrEmpty( textBox_device_send.Text ) ? null : new SecsValue( System.Xml.Linq.XElement.Parse( textBox_device_send.Text ) ) );

			if (publish.IsSuccess)
			{
				textBox_log.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " Send Data：" +
					$"S{textBox_device_s.Text}F{textBox_device_f.Text}" + Environment.NewLine + textBox_device_send.Text + Environment.NewLine );
			}
			else
			{
				MessageBox.Show( "Failed: " + publish.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 关闭服务
			server.ServerClose( );
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void button4_Click( object sender, EventArgs e )
		{
			textBox_log.Clear();
		}

		private Timer timer;

	}
}
