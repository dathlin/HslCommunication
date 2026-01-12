namespace HslCommunicationDemo.PLC.Secs
{
	partial class FormSecsHsmsServer
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
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox_online_max = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox_device_id = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox_main = new System.Windows.Forms.RichTextBox();
			this.comboBox_log_style = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.checkBox_stop = new System.Windows.Forms.CheckBox();
			this.checkBox_show_send_message = new System.Windows.Forms.CheckBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button_device_read = new System.Windows.Forms.Button();
			this.checkBox_device_w = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button_device_save = new System.Windows.Forms.Button();
			this.button_device_send = new System.Windows.Forms.Button();
			this.textBox_device_f = new System.Windows.Forms.TextBox();
			this.textBox_device_s = new System.Windows.Forms.TextBox();
			this.textBox_device_send = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox_data_back = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.D = new System.Windows.Forms.Label();
			this.button_save_tree = new System.Windows.Forms.Button();
			this.button25 = new System.Windows.Forms.Button();
			this.textBox_function = new System.Windows.Forms.TextBox();
			this.textBox_stream = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNewSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSecsItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
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
			this.userControlHead1.ProtocolInfo = "Secs gem HSMS Server";
			this.userControlHead1.Size = new System.Drawing.Size(1046, 32);
			this.userControlHead1.TabIndex = 3;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_online_max);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.textBox_device_id);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button11);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1040, 41);
			this.panel1.TabIndex = 4;
			// 
			// textBox_online_max
			// 
			this.textBox_online_max.Location = new System.Drawing.Point(423, 8);
			this.textBox_online_max.Name = "textBox_online_max";
			this.textBox_online_max.Size = new System.Drawing.Size(57, 23);
			this.textBox_online_max.TabIndex = 35;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(329, 11);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(95, 17);
			this.label10.TabIndex = 34;
			this.label10.Text = "SessionsMax：";
			// 
			// textBox_device_id
			// 
			this.textBox_device_id.Location = new System.Drawing.Point(576, 8);
			this.textBox_device_id.Name = "textBox_device_id";
			this.textBox_device_id.Size = new System.Drawing.Size(57, 23);
			this.textBox_device_id.TabIndex = 33;
			this.textBox_device_id.Text = "1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(498, 11);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 17);
			this.label9.TabIndex = 32;
			this.label9.Text = "Device ID：";
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
			this.comboBox1.Location = new System.Drawing.Point(722, 6);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 25);
			this.comboBox1.TabIndex = 31;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(654, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 17);
			this.label5.TabIndex = 30;
			this.label5.Text = "Encode：";
			// 
			// button11
			// 
			this.button11.Enabled = false;
			this.button11.Location = new System.Drawing.Point(235, 5);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(83, 28);
			this.button11.TabIndex = 28;
			this.button11.Text = "关闭服务";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(145, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(74, 8);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(65, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "5000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.BackColor = System.Drawing.Color.LightGray;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 17;
			this.listBox1.Location = new System.Drawing.Point(754, 25);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(269, 208);
			this.listBox1.TabIndex = 34;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(753, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 17);
			this.label2.TabIndex = 33;
			this.label2.Text = "Online Client：";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(937, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 17);
			this.label4.TabIndex = 32;
			this.label4.Text = "Online Count:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.richTextBox_main);
			this.groupBox1.Controls.Add(this.comboBox_log_style);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.checkBox_stop);
			this.groupBox1.Controls.Add(this.checkBox_show_send_message);
			this.groupBox1.Controls.Add(this.treeView1);
			this.groupBox1.Location = new System.Drawing.Point(3, 79);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1040, 319);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "功能定义区";
			// 
			// richTextBox_main
			// 
			this.richTextBox_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_main.Location = new System.Drawing.Point(324, 39);
			this.richTextBox_main.Name = "richTextBox_main";
			this.richTextBox_main.Size = new System.Drawing.Size(709, 274);
			this.richTextBox_main.TabIndex = 45;
			this.richTextBox_main.Text = "";
			// 
			// comboBox_log_style
			// 
			this.comboBox_log_style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_log_style.FormattingEnabled = true;
			this.comboBox_log_style.Items.AddRange(new object[] {
            "XML",
            "Code",
            "Code-lite",
            "SML"});
			this.comboBox_log_style.Location = new System.Drawing.Point(442, 11);
			this.comboBox_log_style.Name = "comboBox_log_style";
			this.comboBox_log_style.Size = new System.Drawing.Size(101, 25);
			this.comboBox_log_style.TabIndex = 44;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(924, 9);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(55, 28);
			this.button2.TabIndex = 42;
			this.button2.Text = "clear";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(330, 15);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(106, 17);
			this.label11.TabIndex = 40;
			this.label11.Text = "SECS Log Area：";
			// 
			// checkBox_stop
			// 
			this.checkBox_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_stop.AutoSize = true;
			this.checkBox_stop.Location = new System.Drawing.Point(838, 14);
			this.checkBox_stop.Name = "checkBox_stop";
			this.checkBox_stop.Size = new System.Drawing.Size(58, 21);
			this.checkBox_stop.TabIndex = 41;
			this.checkBox_stop.Text = "STOP";
			this.checkBox_stop.UseVisualStyleBackColor = true;
			// 
			// checkBox_show_send_message
			// 
			this.checkBox_show_send_message.AutoSize = true;
			this.checkBox_show_send_message.Checked = true;
			this.checkBox_show_send_message.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_show_send_message.Location = new System.Drawing.Point(607, 14);
			this.checkBox_show_send_message.Name = "checkBox_show_send_message";
			this.checkBox_show_send_message.Size = new System.Drawing.Size(121, 21);
			this.checkBox_show_send_message.TabIndex = 43;
			this.checkBox_show_send_message.Text = "Show Send Msg";
			this.checkBox_show_send_message.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(7, 19);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(311, 295);
			this.treeView1.TabIndex = 36;
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 5);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Size = new System.Drawing.Size(745, 220);
			this.splitContainer1.SplitterDistance = 357;
			this.splitContainer1.TabIndex = 39;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button_device_read);
			this.panel3.Controls.Add(this.checkBox_device_w);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.button_device_save);
			this.panel3.Controls.Add(this.button_device_send);
			this.panel3.Controls.Add(this.textBox_device_f);
			this.panel3.Controls.Add(this.textBox_device_s);
			this.panel3.Controls.Add(this.textBox_device_send);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(357, 220);
			this.panel3.TabIndex = 1;
			// 
			// button_device_read
			// 
			this.button_device_read.Location = new System.Drawing.Point(271, 4);
			this.button_device_read.Name = "button_device_read";
			this.button_device_read.Size = new System.Drawing.Size(52, 28);
			this.button_device_read.TabIndex = 48;
			this.button_device_read.Text = "应答";
			this.button_device_read.UseVisualStyleBackColor = true;
			this.button_device_read.Click += new System.EventHandler(this.button_device_read_Click);
			// 
			// checkBox_device_w
			// 
			this.checkBox_device_w.AutoSize = true;
			this.checkBox_device_w.Location = new System.Drawing.Point(119, 8);
			this.checkBox_device_w.Name = "checkBox_device_w";
			this.checkBox_device_w.Size = new System.Drawing.Size(45, 21);
			this.checkBox_device_w.TabIndex = 47;
			this.checkBox_device_w.Text = "W?";
			this.checkBox_device_w.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(27, 17);
			this.label7.TabIndex = 41;
			this.label7.Text = "S：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(59, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 17);
			this.label8.TabIndex = 43;
			this.label8.Text = "F：";
			// 
			// button_device_save
			// 
			this.button_device_save.Location = new System.Drawing.Point(165, 4);
			this.button_device_save.Name = "button_device_save";
			this.button_device_save.Size = new System.Drawing.Size(49, 28);
			this.button_device_save.TabIndex = 46;
			this.button_device_save.Text = "保存";
			this.button_device_save.UseVisualStyleBackColor = true;
			// 
			// button_device_send
			// 
			this.button_device_send.Location = new System.Drawing.Point(217, 4);
			this.button_device_send.Name = "button_device_send";
			this.button_device_send.Size = new System.Drawing.Size(51, 28);
			this.button_device_send.TabIndex = 45;
			this.button_device_send.Text = "广播";
			this.button_device_send.UseVisualStyleBackColor = true;
			this.button_device_send.Click += new System.EventHandler(this.button_device_send_Click);
			// 
			// textBox_device_f
			// 
			this.textBox_device_f.Location = new System.Drawing.Point(85, 6);
			this.textBox_device_f.Name = "textBox_device_f";
			this.textBox_device_f.Size = new System.Drawing.Size(28, 23);
			this.textBox_device_f.TabIndex = 44;
			this.textBox_device_f.Text = "1";
			// 
			// textBox_device_s
			// 
			this.textBox_device_s.Location = new System.Drawing.Point(27, 6);
			this.textBox_device_s.Name = "textBox_device_s";
			this.textBox_device_s.Size = new System.Drawing.Size(29, 23);
			this.textBox_device_s.TabIndex = 42;
			this.textBox_device_s.Text = "1";
			// 
			// textBox_device_send
			// 
			this.textBox_device_send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_device_send.Location = new System.Drawing.Point(4, 51);
			this.textBox_device_send.Multiline = true;
			this.textBox_device_send.Name = "textBox_device_send";
			this.textBox_device_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_device_send.Size = new System.Drawing.Size(351, 166);
			this.textBox_device_send.TabIndex = 40;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Gray;
			this.label6.Location = new System.Drawing.Point(5, 31);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 17);
			this.label6.TabIndex = 39;
			this.label6.Text = "Data(用于主动发送)：";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.textBox_data_back);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.D);
			this.panel2.Controls.Add(this.button_save_tree);
			this.panel2.Controls.Add(this.button25);
			this.panel2.Controls.Add(this.textBox_function);
			this.panel2.Controls.Add(this.textBox_stream);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(384, 220);
			this.panel2.TabIndex = 0;
			// 
			// textBox_data_back
			// 
			this.textBox_data_back.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_data_back.Location = new System.Drawing.Point(4, 51);
			this.textBox_data_back.Multiline = true;
			this.textBox_data_back.Name = "textBox_data_back";
			this.textBox_data_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_data_back.Size = new System.Drawing.Size(372, 166);
			this.textBox_data_back.TabIndex = 38;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 17);
			this.label1.TabIndex = 27;
			this.label1.Text = "Stream：";
			// 
			// D
			// 
			this.D.AutoSize = true;
			this.D.ForeColor = System.Drawing.Color.Gray;
			this.D.Location = new System.Drawing.Point(3, 31);
			this.D.Name = "D";
			this.D.Size = new System.Drawing.Size(103, 17);
			this.D.TabIndex = 33;
			this.D.Text = "Data(用于应答)：";
			// 
			// button_save_tree
			// 
			this.button_save_tree.Location = new System.Drawing.Point(202, 3);
			this.button_save_tree.Name = "button_save_tree";
			this.button_save_tree.Size = new System.Drawing.Size(73, 28);
			this.button_save_tree.TabIndex = 35;
			this.button_save_tree.Text = "保存应答";
			this.button_save_tree.UseVisualStyleBackColor = true;
			this.button_save_tree.Click += new System.EventHandler(this.button_save_tree_Click);
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(277, 3);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(94, 28);
			this.button25.TabIndex = 31;
			this.button25.Text = "广播";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// textBox_function
			// 
			this.textBox_function.Location = new System.Drawing.Point(166, 5);
			this.textBox_function.Name = "textBox_function";
			this.textBox_function.Size = new System.Drawing.Size(32, 23);
			this.textBox_function.TabIndex = 30;
			this.textBox_function.Text = "1";
			// 
			// textBox_stream
			// 
			this.textBox_stream.Location = new System.Drawing.Point(65, 5);
			this.textBox_stream.Name = "textBox_stream";
			this.textBox_stream.Size = new System.Drawing.Size(32, 23);
			this.textBox_stream.TabIndex = 28;
			this.textBox_stream.Text = "1";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(98, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 17);
			this.label12.TabIndex = 29;
			this.label12.Text = "Function：";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(3, 404);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1040, 264);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1032, 234);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "日志";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.listBox1);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.splitContainer1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1026, 228);
			this.panel4.TabIndex = 35;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.addNewSecsItemToolStripMenuItem,
            this.editSecsItemToolStripMenuItem,
            this.deleteSecsItemToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
			// 
			// addNewSecsItemToolStripMenuItem
			// 
			this.addNewSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_add_16xLG;
			this.addNewSecsItemToolStripMenuItem.Name = "addNewSecsItemToolStripMenuItem";
			this.addNewSecsItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.addNewSecsItemToolStripMenuItem.Text = "AddNewSecsItem";
			this.addNewSecsItemToolStripMenuItem.Click += new System.EventHandler(this.addNewSecsItemToolStripMenuItem_Click);
			// 
			// editSecsItemToolStripMenuItem
			// 
			this.editSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.sig;
			this.editSecsItemToolStripMenuItem.Name = "editSecsItemToolStripMenuItem";
			this.editSecsItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editSecsItemToolStripMenuItem.Text = "EditSecsItem";
			this.editSecsItemToolStripMenuItem.Click += new System.EventHandler(this.editSecsItemToolStripMenuItem_Click);
			// 
			// deleteSecsItemToolStripMenuItem
			// 
			this.deleteSecsItemToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_Cancel_16xLG;
			this.deleteSecsItemToolStripMenuItem.Name = "deleteSecsItemToolStripMenuItem";
			this.deleteSecsItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteSecsItemToolStripMenuItem.Text = "DeleteSecsItem";
			this.deleteSecsItemToolStripMenuItem.Click += new System.EventHandler(this.deleteSecsItemToolStripMenuItem_Click);
			// 
			// sendMessageToolStripMenuItem
			// 
			this.sendMessageToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.Cloud_16xLG;
			this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
			this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.sendMessageToolStripMenuItem.Text = "Send Message";
			this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
			// 
			// FormSecsHsmsServer
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1046, 671);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormSecsHsmsServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormSecsHsmsServer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSecsHsmsServer_FormClosing);
			this.Load += new System.EventHandler(this.FormSecsHsmsServer_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox_data_back;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button button_save_tree;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_stream;
		private System.Windows.Forms.TextBox textBox_function;
		private System.Windows.Forms.Button button25;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label D;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button_device_save;
		private System.Windows.Forms.Button button_device_send;
		private System.Windows.Forms.TextBox textBox_device_f;
		private System.Windows.Forms.TextBox textBox_device_s;
		private System.Windows.Forms.TextBox textBox_device_send;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBox_device_w;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textBox_device_id;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox_online_max;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addNewSecsItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editSecsItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteSecsItemToolStripMenuItem;
		private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox_log_style;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox_stop;
        private System.Windows.Forms.CheckBox checkBox_show_send_message;
        private System.Windows.Forms.RichTextBox richTextBox_main;
        private System.Windows.Forms.Button button_device_read;
		private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
	}
}