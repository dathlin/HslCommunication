using HslCommunication.Core.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormPipeSessionList : System.Windows.Forms.Form
	{
		public FormPipeSessionList( )
		{
			InitializeComponent( );

			Shown += FormPipeSessionList_Shown;

			timer = new Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );
		}

		private void FormPipeSessionList_Shown( object sender, EventArgs e )
		{
			show = true;
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if (this.server != null && show)
			{
				try
				{
					this.pipeSessionListControl1.SetPipeSessions( this.server.GetPipeSessions( ) );
				}
				catch
				{

				}
			}
		}

		public void SetPipeSessions( PipeSession[] sessions )
		{
			this.pipeSessionListControl1.SetPipeSessions( sessions );
		}

		public void SetPipeSessions( CommunicationServer server )
		{
			this.server = server;
			this.pipeSessionListControl1.SetPipeSessions( this.server.GetPipeSessions( ) );
		}

		private bool show = false;
		private CommunicationServer server;
		private System.Windows.Forms.Timer timer;
	}
}
