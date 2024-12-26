using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.Secs;
using HslCommunication.Secs.Types;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using HslCommunication.Secs.Helper;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.PLC.Secs;
using System.IO;

namespace HslCommunicationDemo
{
	public partial class FormSecsGem : HslFormContent
	{
		public FormSecsGem( )
		{
			InitializeComponent( );
		}

		private SecsHsms secs = null;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		/// <summary>
		/// 获取MC协议的地址示例
		/// </summary>
		/// <returns>地址示例信息</returns>
		public static DeviceAddressExample[] GetSecsAddress( )
		{
			return new DeviceAddressExample[]
			{
				new DeviceAddressExample( "sbyte",   "", true, true, new SecsValue( (sbyte)1 ).ToString( )       ),
				new DeviceAddressExample( "byte",    "", true, true, new SecsValue( (byte)2 ).ToString( )        ),
				new DeviceAddressExample( "short",   "", true, true, new SecsValue( (short)3 ).ToString( )       ),
				new DeviceAddressExample( "ushort",  "", true, true, new SecsValue( (ushort)4 ).ToString( )      ),
				new DeviceAddressExample( "int",     "", true, true, new SecsValue( (int)5 ).ToString( )         ),
				new DeviceAddressExample( "uint",    "", true, true, new SecsValue( (uint)6 ).ToString( )        ),
				new DeviceAddressExample( "long",    "", true, true, new SecsValue( (long)7 ).ToString( )        ),
				new DeviceAddressExample( "ulong",   "", true, true, new SecsValue( (ulong)8 ).ToString( )       ),
				new DeviceAddressExample( "float",   "", true, true, new SecsValue( (float)9 ).ToString( )       ),
				new DeviceAddressExample( "double",  "", true, true, new SecsValue( (double)10 ).ToString( )     ),
				new DeviceAddressExample( "string",  "", true, true, new SecsValue( "ABC" ).ToString( )          ),
				new DeviceAddressExample( "bool",    "", true, true, new SecsValue( true ).ToString( )           ),
				new DeviceAddressExample( "byte[]",  "", true, true, new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ).ToString( ) ),
				new DeviceAddressExample( "list",    "", true, true, new SecsValue( new object[] { (short)3 } ).ToString( )           ),
			};
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			comboBox_log_style.SelectedIndex = 0;
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 1;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			Language( Program.Language );

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( GetSecsAddress( ) );
			DemoUtils.AddSpecialFunctionTab( tabControl_buttom, addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( tabControl_buttom, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			//StringBuilder stringBuilder = new StringBuilder( "Example：" );
			//stringBuilder.Append( new SecsValue( (sbyte)1 ) );
			//stringBuilder.Append( new SecsValue( (byte)2 ) );
			//stringBuilder.Append( new SecsValue( (short)3 ) );
			//stringBuilder.Append( new SecsValue( (ushort)4 ) );
			//stringBuilder.Append( new SecsValue( (int)5 ) );
			//stringBuilder.Append( new SecsValue( (uint)6 ) );
			//stringBuilder.Append( new SecsValue( (long)7 ) );
			//stringBuilder.Append( new SecsValue( (ulong)8 ) );
			//stringBuilder.Append( new SecsValue( (float)9 ) );
			//stringBuilder.Append( new SecsValue( (double)10 ) );
			//stringBuilder.Append( new SecsValue( "ABC" ) );
			//stringBuilder.Append( new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ) );
			//stringBuilder.Append( new SecsValue( true ) );
			////stringBuilder.Append( new SecsValue( new object[] { (short)3, "ABC" } ) );
			//textBox_example.Text = stringBuilder.ToString();

			TreeNode s1Node = new TreeNode( "S1" );
			AddTree( s1Node, new SecsTreeItem( 1, 1,  true,  null, "Are You Online" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 3,  true,  new SecsValue( new object[] { (uint)1, (uint)2 } ), "Selected Equipment Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 5,  true,  new SecsValue( new byte[] { 0x01 } ), "Formatted Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 7,  false, new SecsValue( new byte[] { 0x01 } ), "Fixed Form Request" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 9,  true,  null, "Material Transfer Status" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 11, true,  new SecsValue( new object[] { (uint)1, (uint)2 } ), "Status Variable Namelist" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 13, true,  new SecsValue( new object[] { new byte[] { 0x01 }, new object[0]  } ), "Establish Communications" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 15, true,  null, "Request OFF-LINE" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 17, true,  null, "Request ON-LINE" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 19, true,  new SecsValue( new object[] { "object class name", new object[] { "Job0001", "Job0002" }, new object[] { "attribute1", "attribute2" } } ), "Get Attribute" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 21, true,  new SecsValue( new object[] { "Variable ID1", "Variable ID2" } ), "Data Variable Namelist" ) );
			AddTree( s1Node, new SecsTreeItem( 1, 23, true,  new SecsValue( new object[] { (uint)1, (uint)2 } ), "Collection Event Namelist" ) );
			treeView1.Nodes.Add( s1Node );

			TreeNode s2Node = new TreeNode( "S2" );
			AddTree( s2Node, new SecsTreeItem( 2, 1, false, new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ), "Service Program Load Grant" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 3, false, new SecsValue( new byte[] { 0x01, 0x02, 0x03 } ), "Service Program Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 5, false, new SecsValue( "bin00" ), "Service Program Load" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 7, false, new SecsValue( "bin00" ), "Service Program Run Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 9, false, new SecsValue( "bin00" ), "Service Program Results" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 11, false, null, "Service Program Directory" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 13, true, new SecsValue( new object[] { (uint)1, (uint)2 } ), "Equipment Constant" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 15, true, new SecsValue( new object[] { new object[] { (uint)1, "1" }, new object[] { (uint)2, "2" } } ), "New Equipment Constant Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 17, true, null, "Date and Time" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 19, true, new SecsValue((byte)1), "Reset/Initialize Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 21, true, new SecsValue( "pause" ), "Remote Command Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 23, true, new SecsValue( new object[] { "TRID", "000500", (uint)4, (uint)5, new object[] { (uint)1, (uint)2 } } ), "Trace Initialize Send" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 25, true, new SecsValue( "00 01 03 03 0a 0d 1b 5d 18 18 1a 04 13 7f 80 fe ff".ToHexBytes( ) ), "Loopback Diagnostic" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 27, true, new SecsValue( new object[] { new byte[] { 0x01 }, "banana", new object[] { "ee052793.1" } } ), "Initiate Processing Request" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 29, true, new SecsValue( new object[] { (uint)220 } ), "Equipment Constant Namelist" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 31, true, new SecsValue( DateTime.Now.ToString("yyyyMMddHHmmss") ), "Date and Time Set" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 33, true, new SecsValue( new object[] { (uint)1, new object[] { new object[] { (uint)4, new object[] { "810" } } } } ), "Define Report" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 35, true, new SecsValue( new object[] { (uint)1, new object[] { new object[] { (uint)4050, new object[] { (uint)1 } } } } ), "Link Event Report" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 37, true, new SecsValue( new object[] { (uint)1, new object[] { new object[] { (uint)4050, new object[] { (uint)1 } } } } ), "Enable/Disable Event Report" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 39, true, new SecsValue( new object[] { (uint)1, (uint)649 } ), "Multi-block Inquire" ) );
			AddTree( s2Node, new SecsTreeItem( 2, 41, true, new SecsValue( new object[] { "pause", new object[] { new object[] { "ppexecname", "cmos168-zl0EC" } } } ), "Host Command Send" ) );
			treeView1.Nodes.Add( s2Node );


			TreeNode s3Node = new TreeNode( "S3" );
			AddTree( s3Node, new SecsTreeItem( 3, 1, true,  null, "Material Status" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 3, true,  null, "Time to Completion Data" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 5, true,  new SecsValue( new object[] { new byte[] { 0x01 }, new byte[] { 0x18 } } ), "Material Found Send" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 7, true,  new SecsValue( new object[] { new byte[] { 0x01 }, new byte[] { 0x18 }, "ee052793.1" } ), "Material Lost Send" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 9, true,  new SecsValue( new object[] { "ee052793.1", "1" } ), "Matl ID Equate Send" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 11, true, new SecsValue( (byte)1 ), "Matl ID Request" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 13, true, new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Matl ID Send" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 17, true, new SecsValue( new object[] { (uint)1, "ProceedWithCarrier", "CSX 52078", (byte)1, new object[] { new object[] { "Usage", "product" } } } ), "Carrier Action Request" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 19, true, null, "Cancel All Carrier Out Req" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 21, true, new SecsValue( new object[] { "buffer1", (byte)1, new object[] { (byte)1 } } ), "Port Group Defn" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 23, true, new SecsValue( new object[] { "CancelReservationAtPort", "buffer1", new object[] { "ServiceStatus", (byte)1 } } ), "Port Group Action Req" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 25, true, new SecsValue( new object[] { " ChangeServiceStatus", (byte)1, new object[] { new object[] { "ServiceStatus",( byte)1 } } } ), "Port Action Req" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 27, true, new SecsValue( new object[] { (byte)0, new object[] { (byte)1 } } ), "Change Access" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 29, true, new SecsValue( new object[] { "logical ID", "Carrier:CSX 52078", "S01", (uint)649 } ), "Carrier Tag Read Req" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 31, true, new SecsValue( new object[] { "logical ID", "Carrier:CSX 52078", "S01", (uint)649, "unformatted data" } ), "Carrier Tag Write Data" ) );
			AddTree( s3Node, new SecsTreeItem( 3, 33, true, null, "Cancel All Pod Out Req" ) );
			treeView1.Nodes.Add( s3Node );


			TreeNode s4Node = new TreeNode( "S4" );
			AddTree( s4Node, new SecsTreeItem( 4, 1, true,   new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Ready to Send Materials" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 3, false,  new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Send Material" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 5, false,  new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Handshake Complete" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 9, false,  new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Stuck in Sender" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 11, false, new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Stuck in Receiver" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 13, false, new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Send Incomplete Timeout" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 15, false, new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Material Received" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 17, true,  new SecsValue( new object[] { (byte)1, "ee052793.1" } ), "Request to Receive" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 19, true,  new SecsValue( new object[] { (uint)1, new object[] { "TJH_U_M_E1086", new object[] { (uint)3, (uint)1, "c000678", (uint)7, (byte)1, 
				"standard exchange", "AGV0001", (uint)1, (byte)1,(byte)1, (uint)1, "TF:1 0" } } } ), "Transfer Job Create" ) );
			AddTree( s4Node, new SecsTreeItem( 4, 21, true,  new SecsValue( new object[]{ new byte[] { 0x60 }, "PAUSE", new object[] { new object[] { "ppexecname", "cmos168-zl0EC3" } } } ), "Transfer Job Command" ) );
			treeView1.Nodes.Add( s4Node );

			TreeNode s5Node = new TreeNode( "S5" );;
			AddTree( s5Node, new SecsTreeItem( 5, 3, true,  new SecsValue( new object[] { new byte[] { 0x00 }, (uint)1000 } ), "Enable/Disable Alarm Send" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 5, true,  new SecsValue( (uint)0 ), "List Alarms Request" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 7, true,  null, "List Enabled Alarm Request" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 9, true,  new SecsValue( new object[] { "YYMMDDHHMMSS", "out of ink", "ALARM", "ink not sensed at nozzle inlet", new object[] { "manually insert new ink cartridge" } } ), "Exception Post Notify" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 11, true, new SecsValue( new object[] { "YYMMDDHHMMSS", "out of ink", "ALARM", "ink not sensed at nozzle inlet" } ), "Exception Clear Notify" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 13, true, new SecsValue( new object[] { "out of ink", "manually insert new ink cartridge" } ), "Exception Recover Request" ) );
			AddTree( s5Node, new SecsTreeItem( 5, 17, true, new SecsValue( "out of ink" ), "Exception Recovery Abort Request" ) );
			treeView1.Nodes.Add( s5Node );

			TreeNode s6Node = new TreeNode( "S6" );
			AddTree( s6Node, new SecsTreeItem( 6, 1, true, new SecsValue( new object[] { "1", (uint)10, "YYMMDDHHMMSS", new object[] { (byte)65 } } ), "Trace Data Send" ) );
			AddTree( s6Node, new SecsTreeItem( 6, 3, true, new SecsValue( new object[] { (uint)1, (uint)4050, new object[] { new object[] { "12", new object[] { new object[] { (uint)10, "54" } } } } } ), "Discrete Variable Data Send" ) );
			AddTree( s6Node, new SecsTreeItem( 6, 5, true, new SecsValue( new object[] { (uint)1, (uint)649 } ), "Multi-block Data Send Inquire" ) );
			AddTree( s6Node, new SecsTreeItem( 6, 7, true, new SecsValue( (uint)1 ), "Data Transfer Request" ) );
			AddTree( s6Node, new SecsTreeItem( 6, 9, true, new SecsValue( new object[] { new byte[] { 0x02 }, (uint)1, (uint)4050, new object[] { new object[] { "12", new object[] { "54" } } } } ), "Formatted Variable Send" ) );
			treeView1.Nodes.Add( s6Node );

			TreeNode s7Node = new TreeNode( "S7" );
			AddTree( s7Node, new SecsTreeItem( 7, 1, true, new SecsValue( new object[] { "banana", (uint)322 } ), "Process Program Load Inquire" ) );
			AddTree( s7Node, new SecsTreeItem( 7, 3, true, new SecsValue( new object[] { "banana", new byte[] { 0x00 } } ), "Process Program Send\t" ) );

			treeView1.AfterSelect += TreeView1_AfterSelect;
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (secs != null)
			{
				switch (comboBox1.SelectedIndex)
				{
					case 0: secs.StringEncoding = Encoding.ASCII; break;
					case 1: secs.StringEncoding = Encoding.Default; break;
					case 2: secs.StringEncoding = Encoding.UTF8; break;
					case 3: secs.StringEncoding = Encoding.Unicode; break;
					case 4: secs.StringEncoding = Encoding.GetEncoding( "gb2312" ); break;
				}
			}
		}

