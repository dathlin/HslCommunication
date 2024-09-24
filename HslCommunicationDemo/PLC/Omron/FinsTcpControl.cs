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
	public class FinsTcpControl : UserControl
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox4;
		private Button button_cpu_time;
		private TextBox textBox_code;
		private Label label_code;

		public FinsTcpControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.button_cpu_time = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button_cpu_time
			// 
			this.button_cpu_time.Location = new System.Drawing.Point(390, 3);
			this.button_cpu_time.Name = "button_cpu_time";
			this.button_cpu_time.Size = new System.Drawing.Size(104, 28);
			this.button_cpu_time.TabIndex = 23;
			this.button_cpu_time.Text = "Cpu Time";
			this.button_cpu_time.UseVisualStyleBackColor = true;
			this.button_cpu_time.Click += new System.EventHandler(this.button_cpu_time_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(4, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(221, 17);
			this.label5.TabIndex = 22;
			this.label5.Text = "Run Stop 请谨慎操作，确认安全为前提";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(271, 3);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 28);
			this.button6.TabIndex = 21;
			this.button6.Text = "Cpu Status";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(161, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 28);
			this.button5.TabIndex = 20;
			this.button5.Text = "Cpu Data";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(82, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(73, 28);
			this.button4.TabIndex = 19;
			this.button4.Text = "Stop";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 3);
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
			this.textBox4.Location = new System.Drawing.Point(5, 61);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(577, 112);
			this.textBox4.TabIndex = 17;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(4, 180);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 24;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(62, 177);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(520, 55);
			this.textBox_code.TabIndex = 25;
			// 
			// FinsTcpControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button_cpu_time);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FinsTcpControl";
			this.Size = new System.Drawing.Size(585, 235);
			this.Load += new System.EventHandler(this.FinsTcpControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( IOmronFins omron, string address )
		{
			this.omron = omron;
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

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Run( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// stop
			OperateResult stop = omron.Stop( );
			if (stop.IsSuccess)
				MessageBox.Show( "Run success" );
			else
				MessageBox.Show( "Run failed:" + stop.Message );

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Stop( );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// read cpu data
			OperateResult<OmronCpuUnitData> read = omron.ReadCpuUnitData( );
			if (read.IsSuccess)
				textBox4.Text = read.Content.ToJsonString( );
			else
				MessageBox.Show( "read failed:" + read.Message );

			textBox_code.Text = $"OperateResult<OmronCpuUnitData> read = {DemoUtils.PlcDeviceName}.ReadCpuUnitData( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// read cpu status
			OperateResult<OmronCpuUnitStatus> read = omron.ReadCpuUnitStatus( );
			if (read.IsSuccess)
				textBox4.Text = read.Content.ToJsonString( );
			else
				MessageBox.Show( "read failed:" + read.Message );

			textBox_code.Text = $"OperateResult<OmronCpuUnitStatus> read = {DemoUtils.PlcDeviceName}.ReadCpuUnitStatus( );";
		}

		private void button_cpu_time_Click( object sender, EventArgs e )
		{
			// read cpu status
			OperateResult<DateTime> read = omron.ReadCpuTime( );
			if (read.IsSuccess)
				textBox4.Text = read.Content.ToString( );
			else
				MessageBox.Show( "read failed:" + read.Message );

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadCpuTime( );";
		}

		private void FinsTcpControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
