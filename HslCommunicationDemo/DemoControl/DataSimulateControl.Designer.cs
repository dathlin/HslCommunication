namespace HslCommunicationDemo.DemoControl
{
    partial class DataSimulateControl
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_express = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_current = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.rowDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toXmlClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toCsvClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromCsvClipCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button_start = new System.Windows.Forms.Button();
			this.button_finish = new System.Windows.Forms.Button();
			this.button_onece = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button_clear_all = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_address,
            this.Column_time,
            this.Column_express,
            this.Column_current,
            this.Column_mark});
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(0, 30);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(922, 328);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "名称";
			this.Column_name.Name = "Column_name";
			this.Column_name.Width = 140;
			// 
			// Column_address
			// 
			this.Column_address.HeaderText = "设备地址";
			this.Column_address.Name = "Column_address";
			this.Column_address.Width = 120;
			// 
			// Column_time
			// 
			this.Column_time.HeaderText = "间隔时间(ms)";
			this.Column_time.Name = "Column_time";
			// 
			// Column_express
			// 
			this.Column_express.HeaderText = "表达式";
			this.Column_express.Name = "Column_express";
			this.Column_express.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column_express.Width = 200;
			// 
			// Column_current
			// 
			this.Column_current.HeaderText = "当前值";
			this.Column_current.Name = "Column_current";
			this.Column_current.Width = 150;
			// 
			// Column_mark
			// 
			this.Column_mark.HeaderText = "备注";
			this.Column_mark.Name = "Column_mark";
			this.Column_mark.Width = 150;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowDeleteToolStripMenuItem,
            this.toXmlClipToolStripMenuItem,
            this.fromClipToolStripMenuItem,
            this.toFileToolStripMenuItem,
            this.fromFileToolStripMenuItem,
            this.toCsvClipToolStripMenuItem,
            this.fromCsvClipCsvToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 180);
			// 
			// rowDeleteToolStripMenuItem
			// 
			this.rowDeleteToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_Cancel_16xLG;
			this.rowDeleteToolStripMenuItem.Name = "rowDeleteToolStripMenuItem";
			this.rowDeleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rowDeleteToolStripMenuItem.Text = "RowDelete";
			// 
			// toXmlClipToolStripMenuItem
			// 
			this.toXmlClipToolStripMenuItem.Name = "toXmlClipToolStripMenuItem";
			this.toXmlClipToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.toXmlClipToolStripMenuItem.Text = "导出到剪切板";
			// 
			// fromClipToolStripMenuItem
			// 
			this.fromClipToolStripMenuItem.Name = "fromClipToolStripMenuItem";
			this.fromClipToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fromClipToolStripMenuItem.Text = "从剪切板导入";
			// 
			// toFileToolStripMenuItem
			// 
			this.toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
			this.toFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.toFileToolStripMenuItem.Text = "导出到文件";
			// 
			// fromFileToolStripMenuItem
			// 
			this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
			this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fromFileToolStripMenuItem.Text = "从文件导入";
			// 
			// toCsvClipToolStripMenuItem
			// 
			this.toCsvClipToolStripMenuItem.Name = "toCsvClipToolStripMenuItem";
			this.toCsvClipToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.toCsvClipToolStripMenuItem.Text = "导出Csv到剪切板";
			// 
			// fromCsvClipCsvToolStripMenuItem
			// 
			this.fromCsvClipCsvToolStripMenuItem.Name = "fromCsvClipCsvToolStripMenuItem";
			this.fromCsvClipCsvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fromCsvClipCsvToolStripMenuItem.Text = "从剪切板导入Csv";
			// 
			// button_start
			// 
			this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_start.Location = new System.Drawing.Point(775, 1);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(69, 28);
			this.button_start.TabIndex = 3;
			this.button_start.Text = "开始";
			this.button_start.UseVisualStyleBackColor = true;
			// 
			// button_finish
			// 
			this.button_finish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_finish.Location = new System.Drawing.Point(846, 1);
			this.button_finish.Name = "button_finish";
			this.button_finish.Size = new System.Drawing.Size(72, 28);
			this.button_finish.TabIndex = 4;
			this.button_finish.Text = "停止";
			this.button_finish.UseVisualStyleBackColor = true;
			// 
			// button_onece
			// 
			this.button_onece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_onece.Location = new System.Drawing.Point(702, 1);
			this.button_onece.Name = "button_onece";
			this.button_onece.Size = new System.Drawing.Size(69, 28);
			this.button_onece.TabIndex = 5;
			this.button_onece.Text = "运行一次";
			this.button_onece.UseVisualStyleBackColor = true;
			this.button_onece.Click += new System.EventHandler(this.button_onece_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(4, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "右键菜单删除、导入、导出";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(241, 7);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(92, 17);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "表达式参考例子";
			this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
			// 
			// button_clear_all
			// 
			this.button_clear_all.Location = new System.Drawing.Point(442, 2);
			this.button_clear_all.Name = "button_clear_all";
			this.button_clear_all.Size = new System.Drawing.Size(83, 27);
			this.button_clear_all.TabIndex = 13;
			this.button_clear_all.Text = "删除全部";
			this.button_clear_all.UseVisualStyleBackColor = true;
			this.button_clear_all.Click += new System.EventHandler(this.button_clear_all_Click);
			// 
			// DataSimulateControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.button_clear_all);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_onece);
			this.Controls.Add(this.button_finish);
			this.Controls.Add(this.button_start);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DataSimulateControl";
			this.Size = new System.Drawing.Size(922, 358);
			this.Load += new System.EventHandler(this.DataSimulateControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_finish;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_address;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_express;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_current;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_mark;
        private System.Windows.Forms.Button button_onece;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem rowDeleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toXmlClipToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromClipToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ToolStripMenuItem toCsvClipToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromCsvClipCsvToolStripMenuItem;
		private System.Windows.Forms.Button button_clear_all;
	}
}
