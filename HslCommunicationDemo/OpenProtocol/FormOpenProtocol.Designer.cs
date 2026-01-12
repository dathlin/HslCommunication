namespace HslCommunicationDemo
{
    partial class FormOpenProtocol
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label_spindleId = new System.Windows.Forms.Label();
			this.textBox_spindleID = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_dataField = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label_read_time = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label_read_cost = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label_read_byteLength = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label_read_tick = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.textBox_read_content = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.panel6 = new System.Windows.Forms.Panel();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.checkBox_sub_stop = new System.Windows.Forms.CheckBox();
			this.label_subscribe_tick = new System.Windows.Forms.Label();
			this.checkBox_sub_format = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel8 = new System.Windows.Forms.Panel();
			this.button_dataParse_delete = new System.Windows.Forms.Button();
			this.button_dataParse_add = new System.Windows.Forms.Button();
			this.checkBox_withIndex = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_mid_parse = new System.Windows.Forms.TextBox();
			this.textBox_revision_parse = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_decs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.textBox_mid = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button_read_string = new System.Windows.Forms.Button();
			this.textBox_revision = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_stationID = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox_sub_mid = new System.Windows.Forms.TextBox();
			this.label_sub_mid = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox_revison_connect = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Open Protocol";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 3;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel7);
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Location = new System.Drawing.Point(2, 98);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1001, 545);
			this.panel2.TabIndex = 5;
			// 
			// panel7
			// 
			this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel7.Controls.Add(this.label_spindleId);
			this.panel7.Controls.Add(this.textBox_spindleID);
			this.panel7.Controls.Add(this.splitContainer1);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Controls.Add(this.textBox_code);
			this.panel7.Controls.Add(this.textBox_mid);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Controls.Add(this.button_read_string);
			this.panel7.Controls.Add(this.textBox_revision);
			this.panel7.Controls.Add(this.label2);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Controls.Add(this.textBox_stationID);
			this.panel7.Location = new System.Drawing.Point(318, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(678, 537);
			this.panel7.TabIndex = 2;
			// 
			// label_spindleId
			// 
			this.label_spindleId.AutoSize = true;
			this.label_spindleId.Location = new System.Drawing.Point(372, 8);
			this.label_spindleId.Name = "label_spindleId";
			this.label_spindleId.Size = new System.Drawing.Size(74, 17);
			this.label_spindleId.TabIndex = 44;
			this.label_spindleId.Text = "spindleId：";
			// 
			// textBox_spindleID
			// 
			this.textBox_spindleID.Location = new System.Drawing.Point(452, 5);
			this.textBox_spindleID.Name = "textBox_spindleID";
			this.textBox_spindleID.Size = new System.Drawing.Size(48, 23);
			this.textBox_spindleID.TabIndex = 45;
			this.textBox_spindleID.Text = "-1";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(6, 32);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel4);
			this.splitContainer1.Size = new System.Drawing.Size(667, 477);
			this.splitContainer1.SplitterDistance = 144;
			this.splitContainer1.TabIndex = 43;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.textBox_dataField);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label_read_time);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.label_read_cost);
			this.panel3.Controls.Add(this.label14);
			this.panel3.Controls.Add(this.label_read_byteLength);
			this.panel3.Controls.Add(this.label16);
			this.panel3.Controls.Add(this.label_read_tick);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(667, 144);
			this.panel3.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 34);
			this.label8.TabIndex = 23;
			this.label8.Text = "parameters：\r\n多个参数换行";
			// 
			// textBox_dataField
			// 
			this.textBox_dataField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_dataField.Location = new System.Drawing.Point(89, 5);
			this.textBox_dataField.Multiline = true;
			this.textBox_dataField.Name = "textBox_dataField";
			this.textBox_dataField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_dataField.Size = new System.Drawing.Size(569, 116);
			this.textBox_dataField.TabIndex = 24;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Gray;
			this.label7.Location = new System.Drawing.Point(86, 126);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 17);
			this.label7.TabIndex = 27;
			this.label7.Text = "Time：";
			// 
			// label_read_time
			// 
			this.label_read_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_read_time.AutoSize = true;
			this.label_read_time.ForeColor = System.Drawing.Color.Gray;
			this.label_read_time.Location = new System.Drawing.Point(135, 126);
			this.label_read_time.Name = "label_read_time";
			this.label_read_time.Size = new System.Drawing.Size(13, 17);
			this.label_read_time.TabIndex = 28;
			this.label_read_time.Text = "-";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.Gray;
			this.label12.Location = new System.Drawing.Point(300, 126);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 17);
			this.label12.TabIndex = 29;
			this.label12.Text = "Cost：";
			// 
			// label_read_cost
			// 
			this.label_read_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_read_cost.AutoSize = true;
			this.label_read_cost.ForeColor = System.Drawing.Color.Gray;
			this.label_read_cost.Location = new System.Drawing.Point(349, 126);
			this.label_read_cost.Name = "label_read_cost";
			this.label_read_cost.Size = new System.Drawing.Size(13, 17);
			this.label_read_cost.TabIndex = 30;
			this.label_read_cost.Text = "-";
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.Color.Gray;
			this.label14.Location = new System.Drawing.Point(431, 126);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 17);
			this.label14.TabIndex = 31;
			this.label14.Text = "Length：";
			// 
			// label_read_byteLength
			// 
			this.label_read_byteLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_read_byteLength.AutoSize = true;
			this.label_read_byteLength.ForeColor = System.Drawing.Color.Gray;
			this.label_read_byteLength.Location = new System.Drawing.Point(490, 126);
			this.label_read_byteLength.Name = "label_read_byteLength";
			this.label_read_byteLength.Size = new System.Drawing.Size(13, 17);
			this.label_read_byteLength.TabIndex = 32;
			this.label_read_byteLength.Text = "-";
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label16.AutoSize = true;
			this.label16.ForeColor = System.Drawing.Color.Gray;
			this.label16.Location = new System.Drawing.Point(551, 126);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(43, 17);
			this.label16.TabIndex = 33;
			this.label16.Text = "Tick：";
			// 
			// label_read_tick
			// 
			this.label_read_tick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_read_tick.AutoSize = true;
			this.label_read_tick.ForeColor = System.Drawing.Color.Gray;
			this.label_read_tick.Location = new System.Drawing.Point(617, 126);
			this.label_read_tick.Name = "label_read_tick";
			this.label_read_tick.Size = new System.Drawing.Size(13, 17);
			this.label_read_tick.TabIndex = 34;
			this.label_read_tick.Text = "-";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.tabControl2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(667, 329);
			this.panel4.TabIndex = 0;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(667, 329);
			this.tabControl2.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel5);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(659, 299);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Read Result";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.textBox_read_content);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(653, 293);
			this.panel5.TabIndex = 0;
			// 
			// textBox_read_content
			// 
			this.textBox_read_content.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_read_content.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_read_content.Location = new System.Drawing.Point(0, 0);
			this.textBox_read_content.Multiline = true;
			this.textBox_read_content.Name = "textBox_read_content";
			this.textBox_read_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_read_content.Size = new System.Drawing.Size(653, 293);
			this.textBox_read_content.TabIndex = 26;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.panel6);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(659, 299);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Subscribe";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.textBox_log);
			this.panel6.Controls.Add(this.checkBox_sub_stop);
			this.panel6.Controls.Add(this.label_subscribe_tick);
			this.panel6.Controls.Add(this.checkBox_sub_format);
			this.panel6.Controls.Add(this.label15);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(653, 293);
			this.panel6.TabIndex = 0;
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_log.Location = new System.Drawing.Point(82, 3);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(568, 287);
			this.textBox_log.TabIndex = 36;
			// 
			// checkBox_sub_stop
			// 
			this.checkBox_sub_stop.AutoSize = true;
			this.checkBox_sub_stop.Location = new System.Drawing.Point(3, 6);
			this.checkBox_sub_stop.Name = "checkBox_sub_stop";
			this.checkBox_sub_stop.Size = new System.Drawing.Size(54, 21);
			this.checkBox_sub_stop.TabIndex = 37;
			this.checkBox_sub_stop.Text = "Stop";
			this.checkBox_sub_stop.UseVisualStyleBackColor = true;
			// 
			// label_subscribe_tick
			// 
			this.label_subscribe_tick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_subscribe_tick.AutoSize = true;
			this.label_subscribe_tick.ForeColor = System.Drawing.Color.Gray;
			this.label_subscribe_tick.Location = new System.Drawing.Point(39, 271);
			this.label_subscribe_tick.Name = "label_subscribe_tick";
			this.label_subscribe_tick.Size = new System.Drawing.Size(13, 17);
			this.label_subscribe_tick.TabIndex = 40;
			this.label_subscribe_tick.Text = "-";
			// 
			// checkBox_sub_format
			// 
			this.checkBox_sub_format.AutoSize = true;
			this.checkBox_sub_format.Location = new System.Drawing.Point(3, 33);
			this.checkBox_sub_format.Name = "checkBox_sub_format";
			this.checkBox_sub_format.Size = new System.Drawing.Size(68, 21);
			this.checkBox_sub_format.TabIndex = 38;
			this.checkBox_sub_format.Text = "Format";
			this.checkBox_sub_format.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.Gray;
			this.label15.Location = new System.Drawing.Point(3, 271);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(43, 17);
			this.label15.TabIndex = 39;
			this.label15.Text = "Tick：";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel8);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(659, 303);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "DataParse";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.button_dataParse_delete);
			this.panel8.Controls.Add(this.button_dataParse_add);
			this.panel8.Controls.Add(this.checkBox_withIndex);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.textBox_mid_parse);
			this.panel8.Controls.Add(this.textBox_revision_parse);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.dataGridView1);
			this.panel8.Controls.Add(this.listBox1);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(653, 297);
			this.panel8.TabIndex = 0;
			// 
			// button_dataParse_delete
			// 
			this.button_dataParse_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_dataParse_delete.Location = new System.Drawing.Point(578, 1);
			this.button_dataParse_delete.Name = "button_dataParse_delete";
			this.button_dataParse_delete.Size = new System.Drawing.Size(73, 28);
			this.button_dataParse_delete.TabIndex = 25;
			this.button_dataParse_delete.Text = "Delete";
			this.button_dataParse_delete.UseVisualStyleBackColor = true;
			this.button_dataParse_delete.Click += new System.EventHandler(this.button_dataParse_delete_Click);
			// 
			// button_dataParse_add
			// 
			this.button_dataParse_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_dataParse_add.Location = new System.Drawing.Point(499, 1);
			this.button_dataParse_add.Name = "button_dataParse_add";
			this.button_dataParse_add.Size = new System.Drawing.Size(73, 28);
			this.button_dataParse_add.TabIndex = 24;
			this.button_dataParse_add.Text = "Add";
			this.button_dataParse_add.UseVisualStyleBackColor = true;
			this.button_dataParse_add.Click += new System.EventHandler(this.button_dataParse_add_Click);
			// 
			// checkBox_withIndex
			// 
			this.checkBox_withIndex.AutoSize = true;
			this.checkBox_withIndex.Checked = true;
			this.checkBox_withIndex.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_withIndex.Location = new System.Drawing.Point(350, 6);
			this.checkBox_withIndex.Name = "checkBox_withIndex";
			this.checkBox_withIndex.Size = new System.Drawing.Size(105, 21);
			this.checkBox_withIndex.TabIndex = 23;
			this.checkBox_withIndex.Text = "Include Index";
			this.checkBox_withIndex.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(128, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "MID：";
			// 
			// textBox_mid_parse
			// 
			this.textBox_mid_parse.Location = new System.Drawing.Point(179, 4);
			this.textBox_mid_parse.Name = "textBox_mid_parse";
			this.textBox_mid_parse.Size = new System.Drawing.Size(51, 23);
			this.textBox_mid_parse.TabIndex = 20;
			this.textBox_mid_parse.Text = "0060";
			// 
			// textBox_revision_parse
			// 
			this.textBox_revision_parse.Location = new System.Drawing.Point(294, 4);
			this.textBox_revision_parse.Name = "textBox_revision_parse";
			this.textBox_revision_parse.Size = new System.Drawing.Size(50, 23);
			this.textBox_revision_parse.TabIndex = 22;
			this.textBox_revision_parse.Text = "3";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(233, 7);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(62, 17);
			this.label10.TabIndex = 21;
			this.label10.Text = "revison：";
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_index,
            this.Column_decs});
			this.dataGridView1.Location = new System.Drawing.Point(131, 29);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(519, 265);
			this.dataGridView1.TabIndex = 2;
			// 
			// Column_name
			// 
			this.Column_name.HeaderText = "Name";
			this.Column_name.Name = "Column_name";
			this.Column_name.Width = 200;
			// 
			// Column_index
			// 
			this.Column_index.HeaderText = "ByteIndex";
			this.Column_index.Name = "Column_index";
			// 
			// Column_decs
			// 
			this.Column_decs.HeaderText = "Decscription";
			this.Column_decs.Name = "Column_decs";
			this.Column_decs.Width = 150;
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(1, 29);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(124, 242);
			this.listBox1.TabIndex = 1;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "列表:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 17);
			this.label6.TabIndex = 2;
			this.label6.Text = "MID：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(95, 511);
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(578, 23);
			this.textBox_code.TabIndex = 42;
			// 
			// textBox_mid
			// 
			this.textBox_mid.Location = new System.Drawing.Point(56, 5);
			this.textBox_mid.Name = "textBox_mid";
			this.textBox_mid.Size = new System.Drawing.Size(51, 23);
			this.textBox_mid.TabIndex = 3;
			this.textBox_mid.Text = "10";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 514);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 17);
			this.label1.TabIndex = 41;
			this.label1.Text = "Code：";
			// 
			// button_read_string
			// 
			this.button_read_string.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_read_string.Location = new System.Drawing.Point(539, 2);
			this.button_read_string.Name = "button_read_string";
			this.button_read_string.Size = new System.Drawing.Size(134, 28);
			this.button_read_string.TabIndex = 16;
			this.button_read_string.Text = "read";
			this.button_read_string.UseVisualStyleBackColor = true;
			this.button_read_string.Click += new System.EventHandler(this.Button_read_string_Click);
			// 
			// textBox_revision
			// 
			this.textBox_revision.Location = new System.Drawing.Point(171, 5);
			this.textBox_revision.Name = "textBox_revision";
			this.textBox_revision.Size = new System.Drawing.Size(50, 23);
			this.textBox_revision.TabIndex = 18;
			this.textBox_revision.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(110, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 17);
			this.label2.TabIndex = 17;
			this.label2.Text = "revison：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(229, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 17);
			this.label4.TabIndex = 19;
			this.label4.Text = "stationId：";
			// 
			// textBox_stationID
			// 
			this.textBox_stationID.Location = new System.Drawing.Point(309, 5);
			this.textBox_stationID.Name = "textBox_stationID";
			this.textBox_stationID.Size = new System.Drawing.Size(48, 23);
			this.textBox_stationID.TabIndex = 20;
			this.textBox_stationID.Text = "-1";
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(3, 3);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(309, 537);
			this.treeView1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_sub_mid);
			this.panel1.Controls.Add(this.label_sub_mid);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox_revison_connect);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(2, 34);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1001, 61);
			this.panel1.TabIndex = 4;
			// 
			// textBox_sub_mid
			// 
			this.textBox_sub_mid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_sub_mid.Location = new System.Drawing.Point(682, 33);
			this.textBox_sub_mid.MinimumSize = new System.Drawing.Size(100, 23);
			this.textBox_sub_mid.Name = "textBox_sub_mid";
			this.textBox_sub_mid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_sub_mid.Size = new System.Drawing.Size(307, 23);
			this.textBox_sub_mid.TabIndex = 37;
			// 
			// label_sub_mid
			// 
			this.label_sub_mid.AutoSize = true;
			this.label_sub_mid.Cursor = System.Windows.Forms.Cursors.Help;
			this.label_sub_mid.Location = new System.Drawing.Point(601, 36);
			this.label_sub_mid.Name = "label_sub_mid";
			this.label_sub_mid.Size = new System.Drawing.Size(63, 17);
			this.label_sub_mid.TabIndex = 36;
			this.label_sub_mid.Text = "Sub-MID:";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(401, 35);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(184, 21);
			this.checkBox2.TabIndex = 35;
			this.checkBox2.Text = "MID9999 KeepAlive Enable";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(3, 3);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
			this.pipeSelectControl1.TabIndex = 34;
			this.pipeSelectControl1.TcpPortText = "4545";
			this.pipeSelectControl1.UdpPortText = "4545";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(199, 35);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(192, 21);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "AutoAckControllerMessage?";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox_revison_connect
			// 
			this.textBox_revison_connect.Location = new System.Drawing.Point(150, 33);
			this.textBox_revison_connect.Name = "textBox_revison_connect";
			this.textBox_revison_connect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_revison_connect.Size = new System.Drawing.Size(42, 23);
			this.textBox_revison_connect.TabIndex = 7;
			this.textBox_revison_connect.Text = "1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(144, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = "RevisonOnConnected：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(898, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "Disconnect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(799, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// FormOpenProtocol
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormOpenProtocol";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormOpenProtocol";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOpenProtocol_FormClosing);
			this.Load += new System.EventHandler(this.FormOpenProtocol_Load);
			this.panel2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_read_string;
        private System.Windows.Forms.TextBox textBox_mid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_revision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_stationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_dataField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox textBox_revison_connect;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_read_content;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label_read_tick;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label_read_byteLength;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label_read_cost;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label_read_time;
		private System.Windows.Forms.CheckBox checkBox_sub_stop;
		private System.Windows.Forms.TextBox textBox_log;
		private System.Windows.Forms.CheckBox checkBox_sub_format;
		private System.Windows.Forms.Label label_subscribe_tick;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox checkBox1;
        private DemoControl.PipeSelectControl pipeSelectControl1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox_sub_mid;
        private System.Windows.Forms.Label label_sub_mid;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label_spindleId;
		private System.Windows.Forms.TextBox textBox_spindleID;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button_dataParse_delete;
		private System.Windows.Forms.Button button_dataParse_add;
		private System.Windows.Forms.CheckBox checkBox_withIndex;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_mid_parse;
		private System.Windows.Forms.TextBox textBox_revision_parse;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_index;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_decs;
	}
}