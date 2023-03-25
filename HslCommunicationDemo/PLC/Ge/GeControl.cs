using HslCommunication;
using HslCommunication.Profinet.GE;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Ge
{
	public class GeControl : SpecialFeaturesControl
	{
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox1;

		public GeControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.textBox14);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Location = new System.Drawing.Point(251, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(608, 226);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ge Function";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(97, 22);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(102, 28);
			this.button4.TabIndex = 27;
			this.button4.Text = "程序名";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.Location = new System.Drawing.Point(6, 56);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox14.Size = new System.Drawing.Size(596, 164);
			this.textBox14.TabIndex = 26;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 22);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(85, 28);
			this.button3.TabIndex = 25;
			this.button3.Text = "PLC时间";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// GeControl
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "GeControl";
			this.Size = new System.Drawing.Size(862, 232);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		public void SetDevice( GeSRTPNet ge, string address )
		{
			this.ge = ge;
			base.SetDevice( ge, address );
		}

		private GeSRTPNet ge;

		private void button3_Click( object sender, EventArgs e )
		{
			// 读取PLC的时间
			OperateResult<DateTime> read = ge.ReadPLCTime( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.ToMessageShowString( ) );
			}
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			// 读取PLC的程序名
			OperateResult<string> read = await ge.ReadProgramNameAsync( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.ToMessageShowString( ) );
			}
		}
	}
}