		private void RenderSelectedSecs( SecsTreeItem treeItem )
		{
			textBox_stream.Text   = treeItem.S.ToString( );
			textBox_function.Text = treeItem.F.ToString( );
			checkBox_back.Checked = treeItem.W;

			if (treeItem.Value != null)
				textBox_data.Text = checkBox_code_style.Checked ? treeItem.Value.ToSourceCode( true ) : treeItem.Value.ToXElement( ).ToString( );
			else
				textBox_data.Text = string.Empty;

			
			if (treeItem.ValueSingular != null)
			{
				textBox_receive.Text = checkBox_code_style.Checked ? treeItem.ValueSingular.ToSourceCode( true ) : treeItem.ValueSingular.ToString( );
			}
			else
			{
				textBox_receive.Text = string.Empty;
			}

			renderSecsValueLeft = treeItem.Value;
			renderSecsValueRight = treeItem.ValueSingular;
		}

		private void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if (e.Node.Tag is SecsTreeItem treeItem)
			{
				RenderSelectedSecs( treeItem );
			}
		}

		public void AddTree( TreeNode treeNode, SecsTreeItem treeItem )
		{
			TreeNode child = new TreeNode( $"S{treeItem.S}F{treeItem.F}{(treeItem.W ? "W" : "")} {treeItem.Description}" );
			child.Tag = treeItem;
			treeNode.Nodes.Add( child );
		}

