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
	public class GeControl : UserControl
	{
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox14;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Button button3;

		public GeControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button4 = new System.Windows.Forms.Button();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(94, 3);
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
			this.textBox14.Location = new System.Drawing.Point(3, 37);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox14.Size = new System.Drawing.Size(856, 139);
			this.textBox14.TabIndex = 26;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(85, 28);
			this.button3.TabIndex = 25;
			this.button3.Text = "PLC时间";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 179);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(35, 17);
			this.label_code.TabIndex = 28;
			this.label_code.Text = "代码:";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(56, 180);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(803, 50);
			this.textBox_code.TabIndex = 29;
			// 
			// GeControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox14);
			this.Controls.Add(this.button3);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "GeControl";
			this.Size = new System.Drawing.Size(862, 232);
			this.Load += new System.EventHandler(this.GeControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( GeSRTPNet ge, string address )
		{
			this.ge = ge;
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

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadPLCTime( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 读取PLC的程序名
			OperateResult<string> read = ge.ReadProgramName( );
			if (read.IsSuccess)
			{
				textBox14.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadProgramName( );";
		}

		private void GeControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
