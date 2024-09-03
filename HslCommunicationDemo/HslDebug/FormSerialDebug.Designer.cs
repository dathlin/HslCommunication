namespace HslCommunicationDemo
{
    partial class FormSerialDebug
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
			this.checkBox_until_empty = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.textBox_mqtt_password = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_mqtt_name = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_mqtt_topic = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_mqtt_port = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_mqtt_ip = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox_useMqtt = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.comboBox_portName = new System.Windows.Forms.ComboBox();
			this.comboBox_Parity = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox_StopBit = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox_DataBits = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_BaudRate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.debugControl1 = new HslCommunicationDemo.HslDebug.DebugControl();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox_until_empty);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.checkBox5);
			this.panel1.Controls.Add(this.comboBox_portName);
			this.panel1.Controls.Add(this.comboBox_Parity);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.textBox_StopBit);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.textBox_DataBits);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox_BaudRate);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 34);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(993, 71);
			this.panel1.TabIndex = 7;
			// 
			// checkBox_until_empty
			// 
			this.checkBox_until_empty.AutoSize = true;
			this.checkBox_until_empty.Checked = true;
			this.checkBox_until_empty.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_until_empty.Location = new System.Drawing.Point(695, 8);
			this.checkBox_until_empty.Name = "checkBox_until_empty";
			this.checkBox_until_empty.Size = new System.Drawing.Size(93, 21);
			this.checkBox_until_empty.TabIndex = 19;
			this.checkBox_until_empty.Text = "Until Empty";
			this.checkBox_until_empty.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.checkBox1);
			this.panel3.Controls.Add(this.textBox_mqtt_password);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.textBox_mqtt_name);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.textBox_mqtt_topic);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.textBox_mqtt_port);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.textBox_mqtt_ip);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.checkBox_useMqtt);
			this.panel3.Location = new System.Drawing.Point(3, 34);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(985, 32);
			this.panel3.TabIndex = 18;
			// 
			// textBox_mqtt_password
			// 
			this.textBox_mqtt_password.Location = new System.Drawing.Point(587, 3);
			this.textBox_mqtt_password.Name = "textBox_mqtt_password";
			this.textBox_mqtt_password.Size = new System.Drawing.Size(76, 23);
			this.textBox_mqtt_password.TabIndex = 23;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(537, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 17);
			this.label8.TabIndex = 22;
			this.label8.Text = "密码：";
			// 
			// textBox_mqtt_name
			// 
			this.textBox_mqtt_name.Location = new System.Drawing.Point(416, 4);
			this.textBox_mqtt_name.Name = "textBox_mqtt_name";
			this.textBox_mqtt_name.Size = new System.Drawing.Size(110, 23);
			this.textBox_mqtt_name.TabIndex = 21;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(363, 7);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 20;
			this.label9.Text = "用户名：";
			// 
			// textBox_mqtt_topic
			// 
			this.textBox_mqtt_topic.Location = new System.Drawing.Point(730, 4);
			this.textBox_mqtt_topic.Name = "textBox_mqtt_topic";
			this.textBox_mqtt_topic.Size = new System.Drawing.Size(103, 23);
			this.textBox_mqtt_topic.TabIndex = 19;
			this.textBox_mqtt_topic.Text = "Data";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(671, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 18;
			this.label2.Text = "主题：";
			// 
			// textBox_mqtt_port
			// 
			this.textBox_mqtt_port.Location = new System.Drawing.Point(296, 3);
			this.textBox_mqtt_port.Name = "textBox_mqtt_port";
			this.textBox_mqtt_port.Size = new System.Drawing.Size(55, 23);
			this.textBox_mqtt_port.TabIndex = 17;
			this.textBox_mqtt_port.Text = "1883";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(247, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "Port：";
			// 
			// textBox_mqtt_ip
			// 
			this.textBox_mqtt_ip.Location = new System.Drawing.Point(131, 4);
			this.textBox_mqtt_ip.Name = "textBox_mqtt_ip";
			this.textBox_mqtt_ip.Size = new System.Drawing.Size(110, 23);
			this.textBox_mqtt_ip.TabIndex = 15;
			this.textBox_mqtt_ip.Text = "127.0.0.1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(99, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "IP：";
			// 
			// checkBox_useMqtt
			// 
			this.checkBox_useMqtt.AutoSize = true;
			this.checkBox_useMqtt.Location = new System.Drawing.Point(4, 5);
			this.checkBox_useMqtt.Name = "checkBox_useMqtt";
			this.checkBox_useMqtt.Size = new System.Drawing.Size(87, 21);
			this.checkBox_useMqtt.TabIndex = 0;
			this.checkBox_useMqtt.Text = "转发MQTT";
			this.checkBox_useMqtt.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(596, 8);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(84, 21);
			this.checkBox5.TabIndex = 17;
			this.checkBox5.Text = "RtsEnable";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// comboBox_portName
			// 
			this.comboBox_portName.FormattingEnabled = true;
			this.comboBox_portName.Location = new System.Drawing.Point(62, 4);
			this.comboBox_portName.Name = "comboBox_portName";
			this.comboBox_portName.Size = new System.Drawing.Size(105, 25);
			this.comboBox_portName.TabIndex = 16;
			// 
			// comboBox_Parity
			// 
			this.comboBox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Parity.FormattingEnabled = true;
			this.comboBox_Parity.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
			this.comboBox_Parity.Location = new System.Drawing.Point(524, 6);
			this.comboBox_Parity.Name = "comboBox_Parity";
			this.comboBox_Parity.Size = new System.Drawing.Size(59, 25);
			this.comboBox_Parity.TabIndex = 15;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(481, 9);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(44, 17);
			this.label24.TabIndex = 14;
			this.label24.Text = "奇偶：";
			// 
			// textBox_StopBit
			// 
			this.textBox_StopBit.Location = new System.Drawing.Point(451, 6);
			this.textBox_StopBit.Name = "textBox_StopBit";
			this.textBox_StopBit.Size = new System.Drawing.Size(23, 23);
			this.textBox_StopBit.TabIndex = 13;
			this.textBox_StopBit.Text = "1";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(392, 9);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(56, 17);
			this.label23.TabIndex = 12;
			this.label23.Text = "停止位：";
			// 
			// textBox_DataBits
			// 
			this.textBox_DataBits.Location = new System.Drawing.Point(355, 6);
			this.textBox_DataBits.Name = "textBox_DataBits";
			this.textBox_DataBits.Size = new System.Drawing.Size(24, 23);
			this.textBox_DataBits.TabIndex = 11;
			this.textBox_DataBits.Text = "8";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(293, 9);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 17);
			this.label22.TabIndex = 10;
			this.label22.Text = "数据位：";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(892, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭串口";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(795, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "打开串口";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_BaudRate
			// 
			this.textBox_BaudRate.Location = new System.Drawing.Point(240, 6);
			this.textBox_BaudRate.Name = "textBox_BaudRate";
			this.textBox_BaudRate.Size = new System.Drawing.Size(47, 23);
			this.textBox_BaudRate.TabIndex = 3;
			this.textBox_BaudRate.Text = "9600";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(173, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "波特率：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Com口：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.debugControl1);
			this.panel2.Location = new System.Drawing.Point(3, 107);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(993, 557);
			this.panel2.TabIndex = 13;
			// 
			// debugControl1
			// 
			this.debugControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.debugControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.debugControl1.Location = new System.Drawing.Point(0, 0);
			this.debugControl1.Name = "debugControl1";
			this.debugControl1.Size = new System.Drawing.Size(991, 555);
			this.debugControl1.TabIndex = 0;
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
			this.userControlHead1.ProtocolInfo = "serial";
			this.userControlHead1.Size = new System.Drawing.Size(1000, 32);
			this.userControlHead1.TabIndex = 14;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(852, 5);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(76, 21);
			this.checkBox1.TabIndex = 24;
			this.checkBox1.Text = "转发DTU";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// FormSerialDebug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1000, 666);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormSerialDebug";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "串口调试工具";
			this.Load += new System.EventHandler(this.FormSerialDebug_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_StopBit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_DataBits;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_BaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBox_mqtt_topic;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_mqtt_port;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_mqtt_ip;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox_useMqtt;
		private System.Windows.Forms.TextBox textBox_mqtt_password;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox_mqtt_name;
		private System.Windows.Forms.Label label9;
		private HslDebug.DebugControl debugControl1;
		private System.Windows.Forms.CheckBox checkBox_until_empty;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}