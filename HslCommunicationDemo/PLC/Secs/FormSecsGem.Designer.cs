namespace HslCommunicationDemo
{
    partial class FormSecsGem
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_deviceID = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.textBox_data = new System.Windows.Forms.TextBox();
			this.textBox_receive = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.button3 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.checkBox_back = new System.Windows.Forms.CheckBox();
			this.textBox_stream = new System.Windows.Forms.TextBox();
			this.textBox_function = new System.Windows.Forms.TextBox();
			this.button25 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.D = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button_s1f17 = new System.Windows.Forms.Button();
			this.button_s1f15 = new System.Windows.Forms.Button();
			this.button_s1f13 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button_s1f11 = new System.Windows.Forms.Button();
			this.textBox_s1 = new System.Windows.Forms.TextBox();
			this.button_S1F1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage_s2 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.textBox_s2 = new System.Windows.Forms.TextBox();
			this.button_s2f13 = new System.Windows.Forms.Button();
			this.tabControl_buttom = new System.Windows.Forms.TabControl();
			this.tabPage_log = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNewSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage_s2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl_buttom.SuspendLayout();
			this.tabPage_log.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox_deviceID);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1004, 38);
			this.panel1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "ASCII",
            "Default",
            "UTF8",
            "Unicode",
            "GB2312"});
			this.comboBox1.Location = new System.Drawing.Point(668, 4);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 25);
			this.comboBox1.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(600, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 17);
			this.label5.TabIndex = 13;
			this.label5.Text = "Encode：";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(458, 8);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(136, 21);
			this.checkBox2.TabIndex = 12;
			this.checkBox2.Text = "初始化时发送 S0F0?";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(250, 6);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(76, 23);
			this.textBox_port.TabIndex = 11;
			this.textBox_port.Text = "5000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(196, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "端口号：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(62, 6);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(128, 23);
			this.textBox_ip.TabIndex = 9;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Ip地址：";
			// 
			// textBox_deviceID
			// 
			this.textBox_deviceID.Location = new System.Drawing.Point(408, 6);
			this.textBox_deviceID.Name = "textBox_deviceID";
			this.textBox_deviceID.Size = new System.Drawing.Size(44, 23);
			this.textBox_deviceID.TabIndex = 7;
			this.textBox_deviceID.Text = "1";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(332, 9);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(71, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "DeviceID：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(875, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(778, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Location = new System.Drawing.Point(3, 76);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1004, 602);
			this.panel2.TabIndex = 1;
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
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl_buttom);
			this.splitContainer1.Size = new System.Drawing.Size(1002, 600);
			this.splitContainer1.SplitterDistance = 346;
			this.splitContainer1.TabIndex = 7;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage_s2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1002, 346);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.splitContainer2);
			this.tabPage1.Controls.Add(this.treeView1);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.checkBox_back);
			this.tabPage1.Controls.Add(this.textBox_stream);
			this.tabPage1.Controls.Add(this.textBox_function);
			this.tabPage1.Controls.Add(this.button25);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.D);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(994, 316);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Base";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer2.Location = new System.Drawing.Point(325, 51);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.textBox_data);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.textBox_receive);
			this.splitContainer2.Size = new System.Drawing.Size(663, 277);
			this.splitContainer2.SplitterDistance = 297;
			this.splitContainer2.TabIndex = 26;
			// 
			// textBox_data
			// 
			this.textBox_data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_data.Location = new System.Drawing.Point(0, 0);
			this.textBox_data.Multiline = true;
			this.textBox_data.Name = "textBox_data";
			this.textBox_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_data.Size = new System.Drawing.Size(297, 277);
			this.textBox_data.TabIndex = 20;
			// 
			// textBox_receive
			// 
			this.textBox_receive.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_receive.Location = new System.Drawing.Point(0, 0);
			this.textBox_receive.Multiline = true;
			this.textBox_receive.Name = "textBox_receive";
			this.textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_receive.Size = new System.Drawing.Size(362, 277);
			this.textBox_receive.TabIndex = 12;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(5, 6);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(311, 322);
			this.treeView1.TabIndex = 24;
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(718, 5);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(87, 28);
			this.button3.TabIndex = 22;
			this.button3.Text = "仅发送";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(322, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 17);
			this.label11.TabIndex = 4;
			this.label11.Text = "Stream：";
			// 
			// checkBox_back
			// 
			this.checkBox_back.AutoSize = true;
			this.checkBox_back.Location = new System.Drawing.Point(564, 9);
			this.checkBox_back.Name = "checkBox_back";
			this.checkBox_back.Size = new System.Drawing.Size(105, 21);
			this.checkBox_back.TabIndex = 21;
			this.checkBox_back.Text = "W? [必须回复]";
			this.checkBox_back.UseVisualStyleBackColor = true;
			// 
			// textBox_stream
			// 
			this.textBox_stream.Location = new System.Drawing.Point(384, 7);
			this.textBox_stream.Name = "textBox_stream";
			this.textBox_stream.Size = new System.Drawing.Size(49, 23);
			this.textBox_stream.TabIndex = 5;
			this.textBox_stream.Text = "1";
			// 
			// textBox_function
			// 
			this.textBox_function.Location = new System.Drawing.Point(506, 7);
			this.textBox_function.Name = "textBox_function";
			this.textBox_function.Size = new System.Drawing.Size(51, 23);
			this.textBox_function.TabIndex = 7;
			this.textBox_function.Text = "1";
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(811, 5);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(95, 28);
			this.button25.TabIndex = 8;
			this.button25.Text = "应答";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(439, 10);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 17);
			this.label12.TabIndex = 6;
			this.label12.Text = "Function：";
			// 
			// D
			// 
			this.D.AutoSize = true;
			this.D.Location = new System.Drawing.Point(325, 31);
			this.D.Name = "D";
			this.D.Size = new System.Drawing.Size(47, 17);
			this.D.TabIndex = 19;
			this.D.Text = "Data：";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(941, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "结果：";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.button_s1f17);
			this.tabPage2.Controls.Add(this.button_s1f15);
			this.tabPage2.Controls.Add(this.button_s1f13);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Controls.Add(this.button_s1f11);
			this.tabPage2.Controls.Add(this.textBox_s1);
			this.tabPage2.Controls.Add(this.button_S1F1);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(994, 320);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "S1";
			// 
			// button_s1f17
			// 
			this.button_s1f17.Location = new System.Drawing.Point(10, 152);
			this.button_s1f17.Name = "button_s1f17";
			this.button_s1f17.Size = new System.Drawing.Size(222, 30);
			this.button_s1f17.TabIndex = 29;
			this.button_s1f17.Text = "S1F17-OnlineRequest";
			this.button_s1f17.UseVisualStyleBackColor = true;
			this.button_s1f17.Click += new System.EventHandler(this.button_s1f17_Click);
			// 
			// button_s1f15
			// 
			this.button_s1f15.Location = new System.Drawing.Point(10, 116);
			this.button_s1f15.Name = "button_s1f15";
			this.button_s1f15.Size = new System.Drawing.Size(222, 30);
			this.button_s1f15.TabIndex = 28;
			this.button_s1f15.Text = "S1F15-OfflineRequest";
			this.button_s1f15.UseVisualStyleBackColor = true;
			this.button_s1f15.Click += new System.EventHandler(this.button_s1f15_Click);
			// 
			// button_s1f13
			// 
			this.button_s1f13.Location = new System.Drawing.Point(10, 80);
			this.button_s1f13.Name = "button_s1f13";
			this.button_s1f13.Size = new System.Drawing.Size(222, 30);
			this.button_s1f13.TabIndex = 27;
			this.button_s1f13.Text = "S1F13-EstablishCommunications";
			this.button_s1f13.UseVisualStyleBackColor = true;
			this.button_s1f13.Click += new System.EventHandler(this.button_s1f13_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(282, 48);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(194, 23);
			this.textBox4.TabIndex = 25;
			// 
			// button_s1f11
			// 
			this.button_s1f11.Location = new System.Drawing.Point(10, 44);
			this.button_s1f11.Name = "button_s1f11";
			this.button_s1f11.Size = new System.Drawing.Size(222, 30);
			this.button_s1f11.TabIndex = 24;
			this.button_s1f11.Text = "S1F11-StatusVariableNamelist";
			this.button_s1f11.UseVisualStyleBackColor = true;
			this.button_s1f11.Click += new System.EventHandler(this.button_s1f11_Click);
			// 
			// textBox_s1
			// 
			this.textBox_s1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_s1.Location = new System.Drawing.Point(729, 6);
			this.textBox_s1.Multiline = true;
			this.textBox_s1.Name = "textBox_s1";
			this.textBox_s1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_s1.Size = new System.Drawing.Size(259, 303);
			this.textBox_s1.TabIndex = 23;
			// 
			// button_S1F1
			// 
			this.button_S1F1.Location = new System.Drawing.Point(10, 8);
			this.button_S1F1.Name = "button_S1F1";
			this.button_S1F1.Size = new System.Drawing.Size(222, 30);
			this.button_S1F1.TabIndex = 0;
			this.button_S1F1.Text = "S1F1-AreYouThere";
			this.button_S1F1.UseVisualStyleBackColor = true;
			this.button_S1F1.Click += new System.EventHandler(this.button_S1F1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(240, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 17);
			this.label4.TabIndex = 26;
			this.label4.Text = "VIDs:";
			// 
			// tabPage_s2
			// 
			this.tabPage_s2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage_s2.Controls.Add(this.panel3);
			this.tabPage_s2.Location = new System.Drawing.Point(4, 22);
			this.tabPage_s2.Name = "tabPage_s2";
			this.tabPage_s2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_s2.Size = new System.Drawing.Size(994, 320);
			this.tabPage_s2.TabIndex = 2;
			this.tabPage_s2.Text = "S2";
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.Controls.Add(this.textBox_s2);
			this.panel3.Controls.Add(this.button_s2f13);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(988, 314);
			this.panel3.TabIndex = 0;
			// 
			// textBox_s2
			// 
			this.textBox_s2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_s2.Location = new System.Drawing.Point(726, 3);
			this.textBox_s2.Multiline = true;
			this.textBox_s2.Name = "textBox_s2";
			this.textBox_s2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_s2.Size = new System.Drawing.Size(259, 312);
			this.textBox_s2.TabIndex = 24;
			// 
			// button_s2f13
			// 
			this.button_s2f13.Location = new System.Drawing.Point(8, 7);
			this.button_s2f13.Name = "button_s2f13";
			this.button_s2f13.Size = new System.Drawing.Size(222, 30);
			this.button_s2f13.TabIndex = 1;
			this.button_s2f13.Text = "S2F13-EquipmentConstant";
			this.button_s2f13.UseVisualStyleBackColor = true;
			this.button_s2f13.Click += new System.EventHandler(this.button_s2f13_Click);
			// 
			// tabControl_buttom
			// 
			this.tabControl_buttom.Controls.Add(this.tabPage_log);
			this.tabControl_buttom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_buttom.Location = new System.Drawing.Point(0, 0);
			this.tabControl_buttom.Name = "tabControl_buttom";
			this.tabControl_buttom.SelectedIndex = 0;
			this.tabControl_buttom.Size = new System.Drawing.Size(1002, 250);
			this.tabControl_buttom.TabIndex = 3;
			// 
			// tabPage_log
			// 
			this.tabPage_log.Controls.Add(this.button4);
			this.tabPage_log.Controls.Add(this.textBox_log);
			this.tabPage_log.Controls.Add(this.label13);
			this.tabPage_log.Controls.Add(this.checkBox1);
			this.tabPage_log.Location = new System.Drawing.Point(4, 26);
			this.tabPage_log.Name = "tabPage_log";
			this.tabPage_log.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_log.Size = new System.Drawing.Size(994, 220);
			this.tabPage_log.TabIndex = 0;
			this.tabPage_log.Text = "日志";
			this.tabPage_log.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(3, 58);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(55, 26);
			this.button4.TabIndex = 16;
			this.button4.Text = "clear";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click_1);
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Location = new System.Drawing.Point(62, 6);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(926, 208);
			this.textBox_log.TabIndex = 10;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(4, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 9;
			this.label13.Text = "接收：";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 30);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(58, 21);
			this.checkBox1.TabIndex = 15;
			this.checkBox1.Text = "STOP";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Secs gem HSMS";
			this.userControlHead1.Size = new System.Drawing.Size(1011, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSecsItemToolStripMenuItem,
            this.editSecsItemToolStripMenuItem,
            this.deleteSecsItemToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(179, 70);
			// 
			// addNewSecsItemToolStripMenuItem
			// 
			this.addNewSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_add_16xLG;
			this.addNewSecsItemToolStripMenuItem.Name = "addNewSecsItemToolStripMenuItem";
			this.addNewSecsItemToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.addNewSecsItemToolStripMenuItem.Text = "AddNewSecsItem";
			this.addNewSecsItemToolStripMenuItem.Click += new System.EventHandler(this.addNewSecsItemToolStripMenuItem_Click);
			// 
			// editSecsItemToolStripMenuItem
			// 
			this.editSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.sig;
			this.editSecsItemToolStripMenuItem.Name = "editSecsItemToolStripMenuItem";
			this.editSecsItemToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.editSecsItemToolStripMenuItem.Text = "EditSecsItem";
			this.editSecsItemToolStripMenuItem.Click += new System.EventHandler(this.editSecsItemToolStripMenuItem_Click);
			// 
			// deleteSecsItemToolStripMenuItem
			// 
			this.deleteSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_Cancel_16xLG;
			this.deleteSecsItemToolStripMenuItem.Name = "deleteSecsItemToolStripMenuItem";
			this.deleteSecsItemToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.deleteSecsItemToolStripMenuItem.Text = "DeleteSecsItem";
			this.deleteSecsItemToolStripMenuItem.Click += new System.EventHandler(this.deleteSecsItemToolStripMenuItem_Click);
			// 
			// FormSecsGem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1011, 681);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormSecsGem";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Secs/Gem访问Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage_s2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tabControl_buttom.ResumeLayout(false);
			this.tabPage_log.ResumeLayout(false);
			this.tabPage_log.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.TextBox textBox_function;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_stream;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_deviceID;
        private System.Windows.Forms.Label label21;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_receive;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox_data;
		private System.Windows.Forms.Label D;
		private System.Windows.Forms.CheckBox checkBox_back;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button button_S1F1;
		private System.Windows.Forms.TextBox textBox_s1;
		private System.Windows.Forms.Button button_s1f11;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button_s1f13;
		private System.Windows.Forms.Button button_s1f15;
		private System.Windows.Forms.Button button_s1f17;
		private System.Windows.Forms.TabPage tabPage_s2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBox_s2;
		private System.Windows.Forms.Button button_s2f13;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TabControl tabControl_buttom;
		private System.Windows.Forms.TabPage tabPage_log;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addNewSecsItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editSecsItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteSecsItemToolStripMenuItem;
	}
}