		public class SecsTreeItem
		{
			public SecsTreeItem( byte s, byte f, bool w, SecsValue value, string decs, SecsValue singular = null )
			{
				this.S = s;
				this.F = f;
				this.W = w;
				this.Value = value;
				this.Description = decs;
				this.ValueSingular = singular;
			}

			public SecsTreeItem( XElement element )
			{
				LoadByXElement( element );
			}

			public byte S { get; set; }
			public byte F { get; set; }
			public bool W { get; set; }
			public SecsValue Value { get; set; }
			public string Description { get; set; }
			public SecsValue ValueSingular { get; set; }

			public string GetTreeNodeText( )
			{
				return $"S{S}F{F}{(W ? "W" : "")} {Description}";
			}

			public XElement ToXElement( )
			{
				XElement element = new XElement( nameof( SecsTreeItem ) );
				element.SetAttributeValue( nameof( S ), S );
				element.SetAttributeValue( nameof( F ), F );
				element.SetAttributeValue( nameof( W ), W );
				element.SetAttributeValue( nameof( Description ), Description );
				if (Value != null)
				{
					XElement ele = new XElement( "Value" );
					ele.Add( Value.ToXElement( ) );
					element.Add( ele );
				}
				if (ValueSingular != null)
				{
					XElement ele = new XElement( "ValueSingular" );
					ele.Add( ValueSingular.ToXElement( ) );
					element.Add( ele );
				}
				return element;
			}

