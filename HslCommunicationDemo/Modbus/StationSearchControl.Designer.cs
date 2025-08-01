namespace HslCommunicationDemo.Modbus
{
	partial class StationSearchControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_station_start = new System.Windows.Forms.TextBox();
			this.textBox_station_stop = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox_stop_match = new System.Windows.Forms.CheckBox();
			this.textBox_timeout = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button_start = new System.Windows.Forms.Button();
			this.button_stop = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_address = new System.Windows.Forms.TextBox();
			this.textBox_length = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButton_word = new System.Windows.Forms.RadioButton();
			this.radioButton_bool = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_match = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "起始搜索站号:";
			// 
			// textBox_station_start
			// 
			this.textBox_station_start.Location = new System.Drawing.Point(102, 7);
			this.textBox_station_start.Name = "textBox_station_start";
			this.textBox_station_start.Size = new System.Drawing.Size(58, 23);
			this.textBox_station_start.TabIndex = 1;
			this.textBox_station_start.Text = "0";
			// 
			// textBox_station_stop
			// 
			this.textBox_station_stop.Location = new System.Drawing.Point(271, 7);
			this.textBox_station_stop.Name = "textBox_station_stop";
			this.textBox_station_stop.Size = new System.Drawing.Size(62, 23);
			this.textBox_station_stop.TabIndex = 3;
			this.textBox_station_stop.Text = "255";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(174, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "终止搜索站号:";
			// 
			// checkBox_stop_match
			// 
			this.checkBox_stop_match.AutoSize = true;
			this.checkBox_stop_match.Location = new System.Drawing.Point(495, 9);
			this.checkBox_stop_match.Name = "checkBox_stop_match";
			this.checkBox_stop_match.Size = new System.Drawing.Size(111, 21);
			this.checkBox_stop_match.TabIndex = 4;
			this.checkBox_stop_match.Text = "匹配即停止搜索";
			this.checkBox_stop_match.UseVisualStyleBackColor = true;
			// 
			// textBox_timeout
			// 
			this.textBox_timeout.Location = new System.Drawing.Point(429, 7);
			this.textBox_timeout.Name = "textBox_timeout";
			this.textBox_timeout.Size = new System.Drawing.Size(53, 23);
			this.textBox_timeout.TabIndex = 6;
			this.textBox_timeout.Text = "500";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(341, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "超时时间:";
			// 
			// button_start
			// 
			this.button_start.Location = new System.Drawing.Point(623, 4);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(81, 29);
			this.button_start.TabIndex = 7;
			this.button_start.Text = "开始";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.button_start_Click);
			// 
			// button_stop
			// 
			this.button_stop.Enabled = false;
			this.button_stop.Location = new System.Drawing.Point(710, 4);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(81, 29);
			this.button_stop.TabIndex = 8;
			this.button_stop.Text = "停止";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "读取地址:";
			// 
			// textBox_address
			// 
			this.textBox_address.Location = new System.Drawing.Point(102, 38);
			this.textBox_address.Name = "textBox_address";
			this.textBox_address.Size = new System.Drawing.Size(97, 23);
			this.textBox_address.TabIndex = 10;
			this.textBox_address.Text = "0";
			// 
			// textBox_length
			// 
			this.textBox_length.Location = new System.Drawing.Point(293, 38);
			this.textBox_length.Name = "textBox_length";
			this.textBox_length.Size = new System.Drawing.Size(82, 23);
			this.textBox_length.TabIndex = 12;
			this.textBox_length.Text = "1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(208, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "读取长度:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButton_word);
			this.panel1.Controls.Add(this.radioButton_bool);
			this.panel1.Location = new System.Drawing.Point(388, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(209, 32);
			this.panel1.TabIndex = 13;
			// 
			// radioButton_word
			// 
			this.radioButton_word.AutoSize = true;
			this.radioButton_word.Checked = true;
			this.radioButton_word.Location = new System.Drawing.Point(101, 4);
			this.radioButton_word.Name = "radioButton_word";
			this.radioButton_word.Size = new System.Drawing.Size(80, 21);
			this.radioButton_word.TabIndex = 1;
			this.radioButton_word.TabStop = true;
			this.radioButton_word.Text = "word读取";
			this.radioButton_word.UseVisualStyleBackColor = true;
			// 
			// radioButton_bool
			// 
			this.radioButton_bool.AutoSize = true;
			this.radioButton_bool.Location = new System.Drawing.Point(3, 4);
			this.radioButton_bool.Name = "radioButton_bool";
			this.radioButton_bool.Size = new System.Drawing.Size(77, 21);
			this.radioButton_bool.TabIndex = 0;
			this.radioButton_bool.TabStop = true;
			this.radioButton_bool.Text = "bool读取";
			this.radioButton_bool.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 17);
			this.label6.TabIndex = 14;
			this.label6.Text = "实时日志:";
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox_log.Location = new System.Drawing.Point(8, 88);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(381, 187);
			this.textBox_log.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(395, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 17);
			this.label7.TabIndex = 16;
			this.label7.Text = "匹配站号:";
			// 
			// textBox_match
			// 
			this.textBox_match.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_match.Location = new System.Drawing.Point(395, 88);
			this.textBox_match.Multiline = true;
			this.textBox_match.Name = "textBox_match";
			this.textBox_match.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_match.Size = new System.Drawing.Size(413, 187);
			this.textBox_match.TabIndex = 17;
			// 
			// StationSearchControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.textBox_match);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_log);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBox_length);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox_address);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button_stop);
			this.Controls.Add(this.button_start);
			this.Controls.Add(this.textBox_timeout);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkBox_stop_match);
			this.Controls.Add(this.textBox_station_stop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_station_start);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "StationSearchControl";
			this.Size = new System.Drawing.Size(811, 278);
			this.Load += new System.EventHandler(this.StationSearchControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_station_start;
		private System.Windows.Forms.TextBox textBox_station_stop;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_stop_match;
		private System.Windows.Forms.TextBox textBox_timeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_stop;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_address;
		private System.Windows.Forms.TextBox textBox_length;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButton_word;
		private System.Windows.Forms.RadioButton radioButton_bool;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_log;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_match;
	}
}
