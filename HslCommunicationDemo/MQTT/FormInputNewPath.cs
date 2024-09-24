using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.MQTT
{
	public partial class FormInputNewPath : System.Windows.Forms.Form
	{
		public FormInputNewPath( string oldPath, string newPath )
		{
			InitializeComponent( );

			textBox_path_old.Text = oldPath;
			textBox_path_new.Text = newPath;

			textBox_path_old.ReadOnly = true;
		}

		private void FormInputNewPath_Load( object sender, EventArgs e )
		{

		}

		public string PathInput { get; set; }

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox_path_new.Text ))
			{
				MessageBox.Show( "path can not be empty" );
				return;
			}
			PathInput = textBox_path_new.Text;
			DialogResult = DialogResult.OK;
		}
	}
}
