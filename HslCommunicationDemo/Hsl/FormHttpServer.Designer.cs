namespace HslCommunicationDemo
{
    partial class FormHttpServer
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.checkBox_https = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox_IsCrossDomain = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_api = new System.Windows.Forms.TextBox();
			this.button_delete = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.button_post = new System.Windows.Forms.Button();
			this.textBox_body = new System.Windows.Forms.TextBox();
			this.button_get = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.checkBox_show_header = new System.Windows.Forms.CheckBox();
			this.checkBox_show_body = new System.Windows.Forms.CheckBox();
			this.button_clear = new System.Windows.Forms.Button();
			this.button_stop = new System.Windows.Forms.Button();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.button_device_remove = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_form = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label11 = new System.Windows.Forms.Label();
			this.button_device_add = new System.Windows.Forms.Button();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.checkBox_https);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.checkBox_IsCrossDomain);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(998, 60);
			this.panel1.TabIndex = 7;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Gray;
			this.label10.Location = new System.Drawing.Point(101, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(171, 17);
			this.label10.TabIndex = 26;
			this.label10.Text = "也支持 http://127.0.0.1:8000/";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(464, 35);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(491, 17);
			this.linkLabel1.TabIndex = 25;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.hsltechnology.cn/Doc/HslCommunication?chapter=HslCommChapter6-5";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// checkBox_https
			// 
			this.checkBox_https.AutoSize = true;
			this.checkBox_https.Location = new System.Drawing.Point(6, 31);
			this.checkBox_https.Name = "checkBox_https";
			this.checkBox_https.Size = new System.Drawing.Size(68, 21);
			this.checkBox_https.TabIndex = 24;
			this.checkBox_https.Text = "Https ?";
			this.checkBox_https.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(343, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 17);
			this.label4.TabIndex = 21;
			this.label4.Text = "Cert Create Doc:";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(418, 7);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(263, 21);
			this.checkBox2.TabIndex = 20;
			this.checkBox2.Text = "启动账户控制？Name:admin  pwd:123456";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox_IsCrossDomain
			// 
			this.checkBox_IsCrossDomain.AutoSize = true;
			this.checkBox_IsCrossDomain.Checked = true;
			this.checkBox_IsCrossDomain.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_IsCrossDomain.Location = new System.Drawing.Point(289, 7);
			this.checkBox_IsCrossDomain.Name = "checkBox_IsCrossDomain";
			this.checkBox_IsCrossDomain.Size = new System.Drawing.Size(123, 21);
			this.checkBox_IsCrossDomain.TabIndex = 17;
			this.checkBox_IsCrossDomain.Text = "是否支持跨域请求";
			this.checkBox_IsCrossDomain.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(800, 2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(91, 28);
			this.button4.TabIndex = 16;
			this.button4.Text = "关闭服务";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(703, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(62, 5);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(212, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "12345";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 179);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 17);
			this.label1.TabIndex = 19;
			this.label1.Text = "ContentType:";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(92, 176);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(134, 25);
			this.comboBox1.TabIndex = 18;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Location = new System.Drawing.Point(215, 99);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(786, 522);
			this.panel2.TabIndex = 13;
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
			this.splitContainer1.Panel1.Controls.Add(this.panel6);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel7);
			this.splitContainer1.Size = new System.Drawing.Size(784, 520);
			this.splitContainer1.SplitterDistance = 204;
			this.splitContainer1.TabIndex = 26;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label7);
			this.panel6.Controls.Add(this.textBox_api);
			this.panel6.Controls.Add(this.button_delete);
			this.panel6.Controls.Add(this.label8);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.comboBox1);
			this.panel6.Controls.Add(this.label9);
			this.panel6.Controls.Add(this.button_post);
			this.panel6.Controls.Add(this.textBox_body);
			this.panel6.Controls.Add(this.button_get);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(784, 204);
			this.panel6.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 6);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "网址";
			// 
			// textBox_api
			// 
			this.textBox_api.Location = new System.Drawing.Point(57, 2);
			this.textBox_api.Name = "textBox_api";
			this.textBox_api.Size = new System.Drawing.Size(434, 23);
			this.textBox_api.TabIndex = 9;
			this.textBox_api.Text = "/GetA";
			// 
			// button_delete
			// 
			this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_delete.Location = new System.Drawing.Point(531, 175);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new System.Drawing.Size(148, 28);
			this.button_delete.TabIndex = 24;
			this.button_delete.Text = "Delete Api";
			this.button_delete.UseVisualStyleBackColor = true;
			this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(496, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(188, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "在请求的时候就会得到下面的信息";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "数据：";
			// 
			// button_post
			// 
			this.button_post.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_post.Location = new System.Drawing.Point(377, 175);
			this.button_post.Name = "button_post";
			this.button_post.Size = new System.Drawing.Size(148, 28);
			this.button_post.TabIndex = 20;
			this.button_post.Text = "设置Post";
			this.button_post.UseVisualStyleBackColor = true;
			this.button_post.Click += new System.EventHandler(this.Button7_Click);
			// 
			// textBox_body
			// 
			this.textBox_body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_body.Location = new System.Drawing.Point(57, 31);
			this.textBox_body.Multiline = true;
			this.textBox_body.Name = "textBox_body";
			this.textBox_body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_body.Size = new System.Drawing.Size(723, 141);
			this.textBox_body.TabIndex = 8;
			this.textBox_body.Text = "<html><head><title>HslWebServer</title></head><body><p style=\"color:red\">这是一个测试的消" +
    "息内容</p></body></html>";
			// 
			// button_get
			// 
			this.button_get.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_get.Location = new System.Drawing.Point(232, 175);
			this.button_get.Name = "button_get";
			this.button_get.Size = new System.Drawing.Size(139, 28);
			this.button_get.TabIndex = 12;
			this.button_get.Text = "设置Get";
			this.button_get.UseVisualStyleBackColor = true;
			this.button_get.Click += new System.EventHandler(this.button3_Click);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.tabControl1);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(784, 312);
			this.panel7.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 312);
			this.tabControl1.TabIndex = 25;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.webBrowser1);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(776, 282);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "网页浏览";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 17);
			this.label5.TabIndex = 24;
			this.label5.Text = "Url:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(42, 6);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(638, 23);
			this.textBox1.TabIndex = 21;
			this.textBox1.Text = "http://127.0.0.1:12345/GetA";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(682, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 22;
			this.button2.Text = "请求";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.Location = new System.Drawing.Point(6, 35);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(767, 238);
			this.webBrowser1.TabIndex = 23;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel4);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(776, 286);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "调用日志";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.checkBox_show_header);
			this.panel4.Controls.Add(this.checkBox_show_body);
			this.panel4.Controls.Add(this.button_clear);
			this.panel4.Controls.Add(this.button_stop);
			this.panel4.Controls.Add(this.textBox_log);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(770, 280);
			this.panel4.TabIndex = 0;
			// 
			// checkBox_show_header
			// 
			this.checkBox_show_header.AutoSize = true;
			this.checkBox_show_header.Location = new System.Drawing.Point(83, 8);
			this.checkBox_show_header.Name = "checkBox_show_header";
			this.checkBox_show_header.Size = new System.Drawing.Size(124, 21);
			this.checkBox_show_header.TabIndex = 26;
			this.checkBox_show_header.Text = "显示Header内容?";
			this.checkBox_show_header.UseVisualStyleBackColor = true;
			// 
			// checkBox_show_body
			// 
			this.checkBox_show_body.AutoSize = true;
			this.checkBox_show_body.Location = new System.Drawing.Point(266, 8);
			this.checkBox_show_body.Name = "checkBox_show_body";
			this.checkBox_show_body.Size = new System.Drawing.Size(111, 21);
			this.checkBox_show_body.TabIndex = 25;
			this.checkBox_show_body.Text = "显示Bdoy内容?";
			this.checkBox_show_body.UseVisualStyleBackColor = true;
			// 
			// button_clear
			// 
			this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_clear.Location = new System.Drawing.Point(684, 4);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(83, 28);
			this.button_clear.TabIndex = 14;
			this.button_clear.Text = "清空";
			this.button_clear.UseVisualStyleBackColor = true;
			this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
			// 
			// button_stop
			// 
			this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_stop.Location = new System.Drawing.Point(595, 4);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(83, 28);
			this.button_stop.TabIndex = 13;
			this.button_stop.Text = "暂停";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Location = new System.Drawing.Point(3, 35);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(764, 245);
			this.textBox_log.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "Log:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel5);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(776, 282);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "注册设备";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.button_device_remove);
			this.panel5.Controls.Add(this.dataGridView1);
			this.panel5.Controls.Add(this.label11);
			this.panel5.Controls.Add(this.button_device_add);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(770, 276);
			this.panel5.TabIndex = 0;
			// 
			// button_device_remove
			// 
			this.button_device_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_remove.Location = new System.Drawing.Point(372, 240);
			this.button_device_remove.Name = "button_device_remove";
			this.button_device_remove.Size = new System.Drawing.Size(112, 31);
			this.button_device_remove.TabIndex = 3;
			this.button_device_remove.Text = "移除选中设备";
			this.button_device_remove.UseVisualStyleBackColor = true;
			this.button_device_remove.Click += new System.EventHandler(this.button5_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_guid,
            this.Column_form,
            this.Column_device});
			this.dataGridView1.Location = new System.Drawing.Point(3, 24);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(764, 212);
			this.dataGridView1.TabIndex = 2;
			// 
			// Column_guid
			// 
			this.Column_guid.HeaderText = "Guid";
			this.Column_guid.Name = "Column_guid";
			this.Column_guid.ReadOnly = true;
			this.Column_guid.Width = 240;
			// 
			// Column_form
			// 
			this.Column_form.HeaderText = "Form";
			this.Column_form.Name = "Column_form";
			this.Column_form.ReadOnly = true;
			this.Column_form.Width = 200;
			// 
			// Column_device
			// 
			this.Column_device.HeaderText = "Device";
			this.Column_device.Name = "Column_device";
			this.Column_device.ReadOnly = true;
			this.Column_device.Width = 290;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(119, 17);
			this.label11.TabIndex = 1;
			this.label11.Text = "已经注册的设备列表:";
			// 
			// button_device_add
			// 
			this.button_device_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_add.Location = new System.Drawing.Point(250, 240);
			this.button_device_add.Name = "button_device_add";
			this.button_device_add.Size = new System.Drawing.Size(112, 31);
			this.button_device_add.TabIndex = 0;
			this.button_device_add.Text = "新增设备";
			this.button_device_add.UseVisualStyleBackColor = true;
			this.button_device_add.Click += new System.EventHandler(this.button_device_add_Click);
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.hslcommunication.cn/";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "html / WebApi";
			this.userControlHead1.Size = new System.Drawing.Size(1005, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			this.userControlHead1.Load += new System.EventHandler(this.userControlHead1_Load);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.listBox1);
			this.panel3.Location = new System.Drawing.Point(3, 99);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(208, 522);
			this.panel3.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "已设置接口列表：";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(3, 20);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 497);
			this.listBox1.TabIndex = 0;
			// 
			// FormHttpServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1005, 624);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormHttpServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Web轻量级的服务器";
			this.Load += new System.EventHandler(this.FormClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_get;
        private System.Windows.Forms.TextBox textBox_body;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_api;
        private System.Windows.Forms.Label label7;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Button button_post;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox_IsCrossDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_delete;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox_https;
		private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.CheckBox checkBox_show_body;
        private System.Windows.Forms.CheckBox checkBox_show_header;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button_device_add;
		private System.Windows.Forms.Button button_device_remove;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_guid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_form;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_device;
	}
}