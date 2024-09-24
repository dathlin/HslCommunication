using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormWeb
		: HslFormContent
	{
		public FormWeb( string url )
		{
			InitializeComponent( );
			this.url = url;
		}

		private void FormWeb_Load( object sender, EventArgs e )
		{

		}



		private string url =string.Empty;

		private void FormWeb_Shown( object sender, EventArgs e )
		{
			this.webBrowser1.Navigate(this.url);
		}
	}
}
