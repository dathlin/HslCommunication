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
	public partial class FormExpressionExample : Form
	{
		public FormExpressionExample( )
		{
			InitializeComponent( );
		}

		private void FormExpressionExample_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "The variable x represents an integer incremented from 0 and can be used as a variable. \r\nHere are some examples of its expressions:";
				label2.Text = "Square wave:";
				label3.Text = "Linear func:";
				label4.Text = "Trigo func:";
				label5.Text = "Random func:";
				label6.Text = "Trigo jitter:";
			}
		}
	}
}
