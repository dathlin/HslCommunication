namespace HslCommunicationDemo
{
    partial class FormModbus
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
			this.checkBox_DisableFunctionCode06 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox_station_check = new System.Windows.Forms.CheckBox();
			this.textBox_batch_length = new System.Windows.Forms.TextBox();
			this.label_batch_length = new System.Windows.Forms.Label();
			this.textBox_BroadcastStation = new System.Windows.Forms.TextBox();
			this.label_BroadcastStation = new System.Windows.Forms.Label();
			this.pipeSelectControl1 = new HslCommunicationDemo.DemoControl.PipeSelectControl();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteDevice1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteDevice();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkBox_DisableFunctionCode06);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkBox_station_check);
			this.panel1.Controls.Add(this.textBox_batch_length);
			this.panel1.Controls.Add(this.label_batch_length);
			this.panel1.Controls.Add(this.textBox_BroadcastStation);
			this.panel1.Controls.Add(this.label_BroadcastStation);
			this.panel1.Controls.Add(this.pipeSelectControl1);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox15);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.checkBox3);
			this.panel1.Location = new System.Drawing.Point(3, 34);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(990, 83);
			this.panel1.TabIndex = 0;
			// 
			// checkBox_DisableFunctionCode06
			// 
			this.checkBox_DisableFunctionCode06.AutoSize = true;
			this.checkBox_DisableFunctionCode06.Location = new System.Drawing.Point(575, 59);
			this.checkBox_DisableFunctionCode06.Name = "checkBox_DisableFunctionCode06";
			this.checkBox_DisableFunctionCode06.Size = new System.Drawing.Size(163, 21);
			this.checkBox_DisableFunctionCode06.TabIndex = 41;
			this.checkBox_DisableFunctionCode06.Text = "DisableFunctionCode06";
			this.checkBox_DisableFunctionCode06.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(596, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 17);
			this.label2.TabIndex = 40;
			this.label2.Text = "(如果不清楚，不用管，空着就行)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(121, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 17);
			this.label1.TabIndex = 39;
			this.label1.Text = "DataFormat：";
			// 
			// checkBox_station_check
			// 
			this.checkBox_station_check.AutoSize = true;
			this.checkBox_station_check.Checked = true;
			this.checkBox_station_check.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_station_check.Location = new System.Drawing.Point(445, 59);
			this.checkBox_station_check.Name = "checkBox_station_check";
			this.checkBox_station_check.Size = new System.Drawing.Size(106, 21);
			this.checkBox_station_check.TabIndex = 38;
			this.checkBox_station_check.Text = "Station Check";
			this.checkBox_station_check.UseVisualStyleBackColor = true;
			// 
			// textBox_batch_length
			// 
			this.textBox_batch_length.Location = new System.Drawing.Point(544, 33);
			this.textBox_batch_length.Name = "textBox_batch_length";
			this.textBox_batch_length.Size = new System.Drawing.Size(37, 23);
			this.textBox_batch_length.TabIndex = 37;
			// 
			// label_batch_length
			// 
			this.label_batch_length.AutoSize = true;
			this.label_batch_length.Location = new System.Drawing.Point(465, 36);
			this.label_batch_length.Name = "label_batch_length";
			this.label_batch_length.Size = new System.Drawing.Size(71, 17);
			this.label_batch_length.TabIndex = 36;
			this.label_batch_length.Text = "字分批长度:";
			// 
			// textBox_BroadcastStation
			// 
			this.textBox_BroadcastStation.Location = new System.Drawing.Point(404, 33);
			this.textBox_BroadcastStation.Name = "textBox_BroadcastStation";
			this.textBox_BroadcastStation.Size = new System.Drawing.Size(39, 23);
			this.textBox_BroadcastStation.TabIndex = 35;
			// 
			// label_BroadcastStation
			// 
			this.label_BroadcastStation.AutoSize = true;
			this.label_BroadcastStation.Location = new System.Drawing.Point(310, 36);
			this.label_BroadcastStation.Name = "label_BroadcastStation";
			this.label_BroadcastStation.Size = new System.Drawing.Size(59, 17);
			this.label_BroadcastStation.TabIndex = 34;
			this.label_BroadcastStation.Text = "广播站号:";
			// 
			// pipeSelectControl1
			// 
			this.pipeSelectControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSelectControl1.Location = new System.Drawing.Point(3, 2);
			this.pipeSelectControl1.Name = "pipeSelectControl1";
			this.pipeSelectControl1.SerialBaudRate = "9600";
			this.pipeSelectControl1.SerialDataBits = "8";
			this.pipeSelectControl1.SerialParity = System.IO.Ports.Parity.None;
			this.pipeSelectControl1.SerialStopBits = "1";
			this.pipeSelectControl1.SettingPipe = HslCommunicationDemo.DemoControl.SettingPipe.TcpPipe;
			this.pipeSelectControl1.Size = new System.Drawing.Size(790, 28);
			this.pipeSelectControl1.TabIndex = 33;
			this.pipeSelectControl1.TcpPortText = "502";
			this.pipeSelectControl1.UdpPortText = "502";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(8, 59);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(111, 21);
			this.checkBox2.TabIndex = 32;
			this.checkBox2.Text = "检查消息号一致";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(798, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "ABCD",
            "BADC",
            "CDAB",
            "DCBA"});
			this.comboBox1.Location = new System.Drawing.Point(217, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(85, 25);
			this.comboBox1.TabIndex = 26;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(295, 59);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(106, 21);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "首地址从0开始";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(61, 33);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(43, 23);
			this.textBox15.TabIndex = 7;
			this.textBox15.Text = "1";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(8, 36);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(44, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "站号：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(894, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(156, 59);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(87, 21);
			this.checkBox3.TabIndex = 25;
			this.checkBox3.Text = "字符串颠倒";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoScroll = true;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 120);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(990, 539);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(988, 537);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7885368.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Modbus Tcp";
			this.userControlHead1.Size = new System.Drawing.Size(997, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormModbus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(997, 662);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormModbus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modbus Tcp访问Demo";
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.CheckBox checkBox2;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
		private DemoControl.PipeSelectControl pipeSelectControl1;
        private System.Windows.Forms.TextBox textBox_BroadcastStation;
        private System.Windows.Forms.Label label_BroadcastStation;
		private System.Windows.Forms.TextBox textBox_batch_length;
		private System.Windows.Forms.Label label_batch_length;
		private System.Windows.Forms.CheckBox checkBox_station_check;
		private System.Windows.Forms.CheckBox checkBox_DisableFunctionCode06;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}