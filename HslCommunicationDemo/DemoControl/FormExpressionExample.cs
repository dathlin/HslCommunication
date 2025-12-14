using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

			fileName = Path.Combine( Application.StartupPath, "ExpressionExample.txt" );
			pictureBox1.Click += PictureBox1_Click;
			pictureBox2.Click += PictureBox2_Click;
			pictureBox3.Click += PictureBox3_Click;
			pictureBox4.Click += PictureBox4_Click;
			pictureBox5.Click += PictureBox5_Click;
			pictureBox6.Click += PictureBox6_Click;
			pictureBox7.Click += PictureBox7_Click;
			pictureBox8.Click += PictureBox8_Click;
			pictureBox9.Click += PictureBox9_Click;
			pictureBox10.Click += PictureBox10_Click;
		}

		private void PictureBox10_Click( object sender, EventArgs e )
		{
			SetClipText( textBox6 );
		}

		private void PictureBox9_Click( object sender, EventArgs e )
		{
			SetClipText( textBox_example4 );
		}
		private void PictureBox8_Click( object sender, EventArgs e )
		{
			SetClipText( textBox_example3 );
		}
		private void PictureBox7_Click( object sender, EventArgs e )
		{
			SetClipText( textBox_example2 );
		}
		private void PictureBox6_Click( object sender, EventArgs e )
		{
			SetClipText( textBox_example1 );
		}
		private void PictureBox5_Click( object sender, EventArgs e )
		{
			SetClipText( textBox5 );
		}
		private void PictureBox4_Click( object sender, EventArgs e )
		{
			SetClipText( textBox4 );
		}
		private void PictureBox3_Click( object sender, EventArgs e )
		{
			SetClipText( textBox3 );
		}
		private void PictureBox2_Click( object sender, EventArgs e )
		{
			SetClipText( textBox2 );
		}
		private void PictureBox1_Click( object sender, EventArgs e )
		{
			SetClipText( textBox1 );
		}

		private void SetClipText( TextBox textBox )
		{
			try
			{
				Clipboard.SetText( textBox.Text );
				DialogResult = DialogResult.OK;
			}
			catch
			{
				DemoUtils.ShowMessage( "Copy Failed!" );
			}
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
				label7.Text = "Barcode func:";

				button1.Text = "Save";
			}


			if (File.Exists( fileName ))
			{
				try
				{
					string[] lines = File.ReadAllLines( fileName, Encoding.UTF8 );
					if (lines.Length >= 8)
					{
						textBox_head1.Text = lines[0];
						textBox_example1.Text = lines[1];
						textBox_head2.Text = lines[2];
						textBox_example2.Text = lines[3];
						textBox_head3.Text = lines[4];
						textBox_example3.Text = lines[5];
						textBox_head4.Text = lines[6];
						textBox_example4.Text = lines[7];
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show( "Load ExpressionExample failed: " + ex.Message );
				}
			}
		}

		private string fileName = "";
		private void button1_Click( object sender, EventArgs e )
		{
			// 保存自定义的到本地
			StringBuilder stringBuilder = new StringBuilder( );
			stringBuilder.AppendLine( textBox_head1.Text );
			stringBuilder.AppendLine( textBox_example1.Text );
			stringBuilder.AppendLine( textBox_head2.Text );
			stringBuilder.AppendLine( textBox_example2.Text );
			stringBuilder.AppendLine( textBox_head3.Text );
			stringBuilder.AppendLine( textBox_example3.Text );
			stringBuilder.AppendLine( textBox_head4.Text );
			stringBuilder.AppendLine( textBox_example4.Text );

			try
			{
				File.WriteAllText( fileName, stringBuilder.ToString( ), Encoding.UTF8 );
				DemoUtils.ShowMessage( "Save Success!" );
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
				return;
			}
		}
	}
}
