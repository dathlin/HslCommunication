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
			this.textBox_curve_address = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.button_cancel = new System.Windows.Forms.Button();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.button_read = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox_type = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label_color = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBox_line_style = new System.Windows.Forms.ComboBox();
			this.hslCurveHistory1 = new HslControls.HslCurveHistory();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label_time_cost = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_color = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_max = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_min = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.button_timer_start = new System.Windows.Forms.Button();
			this.button_timer_stop = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_curve_name = new System.Windows.Forms.TextBox();
			this.button_clear_all = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox_curve_address
			// 
			this.textBox_curve_address.Location = new System.Drawing.Point(55, 64);
			this.textBox_curve_address.Name = "textBox_curve_address";
			this.textBox_curve_address.Size = new System.Drawing.Size(180, 23);
			this.textBox_curve_address.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "地址：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(151, 37);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(67, 23);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "1000";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(60, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "时间间隔(ms)";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.BackColor = System.Drawing.Color.White;
			this.propertyGrid1.Location = new System.Drawing.Point(3, 4);
			this.propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(300, 397);
			this.propertyGrid1.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 17);
			this.label2.TabIndex = 28;
			this.label2.Text = "循环耗时: ";
			// 
			// button_cancel
			// 
			this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_cancel.Location = new System.Drawing.Point(867, 63);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(80, 28);
			this.button_cancel.TabIndex = 31;
			this.button_cancel.Text = "移除";
			this.button_cancel.UseVisualStyleBackColor = true;
			this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
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
			this.userControlHead1.Size = new System.Drawing.Size(952, 32);
			this.userControlHead1.TabIndex = 33;
			// 
			// button_read
			// 
			this.button_read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_read.Location = new System.Drawing.Point(780, 63);
			this.button_read.Name = "button_read";
			this.button_read.Size = new System.Drawing.Size(81, 28);
			this.button_read.TabIndex = 34;
			this.button_read.Text = "增加";
			this.button_read.UseVisualStyleBackColor = true;
			this.button_read.Click += new System.EventHandler(this.button_read_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(403, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 35;
			this.label4.Text = "类型：";
			// 
			// comboBox_type
			// 
			this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_type.FormattingEnabled = true;
			this.comboBox_type.Location = new System.Drawing.Point(454, 63);
			this.comboBox_type.Name = "comboBox_type";
			this.comboBox_type.Size = new System.Drawing.Size(74, 25);
			this.comboBox_type.TabIndex = 36;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(535, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 17);
			this.label5.TabIndex = 37;
			this.label5.Text = "颜色:";
			// 
			// label_color
			// 
			this.label_color.BackColor = System.Drawing.Color.Blue;
			this.label_color.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label_color.Location = new System.Drawing.Point(583, 67);
			this.label_color.Name = "label_color";
			this.label_color.Size = new System.Drawing.Size(18, 17);
			this.label_color.TabIndex = 38;
			this.label_color.Click += new System.EventHandler(this.label_color_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(611, 67);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 17);
			this.label8.TabIndex = 39;
			this.label8.Text = "样式:";
			// 
			// comboBox_line_style
			// 
			this.comboBox_line_style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_line_style.FormattingEnabled = true;
			this.comboBox_line_style.Location = new System.Drawing.Point(653, 64);
			this.comboBox_line_style.Name = "comboBox_line_style";
			this.comboBox_line_style.Size = new System.Drawing.Size(119, 25);
			this.comboBox_line_style.TabIndex = 40;
			// 
			// hslCurveHistory1
			// 
			this.hslCurveHistory1.BackColor = System.Drawing.Color.White;
			this.hslCurveHistory1.CoordinateColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.CurveRanges = null;
			this.hslCurveHistory1.DashCoordinateColor = System.Drawing.Color.LightGray;
			this.hslCurveHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hslCurveHistory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.hslCurveHistory1.Location = new System.Drawing.Point(0, 0);
			this.hslCurveHistory1.MarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.MarkLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.hslCurveHistory1.MarkTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.MoveLineColor = System.Drawing.Color.Red;
			this.hslCurveHistory1.Name = "hslCurveHistory1";
			this.hslCurveHistory1.ReferenceAxisLeft.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisLeft.Unit = null;
			this.hslCurveHistory1.ReferenceAxisRight.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisRight.Unit = null;
			this.hslCurveHistory1.Size = new System.Drawing.Size(631, 441);
			this.hslCurveHistory1.TabIndex = 46;
			this.hslCurveHistory1.Text = "hslCurveHistory1";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightGray;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label_time_cost);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 543);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(952, 24);
			this.panel1.TabIndex = 47;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(183, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(763, 17);
			this.label3.TabIndex = 30;
			this.label3.Text = "说明: 可以先启动定时器，也可以先添加完所有的曲线信息，再启动定时器，最大个数是曲线点位上线，超过该上限，会自动移除最早的数据。 ";
			// 
			// label_time_cost
			// 
			this.label_time_cost.AutoSize = true;
			this.label_time_cost.Location = new System.Drawing.Point(89, 4);
			this.label_time_cost.Name = "label_time_cost";
			this.label_time_cost.Size = new System.Drawing.Size(38, 17);
			this.label_time_cost.TabIndex = 29;
			this.label_time_cost.Text = "-  ms";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(317, 441);
			this.tabControl1.TabIndex = 48;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel2);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(309, 411);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "曲线属性";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.propertyGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(303, 405);
			this.panel2.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel3);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(309, 411);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "曲线信息";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(303, 405);
			this.panel3.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_color,
            this.Column_value,
            this.Column_max,
            this.Column_min});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(303, 405);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "名称";
			this.Column_name.Name = "Column_name";
			this.Column_name.ReadOnly = true;
			this.Column_name.Width = 110;
			// 
			// Column_color
			// 
			this.Column_color.HeaderText = "";
			this.Column_color.Name = "Column_color";
			this.Column_color.ReadOnly = true;
			this.Column_color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column_color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Column_color.Width = 28;
			// 
			// Column_value
			// 
			this.Column_value.HeaderText = "值";
			this.Column_value.Name = "Column_value";
			this.Column_value.ReadOnly = true;
			// 
			// Column_max
			// 
			this.Column_max.HeaderText = "最大值";
			this.Column_max.Name = "Column_max";
			this.Column_max.ReadOnly = true;
			// 
			// Column_min
			// 
			this.Column_min.HeaderText = "最小值";
			this.Column_min.Name = "Column_min";
			this.Column_min.ReadOnly = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 97);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(952, 441);
			this.splitContainer1.SplitterDistance = 631;
			this.splitContainer1.TabIndex = 49;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.hslCurveHistory1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(631, 441);
			this.panel4.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 17);
			this.label7.TabIndex = 50;
			this.label7.Text = "定时器：";
			// 
			// button_timer_start
			// 
			this.button_timer_start.Location = new System.Drawing.Point(375, 34);
			this.button_timer_start.Name = "button_timer_start";
			this.button_timer_start.Size = new System.Drawing.Size(91, 28);
			this.button_timer_start.TabIndex = 51;
			this.button_timer_start.Text = "启动";
			this.button_timer_start.UseVisualStyleBackColor = true;
			this.button_timer_start.Click += new System.EventHandler(this.button_timer_start_Click);
			// 
			// button_timer_stop
			// 
			this.button_timer_stop.Enabled = false;
			this.button_timer_stop.Location = new System.Drawing.Point(472, 34);
			this.button_timer_stop.Name = "button_timer_stop";
			this.button_timer_stop.Size = new System.Drawing.Size(91, 28);
			this.button_timer_stop.TabIndex = 52;
			this.button_timer_stop.Text = "停止";
			this.button_timer_stop.UseVisualStyleBackColor = true;
			this.button_timer_stop.Click += new System.EventHandler(this.button_timer_stop_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(296, 37);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(67, 23);
			this.textBox2.TabIndex = 54;
			this.textBox2.Text = "3000";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(224, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(59, 17);
			this.label9.TabIndex = 53;
			this.label9.Text = "最大个数:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(239, 67);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 17);
			this.label10.TabIndex = 55;
			this.label10.Text = "曲线名：";
			// 
			// textBox_curve_name
			// 
			this.textBox_curve_name.Location = new System.Drawing.Point(296, 64);
			this.textBox_curve_name.Name = "textBox_curve_name";
			this.textBox_curve_name.Size = new System.Drawing.Size(101, 23);
			this.textBox_curve_name.TabIndex = 56;
			// 
			// button_clear_all
			// 
			this.button_clear_all.Location = new System.Drawing.Point(569, 34);
			this.button_clear_all.Name = "button_clear_all";
			this.button_clear_all.Size = new System.Drawing.Size(110, 28);
			this.button_clear_all.TabIndex = 57;
			this.button_clear_all.Text = "清空所有曲线";
			this.button_clear_all.UseVisualStyleBackColor = true;
			this.button_clear_all.Click += new System.EventHandler(this.button_clear_all_Click);
			// 
			// FormCurveMonitor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(952, 567);
			this.Controls.Add(this.button_clear_all);
			this.Controls.Add(this.textBox_curve_name);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button_timer_stop);
			this.Controls.Add(this.button_timer_start);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.comboBox_line_style);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label_color);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBox_type);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button_read);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_curve_address);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_curve_address;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button_cancel;
		private UserControlHead userControlHead1;
		private System.Windows.Forms.Button button_read;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_type;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label_color;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox_line_style;
		private HslControls.HslCurveHistory hslCurveHistory1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button_timer_start;
		private System.Windows.Forms.Button button_timer_stop;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox_curve_name;
		private System.Windows.Forms.Button button_clear_all;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewImageColumn Column_color;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_max;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_min;
		private System.Windows.Forms.Label label_time_cost;
		private System.Windows.Forms.Label label3;
	}
}