			public void LoadByXElement( XElement element )
			{
				S = GetXmlValue( element, nameof( S ), S, byte.Parse );
				F = GetXmlValue( element, nameof( F ), F, byte.Parse );
				W = GetXmlValue( element, nameof( W ), W, bool.Parse );
				Description = GetXmlValue( element, nameof( Description ), Description, m => m );
				foreach(XElement ele in element.Elements())
				{
					if (ele.Name == "Value")
					{
						Value = new SecsValue( ele.Elements( ).First( ) );
					}
					else if (ele.Name == "ValueSingular")
					{
						ValueSingular = new SecsValue( ele.Elements( ).First( ) );
					}
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "SECS Read Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				checkBox2.Text = "Initialization S0F0?";
				checkBox_code_style.Text = "Show Code Info";
				tabPage_log.Text = "Value";
			}
			else
			{
				addNewSecsItemToolStripMenuItem.Text = "新增Secs功能码";
				editSecsItemToolStripMenuItem.Text = "编辑Secs功能码";
				deleteSecsItemToolStripMenuItem.Text = "删除Secs功能码";
				checkBox_show_send_message.Text = "显示发送消息";
				label13.Text = "SECS 日志区域";
				checkBox1.Text = "暂停输出";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox_port.Text,out int port ))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}

