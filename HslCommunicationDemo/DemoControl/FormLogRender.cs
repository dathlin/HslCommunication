using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.LogNet;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormLogRender : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormLogRender( ILogNet logNet )
		{
			InitializeComponent( );
			this.logNet = logNet;
		}

		private void FormLogRender_Load( object sender, EventArgs e )
		{
			this.logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;


		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				{
					textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				} ) );
			}
			catch
			{
				
			}
		}

		protected override void OnClosing( CancelEventArgs e )
		{
			base.OnClosing( e );

			this.logNet.BeforeSaveToFile -= LogNet_BeforeSaveToFile;
		}


		private ILogNet logNet = null;
	}
}
