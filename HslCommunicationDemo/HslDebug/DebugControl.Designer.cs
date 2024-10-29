namespace HslCommunicationDemo.HslDebug
{
	partial class DebugControl
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
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label_recv_count = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox_send_intenal = new System.Windows.Forms.TextBox();
			this.checkBox_send_cycle = new System.Windows.Forms.CheckBox();
			this.checkBox_show_header = new System.Windows.Forms.CheckBox();
			this.richTextBox_main = new System.Windows.Forms.RichTextBox();
			this.label_send_count = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.radioButton_append_crc16 = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0d0a = new System.Windows.Forms.RadioButton();
			this.radioButton_append_none = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0a = new System.Windows.Forms.RadioButton();
			this.radioButton_append_0d = new System.Windows.Forms.RadioButton();
			this.label_append = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.checkBox_show_send = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button_send = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox_stop_show = new System.Windows.Forms.CheckBox();
			this.checkBox_auto_return = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioButton_send_cycle = new System.Windows.Forms.RadioButton();
			this.radioButton_send_text = new System.Windows.Forms.RadioButton();
			this.linkLabel_build_message = new System.Windows.Forms.LinkLabel();
			this.comboBox_sessions = new System.Windows.Forms.ComboBox();
			this.label_session_count = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.radioButton_send_all = new System.Windows.Forms.RadioButton();
			this.radioButton_send_single = new System.Windows.Forms.RadioButton();
			this.textBox_send_info = new System.Windows.Forms.TextBox();
			this.comboBox_encoding = new System.Windows.Forms.ComboBox();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(83, 3);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(47, 17);
			this.linkLabel1.TabIndex = 64;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "管理(0)";
			// 
			// label_recv_count
			// 
			this.label_recv_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_recv_count.AutoSize = true;
			this.label_recv_count.ForeColor = System.Drawing.Color.Gray;
			this.label_recv_count.Location = new System.Drawing.Point(416, 526);
			this.label_recv_count.Name = "label_recv_count";
			this.label_recv_count.Size = new System.Drawing.Size(76, 17);
			this.label_recv_count.TabIndex = 62;
			this.label_recv_count.Text = "Recv Count:";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(7, 447);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox5.Size = new System.Drawing.Size(854, 74);
			this.textBox5.TabIndex = 44;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.Gray;
			this.label11.Location = new System.Drawing.Point(977, 526);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(25, 17);
			this.label11.TabIndex = 61;
			this.label11.Text = "ms";
			// 
			// textBox_send_intenal
			// 
			this.textBox_send_intenal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_send_intenal.Location = new System.Drawing.Point(922, 522);
			this.textBox_send_intenal.Name = "textBox_send_intenal";
			this.textBox_send_intenal.Size = new System.Drawing.Size(49, 23);
			this.textBox_send_intenal.TabIndex = 60;
			this.textBox_send_intenal.Text = "1000";
			// 
			// checkBox_send_cycle
			// 
			this.checkBox_send_cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_send_cycle.AutoSize = true;
			this.checkBox_send_cycle.Location = new System.Drawing.Point(867, 525);
			this.checkBox_send_cycle.Name = "checkBox_send_cycle";
			this.checkBox_send_cycle.Size = new System.Drawing.Size(51, 21);
			this.checkBox_send_cycle.TabIndex = 59;
			this.checkBox_send_cycle.Text = "循环";
			this.checkBox_send_cycle.UseVisualStyleBackColor = true;
			// 
			// checkBox_show_header
			// 
			this.checkBox_show_header.AutoSize = true;
			this.checkBox_show_header.Checked = true;
			this.checkBox_show_header.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_header.Location = new System.Drawing.Point(391, 4);
			this.checkBox_show_header.Name = "checkBox_show_header";
			this.checkBox_show_header.Size = new System.Drawing.Size(135, 21);
			this.checkBox_show_header.TabIndex = 58;
			this.checkBox_show_header.Text = "是否显示消息头信息";
			this.checkBox_show_header.UseVisualStyleBackColor = true;
			// 
			// richTextBox_main
			// 
			this.richTextBox_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_main.Location = new System.Drawing.Point(4, 27);
			this.richTextBox_main.Name = "richTextBox_main";
			this.richTextBox_main.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.richTextBox_main.Size = new System.Drawing.Size(857, 383);
			this.richTextBox_main.TabIndex = 57;
			this.richTextBox_main.Text = "";
			// 
			// label_send_count
			// 
			this.label_send_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_send_count.AutoSize = true;
			this.label_send_count.ForeColor = System.Drawing.Color.Gray;
			this.label_send_count.Location = new System.Drawing.Point(283, 526);
			this.label_send_count.Name = "label_send_count";
			this.label_send_count.Size = new System.Drawing.Size(78, 17);
			this.label_send_count.TabIndex = 55;
			this.label_send_count.Text = "Send Count:";
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BackColor = System.Drawing.SystemColors.Control;
			this.panel4.Controls.Add(this.radioButton_append_crc16);
			this.panel4.Controls.Add(this.radioButton_append_0d0a);
			this.panel4.Controls.Add(this.radioButton_append_none);
			this.panel4.Controls.Add(this.radioButton_append_0a);
			this.panel4.Controls.Add(this.radioButton_append_0d);
			this.panel4.Controls.Add(this.label_append);
			this.panel4.Location = new System.Drawing.Point(424, 415);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(339, 28);
			this.panel4.TabIndex = 53;
			// 
			// radioButton_append_crc16
			// 
			this.radioButton_append_crc16.AutoSize = true;
			this.radioButton_append_crc16.Location = new System.Drawing.Point(273, 4);
			this.radioButton_append_crc16.Name = "radioButton_append_crc16";
			this.radioButton_append_crc16.Size = new System.Drawing.Size(57, 21);
			this.radioButton_append_crc16.TabIndex = 5;
			this.radioButton_append_crc16.Text = "crc16";
			this.radioButton_append_crc16.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_0d0a
			// 
			this.radioButton_append_0d0a.AutoSize = true;
			this.radioButton_append_0d0a.Location = new System.Drawing.Point(217, 4);
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
			this.radioButton_append_none.Location = new System.Drawing.Point(67, 4);
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
			this.radioButton_append_0a.Location = new System.Drawing.Point(172, 4);
			this.radioButton_append_0a.Name = "radioButton_append_0a";
			this.radioButton_append_0a.Size = new System.Drawing.Size(38, 21);
			this.radioButton_append_0a.TabIndex = 1;
			this.radioButton_append_0a.Text = "\\n";
			this.radioButton_append_0a.UseVisualStyleBackColor = true;
			// 
			// radioButton_append_0d
			// 
			this.radioButton_append_0d.AutoSize = true;
			this.radioButton_append_0d.Location = new System.Drawing.Point(129, 4);
			this.radioButton_append_0d.Name = "radioButton_append_0d";
			this.radioButton_append_0d.Size = new System.Drawing.Size(36, 21);
			this.radioButton_append_0d.TabIndex = 0;
			this.radioButton_append_0d.Text = "\\r";
			this.radioButton_append_0d.UseVisualStyleBackColor = true;
			// 
			// label_append
			// 
			this.label_append.AutoSize = true;
			this.label_append.Location = new System.Drawing.Point(4, 6);
			this.label_append.Name = "label_append";
			this.label_append.Size = new System.Drawing.Size(57, 17);
			this.label_append.TabIndex = 2;
			this.label_append.Text = "Append:";
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(908, 1);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(91, 25);
			this.button5.TabIndex = 50;
			this.button5.Text = "清空";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button_clear_Click);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Gray;
			this.label8.Location = new System.Drawing.Point(6, 526);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(92, 17);
			this.label8.TabIndex = 48;
			this.label8.Text = "已选择字节数：";
			// 
			// checkBox_show_send
			// 
			this.checkBox_show_send.AutoSize = true;
			this.checkBox_show_send.Checked = true;
			this.checkBox_show_send.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_send.Location = new System.Drawing.Point(188, 4);
			this.checkBox_show_send.Name = "checkBox_show_send";
			this.checkBox_show_send.Size = new System.Drawing.Size(123, 21);
			this.checkBox_show_send.TabIndex = 47;
			this.checkBox_show_send.Text = "是否显示发送数据";
			this.checkBox_show_send.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 17);
			this.label7.TabIndex = 46;
			this.label7.Text = "数据收发显示：";
			// 
			// button_send
			// 
			this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_send.Location = new System.Drawing.Point(865, 448);
			this.button_send.Name = "button_send";
			this.button_send.Size = new System.Drawing.Size(131, 74);
			this.button_send.TabIndex = 45;
			this.button_send.Text = "发送数据";
			this.button_send.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 420);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 17);
			this.label6.TabIndex = 43;
			this.label6.Text = "发送：";
			// 
			// checkBox_stop_show
			// 
			this.checkBox_stop_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_stop_show.Location = new System.Drawing.Point(772, 409);
			this.checkBox_stop_show.Name = "checkBox_stop_show";
			this.checkBox_stop_show.Size = new System.Drawing.Size(89, 21);
			this.checkBox_stop_show.TabIndex = 54;
			this.checkBox_stop_show.Text = "暂停显示";
			this.checkBox_stop_show.UseVisualStyleBackColor = true;
			// 
			// checkBox_auto_return
			// 
			this.checkBox_auto_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_auto_return.AutoSize = true;
			this.checkBox_auto_return.Location = new System.Drawing.Point(772, 427);
			this.checkBox_auto_return.Name = "checkBox_auto_return";
			this.checkBox_auto_return.Size = new System.Drawing.Size(75, 21);
			this.checkBox_auto_return.TabIndex = 56;
			this.checkBox_auto_return.Text = "自动返回";
			this.checkBox_auto_return.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.radioButton_send_cycle);
			this.panel2.Controls.Add(this.radioButton_send_text);
			this.panel2.Location = new System.Drawing.Point(651, 520);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(192, 28);
			this.panel2.TabIndex = 63;
			// 
			// radioButton_send_cycle
			// 
			this.radioButton_send_cycle.AutoSize = true;
			this.radioButton_send_cycle.Location = new System.Drawing.Point(100, 3);
			this.radioButton_send_cycle.Name = "radioButton_send_cycle";
			this.radioButton_send_cycle.Size = new System.Drawing.Size(98, 21);
			this.radioButton_send_cycle.TabIndex = 1;
			this.radioButton_send_cycle.Text = "列表顺序循环";
			this.radioButton_send_cycle.UseVisualStyleBackColor = true;
			// 
			// radioButton_send_text
			// 
			this.radioButton_send_text.AutoSize = true;
			this.radioButton_send_text.Checked = true;
			this.radioButton_send_text.Location = new System.Drawing.Point(7, 3);
			this.radioButton_send_text.Name = "radioButton_send_text";
			this.radioButton_send_text.Size = new System.Drawing.Size(86, 21);
			this.radioButton_send_text.TabIndex = 0;
			this.radioButton_send_text.TabStop = true;
			this.radioButton_send_text.Text = "使用输入框";
			this.radioButton_send_text.UseVisualStyleBackColor = true;
			// 
			// linkLabel_build_message
			// 
			this.linkLabel_build_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_build_message.AutoSize = true;
			this.linkLabel_build_message.Location = new System.Drawing.Point(554, 527);
			this.linkLabel_build_message.Name = "linkLabel_build_message";
			this.linkLabel_build_message.Size = new System.Drawing.Size(56, 17);
			this.linkLabel_build_message.TabIndex = 65;
			this.linkLabel_build_message.TabStop = true;
			this.linkLabel_build_message.Text = "构建报文";
			// 
			// comboBox_sessions
			// 
			this.comboBox_sessions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_sessions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_sessions.FormattingEnabled = true;
			this.comboBox_sessions.Location = new System.Drawing.Point(46, 416);
			this.comboBox_sessions.Name = "comboBox_sessions";
			this.comboBox_sessions.Size = new System.Drawing.Size(226, 25);
			this.comboBox_sessions.TabIndex = 66;
			// 
			// label_session_count
			// 
			this.label_session_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_session_count.AutoSize = true;
			this.label_session_count.ForeColor = System.Drawing.Color.Gray;
			this.label_session_count.Location = new System.Drawing.Point(189, 526);
			this.label_session_count.Name = "label_session_count";
			this.label_session_count.Size = new System.Drawing.Size(70, 17);
			this.label_session_count.TabIndex = 67;
			this.label_session_count.Text = "会话数量: 0";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Location = new System.Drawing.Point(862, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(140, 383);
			this.panel1.TabIndex = 68;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(5, 22);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(129, 361);
			this.listBox1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "数据包(双击)";
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BackColor = System.Drawing.SystemColors.Control;
			this.panel5.Controls.Add(this.radioButton_send_all);
			this.panel5.Controls.Add(this.radioButton_send_single);
			this.panel5.Location = new System.Drawing.Point(865, 414);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(131, 28);
			this.panel5.TabIndex = 69;
			// 
			// radioButton_send_all
			// 
			this.radioButton_send_all.AutoSize = true;
			this.radioButton_send_all.Location = new System.Drawing.Point(72, 3);
			this.radioButton_send_all.Name = "radioButton_send_all";
			this.radioButton_send_all.Size = new System.Drawing.Size(50, 21);
			this.radioButton_send_all.TabIndex = 1;
			this.radioButton_send_all.Text = "广播";
			this.radioButton_send_all.UseVisualStyleBackColor = true;
			// 
			// radioButton_send_single
			// 
			this.radioButton_send_single.AutoSize = true;
			this.radioButton_send_single.Checked = true;
			this.radioButton_send_single.Location = new System.Drawing.Point(7, 3);
			this.radioButton_send_single.Name = "radioButton_send_single";
			this.radioButton_send_single.Size = new System.Drawing.Size(50, 21);
			this.radioButton_send_single.TabIndex = 0;
			this.radioButton_send_single.TabStop = true;
			this.radioButton_send_single.Text = "单播";
			this.radioButton_send_single.UseVisualStyleBackColor = true;
			// 
			// textBox_send_info
			// 
			this.textBox_send_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_send_info.ForeColor = System.Drawing.Color.Gray;
			this.textBox_send_info.Location = new System.Drawing.Point(579, 5);
			this.textBox_send_info.Name = "textBox_send_info";
			this.textBox_send_info.ReadOnly = true;
			this.textBox_send_info.Size = new System.Drawing.Size(311, 16);
			this.textBox_send_info.TabIndex = 70;
			this.textBox_send_info.Text = "<sleep=100> 单独一行可以分割延时发送";
			// 
			// comboBox_encoding
			// 
			this.comboBox_encoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_encoding.FormattingEnabled = true;
			this.comboBox_encoding.Items.AddRange(new object[] {
            "Binary",
            "ASCII",
            "Unicode"});
			this.comboBox_encoding.Location = new System.Drawing.Point(278, 416);
			this.comboBox_encoding.Name = "comboBox_encoding";
			this.comboBox_encoding.Size = new System.Drawing.Size(140, 25);
			this.comboBox_encoding.TabIndex = 71;
			// 
			// DebugControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.comboBox_encoding);
			this.Controls.Add(this.textBox_send_info);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label_session_count);
			this.Controls.Add(this.comboBox_sessions);
			this.Controls.Add(this.linkLabel_build_message);
			this.Controls.Add(this.label_recv_count);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox_send_intenal);
			this.Controls.Add(this.checkBox_send_cycle);
			this.Controls.Add(this.checkBox_show_header);
			this.Controls.Add(this.richTextBox_main);
			this.Controls.Add(this.label_send_count);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.checkBox_show_send);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button_send);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.checkBox_stop_show);
			this.Controls.Add(this.checkBox_auto_return);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "DebugControl";
			this.Size = new System.Drawing.Size(1003, 548);
			this.Load += new System.EventHandler(this.DebugControl_Load);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label_recv_count;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_send_intenal;
		private System.Windows.Forms.CheckBox checkBox_send_cycle;
		private System.Windows.Forms.CheckBox checkBox_show_header;
		private System.Windows.Forms.RichTextBox richTextBox_main;
		private System.Windows.Forms.Label label_send_count;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton radioButton_append_crc16;
		private System.Windows.Forms.RadioButton radioButton_append_0d0a;
		private System.Windows.Forms.RadioButton radioButton_append_none;
		private System.Windows.Forms.RadioButton radioButton_append_0a;
		private System.Windows.Forms.RadioButton radioButton_append_0d;
		private System.Windows.Forms.Label label_append;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox checkBox_show_send;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button_send;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBox_stop_show;
		private System.Windows.Forms.CheckBox checkBox_auto_return;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioButton_send_cycle;
		private System.Windows.Forms.RadioButton radioButton_send_text;
		private System.Windows.Forms.LinkLabel linkLabel_build_message;
		private System.Windows.Forms.ComboBox comboBox_sessions;
		private System.Windows.Forms.Label label_session_count;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton radioButton_send_all;
		private System.Windows.Forms.RadioButton radioButton_send_single;
		private System.Windows.Forms.TextBox textBox_send_info;
        private System.Windows.Forms.ComboBox comboBox_encoding;
    }
}
