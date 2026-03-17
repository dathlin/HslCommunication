namespace HslCommunicationDemo.Vip
{
	partial class FormHslVpn
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
			this.textBox_password = new System.Windows.Forms.TextBox();
			this.textBox_clientId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_userName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_device_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_device_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button_log_continue = new System.Windows.Forms.Button();
			this.button_log_stop = new System.Windows.Forms.Button();
			this.label_session_count = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label_left_seconds = new System.Windows.Forms.Label();
			this.label_server_port = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
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
			this.userControlHead1.ProtocolInfo = "Hsl Vpn";
			this.userControlHead1.Size = new System.Drawing.Size(1000, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 15;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_password);
			this.panel1.Controls.Add(this.textBox_clientId);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBox_userName);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_device_port);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_device_ip);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.textBox_port);
			this.panel1.Controls.Add(this.textBox_ip);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Location = new System.Drawing.Point(4, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 70);
			this.panel1.TabIndex = 16;
			// 
			// textBox_password
			// 
			this.textBox_password.Location = new System.Drawing.Point(885, 38);
			this.textBox_password.Name = "textBox_password";
			this.textBox_password.PasswordChar = '*';
			this.textBox_password.Size = new System.Drawing.Size(100, 23);
			this.textBox_password.TabIndex = 13;
			// 
			// textBox_clientId
			// 
			this.textBox_clientId.Location = new System.Drawing.Point(438, 38);
			this.textBox_clientId.Name = "textBox_clientId";
			this.textBox_clientId.Size = new System.Drawing.Size(194, 23);
			this.textBox_clientId.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(823, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "密码：";
			// 
			// textBox_userName
			// 
			this.textBox_userName.Location = new System.Drawing.Point(702, 38);
			this.textBox_userName.Name = "textBox_userName";
			this.textBox_userName.Size = new System.Drawing.Size(115, 23);
			this.textBox_userName.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(359, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "客户端标识：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(638, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 17);
			this.label7.TabIndex = 10;
			this.label7.Text = "用户名：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(738, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(641, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_device_port
			// 
			this.textBox_device_port.Location = new System.Drawing.Point(302, 6);
			this.textBox_device_port.Name = "textBox_device_port";
			this.textBox_device_port.Size = new System.Drawing.Size(52, 23);
			this.textBox_device_port.TabIndex = 3;
			this.textBox_device_port.Text = "102";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(248, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox_device_ip
			// 
			this.textBox_device_ip.Location = new System.Drawing.Point(81, 6);
			this.textBox_device_ip.Name = "textBox_device_ip";
			this.textBox_device_ip.Size = new System.Drawing.Size(158, 23);
			this.textBox_device_ip.TabIndex = 1;
			this.textBox_device_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "设备Ip：";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 41);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 0;
			this.label9.Text = "服务器：";
			// 
			// textBox_port
			// 
			this.textBox_port.Location = new System.Drawing.Point(302, 38);
			this.textBox_port.Name = "textBox_port";
			this.textBox_port.Size = new System.Drawing.Size(52, 23);
			this.textBox_port.TabIndex = 3;
			this.textBox_port.Text = "7791";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(81, 38);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(158, 23);
			this.textBox_ip.TabIndex = 1;
			this.textBox_ip.Text = "118.195.180.167";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(248, 41);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "端口号：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.button_log_continue);
			this.panel2.Controls.Add(this.button_log_stop);
			this.panel2.Controls.Add(this.label_session_count);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label_left_seconds);
			this.panel2.Controls.Add(this.label_server_port);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(4, 110);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(992, 538);
			this.panel2.TabIndex = 17;
			// 
			// button_log_continue
			// 
			this.button_log_continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_log_continue.Location = new System.Drawing.Point(893, 2);
			this.button_log_continue.Name = "button_log_continue";
			this.button_log_continue.Size = new System.Drawing.Size(90, 27);
			this.button_log_continue.TabIndex = 9;
			this.button_log_continue.Text = "继续";
			this.button_log_continue.UseVisualStyleBackColor = true;
			this.button_log_continue.Click += new System.EventHandler(this.button_log_continue_Click);
			// 
			// button_log_stop
			// 
			this.button_log_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_log_stop.Location = new System.Drawing.Point(799, 2);
			this.button_log_stop.Name = "button_log_stop";
			this.button_log_stop.Size = new System.Drawing.Size(88, 27);
			this.button_log_stop.TabIndex = 8;
			this.button_log_stop.Text = "暂停";
			this.button_log_stop.UseVisualStyleBackColor = true;
			this.button_log_stop.Click += new System.EventHandler(this.button_log_stop_Click);
			// 
			// label_session_count
			// 
			this.label_session_count.AutoSize = true;
			this.label_session_count.Location = new System.Drawing.Point(681, 6);
			this.label_session_count.Name = "label_session_count";
			this.label_session_count.Size = new System.Drawing.Size(13, 17);
			this.label_session_count.TabIndex = 7;
			this.label_session_count.Text = "-";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(567, 6);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(83, 17);
			this.label11.TabIndex = 6;
			this.label11.Text = "当前会话数量:";
			// 
			// label_left_seconds
			// 
			this.label_left_seconds.AutoSize = true;
			this.label_left_seconds.Location = new System.Drawing.Point(461, 6);
			this.label_left_seconds.Name = "label_left_seconds";
			this.label_left_seconds.Size = new System.Drawing.Size(13, 17);
			this.label_left_seconds.TabIndex = 5;
			this.label_left_seconds.Text = "-";
			// 
			// label_server_port
			// 
			this.label_server_port.AutoSize = true;
			this.label_server_port.Location = new System.Drawing.Point(257, 6);
			this.label_server_port.Name = "label_server_port";
			this.label_server_port.Size = new System.Drawing.Size(13, 17);
			this.label_server_port.TabIndex = 4;
			this.label_server_port.Text = "-";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(345, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(103, 17);
			this.label10.TabIndex = 3;
			this.label10.Text = "剩余运行时长(秒):";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(168, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "服务器端口号:";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(7, 32);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(980, 501);
			this.textBox4.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "日志:";
			// 
			// FormHslVpn
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1000, 653);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormHslVpn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "端口映射";
			this.Load += new System.EventHandler(this.FormHslVpn_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_device_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_device_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_clientId;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_password;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_userName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox_ip;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label_left_seconds;
		private System.Windows.Forms.Label label_server_port;
		private System.Windows.Forms.Label label_session_count;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button_log_continue;
		private System.Windows.Forms.Button button_log_stop;
	}
}