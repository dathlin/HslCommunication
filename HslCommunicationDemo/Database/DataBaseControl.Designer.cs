namespace HslCommunicationDemo.Database
{
	partial class DataBaseControl
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.dataGridView_sql = new System.Windows.Forms.DataGridView();
			this.Column_sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_success = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_failed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel7 = new System.Windows.Forms.Panel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel8 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_query = new System.Windows.Forms.Button();
			this.textBox_sql = new System.Windows.Forms.TextBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel10 = new System.Windows.Forms.Panel();
			this.dataGridView_table = new System.Windows.Forms.DataGridView();
			this.label_timecost = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_sql)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(935, 638);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(927, 608);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "定时任务";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.splitContainer1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(921, 602);
			this.panel3.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel6);
			this.splitContainer1.Size = new System.Drawing.Size(921, 602);
			this.splitContainer1.SplitterDistance = 283;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(921, 283);
			this.panel4.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label8);
			this.panel6.Controls.Add(this.dataGridView_sql);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(921, 315);
			this.panel6.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(3, 292);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(612, 17);
			this.label8.TabIndex = 3;
			this.label8.Text = "传参例子:  INSERT INTO [dbo].[table] ([A], [B]) VALUES (@A, @B)  这里的@A 这个A来自发布主题列表的名称" +
    "";
			// 
			// dataGridView_sql
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView_sql.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView_sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_sql.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView_sql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_sql.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_sql,
            this.Column_success,
            this.Column_failed});
			this.dataGridView_sql.Location = new System.Drawing.Point(3, 2);
			this.dataGridView_sql.Name = "dataGridView_sql";
			this.dataGridView_sql.RowTemplate.Height = 23;
			this.dataGridView_sql.Size = new System.Drawing.Size(915, 286);
			this.dataGridView_sql.TabIndex = 0;
			// 
			// Column_sql
			// 
			this.Column_sql.HeaderText = "Sql Command";
			this.Column_sql.Name = "Column_sql";
			this.Column_sql.Width = 530;
			// 
			// Column_success
			// 
			this.Column_success.HeaderText = "Success";
			this.Column_success.Name = "Column_success";
			// 
			// Column_failed
			// 
			this.Column_failed.HeaderText = "Failed";
			this.Column_failed.Name = "Column_failed";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel7);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(927, 608);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "基本查询";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.splitContainer2);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(921, 602);
			this.panel7.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.panel8);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.panel9);
			this.splitContainer2.Size = new System.Drawing.Size(921, 602);
			this.splitContainer2.SplitterDistance = 176;
			this.splitContainer2.TabIndex = 1;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.textBox1);
			this.panel8.Controls.Add(this.button_query);
			this.panel8.Controls.Add(this.textBox_sql);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(921, 176);
			this.panel8.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.ForeColor = System.Drawing.Color.Gray;
			this.textBox1.Location = new System.Drawing.Point(117, 147);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(801, 23);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "排序使用 ORDER BY [col] DESC";
			// 
			// button_query
			// 
			this.button_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_query.Location = new System.Drawing.Point(2, 144);
			this.button_query.Name = "button_query";
			this.button_query.Size = new System.Drawing.Size(86, 29);
			this.button_query.TabIndex = 1;
			this.button_query.Text = "查询";
			this.button_query.UseVisualStyleBackColor = true;
			// 
			// textBox_sql
			// 
			this.textBox_sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_sql.Location = new System.Drawing.Point(3, 3);
			this.textBox_sql.Multiline = true;
			this.textBox_sql.Name = "textBox_sql";
			this.textBox_sql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_sql.Size = new System.Drawing.Size(915, 139);
			this.textBox_sql.TabIndex = 0;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.tabControl2);
			this.panel9.Controls.Add(this.label_timecost);
			this.panel9.Controls.Add(this.textBox3);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(921, 422);
			this.panel9.TabIndex = 1;
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Location = new System.Drawing.Point(2, 74);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(916, 348);
			this.tabControl2.TabIndex = 5;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel10);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(908, 318);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "表格";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.dataGridView_table);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel10.Location = new System.Drawing.Point(3, 3);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(902, 312);
			this.panel10.TabIndex = 0;
			// 
			// dataGridView_table
			// 
			this.dataGridView_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_table.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_table.Location = new System.Drawing.Point(3, 3);
			this.dataGridView_table.Name = "dataGridView_table";
			this.dataGridView_table.RowTemplate.Height = 23;
			this.dataGridView_table.Size = new System.Drawing.Size(896, 306);
			this.dataGridView_table.TabIndex = 3;
			// 
			// label_timecost
			// 
			this.label_timecost.AutoSize = true;
			this.label_timecost.Location = new System.Drawing.Point(201, 4);
			this.label_timecost.Name = "label_timecost";
			this.label_timecost.Size = new System.Drawing.Size(44, 17);
			this.label_timecost.TabIndex = 4;
			this.label_timecost.Text = "耗时：";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(3, 24);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(915, 47);
			this.textBox3.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "信息：";
			// 
			// DataBaseControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DataBaseControl";
			this.Size = new System.Drawing.Size(935, 638);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_sql)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridView dataGridView_sql;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_sql;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_success;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_failed;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button_query;
		private System.Windows.Forms.TextBox textBox_sql;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.DataGridView dataGridView_table;
		private System.Windows.Forms.Label label_timecost;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
	}
}
