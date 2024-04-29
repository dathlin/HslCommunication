namespace HslCommunicationDemo
{
    partial class FormMqttFileClient
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("文件列表");
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox_rsa = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox_show_group = new System.Windows.Forms.TextBox();
			this.textBox_file_fileName = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox_file_fileSize = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox_file_dowloadTimes = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.textBox_file_date = new System.Windows.Forms.TextBox();
			this.textBox_file_upload = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.textBox_file_tag = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button12 = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.textBox_delete_fileName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button_download_cancel = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button10 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_download_fileName = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.label12 = new System.Windows.Forms.Label();
			this.button_download = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button_upload_cancel = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_upload_tag = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.textBox_upload_group = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label7 = new System.Windows.Forms.Label();
			this.button_upload = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.下载文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.删除目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.全部下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.批量上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.清除目录文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.刷新目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.重命名目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox_rsa);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox10);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox9);
			this.panel1.Controls.Add(this.label19);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Location = new System.Drawing.Point(6, 37);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(993, 60);
			this.panel1.TabIndex = 7;
			// 
			// checkBox_rsa
			// 
			this.checkBox_rsa.AutoSize = true;
			this.checkBox_rsa.Location = new System.Drawing.Point(712, 4);
			this.checkBox_rsa.Name = "checkBox_rsa";
			this.checkBox_rsa.Size = new System.Drawing.Size(212, 21);
			this.checkBox_rsa.TabIndex = 30;
			this.checkBox_rsa.Text = "RSA加密 (V10.2.0版本以上服务器)";
			this.checkBox_rsa.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(87, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(611, 23);
			this.textBox1.TabIndex = 29;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "客户端标识：";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(585, 4);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(113, 23);
			this.textBox10.TabIndex = 27;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(521, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 26;
			this.label3.Text = "密码：";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(418, 4);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(91, 23);
			this.textBox9.TabIndex = 25;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(342, 7);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(56, 17);
			this.label19.TabIndex = 24;
			this.label19.Text = "用户名：";
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(808, 27);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 23;
			this.button1.Text = "断开连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(708, 27);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(91, 28);
			this.button7.TabIndex = 22;
			this.button7.Text = "连接";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click_1);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(244, 4);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(79, 23);
			this.textBox2.TabIndex = 21;
			this.textBox2.Text = "1883";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(190, 7);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 17);
			this.label20.TabIndex = 20;
			this.label20.Text = "端口号：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(63, 4);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(115, 23);
			this.textBox_ip.TabIndex = 19;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(9, 7);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 17);
			this.label21.TabIndex = 18;
			this.label21.Text = "Ip地址：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.groupBox4);
			this.panel2.Enabled = false;
			this.panel2.Location = new System.Drawing.Point(6, 102);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(993, 539);
			this.panel2.TabIndex = 13;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.groupBox3);
			this.groupBox4.Controls.Add(this.groupBox2);
			this.groupBox4.Controls.Add(this.groupBox1);
			this.groupBox4.Controls.Add(this.button6);
			this.groupBox4.Controls.Add(this.treeView1);
			this.groupBox4.Location = new System.Drawing.Point(3, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(989, 532);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "浏览服务器文件";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.textBox_show_group);
			this.groupBox5.Controls.Add(this.textBox_file_fileName);
			this.groupBox5.Controls.Add(this.label23);
			this.groupBox5.Controls.Add(this.textBox_file_fileSize);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Controls.Add(this.textBox_file_dowloadTimes);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.textBox_file_date);
			this.groupBox5.Controls.Add(this.textBox_file_upload);
			this.groupBox5.Controls.Add(this.label32);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Controls.Add(this.textBox_file_tag);
			this.groupBox5.Location = new System.Drawing.Point(389, 11);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(594, 141);
			this.groupBox5.TabIndex = 41;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "选中文件详细信息";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 17);
			this.label4.TabIndex = 38;
			this.label4.Text = "Group：";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 53);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 17);
			this.label11.TabIndex = 14;
			this.label11.Text = "文件名：";
			// 
			// textBox_show_group
			// 
			this.textBox_show_group.Location = new System.Drawing.Point(106, 20);
			this.textBox_show_group.Name = "textBox_show_group";
			this.textBox_show_group.Size = new System.Drawing.Size(481, 23);
			this.textBox_show_group.TabIndex = 39;
			// 
			// textBox_file_fileName
			// 
			this.textBox_file_fileName.Location = new System.Drawing.Point(106, 50);
			this.textBox_file_fileName.Name = "textBox_file_fileName";
			this.textBox_file_fileName.Size = new System.Drawing.Size(481, 23);
			this.textBox_file_fileName.TabIndex = 15;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(6, 83);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(68, 17);
			this.label23.TabIndex = 22;
			this.label23.Text = "文件大小：";
			// 
			// textBox_file_fileSize
			// 
			this.textBox_file_fileSize.Location = new System.Drawing.Point(106, 80);
			this.textBox_file_fileSize.Name = "textBox_file_fileSize";
			this.textBox_file_fileSize.Size = new System.Drawing.Size(135, 23);
			this.textBox_file_fileSize.TabIndex = 23;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(259, 83);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(68, 17);
			this.label24.TabIndex = 24;
			this.label24.Text = "下载次数：";
			// 
			// textBox_file_dowloadTimes
			// 
			this.textBox_file_dowloadTimes.Location = new System.Drawing.Point(347, 80);
			this.textBox_file_dowloadTimes.Name = "textBox_file_dowloadTimes";
			this.textBox_file_dowloadTimes.Size = new System.Drawing.Size(80, 23);
			this.textBox_file_dowloadTimes.TabIndex = 25;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(451, 83);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 17);
			this.label25.TabIndex = 26;
			this.label25.Text = "上传人：";
			// 
			// textBox_file_date
			// 
			this.textBox_file_date.Location = new System.Drawing.Point(106, 110);
			this.textBox_file_date.Name = "textBox_file_date";
			this.textBox_file_date.Size = new System.Drawing.Size(187, 23);
			this.textBox_file_date.TabIndex = 31;
			// 
			// textBox_file_upload
			// 
			this.textBox_file_upload.Location = new System.Drawing.Point(521, 80);
			this.textBox_file_upload.Name = "textBox_file_upload";
			this.textBox_file_upload.Size = new System.Drawing.Size(66, 23);
			this.textBox_file_upload.TabIndex = 27;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(6, 113);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(68, 17);
			this.label32.TabIndex = 30;
			this.label32.Text = "上传日期：";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(299, 113);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(44, 17);
			this.label26.TabIndex = 28;
			this.label26.Text = "备注：";
			// 
			// textBox_file_tag
			// 
			this.textBox_file_tag.Location = new System.Drawing.Point(399, 110);
			this.textBox_file_tag.Name = "textBox_file_tag";
			this.textBox_file_tag.Size = new System.Drawing.Size(188, 23);
			this.textBox_file_tag.TabIndex = 29;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.Color.Gray;
			this.label13.Location = new System.Drawing.Point(5, 21);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(116, 17);
			this.label13.TabIndex = 40;
			this.label13.Text = "右键弹出菜单可操作";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.button12);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.button11);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.button9);
			this.groupBox3.Controls.Add(this.textBox_delete_fileName);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.button5);
			this.groupBox3.Location = new System.Drawing.Point(389, 425);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(594, 101);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "文件删除";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(156, 41);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 28);
			this.button12.TabIndex = 26;
			this.button12.Text = "子目录";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.Location = new System.Drawing.Point(344, 47);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(241, 51);
			this.label17.TabIndex = 25;
			this.label17.Text = "0";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(237, 41);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(101, 28);
			this.button11.TabIndex = 24;
			this.button11.Text = "目录文件信息";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(63, 17);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(178, 23);
			this.textBox6.TabIndex = 23;
			this.textBox6.Text = "Files/Personal/Admin";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 17);
			this.label5.TabIndex = 22;
			this.label5.Text = "Group：";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(67, 41);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(83, 28);
			this.button9.TabIndex = 18;
			this.button9.Text = "删除目录";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// textBox_delete_fileName
			// 
			this.textBox_delete_fileName.Location = new System.Drawing.Point(321, 17);
			this.textBox_delete_fileName.Name = "textBox_delete_fileName";
			this.textBox_delete_fileName.Size = new System.Drawing.Size(266, 23);
			this.textBox_delete_fileName.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(247, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 17);
			this.label8.TabIndex = 16;
			this.label8.Text = "文件名：";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(7, 41);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(54, 28);
			this.button5.TabIndex = 7;
			this.button5.Text = "删除";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button_download_cancel);
			this.groupBox2.Controls.Add(this.button8);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.textBox_download_fileName);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.progressBar2);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.button_download);
			this.groupBox2.Location = new System.Drawing.Point(389, 296);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(594, 128);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "文件下载";
			// 
			// button_download_cancel
			// 
			this.button_download_cancel.Enabled = false;
			this.button_download_cancel.Location = new System.Drawing.Point(517, 74);
			this.button_download_cancel.Name = "button_download_cancel";
			this.button_download_cancel.Size = new System.Drawing.Size(70, 25);
			this.button_download_cancel.TabIndex = 25;
			this.button_download_cancel.Text = "取消";
			this.button_download_cancel.UseVisualStyleBackColor = true;
			this.button_download_cancel.Click += new System.EventHandler(this.button_download_cancel_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(517, 101);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(70, 25);
			this.button8.TabIndex = 24;
			this.button8.Text = "打开目录";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(78, 104);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 17);
			this.label15.TabIndex = 23;
			this.label15.Text = "等待下载...";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(7, 104);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 17);
			this.label14.TabIndex = 22;
			this.label14.Text = "状态：";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(81, 21);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(430, 23);
			this.textBox5.TabIndex = 21;
			this.textBox5.Text = "Files/Personal/Admin";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 17);
			this.label2.TabIndex = 20;
			this.label2.Text = "Group：";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(517, 19);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(70, 25);
			this.button10.TabIndex = 19;
			this.button10.Text = "是否存在";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(417, 81);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(27, 17);
			this.label9.TabIndex = 18;
			this.label9.Text = "0/0";
			// 
			// textBox_download_fileName
			// 
			this.textBox_download_fileName.Location = new System.Drawing.Point(80, 52);
			this.textBox_download_fileName.Name = "textBox_download_fileName";
			this.textBox_download_fileName.Size = new System.Drawing.Size(431, 23);
			this.textBox_download_fileName.TabIndex = 17;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 55);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 17);
			this.label16.TabIndex = 16;
			this.label16.Text = "文件名：";
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point(80, 81);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(331, 17);
			this.progressBar2.TabIndex = 9;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 81);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 17);
			this.label12.TabIndex = 8;
			this.label12.Text = "进度：";
			// 
			// button_download
			// 
			this.button_download.Location = new System.Drawing.Point(517, 47);
			this.button_download.Name = "button_download";
			this.button_download.Size = new System.Drawing.Size(70, 25);
			this.button_download.TabIndex = 7;
			this.button_download.Text = "下载";
			this.button_download.UseVisualStyleBackColor = true;
			this.button_download.Click += new System.EventHandler(this.button_download_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.button_upload_cancel);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox_upload_tag);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.textBox_upload_group);
			this.groupBox1.Controls.Add(this.label28);
			this.groupBox1.Controls.Add(this.progressBar1);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.button_upload);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(389, 154);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(594, 138);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "文件上传";
			// 
			// button_upload_cancel
			// 
			this.button_upload_cancel.Enabled = false;
			this.button_upload_cancel.Location = new System.Drawing.Point(518, 83);
			this.button_upload_cancel.Name = "button_upload_cancel";
			this.button_upload_cancel.Size = new System.Drawing.Size(70, 28);
			this.button_upload_cancel.TabIndex = 27;
			this.button_upload_cancel.Text = "取消";
			this.button_upload_cancel.UseVisualStyleBackColor = true;
			this.button_upload_cancel.Click += new System.EventHandler(this.button_upload_cancel_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(464, 113);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(27, 17);
			this.label10.TabIndex = 26;
			this.label10.Text = "0/0";
			// 
			// textBox_upload_tag
			// 
			this.textBox_upload_tag.Location = new System.Drawing.Point(80, 84);
			this.textBox_upload_tag.Name = "textBox_upload_tag";
			this.textBox_upload_tag.Size = new System.Drawing.Size(431, 23);
			this.textBox_upload_tag.TabIndex = 25;
			this.textBox_upload_tag.Text = "test test for example it is import";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(7, 87);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(44, 17);
			this.label31.TabIndex = 24;
			this.label31.Text = "备注：";
			// 
			// textBox_upload_group
			// 
			this.textBox_upload_group.Location = new System.Drawing.Point(80, 55);
			this.textBox_upload_group.Name = "textBox_upload_group";
			this.textBox_upload_group.Size = new System.Drawing.Size(431, 23);
			this.textBox_upload_group.TabIndex = 19;
			this.textBox_upload_group.Text = "Files/Personal/Admin";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(6, 58);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(57, 17);
			this.label28.TabIndex = 18;
			this.label28.Text = "Group：";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(80, 113);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(378, 17);
			this.progressBar1.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 113);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 17);
			this.label7.TabIndex = 8;
			this.label7.Text = "进度：";
			// 
			// button_upload
			// 
			this.button_upload.Location = new System.Drawing.Point(517, 51);
			this.button_upload.Name = "button_upload";
			this.button_upload.Size = new System.Drawing.Size(70, 28);
			this.button_upload.TabIndex = 7;
			this.button_upload.Text = "上传";
			this.button_upload.UseVisualStyleBackColor = true;
			this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(517, 20);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(70, 28);
			this.button2.TabIndex = 6;
			this.button2.Text = "选择";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(80, 25);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(431, 23);
			this.textBox3.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "文件路径：";
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.Location = new System.Drawing.Point(310, 15);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(74, 23);
			this.button6.TabIndex = 32;
			this.button6.Text = "刷新";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.Location = new System.Drawing.Point(4, 42);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "节点0";
			treeNode1.Text = "文件列表";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.treeView1.Size = new System.Drawing.Size(379, 484);
			this.treeView1.TabIndex = 0;
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7746113.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "MQTT - File";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载文件ToolStripMenuItem,
            this.删除文件ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
			// 
			// 下载文件ToolStripMenuItem
			// 
			this.下载文件ToolStripMenuItem.Name = "下载文件ToolStripMenuItem";
			this.下载文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.下载文件ToolStripMenuItem.Text = "下载文件";
			this.下载文件ToolStripMenuItem.Click += new System.EventHandler(this.下载文件ToolStripMenuItem_Click);
			// 
			// 删除文件ToolStripMenuItem
			// 
			this.删除文件ToolStripMenuItem.Name = "删除文件ToolStripMenuItem";
			this.删除文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.删除文件ToolStripMenuItem.Text = "删除文件";
			this.删除文件ToolStripMenuItem.Click += new System.EventHandler(this.删除文件ToolStripMenuItem_Click);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除目录ToolStripMenuItem,
            this.全部下载ToolStripMenuItem,
            this.批量上传ToolStripMenuItem,
            this.清除目录文件ToolStripMenuItem,
            this.刷新目录ToolStripMenuItem,
            this.重命名目录ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(149, 136);
			// 
			// 删除目录ToolStripMenuItem
			// 
			this.删除目录ToolStripMenuItem.Name = "删除目录ToolStripMenuItem";
			this.删除目录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.删除目录ToolStripMenuItem.Text = "删除目录";
			this.删除目录ToolStripMenuItem.Click += new System.EventHandler(this.删除目录ToolStripMenuItem_Click);
			// 
			// 全部下载ToolStripMenuItem
			// 
			this.全部下载ToolStripMenuItem.Name = "全部下载ToolStripMenuItem";
			this.全部下载ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.全部下载ToolStripMenuItem.Text = "全部下载";
			this.全部下载ToolStripMenuItem.Click += new System.EventHandler(this.全部下载ToolStripMenuItem_Click);
			// 
			// 批量上传ToolStripMenuItem
			// 
			this.批量上传ToolStripMenuItem.Name = "批量上传ToolStripMenuItem";
			this.批量上传ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.批量上传ToolStripMenuItem.Text = "批量上传";
			this.批量上传ToolStripMenuItem.Click += new System.EventHandler(this.批量上传ToolStripMenuItem_Click);
			// 
			// 清除目录文件ToolStripMenuItem
			// 
			this.清除目录文件ToolStripMenuItem.Name = "清除目录文件ToolStripMenuItem";
			this.清除目录文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.清除目录文件ToolStripMenuItem.Text = "清除目录文件";
			this.清除目录文件ToolStripMenuItem.Click += new System.EventHandler(this.清除目录文件ToolStripMenuItem_Click);
			// 
			// 刷新目录ToolStripMenuItem
			// 
			this.刷新目录ToolStripMenuItem.Name = "刷新目录ToolStripMenuItem";
			this.刷新目录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.刷新目录ToolStripMenuItem.Text = "刷新目录";
			this.刷新目录ToolStripMenuItem.Click += new System.EventHandler(this.刷新目录ToolStripMenuItem_Click);
			// 
			// 重命名目录ToolStripMenuItem
			// 
			this.重命名目录ToolStripMenuItem.Name = "重命名目录ToolStripMenuItem";
			this.重命名目录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.重命名目录ToolStripMenuItem.Text = "重命名目录";
			this.重命名目录ToolStripMenuItem.Click += new System.EventHandler(this.重命名目录ToolStripMenuItem_Click);
			// 
			// FormMqttFileClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormMqttFileClient";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "文件客户端窗口";
			this.Load += new System.EventHandler(this.FormFileClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_file_date;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox_file_tag;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox_file_upload;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_file_dowloadTimes;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_file_fileSize;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_file_fileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_delete_fileName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_download_fileName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.TextBox textBox_upload_tag;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox_upload_group;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.TextBox textBox_show_group;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox textBox_ip;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ToolStripMenuItem 下载文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除文件ToolStripMenuItem;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem 删除目录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 全部下载ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 批量上传ToolStripMenuItem;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.CheckBox checkBox_rsa;
		private System.Windows.Forms.Button button_upload_cancel;
		private System.Windows.Forms.Button button_download_cancel;
		private System.Windows.Forms.ToolStripMenuItem 清除目录文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 刷新目录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 重命名目录ToolStripMenuItem;
	}
}