using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.Profinet.OpenProtocol;
using HslCommunicationDemo.DemoControl;

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
				MessageBox.Show( "端口输入格式不正确！" );
				return;
			}

			server = new OpenProtocolServer( );
			server.LogNet = new LogNetSingle( string.Empty );
			server.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;


			try
			{
				server.ServerStart( port );
				MessageBox.Show( Program.Language == 1 ? "启动成功！" : "Start success" );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
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

		private OpenProtocolNet openProtocol = null;
		private OpenProtocolServer server = null;
		private CodeExampleControl codeExampleControl;

		private void FormOpenProtocol_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;

			// 添加 Open protocol 消息
			TreeNode node1 = new TreeNode( "Parameter set messages" );
			node1.Nodes.Add( new TreeNode( "MID 0010 Parameter set ID upload" )               { Tag = new OpenMessage( mID: 10, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0012 Parameter set data upload" )             { Tag = new OpenMessage( mID: 12, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0014 Parameter set selected subscribe" )      { Tag = new OpenMessage( mID: 14, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0017 Parameter set selected unsubscribe" )    { Tag = new OpenMessage( mID: 17, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node1.Nodes.Add( new TreeNode( "MID 0018 Select Parameter set" )                  { Tag = new OpenMessage( mID: 18, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000", "00" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0019 Set Parameter set batch size" )          { Tag = new OpenMessage( mID: 19, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000", "00" } ) } );
			node1.Nodes.Add( new TreeNode( "MID 0020 Reset Parameter set batch counter" )     { Tag = new OpenMessage( mID: 20, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "000" } ) } );
			treeView1.Nodes.Add( node1 );

			TreeNode node2 = new TreeNode( "Job message" );
			node2.Nodes.Add( new TreeNode( "MID 0030 Job ID upload" )        { Tag = new OpenMessage( mID: 30, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0032 Job data upload" )      { Tag = new OpenMessage( mID: 32, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0034 Job info subscribe" )   { Tag = new OpenMessage( mID: 34, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0037 Job info unsubscribe" ) { Tag = new OpenMessage( mID: 37, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node2.Nodes.Add( new TreeNode( "MID 0038 Select Job" )           { Tag = new OpenMessage( mID: 38, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "00" } ) } );
			node2.Nodes.Add( new TreeNode( "MID 0039 Job restart" )          { Tag = new OpenMessage( mID: 39, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "00" } ) } );
			treeView1.Nodes.Add( node2 );

			TreeNode node3 = new TreeNode( "Tool messages" );
			node3.Nodes.Add( new TreeNode( "MID 0040 Tool data upload" )      { Tag = new OpenMessage( mID: 40, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0042 Disable tool" )          { Tag = new OpenMessage( mID: 42, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0043 Enable tool" )           { Tag = new OpenMessage( mID: 43, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0044 Disconnect tool" )       { Tag = new OpenMessage( mID: 44, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node3.Nodes.Add( new TreeNode( "MID 0045 Set calibration value" ) { Tag = new OpenMessage( mID: 44, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "011", "02003550" } ) } );
			treeView1.Nodes.Add( node3 );


			TreeNode node4 = new TreeNode( "VIN Messages" );
			node4.Nodes.Add( new TreeNode( "MID 0050 Vehicle ID Number download" )   { Tag = new OpenMessage( mID: 50, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "0000000000000000000000000" } ) } );
			node4.Nodes.Add( new TreeNode( "MID 0051 Vehicle ID Number subscribe" )  { Tag = new OpenMessage( mID: 51, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node4.Nodes.Add( new TreeNode( "MID 0054 Vehicle ID Number unsubscrib" ) { Tag = new OpenMessage( mID: 54, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node4 );

			TreeNode node5 = new TreeNode( "Tightening result messages" );
			node5.Nodes.Add( new TreeNode( "MID 0060 Last tightening result data subscribe" )   { Tag = new OpenMessage( mID: 60, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node5.Nodes.Add( new TreeNode( "MID 0063 Last tightening result data unsubscribe" ) { Tag = new OpenMessage( mID: 63, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node5.Nodes.Add( new TreeNode( "MID 0064 Old tightening result upload" )            { Tag = new OpenMessage( mID: 64, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node5 );

			TreeNode node6 = new TreeNode( "Alarm messages" );
			node6.Nodes.Add( new TreeNode( "MID 0070 Alarm subscribe" )                          { Tag = new OpenMessage( mID: 70, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0073 Alarm unsubscribe" )                        { Tag = new OpenMessage( mID: 73, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node6.Nodes.Add( new TreeNode( "MID 0074 Alarm acknowledged on controller" )         { Tag = new OpenMessage( mID: 74, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "E406" } ) } );
			node6.Nodes.Add( new TreeNode( "MID 0076 Alarm status" )                             { Tag = new OpenMessage( mID: 76, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { "011", "02E404", "031", "041", "052024-07-03:17:08:12" } ) } );
			node6.Nodes.Add( new TreeNode( "MID 0078 Acknowledge alarm remotely on controller" ) { Tag = new OpenMessage( mID: 78, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			treeView1.Nodes.Add( node6 );

			TreeNode node7 = new TreeNode( "Time messages" );
			node7.Nodes.Add( new TreeNode( "MID 0080 Read time upload" ) { Tag = new OpenMessage( mID: 80, revision: 1, stationID: -1, spindleID: -1, dataField: null ) } );
			node7.Nodes.Add( new TreeNode( "MID 0082 Set Time" )         { Tag = new OpenMessage( mID: 82, revision: 1, stationID: -1, spindleID: -1, dataField: new List<string>( ) { DateTime.Now.ToString( "yyyy-MM-dd:HH:mm:ss" ) } ) } );
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
				OperateResult<string> read = openProtocol.ReadCustomer( int.Parse( textBox_mid.Text ),
					int.Parse( textBox_revision.Text ), int.Parse( textBox_stationID.Text ), int.Parse( textBox_spindleID.Text ), new List<string>( textBox_dataField.Lines ) );

				if (read.IsSuccess)
				{
					textBox_result.AppendText( DateTime.Now.ToString( ) + " : " + read.Content + Environment.NewLine );
				}
				else
				{
					MessageBox.Show( "Read Failed:" + read.Message );
				}
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}
	}
}
