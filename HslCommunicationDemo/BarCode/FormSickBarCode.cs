using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Sick;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.BarCode
{
	public partial class FormSickBarCode : HslFormContent
	{
		public FormSickBarCode( )
		{
			InitializeComponent( );
		}

		private void FormSickBarCode_Load( object sender, EventArgs e )
		{
			button11.Enabled = false;
			timer = new Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );

			panel2.Enabled = false;
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if(tcpServer != null)
			{
				label15.Text = tcpServer.GetPipeSessions( ).Length.ToString( );
			}
		}

		private SickIcrTcpServer tcpServer;
		private Timer timer;

		private void Button1_Click( object sender, EventArgs e )
		{
			try
			{
				tcpServer = new SickIcrTcpServer( );
				tcpServer.LogNet = new LogNetSingle( "" );
				tcpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				tcpServer.ServerStart( int.Parse( textBox2.Text ), radioButton_tcp.Checked );
				tcpServer.OnReceivedBarCode += TcpServer_OnReceivedBarCode;
				button1.Enabled = false;
				button11.Enabled = true;
				panel2.Enabled = true;


				textBox_code.Text = SampleCode( );
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Start Failed: " + ex.Message );
			}
		}

		private string SampleCode()
		{
			return @"SickIcrTcpServer tcpServer = new SickIcrTcpServer( );
tcpServer.ServerStart( int.Parse( textBox2.Text ), radioButton_tcp.Checked );
tcpServer.OnReceivedBarCode += (string ipAddress, string barCode) => {
	Console.WriteLine( DateTime.Now.ToString( ""yyyy-MM-dd HH:mm:ss  ["" ) + ipAddress + ""] BarCode["" + barCode + ""]"" );
};";
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			{
				textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			} ) );
		}

		private void TcpServer_OnReceivedBarCode( string ipAddress, string barCode )
		{
			Invoke( new Action( ( ) =>
			 {
				 textBox1.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss  [") + ipAddress + "] BarCode[" + barCode + "]" + Environment.NewLine );
			 } ) );
		}

		private void Button11_Click( object sender, EventArgs e )
		{
			tcpServer?.ServerClose( );

			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void Button2_Click( object sender, EventArgs e )
		{
			try
			{
				System.Net.IPAddress.Parse( textBox3.Text );
				tcpServer.ConnectRemoteServer( textBox3.Text, int.Parse( textBox4.Text ) );
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Data Input wrong: " + HslCommunication.BasicFramework.SoftBasic.GetExceptionMessage( ex ) );
			}
		}

		private void label6_Click( object sender, EventArgs e )
		{

		}

		private void label16_Click( object sender, EventArgs e )
		{
			using (FormPipeSessionList form = new FormPipeSessionList( ))
			{
				form.SetPipeSessions( this.tcpServer );
				form.ShowDialog( );
			}
		}
	}
}
