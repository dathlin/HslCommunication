using HslCommunication;
using HslCommunication.Profinet.Omron;
using HslCommunication.Profinet.Omron.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Omron
{
	public class FinsTcpControl : SpecialFeaturesControl
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.GroupBox groupBox2;

		public FinsTcpControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.button6);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(591, 226);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Fins Function";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(10, 57);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(221, 17);
			this.label5.TabIndex = 22;
			this.label5.Text = "Run Stop 请谨慎操作，确认安全为前提";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(277, 23);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 28);
			this.button6.TabIndex = 21;
			this.button6.Text = "Cpu Status";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(167, 23);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 28);
			this.button5.TabIndex = 20;
			this.button5.Text = "Cpu Data";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(88, 23);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(73, 28);
			this.button4.TabIndex = 19;
			this.button4.Text = "Stop";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 23);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(73, 28);
			this.button3.TabIndex = 18;
			this.button3.Text = "Run";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(9, 81);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(576, 139);
			this.textBox4.TabIndex = 17;
			// 
			// FinsTcpControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "FinsTcpControl";
			this.Size = new System.Drawing.Size(845, 232);
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		public void SetDevice( IOmronFins omron, string address )
		{
			this.omron = omron;
			base.SetDevice( omron, address );
		}

		private IOmronFins omron;

		private void button3_Click( object sender, EventArgs e )
		{
			// run
			OperateResult run = omron.Run( );
			if (run.IsSuccess)
				MessageBox.Show( "Run success" );
			else
				MessageBox.Show( "Run failed:" + run.Message );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// stop
			OperateResult stop = omron.Stop( );
			if (stop.IsSuccess)
				MessageBox.Show( "Run success" );
			else
				MessageBox.Show( "Run failed:" + stop.Message );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// read cpu data
			OperateResult<OmronCpuUnitData> read = omron.ReadCpuUnitData( );
			if (read.IsSuccess)
				textBox4.Text = read.Content.ToJsonString( );
			else
				MessageBox.Show( "read failed:" + read.Message );
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// read cpu status
			OperateResult<OmronCpuUnitStatus> read = omron.ReadCpuUnitStatus( );
			if (read.IsSuccess)
				textBox4.Text = read.Content.ToJsonString( );
			else
				MessageBox.Show( "read failed:" + read.Message );
		}
	}
}
