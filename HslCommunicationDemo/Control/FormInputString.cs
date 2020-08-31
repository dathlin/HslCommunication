using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Control
{
	public partial class FormInputString : Form
	{
		public FormInputString( )
		{
			InitializeComponent( );
		}

		private void FormInputString_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Please enter a string";
				label1.Text= "Please enter the alias information. If \":\" is entered in the middle, it will be used as the category separator";
				button1.Text = "ok";
			}
		}

		public string DeviceAlias { get; set; }

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox1.Text ))
			{
				MessageBox.Show( "Value can not be null" );
				return;
			}

			DeviceAlias = textBox1.Text;
			DialogResult = DialogResult.OK;
		}
	}
}
