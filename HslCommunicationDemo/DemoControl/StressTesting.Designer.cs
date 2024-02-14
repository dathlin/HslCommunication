namespace HslCommunicationDemo.PLC.Common
{
	partial class StressTesting
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent( )
		{
			this.groupBox_press = new System.Windows.Forms.GroupBox();
			this.checkBox_continue_when_error = new System.Windows.Forms.CheckBox();
			this.checkBox_check_same = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.checkBox_write = new System.Windows.Forms.CheckBox();
			this.checkBox_read = new System.Windows.Forms.CheckBox();
			this.button_test_start = new System.Windows.Forms.Button();
			this.textBox_test_address = new System.Windows.Forms.TextBox();
			this.label_pressure_address = new System.Windows.Forms.Label();
			this.textBox_repreat_times = new System.Windows.Forms.TextBox();
			this.label_repeat_times = new System.Windows.Forms.Label();
			this.textBox_thread_count = new System.Windows.Forms.TextBox();
			this.label_thread_count = new System.Windows.Forms.Label();
			this.label_pressure_progress = new System.Windows.Forms.Label();
			this.hslProgressBar1 = new HslControls.HslProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label_info = new System.Windows.Forms.Label();
			this.textBox_check_wrong = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_failed_count = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_check_same = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_avg_time = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_total_time = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_total_count = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_press.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_press
			// 
			this.groupBox_press.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox_press.Controls.Add(this.checkBox_continue_when_error);
			this.groupBox_press.Controls.Add(this.checkBox_check_same);
			this.groupBox_press.Controls.Add(this.label3);
			this.groupBox_press.Controls.Add(this.textBox3);
			this.groupBox_press.Controls.Add(this.checkBox_write);
			this.groupBox_press.Controls.Add(this.checkBox_read);
			this.groupBox_press.Controls.Add(this.button_test_start);
			this.groupBox_press.Controls.Add(this.textBox_test_address);
			this.groupBox_press.Controls.Add(this.label_pressure_address);
			this.groupBox_press.Controls.Add(this.textBox_repreat_times);
			this.groupBox_press.Controls.Add(this.label_repeat_times);
			this.groupBox_press.Controls.Add(this.textBox_thread_count);
			this.groupBox_press.Controls.Add(this.label_thread_count);
			this.groupBox_press.Location = new System.Drawing.Point(3, 3);
			this.groupBox_press.Name = "groupBox_press";
			this.groupBox_press.Size = new System.Drawing.Size(401, 280);
			this.groupBox_press.TabIndex = 0;
			this.groupBox_press.TabStop = false;
			this.groupBox_press.Text = "Thread Settings";
			// 
			// checkBox_continue_when_error
			// 
			this.checkBox_continue_when_error.AutoSize = true;
			this.checkBox_continue_when_error.Checked = true;
			this.checkBox_continue_when_error.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_continue_when_error.Location = new System.Drawing.Point(9, 160);
			this.checkBox_continue_when_error.Name = "checkBox_continue_when_error";
			this.checkBox_continue_when_error.Size = new System.Drawing.Size(199, 21);
			this.checkBox_continue_when_error.TabIndex = 14;
			this.checkBox_continue_when_error.Text = "Continued read/write if it fails";
			this.checkBox_continue_when_error.UseVisualStyleBackColor = true;
			// 
			// checkBox_check_same
			// 
			this.checkBox_check_same.AutoSize = true;
			this.checkBox_check_same.Checked = true;
			this.checkBox_check_same.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_check_same.Location = new System.Drawing.Point(109, 135);
			this.checkBox_check_same.Name = "checkBox_check_same";
			this.checkBox_check_same.Size = new System.Drawing.Size(218, 21);
			this.checkBox_check_same.TabIndex = 13;
			this.checkBox_check_same.Text = "Check same with the write value?";
			this.checkBox_check_same.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Gray;
			this.label3.Location = new System.Drawing.Point(108, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(282, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "every thread use diff address: D100;D200;D300";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(109, 102);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(286, 23);
			this.textBox3.TabIndex = 11;
			this.textBox3.Text = "0-32767";
			// 
			// checkBox_write
			// 
			this.checkBox_write.AutoSize = true;
			this.checkBox_write.Checked = true;
			this.checkBox_write.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_write.Location = new System.Drawing.Point(9, 104);
			this.checkBox_write.Name = "checkBox_write";
			this.checkBox_write.Size = new System.Drawing.Size(92, 21);
			this.checkBox_write.TabIndex = 10;
			this.checkBox_write.Text = "Write short";
			this.checkBox_write.UseVisualStyleBackColor = true;
			// 
			// checkBox_read
			// 
			this.checkBox_read.AutoSize = true;
			this.checkBox_read.Checked = true;
			this.checkBox_read.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_read.Location = new System.Drawing.Point(9, 133);
			this.checkBox_read.Name = "checkBox_read";
			this.checkBox_read.Size = new System.Drawing.Size(91, 21);
			this.checkBox_read.TabIndex = 9;
			this.checkBox_read.Text = "Read short";
			this.checkBox_read.UseVisualStyleBackColor = true;
			// 
			// button_test_start
			// 
			this.button_test_start.Enabled = false;
			this.button_test_start.Location = new System.Drawing.Point(121, 184);
			this.button_test_start.Name = "button_test_start";
			this.button_test_start.Size = new System.Drawing.Size(147, 34);
			this.button_test_start.TabIndex = 8;
			this.button_test_start.Text = "Start";
			this.button_test_start.UseVisualStyleBackColor = true;
			this.button_test_start.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_test_address
			// 
			this.textBox_test_address.Location = new System.Drawing.Point(105, 50);
			this.textBox_test_address.Name = "textBox_test_address";
			this.textBox_test_address.Size = new System.Drawing.Size(290, 23);
			this.textBox_test_address.TabIndex = 5;
			this.textBox_test_address.Text = "D100";
			// 
			// label_pressure_address
			// 
			this.label_pressure_address.AutoSize = true;
			this.label_pressure_address.Location = new System.Drawing.Point(6, 53);
			this.label_pressure_address.Name = "label_pressure_address";
			this.label_pressure_address.Size = new System.Drawing.Size(59, 17);
			this.label_pressure_address.TabIndex = 4;
			this.label_pressure_address.Text = "Address:";
			// 
			// textBox_repreat_times
			// 
			this.textBox_repreat_times.Location = new System.Drawing.Point(303, 22);
			this.textBox_repreat_times.Name = "textBox_repreat_times";
			this.textBox_repreat_times.Size = new System.Drawing.Size(92, 23);
			this.textBox_repreat_times.TabIndex = 3;
			this.textBox_repreat_times.Text = "1000";
			// 
			// label_repeat_times
			// 
			this.label_repeat_times.AutoSize = true;
			this.label_repeat_times.Location = new System.Drawing.Point(195, 25);
			this.label_repeat_times.Name = "label_repeat_times";
			this.label_repeat_times.Size = new System.Drawing.Size(87, 17);
			this.label_repeat_times.TabIndex = 2;
			this.label_repeat_times.Text = "Repeat times:";
			// 
			// textBox_thread_count
			// 
			this.textBox_thread_count.Location = new System.Drawing.Point(105, 22);
			this.textBox_thread_count.Name = "textBox_thread_count";
			this.textBox_thread_count.Size = new System.Drawing.Size(73, 23);
			this.textBox_thread_count.TabIndex = 1;
			this.textBox_thread_count.Text = "1";
			// 
			// label_thread_count
			// 
			this.label_thread_count.AutoSize = true;
			this.label_thread_count.Location = new System.Drawing.Point(6, 25);
			this.label_thread_count.Name = "label_thread_count";
			this.label_thread_count.Size = new System.Drawing.Size(90, 17);
			this.label_thread_count.TabIndex = 0;
			this.label_thread_count.Text = "Thread Count:";
			// 
			// label_pressure_progress
			// 
			this.label_pressure_progress.AutoSize = true;
			this.label_pressure_progress.Location = new System.Drawing.Point(6, 22);
			this.label_pressure_progress.Name = "label_pressure_progress";
			this.label_pressure_progress.Size = new System.Drawing.Size(63, 17);
			this.label_pressure_progress.TabIndex = 6;
			this.label_pressure_progress.Text = "Progress:";
			// 
			// hslProgressBar1
			// 
			this.hslProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslProgressBar1.CustmerTextTranslate = null;
			this.hslProgressBar1.InflateWidth = 2;
			this.hslProgressBar1.Location = new System.Drawing.Point(105, 19);
			this.hslProgressBar1.Name = "hslProgressBar1";
			this.hslProgressBar1.ProgressStyle = HslControls.ProgressStyle.Percent;
			this.hslProgressBar1.Size = new System.Drawing.Size(422, 23);
			this.hslProgressBar1.TabIndex = 11;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label_info);
			this.groupBox1.Controls.Add(this.textBox_check_wrong);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox_failed_count);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox_check_same);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox_avg_time);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox_total_time);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_total_count);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.hslProgressBar1);
			this.groupBox1.Controls.Add(this.label_pressure_progress);
			this.groupBox1.Location = new System.Drawing.Point(410, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(533, 280);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test Result";
			// 
			// label_info
			// 
			this.label_info.AutoSize = true;
			this.label_info.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_info.ForeColor = System.Drawing.Color.Teal;
			this.label_info.Location = new System.Drawing.Point(6, 164);
			this.label_info.Name = "label_info";
			this.label_info.Size = new System.Drawing.Size(107, 27);
			this.label_info.TabIndex = 24;
			this.label_info.Text = "测试开始...";
			// 
			// textBox_check_wrong
			// 
			this.textBox_check_wrong.Location = new System.Drawing.Point(306, 118);
			this.textBox_check_wrong.Name = "textBox_check_wrong";
			this.textBox_check_wrong.ReadOnly = true;
			this.textBox_check_wrong.Size = new System.Drawing.Size(86, 23);
			this.textBox_check_wrong.TabIndex = 23;
			this.textBox_check_wrong.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(209, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 17);
			this.label6.TabIndex = 22;
			this.label6.Text = "Check Wrong:";
			// 
			// textBox_failed_count
			// 
			this.textBox_failed_count.Location = new System.Drawing.Point(105, 118);
			this.textBox_failed_count.Name = "textBox_failed_count";
			this.textBox_failed_count.ReadOnly = true;
			this.textBox_failed_count.Size = new System.Drawing.Size(84, 23);
			this.textBox_failed_count.TabIndex = 21;
			this.textBox_failed_count.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 17);
			this.label7.TabIndex = 20;
			this.label7.Text = "Failed Count:";
			// 
			// textBox_check_same
			// 
			this.textBox_check_same.Location = new System.Drawing.Point(306, 86);
			this.textBox_check_same.Name = "textBox_check_same";
			this.textBox_check_same.ReadOnly = true;
			this.textBox_check_same.Size = new System.Drawing.Size(86, 23);
			this.textBox_check_same.TabIndex = 19;
			this.textBox_check_same.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(209, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 17);
			this.label5.TabIndex = 18;
			this.label5.Text = "Check Same:";
			// 
			// textBox_avg_time
			// 
			this.textBox_avg_time.Location = new System.Drawing.Point(105, 86);
			this.textBox_avg_time.Name = "textBox_avg_time";
			this.textBox_avg_time.ReadOnly = true;
			this.textBox_avg_time.Size = new System.Drawing.Size(84, 23);
			this.textBox_avg_time.TabIndex = 17;
			this.textBox_avg_time.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "R/W-Avg(ms):";
			// 
			// textBox_total_time
			// 
			this.textBox_total_time.Location = new System.Drawing.Point(306, 50);
			this.textBox_total_time.Name = "textBox_total_time";
			this.textBox_total_time.ReadOnly = true;
			this.textBox_total_time.Size = new System.Drawing.Size(86, 23);
			this.textBox_total_time.TabIndex = 15;
			this.textBox_total_time.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(209, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 17);
			this.label2.TabIndex = 14;
			this.label2.Text = "Timer Total(s):";
			// 
			// textBox_total_count
			// 
			this.textBox_total_count.Location = new System.Drawing.Point(105, 50);
			this.textBox_total_count.Name = "textBox_total_count";
			this.textBox_total_count.ReadOnly = true;
			this.textBox_total_count.Size = new System.Drawing.Size(84, 23);
			this.textBox_total_count.TabIndex = 13;
			this.textBox_total_count.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "R/W Count:";
			// 
			// StressTesting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox_press);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "StressTesting";
			this.Size = new System.Drawing.Size(946, 286);
			this.Load += new System.EventHandler(this.StressTesting_Load);
			this.groupBox_press.ResumeLayout(false);
			this.groupBox_press.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_press;
		private System.Windows.Forms.TextBox textBox_test_address;
		private System.Windows.Forms.Label label_pressure_address;
		private System.Windows.Forms.TextBox textBox_repreat_times;
		private System.Windows.Forms.Label label_repeat_times;
		private System.Windows.Forms.TextBox textBox_thread_count;
		private System.Windows.Forms.Label label_thread_count;
		private System.Windows.Forms.Button button_test_start;
		private System.Windows.Forms.Label label_pressure_progress;
		private System.Windows.Forms.CheckBox checkBox_write;
		private System.Windows.Forms.CheckBox checkBox_read;
		private HslControls.HslProgressBar hslProgressBar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_total_count;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_total_time;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.CheckBox checkBox_check_same;
		private System.Windows.Forms.TextBox textBox_avg_time;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox_continue_when_error;
		private System.Windows.Forms.TextBox textBox_check_same;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_check_wrong;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_failed_count;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label_info;
	}
}
