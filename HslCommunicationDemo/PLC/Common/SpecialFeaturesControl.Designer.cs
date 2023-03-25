namespace HslCommunicationDemo.PLC.Common
{
	partial class SpecialFeaturesControl
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
			this.checkBox_write = new System.Windows.Forms.CheckBox();
			this.checkBox_read = new System.Windows.Forms.CheckBox();
			this.button_test_start = new System.Windows.Forms.Button();
			this.label_progress = new System.Windows.Forms.Label();
			this.label_pressure_progress = new System.Windows.Forms.Label();
			this.textBox_test_address = new System.Windows.Forms.TextBox();
			this.label_pressure_address = new System.Windows.Forms.Label();
			this.textBox_repreat_times = new System.Windows.Forms.TextBox();
			this.label_repeat_times = new System.Windows.Forms.Label();
			this.textBox_thread_count = new System.Windows.Forms.TextBox();
			this.label_thread_count = new System.Windows.Forms.Label();
			this.groupBox_press.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_press
			// 
			this.groupBox_press.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox_press.Controls.Add(this.checkBox_write);
			this.groupBox_press.Controls.Add(this.checkBox_read);
			this.groupBox_press.Controls.Add(this.button_test_start);
			this.groupBox_press.Controls.Add(this.label_progress);
			this.groupBox_press.Controls.Add(this.label_pressure_progress);
			this.groupBox_press.Controls.Add(this.textBox_test_address);
			this.groupBox_press.Controls.Add(this.label_pressure_address);
			this.groupBox_press.Controls.Add(this.textBox_repreat_times);
			this.groupBox_press.Controls.Add(this.label_repeat_times);
			this.groupBox_press.Controls.Add(this.textBox_thread_count);
			this.groupBox_press.Controls.Add(this.label_thread_count);
			this.groupBox_press.Location = new System.Drawing.Point(3, 3);
			this.groupBox_press.Name = "groupBox_press";
			this.groupBox_press.Size = new System.Drawing.Size(242, 226);
			this.groupBox_press.TabIndex = 0;
			this.groupBox_press.TabStop = false;
			this.groupBox_press.Text = "Pressure Testing";
			// 
			// checkBox_write
			// 
			this.checkBox_write.AutoSize = true;
			this.checkBox_write.Checked = true;
			this.checkBox_write.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_write.Location = new System.Drawing.Point(130, 149);
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
			this.checkBox_read.Location = new System.Drawing.Point(23, 149);
			this.checkBox_read.Name = "checkBox_read";
			this.checkBox_read.Size = new System.Drawing.Size(91, 21);
			this.checkBox_read.TabIndex = 9;
			this.checkBox_read.Text = "Read short";
			this.checkBox_read.UseVisualStyleBackColor = true;
			// 
			// button_test_start
			// 
			this.button_test_start.Location = new System.Drawing.Point(46, 179);
			this.button_test_start.Name = "button_test_start";
			this.button_test_start.Size = new System.Drawing.Size(147, 34);
			this.button_test_start.TabIndex = 8;
			this.button_test_start.Text = "Start";
			this.button_test_start.UseVisualStyleBackColor = true;
			this.button_test_start.Click += new System.EventHandler(this.button1_Click);
			// 
			// label_progress
			// 
			this.label_progress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_progress.Location = new System.Drawing.Point(111, 113);
			this.label_progress.Name = "label_progress";
			this.label_progress.Size = new System.Drawing.Size(119, 25);
			this.label_progress.TabIndex = 7;
			this.label_progress.Text = "0%";
			this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_pressure_progress
			// 
			this.label_pressure_progress.AutoSize = true;
			this.label_pressure_progress.Location = new System.Drawing.Point(6, 117);
			this.label_pressure_progress.Name = "label_pressure_progress";
			this.label_pressure_progress.Size = new System.Drawing.Size(63, 17);
			this.label_pressure_progress.TabIndex = 6;
			this.label_pressure_progress.Text = "Progress:";
			// 
			// textBox_test_address
			// 
			this.textBox_test_address.Location = new System.Drawing.Point(114, 82);
			this.textBox_test_address.Name = "textBox_test_address";
			this.textBox_test_address.Size = new System.Drawing.Size(116, 23);
			this.textBox_test_address.TabIndex = 5;
			this.textBox_test_address.Text = "D100";
			// 
			// label_pressure_address
			// 
			this.label_pressure_address.AutoSize = true;
			this.label_pressure_address.Location = new System.Drawing.Point(6, 85);
			this.label_pressure_address.Name = "label_pressure_address";
			this.label_pressure_address.Size = new System.Drawing.Size(59, 17);
			this.label_pressure_address.TabIndex = 4;
			this.label_pressure_address.Text = "Address:";
			// 
			// textBox_repreat_times
			// 
			this.textBox_repreat_times.Location = new System.Drawing.Point(114, 51);
			this.textBox_repreat_times.Name = "textBox_repreat_times";
			this.textBox_repreat_times.Size = new System.Drawing.Size(116, 23);
			this.textBox_repreat_times.TabIndex = 3;
			this.textBox_repreat_times.Text = "1000";
			// 
			// label_repeat_times
			// 
			this.label_repeat_times.AutoSize = true;
			this.label_repeat_times.Location = new System.Drawing.Point(6, 54);
			this.label_repeat_times.Name = "label_repeat_times";
			this.label_repeat_times.Size = new System.Drawing.Size(87, 17);
			this.label_repeat_times.TabIndex = 2;
			this.label_repeat_times.Text = "Repeat times:";
			// 
			// textBox_thread_count
			// 
			this.textBox_thread_count.Location = new System.Drawing.Point(114, 22);
			this.textBox_thread_count.Name = "textBox_thread_count";
			this.textBox_thread_count.Size = new System.Drawing.Size(116, 23);
			this.textBox_thread_count.TabIndex = 1;
			this.textBox_thread_count.Text = "3";
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
			// SpecialFeaturesControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.groupBox_press);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "SpecialFeaturesControl";
			this.Size = new System.Drawing.Size(652, 232);
			this.groupBox_press.ResumeLayout(false);
			this.groupBox_press.PerformLayout();
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
		private System.Windows.Forms.Label label_progress;
		private System.Windows.Forms.Label label_pressure_progress;
		private System.Windows.Forms.CheckBox checkBox_write;
		private System.Windows.Forms.CheckBox checkBox_read;
	}
}
