using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslRedisDesktop
{
	public partial class FormInputString : Form
	{
		public FormInputString( )
		{
			InitializeComponent( );
		}

		public string TextInfo
		{
			get => label1.Text;
			set => label1.Text = value;
		}

		public string InputValue 
		{
			get => textBox1.Text;
			set => textBox1.Text = value;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
		}

        private void FormInputString_Load( object sender, EventArgs e )
        {

        }
    }
}
