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
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label_subscribe_tick = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.checkBox_sub_format = new System.Windows.Forms.CheckBox();
			this.checkBox_sub_stop = new System.Windows.Forms.CheckBox();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label_read_tick = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label_read_byteLength = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label_read_cost = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label_read_time = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_read_content = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_revision = new System.Windows.Forms.TextBox();
			this.textBox_dataField = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_spindleID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_stationID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button_read_string = new System.Windows.Forms.Button();
			this.textBox_mid = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox_revison_connect = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Location = new System.Drawing.Point(2, 81);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1001, 560);
			this.panel2.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(999, 558);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.treeView1);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(991, 528);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Basic Test";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(6, 6);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(309, 516);
			this.treeView1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label_subscribe_tick);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.checkBox_sub_format);
			this.groupBox1.Controls.Add(this.checkBox_sub_stop);
			this.groupBox1.Controls.Add(this.textBox_log);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label_read_tick);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label_read_byteLength);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label_read_cost);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label_read_time);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox_read_content);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox_revision);
			this.groupBox1.Controls.Add(this.textBox_dataField);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.textBox_spindleID);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox_stationID);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.button_read_string);
			this.groupBox1.Controls.Add(this.textBox_mid);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(321, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(664, 522);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Single Read";
			// 
			// label_subscribe_tick
			// 
			this.label_subscribe_tick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_subscribe_tick.AutoSize = true;
			this.label_subscribe_tick.ForeColor = System.Drawing.Color.Gray;
			this.label_subscribe_tick.Location = new System.Drawing.Point(42, 499);
			this.label_subscribe_tick.Name = "label_subscribe_tick";
			this.label_subscribe_tick.Size = new System.Drawing.Size(13, 17);
			this.label_subscribe_tick.TabIndex = 40;
			this.label_subscribe_tick.Text = "-";
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.Gray;
			this.label15.Location = new System.Drawing.Point(6, 499);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(43, 17);
			this.label15.TabIndex = 39;
			this.label15.Text = "Tick：";
			// 
			// checkBox_sub_format
			// 
			this.checkBox_sub_format.AutoSize = true;
			this.checkBox_sub_format.Location = new System.Drawing.Point(6, 435);
			this.checkBox_sub_format.Name = "checkBox_sub_format";
			this.checkBox_sub_format.Size = new System.Drawing.Size(68, 21);
			this.checkBox_sub_format.TabIndex = 38;
			this.checkBox_sub_format.Text = "Format";
			this.checkBox_sub_format.UseVisualStyleBackColor = true;
			// 
			// checkBox_sub_stop
			// 
			this.checkBox_sub_stop.AutoSize = true;
			this.checkBox_sub_stop.Location = new System.Drawing.Point(6, 408);
			this.checkBox_sub_stop.Name = "checkBox_sub_stop";
			this.checkBox_sub_stop.Size = new System.Drawing.Size(54, 21);
			this.checkBox_sub_stop.TabIndex = 37;
			this.checkBox_sub_stop.Text = "Stop";
			this.checkBox_sub_stop.UseVisualStyleBackColor = true;
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_log.Location = new System.Drawing.Point(94, 377);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(564, 139);
			this.textBox_log.TabIndex = 36;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 381);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 17);
			this.label11.TabIndex = 35;
			this.label11.Text = "Subscribe：";
			// 
			// label_read_tick
			// 
			this.label_read_tick.AutoSize = true;
			this.label_read_tick.ForeColor = System.Drawing.Color.Gray;
			this.label_read_tick.Location = new System.Drawing.Point(622, 167);
			this.label_read_tick.Name = "label_read_tick";
			this.label_read_tick.Size = new System.Drawing.Size(13, 17);
			this.label_read_tick.TabIndex = 34;
			this.label_read_tick.Text = "-";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.ForeColor = System.Drawing.Color.Gray;
			this.label16.Location = new System.Drawing.Point(556, 167);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(43, 17);
			this.label16.TabIndex = 33;
			this.label16.Text = "Tick：";
			// 
			// label_read_byteLength
			// 
			this.label_read_byteLength.AutoSize = true;
			this.label_read_byteLength.ForeColor = System.Drawing.Color.Gray;
			this.label_read_byteLength.Location = new System.Drawing.Point(495, 167);
			this.label_read_byteLength.Name = "label_read_byteLength";
			this.label_read_byteLength.Size = new System.Drawing.Size(13, 17);
			this.label_read_byteLength.TabIndex = 32;
			this.label_read_byteLength.Text = "-";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.Color.Gray;
			this.label14.Location = new System.Drawing.Point(436, 167);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 17);
			this.label14.TabIndex = 31;
			this.label14.Text = "Length：";
			// 
			// label_read_cost
			// 
			this.label_read_cost.AutoSize = true;
			this.label_read_cost.ForeColor = System.Drawing.Color.Gray;
			this.label_read_cost.Location = new System.Drawing.Point(354, 167);
			this.label_read_cost.Name = "label_read_cost";
			this.label_read_cost.Size = new System.Drawing.Size(13, 17);
			this.label_read_cost.TabIndex = 30;
			this.label_read_cost.Text = "-";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.Gray;
			this.label12.Location = new System.Drawing.Point(305, 167);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 17);
			this.label12.TabIndex = 29;
			this.label12.Text = "Cost：";
			// 
			// label_read_time
			// 
			this.label_read_time.AutoSize = true;
			this.label_read_time.ForeColor = System.Drawing.Color.Gray;
			this.label_read_time.Location = new System.Drawing.Point(140, 167);
			this.label_read_time.Name = "label_read_time";
			this.label_read_time.Size = new System.Drawing.Size(13, 17);
			this.label_read_time.TabIndex = 28;
			this.label_read_time.Text = "-";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Gray;
			this.label7.Location = new System.Drawing.Point(91, 167);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 17);
			this.label7.TabIndex = 27;
			this.label7.Text = "Time：";
			// 
			// textBox_read_content
			// 
			this.textBox_read_content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_read_content.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_read_content.Location = new System.Drawing.Point(94, 187);
			this.textBox_read_content.Multiline = true;
			this.textBox_read_content.Name = "textBox_read_content";
			this.textBox_read_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_read_content.Size = new System.Drawing.Size(564, 184);
			this.textBox_read_content.TabIndex = 26;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 191);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 17);
			this.label10.TabIndex = 25;
			this.label10.Text = "Read Result：";
			// 
			// textBox_revision
			// 
			this.textBox_revision.Location = new System.Drawing.Point(175, 21);
			this.textBox_revision.Name = "textBox_revision";
			this.textBox_revision.Size = new System.Drawing.Size(50, 23);
			this.textBox_revision.TabIndex = 18;
			this.textBox_revision.Text = "1";
			// 
			// textBox_dataField
			// 
			this.textBox_dataField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_dataField.Location = new System.Drawing.Point(94, 59);
			this.textBox_dataField.Multiline = true;
			this.textBox_dataField.Name = "textBox_dataField";
			this.textBox_dataField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_dataField.Size = new System.Drawing.Size(564, 103);
			this.textBox_dataField.TabIndex = 24;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 59);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 34);
			this.label8.TabIndex = 23;
			this.label8.Text = "parameters：\r\n多个参数换行";
			// 
			// textBox_spindleID
			// 
			this.textBox_spindleID.Location = new System.Drawing.Point(444, 21);
			this.textBox_spindleID.Name = "textBox_spindleID";
			this.textBox_spindleID.Size = new System.Drawing.Size(48, 23);
			this.textBox_spindleID.TabIndex = 22;
			this.textBox_spindleID.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(367, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 17);
			this.label5.TabIndex = 21;
			this.label5.Text = "spindleId：";
			// 
			// textBox_stationID
			// 
			this.textBox_stationID.Location = new System.Drawing.Point(313, 21);
			this.textBox_stationID.Name = "textBox_stationID";
			this.textBox_stationID.Size = new System.Drawing.Size(48, 23);
			this.textBox_stationID.TabIndex = 20;
			this.textBox_stationID.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(233, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 17);
			this.label4.TabIndex = 19;
			this.label4.Text = "stationId：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(114, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 17);
			this.label2.TabIndex = 17;
			this.label2.Text = "revison：";
			// 
			// button_read_string
			// 
			this.button_read_string.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_read_string.Location = new System.Drawing.Point(524, 19);
			this.button_read_string.Name = "button_read_string";
			this.button_read_string.Size = new System.Drawing.Size(134, 28);
			this.button_read_string.TabIndex = 16;
			this.button_read_string.Text = "read";
			this.button_read_string.UseVisualStyleBackColor = true;
			this.button_read_string.Click += new System.EventHandler(this.Button_read_string_Click);
			// 
			// textBox_mid
			// 
			this.textBox_mid.Location = new System.Drawing.Point(60, 21);
			this.textBox_mid.Name = "textBox_mid";
			this.textBox_mid.Size = new System.Drawing.Size(51, 23);
			this.textBox_mid.TabIndex = 3;
			this.textBox_mid.Text = "10";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 17);
			this.label6.TabIndex = 2;
			this.label6.Text = "MID：";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(991, 528);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "API Test";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox_revison_connect);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(2, 34);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1001, 42);
			this.panel1.TabIndex = 4;
			// 
			// textBox_revison_connect
			// 
			this.textBox_revison_connect.Location = new System.Drawing.Point(549, 9);
			this.textBox_revison_connect.Name = "textBox_revison_connect";
			this.textBox_revison_connect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_revison_connect.Size = new System.Drawing.Size(42, 23);
			this.textBox_revison_connect.TabIndex = 7;
			this.textBox_revison_connect.Text = "1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(402, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(144, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = "RevisonOnConnected：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(898, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "Disconnect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(799, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(331, 9);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_port.Size = new System.Drawing.Size(58, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "4545";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(280, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "port：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(62, 9);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(212, 23);
			this.textBox_ip.TabIndex = 1;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip：";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(600, 10);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(192, 21);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "AutoAckControllerMessage?";
			this.checkBox1.UseVisualStyleBackColor = true;
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
			this.Load += new System.EventHandler(this.FormOpenProtocol_Load);
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_read_string;
        private System.Windows.Forms.TextBox textBox_mid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_revision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_stationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_spindleID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_dataField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox_revison_connect;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_read_content;
		private System.Windows.Forms.Label label10;
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
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox checkBox_sub_format;
		private System.Windows.Forms.Label label_subscribe_tick;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}