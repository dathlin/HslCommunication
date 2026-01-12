namespace HslCommunicationDemo.MQTT
{
	partial class MqttTopicControl
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
			this.panel8 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label_topic_size = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.checkBox_topic_retain = new System.Windows.Forms.CheckBox();
			this.textBox_topic_publishTime = new System.Windows.Forms.TextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.radioButton_topic_render_json = new System.Windows.Forms.RadioButton();
			this.radioButton_topic_render_text = new System.Windows.Forms.RadioButton();
			this.label20 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox_topic_publishSession = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox_topic_topic = new System.Windows.Forms.TextBox();
			this.textBox_topic_payload = new System.Windows.Forms.TextBox();
			this.checkBox_stop = new System.Windows.Forms.CheckBox();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.checkBox_stop);
			this.panel8.Controls.Add(this.dataGridView1);
			this.panel8.Controls.Add(this.label_topic_size);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label21);
			this.panel8.Controls.Add(this.label19);
			this.panel8.Controls.Add(this.checkBox_topic_retain);
			this.panel8.Controls.Add(this.textBox_topic_publishTime);
			this.panel8.Controls.Add(this.panel6);
			this.panel8.Controls.Add(this.label20);
			this.panel8.Controls.Add(this.label24);
			this.panel8.Controls.Add(this.textBox_topic_publishSession);
			this.panel8.Controls.Add(this.button7);
			this.panel8.Controls.Add(this.label22);
			this.panel8.Controls.Add(this.textBox_topic_topic);
			this.panel8.Controls.Add(this.textBox_topic_payload);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(982, 266);
			this.panel8.TabIndex = 28;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
			this.dataGridView1.Location = new System.Drawing.Point(2, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(442, 260);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			// 
			// Column3
			// 
			this.Column3.HeaderText = "ID";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 60;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Topic";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 260;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Count";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// label_topic_size
			// 
			this.label_topic_size.AutoSize = true;
			this.label_topic_size.ForeColor = System.Drawing.Color.Gray;
			this.label_topic_size.Location = new System.Drawing.Point(452, 116);
			this.label_topic_size.Name = "label_topic_size";
			this.label_topic_size.Size = new System.Drawing.Size(27, 17);
			this.label_topic_size.TabIndex = 26;
			this.label_topic_size.Text = "0 B";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(452, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 17);
			this.label4.TabIndex = 19;
			this.label4.Text = "Topic：";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.ForeColor = System.Drawing.Color.Gray;
			this.label21.Location = new System.Drawing.Point(452, 96);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(43, 17);
			this.label21.TabIndex = 25;
			this.label21.Text = "Size：";
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(458, 241);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 17);
			this.label19.TabIndex = 11;
			this.label19.Text = "Time：";
			// 
			// checkBox_topic_retain
			// 
			this.checkBox_topic_retain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_topic_retain.AutoSize = true;
			this.checkBox_topic_retain.Location = new System.Drawing.Point(905, 36);
			this.checkBox_topic_retain.Name = "checkBox_topic_retain";
			this.checkBox_topic_retain.Size = new System.Drawing.Size(63, 21);
			this.checkBox_topic_retain.TabIndex = 24;
			this.checkBox_topic_retain.Text = "Retain";
			this.checkBox_topic_retain.UseVisualStyleBackColor = true;
			// 
			// textBox_topic_publishTime
			// 
			this.textBox_topic_publishTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_topic_publishTime.Location = new System.Drawing.Point(520, 238);
			this.textBox_topic_publishTime.Name = "textBox_topic_publishTime";
			this.textBox_topic_publishTime.Size = new System.Drawing.Size(270, 23);
			this.textBox_topic_publishTime.TabIndex = 12;
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.Controls.Add(this.radioButton_topic_render_json);
			this.panel6.Controls.Add(this.radioButton_topic_render_text);
			this.panel6.Location = new System.Drawing.Point(860, 236);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(119, 28);
			this.panel6.TabIndex = 23;
			// 
			// radioButton_topic_render_json
			// 
			this.radioButton_topic_render_json.AutoSize = true;
			this.radioButton_topic_render_json.Location = new System.Drawing.Point(61, 3);
			this.radioButton_topic_render_json.Name = "radioButton_topic_render_json";
			this.radioButton_topic_render_json.Size = new System.Drawing.Size(52, 21);
			this.radioButton_topic_render_json.TabIndex = 2;
			this.radioButton_topic_render_json.Text = "Json";
			this.radioButton_topic_render_json.UseVisualStyleBackColor = true;
			// 
			// radioButton_topic_render_text
			// 
			this.radioButton_topic_render_text.AutoSize = true;
			this.radioButton_topic_render_text.Checked = true;
			this.radioButton_topic_render_text.Location = new System.Drawing.Point(4, 3);
			this.radioButton_topic_render_text.Name = "radioButton_topic_render_text";
			this.radioButton_topic_render_text.Size = new System.Drawing.Size(50, 21);
			this.radioButton_topic_render_text.TabIndex = 0;
			this.radioButton_topic_render_text.TabStop = true;
			this.radioButton_topic_render_text.Text = "Text";
			this.radioButton_topic_render_text.UseVisualStyleBackColor = true;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(452, 36);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(109, 17);
			this.label20.TabIndex = 13;
			this.label20.Text = "Publish Session：";
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(796, 241);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(61, 17);
			this.label24.TabIndex = 22;
			this.label24.Text = "Format：";
			// 
			// textBox_topic_publishSession
			// 
			this.textBox_topic_publishSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_topic_publishSession.Location = new System.Drawing.Point(565, 33);
			this.textBox_topic_publishSession.Name = "textBox_topic_publishSession";
			this.textBox_topic_publishSession.Size = new System.Drawing.Size(333, 23);
			this.textBox_topic_publishSession.TabIndex = 14;
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(904, 3);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(73, 28);
			this.button7.TabIndex = 21;
			this.button7.Text = "Delete";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(452, 65);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(66, 17);
			this.label22.TabIndex = 17;
			this.label22.Text = "Payload：";
			// 
			// textBox_topic_topic
			// 
			this.textBox_topic_topic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_topic_topic.Location = new System.Drawing.Point(565, 6);
			this.textBox_topic_topic.Name = "textBox_topic_topic";
			this.textBox_topic_topic.Size = new System.Drawing.Size(333, 23);
			this.textBox_topic_topic.TabIndex = 20;
			// 
			// textBox_topic_payload
			// 
			this.textBox_topic_payload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_topic_payload.Location = new System.Drawing.Point(520, 62);
			this.textBox_topic_payload.Multiline = true;
			this.textBox_topic_payload.Name = "textBox_topic_payload";
			this.textBox_topic_payload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_topic_payload.Size = new System.Drawing.Size(459, 172);
			this.textBox_topic_payload.TabIndex = 18;
			// 
			// checkBox_stop
			// 
			this.checkBox_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_stop.AutoSize = true;
			this.checkBox_stop.ForeColor = System.Drawing.Color.Gray;
			this.checkBox_stop.Location = new System.Drawing.Point(455, 211);
			this.checkBox_stop.Name = "checkBox_stop";
			this.checkBox_stop.Size = new System.Drawing.Size(54, 21);
			this.checkBox_stop.TabIndex = 27;
			this.checkBox_stop.Text = "Stop";
			this.checkBox_stop.UseVisualStyleBackColor = true;
			// 
			// MqttTopicControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.panel8);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "MqttTopicControl";
			this.Size = new System.Drawing.Size(982, 266);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.Label label_topic_size;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox checkBox_topic_retain;
		private System.Windows.Forms.TextBox textBox_topic_publishTime;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.RadioButton radioButton_topic_render_json;
		private System.Windows.Forms.RadioButton radioButton_topic_render_text;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox textBox_topic_publishSession;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox textBox_topic_topic;
		private System.Windows.Forms.TextBox textBox_topic_payload;
		private System.Windows.Forms.CheckBox checkBox_stop;
	}
}
