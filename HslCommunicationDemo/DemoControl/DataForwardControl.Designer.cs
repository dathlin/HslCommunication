namespace HslCommunicationDemo.DemoControl
{
	partial class DataForwardControl
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label25 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_image = new System.Windows.Forms.DataGridViewImageColumn();
			this.Column_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button_device_remove = new System.Windows.Forms.Button();
			this.button_device_add = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_interval = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_topic = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox_use_one_topic = new System.Windows.Forms.CheckBox();
			this.button_start = new System.Windows.Forms.Button();
			this.button_stop = new System.Windows.Forms.Button();
			this.button_device_set = new System.Windows.Forms.Button();
			this.label_timecost = new System.Windows.Forms.Label();
			this.label_rowcount = new System.Windows.Forms.Label();
			this.label_run_count = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(3, 8);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(107, 17);
			this.label25.TabIndex = 2;
			this.label25.Text = "发布数据点位列表:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_topic,
            this.Column_image,
            this.Column_guid,
            this.Column_device,
            this.Column_type,
            this.Column_length,
            this.Column_value});
			this.dataGridView1.Location = new System.Drawing.Point(3, 33);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(963, 298);
			this.dataGridView1.TabIndex = 3;
			// 
			// Column_topic
			// 
			this.Column_topic.HeaderText = "Topic";
			this.Column_topic.Name = "Column_topic";
			this.Column_topic.ReadOnly = true;
			this.Column_topic.Width = 150;
			// 
			// Column_image
			// 
			this.Column_image.HeaderText = "";
			this.Column_image.Name = "Column_image";
			this.Column_image.ReadOnly = true;
			this.Column_image.Width = 24;
			// 
			// Column_guid
			// 
			this.Column_guid.HeaderText = "Device";
			this.Column_guid.Name = "Column_guid";
			this.Column_guid.ReadOnly = true;
			this.Column_guid.Width = 276;
			// 
			// Column_device
			// 
			this.Column_device.HeaderText = "Address";
			this.Column_device.Name = "Column_device";
			this.Column_device.ReadOnly = true;
			this.Column_device.Width = 150;
			// 
			// Column_type
			// 
			this.Column_type.HeaderText = "DataType";
			this.Column_type.Name = "Column_type";
			this.Column_type.ReadOnly = true;
			// 
			// Column_length
			// 
			this.Column_length.HeaderText = "Length";
			this.Column_length.Name = "Column_length";
			this.Column_length.ReadOnly = true;
			// 
			// Column_value
			// 
			this.Column_value.HeaderText = "Value";
			this.Column_value.Name = "Column_value";
			this.Column_value.ReadOnly = true;
			this.Column_value.Width = 143;
			// 
			// button_device_remove
			// 
			this.button_device_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_remove.Location = new System.Drawing.Point(483, 335);
			this.button_device_remove.Name = "button_device_remove";
			this.button_device_remove.Size = new System.Drawing.Size(112, 31);
			this.button_device_remove.TabIndex = 5;
			this.button_device_remove.Text = "移除选中点位";
			this.button_device_remove.UseVisualStyleBackColor = true;
			this.button_device_remove.Click += new System.EventHandler(this.button_device_remove_Click);
			// 
			// button_device_add
			// 
			this.button_device_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_add.Location = new System.Drawing.Point(361, 335);
			this.button_device_add.Name = "button_device_add";
			this.button_device_add.Size = new System.Drawing.Size(112, 31);
			this.button_device_add.TabIndex = 4;
			this.button_device_add.Text = "新增点位";
			this.button_device_add.UseVisualStyleBackColor = true;
			this.button_device_add.Click += new System.EventHandler(this.button_device_add_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "周期:";
			// 
			// textBox_interval
			// 
			this.textBox_interval.Location = new System.Drawing.Point(197, 5);
			this.textBox_interval.Name = "textBox_interval";
			this.textBox_interval.Size = new System.Drawing.Size(55, 23);
			this.textBox_interval.TabIndex = 7;
			this.textBox_interval.Text = "1000";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "ms";
			// 
			// textBox_topic
			// 
			this.textBox_topic.Location = new System.Drawing.Point(350, 5);
			this.textBox_topic.Name = "textBox_topic";
			this.textBox_topic.Size = new System.Drawing.Size(117, 23);
			this.textBox_topic.TabIndex = 10;
			this.textBox_topic.Text = "A";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(293, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "Topic:";
			// 
			// checkBox_use_one_topic
			// 
			this.checkBox_use_one_topic.AutoSize = true;
			this.checkBox_use_one_topic.Checked = true;
			this.checkBox_use_one_topic.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_use_one_topic.Location = new System.Drawing.Point(476, 7);
			this.checkBox_use_one_topic.Name = "checkBox_use_one_topic";
			this.checkBox_use_one_topic.Size = new System.Drawing.Size(107, 21);
			this.checkBox_use_one_topic.TabIndex = 11;
			this.checkBox_use_one_topic.Text = "打包一个Topic";
			this.checkBox_use_one_topic.UseVisualStyleBackColor = true;
			// 
			// button_start
			// 
			this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_start.Location = new System.Drawing.Point(768, 3);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(94, 27);
			this.button_start.TabIndex = 12;
			this.button_start.Text = "Start";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.button_start_Click);
			// 
			// button_stop
			// 
			this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_stop.Location = new System.Drawing.Point(868, 3);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(94, 27);
			this.button_stop.TabIndex = 13;
			this.button_stop.Text = "Stop";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
			// 
			// button_device_set
			// 
			this.button_device_set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_device_set.Location = new System.Drawing.Point(848, 335);
			this.button_device_set.Name = "button_device_set";
			this.button_device_set.Size = new System.Drawing.Size(118, 31);
			this.button_device_set.TabIndex = 14;
			this.button_device_set.Text = "设置选中行的设备";
			this.button_device_set.UseVisualStyleBackColor = true;
			this.button_device_set.Click += new System.EventHandler(this.button_device_set_Click);
			// 
			// label_timecost
			// 
			this.label_timecost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_timecost.AutoSize = true;
			this.label_timecost.Location = new System.Drawing.Point(3, 342);
			this.label_timecost.Name = "label_timecost";
			this.label_timecost.Size = new System.Drawing.Size(69, 17);
			this.label_timecost.TabIndex = 15;
			this.label_timecost.Text = "TimeCost: ";
			// 
			// label_rowcount
			// 
			this.label_rowcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_rowcount.AutoSize = true;
			this.label_rowcount.Location = new System.Drawing.Point(136, 342);
			this.label_rowcount.Name = "label_rowcount";
			this.label_rowcount.Size = new System.Drawing.Size(74, 17);
			this.label_rowcount.TabIndex = 16;
			this.label_rowcount.Text = "RowCount: ";
			// 
			// label_run_count
			// 
			this.label_run_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_run_count.AutoSize = true;
			this.label_run_count.Location = new System.Drawing.Point(708, 342);
			this.label_run_count.Name = "label_run_count";
			this.label_run_count.Size = new System.Drawing.Size(71, 17);
			this.label_run_count.TabIndex = 17;
			this.label_run_count.Text = "RunCount: ";
			// 
			// DataForwardControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.label_run_count);
			this.Controls.Add(this.label_rowcount);
			this.Controls.Add(this.label_timecost);
			this.Controls.Add(this.button_device_set);
			this.Controls.Add(this.button_stop);
			this.Controls.Add(this.button_start);
			this.Controls.Add(this.checkBox_use_one_topic);
			this.Controls.Add(this.textBox_topic);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_interval);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_device_remove);
			this.Controls.Add(this.button_device_add);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label25);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DataForwardControl";
			this.Size = new System.Drawing.Size(969, 369);
			this.Load += new System.EventHandler(this.DataForwardControl_Load);
			this.SizeChanged += new System.EventHandler(this.DataForwardControl_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button_device_remove;
		private System.Windows.Forms.Button button_device_add;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_interval;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_topic;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox_use_one_topic;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_stop;
		private System.Windows.Forms.Button button_device_set;
		private System.Windows.Forms.Label label_timecost;
		private System.Windows.Forms.Label label_rowcount;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_topic;
		private System.Windows.Forms.DataGridViewImageColumn Column_image;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_guid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_device;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_length;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_value;
		private System.Windows.Forms.Label label_run_count;
	}
}
