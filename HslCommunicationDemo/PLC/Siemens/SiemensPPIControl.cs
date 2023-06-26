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
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox2;

		public SiemensPPIControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(749, 255);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Siemens PPI";
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(548, 25);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(82, 28);
			this.button5.TabIndex = 20;
			this.button5.Text = "PLC Type";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(109, 25);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 28);
			this.button4.TabIndex = 22;
			this.button4.Text = "Stop";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(21, 25);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 21;
			this.button3.Text = "Start";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// SiemensPPIControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "SiemensPPIControl";
			this.Size = new System.Drawing.Size(755, 261);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

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
		}

		private ISiemensPPI siemensPPI;

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult stop = siemensPPI.Stop( );
			if (stop.IsSuccess) MessageBox.Show( "Stop Success!" );
			else MessageBox.Show( stop.Message );
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
		}
	}
}
