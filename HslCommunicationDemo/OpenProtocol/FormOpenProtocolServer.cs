using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core.Device;
using HslCommunication.LogNet;
using HslCommunication.Profinet.OpenProtocol;
using HslCommunicationDemo.DemoControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HslCommunicationDemo
{
	public partial class FormOpenProtocolServer : HslFormContent
	{
		public FormOpenProtocolServer( )
		{
			InitializeComponent( );
		}

		private void Button1_Click( object sender, EventArgs e )
		{
			// 连接
			if (!int.TryParse( textBox_port.Text, out int port ))
			{
				DemoUtils.ShowMessage( "端口输入格式不正确！" );
				return;
			}

			server = new OpenProtocolServer( );
			server.LogNet = new LogNetSingle( string.Empty );
			server.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;


			try
			{
				server.ServerStart( port );
				DemoUtils.ShowMessage( Program.Language == 1 ? "启动成功！" : "Start success" );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
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
				server?.ServerClose( );
				button2.Enabled = false;
				button1.Enabled = true;
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			// 输出到控件界面上去
			Invoke( new Action( ( ) =>
			{
				textBox_result.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			} ) );
		}

		private void OpenProtocol_ReceivedMessage( object sender, OpenEventArgs e )
		{
			this.Invoke( new Action( ( ) =>
			{
				textBox_result.AppendText( DateTime.Now.ToString( ) + " : " + e.Content + Environment.NewLine );
			} ) );
		}

		private OpenProtocolServer server = null;
		private CodeExampleControl codeExampleControl;

		private void FormOpenProtocol_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			// 添加 Open protocol 消息
			TreeNode node1 = new TreeNode( "Parameter set messages" );
			node1.Nodes.Add( new TreeNode( "MID 0010 Parameter set ID upload" )               { Tag = new OpenMessage( mid: 10, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0012 Parameter set data upload" )             { Tag = new OpenMessage( mid: 12, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0014 Parameter set selected subscribe" )      { Tag = new OpenMessage( mid: 14, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0017 Parameter set selected unsubscribe" )    { Tag = new OpenMessage( mid: 17, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0018 Select Parameter set" )                  { Tag = new OpenMessage( mid: 18, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000", "00" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0019 Set Parameter set batch size" )          { Tag = new OpenMessage( mid: 19, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000", "00" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0020 Reset Parameter set batch counter" )     { Tag = new OpenMessage( mid: 20, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			treeView1.Nodes.Add( node1 );

			TreeNode node2 = new TreeNode( "Job message" );
			node2.Nodes.Add( new TreeNode( "MID 0030 Job ID upload" )        { Tag = new OpenMessage( mid: 30, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0032 Job data upload" )      { Tag = new OpenMessage( mid: 32, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0034 Job info subscribe" )   { Tag = new OpenMessage( mid: 34, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0037 Job info unsubscribe" ) { Tag = new OpenMessage( mid: 37, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0038 Select Job" )           { Tag = new OpenMessage( mid: 38, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "00" } ) } );
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
			node5.Nodes.Add( new TreeNode( "MID 0064 Old tightening result upload" )            { Tag = new OpenMessage( mid: 64, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node5 );

			TreeNode node6 = new TreeNode( "Alarm messages" );
			node6.Nodes.Add( new TreeNode( "MID 0070 Alarm subscribe" )                          { Tag = new OpenMessage( mid: 70, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0073 Alarm unsubscribe" )                        { Tag = new OpenMessage( mid: 73, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0074 Alarm acknowledged on controller" )         { Tag = new OpenMessage( mid: 74, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "E406" } ) } );
			node6.Nodes.Add( new TreeNode( "MID 0076 Alarm status" )                             { Tag = new OpenMessage( mid: 76, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "011", "02E404", "031", "041", "052024-07-03:17:08:12" } ) } );
			node6.Nodes.Add( new TreeNode( "MID 0078 Acknowledge alarm remotely on controller" ) { Tag = new OpenMessage( mid: 78, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node6 );

			TreeNode node7 = new TreeNode( "Time messages" );
			node7.Nodes.Add( new TreeNode( "MID 0080 Read time upload" ) { Tag = new OpenMessage( mid: 80, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node7.Nodes.Add( new TreeNode( "MID 0082 Set Time" )         { Tag = new OpenMessage( mid: 82, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { DateTime.Now.ToString( "yyyy-MM-dd:HH:mm:ss" ) } ) } );
			treeView1.Nodes.Add( node7 );

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

		private void Button_read_string_Click( object sender, EventArgs e )
		{
			try
			{
				this.server.Publish( int.Parse( textBox_mid.Text ),
					int.Parse( textBox_revision.Text ), int.Parse( textBox_stationID.Text ), int.Parse( textBox_spindleID.Text ), new List<string>( textBox_dataField.Lines ) );

				textBox_result.AppendText( DateTime.Now.ToString( ) + " : Publish success" + Environment.NewLine );
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		#region Save Load

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( nameof( DeviceServer.Port ), textBox_port.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = GetXmlValue( element, nameof( DeviceServer.Port ), textBox_port.Text, m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		#endregion

		private void FormOpenProtocolServer_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty ); // 如果没有关闭，则进行关闭操作
		}
	}
}
