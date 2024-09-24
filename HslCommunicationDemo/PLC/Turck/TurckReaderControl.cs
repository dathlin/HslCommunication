using HslCommunication;
using HslCommunication.Profinet.Turck;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Turck
{
	public class TurckReaderControl : UserControl
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.GroupBox groupBox2;

		public TurckReaderControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox3);
			this.groupBox2.Controls.Add(this.button7);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(933, 226);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Turck Reader Function";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 17);
			this.label5.TabIndex = 34;
			this.label5.Text = "NumberOfBloack:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 17);
			this.label6.TabIndex = 33;
			this.label6.Text = "BytesOfBloack:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 17);
			this.label7.TabIndex = 32;
			this.label7.Text = "UID:";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(9, 95);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(918, 125);
			this.textBox3.TabIndex = 31;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(296, 20);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(101, 34);
			this.button7.TabIndex = 30;
			this.button7.Text = "Read 载码体";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// TurckReaderControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "TurckReaderControl";
			this.Size = new System.Drawing.Size(939, 232);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		public void SetDevice( ReaderNet reader_net, string address )
		{
			this.reader_net = reader_net;
		}

		private ReaderNet reader_net;

		private void button7_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = reader_net.ReadRFIDInfo( );
			if (read.IsSuccess)
			{
				label7.Text = "UID: " + reader_net.UID;
				label6.Text = "BytesOfBlock: " + reader_net.BytesOfBlock;
				label5.Text = "NumberOfBlock: " + reader_net.NumberOfBlock;

				textBox3.Text = $"OperateResult<string> read = reader_net.ReadRFIDInfo( );";
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.Message );
			}
		}
	}
}
