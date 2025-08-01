using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Profinet.OpenProtocol;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormOpenProtocol : HslFormContent
	{
		public FormOpenProtocol( )
		{
			InitializeComponent( );

			this.toolTip = new ToolTip( );
			string tip = "额外的mid数组，如果你得用于订阅返回的mid大于421，则需要在数组里额外指定，例如 1000,1010";
			if (Program.Language == 2) tip = "Additional mid array, if you need to subscribe to the returned mid greater than 421, you need to specify it additionally in the array, such as 1000,1010";
			this.toolTip.SetToolTip( label_sub_mid, tip );
		}

		private void Button1_Click( object sender, EventArgs e )
		{
			// 连接
			if (!int.TryParse( textBox_revison_connect.Text, out int revison ))
			{
				DemoUtils.ShowMessage( "revison input format wrong！" );
				return;
			}

			openProtocol?.ConnectClose( );
			openProtocol = new OpenProtocolNet( );
			openProtocol.LogNet = this.LogNet;
			openProtocol.AutoAckControllerMessage = checkBox1.Checked;
			openProtocol.KeepAliveMessageEnable = checkBox2.Checked;
			openProtocol.RevisonOnConnected = revison;                             // 如果设置小于0 则连接时不使用 MID0001
			openProtocol.OnReceivedOpenMessage += OpenProtocol_ReceivedMessage;
			try
			{
				if (!string.IsNullOrEmpty( textBox_sub_mid.Text )) openProtocol.ExtraSubscribeMID = textBox_sub_mid.Text.ToStringArray<int>( );
				this.pipeSelectControl1.IniPipe( openProtocol );
				OperateResult connect = DeviceConnectPLC( openProtocol );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;


					List<string> paras = new List<string>( );
					paras.Add( nameof( openProtocol.RevisonOnConnected ) );
					paras.Add( nameof( openProtocol.AutoAckControllerMessage ) );
					paras.Add( nameof( openProtocol.KeepAliveMessageEnable ) );
					if (!string.IsNullOrEmpty( textBox_sub_mid.Text )) paras.Add( nameof( openProtocol.ExtraSubscribeMID ) );

					codeExampleControl.SetCodeText( "openProtocol", openProtocol, paras.ToArray( ) );
				}
				else
				{
					DemoUtils.ShowMessage( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}

		}

		private void button2_Click( object sender, EventArgs e )
		{
			try
			{
				openProtocol?.ConnectClose( );
				button2.Enabled = false;
				button1.Enabled = true;
			}
			catch( Exception ex )
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void OpenProtocol_ReceivedMessage( object sender, OpenEventArgs e )
		{
			this.Invoke( new Action( ( ) =>
			{
				System.Threading.Interlocked.Increment( ref sub_tick );
				label_subscribe_tick.Text = sub_tick.ToString( );

				if (!checkBox_sub_stop.Checked)
				{
					if (checkBox_sub_format.Checked)
					{
						textBox_log.Text = DateTime.Now.ToString( ) + " :               Length: " + e.Content.Length + Environment.NewLine + Environment.NewLine + GetRenderOpenMessage( e.Content );
					}
					else
					{
						textBox_log.AppendText( DateTime.Now.ToString( ) + " : " + e.Content + Environment.NewLine );
					}
				}
			} ) );
		}

		private long sub_tick = 0;
		private long read_tick = 0;
		private OpenProtocolNet openProtocol = null;
		private CodeExampleControl codeExampleControl;
		private ToolTip toolTip;

		private void FormOpenProtocol_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			// 添加 Open protocol 消息
			TreeNode node0 = new TreeNode( " Communication messages" );
			node0.Nodes.Add( new TreeNode( "MID 0008 Data message subscription" ) { Tag = new OpenMessage( mid: 8, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "0900" } ) } );
			node0.Nodes.Add( new TreeNode( "MID 0009 Data message unsubscribe" ) { Tag = new OpenMessage( mid: 9, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "0900" } ) } );
			treeView1.Nodes.Add( node0 );

			TreeNode node1 = new TreeNode( "Parameter set messages" );
			node1.Nodes.Add( new TreeNode( "MID 0010 Parameter set ID upload" )               { Tag = new OpenMessage( mid: 10, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0012 Parameter set data upload" )             { Tag = new OpenMessage( mid: 12, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0014 Parameter set selected subscribe" )      { Tag = new OpenMessage( mid: 14, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0017 Parameter set selected unsubscribe" )    { Tag = new OpenMessage( mid: 17, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0018 Select Parameter set" )                  { Tag = new OpenMessage( mid: 18, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0019 Set Parameter set batch size" )          { Tag = new OpenMessage( mid: 19, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000", "00" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0020 Reset Parameter set batch counter" )     { Tag = new OpenMessage( mid: 20, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			treeView1.Nodes.Add( node1 );

			TreeNode node2 = new TreeNode( "Job message" );
			node2.Nodes.Add( new TreeNode( "MID 0030 Job ID upload" )        { Tag = new OpenMessage( mid: 30, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0032 Job data upload" )      { Tag = new OpenMessage( mid: 32, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "01" } ) } );
			node2.Nodes.Add( new TreeNode( "MID 0034 Job info subscribe" )   { Tag = new OpenMessage( mid: 34, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0037 Job info unsubscribe" ) { Tag = new OpenMessage( mid: 37, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0038 Select Job" )           { Tag = new OpenMessage( mid: 38, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "01" } ) } );
			node2.Nodes.Add( new TreeNode( "MID 0039 Job restart" )          { Tag = new OpenMessage( mid: 39, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "00" } ) } );
			treeView1.Nodes.Add( node2 );

			TreeNode node3 = new TreeNode( "Tool messages" );
			node3.Nodes.Add( new TreeNode( "MID 0040 Tool data upload" )      { Tag = new OpenMessage( mid: 40, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0042 Disable tool" )          { Tag = new OpenMessage( mid: 42, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0043 Enable tool" )           { Tag = new OpenMessage( mid: 43, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0044 Disconnect tool" )       { Tag = new OpenMessage( mid: 44, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0045 Set calibration value" ) { Tag = new OpenMessage( mid: 44, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "011", "02003550" } ) } );
			treeView1.Nodes.Add( node3 );


			TreeNode node4 = new TreeNode( "VIN Messages" );
			node4.Nodes.Add( new TreeNode( "MID 0050 Vehicle ID Number download" )   { Tag = new OpenMessage( mid: 50, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "0000000000000000000000000" } ) } );
			node4.Nodes.Add( new TreeNode( "MID 0051 Vehicle ID Number subscribe" )  { Tag = new OpenMessage( mid: 51, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node4.Nodes.Add( new TreeNode( "MID 0054 Vehicle ID Number unsubscrib" ) { Tag = new OpenMessage( mid: 54, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node4 );

			TreeNode node5 = new TreeNode( "Tightening result messages" );
			node5.Nodes.Add( new TreeNode( "MID 0060 Last tightening result data subscribe" )   { Tag = new OpenMessage( mid: 60, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node5.Nodes.Add( new TreeNode( "MID 0063 Last tightening result data unsubscribe" ) { Tag = new OpenMessage( mid: 63, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node5.Nodes.Add( new TreeNode( "MID 0064 Old tightening result upload" )            { Tag = new OpenMessage( mid: 64, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "0000000000" } ) } );
			treeView1.Nodes.Add( node5 );

			TreeNode node6 = new TreeNode( "Alarm messages" );
			node6.Nodes.Add( new TreeNode( "MID 0070 Alarm subscribe" )                          { Tag = new OpenMessage( mid: 70, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0073 Alarm unsubscribe" )                        { Tag = new OpenMessage( mid: 73, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0078 Acknowledge alarm remotely on controller" ) { Tag = new OpenMessage( mid: 78, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node6 );

			TreeNode node7 = new TreeNode( "Time messages" );
			node7.Nodes.Add( new TreeNode( "MID 0080 Read time upload" ) { Tag = new OpenMessage( mid: 80, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node7.Nodes.Add( new TreeNode( "MID 0082 Set Time" )         { Tag = new OpenMessage( mid: 82, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { DateTime.Now.ToString( "yyyy-MM-dd:HH:mm:ss" ) } ) } );
			treeView1.Nodes.Add( node7 );

			TreeNode node8 = new TreeNode( "Multi-spindle status messages" );
			node8.Nodes.Add( new TreeNode( "MID 0090 Multi-spindle status subscribe" )   { Tag = new OpenMessage( mid: 90, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node8.Nodes.Add( new TreeNode( "MID 0093 Multi-spindle status unsubscribe" ) { Tag = new OpenMessage( mid: 93, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node8 );

			TreeNode node9 = new TreeNode( "Multi-spindle result messages" );
			node9.Nodes.Add( new TreeNode( "MID 0100 Multi-spindle result subscribe" )   { Tag = new OpenMessage( mid: 100, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node9.Nodes.Add( new TreeNode( "MID 0103 Multi spindle result unsubscribe" ) { Tag = new OpenMessage( mid: 103, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node9 );

			TreeNode node10 = new TreeNode( "PowerMACS result data" );
			node10.Nodes.Add( new TreeNode( "MID 0105 Last PowerMACS tightening result data subscribe" ) { Tag = new OpenMessage( mid: 105, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node10.Nodes.Add( new TreeNode( "MID 0109 Last PowerMACS tightening result data unsubscribe" ) { Tag = new OpenMessage( mid: 109, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node10 );



			treeView1.ExpandAll( );
			treeView1.AfterSelect += TreeView1_AfterSelect;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if (e.Node.Tag is OpenMessage openMessage)
			{
				textBox_mid.Text = openMessage.MID.ToString( );
				textBox_revision.Text = openMessage.Revision.ToString( );
				textBox_stationID.Text = openMessage.StationID.ToString( );
				textBox_spindleID.Text = openMessage.SpindleID.ToString( );
				if (openMessage.DataField != null)
				{
					textBox_dataField.Lines = openMessage.DataField.ToArray( );
				}
				else
				{
					textBox_dataField.Text = string.Empty;
				}
			}
		}

		private string GetMIDText( int mid )
		{
			switch(mid)
			{
				case 1: return "Communication start";
				case 2: return "Communication start acknowledge";
				case 3: return "Communication stop";
				case 4: return "Command error";
				case 5: return "Command accepted";
				case 10: return "Parameter set ID upload request";
				case 11: return "Parameter set ID upload reply";
				case 12: return "Parameter set data upload request";
				case 13: return "Parameter set data upload reply";
				case 14: return "Parameter set selected subscribe";
				case 15: return "Parameter set selected";
				case 16: return "Parameter set selected acknowledge";
				case 17: return "Parameter set selected unsubscribe";
				case 18: return "Select Parameter set";
				case 19: return "Set Parameter set batch size";
				case 20: return "Reset Parameter set batch counter";
				case 30: return "Job ID upload request";
				case 31: return "Job ID upload reply";
				case 32: return "Job data upload request";
				case 33: return "Job data upload reply";
				case 34: return "Job info subscribe";
				case 35: return "Job info";
				case 36: return "Job info acknowledge";
				case 37: return "Job info unsubscribe";
				case 38: return "Select Job";
				case 39: return "Job restart";
				case 40: return "Tool data upload request";
				case 41: return "Tool data upload reply";
				case 42: return "Disable tool";
				case 43: return "Enable tool";
				case 44: return "Disconnect tool request";
				case 45: return "Set calibration value request";
				case 50: return "Vehicle ID Number download request";
				case 51: return "Vehicle ID Number subscribe";
				case 52: return "Vehicle ID Number";
				case 53: return "Vehicle ID Number acknowledge";
				case 54: return "Vehicle ID Number unsubscribe";
				case 60: return "Last tightening result data subscribe";
				case 61: return "Last tightening result data";
				case 62: return "Last tightening result data acknowledge";
				case 63: return "Last tightening result data unsubscribe";
				case 64: return "Old tightening result upload request";
				case 65: return "Old tightening result upload reply";
				case 70: return "Alarm subscribe";
				case 71: return "Alarm";
				case 72: return "Alarm acknowledge";
				case 73: return "Alarm unsubscribe";
				case 74: return "Alarm acknowledged on controller";
				case 75: return "Alarm acknowledged on controller acknowledge";
				case 76: return "Alarm status";
				case 77: return "Alarm status acknowledge";
				case 78: return "Acknowledge alarm remotely on controller";
				case 80: return "Read time upload request";
				case 81: return "Read time upload reply";
				case 82: return "Set Time";
				case 90: return "Multi-spindle status subscribe";
				case 91: return "Multi-spindle status";
				case 92: return "Multi-spindle status acknowledge";
				case 93: return "Multi-spindle status unsubscribe";
				case 100: return "Multi-spindle result subscribe";
				case 101: return "Multi-spindle result";
				case 102: return "Multi-spindle result acknowledge";
				case 103: return "Multi spindle result unsubscribe";
				default: return "Unknown";
			}
		}

		private void AddStringBuilder( StringBuilder sb, string content, bool withIndex = true, params string[] paras )
		{
			sb.Append( "Name".PadRight( 35, ' ' ) );
			sb.Append( "Index:Len".PadRight( 15, ' ' ) );
			sb.Append( "Num".PadRight( 10, ' ' ) );
			sb.Append( "Value" );
			sb.AppendLine( );

			for (int i = 0; i < paras.Length; i++)
			{
				int index = paras[i].IndexOf( '[' );
				if (index < 0) return;

				string tail = string.Empty;
				if (!paras[i].EndsWith("]"))
				{
					int endIndex = paras[i].LastIndexOf( "]" );
					if (endIndex > 0)
					{
						tail = paras[i].Substring( endIndex + 1 );
						paras[i] = paras[i].Substring( 0, endIndex + 1 );
					}
				}

				// 先添加名称信息
				string name = paras[i].Substring( 0, index );

				// [21-25]   [21-N]  []
				MatchCollection mc = Regex.Matches( paras[i].Substring( index ), @"[0-9]+" );
				if (mc.Count != 2)
				{
					int index1 = Convert.ToInt32( mc[0].Value ) - 1;
					if (index1 >= content.Length - 1) break;
					sb.Append( name.PadRight( 35, ' ' ) );

					sb.Append( $"[{index1}:N]".PadRight( 15, ' ' ) );

					if (mc.Count == 1 && paras[i].Substring( index ).EndsWith( "N]" ))
					{
						if (withIndex)
						{
							sb.Append( content.Substring( index1, 2 ).PadRight( 10, ' ' ) );
							sb.Append( content.Substring( index1 + 2 ) );
						}
						else
						{
							sb.Append( " ".PadRight( 10, ' ' ) );
							sb.Append( content.Substring( index1 ) );
						}
						if (sb[sb.Length - 1] == 0x00) sb.Remove( sb.Length - 1, 1 );
					}
					if (!string.IsNullOrEmpty( tail )) sb.Append( "  // " + tail );
				}
				else
				{
					int index1 = Convert.ToInt32( mc[0].Value ) - 1;
					int index2 = Convert.ToInt32( mc[1].Value ) - 1;
					int len = index2 - index1 + 1;

					if (index1 >= content.Length - 1) break;
					sb.Append( name.PadRight( 35, ' ' ) );

					sb.Append( $"[{index1}:{len}]".PadRight( 15, ' ' ) );
					if (withIndex)
					{
						sb.Append( content.Substring( index1, 2 ).PadRight( 10, ' ' ) );
						sb.Append( content.Substring( index1 + 2, len - 2 ) );
					}
					else
					{
						sb.Append( " ".PadRight( 10, ' ' ) );
						sb.Append( content.Substring( index1, len ) );
					}
					if (!string.IsNullOrEmpty( tail )) sb.Append( "  // " + tail );
				}
				sb.Append( Environment.NewLine );
			}
		}



		private string GetRenderOpenMessage( string content )
		{
			int mid = Convert.ToInt32( content.Substring( 4, 4 ) );
			int revision = Convert.ToInt32( content.Substring( 8, 3 ) );

			StringBuilder sb = new StringBuilder( $"MID {content.Substring( 4, 4 )} : {GetMIDText( mid )}" );
			sb.AppendLine( );
			sb.AppendLine( $"Revision {content.Substring( 8, 3 )}                       Ack flag: {content.Substring( 11, 1 )} {(content[11] == '0' ? "Ack needed" : content[11] == '1' ? "No ack needed" : string.Empty)}" );
			sb.AppendLine( );

			if (mid == 4)
			{
				sb.AppendLine( $"Command MID: {content.Substring( 20, 4 )}   Error: {content.Substring( 24, 2 )}" );
				sb.AppendLine( $"Message: {OpenProtocolNet.GetErrorText( Convert.ToInt32( content.Substring( 24, 2 ) ) )}" );
			}
			else if (mid == 5) AddStringBuilder( sb, content, withIndex: false, "MID number accepted[21-24]" );
			else if (mid == 11) AddStringBuilder( sb, content, withIndex: false, "The number of parameter sets[21-23]", "The ID of each parameter set[24-N]" );
			else if (mid == 13) AddStringBuilder( sb, content, withIndex: true, "Parameter set ID[21-25]", "Parameter set name[26-52]", "Rotation direction[53-55]1=CW;2=CCW", "Batch size[56-59]", "Torque min[60-67]",
				"Torque max[68-75]", "Torque final target[76-83]", "Angle min[84-90]", "Angle max[91-97]", "Final Angle Target[98-104]" );
			else if (mid == 15) AddStringBuilder( sb, content, withIndex: false, "Parameter set ID[21-23]", "Date of last change[21-42]" );
			else if (mid == 31 && revision == 1) { AddStringBuilder( sb, content, withIndex: false, "Number of Jobs[21-22]", "Job ID of each Job[23-N]" ); }
			else if (mid == 31 && revision == 2) { AddStringBuilder( sb, content, withIndex: false, "Number of Jobs[21-24]", "Job ID of each Job[25-N]" ); }
			else if (mid == 33) AddStringBuilder( sb, content, withIndex: true, "Job ID[21-24]", "Job name[25-51]", "Forced order[52-54]", "Max time for first tightening[55-60]", "Max time to complete Job[61-67]", "Job batch mode[68-70]", "Lock at Job done[71-73]",
				"Use line control[74-76]", "Repeat Job[77-79]", "Tool loosening[80-82]", "Reserved[83-85]", "Number of parameter sets[86-89]", "Job list[90-N]" );
			else if (mid == 35 && revision == 1) AddStringBuilder( sb, content, withIndex: true, "Job ID[21-24]", "Job status[25-27]", "Job batch mode[28-30]", "Job batch size[31-36]", "Job batch counter[37-42]", "Time stamp[43-63]" );
			else if (mid == 41) AddStringBuilder( sb, content, withIndex: true, "Tool serial number[21-36]", "Tool number of tightening[37-48]", "Last calibration date[49-69]", "Controller serial number[70-81]",
				"Calibration value[82-89]", "Last service date[90-110]", "Tightenings since service[111-122]", "Tool type[123-126]", "Motor size[127-130]", "Open end data[131-135]", "Controller software version[136-156]" );
			else if (mid == 52) AddStringBuilder( sb, content, withIndex: true, "VIN number[21-47]", "Identifier result part 2[48-74]", "Identifier result part 3[75-91]", "Identifier result part 4[92-128]" );
			else if (mid == 61 && revision == 1) AddStringBuilder( sb, content, withIndex: true, "Cell ID[21-26]", "Channel ID[27-30]", "Torque controller Name[31-57]", "VIN Number[58-84]", "Job ID[85-88]", "Parameter set ID[89-93]",
				"Batch size[94-99]", "Batch counter[100-105]", "Tightening Status[106-108]", "Torque status[109-111]", "Angle status[112-114]", "Torque Min limit[115-122]", "Torque Max limit[123-130]",
				"Torque final target[131-138]", "Torque[139-146]", "Angle Min[147-153]", "Angle Max[154-160]", "Final Angle Target[161-167]", "Angle[168-174]", "Time stamp[175-195]", "Date/time of last change[196-216]", "Batch status[217-219]", "Tightening ID[220-231]" );
			else if (mid == 61 && revision == 999) AddStringBuilder( sb, content, withIndex: false, "VIN Number[21-45]", "Job ID[46-47]", "Parameter set ID[48-50]", "Batch size[51-54]", "Batch counter[55-58]", "Batch status[59-59]",
				"Tightening status[60-60]", "Torque status[61-61]", "Angle status[62-62]", "Torque[63-68]", "Angle[69-73]", "Time stamp[74-92]", "Date/time of last change[93-111]", "Tightening ID[112-121]" );
			else if (mid == 65 && revision == 1) AddStringBuilder( sb, content, withIndex: true, "Tightening ID[21-32]", "VIN Number[33-59]", "Parameter set ID[60-64]", "Batch counter[65-70]", "Tightening Status[71-73]", "Torque status[74-76]",
				"Angle status[77-79]", "Torque[80-87]", "Angle[88-94]", "Time stamp[95-115]", "Batch status[116-118]" );
			else if (mid == 71) AddStringBuilder( sb, content, withIndex: true, "Error code[21-26]", "Controller ready status[27-29]", "Tool ready status[30-32]", "Time[33-53]" );
			else if (mid == 74) AddStringBuilder( sb, content, withIndex: false, "Error code[21-24]" );
			else if (mid == 76) AddStringBuilder( sb, content, withIndex: true, "Alarm status[21-23]", "Error code[24-29]", "Controller ready status[30-32]", "Tool ready status[33-35]", "Time[36-56]" );
			else if (mid == 81) AddStringBuilder( sb, content, withIndex: false, "Time[21-39]" );
			else if (mid == 106) AddStringBuilder( sb, content, withIndex: true, "Total no of messages[21-24]", "Message number[25-28]", "Data No System[29-40]", "Station No[41-44]", "Station Name[45-66]", "Time[67-87]",
				"Mode No[88-91]", "Mode Name[92-113]", "Simple status[114-116]", "PM Status[117-119]", "Wp. Id[120-161]", "Number of Bolts[162-165]" );
			else if (mid == 107) AddStringBuilder( sb, content, withIndex: true, "Total no of messages[21-24]", "Message number[25-28]", "Data No System[29-40]", "Station No[41-44]", "Time[45-55]", "Bolt number[56-61]",
				"Bolt name[62-83]", "Program name[84-105]", "PM status[106-108]", "Errors[109-160]", "Customer error code[161-166]", "Number of Bolt results[167-170]" );


			sb.AppendLine( );
			sb.AppendLine( );
			sb.AppendLine( "Source Content: ======================================================" );
			sb.Append( content );
			return sb.ToString( );
		}

		private string getArrayString( string[] values )
		{
			if (values == null || values.Length <= 0) return string.Empty;
			var sb = new StringBuilder( );
			for (int i = 0; i < values.Length; i++)
			{
				sb.Append( "\"" );
				sb.Append( values[i] );
				sb.Append( "\"" );
				if (i < values.Length - 1) sb.Append( "," );
			}
			return sb.ToString( );
		}

		private void Button_read_string_Click( object sender, EventArgs e )
		{
			try
			{
				textBox_read_content.Text = string.Empty;
				textBox_read_content.Refresh( );

				DateTime start = DateTime.Now;
				OperateResult<string> read = openProtocol.ReadCustomer( int.Parse( textBox_mid.Text ),
					int.Parse( textBox_revision.Text ), int.Parse( textBox_stationID.Text ), int.Parse( textBox_spindleID.Text ), new List<string>( textBox_dataField.Lines ) );

				TimeSpan ts = DateTime.Now - start;
				if (read.IsSuccess)
				{
					label_read_time.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
					label_read_cost.Text = ts.TotalMilliseconds.ToString( "F0" ) + " ms";
					read_tick++;
					label_read_tick.Text = read_tick.ToString( );
					label_read_byteLength.Text = read.Content.Length.ToString( );


					textBox_read_content.Text = GetRenderOpenMessage( read.Content );
					//textBox_log.AppendText( DateTime.Now.ToString( ) + " : " + read.Content.Trim( '\0' ) + Environment.NewLine );
				}
				else
				{
					DemoUtils.ShowMessage( "Read Failed :" + read.Message );
				}
				textBox_code.Text = $"OperateResult<string> read = openProtocol.ReadCustomer( {int.Parse( textBox_mid.Text )}," +
					$"{int.Parse( textBox_revision.Text )}, {int.Parse( textBox_stationID.Text )}, {int.Parse( textBox_spindleID.Text )}, " +
					$"new List<string>() {{{getArrayString( textBox_dataField.Lines )}}} );";
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}


		#region Save Load

		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( "RevisonConnect", textBox_revison_connect.Text );
			element.SetAttributeValue( "AutoAckControllerMessage", checkBox1.Checked );
			element.SetAttributeValue( "MID9999", checkBox2.Checked );
			element.SetAttributeValue( "SubMID", textBox_sub_mid.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.TcpPipe );
			textBox_revison_connect.Text = GetXmlValue( element, "RevisonConnect", "1", m => m );
			checkBox1.Checked = GetXmlValue( element, "AutoAckControllerMessage", checkBox1.Checked, bool.Parse );
			checkBox2.Checked = GetXmlValue( element, "MID9999", true, bool.Parse );
			textBox_sub_mid.Text = GetXmlValue( element, "SubMID", string.Empty, m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		#endregion

		private void FormOpenProtocol_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
	}

	public class OpenMessage
	{
		public OpenMessage( int mid, int revision, int stationID, int spindleID, List<string> dataField  )
		{
			this.MID = mid;
			this.Revision = revision;
			this.StationID = stationID;
			this.SpindleID = spindleID;
			this.DataField = dataField;
		}

		public int MID { get; set; }

		public int Revision { get; set; }

		public int StationID { get; set; }

		public int SpindleID { get; set; }

		public List<string> DataField { get; set; }
	}
}
