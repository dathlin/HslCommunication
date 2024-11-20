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
	public partial class FormMessageShow : Form
	{
		public FormMessageShow( string message )
		{
			InitializeComponent( );
			SizeChanged += FormMessageShow_SizeChanged;

			this.label1.Text = message;
			Graphics g = label1.CreateGraphics( );
			g.PageUnit = GraphicsUnit.Pixel;
			SizeF size = g.MeasureString( message, this.Font, label1.Width );
			if (size.Height > this.Height - 90 - 20)
			{
				size = g.MeasureString( message, this.Font, label1.Width + 300 );
				if (size.Height > 140)
				{
					this.Size = new Size( this.Width + 300, (int)size.Height + 120 );
				}
				else
				{
					this.Size = new Size( this.Width + 300, this.Height );
				}
			}
			else if (size.Width < 200 && size.Height < 30)
			{
				this.Size = new Size( 240, 160 );
			}
		}

		private void FormMessageShow_SizeChanged( object sender, EventArgs e )
		{
			button1.Location = new Point( this.Width / 2 - button1.Width / 2, this.Height - 80 );
		}

		private void FormMessageShow_Load( object sender, EventArgs e )
		{
		}



		private void button1_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
		}


		public static DialogResult ShowMessage( string message )
		{
			using(FormMessageShow form = new FormMessageShow( message ) )
			{
				return form.ShowDialog( );
			}
		}

	}
}
