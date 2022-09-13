namespace HslCommunicationDemo.MQTT
{
	partial class FormMqttRpcDevice
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
			this.textBox_deviceTopic = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox_rsa = new System.Windows.Forms.CheckBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button25 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_deviceTopic);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.checkBox_rsa);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.textBox10);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBox9);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1001, 61);
			this.panel1.TabIndex = 8;
			// 
			// textBox_deviceTopic
			// 
			this.textBox_deviceTopic.Location = new System.Drawing.Point(575, 32);
			this.textBox_deviceTopic.Name = "textBox_deviceTopic";
			this.textBox_deviceTopic.Size = new System.Drawing.Size(134, 23);
			this.textBox_deviceTopic.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(497, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "设备主题：";
			// 
			// checkBox_rsa
			// 
			this.checkBox_rsa.AutoSize = true;
			this.checkBox_rsa.Location = new System.Drawing.Point(705, 5);
			this.checkBox_rsa.Name = "checkBox_rsa";
			this.checkBox_rsa.Size = new System.Drawing.Size(287, 21);
			this.checkBox_rsa.TabIndex = 18;
			this.checkBox_rsa.Text = "RSA加密 (支持v10.2.0版本及以上的MqttServer)";
			this.checkBox_rsa.UseVisualStyleBackColor = true;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(86, 32);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(405, 23);
			this.textBox3.TabIndex = 17;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "客户端标识：";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(584, 3);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(113, 23);
			this.textBox10.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(520, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "密码：";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(417, 3);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(91, 23);
			this.textBox9.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(341, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "用户名：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(823, 29);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(719, 29);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(243, 3);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(79, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "1883";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(189, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(115, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 6);
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
			this.panel2.Controls.Add(this.userControlReadWriteOp1);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Location = new System.Drawing.Point(3, 99);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1001, 513);
			this.panel2.TabIndex = 9;
			// 
			// userControlReadWriteOp1
			// 
			this.userControlReadWriteOp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userControlReadWriteOp1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteOp1.Location = new System.Drawing.Point(3, 1);
			this.userControlReadWriteOp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			this.userControlReadWriteOp1.Size = new System.Drawing.Size(993, 240);
			this.userControlReadWriteOp1.TabIndex = 5;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.textBox5);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.button25);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Location = new System.Drawing.Point(3, 243);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(993, 265);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "批量读取测试";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(63, 60);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox5.Size = new System.Drawing.Size(924, 199);
			this.textBox5.TabIndex = 10;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(9, 62);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 9;
			this.label13.Text = "结果：";
			// 
			// button25
			// 
			this.button25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button25.Location = new System.Drawing.Point(355, 24);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(82, 28);
			this.button25.TabIndex = 8;
			this.button25.Text = "批量读取";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new System.EventHandler(this.button25_Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(279, 27);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(59, 23);
			this.textBox6.TabIndex = 7;
			this.textBox6.Text = "10";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(237, 30);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 17);
			this.label12.TabIndex = 6;
			this.label12.Text = "长度：";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(63, 27);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(168, 23);
			this.textBox7.TabIndex = 5;
			this.textBox7.Text = "D100";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 30);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 4;
			this.label11.Text = "地址：";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.hsltechnology.cn/";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "MRPC";
			this.userControlHead1.Size = new System.Drawing.Size(1008, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 10;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormMqttRpcDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1008, 615);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormMqttRpcDevice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MqttRpcDevice [基于MRPC的PLC设备访问]";
			this.Load += new System.EventHandler(this.FormMqttRpcDevice_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBox_rsa;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private DemoControl.UserControlReadWriteOp userControlReadWriteOp1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button25;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label11;
		private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_deviceTopic;
		private System.Windows.Forms.Label label5;
	}
}