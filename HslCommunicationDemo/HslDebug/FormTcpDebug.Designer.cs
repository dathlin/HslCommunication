namespace HslCommunicationDemo
{
    partial class FormTcpDebug
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
			this.panel_main = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox_stop_show = new System.Windows.Forms.CheckBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.radioButton_append_crc16 = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0d0a = new System.Windows.Forms.RadioButton();
			this.radioButton_append_none = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0a = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0d = new System.Windows.Forms.RadioButton();
			this.label_append = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_ascii = new System.Windows.Forms.RadioButton();
			this.radioButton_binary = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.checkBox_show_time = new System.Windows.Forms.CheckBox();
			this.checkBox_show_send = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button_send = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel_tcp_udp = new System.Windows.Forms.Panel();
			this.radioButton_udp = new System.Windows.Forms.RadioButton();
			this.radioButton_tcp = new System.Windows.Forms.RadioButton();
			this.button_edit_hand = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.checkBox_auto_return = new System.Windows.Forms.CheckBox();
			this.panel_main.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel_tcp_udp.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_main
			// 
			this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_main.Controls.Add(this.checkBox_auto_return);
			this.panel_main.Controls.Add(this.label5);
			this.panel_main.Controls.Add(this.checkBox_stop_show);
			this.panel_main.Controls.Add(this.panel4);
			this.panel_main.Controls.Add(this.panel3);
			this.panel_main.Controls.Add(this.label2);
			this.panel_main.Controls.Add(this.button6);
			this.panel_main.Controls.Add(this.button5);
			this.panel_main.Controls.Add(this.button4);
			this.panel_main.Controls.Add(this.label8);
			this.panel_main.Controls.Add(this.textBox6);
			this.panel_main.Controls.Add(this.checkBox_show_time);
			this.panel_main.Controls.Add(this.checkBox_show_send);
			this.panel_main.Controls.Add(this.label7);
			this.panel_main.Controls.Add(this.button_send);
			this.panel_main.Controls.Add(this.textBox5);
			this.panel_main.Controls.Add(this.label6);
			this.panel_main.Location = new System.Drawing.Point(3, 103);
			this.panel_main.Name = "panel_main";
			this.panel_main.Size = new System.Drawing.Size(997, 528);
			this.panel_main.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Gray;
			this.label5.Location = new System.Drawing.Point(601, 506);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 17);
			this.label5.TabIndex = 33;
			this.label5.Text = "Send Count:";
			// 
			// checkBox_stop_show
			// 
			this.checkBox_stop_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_stop_show.AutoSize = true;
			this.checkBox_stop_show.Location = new System.Drawing.Point(881, 413);
			this.checkBox_stop_show.Name = "checkBox_stop_show";
			this.checkBox_stop_show.Size = new System.Drawing.Size(75, 21);
			this.checkBox_stop_show.TabIndex = 32;
			this.checkBox_stop_show.Text = "暂停显示";
			this.checkBox_stop_show.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel4.BackColor = System.Drawing.SystemColors.Control;
			this.panel4.Controls.Add(this.radioButton_append_crc16);
			this.panel4.Controls.Add(this.radioButton_append_0d0a);
			this.panel4.Controls.Add(this.radioButton_append_none);
			this.panel4.Controls.Add(this.radioButton_append_0a);
			this.panel4.Controls.Add(this.radioButton_append_0d);
			this.panel4.Controls.Add(this.label_append);
			this.panel4.Location = new System.Drawing.Point(248, 409);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(348, 28);
			this.panel4.TabIndex = 31;
			// 
			// radioButton_append_crc16
			// 
			this.radioButton_append_crc16.AutoSize = true;
			this.radioButton_append_crc16.Location = new System.Drawing.Point(281, 3);
			this.radioButton_append_crc16.Name = "radioButton_append_crc16";
			this.radioButton_append_crc16.Size = new System.Drawing.Size(57, 21);
			this.radioButton_append_crc16.TabIndex = 5;
			this.radioButton_append_crc16.Text = "crc16";
			this.radioButton_append_crc16.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_0d0a
			// 
			this.radioButton_append_0d0a.AutoSize = true;
			this.radioButton_append_0d0a.Location = new System.Drawing.Point(223, 3);
			this.radioButton_append_0d0a.Name = "radioButton_append_0d0a";
			this.radioButton_append_0d0a.Size = new System.Drawing.Size(48, 21);
			this.radioButton_append_0d0a.TabIndex = 4;
			this.radioButton_append_0d0a.Text = "\\r\\n";
			this.radioButton_append_0d0a.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_none
			// 
			this.radioButton_append_none.AutoSize = true;
			this.radioButton_append_none.Checked = true;
			this.radioButton_append_none.Location = new System.Drawing.Point(69, 4);
			this.radioButton_append_none.Name = "radioButton_append_none";
			this.radioButton_append_none.Size = new System.Drawing.Size(58, 21);
			this.radioButton_append_none.TabIndex = 3;
			this.radioButton_append_none.TabStop = true;
			this.radioButton_append_none.Text = "None";
			this.radioButton_append_none.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_0a
			// 
			this.radioButton_append_0a.AutoSize = true;
			this.radioButton_append_0a.Location = new System.Drawing.Point(179, 3);
			this.radioButton_append_0a.Name = "radioButton_append_0a";
			this.radioButton_append_0a.Size = new System.Drawing.Size(38, 21);
			this.radioButton_append_0a.TabIndex = 1;
			this.radioButton_append_0a.Text = "\\n";
			this.radioButton_append_0a.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_0d
			// 
			this.radioButton_append_0d.AutoSize = true;
			this.radioButton_append_0d.Location = new System.Drawing.Point(133, 3);
			this.radioButton_append_0d.Name = "radioButton_append_0d";
			this.radioButton_append_0d.Size = new System.Drawing.Size(36, 21);
			this.radioButton_append_0d.TabIndex = 0;
			this.radioButton_append_0d.Text = "\\r";
			this.radioButton_append_0d.UseVisualStyleBackColor = true;
			// 
			// label_append
			// 
			this.label_append.AutoSize = true;
			this.label_append.Location = new System.Drawing.Point(4, 5);
			this.label_append.Name = "label_append";
			this.label_append.Size = new System.Drawing.Size(57, 17);
			this.label_append.TabIndex = 2;
			this.label_append.Text = "Append:";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.radioButton_ascii);
			this.panel3.Controls.Add(this.radioButton_binary);
			this.panel3.Location = new System.Drawing.Point(87, 409);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(155, 28);
			this.panel3.TabIndex = 30;
			// 
			// radioButton_ascii
			// 
			this.radioButton_ascii.AutoSize = true;
			this.radioButton_ascii.Location = new System.Drawing.Point(86, 3);
			this.radioButton_ascii.Name = "radioButton_ascii";
			this.radioButton_ascii.Size = new System.Drawing.Size(57, 21);
			this.radioButton_ascii.TabIndex = 1;
			this.radioButton_ascii.Text = "ASCII";
			this.radioButton_ascii.UseVisualStyleBackColor = true;
			// 
			// radioButton_binary
			// 
			this.radioButton_binary.AutoSize = true;
			this.radioButton_binary.Checked = true;
			this.radioButton_binary.Location = new System.Drawing.Point(7, 3);
			this.radioButton_binary.Name = "radioButton_binary";
			this.radioButton_binary.Size = new System.Drawing.Size(62, 21);
			this.radioButton_binary.TabIndex = 0;
			this.radioButton_binary.TabStop = true;
			this.radioButton_binary.Text = "Binary";
			this.radioButton_binary.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(296, 506);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(273, 17);
			this.label2.TabIndex = 29;
			this.label2.Text = "If ASCII Format: use \\r , \\n means  0x0d  0x0a";
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Location = new System.Drawing.Point(602, 409);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 28);
			this.button6.TabIndex = 26;
			this.button6.Text = "toledo msg test";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(902, 1);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(91, 25);
			this.button5.TabIndex = 25;
			this.button5.Text = "清空";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(728, 408);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 28);
			this.button4.TabIndex = 23;
			this.button4.Text = "构建报文";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(4, 506);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 17);
			this.label8.TabIndex = 22;
			this.label8.Text = "已选择数据字节数：";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(3, 29);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(990, 376);
			this.textBox6.TabIndex = 21;
			// 
			// checkBox_show_time
			// 
			this.checkBox_show_time.AutoSize = true;
			this.checkBox_show_time.Checked = true;
			this.checkBox_show_time.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_time.Location = new System.Drawing.Point(299, 4);
			this.checkBox_show_time.Name = "checkBox_show_time";
			this.checkBox_show_time.Size = new System.Drawing.Size(99, 21);
			this.checkBox_show_time.TabIndex = 20;
			this.checkBox_show_time.Text = "是否显示时间";
			this.checkBox_show_time.UseVisualStyleBackColor = true;
			// 
			// checkBox_show_send
			// 
			this.checkBox_show_send.AutoSize = true;
			this.checkBox_show_send.Checked = true;
			this.checkBox_show_send.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_send.Location = new System.Drawing.Point(119, 4);
			this.checkBox_show_send.Name = "checkBox_show_send";
			this.checkBox_show_send.Size = new System.Drawing.Size(123, 21);
			this.checkBox_show_send.TabIndex = 19;
			this.checkBox_show_send.Text = "是否显示发送数据";
			this.checkBox_show_send.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "数据收发显示：";
			// 
			// button_send
			// 
			this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_send.Location = new System.Drawing.Point(881, 465);
			this.button_send.Name = "button_send";
			this.button_send.Size = new System.Drawing.Size(107, 37);
			this.button_send.TabIndex = 17;
			this.button_send.Text = "发送数据";
			this.button_send.UseVisualStyleBackColor = true;
			this.button_send.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(5, 441);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(869, 61);
			this.textBox5.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 414);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "数据发送区：";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel_tcp_udp);
			this.panel1.Controls.Add(this.button_edit_hand);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 61);
			this.panel1.TabIndex = 14;
			// 
			// panel_tcp_udp
			// 
			this.panel_tcp_udp.Controls.Add(this.radioButton_udp);
			this.panel_tcp_udp.Controls.Add(this.radioButton_tcp);
			this.panel_tcp_udp.Location = new System.Drawing.Point(51, 32);
			this.panel_tcp_udp.Name = "panel_tcp_udp";
			this.panel_tcp_udp.Size = new System.Drawing.Size(146, 23);
			this.panel_tcp_udp.TabIndex = 19;
			// 
			// radioButton_udp
			// 
			this.radioButton_udp.AutoSize = true;
			this.radioButton_udp.Location = new System.Drawing.Point(73, 1);
			this.radioButton_udp.Name = "radioButton_udp";
			this.radioButton_udp.Size = new System.Drawing.Size(51, 21);
			this.radioButton_udp.TabIndex = 1;
			this.radioButton_udp.Text = "UDP";
			this.radioButton_udp.UseVisualStyleBackColor = true;
			// 
			// radioButton_tcp
			// 
			this.radioButton_tcp.AutoSize = true;
			this.radioButton_tcp.Checked = true;
			this.radioButton_tcp.Location = new System.Drawing.Point(10, 1);
			this.radioButton_tcp.Name = "radioButton_tcp";
			this.radioButton_tcp.Size = new System.Drawing.Size(48, 21);
			this.radioButton_tcp.TabIndex = 0;
			this.radioButton_tcp.TabStop = true;
			this.radioButton_tcp.Text = "TCP";
			this.radioButton_tcp.UseVisualStyleBackColor = true;
			// 
			// button_edit_hand
			// 
			this.button_edit_hand.Location = new System.Drawing.Point(540, 1);
			this.button_edit_hand.Name = "button_edit_hand";
			this.button_edit_hand.Size = new System.Drawing.Size(110, 31);
			this.button_edit_hand.TabIndex = 18;
			this.button_edit_hand.Text = "编辑握手包";
			this.button_edit_hand.UseVisualStyleBackColor = true;
			this.button_edit_hand.Click += new System.EventHandler(this.button_edit_hand_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(463, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "握手包：0";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(776, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(679, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(374, 5);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(77, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "502";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(320, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Port：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(51, 5);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(258, 23);
			this.textBox_ip.TabIndex = 1;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip：";
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
			this.userControlHead1.ProtocolInfo = "TCP/UDP Clinet";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 21;
			// 
			// checkBox_auto_return
			// 
			this.checkBox_auto_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_auto_return.AutoSize = true;
			this.checkBox_auto_return.Location = new System.Drawing.Point(881, 438);
			this.checkBox_auto_return.Name = "checkBox_auto_return";
			this.checkBox_auto_return.Size = new System.Drawing.Size(75, 21);
			this.checkBox_auto_return.TabIndex = 34;
			this.checkBox_auto_return.Text = "暂停显示";
			this.checkBox_auto_return.UseVisualStyleBackColor = true;
			// 
			// FormTcpDebug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 633);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel_main);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormTcpDebug";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TCP/IP调试助手";
			this.Load += new System.EventHandler(this.FormTcpDebug_Load);
			this.panel_main.ResumeLayout(false);
			this.panel_main.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel_tcp_udp.ResumeLayout(false);
			this.panel_tcp_udp.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox checkBox_show_time;
        private System.Windows.Forms.CheckBox checkBox_show_send;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton radioButton_append_0d0a;
		private System.Windows.Forms.RadioButton radioButton_append_none;
		private System.Windows.Forms.RadioButton radioButton_append_0a;
		private System.Windows.Forms.RadioButton radioButton_append_0d;
		private System.Windows.Forms.Label label_append;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton_ascii;
		private System.Windows.Forms.RadioButton radioButton_binary;
		private System.Windows.Forms.CheckBox checkBox_stop_show;
		private System.Windows.Forms.RadioButton radioButton_append_crc16;
		private System.Windows.Forms.Button button_edit_hand;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel_tcp_udp;
		private System.Windows.Forms.RadioButton radioButton_udp;
		private System.Windows.Forms.RadioButton radioButton_tcp;
		private System.Windows.Forms.CheckBox checkBox_auto_return;
	}
}