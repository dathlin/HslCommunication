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
			this.button_delete = new System.Windows.Forms.Button();
			this.button_post = new System.Windows.Forms.Button();
			this.button_get = new System.Windows.Forms.Button();
			this.textBox_body = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_api = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel4.SuspendLayout();
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
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 17);
			this.label1.TabIndex = 19;
			this.label1.Text = "ContentType:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(94, 181);
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
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Controls.Add(this.button_delete);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.button_post);
			this.panel2.Controls.Add(this.button_get);
			this.panel2.Controls.Add(this.textBox_body);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.textBox_api);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Location = new System.Drawing.Point(188, 99);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(813, 522);
			this.panel2.TabIndex = 13;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(4, 208);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(808, 309);
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
			this.tabPage1.Size = new System.Drawing.Size(800, 279);
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
			this.textBox1.Size = new System.Drawing.Size(654, 23);
			this.textBox1.TabIndex = 21;
			this.textBox1.Text = "http://127.0.0.1:12345/GetA";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(703, 3);
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
			this.webBrowser1.Size = new System.Drawing.Size(788, 238);
			this.webBrowser1.TabIndex = 23;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel4);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(800, 279);
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
			this.panel4.Size = new System.Drawing.Size(794, 273);
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
			this.button_clear.Location = new System.Drawing.Point(708, 4);
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
			this.button_stop.Location = new System.Drawing.Point(619, 4);
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
			this.textBox_log.Size = new System.Drawing.Size(788, 238);
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
			// button_delete
			// 
			this.button_delete.Location = new System.Drawing.Point(533, 180);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new System.Drawing.Size(148, 28);
			this.button_delete.TabIndex = 24;
			this.button_delete.Text = "Delete Api";
			this.button_delete.UseVisualStyleBackColor = true;
			this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
			// 
			// button_post
			// 
			this.button_post.Location = new System.Drawing.Point(379, 180);
			this.button_post.Name = "button_post";
			this.button_post.Size = new System.Drawing.Size(148, 28);
			this.button_post.TabIndex = 20;
			this.button_post.Text = "设置Post";
			this.button_post.UseVisualStyleBackColor = true;
			this.button_post.Click += new System.EventHandler(this.Button7_Click);
			// 
			// button_get
			// 
			this.button_get.Location = new System.Drawing.Point(234, 180);
			this.button_get.Name = "button_get";
			this.button_get.Size = new System.Drawing.Size(139, 28);
			this.button_get.TabIndex = 12;
			this.button_get.Text = "设置Get";
			this.button_get.UseVisualStyleBackColor = true;
			this.button_get.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox_body
			// 
			this.textBox_body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_body.Location = new System.Drawing.Point(62, 36);
			this.textBox_body.Multiline = true;
			this.textBox_body.Name = "textBox_body";
			this.textBox_body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_body.Size = new System.Drawing.Size(742, 138);
			this.textBox_body.TabIndex = 8;
			this.textBox_body.Text = "<html><head><title>HslWebServer</title></head><body><p style=\"color:red\">这是一个测试的消" +
    "息内容</p></body></html>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "数据：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(501, 11);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(188, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "在请求的时候就会得到下面的信息";
			// 
			// textBox_api
			// 
			this.textBox_api.Location = new System.Drawing.Point(62, 7);
			this.textBox_api.Name = "textBox_api";
			this.textBox_api.Size = new System.Drawing.Size(434, 23);
			this.textBox_api.TabIndex = 9;
			this.textBox_api.Text = "/GetA";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "网址";
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
			this.panel3.Size = new System.Drawing.Size(179, 522);
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
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(3, 20);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(171, 497);
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
			this.panel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
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
	}
}