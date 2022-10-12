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
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox_data = new System.Windows.Forms.TextBox();
			this.textBox_example = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.button_save_tree = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_stream = new System.Windows.Forms.TextBox();
			this.textBox_function = new System.Windows.Forms.TextBox();
			this.button25 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.D = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.userControlHead1.Size = new System.Drawing.Size(1005, 32);
			this.userControlHead1.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.button11);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(999, 41);
			this.panel1.TabIndex = 4;
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
			this.comboBox1.Location = new System.Drawing.Point(399, 6);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 25);
			this.comboBox1.TabIndex = 31;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(331, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 17);
			this.label5.TabIndex = 30;
			this.label5.Text = "Encode：";
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label11.Location = new System.Drawing.Point(512, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(467, 41);
			this.label11.TabIndex = 29;
			this.label11.Text = "本服务器不是严格的secs协议，仅支持和HSL组件完美通信。";
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
			this.label3.Location = new System.Drawing.Point(20, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.textBox_log);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Location = new System.Drawing.Point(3, 439);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(999, 173);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "日志";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 70);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(55, 26);
			this.button4.TabIndex = 19;
			this.button4.Text = "clear";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox_log
			// 
			this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_log.Location = new System.Drawing.Point(70, 17);
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(923, 150);
			this.textBox_log.TabIndex = 10;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(11, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 17;
			this.label13.Text = "接收：";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(9, 42);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(58, 21);
			this.checkBox1.TabIndex = 18;
			this.checkBox1.Text = "STOP";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox_data);
			this.groupBox1.Controls.Add(this.textBox_example);
			this.groupBox1.Controls.Add(this.treeView1);
			this.groupBox1.Controls.Add(this.button_save_tree);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox_stream);
			this.groupBox1.Controls.Add(this.textBox_function);
			this.groupBox1.Controls.Add(this.button25);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.D);
			this.groupBox1.Location = new System.Drawing.Point(3, 79);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(999, 354);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据定义区";
			// 
			// textBox_data
			// 
			this.textBox_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_data.Location = new System.Drawing.Point(332, 64);
			this.textBox_data.Multiline = true;
			this.textBox_data.Name = "textBox_data";
			this.textBox_data.Size = new System.Drawing.Size(661, 235);
			this.textBox_data.TabIndex = 38;
			// 
			// textBox_example
			// 
			this.textBox_example.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_example.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_example.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_example.ForeColor = System.Drawing.Color.Green;
			this.textBox_example.Location = new System.Drawing.Point(13, 301);
			this.textBox_example.Multiline = true;
			this.textBox_example.Name = "textBox_example";
			this.textBox_example.ReadOnly = true;
			this.textBox_example.Size = new System.Drawing.Size(980, 47);
			this.textBox_example.TabIndex = 37;
			this.textBox_example.Text = "Example:";
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(7, 19);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(311, 280);
			this.treeView1.TabIndex = 36;
			// 
			// button_save_tree
			// 
			this.button_save_tree.Location = new System.Drawing.Point(675, 17);
			this.button_save_tree.Name = "button_save_tree";
			this.button_save_tree.Size = new System.Drawing.Size(102, 28);
			this.button_save_tree.TabIndex = 35;
			this.button_save_tree.Text = "保存应答";
			this.button_save_tree.UseVisualStyleBackColor = true;
			this.button_save_tree.Click += new System.EventHandler(this.button_save_tree_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(329, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 17);
			this.label1.TabIndex = 27;
			this.label1.Text = "Stream：";
			// 
			// textBox_stream
			// 
			this.textBox_stream.Location = new System.Drawing.Point(391, 20);
			this.textBox_stream.Name = "textBox_stream";
			this.textBox_stream.Size = new System.Drawing.Size(49, 23);
			this.textBox_stream.TabIndex = 28;
			this.textBox_stream.Text = "1";
			// 
			// textBox_function
			// 
			this.textBox_function.Location = new System.Drawing.Point(513, 20);
			this.textBox_function.Name = "textBox_function";
			this.textBox_function.Size = new System.Drawing.Size(51, 23);
			this.textBox_function.TabIndex = 30;
			this.textBox_function.Text = "1";
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(807, 17);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(95, 28);
			this.button25.TabIndex = 31;
			this.button25.Text = "广播";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(446, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 17);
			this.label12.TabIndex = 29;
			this.label12.Text = "Function：";
			// 
			// D
			// 
			this.D.AutoSize = true;
			this.D.Location = new System.Drawing.Point(332, 44);
			this.D.Name = "D";
			this.D.Size = new System.Drawing.Size(47, 17);
			this.D.TabIndex = 33;
			this.D.Text = "Data：";
			// 
			// FormSecsHsmsServer
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1005, 616);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormSecsHsmsServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormSecsHsmsServer";
			this.Load += new System.EventHandler(this.FormSecsHsmsServer_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox_log;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox_data;
		private System.Windows.Forms.TextBox textBox_example;
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
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}