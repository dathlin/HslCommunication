namespace HslCommunicationDemo.PLC.Siemens
{
	partial class S7ServerDbControl
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_des = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.button_db_remove = new System.Windows.Forms.Button();
			this.button_db_add = new System.Windows.Forms.Button();
			this.textBox_db = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_length = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_name = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_desc = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label_row_count = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_db,
            this.Column_length,
            this.Column_des});
			this.dataGridView1.Location = new System.Drawing.Point(1, 25);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(611, 235);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "Name";
			this.Column_name.Name = "Column_name";
			this.Column_name.ReadOnly = true;
			this.Column_name.Width = 150;
			// 
			// Column_db
			// 
			this.Column_db.HeaderText = "DB";
			this.Column_db.Name = "Column_db";
			this.Column_db.ReadOnly = true;
			// 
			// Column_length
			// 
			this.Column_length.HeaderText = "Length";
			this.Column_length.Name = "Column_length";
			this.Column_length.ReadOnly = true;
			// 
			// Column_des
			// 
			this.Column_des.HeaderText = "Description";
			this.Column_des.Name = "Column_des";
			this.Column_des.ReadOnly = true;
			this.Column_des.Width = 150;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(290, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "当前的DB块信息: (除系统自带的DB1,DB2, DB3之外)";
			// 
			// button_db_remove
			// 
			this.button_db_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_db_remove.Location = new System.Drawing.Point(618, 153);
			this.button_db_remove.Name = "button_db_remove";
			this.button_db_remove.Size = new System.Drawing.Size(149, 28);
			this.button_db_remove.TabIndex = 37;
			this.button_db_remove.Text = "Remove";
			this.button_db_remove.UseVisualStyleBackColor = true;
			this.button_db_remove.Click += new System.EventHandler(this.button_db_remove_Click);
			// 
			// button_db_add
			// 
			this.button_db_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_db_add.Location = new System.Drawing.Point(618, 121);
			this.button_db_add.Name = "button_db_add";
			this.button_db_add.Size = new System.Drawing.Size(149, 28);
			this.button_db_add.TabIndex = 36;
			this.button_db_add.Text = "Add";
			this.button_db_add.UseVisualStyleBackColor = true;
			this.button_db_add.Click += new System.EventHandler(this.button_db_add_Click);
			// 
			// textBox_db
			// 
			this.textBox_db.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_db.Location = new System.Drawing.Point(696, 2);
			this.textBox_db.Name = "textBox_db";
			this.textBox_db.Size = new System.Drawing.Size(71, 23);
			this.textBox_db.TabIndex = 35;
			this.textBox_db.Text = "10";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(618, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 17);
			this.label2.TabIndex = 34;
			this.label2.Text = "DB block：";
			// 
			// textBox_length
			// 
			this.textBox_length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_length.Location = new System.Drawing.Point(696, 30);
			this.textBox_length.Name = "textBox_length";
			this.textBox_length.Size = new System.Drawing.Size(71, 23);
			this.textBox_length.TabIndex = 39;
			this.textBox_length.Text = "65536";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(618, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 17);
			this.label3.TabIndex = 38;
			this.label3.Text = "Length：";
			// 
			// textBox_name
			// 
			this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_name.Location = new System.Drawing.Point(696, 59);
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.Size = new System.Drawing.Size(71, 23);
			this.textBox_name.TabIndex = 41;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(618, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 17);
			this.label4.TabIndex = 40;
			this.label4.Text = "Name：";
			// 
			// textBox_desc
			// 
			this.textBox_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_desc.Location = new System.Drawing.Point(696, 89);
			this.textBox_desc.Name = "textBox_desc";
			this.textBox_desc.Size = new System.Drawing.Size(71, 23);
			this.textBox_desc.TabIndex = 43;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(618, 92);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 17);
			this.label5.TabIndex = 42;
			this.label5.Text = "Desc：";
			// 
			// label_row_count
			// 
			this.label_row_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_row_count.AutoSize = true;
			this.label_row_count.Location = new System.Drawing.Point(615, 243);
			this.label_row_count.Name = "label_row_count";
			this.label_row_count.Size = new System.Drawing.Size(46, 17);
			this.label_row_count.TabIndex = 44;
			this.label_row_count.Text = "Rows: ";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.ForeColor = System.Drawing.Color.Gray;
			this.label6.Location = new System.Drawing.Point(416, 5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(196, 17);
			this.label6.TabIndex = 45;
			this.label6.Text = "批量增加：100-200";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// S7ServerDbControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label_row_count);
			this.Controls.Add(this.textBox_desc);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox_name);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_length);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button_db_remove);
			this.Controls.Add(this.button_db_add);
			this.Controls.Add(this.textBox_db);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "S7ServerDbControl";
			this.Size = new System.Drawing.Size(770, 262);
			this.SizeChanged += new System.EventHandler(this.S7ServerDbControl_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_db_remove;
		private System.Windows.Forms.Button button_db_add;
		private System.Windows.Forms.TextBox textBox_db;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_length;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_name;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_desc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_db;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_length;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_des;
		private System.Windows.Forms.Label label_row_count;
		private System.Windows.Forms.Label label6;
	}
}
