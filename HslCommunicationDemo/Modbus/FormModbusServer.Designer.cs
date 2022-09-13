namespace HslCommunicationDemo
{
    partial class FormModbusServer
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
            this.textBox_station = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_station_isolation = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ipv6 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox_remote_write = new System.Windows.Forms.CheckBox();
            this.checkBox_account = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.checkBox_forceReceiveOnce = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox_forceReceiveOnce);
            this.panel1.Controls.Add(this.textBox_station);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox_station_isolation);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox_ipv6);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox_remote_write);
            this.panel1.Controls.Add(this.checkBox_account);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 61);
            this.panel1.TabIndex = 0;
            // 
            // textBox_station
            // 
            this.textBox_station.Location = new System.Drawing.Point(588, 33);
            this.textBox_station.Name = "textBox_station";
            this.textBox_station.Size = new System.Drawing.Size(28, 23);
            this.textBox_station.TabIndex = 40;
            this.textBox_station.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Station：";
            // 
            // checkBox_station_isolation
            // 
            this.checkBox_station_isolation.AutoSize = true;
            this.checkBox_station_isolation.Location = new System.Drawing.Point(295, 35);
            this.checkBox_station_isolation.Name = "checkBox_station_isolation";
            this.checkBox_station_isolation.Size = new System.Drawing.Size(127, 21);
            this.checkBox_station_isolation.TabIndex = 38;
            this.checkBox_station_isolation.Text = "Station Isolation?";
            this.checkBox_station_isolation.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(723, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(39, 23);
            this.textBox3.TabIndex = 37;
            this.textBox3.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "最短接收时间：";
            // 
            // checkBox_ipv6
            // 
            this.checkBox_ipv6.AutoSize = true;
            this.checkBox_ipv6.Location = new System.Drawing.Point(430, 35);
            this.checkBox_ipv6.Name = "checkBox_ipv6";
            this.checkBox_ipv6.Size = new System.Drawing.Size(77, 21);
            this.checkBox_ipv6.TabIndex = 33;
            this.checkBox_ipv6.Text = "Use IPv6";
            this.checkBox_ipv6.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 34);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(148, 21);
            this.checkBox4.TabIndex = 32;
            this.checkBox4.Text = "使用ModbusRTU报文";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox_remote_write
            // 
            this.checkBox_remote_write.AutoSize = true;
            this.checkBox_remote_write.Checked = true;
            this.checkBox_remote_write.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_remote_write.Location = new System.Drawing.Point(165, 35);
            this.checkBox_remote_write.Name = "checkBox_remote_write";
            this.checkBox_remote_write.Size = new System.Drawing.Size(123, 21);
            this.checkBox_remote_write.TabIndex = 31;
            this.checkBox_remote_write.Text = "是否允许远程写入";
            this.checkBox_remote_write.UseVisualStyleBackColor = true;
            // 
            // checkBox_account
            // 
            this.checkBox_account.AutoSize = true;
            this.checkBox_account.Location = new System.Drawing.Point(884, 35);
            this.checkBox_account.Name = "checkBox_account";
            this.checkBox_account.Size = new System.Drawing.Size(75, 21);
            this.checkBox_account.TabIndex = 30;
            this.checkBox_account.Text = "账户登录";
            this.checkBox_account.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "ABCD",
            "BADC",
            "CDAB",
            "DCBA"});
            this.comboBox2.Location = new System.Drawing.Point(726, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 25);
            this.comboBox2.TabIndex = 29;
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(218, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 28);
            this.button11.TabIndex = 28;
            this.button11.Text = "关闭服务";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(884, 9);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(87, 21);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "字符串颠倒";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(622, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 28);
            this.button5.TabIndex = 9;
            this.button5.Text = "启动串口";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(461, 6);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(155, 23);
            this.textBox10.TabIndex = 8;
            this.textBox10.Text = "COM4-9600-8-N-1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(415, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "串口：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(309, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "客户端过滤";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "启动服务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(65, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "502";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.userControlReadWriteServer1);
            this.panel2.Location = new System.Drawing.Point(3, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 541);
            this.panel2.TabIndex = 1;
            // 
            // userControlReadWriteServer1
            // 
            this.userControlReadWriteServer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlReadWriteServer1.Location = new System.Drawing.Point(3, 0);
            this.userControlReadWriteServer1.Name = "userControlReadWriteServer1";
            this.userControlReadWriteServer1.Size = new System.Drawing.Size(989, 536);
            this.userControlReadWriteServer1.TabIndex = 0;
            // 
            // userControlHead1
            // 
            this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7782315.html";
            this.userControlHead1.Location = new System.Drawing.Point(0, 0);
            this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
            this.userControlHead1.Name = "userControlHead1";
            this.userControlHead1.ProtocolInfo = "Modbus Tcp + Rtu + Ascii";
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.TabIndex = 2;
            this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
            // 
            // checkBox_forceReceiveOnce
            // 
            this.checkBox_forceReceiveOnce.AutoSize = true;
            this.checkBox_forceReceiveOnce.Location = new System.Drawing.Point(768, 34);
            this.checkBox_forceReceiveOnce.Name = "checkBox_forceReceiveOnce";
            this.checkBox_forceReceiveOnce.Size = new System.Drawing.Size(107, 21);
            this.checkBox_forceReceiveOnce.TabIndex = 41;
            this.checkBox_forceReceiveOnce.Text = "ReceiveOnce?";
            this.checkBox_forceReceiveOnce.UseVisualStyleBackColor = true;
            // 
            // FormModbusServer
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
            this.Name = "FormModbusServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus虚拟服务器【同时支持Tcp和Rtu模式的服务器，数据支持线圈读写和寄存器读写，输入寄存器读取，离散输入读取】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
            this.Load += new System.EventHandler(this.FormSiemens_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox2;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.CheckBox checkBox_account;
		private DemoControl.UserControlReadWriteServer userControlReadWriteServer1;
		private System.Windows.Forms.CheckBox checkBox_remote_write;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox_ipv6;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_station_isolation;
		private System.Windows.Forms.TextBox textBox_station;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox_forceReceiveOnce;
	}
}