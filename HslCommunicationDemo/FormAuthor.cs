using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormAuthor : System.Windows.Forms.Form
	{
		public FormAuthor( )
		{
			InitializeComponent( );
		}

		private void FormAuthor_Load( object sender, EventArgs e )
		{
			label2.Text = " 本软件著作权归属胡少林所有";
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				System.Diagnostics.Process.Start( linkLabel1.Text );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}
	}
}
