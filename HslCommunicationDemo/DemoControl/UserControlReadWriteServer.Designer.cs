namespace HslCommunicationDemo.DemoControl
{
    partial class UserControlReadWriteServer
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
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_log_filter = new System.Windows.Forms.Button();
            this.textBox_log_filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_import_abort = new System.Windows.Forms.Button();
            this.checkBox_cycle = new System.Windows.Forms.CheckBox();
            this.button_data_import = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.batchReadControl1 = new HslCommunicationDemo.DemoControl.BatchReadControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataTableControl1 = new HslCommunicationDemo.DemoControl.DataTableControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataSimulateControl1 = new HslCommunicationDemo.DemoControl.DataSimulateControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_others_code = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView_dtu_sessions = new System.Windows.Forms.DataGridView();
            this.Column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_dtu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_close = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button8 = new System.Windows.Forms.Button();
            this.userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dtu_sessions)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(291, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 21);
            this.label15.TabIndex = 26;
            this.label15.Text = "0";
            this.label15.Click += new System.EventHandler(this.label16_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(170, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 21);
            this.label16.TabIndex = 25;
            this.label16.Text = "在线客户端：";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "显示运行日志数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(936, 163);
            this.textBox1.TabIndex = 23;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(2, 272);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 233);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_log_filter);
            this.tabPage1.Controls.Add(this.textBox_log_filter);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(948, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_log_filter
            // 
            this.button_log_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_log_filter.Location = new System.Drawing.Point(850, 3);
            this.button_log_filter.Name = "button_log_filter";
            this.button_log_filter.Size = new System.Drawing.Size(95, 28);
            this.button_log_filter.TabIndex = 36;
            this.button_log_filter.Text = "设置过滤条件";
            this.button_log_filter.UseVisualStyleBackColor = true;
            this.button_log_filter.Click += new System.EventHandler(this.button_log_filter_Click);
            // 
            // textBox_log_filter
            // 
            this.textBox_log_filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log_filter.Location = new System.Drawing.Point(723, 5);
            this.textBox_log_filter.Name = "textBox_log_filter";
            this.textBox_log_filter.Size = new System.Drawing.Size(121, 23);
            this.textBox_log_filter.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(673, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "正则：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_import_abort);
            this.panel1.Controls.Add(this.checkBox_cycle);
            this.panel1.Controls.Add(this.button_data_import);
            this.panel1.Location = new System.Drawing.Point(361, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 30);
            this.panel1.TabIndex = 33;
            // 
            // button_import_abort
            // 
            this.button_import_abort.Enabled = false;
            this.button_import_abort.Location = new System.Drawing.Point(186, 1);
            this.button_import_abort.Name = "button_import_abort";
            this.button_import_abort.Size = new System.Drawing.Size(108, 28);
            this.button_import_abort.TabIndex = 33;
            this.button_import_abort.Text = "终止导入";
            this.button_import_abort.UseVisualStyleBackColor = true;
            this.button_import_abort.Click += new System.EventHandler(this.button_import_abort_Click);
            // 
            // checkBox_cycle
            // 
            this.checkBox_cycle.AutoSize = true;
            this.checkBox_cycle.Location = new System.Drawing.Point(10, 5);
            this.checkBox_cycle.Name = "checkBox_cycle";
            this.checkBox_cycle.Size = new System.Drawing.Size(51, 21);
            this.checkBox_cycle.TabIndex = 32;
            this.checkBox_cycle.Text = "循环";
            this.checkBox_cycle.UseVisualStyleBackColor = true;
            this.checkBox_cycle.CheckedChanged += new System.EventHandler(this.checkBox_cycle_CheckedChanged);
            // 
            // button_data_import
            // 
            this.button_data_import.Location = new System.Drawing.Point(72, 1);
            this.button_data_import.Name = "button_data_import";
            this.button_data_import.Size = new System.Drawing.Size(108, 28);
            this.button_data_import.TabIndex = 31;
            this.button_data_import.Text = "数据导入";
            this.button_data_import.UseVisualStyleBackColor = true;
            this.button_data_import.Click += new System.EventHandler(this.button_data_import_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.batchReadControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(948, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "批量读取";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // batchReadControl1
            // 
            this.batchReadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchReadControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.batchReadControl1.IsSourceReadMode = false;
            this.batchReadControl1.Location = new System.Drawing.Point(3, 3);
            this.batchReadControl1.Name = "batchReadControl1";
            this.batchReadControl1.Size = new System.Drawing.Size(942, 201);
            this.batchReadControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataTableControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(948, 203);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "点位变量";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataTableControl1
            // 
            this.dataTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataTableControl1.Location = new System.Drawing.Point(3, 3);
            this.dataTableControl1.Name = "dataTableControl1";
            this.dataTableControl1.Size = new System.Drawing.Size(942, 197);
            this.dataTableControl1.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataSimulateControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(948, 207);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "数据模拟";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataSimulateControl1
            // 
            this.dataSimulateControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSimulateControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataSimulateControl1.Location = new System.Drawing.Point(3, 3);
            this.dataSimulateControl1.Name = "dataSimulateControl1";
            this.dataSimulateControl1.Size = new System.Drawing.Size(942, 201);
            this.dataSimulateControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(948, 207);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "其他功能";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_others_code);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.dataGridView_dtu_sessions);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 201);
            this.panel2.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "连接列表：";
            // 
            // textBox_others_code
            // 
            this.textBox_others_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_others_code.Location = new System.Drawing.Point(60, 146);
            this.textBox_others_code.Multiline = true;
            this.textBox_others_code.Name = "textBox_others_code";
            this.textBox_others_code.Size = new System.Drawing.Size(879, 52);
            this.textBox_others_code.TabIndex = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 28);
            this.button1.TabIndex = 34;
            this.button1.Text = "连接异形服务器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Code：";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(648, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(138, 28);
            this.button9.TabIndex = 36;
            this.button9.Text = "存储数据到文件";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView_dtu_sessions
            // 
            this.dataGridView_dtu_sessions.AllowUserToAddRows = false;
            this.dataGridView_dtu_sessions.AllowUserToDeleteRows = false;
            this.dataGridView_dtu_sessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_dtu_sessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dtu_sessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_number,
            this.Column_ip,
            this.Column_port,
            this.Column_dtu,
            this.Column_time,
            this.Column_close});
            this.dataGridView_dtu_sessions.Location = new System.Drawing.Point(3, 38);
            this.dataGridView_dtu_sessions.Name = "dataGridView_dtu_sessions";
            this.dataGridView_dtu_sessions.ReadOnly = true;
            this.dataGridView_dtu_sessions.RowTemplate.Height = 23;
            this.dataGridView_dtu_sessions.Size = new System.Drawing.Size(936, 102);
            this.dataGridView_dtu_sessions.TabIndex = 38;
            this.dataGridView_dtu_sessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_dtu_sessions_CellContentClick);
            // 
            // Column_number
            // 
            this.Column_number.HeaderText = "Number";
            this.Column_number.Name = "Column_number";
            this.Column_number.ReadOnly = true;
            // 
            // Column_ip
            // 
            this.Column_ip.HeaderText = "EndPoint";
            this.Column_ip.Name = "Column_ip";
            this.Column_ip.ReadOnly = true;
            this.Column_ip.Width = 220;
            // 
            // Column_port
            // 
            this.Column_port.HeaderText = "Status";
            this.Column_port.Name = "Column_port";
            this.Column_port.ReadOnly = true;
            // 
            // Column_dtu
            // 
            this.Column_dtu.HeaderText = "DTU";
            this.Column_dtu.Name = "Column_dtu";
            this.Column_dtu.ReadOnly = true;
            this.Column_dtu.Width = 200;
            // 
            // Column_time
            // 
            this.Column_time.HeaderText = "ConnectTime";
            this.Column_time.Name = "Column_time";
            this.Column_time.ReadOnly = true;
            this.Column_time.Width = 180;
            // 
            // Column_close
            // 
            this.Column_close.HeaderText = "Close";
            this.Column_close.Name = "Column_close";
            this.Column_close.ReadOnly = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(792, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(147, 28);
            this.button8.TabIndex = 35;
            this.button8.Text = "从文件加载数据";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // userControlReadWriteOp1
            // 
            this.userControlReadWriteOp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlReadWriteOp1.Location = new System.Drawing.Point(2, 1);
            this.userControlReadWriteOp1.Name = "userControlReadWriteOp1";
            this.userControlReadWriteOp1.Size = new System.Drawing.Size(956, 270);
            this.userControlReadWriteOp1.TabIndex = 0;
            // 
            // UserControlReadWriteServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.userControlReadWriteOp1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserControlReadWriteServer";
            this.Size = new System.Drawing.Size(960, 505);
            this.Load += new System.EventHandler(this.UserControlReadWriteServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dtu_sessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlReadWriteOp userControlReadWriteOp1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private BatchReadControl batchReadControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private DataTableControl dataTableControl1;
        private System.Windows.Forms.Button button_data_import;
        private System.Windows.Forms.CheckBox checkBox_cycle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_import_abort;
		private System.Windows.Forms.TabPage tabPage4;
		private DataSimulateControl dataSimulateControl1;
        private System.Windows.Forms.Button button_log_filter;
        private System.Windows.Forms.TextBox textBox_log_filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_dtu_sessions;
        private System.Windows.Forms.TextBox textBox_others_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_port;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_dtu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
        private System.Windows.Forms.DataGridViewButtonColumn Column_close;
        private System.Windows.Forms.Panel panel2;
    }
}
