using HslCommunication;
using HslCommunication.Profinet.Keyence;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Keyence
{
	public class NanoControl : SpecialFeaturesControl
	{
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private TextBox textBox10;
		private Label label13;
		private System.Windows.Forms.TextBox textBox6;
		private Label label1;
		private System.Windows.Forms.GroupBox groupBox1;

		public NanoControl( )
		{
			InitializeComponent( );
			if(Program.Language == 2)
			{
				label1.Text = "Address:";
				label13.Text = "Result:";
				button4.Text = "Annotation";
			}
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox10);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Location = new System.Drawing.Point(251, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(528, 226);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nano";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(361, 19);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 28);
			this.button4.TabIndex = 14;
			this.button4.Text = "注释";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(439, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 28);
			this.button3.TabIndex = 13;
			this.button3.Text = "plc-type";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(60, 52);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(462, 168);
			this.textBox10.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 15;
			this.label13.Text = "结果：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 17;
			this.label1.Text = "地址：";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(60, 22);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(295, 23);
			this.textBox6.TabIndex = 18;
			this.textBox6.Text = "D100";
			// 
			// NanoControl
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "NanoControl";
			this.Size = new System.Drawing.Size(782, 232);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}


		public void SetDevice( KeyenceNanoSerial keyence, string address )
		{
			this.keyence = keyence;
			base.SetDevice( keyence, address );
		}

		private KeyenceNanoSerial keyence;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<KeyencePLCS> read = keyence.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox10.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = keyence.ReadAddressAnnotation( textBox6.Text );
			if (read.IsSuccess)
			{
				textBox10.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed:" + read.ToMessageShowString( ) );
			}
		}
	}
}
