namespace HslCommunicationDemo
{
    partial class FormMqttServer
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
			this.sslServerControl1 = new HslCommunicationDemo.DemoControl.SslServerControl();
			this.textBox_login_password = new System.Windows.Forms.TextBox();
			this.label_login_password = new System.Windows.Forms.Label();
			this.textBox_login_name = new System.Windows.Forms.TextBox();
			this.label_login_name = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label_receive_size = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox_publish_timer = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button_publish_test = new System.Windows.Forms.Button();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.button_stop = new System.Windows.Forms.Button();
			this.button_clear = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox_session_activeTime = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox_session_willTopic = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox_session_userName = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox_session_topics = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox_session_rsa = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox_session_clientID = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox_session_port = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_session_ip = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox_session_onlineTime = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox_session_select = new System.Windows.Forms.ComboBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel8 = new System.Windows.Forms.Panel();
			this.mqttTopicControl1 = new HslCommunicationDemo.MQTT.MqttTopicControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.hslBarChart1 = new HslControls.HslBarChart();
			this.panel5 = new System.Windows.Forms.Panel();
			this.checkBox_skip_zero = new System.Windows.Forms.CheckBox();
			this.radioButton_every_day = new System.Windows.Forms.RadioButton();
			this.radioButton_every_hour = new System.Windows.Forms.RadioButton();
			this.radioButton_every_minute = new System.Windows.Forms.RadioButton();
			this.radioButton_every_seconds = new System.Windows.Forms.RadioButton();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.panel7 = new System.Windows.Forms.Panel();
			this.button_device_remove = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.Column_guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_form = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_device = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label25 = new System.Windows.Forms.Label();
			this.button_device_add = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label32 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox_redir_name5 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.textBox_redir_name4 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.textBox_redir_name3 = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.textBox_redir_name2 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.textBox_redir_name1 = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.textBox_redir_id5 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.textBox_redir_id4 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox_redir_id3 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox_redir_id2 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox_redir_id1 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_recv_gb2312 = new System.Windows.Forms.RadioButton();
			this.radioButton_recv_Unicode = new System.Windows.Forms.RadioButton();
			this.radioButton_recv_UTF8 = new System.Windows.Forms.RadioButton();
			this.radioButton_recv_ASCII = new System.Windows.Forms.RadioButton();
			this.radioButton_recv_Hex = new System.Windows.Forms.RadioButton();
			this.checkBox_publish_isHex = new System.Windows.Forms.CheckBox();
			this.checkBox_long_message_hide = new System.Windows.Forms.CheckBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label_receive_count = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.textBox_publish_clientID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.checkBox_retain = new System.Windows.Forms.CheckBox();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel8.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.tabPage6.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.sslServerControl1);
			this.panel1.Controls.Add(this.textBox_login_password);
			this.panel1.Controls.Add(this.label_login_password);
			this.panel1.Controls.Add(this.textBox_login_name);
			this.panel1.Controls.Add(this.label_login_name);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.checkBox3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(999, 65);
			this.panel1.TabIndex = 7;
			// 
			// sslServerControl1
			// 
			this.sslServerControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sslServerControl1.Location = new System.Drawing.Point(2, 32);
			this.sslServerControl1.Name = "sslServerControl1";
			this.sslServerControl1.Size = new System.Drawing.Size(993, 30);
			this.sslServerControl1.TabIndex = 15;
			// 
			// textBox_login_password
			// 
			this.textBox_login_password.Location = new System.Drawing.Point(902, 7);
			this.textBox_login_password.Name = "textBox_login_password";
			this.textBox_login_password.Size = new System.Drawing.Size(83, 23);
			this.textBox_login_password.TabIndex = 14;
			this.textBox_login_password.Text = "123456";
			// 
			// label_login_password
			// 
			this.label_login_password.AutoSize = true;
			this.label_login_password.Location = new System.Drawing.Point(847, 10);
			this.label_login_password.Name = "label_login_password";
			this.label_login_password.Size = new System.Drawing.Size(44, 17);
			this.label_login_password.TabIndex = 13;
			this.label_login_password.Text = "密码：";
			// 
			// textBox_login_name
			// 
			this.textBox_login_name.Location = new System.Drawing.Point(740, 7);
			this.textBox_login_name.Name = "textBox_login_name";
			this.textBox_login_name.Size = new System.Drawing.Size(100, 23);
			this.textBox_login_name.TabIndex = 12;
			this.textBox_login_name.Text = "admin";
			// 
			// label_login_name
			// 
			this.label_login_name.AutoSize = true;
			this.label_login_name.Location = new System.Drawing.Point(678, 10);
			this.label_login_name.Name = "label_login_name";
			this.label_login_name.Size = new System.Drawing.Size(56, 17);
			this.label_login_name.TabIndex = 11;
			this.label_login_name.Text = "用户名：";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(147, 9);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(87, 21);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "主题通配符";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(589, 9);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(87, 21);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "启用用户名";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(335, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭服务";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(238, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(58, 7);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(78, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "1883";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(435, 9);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(147, 21);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "是否回发一条测试数据";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label_receive_size);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.checkBox_publish_timer);
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.checkBox_publish_isHex);
			this.panel2.Controls.Add(this.checkBox_long_message_hide);
			this.panel2.Controls.Add(this.listBox1);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label_receive_count);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.textBox_publish_clientID);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.textBox5);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.checkBox_retain);
			this.panel2.Location = new System.Drawing.Point(3, 102);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(999, 539);
			this.panel2.TabIndex = 13;
			// 
			// label_receive_size
			// 
			this.label_receive_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_receive_size.AutoSize = true;
			this.label_receive_size.Location = new System.Drawing.Point(550, 516);
			this.label_receive_size.Name = "label_receive_size";
			this.label_receive_size.Size = new System.Drawing.Size(34, 17);
			this.label_receive_size.TabIndex = 44;
			this.label_receive_size.Text = "Size:";
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(962, 186);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(25, 17);
			this.label18.TabIndex = 42;
			this.label18.Text = "ms";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(889, 183);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(68, 23);
			this.textBox1.TabIndex = 41;
			this.textBox1.Text = "1000";
			// 
			// checkBox_publish_timer
			// 
			this.checkBox_publish_timer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_publish_timer.AutoSize = true;
			this.checkBox_publish_timer.Location = new System.Drawing.Point(807, 184);
			this.checkBox_publish_timer.Name = "checkBox_publish_timer";
			this.checkBox_publish_timer.Size = new System.Drawing.Size(75, 21);
			this.checkBox_publish_timer.TabIndex = 40;
			this.checkBox_publish_timer.Text = "定时发布";
			this.checkBox_publish_timer.UseVisualStyleBackColor = true;
			this.checkBox_publish_timer.CheckedChanged += new System.EventHandler(this.checkBox_publish_timer_CheckedChanged);
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
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(2, 211);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(996, 302);
			this.tabControl1.TabIndex = 39;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button_publish_test);
			this.tabPage1.Controls.Add(this.textBox8);
			this.tabPage1.Controls.Add(this.button_stop);
			this.tabPage1.Controls.Add(this.button_clear);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(988, 272);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "LogInfo";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button_publish_test
			// 
			this.button_publish_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_publish_test.ForeColor = System.Drawing.Color.Silver;
			this.button_publish_test.Location = new System.Drawing.Point(901, 238);
			this.button_publish_test.Name = "button_publish_test";
			this.button_publish_test.Size = new System.Drawing.Size(81, 28);
			this.button_publish_test.TabIndex = 29;
			this.button_publish_test.Text = "发布测试";
			this.button_publish_test.UseVisualStyleBackColor = true;
			this.button_publish_test.Click += new System.EventHandler(this.button_publish_test_Click);
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(3, 3);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(892, 267);
			this.textBox8.TabIndex = 18;
			// 
			// button_stop
			// 
			this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_stop.Location = new System.Drawing.Point(901, 6);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(81, 28);
			this.button_stop.TabIndex = 28;
			this.button_stop.Text = "暂停";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button7_Click);
			// 
			// button_clear
			// 
			this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_clear.Location = new System.Drawing.Point(901, 40);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(81, 28);
			this.button_clear.TabIndex = 17;
			this.button_clear.Text = "清空";
			this.button_clear.UseVisualStyleBackColor = true;
			this.button_clear.Click += new System.EventHandler(this.button4_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button4);
			this.tabPage2.Controls.Add(this.textBox_session_activeTime);
			this.tabPage2.Controls.Add(this.label23);
			this.tabPage2.Controls.Add(this.textBox_session_willTopic);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.textBox_session_userName);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.textBox_session_topics);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.textBox_session_rsa);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.textBox_session_clientID);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.textBox_session_port);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.textBox_session_ip);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.textBox_session_onlineTime);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.comboBox_session_select);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(988, 272);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Sessions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(881, 4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(104, 28);
			this.button4.TabIndex = 27;
			this.button4.Text = "Logoff";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click_1);
			// 
			// textBox_session_activeTime
			// 
			this.textBox_session_activeTime.Location = new System.Drawing.Point(101, 67);
			this.textBox_session_activeTime.Name = "textBox_session_activeTime";
			this.textBox_session_activeTime.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_activeTime.TabIndex = 26;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(6, 70);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(86, 17);
			this.label23.TabIndex = 25;
			this.label23.Text = "Active Time：";
			// 
			// textBox_session_willTopic
			// 
			this.textBox_session_willTopic.Location = new System.Drawing.Point(101, 250);
			this.textBox_session_willTopic.Name = "textBox_session_willTopic";
			this.textBox_session_willTopic.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_willTopic.TabIndex = 24;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(6, 253);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(73, 17);
			this.label17.TabIndex = 23;
			this.label17.Text = "WillTopic：";
			// 
			// textBox_session_userName
			// 
			this.textBox_session_userName.Location = new System.Drawing.Point(101, 187);
			this.textBox_session_userName.Name = "textBox_session_userName";
			this.textBox_session_userName.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_userName.TabIndex = 22;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 190);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(82, 17);
			this.label16.TabIndex = 21;
			this.label16.Text = "UserName：";
			// 
			// textBox_session_topics
			// 
			this.textBox_session_topics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_session_topics.Location = new System.Drawing.Point(498, 37);
			this.textBox_session_topics.Multiline = true;
			this.textBox_session_topics.Name = "textBox_session_topics";
			this.textBox_session_topics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_session_topics.Size = new System.Drawing.Size(484, 230);
			this.textBox_session_topics.TabIndex = 20;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(402, 43);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(76, 17);
			this.label15.TabIndex = 19;
			this.label15.Text = "Sub-Topics:";
			// 
			// textBox_session_rsa
			// 
			this.textBox_session_rsa.Location = new System.Drawing.Point(101, 217);
			this.textBox_session_rsa.Name = "textBox_session_rsa";
			this.textBox_session_rsa.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_rsa.TabIndex = 18;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 220);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(70, 17);
			this.label14.TabIndex = 17;
			this.label14.Text = "RSA/AES：";
			// 
			// textBox_session_clientID
			// 
			this.textBox_session_clientID.Location = new System.Drawing.Point(101, 157);
			this.textBox_session_clientID.Name = "textBox_session_clientID";
			this.textBox_session_clientID.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_clientID.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 160);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(69, 17);
			this.label13.TabIndex = 15;
			this.label13.Text = "Client ID：";
			// 
			// textBox_session_port
			// 
			this.textBox_session_port.Location = new System.Drawing.Point(101, 128);
			this.textBox_session_port.Name = "textBox_session_port";
			this.textBox_session_port.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_port.TabIndex = 14;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 131);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 17);
			this.label12.TabIndex = 13;
			this.label12.Text = "Ip Port：";
			// 
			// textBox_session_ip
			// 
			this.textBox_session_ip.Location = new System.Drawing.Point(101, 98);
			this.textBox_session_ip.Name = "textBox_session_ip";
			this.textBox_session_ip.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_ip.TabIndex = 12;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 101);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(84, 17);
			this.label11.TabIndex = 11;
			this.label11.Text = "Ip Address：";
			// 
			// textBox_session_onlineTime
			// 
			this.textBox_session_onlineTime.Location = new System.Drawing.Point(101, 37);
			this.textBox_session_onlineTime.Name = "textBox_session_onlineTime";
			this.textBox_session_onlineTime.Size = new System.Drawing.Size(280, 23);
			this.textBox_session_onlineTime.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 17);
			this.label10.TabIndex = 9;
			this.label10.Text = "Online Time：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "Session：";
			// 
			// comboBox_session_select
			// 
			this.comboBox_session_select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_session_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_session_select.FormattingEnabled = true;
			this.comboBox_session_select.Location = new System.Drawing.Point(103, 6);
			this.comboBox_session_select.Name = "comboBox_session_select";
			this.comboBox_session_select.Size = new System.Drawing.Size(773, 25);
			this.comboBox_session_select.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.panel8);
			this.tabPage3.Location = new System.Drawing.Point(4, 26);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(988, 272);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Topics";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.mqttTopicControl1);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(982, 266);
			this.panel8.TabIndex = 27;
			// 
			// mqttTopicControl1
			// 
			this.mqttTopicControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mqttTopicControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.mqttTopicControl1.GetStringFromPayload = null;
			this.mqttTopicControl1.Location = new System.Drawing.Point(0, 0);
			this.mqttTopicControl1.Name = "mqttTopicControl1";
			this.mqttTopicControl1.Size = new System.Drawing.Size(982, 266);
			this.mqttTopicControl1.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.panel4);
			this.tabPage4.Location = new System.Drawing.Point(4, 26);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(988, 272);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Statistics";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.hslBarChart1);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(982, 266);
			this.panel4.TabIndex = 0;
			// 
			// hslBarChart1
			// 
			this.hslBarChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hslBarChart1.BarBackColor = System.Drawing.Color.SlateBlue;
			this.hslBarChart1.Location = new System.Drawing.Point(0, 38);
			this.hslBarChart1.Name = "hslBarChart1";
			this.hslBarChart1.ShowBarValueFormat = "{0}";
			this.hslBarChart1.Size = new System.Drawing.Size(978, 225);
			this.hslBarChart1.TabIndex = 1;
			this.hslBarChart1.Text = "hslBarChart1";
			this.hslBarChart1.UseGradient = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.checkBox_skip_zero);
			this.panel5.Controls.Add(this.radioButton_every_day);
			this.panel5.Controls.Add(this.radioButton_every_hour);
			this.panel5.Controls.Add(this.radioButton_every_minute);
			this.panel5.Controls.Add(this.radioButton_every_seconds);
			this.panel5.Location = new System.Drawing.Point(1, 1);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(958, 35);
			this.panel5.TabIndex = 0;
			// 
			// checkBox_skip_zero
			// 
			this.checkBox_skip_zero.AutoSize = true;
			this.checkBox_skip_zero.Checked = true;
			this.checkBox_skip_zero.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_skip_zero.Location = new System.Drawing.Point(78, 8);
			this.checkBox_skip_zero.Name = "checkBox_skip_zero";
			this.checkBox_skip_zero.Size = new System.Drawing.Size(96, 21);
			this.checkBox_skip_zero.TabIndex = 8;
			this.checkBox_skip_zero.Text = "跳过次数 0 ?";
			this.checkBox_skip_zero.UseVisualStyleBackColor = true;
			// 
			// radioButton_every_day
			// 
			this.radioButton_every_day.AutoSize = true;
			this.radioButton_every_day.Location = new System.Drawing.Point(374, 7);
			this.radioButton_every_day.Name = "radioButton_every_day";
			this.radioButton_every_day.Size = new System.Drawing.Size(50, 21);
			this.radioButton_every_day.TabIndex = 7;
			this.radioButton_every_day.Text = "每天";
			this.radioButton_every_day.UseVisualStyleBackColor = true;
			// 
			// radioButton_every_hour
			// 
			this.radioButton_every_hour.AutoSize = true;
			this.radioButton_every_hour.Location = new System.Drawing.Point(284, 7);
			this.radioButton_every_hour.Name = "radioButton_every_hour";
			this.radioButton_every_hour.Size = new System.Drawing.Size(62, 21);
			this.radioButton_every_hour.TabIndex = 3;
			this.radioButton_every_hour.Text = "每小时";
			this.radioButton_every_hour.UseVisualStyleBackColor = true;
			// 
			// radioButton_every_minute
			// 
			this.radioButton_every_minute.AutoSize = true;
			this.radioButton_every_minute.Checked = true;
			this.radioButton_every_minute.Location = new System.Drawing.Point(191, 7);
			this.radioButton_every_minute.Name = "radioButton_every_minute";
			this.radioButton_every_minute.Size = new System.Drawing.Size(62, 21);
			this.radioButton_every_minute.TabIndex = 1;
			this.radioButton_every_minute.TabStop = true;
			this.radioButton_every_minute.Text = "每分钟";
			this.radioButton_every_minute.UseVisualStyleBackColor = true;
			// 
			// radioButton_every_seconds
			// 
			this.radioButton_every_seconds.AutoSize = true;
			this.radioButton_every_seconds.Location = new System.Drawing.Point(5, 7);
			this.radioButton_every_seconds.Name = "radioButton_every_seconds";
			this.radioButton_every_seconds.Size = new System.Drawing.Size(50, 21);
			this.radioButton_every_seconds.TabIndex = 0;
			this.radioButton_every_seconds.Text = "每秒";
			this.radioButton_every_seconds.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.panel7);
			this.tabPage5.Location = new System.Drawing.Point(4, 26);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(988, 272);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "注册设备";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.button_device_remove);
			this.panel7.Controls.Add(this.dataGridView2);
			this.panel7.Controls.Add(this.label25);
			this.panel7.Controls.Add(this.button_device_add);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(982, 266);
			this.panel7.TabIndex = 1;
			this.panel7.SizeChanged += new System.EventHandler(this.panel7_SizeChanged);
			// 
			// button_device_remove
			// 
			this.button_device_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_remove.Location = new System.Drawing.Point(372, 230);
			this.button_device_remove.Name = "button_device_remove";
			this.button_device_remove.Size = new System.Drawing.Size(112, 31);
			this.button_device_remove.TabIndex = 3;
			this.button_device_remove.Text = "移除选中设备";
			this.button_device_remove.UseVisualStyleBackColor = true;
			this.button_device_remove.Click += new System.EventHandler(this.button_device_remove_Click);
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
			this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_guid,
            this.Column_form,
            this.Column_device});
			this.dataGridView2.Location = new System.Drawing.Point(3, 24);
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(976, 202);
			this.dataGridView2.TabIndex = 2;
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
			this.Column_form.Width = 270;
			// 
			// Column_device
			// 
			this.Column_device.HeaderText = "Device";
			this.Column_device.Name = "Column_device";
			this.Column_device.ReadOnly = true;
			this.Column_device.Width = 360;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(6, 4);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(119, 17);
			this.label25.TabIndex = 1;
			this.label25.Text = "已经注册的设备列表:";
			// 
			// button_device_add
			// 
			this.button_device_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_device_add.Location = new System.Drawing.Point(250, 230);
			this.button_device_add.Name = "button_device_add";
			this.button_device_add.Size = new System.Drawing.Size(112, 31);
			this.button_device_add.TabIndex = 0;
			this.button_device_add.Text = "新增设备";
			this.button_device_add.UseVisualStyleBackColor = true;
			this.button_device_add.Click += new System.EventHandler(this.button_device_add_Click);
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.panel6);
			this.tabPage6.Location = new System.Drawing.Point(4, 26);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(988, 272);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "重定向服务";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.AutoScroll = true;
			this.panel6.Controls.Add(this.label32);
			this.panel6.Controls.Add(this.button8);
			this.panel6.Controls.Add(this.button7);
			this.panel6.Controls.Add(this.textBox_redir_name5);
			this.panel6.Controls.Add(this.label31);
			this.panel6.Controls.Add(this.textBox_redir_name4);
			this.panel6.Controls.Add(this.label30);
			this.panel6.Controls.Add(this.textBox_redir_name3);
			this.panel6.Controls.Add(this.label29);
			this.panel6.Controls.Add(this.textBox_redir_name2);
			this.panel6.Controls.Add(this.label28);
			this.panel6.Controls.Add(this.textBox_redir_name1);
			this.panel6.Controls.Add(this.label27);
			this.panel6.Controls.Add(this.textBox_redir_id5);
			this.panel6.Controls.Add(this.label26);
			this.panel6.Controls.Add(this.textBox_redir_id4);
			this.panel6.Controls.Add(this.label24);
			this.panel6.Controls.Add(this.textBox_redir_id3);
			this.panel6.Controls.Add(this.label22);
			this.panel6.Controls.Add(this.textBox_redir_id2);
			this.panel6.Controls.Add(this.label21);
			this.panel6.Controls.Add(this.textBox_redir_id1);
			this.panel6.Controls.Add(this.label20);
			this.panel6.Controls.Add(this.panel9);
			this.panel6.Controls.Add(this.textBox6);
			this.panel6.Controls.Add(this.label19);
			this.panel6.Controls.Add(this.textBox3);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(982, 266);
			this.panel6.TabIndex = 0;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.ForeColor = System.Drawing.Color.DimGray;
			this.label32.Location = new System.Drawing.Point(464, 15);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(339, 17);
			this.label32.TabIndex = 31;
			this.label32.Text = "(符合条件的客户端连接上来后，会自动重定向连接的IP和端口)";
			// 
			// button8
			// 
			this.button8.Enabled = false;
			this.button8.Location = new System.Drawing.Point(345, 218);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(163, 36);
			this.button8.TabIndex = 30;
			this.button8.Text = "关闭";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click_1);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(156, 218);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(163, 36);
			this.button7.TabIndex = 29;
			this.button7.Text = "启动重定向服务";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click_1);
			// 
			// textBox_redir_name5
			// 
			this.textBox_redir_name5.Location = new System.Drawing.Point(457, 187);
			this.textBox_redir_name5.Name = "textBox_redir_name5";
			this.textBox_redir_name5.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_name5.TabIndex = 28;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(382, 190);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(74, 17);
			this.label31.TabIndex = 27;
			this.label31.Text = "Name 5#：";
			// 
			// textBox_redir_name4
			// 
			this.textBox_redir_name4.Location = new System.Drawing.Point(457, 159);
			this.textBox_redir_name4.Name = "textBox_redir_name4";
			this.textBox_redir_name4.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_name4.TabIndex = 26;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(382, 162);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(74, 17);
			this.label30.TabIndex = 25;
			this.label30.Text = "Name 4#：";
			// 
			// textBox_redir_name3
			// 
			this.textBox_redir_name3.Location = new System.Drawing.Point(457, 132);
			this.textBox_redir_name3.Name = "textBox_redir_name3";
			this.textBox_redir_name3.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_name3.TabIndex = 24;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(382, 135);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(74, 17);
			this.label29.TabIndex = 23;
			this.label29.Text = "Name 3#：";
			// 
			// textBox_redir_name2
			// 
			this.textBox_redir_name2.Location = new System.Drawing.Point(457, 104);
			this.textBox_redir_name2.Name = "textBox_redir_name2";
			this.textBox_redir_name2.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_name2.TabIndex = 22;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(382, 107);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(74, 17);
			this.label28.TabIndex = 21;
			this.label28.Text = "Name 2#：";
			// 
			// textBox_redir_name1
			// 
			this.textBox_redir_name1.Location = new System.Drawing.Point(457, 76);
			this.textBox_redir_name1.Name = "textBox_redir_name1";
			this.textBox_redir_name1.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_name1.TabIndex = 20;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(382, 79);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(74, 17);
			this.label27.TabIndex = 19;
			this.label27.Text = "Name 1#：";
			// 
			// textBox_redir_id5
			// 
			this.textBox_redir_id5.Location = new System.Drawing.Point(190, 187);
			this.textBox_redir_id5.Name = "textBox_redir_id5";
			this.textBox_redir_id5.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_id5.TabIndex = 18;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(135, 190);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(52, 17);
			this.label26.TabIndex = 17;
			this.label26.Text = "ID 5#：";
			// 
			// textBox_redir_id4
			// 
			this.textBox_redir_id4.Location = new System.Drawing.Point(190, 159);
			this.textBox_redir_id4.Name = "textBox_redir_id4";
			this.textBox_redir_id4.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_id4.TabIndex = 16;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(135, 162);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(52, 17);
			this.label24.TabIndex = 15;
			this.label24.Text = "ID 4#：";
			// 
			// textBox_redir_id3
			// 
			this.textBox_redir_id3.Location = new System.Drawing.Point(190, 132);
			this.textBox_redir_id3.Name = "textBox_redir_id3";
			this.textBox_redir_id3.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_id3.TabIndex = 14;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(135, 135);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(52, 17);
			this.label22.TabIndex = 13;
			this.label22.Text = "ID 3#：";
			// 
			// textBox_redir_id2
			// 
			this.textBox_redir_id2.Location = new System.Drawing.Point(190, 104);
			this.textBox_redir_id2.Name = "textBox_redir_id2";
			this.textBox_redir_id2.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_id2.TabIndex = 12;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(135, 107);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(52, 17);
			this.label21.TabIndex = 11;
			this.label21.Text = "ID 2#：";
			// 
			// textBox_redir_id1
			// 
			this.textBox_redir_id1.Location = new System.Drawing.Point(190, 76);
			this.textBox_redir_id1.Name = "textBox_redir_id1";
			this.textBox_redir_id1.Size = new System.Drawing.Size(182, 23);
			this.textBox_redir_id1.TabIndex = 10;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(135, 79);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(52, 17);
			this.label20.TabIndex = 9;
			this.label20.Text = "ID 1#：";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.radioButton3);
			this.panel9.Controls.Add(this.radioButton2);
			this.panel9.Controls.Add(this.radioButton1);
			this.panel9.Location = new System.Drawing.Point(3, 41);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(976, 29);
			this.panel9.TabIndex = 8;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(457, 4);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(86, 21);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "指定用户名";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(190, 4);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(94, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "指定ClientId";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(4, 4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(86, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "全部重定向";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(330, 12);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(115, 23);
			this.textBox6.TabIndex = 7;
			this.textBox6.Text = "1883";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(275, 15);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(44, 17);
			this.label19.TabIndex = 6;
			this.label19.Text = "端口：";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(61, 12);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(193, 23);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "127.0.0.1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Ip地址：";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.Controls.Add(this.radioButton_recv_gb2312);
			this.panel3.Controls.Add(this.radioButton_recv_Unicode);
			this.panel3.Controls.Add(this.radioButton_recv_UTF8);
			this.panel3.Controls.Add(this.radioButton_recv_ASCII);
			this.panel3.Controls.Add(this.radioButton_recv_Hex);
			this.panel3.Location = new System.Drawing.Point(5, 512);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(343, 24);
			this.panel3.TabIndex = 38;
			// 
			// radioButton_recv_gb2312
			// 
			this.radioButton_recv_gb2312.AutoSize = true;
			this.radioButton_recv_gb2312.Location = new System.Drawing.Point(264, 2);
			this.radioButton_recv_gb2312.Name = "radioButton_recv_gb2312";
			this.radioButton_recv_gb2312.Size = new System.Drawing.Size(71, 21);
			this.radioButton_recv_gb2312.TabIndex = 4;
			this.radioButton_recv_gb2312.TabStop = true;
			this.radioButton_recv_gb2312.Text = "GB2312";
			this.radioButton_recv_gb2312.UseVisualStyleBackColor = true;
			// 
			// radioButton_recv_Unicode
			// 
			this.radioButton_recv_Unicode.AutoSize = true;
			this.radioButton_recv_Unicode.Location = new System.Drawing.Point(184, 2);
			this.radioButton_recv_Unicode.Name = "radioButton_recv_Unicode";
			this.radioButton_recv_Unicode.Size = new System.Drawing.Size(74, 21);
			this.radioButton_recv_Unicode.TabIndex = 3;
			this.radioButton_recv_Unicode.TabStop = true;
			this.radioButton_recv_Unicode.Text = "Unicode";
			this.radioButton_recv_Unicode.UseVisualStyleBackColor = true;
			// 
			// radioButton_recv_UTF8
			// 
			this.radioButton_recv_UTF8.AutoSize = true;
			this.radioButton_recv_UTF8.Checked = true;
			this.radioButton_recv_UTF8.Location = new System.Drawing.Point(123, 2);
			this.radioButton_recv_UTF8.Name = "radioButton_recv_UTF8";
			this.radioButton_recv_UTF8.Size = new System.Drawing.Size(55, 21);
			this.radioButton_recv_UTF8.TabIndex = 2;
			this.radioButton_recv_UTF8.TabStop = true;
			this.radioButton_recv_UTF8.Text = "UTF8";
			this.radioButton_recv_UTF8.UseVisualStyleBackColor = true;
			// 
			// radioButton_recv_ASCII
			// 
			this.radioButton_recv_ASCII.AutoSize = true;
			this.radioButton_recv_ASCII.Location = new System.Drawing.Point(60, 2);
			this.radioButton_recv_ASCII.Name = "radioButton_recv_ASCII";
			this.radioButton_recv_ASCII.Size = new System.Drawing.Size(57, 21);
			this.radioButton_recv_ASCII.TabIndex = 1;
			this.radioButton_recv_ASCII.TabStop = true;
			this.radioButton_recv_ASCII.Text = "ASCII";
			this.radioButton_recv_ASCII.UseVisualStyleBackColor = true;
			// 
			// radioButton_recv_Hex
			// 
			this.radioButton_recv_Hex.AutoSize = true;
			this.radioButton_recv_Hex.Location = new System.Drawing.Point(6, 2);
			this.radioButton_recv_Hex.Name = "radioButton_recv_Hex";
			this.radioButton_recv_Hex.Size = new System.Drawing.Size(48, 21);
			this.radioButton_recv_Hex.TabIndex = 0;
			this.radioButton_recv_Hex.TabStop = true;
			this.radioButton_recv_Hex.Text = "Hex";
			this.radioButton_recv_Hex.UseVisualStyleBackColor = true;
			// 
			// checkBox_publish_isHex
			// 
			this.checkBox_publish_isHex.AutoSize = true;
			this.checkBox_publish_isHex.Location = new System.Drawing.Point(5, 62);
			this.checkBox_publish_isHex.Name = "checkBox_publish_isHex";
			this.checkBox_publish_isHex.Size = new System.Drawing.Size(55, 21);
			this.checkBox_publish_isHex.TabIndex = 36;
			this.checkBox_publish_isHex.Text = "Hex?";
			this.checkBox_publish_isHex.UseVisualStyleBackColor = true;
			// 
			// checkBox_long_message_hide
			// 
			this.checkBox_long_message_hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_long_message_hide.AutoSize = true;
			this.checkBox_long_message_hide.Checked = true;
			this.checkBox_long_message_hide.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_long_message_hide.Location = new System.Drawing.Point(694, 515);
			this.checkBox_long_message_hide.Name = "checkBox_long_message_hide";
			this.checkBox_long_message_hide.Size = new System.Drawing.Size(99, 21);
			this.checkBox_long_message_hide.TabIndex = 33;
			this.checkBox_long_message_hide.Text = "超长消息简略";
			this.checkBox_long_message_hide.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.BackColor = System.Drawing.Color.LightGray;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(579, 36);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(413, 140);
			this.listBox1.TabIndex = 31;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(579, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 17);
			this.label5.TabIndex = 30;
			this.label5.Text = "Online Client：";
			// 
			// label_receive_count
			// 
			this.label_receive_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_receive_count.AutoSize = true;
			this.label_receive_count.Location = new System.Drawing.Point(379, 516);
			this.label_receive_count.Name = "label_receive_count";
			this.label_receive_count.Size = new System.Drawing.Size(93, 17);
			this.label_receive_count.TabIndex = 29;
			this.label_receive_count.Text = "Receive Count:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(882, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 17);
			this.label2.TabIndex = 27;
			this.label2.Text = "Online Count:";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(171, 180);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(91, 28);
			this.button6.TabIndex = 26;
			this.button6.Text = "发布订阅";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click_1);
			// 
			// textBox_publish_clientID
			// 
			this.textBox_publish_clientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_publish_clientID.Location = new System.Drawing.Point(444, 182);
			this.textBox_publish_clientID.Name = "textBox_publish_clientID";
			this.textBox_publish_clientID.Size = new System.Drawing.Size(345, 23);
			this.textBox_publish_clientID.TabIndex = 25;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(370, 186);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 24;
			this.label1.Text = "Client Id：";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(269, 180);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 28);
			this.button5.TabIndex = 20;
			this.button5.Text = "广播指定id";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(75, 180);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(91, 28);
			this.button3.TabIndex = 12;
			this.button3.Text = "广播所有";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(62, 36);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(511, 138);
			this.textBox4.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "Payload：";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label8.Location = new System.Drawing.Point(523, 11);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "(主题)";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(62, 7);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(455, 23);
			this.textBox5.TabIndex = 9;
			this.textBox5.Text = "A";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(2, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Topic：";
			// 
			// checkBox_retain
			// 
			this.checkBox_retain.AutoSize = true;
			this.checkBox_retain.Checked = true;
			this.checkBox_retain.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_retain.Location = new System.Drawing.Point(2, 183);
			this.checkBox_retain.Name = "checkBox_retain";
			this.checkBox_retain.Size = new System.Drawing.Size(69, 21);
			this.checkBox_retain.TabIndex = 43;
			this.checkBox_retain.Text = "Retain?";
			this.checkBox_retain.UseVisualStyleBackColor = true;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12312952.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "MQTT v3.1.1";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormMqttServer
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
			this.Name = "FormMqttServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MQTT 服务器";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMqttServer_FormClosing);
			this.Load += new System.EventHandler(this.FormClient_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.tabPage6.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox_publish_clientID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label_receive_count;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox_long_message_hide;
		private System.Windows.Forms.CheckBox checkBox_publish_isHex;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton_recv_UTF8;
		private System.Windows.Forms.RadioButton radioButton_recv_ASCII;
		private System.Windows.Forms.RadioButton radioButton_recv_Hex;
		private System.Windows.Forms.RadioButton radioButton_recv_Unicode;
		private System.Windows.Forms.RadioButton radioButton_recv_gb2312;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox textBox_session_port;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox_session_ip;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_session_onlineTime;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox_session_select;
		private System.Windows.Forms.TextBox textBox_session_clientID;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox_session_rsa;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox_session_topics;
		private System.Windows.Forms.TextBox textBox_session_willTopic;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox_session_userName;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox_publish_timer;
		private System.Windows.Forms.TextBox textBox_session_activeTime;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox checkBox_retain;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox_login_password;
		private System.Windows.Forms.Label label_login_password;
		private System.Windows.Forms.TextBox textBox_login_name;
		private System.Windows.Forms.Label label_login_name;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_receive_size;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButton_every_minute;
        private System.Windows.Forms.RadioButton radioButton_every_seconds;
        private System.Windows.Forms.RadioButton radioButton_every_hour;
        private HslControls.HslBarChart hslBarChart1;
        private System.Windows.Forms.RadioButton radioButton_every_day;
        private System.Windows.Forms.CheckBox checkBox_skip_zero;
		private System.Windows.Forms.Button button_publish_test;
		private DemoControl.SslServerControl sslServerControl1;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button button_device_remove;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button button_device_add;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_guid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_form;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_device;
		private System.Windows.Forms.Panel panel8;
		private MQTT.MqttTopicControl mqttTopicControl1;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox_redir_name5;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox textBox_redir_name4;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox textBox_redir_name3;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox textBox_redir_name2;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox textBox_redir_name1;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox textBox_redir_id5;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox textBox_redir_id4;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox textBox_redir_id3;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox textBox_redir_id2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox_redir_id1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label32;
	}
}