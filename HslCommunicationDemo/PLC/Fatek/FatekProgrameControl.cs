using HslCommunication;
using HslCommunication.Profinet.FATEK.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Fatek
{
	public class FatekProgrameControl : UserControl
	{
		private System.Windows.Forms.Label label_bit6_false;
		private System.Windows.Forms.Label label_bit6_true;
		private System.Windows.Forms.Label label_bit5_false;
		private System.Windows.Forms.Label label_bit5_true;
		private System.Windows.Forms.Label label_bit4_false;
		private System.Windows.Forms.Label label_bit4_true;
		private System.Windows.Forms.Label label_bit3_false;
		private System.Windows.Forms.Label label_bit3_true;
		private System.Windows.Forms.Label label_bit2_false;
		private System.Windows.Forms.Label label_bit2_true;
		private System.Windows.Forms.Label label_bit1_false;
		private System.Windows.Forms.Label label_bit1_true;
		private System.Windows.Forms.Label label_bit0_false;
		private System.Windows.Forms.Label label_bit0_true;
		private System.Windows.Forms.Button button_read_status;
		private System.Windows.Forms.Button button_stop;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Button button_run;

		public FatekProgrameControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.label_bit6_false = new System.Windows.Forms.Label();
			this.label_bit6_true = new System.Windows.Forms.Label();
			this.label_bit5_false = new System.Windows.Forms.Label();
			this.label_bit5_true = new System.Windows.Forms.Label();
			this.label_bit4_false = new System.Windows.Forms.Label();
			this.label_bit4_true = new System.Windows.Forms.Label();
			this.label_bit3_false = new System.Windows.Forms.Label();
			this.label_bit3_true = new System.Windows.Forms.Label();
			this.label_bit2_false = new System.Windows.Forms.Label();
			this.label_bit2_true = new System.Windows.Forms.Label();
			this.label_bit1_false = new System.Windows.Forms.Label();
			this.label_bit1_true = new System.Windows.Forms.Label();
			this.label_bit0_false = new System.Windows.Forms.Label();
			this.label_bit0_true = new System.Windows.Forms.Label();
			this.button_read_status = new System.Windows.Forms.Button();
			this.button_stop = new System.Windows.Forms.Button();
			this.button_run = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label_bit6_false
			// 
			this.label_bit6_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit6_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit6_false.Location = new System.Drawing.Point(709, 62);
			this.label_bit6_false.Name = "label_bit6_false";
			this.label_bit6_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit6_false.TabIndex = 42;
			this.label_bit6_false.Text = "Normal";
			this.label_bit6_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit6_true
			// 
			this.label_bit6_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit6_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit6_true.Location = new System.Drawing.Point(539, 62);
			this.label_bit6_true.Name = "label_bit6_true";
			this.label_bit6_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit6_true.TabIndex = 41;
			this.label_bit6_true.Text = "Emergency stop";
			this.label_bit6_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit5_false
			// 
			this.label_bit5_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit5_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit5_false.Location = new System.Drawing.Point(709, 32);
			this.label_bit5_false.Name = "label_bit5_false";
			this.label_bit5_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit5_false.TabIndex = 40;
			this.label_bit5_false.Text = "Not Set ID";
			this.label_bit5_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit5_true
			// 
			this.label_bit5_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit5_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit5_true.Location = new System.Drawing.Point(539, 32);
			this.label_bit5_true.Name = "label_bit5_true";
			this.label_bit5_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit5_true.TabIndex = 39;
			this.label_bit5_true.Text = "Set ID";
			this.label_bit5_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit4_false
			// 
			this.label_bit4_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit4_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit4_false.Location = new System.Drawing.Point(709, 3);
			this.label_bit4_false.Name = "label_bit4_false";
			this.label_bit4_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit4_false.TabIndex = 38;
			this.label_bit4_false.Text = "Normal";
			this.label_bit4_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit4_true
			// 
			this.label_bit4_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit4_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit4_true.Location = new System.Drawing.Point(539, 3);
			this.label_bit4_true.Name = "label_bit4_true";
			this.label_bit4_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit4_true.TabIndex = 37;
			this.label_bit4_true.Text = "WDT Timeout";
			this.label_bit4_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit3_false
			// 
			this.label_bit3_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit3_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit3_false.Location = new System.Drawing.Point(366, 86);
			this.label_bit3_false.Name = "label_bit3_false";
			this.label_bit3_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit3_false.TabIndex = 36;
			this.label_bit3_false.Text = "Not used";
			this.label_bit3_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit3_true
			// 
			this.label_bit3_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit3_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit3_true.Location = new System.Drawing.Point(196, 86);
			this.label_bit3_true.Name = "label_bit3_true";
			this.label_bit3_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit3_true.TabIndex = 35;
			this.label_bit3_true.Text = "Use ROM Pack";
			this.label_bit3_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit2_false
			// 
			this.label_bit2_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit2_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit2_false.Location = new System.Drawing.Point(366, 58);
			this.label_bit2_false.Name = "label_bit2_false";
			this.label_bit2_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit2_false.TabIndex = 34;
			this.label_bit2_false.Text = "Normal";
			this.label_bit2_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit2_true
			// 
			this.label_bit2_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit2_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit2_true.Location = new System.Drawing.Point(196, 58);
			this.label_bit2_true.Name = "label_bit2_true";
			this.label_bit2_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit2_true.TabIndex = 33;
			this.label_bit2_true.Text = "Ladder checksum error";
			this.label_bit2_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit1_false
			// 
			this.label_bit1_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit1_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit1_false.Location = new System.Drawing.Point(366, 30);
			this.label_bit1_false.Name = "label_bit1_false";
			this.label_bit1_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit1_false.TabIndex = 32;
			this.label_bit1_false.Text = "Normal";
			this.label_bit1_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit1_true
			// 
			this.label_bit1_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit1_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit1_true.Location = new System.Drawing.Point(196, 30);
			this.label_bit1_true.Name = "label_bit1_true";
			this.label_bit1_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit1_true.TabIndex = 31;
			this.label_bit1_true.Text = "BAT LOW";
			this.label_bit1_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit0_false
			// 
			this.label_bit0_false.BackColor = System.Drawing.Color.Silver;
			this.label_bit0_false.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit0_false.Location = new System.Drawing.Point(366, 3);
			this.label_bit0_false.Name = "label_bit0_false";
			this.label_bit0_false.Size = new System.Drawing.Size(150, 20);
			this.label_bit0_false.TabIndex = 30;
			this.label_bit0_false.Text = "STOP";
			this.label_bit0_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_bit0_true
			// 
			this.label_bit0_true.BackColor = System.Drawing.Color.Silver;
			this.label_bit0_true.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_bit0_true.Location = new System.Drawing.Point(196, 3);
			this.label_bit0_true.Name = "label_bit0_true";
			this.label_bit0_true.Size = new System.Drawing.Size(150, 20);
			this.label_bit0_true.TabIndex = 29;
			this.label_bit0_true.Text = "RUN";
			this.label_bit0_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button_read_status
			// 
			this.button_read_status.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button_read_status.Location = new System.Drawing.Point(6, 38);
			this.button_read_status.Name = "button_read_status";
			this.button_read_status.Size = new System.Drawing.Size(82, 28);
			this.button_read_status.TabIndex = 28;
			this.button_read_status.Text = "Status";
			this.button_read_status.UseVisualStyleBackColor = true;
			this.button_read_status.Click += new System.EventHandler(this.button_read_status_Click);
			// 
			// button_stop
			// 
			this.button_stop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button_stop.Location = new System.Drawing.Point(94, 6);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(82, 28);
			this.button_stop.TabIndex = 27;
			this.button_stop.Text = "Stop";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
			// 
			// button_run
			// 
			this.button_run.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button_run.Location = new System.Drawing.Point(6, 6);
			this.button_run.Name = "button_run";
			this.button_run.Size = new System.Drawing.Size(82, 28);
			this.button_run.TabIndex = 26;
			this.button_run.Text = "Run";
			this.button_run.UseVisualStyleBackColor = true;
			this.button_run.Click += new System.EventHandler(this.button_run_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 155);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 43;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(53, 152);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(840, 62);
			this.textBox_code.TabIndex = 44;
			// 
			// FatekProgrameControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.label_bit6_false);
			this.Controls.Add(this.label_bit6_true);
			this.Controls.Add(this.button_read_status);
			this.Controls.Add(this.label_bit5_false);
			this.Controls.Add(this.button_run);
			this.Controls.Add(this.label_bit5_true);
			this.Controls.Add(this.button_stop);
			this.Controls.Add(this.label_bit4_false);
			this.Controls.Add(this.label_bit0_true);
			this.Controls.Add(this.label_bit4_true);
			this.Controls.Add(this.label_bit0_false);
			this.Controls.Add(this.label_bit3_false);
			this.Controls.Add(this.label_bit1_true);
			this.Controls.Add(this.label_bit3_true);
			this.Controls.Add(this.label_bit1_false);
			this.Controls.Add(this.label_bit2_false);
			this.Controls.Add(this.label_bit2_true);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FatekProgrameControl";
			this.Size = new System.Drawing.Size(896, 217);
			this.Load += new System.EventHandler(this.FatekProgrameControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( IFatekProgram fatekProgram, string address )
		{
			this.fatekProgram = fatekProgram;
		}


		private IFatekProgram fatekProgram;

		private void button_run_Click( object sender, EventArgs e )
		{
			OperateResult run = fatekProgram.Run( );
			if (run.IsSuccess)
			{
				MessageBox.Show( "Run Success!" );
			}
			else
			{
				MessageBox.Show( "Run failed: " + run.Message );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Run( );";
		}

		private void button_stop_Click( object sender, EventArgs e )
		{
			OperateResult stop = fatekProgram.Stop( );
			if (stop.IsSuccess)
			{
				MessageBox.Show( "Stop Success!" );
			}
			else
			{
				MessageBox.Show( "Stop failed: " + stop.Message );
			}
			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Stop( );";
		}

		private void button_read_status_Click( object sender, EventArgs e )
		{
			OperateResult<bool[]> read = fatekProgram.ReadStatus( );
			if (read.IsSuccess)
			{
				SetColorFromStatus( read.Content[0], label_bit0_true, label_bit0_false );
				SetColorFromStatus( read.Content[1], label_bit1_true, label_bit1_false );
				SetColorFromStatus( read.Content[2], label_bit2_true, label_bit2_false );
				SetColorFromStatus( read.Content[3], label_bit3_true, label_bit3_false );
				SetColorFromStatus( read.Content[4], label_bit4_true, label_bit4_false );
				SetColorFromStatus( read.Content[5], label_bit5_true, label_bit5_false );
				SetColorFromStatus( read.Content[6], label_bit6_true, label_bit6_false );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<bool[]> read = {DemoUtils.PlcDeviceName}.ReadStatus( );  // 共计返回7个bool";
		}
		public static void SetColorFromStatus( bool status, Label labelTrue, Label labelFalse )
		{
			if (status)
			{
				labelTrue.BackColor = Color.Tomato;
				labelFalse.BackColor = Color.Silver;
			}
			else
			{
				labelFalse.BackColor = Color.Tomato;
				labelTrue.BackColor = Color.Silver;
			}
		}

		private void FatekProgrameControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
