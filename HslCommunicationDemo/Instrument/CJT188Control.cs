using HslCommunication;
using HslCommunication.Instrument.CJT.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Instrument
{
	public class CJT188Control : UserControl
	{
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox12;
		private TextBox textBox_code;
		private Label label_code;
		private System.Windows.Forms.GroupBox groupBox1;

		public CJT188Control( )
		{
			InitializeComponent( );

			if (Program.Language == 2)
			{
				button3.Text = "Active";
			}
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox_code);
			this.groupBox1.Controls.Add(this.label_code);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.textBox12);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(883, 226);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "CJT188 Function";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(254, 51);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(151, 28);
			this.button7.TabIndex = 26;
			this.button7.Text = "读取原始字符串";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Enabled = false;
			this.button6.Location = new System.Drawing.Point(212, 18);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(81, 28);
			this.button6.TabIndex = 25;
			this.button6.Text = "广播时间";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(411, 51);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(106, 28);
			this.button5.TabIndex = 24;
			this.button5.Text = "写入通信地址";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(60, 54);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(188, 23);
			this.textBox1.TabIndex = 23;
			this.textBox1.Text = "90-1F";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 22;
			this.label2.Text = "地址：";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(111, 18);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(95, 28);
			this.button4.TabIndex = 21;
			this.button4.Text = "读取通信地址";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 18);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 28);
			this.button3.TabIndex = 20;
			this.button3.Text = "唤醒接收";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(9, 84);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(868, 90);
			this.textBox12.TabIndex = 19;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(6, 182);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 27;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(56, 180);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(821, 40);
			this.textBox_code.TabIndex = 28;
			// 
			// CJT188Control
			// 
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "CJT188Control";
			this.Size = new System.Drawing.Size(889, 232);
			this.Load += new System.EventHandler(this.CJT188Control_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		public void SetDevice( ICjt188 cjt188, string address )
		{
			this.cjt188 = cjt188;
		}

		private ICjt188 cjt188;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult active = cjt188.ActiveDeveice( );
			if (active.IsSuccess)
			{
				MessageBox.Show( "Send Active Code Success" );
			}
			else
			{
				MessageBox.Show( "Active Code failed:" + active.Message );
			}

			textBox_code.Text = "OperateResult active = cjt.ActiveDeveice( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = cjt188.ReadAddress( );
			if (read.IsSuccess)
			{
				//textBox12.Text = read.Content;
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Address:{read.Content}";
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = "OperateResult<string> read = cjt.ReadAddress( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{

		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 写通信地址
			OperateResult read = cjt188.WriteAddress( textBox1.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Write Success";
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult write = cjt.WriteAddress( \"{textBox1.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = cjt188.ReadStringArray( textBox1.Text );
			if (read.IsSuccess)
			{
				textBox12.Text = $"[{DateTime.Now:HH:mm:ss}] Read Result: {Environment.NewLine}";
				foreach (string item in read.Content)
				{
					textBox12.AppendText( item );
					textBox12.AppendText( Environment.NewLine );
				}
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string[]> read = cjt.ReadStringArray( \"{textBox1.Text}\" );";
		}

		private void CJT188Control_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}

	}
}
