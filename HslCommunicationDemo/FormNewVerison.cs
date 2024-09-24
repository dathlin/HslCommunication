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
	public partial class FormNewVerison : System.Windows.Forms.Form
	{
		public FormNewVerison( )
		{
			InitializeComponent( );
		}

		public DialogResult ShowDialog( string caption, string info )
		{
			this.Text            = caption;
			this.label1.Text     = info;
			return ShowDialog( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.Yes;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.No;
		}

		public bool NewVersionIngored => this.checkBox1.Checked;

		private void FormNewVerison_Load( object sender, EventArgs e )
		{

		}
	}
}
