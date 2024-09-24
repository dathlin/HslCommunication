using HslCommunication;
using HslCommunication.Profinet.Siemens.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Siemens
{
	public class SiemensPPIControl :  UserControl
	{
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Button button3;

		public SiemensPPIControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(192, 9);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(82, 28);
			this.button5.TabIndex = 20;
			this.button5.Text = "PLC Type";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(91, 9);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 28);
			this.button4.TabIndex = 22;
			this.button4.Text = "Stop";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 9);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 21;
			this.button3.Text = "Start";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 121);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 23;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(53, 118);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(699, 54);
			this.textBox_code.TabIndex = 24;
			// 
			// SiemensPPIControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "SiemensPPIControl";
			this.Size = new System.Drawing.Size(755, 175);
			this.Load += new System.EventHandler(this.SiemensPPIControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( ISiemensPPI siemensPPI, string address )
		{
			this.siemensPPI = siemensPPI;
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult start = siemensPPI.Start( );
			if (start.IsSuccess) MessageBox.Show( "Start Success!" );
			else MessageBox.Show( start.Message );

			textBox_code.Text = $"OperateResult start = {DemoUtils.PlcDeviceName}.Start( );";
		}

		private ISiemensPPI siemensPPI;

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult stop = siemensPPI.Stop( );
			if (stop.IsSuccess) MessageBox.Show( "Stop Success!" );
			else MessageBox.Show( stop.Message );

			textBox_code.Text = $"OperateResult stop = {DemoUtils.PlcDeviceName}.Stop( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = siemensPPI.ReadPlcType( );
			if (read.IsSuccess)
			{
				MessageBox.Show("Plc type: " + read.Content);
			}
			else
			{
				MessageBox.Show( read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";
		}

		private void SiemensPPIControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
