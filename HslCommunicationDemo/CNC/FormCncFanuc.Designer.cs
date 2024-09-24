namespace HslCommunicationDemo
{
    partial class FormCncFanuc
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
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("CNC_MEM");
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.label_code = new System.Windows.Forms.Label();
			this.button42 = new System.Windows.Forms.Button();
			this.button41 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.button40 = new System.Windows.Forms.Button();
			this.textBox_diagnoss_axis = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.textBox_diagnoss_length = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.button39 = new System.Windows.Forms.Button();
			this.textBox_read_diagnoss = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.button38 = new System.Windows.Forms.Button();
			this.button37 = new System.Windows.Forms.Button();
			this.button36 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button35 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_op_path = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.button34 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button32 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox_pmc_Data = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_pmc_write = new System.Windows.Forms.TextBox();
			this.button31 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_pmc_read = new System.Windows.Forms.TextBox();
			this.button23 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_pmc_length = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button30 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button26 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button24 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button22 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button21 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button20 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button15 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.button16 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox_code2 = new System.Windows.Forms.TextBox();
			this.label_code2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.button29 = new System.Windows.Forms.Button();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox_path = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.button28 = new System.Windows.Forms.Button();
			this.textBox_program = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button25 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.button27 = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.button33 = new System.Windows.Forms.Button();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AddNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.readNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.readNcLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox11);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(4, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 38);
			this.panel1.TabIndex = 7;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(446, 6);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(79, 23);
			this.textBox11.TabIndex = 15;
			this.textBox11.Text = "5000";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(380, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "接收超时：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(664, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(567, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(279, 6);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(79, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "8193";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(225, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 6);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(141, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "192.168.64.129";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip地址：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Location = new System.Drawing.Point(4, 79);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(992, 571);
			this.panel2.TabIndex = 13;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(989, 568);
			this.tabControl1.TabIndex = 71;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox_code);
			this.tabPage1.Controls.Add(this.label_code);
			this.tabPage1.Controls.Add(this.button42);
			this.tabPage1.Controls.Add(this.button41);
			this.tabPage1.Controls.Add(this.textBox5);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.button40);
			this.tabPage1.Controls.Add(this.textBox_diagnoss_axis);
			this.tabPage1.Controls.Add(this.label19);
			this.tabPage1.Controls.Add(this.textBox_diagnoss_length);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.button39);
			this.tabPage1.Controls.Add(this.textBox_read_diagnoss);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.button38);
			this.tabPage1.Controls.Add(this.button37);
			this.tabPage1.Controls.Add(this.button36);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.button35);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.textBox_op_path);
			this.tabPage1.Controls.Add(this.textBox8);
			this.tabPage1.Controls.Add(this.button34);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button32);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Controls.Add(this.button6);
			this.tabPage1.Controls.Add(this.button30);
			this.tabPage1.Controls.Add(this.button7);
			this.tabPage1.Controls.Add(this.button26);
			this.tabPage1.Controls.Add(this.button8);
			this.tabPage1.Controls.Add(this.button24);
			this.tabPage1.Controls.Add(this.button9);
			this.tabPage1.Controls.Add(this.button22);
			this.tabPage1.Controls.Add(this.button10);
			this.tabPage1.Controls.Add(this.button21);
			this.tabPage1.Controls.Add(this.button11);
			this.tabPage1.Controls.Add(this.button20);
			this.tabPage1.Controls.Add(this.button12);
			this.tabPage1.Controls.Add(this.button19);
			this.tabPage1.Controls.Add(this.button13);
			this.tabPage1.Controls.Add(this.button18);
			this.tabPage1.Controls.Add(this.button14);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.button15);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.button16);
			this.tabPage1.Controls.Add(this.button17);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(981, 538);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "基本操作";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(64, 471);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(909, 61);
			this.textBox_code.TabIndex = 89;
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(7, 476);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(51, 17);
			this.label_code.TabIndex = 88;
			this.label_code.Text = "Code：";
			// 
			// button42
			// 
			this.button42.Location = new System.Drawing.Point(838, 176);
			this.button42.Name = "button42";
			this.button42.Size = new System.Drawing.Size(96, 29);
			this.button42.TabIndex = 87;
			this.button42.Text = "清除刀组号";
			this.button42.UseVisualStyleBackColor = true;
			this.button42.Click += new System.EventHandler(this.button42_Click);
			// 
			// button41
			// 
			this.button41.Location = new System.Drawing.Point(736, 176);
			this.button41.Name = "button41";
			this.button41.Size = new System.Drawing.Size(96, 29);
			this.button41.TabIndex = 86;
			this.button41.Text = "读刀组寿命";
			this.button41.UseVisualStyleBackColor = true;
			this.button41.Click += new System.EventHandler(this.button41_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(675, 179);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(55, 23);
			this.textBox5.TabIndex = 85;
			this.textBox5.Text = "2";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(619, 182);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 17);
			this.label20.TabIndex = 84;
			this.label20.Text = "刀组号：";
			// 
			// button40
			// 
			this.button40.Location = new System.Drawing.Point(4, 180);
			this.button40.Name = "button40";
			this.button40.Size = new System.Drawing.Size(96, 29);
			this.button40.TabIndex = 83;
			this.button40.Text = "读当前刀组";
			this.button40.UseVisualStyleBackColor = true;
			this.button40.Click += new System.EventHandler(this.button40_Click);
			// 
			// textBox_diagnoss_axis
			// 
			this.textBox_diagnoss_axis.Location = new System.Drawing.Point(451, 185);
			this.textBox_diagnoss_axis.Name = "textBox_diagnoss_axis";
			this.textBox_diagnoss_axis.Size = new System.Drawing.Size(44, 23);
			this.textBox_diagnoss_axis.TabIndex = 82;
			this.textBox_diagnoss_axis.Text = "-1";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(402, 188);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(32, 17);
			this.label19.TabIndex = 81;
			this.label19.Text = "轴：";
			// 
			// textBox_diagnoss_length
			// 
			this.textBox_diagnoss_length.Location = new System.Drawing.Point(352, 185);
			this.textBox_diagnoss_length.Name = "textBox_diagnoss_length";
			this.textBox_diagnoss_length.Size = new System.Drawing.Size(44, 23);
			this.textBox_diagnoss_length.TabIndex = 80;
			this.textBox_diagnoss_length.Text = "1";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(303, 188);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(44, 17);
			this.label18.TabIndex = 79;
			this.label18.Text = "长度：";
			// 
			// button39
			// 
			this.button39.Location = new System.Drawing.Point(502, 182);
			this.button39.Name = "button39";
			this.button39.Size = new System.Drawing.Size(96, 29);
			this.button39.TabIndex = 78;
			this.button39.Text = "读诊断";
			this.button39.UseVisualStyleBackColor = true;
			this.button39.Click += new System.EventHandler(this.button39_Click);
			// 
			// textBox_read_diagnoss
			// 
			this.textBox_read_diagnoss.Location = new System.Drawing.Point(247, 185);
			this.textBox_read_diagnoss.Name = "textBox_read_diagnoss";
			this.textBox_read_diagnoss.Size = new System.Drawing.Size(52, 23);
			this.textBox_read_diagnoss.TabIndex = 77;
			this.textBox_read_diagnoss.Text = "308";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(189, 188);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 17);
			this.label17.TabIndex = 76;
			this.label17.Text = "诊断号：";
			// 
			// button38
			// 
			this.button38.Location = new System.Drawing.Point(804, 74);
			this.button38.Name = "button38";
			this.button38.Size = new System.Drawing.Size(96, 29);
			this.button38.TabIndex = 75;
			this.button38.Text = "主轴名称";
			this.button38.UseVisualStyleBackColor = true;
			this.button38.Click += new System.EventHandler(this.button38_Click);
			// 
			// button37
			// 
			this.button37.Location = new System.Drawing.Point(704, 74);
			this.button37.Name = "button37";
			this.button37.Size = new System.Drawing.Size(96, 29);
			this.button37.TabIndex = 74;
			this.button37.Text = "轴名称列表";
			this.button37.UseVisualStyleBackColor = true;
			this.button37.Click += new System.EventHandler(this.button37_Click);
			// 
			// button36
			// 
			this.button36.Location = new System.Drawing.Point(848, 141);
			this.button36.Name = "button36";
			this.button36.Size = new System.Drawing.Size(96, 29);
			this.button36.TabIndex = 73;
			this.button36.Text = "写宏变量";
			this.button36.UseVisualStyleBackColor = true;
			this.button36.Click += new System.EventHandler(this.button36_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(675, 144);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(167, 23);
			this.textBox4.TabIndex = 72;
			this.textBox4.Text = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(621, 148);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 17);
			this.label16.TabIndex = 71;
			this.label16.Text = "值：";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(4, 4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 29);
			this.button3.TabIndex = 20;
			this.button3.Text = "系统状态";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button35
			// 
			this.button35.Location = new System.Drawing.Point(877, 39);
			this.button35.Name = "button35";
			this.button35.Size = new System.Drawing.Size(96, 29);
			this.button35.TabIndex = 70;
			this.button35.Text = "设置路径";
			this.button35.UseVisualStyleBackColor = true;
			this.button35.Click += new System.EventHandler(this.button35_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 214);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 17);
			this.label12.TabIndex = 19;
			this.label12.Text = "receive：";
			// 
			// textBox_op_path
			// 
			this.textBox_op_path.Location = new System.Drawing.Point(806, 42);
			this.textBox_op_path.Name = "textBox_op_path";
			this.textBox_op_path.Size = new System.Drawing.Size(65, 23);
			this.textBox_op_path.TabIndex = 69;
			this.textBox_op_path.Text = "1";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(6, 239);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(967, 228);
			this.textBox8.TabIndex = 18;
			// 
			// button34
			// 
			this.button34.Location = new System.Drawing.Point(504, 74);
			this.button34.Name = "button34";
			this.button34.Size = new System.Drawing.Size(96, 29);
			this.button34.TabIndex = 68;
			this.button34.Text = "操作信息";
			this.button34.UseVisualStyleBackColor = true;
			this.button34.Click += new System.EventHandler(this.button34_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(104, 4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 29);
			this.button4.TabIndex = 21;
			this.button4.Text = "报警信息";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button32
			// 
			this.button32.Location = new System.Drawing.Point(604, 74);
			this.button32.Name = "button32";
			this.button32.Size = new System.Drawing.Size(96, 29);
			this.button32.TabIndex = 64;
			this.button32.Text = "系统信息";
			this.button32.UseVisualStyleBackColor = true;
			this.button32.Click += new System.EventHandler(this.button32_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(204, 4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 29);
			this.button5.TabIndex = 22;
			this.button5.Text = "坐标数据";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
			this.panel3.Controls.Add(this.label13);
			this.panel3.Controls.Add(this.textBox_pmc_Data);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.textBox_pmc_write);
			this.panel3.Controls.Add(this.button31);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.textBox_pmc_read);
			this.panel3.Controls.Add(this.button23);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.textBox_pmc_length);
			this.panel3.Location = new System.Drawing.Point(6, 109);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(592, 66);
			this.panel3.TabIndex = 61;
			this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(344, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(181, 17);
			this.label13.TabIndex = 68;
			this.label13.Text = "Support: G,F,Y,X,A,R,T,K,C,D,E ";
			// 
			// textBox_pmc_Data
			// 
			this.textBox_pmc_Data.Location = new System.Drawing.Point(169, 36);
			this.textBox_pmc_Data.Name = "textBox_pmc_Data";
			this.textBox_pmc_Data.Size = new System.Drawing.Size(309, 23);
			this.textBox_pmc_Data.TabIndex = 67;
			this.textBox_pmc_Data.Text = "01 02";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 39);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 17);
			this.label10.TabIndex = 61;
			this.label10.Text = "起始：";
			// 
			// textBox_pmc_write
			// 
			this.textBox_pmc_write.Location = new System.Drawing.Point(48, 36);
			this.textBox_pmc_write.Name = "textBox_pmc_write";
			this.textBox_pmc_write.Size = new System.Drawing.Size(65, 23);
			this.textBox_pmc_write.TabIndex = 62;
			this.textBox_pmc_write.Text = "R1200";
			// 
			// button31
			// 
			this.button31.Location = new System.Drawing.Point(492, 33);
			this.button31.Name = "button31";
			this.button31.Size = new System.Drawing.Size(96, 29);
			this.button31.TabIndex = 63;
			this.button31.Text = "写数据";
			this.button31.UseVisualStyleBackColor = true;
			this.button31.Click += new System.EventHandler(this.button31_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(119, 39);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 64;
			this.label11.Text = "数据：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 42;
			this.label4.Text = "起始：";
			// 
			// textBox_pmc_read
			// 
			this.textBox_pmc_read.Location = new System.Drawing.Point(48, 7);
			this.textBox_pmc_read.Name = "textBox_pmc_read";
			this.textBox_pmc_read.Size = new System.Drawing.Size(65, 23);
			this.textBox_pmc_read.TabIndex = 43;
			this.textBox_pmc_read.Text = "R1200";
			// 
			// button23
			// 
			this.button23.Location = new System.Drawing.Point(242, 4);
			this.button23.Name = "button23";
			this.button23.Size = new System.Drawing.Size(96, 29);
			this.button23.TabIndex = 44;
			this.button23.Text = "读数据";
			this.button23.UseVisualStyleBackColor = true;
			this.button23.Click += new System.EventHandler(this.button23_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(119, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 45;
			this.label6.Text = "长度：";
			// 
			// textBox_pmc_length
			// 
			this.textBox_pmc_length.Location = new System.Drawing.Point(168, 7);
			this.textBox_pmc_length.Name = "textBox_pmc_length";
			this.textBox_pmc_length.Size = new System.Drawing.Size(62, 23);
			this.textBox_pmc_length.TabIndex = 46;
			this.textBox_pmc_length.Text = "10";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(304, 4);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 29);
			this.button6.TabIndex = 23;
			this.button6.Text = "程序列表";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button30
			// 
			this.button30.Location = new System.Drawing.Point(404, 74);
			this.button30.Name = "button30";
			this.button30.Size = new System.Drawing.Size(96, 29);
			this.button30.TabIndex = 59;
			this.button30.Text = "当前刀具号";
			this.button30.UseVisualStyleBackColor = true;
			this.button30.Click += new System.EventHandler(this.button30_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(404, 4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(96, 29);
			this.button7.TabIndex = 24;
			this.button7.Text = "当前程序名";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button26
			// 
			this.button26.Location = new System.Drawing.Point(704, 39);
			this.button26.Name = "button26";
			this.button26.Size = new System.Drawing.Size(96, 29);
			this.button26.TabIndex = 51;
			this.button26.Text = "启动加工";
			this.button26.UseVisualStyleBackColor = true;
			this.button26.Click += new System.EventHandler(this.button26_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(504, 4);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(96, 29);
			this.button8.TabIndex = 25;
			this.button8.Text = "主轴转速进给";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button24
			// 
			this.button24.Location = new System.Drawing.Point(604, 39);
			this.button24.Name = "button24";
			this.button24.Size = new System.Drawing.Size(96, 29);
			this.button24.TabIndex = 47;
			this.button24.Text = "读当前程序";
			this.button24.UseVisualStyleBackColor = true;
			this.button24.Click += new System.EventHandler(this.button24_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(604, 4);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(96, 29);
			this.button9.TabIndex = 26;
			this.button9.Text = "伺服负载";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button22
			// 
			this.button22.Location = new System.Drawing.Point(504, 39);
			this.button22.Name = "button22";
			this.button22.Size = new System.Drawing.Size(96, 29);
			this.button22.TabIndex = 41;
			this.button22.Text = "系统语言";
			this.button22.UseVisualStyleBackColor = true;
			this.button22.Click += new System.EventHandler(this.button22_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(704, 4);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(96, 29);
			this.button10.TabIndex = 27;
			this.button10.Text = "刀具补偿";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(404, 39);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(96, 29);
			this.button21.TabIndex = 40;
			this.button21.Text = "总加工数量";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += new System.EventHandler(this.button21_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(804, 4);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(96, 29);
			this.button11.TabIndex = 28;
			this.button11.Text = "程序路径";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button20
			// 
			this.button20.Location = new System.Drawing.Point(304, 39);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(96, 29);
			this.button20.TabIndex = 39;
			this.button20.Text = "已加工数量";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += new System.EventHandler(this.button20_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(4, 39);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(96, 29);
			this.button12.TabIndex = 29;
			this.button12.Text = "工件尺寸";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(204, 39);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(96, 29);
			this.button19.TabIndex = 38;
			this.button19.Text = "机床时间";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new System.EventHandler(this.button19_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(104, 39);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(96, 29);
			this.button13.TabIndex = 30;
			this.button13.Text = "报警代号";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(848, 109);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(96, 29);
			this.button18.TabIndex = 37;
			this.button18.Text = "读宏变量";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.button18_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(4, 74);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(96, 29);
			this.button14.TabIndex = 31;
			this.button14.Text = "开机时间";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(675, 112);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(167, 23);
			this.textBox3.TabIndex = 36;
			this.textBox3.Text = "4320";
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(104, 74);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(96, 29);
			this.button15.TabIndex = 32;
			this.button15.Text = "运行时间";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(621, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 35;
			this.label2.Text = "宏变量：";
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(204, 74);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(96, 29);
			this.button16.TabIndex = 33;
			this.button16.Text = "切削时间";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new System.EventHandler(this.button16_Click);
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(304, 74);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(96, 29);
			this.button17.TabIndex = 34;
			this.button17.Text = "循环时间";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new System.EventHandler(this.button17_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox_code2);
			this.tabPage2.Controls.Add(this.label_code2);
			this.tabPage2.Controls.Add(this.panel4);
			this.tabPage2.Controls.Add(this.textBox_program);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.button25);
			this.tabPage2.Controls.Add(this.textBox6);
			this.tabPage2.Controls.Add(this.button27);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.treeView1);
			this.tabPage2.Controls.Add(this.textBox7);
			this.tabPage2.Controls.Add(this.button33);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1004, 551);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "程序上传下载";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox_code2
			// 
			this.textBox_code2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code2.Location = new System.Drawing.Point(56, 499);
			this.textBox_code2.Multiline = true;
			this.textBox_code2.Name = "textBox_code2";
			this.textBox_code2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code2.Size = new System.Drawing.Size(944, 46);
			this.textBox_code2.TabIndex = 71;
			// 
			// label_code2
			// 
			this.label_code2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code2.AutoSize = true;
			this.label_code2.Location = new System.Drawing.Point(8, 502);
			this.label_code2.Name = "label_code2";
			this.label_code2.Size = new System.Drawing.Size(44, 17);
			this.label_code2.TabIndex = 70;
			this.label_code2.Text = "代码：";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.AliceBlue;
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.button29);
			this.panel4.Controls.Add(this.textBox9);
			this.panel4.Controls.Add(this.textBox_path);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.button28);
			this.panel4.Location = new System.Drawing.Point(3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(388, 62);
			this.panel4.TabIndex = 69;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(5, 7);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(51, 17);
			this.label14.TabIndex = 62;
			this.label14.Text = "PATH：";
			// 
			// button29
			// 
			this.button29.Location = new System.Drawing.Point(177, 28);
			this.button29.Name = "button29";
			this.button29.Size = new System.Drawing.Size(96, 29);
			this.button29.TabIndex = 58;
			this.button29.Text = "删除程序";
			this.button29.UseVisualStyleBackColor = true;
			this.button29.Click += new System.EventHandler(this.button29_Click);
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(59, 31);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(105, 23);
			this.textBox9.TabIndex = 57;
			this.textBox9.Text = "O33";
			// 
			// textBox_path
			// 
			this.textBox_path.Location = new System.Drawing.Point(59, 4);
			this.textBox_path.Name = "textBox_path";
			this.textBox_path.Size = new System.Drawing.Size(316, 23);
			this.textBox_path.TabIndex = 63;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 56;
			this.label9.Text = "程序号：";
			// 
			// button28
			// 
			this.button28.Location = new System.Drawing.Point(279, 28);
			this.button28.Name = "button28";
			this.button28.Size = new System.Drawing.Size(96, 29);
			this.button28.TabIndex = 55;
			this.button28.Text = "读取程序";
			this.button28.UseVisualStyleBackColor = true;
			this.button28.Click += new System.EventHandler(this.button28_Click);
			// 
			// textBox_program
			// 
			this.textBox_program.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_program.Location = new System.Drawing.Point(215, 99);
			this.textBox_program.Multiline = true;
			this.textBox_program.Name = "textBox_program";
			this.textBox_program.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_program.Size = new System.Drawing.Size(783, 397);
			this.textBox_program.TabIndex = 68;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(397, 67);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 17);
			this.label7.TabIndex = 49;
			this.label7.Text = "程序号：";
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(563, 61);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(122, 29);
			this.button25.TabIndex = 48;
			this.button25.Text = "设为主程序";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(451, 64);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(105, 23);
			this.textBox6.TabIndex = 50;
			this.textBox6.Text = "33";
			// 
			// button27
			// 
			this.button27.Location = new System.Drawing.Point(877, 28);
			this.button27.Name = "button27";
			this.button27.Size = new System.Drawing.Size(96, 29);
			this.button27.TabIndex = 52;
			this.button27.Text = "下传程序";
			this.button27.UseVisualStyleBackColor = true;
			this.button27.Click += new System.EventHandler(this.button27_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.Green;
			this.label15.Location = new System.Drawing.Point(94, 73);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(80, 17);
			this.label15.TabIndex = 67;
			this.label15.Text = "右键菜单操作";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(397, 11);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 17);
			this.label8.TabIndex = 53;
			this.label8.Text = "程序文件：";
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(5, 99);
			this.treeView1.Name = "treeView1";
			treeNode2.Name = "节点0";
			treeNode2.Text = "CNC_MEM";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
			this.treeView1.Size = new System.Drawing.Size(204, 397);
			this.treeView1.TabIndex = 66;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(400, 31);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(471, 23);
			this.textBox7.TabIndex = 54;
			this.textBox7.Text = "06.txt";
			// 
			// button33
			// 
			this.button33.Location = new System.Drawing.Point(4, 70);
			this.button33.Name = "button33";
			this.button33.Size = new System.Drawing.Size(83, 23);
			this.button33.TabIndex = 65;
			this.button33.Text = "路径信息";
			this.button33.UseVisualStyleBackColor = true;
			this.button33.Click += new System.EventHandler(this.button33_Click);
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
			this.userControlHead1.ProtocolInfo = "Fanuc Series 0iD/0iF/30i/31i/32i/35i 等新系统";
			this.userControlHead1.Size = new System.Drawing.Size(1000, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNCToolStripMenuItem,
            this.readNCToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.readNcLocalToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(155, 92);
			// 
			// AddNCToolStripMenuItem
			// 
			this.AddNCToolStripMenuItem.Name = "AddNCToolStripMenuItem";
			this.AddNCToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.AddNCToolStripMenuItem.Text = "添加NC程序";
			// 
			// readNCToolStripMenuItem
			// 
			this.readNCToolStripMenuItem.Name = "readNCToolStripMenuItem";
			this.readNCToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.readNCToolStripMenuItem.Text = "读取NC程序";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.deleteToolStripMenuItem.Text = "删除文件";
			// 
			// readNcLocalToolStripMenuItem
			// 
			this.readNcLocalToolStripMenuItem.Name = "readNcLocalToolStripMenuItem";
			this.readNcLocalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.readNcLocalToolStripMenuItem.Text = "读取NC到本地";
			// 
			// FormCncFanuc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1000, 653);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormCncFanuc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fanuc0i客户端";
			this.Load += new System.EventHandler(this.FormClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label12;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button22;
        private System.Windows.Forms.TextBox textBox_pmc_length;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TextBox textBox_pmc_read;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button24;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button25;
		private System.Windows.Forms.Button button26;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button27;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button28;
		private System.Windows.Forms.Button button29;
		private System.Windows.Forms.Button button30;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBox_pmc_Data;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox_pmc_write;
		private System.Windows.Forms.Button button31;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox_path;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button32;
		private System.Windows.Forms.Button button33;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem AddNCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readNCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button34;
		private System.Windows.Forms.Button button35;
		private System.Windows.Forms.TextBox textBox_op_path;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox textBox_program;
		private System.Windows.Forms.Button button36;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
		private System.Windows.Forms.TextBox textBox_diagnoss_length;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button button39;
		private System.Windows.Forms.TextBox textBox_read_diagnoss;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox_diagnoss_axis;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ToolStripMenuItem readNcLocalToolStripMenuItem;
		private System.Windows.Forms.Button button40;
		private System.Windows.Forms.Button button41;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button button42;
		private System.Windows.Forms.TextBox textBox_code;
		private System.Windows.Forms.Label label_code;
		private System.Windows.Forms.TextBox textBox_code2;
		private System.Windows.Forms.Label label_code2;
	}
}