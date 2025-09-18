using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Enthernet.Tcp;
using HslCommunication.Core.Net;
using HslCommunication.LogNet;

namespace HslCommunicationDemo.DemoControl
{
	public partial class DebugRemoteControl : UserControl
	{
		public DebugRemoteControl( )
		{
			InitializeComponent( );

			button2.Enabled = false;
		}

		private void DebugRemoteControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				label2.Text = "Onlines:";
				label4.Text = "(The client uses the Debug pipe to connect to this port)";
			}
		}

		/// <summary>
		/// 设置通信对象
		/// </summary>
		/// <param name="communication">设备通信对象</param>
		public void SetCommunication( BinaryCommunication communication )
		{
			this.communication = communication;
			if (this.communication == null)
			{
				button1.Enabled = false;
			}
		}


		private DebugRemoteServer server;
		private BinaryCommunication communication;

		private void button1_Click( object sender, EventArgs e )
		{
			// 启动服务
			if (!int.TryParse( textBox1.Text, out int port ))
			{
				DemoUtils.ShowMessage( "Port input wrong!" );
				return;
			}
			try
			{
				server = new DebugRemoteServer( );
				server.LogNet = new LogNetSingle( "" );
				server.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				server.GetCommunicationServer( ).OnClientOnline += DebugRemoteControl_OnClientOnline;
				server.GetCommunicationServer( ).OnClientOffline += DebugRemoteControl_OnClientOnline;
				server.SetDeviceCommunication( communication );
				server.ServerStart( port );
				button1.Enabled = false;
				button2.Enabled = true;
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
				return;
			}

		}

		private void DebugRemoteControl_OnClientOnline( object server, PipeSession session )
		{
			try
			{
				if (this.IsDisposed == false) Invoke( new Action( ( ) =>
				{
					listBox1.DataSource = this.server.GetCommunicationServer( ).GetPipeSessions( );
				} ) );
			}
			catch
			{

			}
		}
		

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				if (this.IsDisposed == false) Invoke( new Action( ( ) =>
				{
					textBox2.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				} ) );
			}
			catch
			{

			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			server.ServerClose( );
			button1.Enabled = true;
			button2.Enabled = false;
		}

		public void Close( )
		{
			if (button2.Enabled == true)
			{
				button2_Click( null, new EventArgs( ) );
			}
		}

		private void label3_Click( object sender, EventArgs e )
		{
			FormMain.OpenWebside( "http://www.hsltechnology.cn/Doc/HslCommunication?chapter=HslCommChapter7-9" );
		}
	}
}