			secs?.ConnectClose( );
			secs = new SecsHsms( textBox_ip.Text, port );
			secs.DeviceID = ushort.Parse( textBox_deviceID.Text );
			secs.OnSecsMessageReceived += Secs_OnSecsMessageReceived;
			secs.InitializationS0F0 = checkBox2.Checked;
			secs.LogNet = this.LogNet;
			ComboBox1_SelectedIndexChanged( comboBox1, e );

			secs.LogNet = LogNet;
			try
			{
				OperateResult connect = secs.ConnectServer( );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;


					// 设置示例的代码
					codeExampleControl.SetCodeText( "secs", secs, nameof( SecsHsms.DeviceID ), nameof( SecsHsms.InitializationS0F0 ), nameof( SecsHsms.StringEncoding ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void Secs_OnSecsMessageReceived( object sender, SecsMessage secsMessage )
		{
			// 当接收到数据返回的非应答数据时，需要处理的方法代码，此处只是显示
			if (InvokeRequired)
			{
				Invoke( new Action<object, SecsMessage>( Secs_OnSecsMessageReceived ), sender, secsMessage );
				return;
			}

			if (!checkBox1.Checked)
			{
				AppendHeadText( -1, $"RECV: S{secsMessage.StreamNo}F{secsMessage.FunctionNo}{(secsMessage.W ? "W" : string.Empty)} SystemBytes=" + secsMessage.MessageID );
				AppendHeadText( 0, secsMessage.GetItemValues( ) );
				richTextBox_main.ScrollToCaret( );
			}

			// 判断要不要返回，当且 F 为单数，且树形控件的返回数据不为空时，进行返回数据操作
			if (secsMessage.FunctionNo != 0 && secsMessage.FunctionNo % 2 == 1)
			{
				for ( int i = 0; i < treeView1.Nodes.Count; i++)
				{
					if (("S" + secsMessage.StreamNo) != treeView1.Nodes[i].Text) continue;

					TreeNode treeNode = treeView1.Nodes[i];
					for ( int j = 0; j < treeNode.Nodes.Count; j ++)
					{
						if (treeNode.Nodes[j].Tag is SecsTreeItem secsTreeItem)
						{
							if (secsTreeItem.F != secsMessage.FunctionNo) continue;

							if (secsTreeItem.ValueSingular == null) break;

							// 自动返回这个数据信息
							SendSecsValue( secsTreeItem.S, (byte)(secsTreeItem.F + 1), secsTreeItem.W, secsTreeItem.ValueSingular );
						}
					}

					break;
				}
			}
		}


		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			secs.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			SecsValue secsValue = string.IsNullOrEmpty( textBox_data.Text ) ?
				new SecsValue( ) :
				new SecsValue( XElement.Parse( textBox_data.Text ) );

			OperateResult<SecsMessage> read = secs.ReadSecsMessage( byte.Parse( textBox_stream.Text ), byte.Parse( textBox_function.Text ), secsValue, checkBox_back.Checked );
			if (read.IsSuccess)
			{
				// 修改左边树形菜单的默认值
				textBox_receive.Text = DateTime.Now.ToString( "HH:mm:ss" ) + ": " + Environment.NewLine + read.Content.GetItemValues( )?.ToString( );
			}
			else
			{
				DemoUtils.ShowMessage( "读取失败！" + read.ToMessageShowString( ) );
			}

			string code = secsValue == null ? "null" : secsValue.ToSourceCode( );
			codeExampleControl.ReaderReadCode( $"OperateResult<SecsMessage> read = @deviceName.ReadSecsMessage( {textBox_stream.Text}, {textBox_function.Text}, {code}, {checkBox_back.Checked.ToString( ).ToLower( )} );" );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			SecsValue secsValue = string.IsNullOrEmpty( textBox_data.Text ) ? SecsValue.EmptySecsValue( ) : new SecsValue( XElement.Parse( textBox_data.Text ) );

			OperateResult send = secs.SendByCommand( byte.Parse( textBox_stream.Text ), byte.Parse( textBox_function.Text ), secsValue, checkBox_back.Checked );
			if (send.IsSuccess)
			{
			   DemoUtils.ShowMessage( "发送成功！" );
			}
			else
			{
				DemoUtils.ShowMessage( "发送失败！" + send.ToMessageShowString( ) );
			}

			string code = secsValue == null ? "null" : secsValue.ToSourceCode( );
			codeExampleControl.ReaderReadCode( $"OperateResult send = @deviceName.SendByCommand( {textBox_stream.Text}, {textBox_function.Text}, {code}, {checkBox_back.Checked.ToString( ).ToLower( )} );" );
		}

		private void button4_Click( object sender, EventArgs e )
		{

		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate,  textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStation,   textBox_deviceID.Text );
			element.SetAttributeValue( "Encoding",                  comboBox1.SelectedIndex );
			element.SetAttributeValue( "S0F0", checkBox2.Checked );

			element.RemoveNodes( );
			// 保存现有的树形控件
			for (int i = 0; i < treeView1.Nodes.Count; i++)
			{
				TreeNode root = treeView1.Nodes[i];
				XElement ele1 = new XElement( root.Text );
				for (int j = 0; j < root.Nodes.Count; j++)
				{
					TreeNode secsNode = root.Nodes[j];
					if (secsNode.Tag is SecsTreeItem item)
					{
						ele1.Add( item.ToXElement( ) );
					}
				}
				element.Add( ele1 );
			}
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text           = SoftBasic.GetXmlValue( element, DemoDeviceList.XmlIpAddress, "127.0.0.1" );
			textBox_port.Text         = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox_deviceID.Text     = element.Attribute( DemoDeviceList.XmlStation ).Value;
			comboBox1.SelectedIndex   = SoftBasic.GetXmlValue( element, "Encoding", 1 );
			checkBox2.Checked         = SoftBasic.GetXmlValue( element, "S0F0", false );

			IEnumerable<XElement> roots = element.Elements( );
			if (roots.Count( ) > 0)
			{
				treeView1.Nodes.Clear( );
				foreach (XElement ele1 in roots)
				{
					TreeNode root = new TreeNode( ele1.Name.ToString( ) );
					foreach (XElement ele2 in ele1.Elements( ))
					{
						SecsTreeItem secsTreeItem = new SecsTreeItem( ele2 );
						TreeNode node = new TreeNode( secsTreeItem.GetTreeNodeText( ) );
						node.Tag = secsTreeItem;
						root.Nodes.Add( node );
					}
					treeView1.Nodes.Add( root );
				}
			}
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button_S1F1_Click( object sender, EventArgs e )
		{
			OperateResult<OnlineData> read = this.secs.Gem.S1F1_AreYouThere( );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToJsonString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button_s1f11_Click( object sender, EventArgs e )
		{
			OperateResult<VariableName[]> read = null;
			if (string.IsNullOrEmpty( textBox4.Text ))
				read = this.secs.Gem.S1F11_StatusVariableNamelist( );
			else
				read = this.secs.Gem.S1F11_StatusVariableNamelist( textBox4.Text.ToStringArray<int>( ) );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToJsonString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button_s1f13_Click( object sender, EventArgs e )
		{
			OperateResult<OnlineData> read = this.secs.Gem.S1F13_EstablishCommunications( );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToJsonString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button_s1f15_Click( object sender, EventArgs e )
		{
			OperateResult<byte> read = this.secs.Gem.S1F15_OfflineRequest( );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToString( ) + Environment.NewLine + "返回值说明，0: ok, 1: refused, 2: already online";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button_s1f17_Click( object sender, EventArgs e )
		{
			OperateResult<byte> read = this.secs.Gem.S1F17_OnlineRequest( );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToString( ) + Environment.NewLine + "返回值说明，0: ok, 1: refused, 2: already online";
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button_s2f13_Click( object sender, EventArgs e )
		{
			OperateResult<SecsValue> read = this.secs.Gem.S2F13_EquipmentConstantRequest( );
			if (read.IsSuccess)
			{
				textBox_s1.Text = read.Content.ToString( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}

		private void button4_Click_1( object sender, EventArgs e )
		{
			richTextBox_main.Clear( );
		}

		private void RenderMessage( int code, string msg )
		{
			if (!string.IsNullOrEmpty( msg ))
			{
				int index = richTextBox_main.Text.Length;
				richTextBox_main.AppendText( msg );
				richTextBox_main.Select( index, msg.Length );
				if (code < 0)
					richTextBox_main.SelectionColor = Color.Gray;
				else if (code == 0)
					richTextBox_main.SelectionColor = Color.Green;
				else if (code == 1)
					richTextBox_main.SelectionColor = Color.Blue;
				else if (code == 4)
					richTextBox_main.SelectionColor = Color.Purple;
				else
					richTextBox_main.SelectionColor = Color.Red;
				richTextBox_main.AppendText( Environment.NewLine );
			}
		}

		private void AppendHeadText( int code, string text )
		{
			string msg = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "  " + text;
			RenderMessage( code, msg );
		}

		private void AppendHeadText( int code, SecsValue secsValue )
		{
			RenderMessage( code, 
				comboBox_log_style.SelectedIndex == 0 ? secsValue.ToString( ) :
				comboBox_log_style.SelectedIndex == 1 ? secsValue.ToSourceCode( format: true ) : secsValue.ToSourceCode( ) );
		}


		private void SendSecsValue( byte s, byte f, bool w, SecsValue secsValue )
		{
			OperateResult send = secs.SendByCommand( byte.Parse( textBox_stream.Text ), byte.Parse( textBox_function.Text ), secsValue, w );
			if (send.IsSuccess)
			{
				//DemoUtils.ShowMessage( "发送成功！" );
			}
			else
			{
				AppendHeadText( 5, $"SEND:  S{s}F{f}{(w ? "W" : string.Empty)}" + " faild: " + send.Message );
				richTextBox_main.ScrollToCaret( );
				return;
			}

			if (checkBox_show_send_message.Checked)
			{
				AppendHeadText( -1, $"SEND:  S{s}F{f}{(w ? "W" : string.Empty)}" );
				AppendHeadText( 1, secsValue );
				richTextBox_main.ScrollToCaret( );
			}
		}

		private void sendMessageToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode != null)
			{
				if (treeNode.Tag is SecsTreeItem item)
				{
					if (item.Value == null) item.Value = SecsValue.EmptySecsValue( );
					SecsValue secsValue = item.Value;
					//if (item.W)
					//{
					//                   OperateResult<SecsMessage> read = secs.ReadSecsMessage( item.S, item.F, secsValue, item.W );
					//                   if (read.IsSuccess)
					//                   {
					//                       // 修改左边树形菜单的默认值
					//                       textBox_receive.Text = DateTime.Now.ToString( "HH:mm:ss" ) + ": " + Environment.NewLine + read.Content.GetItemValues( )?.ToString( );
					//                   }
					//                   else
					//                   {
					//                       DemoUtils.ShowMessage( "读取失败！" + read.ToMessageShowString( ) );
					//                   }

					//                   string code = secsValue == null ? "null" : secsValue.ToSourceCode( );
					//                   codeExampleControl.ReaderReadCode( $"OperateResult<SecsMessage> read = @deviceName.ReadSecsMessage( {textBox_stream.Text}, {textBox_function.Text}, {code}, {checkBox_back.Checked.ToString( ).ToLower( )} );" );
					//               }
					//else
					//{
					SendSecsValue( item.S, item.F, item.W, secsValue );

					string code = secsValue == null ? "null" : secsValue.ToSourceCode( );
					codeExampleControl.ReaderReadCode( $"OperateResult send = @deviceName.SendByCommand( {textBox_stream.Text}, {textBox_function.Text}, {code}, {checkBox_back.Checked.ToString( ).ToLower( )} ); // 仅发送消息" + Environment.NewLine + Environment.NewLine +
						 $"OperateResult<SecsMessage> read = @deviceName.ReadSecsMessage( {textBox_stream.Text}, {textBox_function.Text}, {code}, {checkBox_back.Checked.ToString( ).ToLower( )} );   // 应答方式" );

					//}
				}
			}
		}

		private void addNewSecsItemToolStripMenuItem_Click( object sender, EventArgs e )
		{
			SecsHelper.AddNewSecsItemToolStripMenuItem_Click( treeView1, RenderSelectedSecs, server: false );
		}

		private void editSecsItemToolStripMenuItem_Click( object sender, EventArgs e )
		{
			SecsHelper.EditSecsItemToolStripMenuItem_Click( treeView1, RenderSelectedSecs, server: false );
		}

		private void deleteSecsItemToolStripMenuItem_Click( object sender, EventArgs e )
		{
			SecsHelper.DeleteSecsItemToolStripMenuItem_Click( treeView1 );
		}

		private void treeView1_MouseDown( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode node = treeView1.GetNodeAt( e.Location );
				if (node != null)
				{
					treeView1.SelectedNode = node;

					// 显示右键菜单

					contextMenuStrip1.Show( treeView1, e.Location );
				}
			}
		}

		private SecsValue renderSecsValueLeft = SecsValue.EmptySecsValue( );
		private SecsValue renderSecsValueRight = SecsValue.EmptySecsValue( );

		private void checkBox_code_style_CheckedChanged( object sender, EventArgs e )
		{
			if (renderSecsValueLeft != null)
				textBox_data.Text = checkBox_code_style.Checked ? renderSecsValueLeft.ToSourceCode( true ) : renderSecsValueLeft.ToXElement( ).ToString( );
			if (renderSecsValueRight != null)
				textBox_receive.Text = checkBox_code_style.Checked ? renderSecsValueRight.ToSourceCode( true ) : renderSecsValueRight.ToString( );
		}
	}
}
