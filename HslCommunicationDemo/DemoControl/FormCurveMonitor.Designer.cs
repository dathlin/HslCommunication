namespace HslCommunicationDemo.DemoControl
{
	partial class FormCurveMonitor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurveMonitor));
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.button_cancel = new System.Windows.Forms.Button();
			this.label_value = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.button_read = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox_type = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label_color = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBox_line_style = new System.Windows.Forms.ComboBox();
			this.label_value_max = new System.Windows.Forms.Label();
			this.label_value_min = new System.Windows.Forms.Label();
			this.label_value_avg = new System.Windows.Forms.Label();
			this.label_value_tick = new System.Windows.Forms.Label();
			this.label_plus = new System.Windows.Forms.Label();
			this.hslCurveHistory1 = new HslControls.HslCurveHistory();
			this.SuspendLayout();
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(59, 36);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(185, 23);
			this.textBox3.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 39);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "地址：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(344, 36);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(52, 23);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "1000";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(256, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "时间间隔(ms)";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.BackColor = System.Drawing.Color.White;
			this.propertyGrid1.Location = new System.Drawing.Point(725, 87);
			this.propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(219, 446);
			this.propertyGrid1.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 544);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(484, 17);
			this.label2.TabIndex = 28;
			this.label2.Text = "更高级的数据分析，诊断，曲线分析，诊断，请访问下面的优秀生态产品：PLC-Recorder";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(526, 544);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(120, 17);
			this.linkLabel1.TabIndex = 29;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.hiddenmap.cn";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(657, 544);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 17);
			this.label3.TabIndex = 30;
			this.label3.Text = "QQ群：877456127";
			// 
			// button_cancel
			// 
			this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_cancel.Location = new System.Drawing.Point(863, 35);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(82, 28);
			this.button_cancel.TabIndex = 31;
			this.button_cancel.Text = "取消";
			this.button_cancel.UseVisualStyleBackColor = true;
			this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
			// 
			// label_value
			// 
			this.label_value.AutoSize = true;
			this.label_value.Location = new System.Drawing.Point(7, 66);
			this.label_value.Name = "label_value";
			this.label_value.Size = new System.Drawing.Size(47, 17);
			this.label_value.TabIndex = 32;
			this.label_value.Text = "Value: ";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "";
			this.userControlHead1.SaveDeviceVisiable = false;
			this.userControlHead1.Size = new System.Drawing.Size(950, 32);
			this.userControlHead1.TabIndex = 33;
			// 
			// button_read
			// 
			this.button_read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_read.Location = new System.Drawing.Point(778, 35);
			this.button_read.Name = "button_read";
			this.button_read.Size = new System.Drawing.Size(82, 28);
			this.button_read.TabIndex = 34;
			this.button_read.Text = "读取";
			this.button_read.UseVisualStyleBackColor = true;
			this.button_read.Click += new System.EventHandler(this.button_read_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(403, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 35;
			this.label4.Text = "类型：";
			// 
			// comboBox_type
			// 
			this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_type.FormattingEnabled = true;
			this.comboBox_type.Location = new System.Drawing.Point(454, 35);
			this.comboBox_type.Name = "comboBox_type";
			this.comboBox_type.Size = new System.Drawing.Size(74, 25);
			this.comboBox_type.TabIndex = 36;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(535, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 17);
			this.label5.TabIndex = 37;
			this.label5.Text = "颜色:";
			// 
			// label_color
			// 
			this.label_color.BackColor = System.Drawing.Color.Blue;
			this.label_color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label_color.Location = new System.Drawing.Point(583, 39);
			this.label_color.Name = "label_color";
			this.label_color.Size = new System.Drawing.Size(18, 17);
			this.label_color.TabIndex = 38;
			this.label_color.Click += new System.EventHandler(this.label_color_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(611, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 17);
			this.label8.TabIndex = 39;
			this.label8.Text = "样式:";
			// 
			// comboBox_line_style
			// 
			this.comboBox_line_style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_line_style.FormattingEnabled = true;
			this.comboBox_line_style.Location = new System.Drawing.Point(653, 36);
			this.comboBox_line_style.Name = "comboBox_line_style";
			this.comboBox_line_style.Size = new System.Drawing.Size(119, 25);
			this.comboBox_line_style.TabIndex = 40;
			// 
			// label_value_max
			// 
			this.label_value_max.AutoSize = true;
			this.label_value_max.Location = new System.Drawing.Point(178, 66);
			this.label_value_max.Name = "label_value_max";
			this.label_value_max.Size = new System.Drawing.Size(40, 17);
			this.label_value_max.TabIndex = 41;
			this.label_value_max.Text = "Max: ";
			// 
			// label_value_min
			// 
			this.label_value_min.AutoSize = true;
			this.label_value_min.Location = new System.Drawing.Point(308, 66);
			this.label_value_min.Name = "label_value_min";
			this.label_value_min.Size = new System.Drawing.Size(37, 17);
			this.label_value_min.TabIndex = 42;
			this.label_value_min.Text = "Min: ";
			// 
			// label_value_avg
			// 
			this.label_value_avg.AutoSize = true;
			this.label_value_avg.Location = new System.Drawing.Point(420, 66);
			this.label_value_avg.Name = "label_value_avg";
			this.label_value_avg.Size = new System.Drawing.Size(37, 17);
			this.label_value_avg.TabIndex = 43;
			this.label_value_avg.Text = "Avg: ";
			// 
			// label_value_tick
			// 
			this.label_value_tick.AutoSize = true;
			this.label_value_tick.Location = new System.Drawing.Point(556, 66);
			this.label_value_tick.Name = "label_value_tick";
			this.label_value_tick.Size = new System.Drawing.Size(38, 17);
			this.label_value_tick.TabIndex = 44;
			this.label_value_tick.Text = "Tick: ";
			// 
			// label_plus
			// 
			this.label_plus.AutoSize = true;
			this.label_plus.Location = new System.Drawing.Point(671, 66);
			this.label_plus.Name = "label_plus";
			this.label_plus.Size = new System.Drawing.Size(70, 17);
			this.label_plus.TabIndex = 45;
			this.label_plus.Text = "Plus[脉冲]: ";
			// 
			// hslCurveHistory1
			// 
			this.hslCurveHistory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslCurveHistory1.BackColor = System.Drawing.Color.White;
			this.hslCurveHistory1.CoordinateColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.CurveRanges = null;
			this.hslCurveHistory1.DashCoordinateColor = System.Drawing.Color.LightGray;
			this.hslCurveHistory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.hslCurveHistory1.Location = new System.Drawing.Point(8, 88);
			this.hslCurveHistory1.MarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.MarkLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.hslCurveHistory1.MarkTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.MoveLineColor = System.Drawing.Color.Red;
			this.hslCurveHistory1.Name = "hslCurveHistory1";
			this.hslCurveHistory1.ReferenceAxisLeft.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisLeft.Unit = null;
			this.hslCurveHistory1.ReferenceAxisRight.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisRight.Unit = null;
			this.hslCurveHistory1.Size = new System.Drawing.Size(711, 445);
			this.hslCurveHistory1.TabIndex = 46;
			this.hslCurveHistory1.Text = "hslCurveHistory1";
			// 
			// FormCurveMonitor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(950, 564);
			this.Controls.Add(this.hslCurveHistory1);
			this.Controls.Add(this.label_plus);
			this.Controls.Add(this.label_value_tick);
			this.Controls.Add(this.label_value_avg);
			this.Controls.Add(this.label_value_min);
			this.Controls.Add(this.label_value_max);
			this.Controls.Add(this.comboBox_line_style);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label_color);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBox_type);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button_read);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.label_value);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label6);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimizeBox = false;
			this.Name = "FormCurveMonitor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "实时曲线";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCurveMonitor_FormClosing);
			this.Load += new System.EventHandler(this.FormCurveMonitor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button_cancel;
		private System.Windows.Forms.Label label_value;
		private UserControlHead userControlHead1;
		private System.Windows.Forms.Button button_read;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_type;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label_color;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox_line_style;
		private System.Windows.Forms.Label label_value_max;
		private System.Windows.Forms.Label label_value_min;
		private System.Windows.Forms.Label label_value_avg;
		private System.Windows.Forms.Label label_value_tick;
		private System.Windows.Forms.Label label_plus;
		private HslControls.HslCurveHistory hslCurveHistory1;
	}
}