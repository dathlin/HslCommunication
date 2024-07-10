namespace HslCommunicationDemo.DemoControl
{
	partial class DataTableControl
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Column_encoding = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Column_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_expression = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_decs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_curve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.textBox_time = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button_out_clip = new System.Windows.Forms.Button();
			this.button_from_clip = new System.Windows.Forms.Button();
			this.button_out_file = new System.Windows.Forms.Button();
			this.button_from_file = new System.Windows.Forms.Button();
			this.label_info = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.rowDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hslCurveHistory1 = new HslControls.HslCurveHistory();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_address,
            this.Column_type,
            this.Column_encoding,
            this.Column_length,
            this.Column_value,
            this.Column_unit,
            this.Column_expression,
            this.Column_decs,
            this.Column_curve});
			this.dataGridView1.Location = new System.Drawing.Point(0, 30);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1095, 387);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "数据名";
			this.Column_name.Name = "Column_name";
			// 
			// Column_address
			// 
			this.Column_address.HeaderText = "设备地址";
			this.Column_address.Name = "Column_address";
			// 
			// Column_type
			// 
			this.Column_type.HeaderText = "数据类型";
			this.Column_type.Items.AddRange(new object[] {
            "bool",
            "byte",
            "short",
            "ushort",
            "int",
            "uint",
            "long",
            "ulong",
            "float",
            "double",
            "string"});
			this.Column_type.MaxDropDownItems = 12;
			this.Column_type.Name = "Column_type";
			// 
			// Column_encoding
			// 
			this.Column_encoding.HeaderText = "字符编码";
			this.Column_encoding.Items.AddRange(new object[] {
            "ASCII",
            "UFT16",
            "UTF8",
            "GB2312"});
			this.Column_encoding.Name = "Column_encoding";
			// 
			// Column_length
			// 
			this.Column_length.HeaderText = "长度";
			this.Column_length.Name = "Column_length";
			this.Column_length.ToolTipText = "数组长度，大于0表示这是一个数组，并且指示长度信息";
			// 
			// Column_value
			// 
			this.Column_value.HeaderText = "值";
			this.Column_value.Name = "Column_value";
			// 
			// Column_unit
			// 
			this.Column_unit.HeaderText = "单位";
			this.Column_unit.Name = "Column_unit";
			// 
			// Column_expression
			// 
			this.Column_expression.HeaderText = "表达式";
			this.Column_expression.Name = "Column_expression";
			// 
			// Column_decs
			// 
			this.Column_decs.HeaderText = "注释";
			this.Column_decs.Name = "Column_decs";
			// 
			// Column_curve
			// 
			this.Column_curve.HeaderText = "曲线";
			this.Column_curve.Name = "Column_curve";
			this.Column_curve.Width = 40;
			// 
			// textBox_time
			// 
			this.textBox_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_time.Location = new System.Drawing.Point(904, 3);
			this.textBox_time.Name = "textBox_time";
			this.textBox_time.Size = new System.Drawing.Size(84, 23);
			this.textBox_time.TabIndex = 1;
			this.textBox_time.Text = "1000";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(839, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "间隔时间:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(994, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 27);
			this.button1.TabIndex = 3;
			this.button1.Text = "开始刷新";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button_out_clip
			// 
			this.button_out_clip.Location = new System.Drawing.Point(0, 0);
			this.button_out_clip.Name = "button_out_clip";
			this.button_out_clip.Size = new System.Drawing.Size(101, 27);
			this.button_out_clip.TabIndex = 4;
			this.button_out_clip.Text = "导出到剪切板";
			this.button_out_clip.UseVisualStyleBackColor = true;
			this.button_out_clip.Click += new System.EventHandler(this.button_out_clip_Click);
			// 
			// button_from_clip
			// 
			this.button_from_clip.Location = new System.Drawing.Point(107, 0);
			this.button_from_clip.Name = "button_from_clip";
			this.button_from_clip.Size = new System.Drawing.Size(101, 27);
			this.button_from_clip.TabIndex = 5;
			this.button_from_clip.Text = "从剪切板导入";
			this.button_from_clip.UseVisualStyleBackColor = true;
			this.button_from_clip.Click += new System.EventHandler(this.button_from_clip_Click);
			// 
			// button_out_file
			// 
			this.button_out_file.Location = new System.Drawing.Point(233, 1);
			this.button_out_file.Name = "button_out_file";
			this.button_out_file.Size = new System.Drawing.Size(101, 27);
			this.button_out_file.TabIndex = 6;
			this.button_out_file.Text = "导出到文件";
			this.button_out_file.UseVisualStyleBackColor = true;
			this.button_out_file.Click += new System.EventHandler(this.button_out_file_Click);
			// 
			// button_from_file
			// 
			this.button_from_file.Location = new System.Drawing.Point(340, 1);
			this.button_from_file.Name = "button_from_file";
			this.button_from_file.Size = new System.Drawing.Size(101, 27);
			this.button_from_file.TabIndex = 7;
			this.button_from_file.Text = "从文件导入";
			this.button_from_file.UseVisualStyleBackColor = true;
			this.button_from_file.Click += new System.EventHandler(this.button_from_file_Click);
			// 
			// label_info
			// 
			this.label_info.AutoSize = true;
			this.label_info.ForeColor = System.Drawing.Color.Gray;
			this.label_info.Location = new System.Drawing.Point(447, 6);
			this.label_info.Name = "label_info";
			this.label_info.Size = new System.Drawing.Size(0, 17);
			this.label_info.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(443, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "双击值单元格可写入";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowDeleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
			// 
			// rowDeleteToolStripMenuItem
			// 
			this.rowDeleteToolStripMenuItem.Name = "rowDeleteToolStripMenuItem";
			this.rowDeleteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.rowDeleteToolStripMenuItem.Text = "RowDelete";
			// 
			// hslCurveHistory1
			// 
			this.hslCurveHistory1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslCurveHistory1.BackColor = System.Drawing.Color.White;
			this.hslCurveHistory1.CoordinateColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.CurveRanges = null;
			this.hslCurveHistory1.DashCoordinateColor = System.Drawing.Color.Silver;
			this.hslCurveHistory1.ForeColor = System.Drawing.Color.Blue;
			this.hslCurveHistory1.HoverBackColor = System.Drawing.Color.WhiteSmoke;
			this.hslCurveHistory1.Location = new System.Drawing.Point(3, 228);
			this.hslCurveHistory1.MarkLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.hslCurveHistory1.MarkTextColor = System.Drawing.Color.DarkGoldenrod;
			this.hslCurveHistory1.MoveLineColor = System.Drawing.Color.Red;
			this.hslCurveHistory1.Name = "hslCurveHistory1";
			this.hslCurveHistory1.ReferenceAxisLeft.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisLeft.Unit = null;
			this.hslCurveHistory1.ReferenceAxisRight.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.hslCurveHistory1.ReferenceAxisRight.Unit = null;
			this.hslCurveHistory1.ScrollColor = System.Drawing.Color.Gray;
			this.hslCurveHistory1.Size = new System.Drawing.Size(1089, 186);
			this.hslCurveHistory1.TabIndex = 11;
			this.hslCurveHistory1.Text = "hslCurveHistory1";
			this.hslCurveHistory1.Visible = false;
			// 
			// DataTableControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.hslCurveHistory1);
			this.Controls.Add(this.label_info);
			this.Controls.Add(this.button_from_file);
			this.Controls.Add(this.button_out_file);
			this.Controls.Add(this.button_from_clip);
			this.Controls.Add(this.button_out_clip);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_time);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DataTableControl";
			this.Size = new System.Drawing.Size(1095, 417);
			this.Load += new System.EventHandler(this.DataTableControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox_time;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button_out_clip;
		private System.Windows.Forms.Button button_from_clip;
		private System.Windows.Forms.Button button_out_file;
		private System.Windows.Forms.Button button_from_file;
		private System.Windows.Forms.Label label_info;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rowDeleteToolStripMenuItem;
        private HslControls.HslCurveHistory hslCurveHistory1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_address;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_type;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_encoding;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_expression;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_decs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_curve;
    }
}
