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
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.serverSettingControl1 = new HslCommunicationDemo.DemoControl.ServerSettingControl();
			this.sslServerControl1 = new HslCommunicationDemo.DemoControl.SslServerControl();
			this.checkBox_maskcode = new System.Windows.Forms.CheckBox();
			this.checkBox_forceReceiveOnce = new System.Windows.Forms.CheckBox();
			this.textBox_station = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox_station_isolation = new System.Windows.Forms.CheckBox();
			this.textBox_time_min = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox_RtuOverTcp = new System.Windows.Forms.CheckBox();
			this.checkBox_remote_write = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
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
			this.panel1.Controls.Add(this.comboBox2);
			this.panel1.Controls.Add(this.serverSettingControl1);
			this.panel1.Controls.Add(this.sslServerControl1);
			this.panel1.Controls.Add(this.checkBox_maskcode);
			this.panel1.Controls.Add(this.checkBox_forceReceiveOnce);
			this.panel1.Controls.Add(this.textBox_station);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkBox_station_isolation);
			this.panel1.Controls.Add(this.textBox_time_min);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.checkBox_RtuOverTcp);
			this.panel1.Controls.Add(this.checkBox_remote_write);
			this.panel1.Controls.Add(this.checkBox3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 90);
			this.panel1.TabIndex = 0;
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
			this.comboBox2.Location = new System.Drawing.Point(3, 58);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(84, 25);
			this.comboBox2.TabIndex = 29;
			// 
			// serverSettingControl1
			// 
			this.serverSettingControl1.buttonCloseAction = null;
			this.serverSettingControl1.buttonSerialAction = null;
			this.serverSettingControl1.buttonStartAction = null;
			this.serverSettingControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.serverSettingControl1.Location = new System.Drawing.Point(1, 3);
			this.serverSettingControl1.Name = "serverSettingControl1";
			this.serverSettingControl1.Size = new System.Drawing.Size(904, 30);
			this.serverSettingControl1.TabIndex = 45;
			this.serverSettingControl1.TextSerialInfo = "COM4-9600-8-N-1";
			// 
			// sslServerControl1
			// 
			this.sslServerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sslServerControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sslServerControl1.Location = new System.Drawing.Point(93, 57);
			this.sslServerControl1.Name = "sslServerControl1";
			this.sslServerControl1.Size = new System.Drawing.Size(899, 30);
			this.sslServerControl1.TabIndex = 44;
			// 
			// checkBox_maskcode
			// 
			this.checkBox_maskcode.AutoSize = true;
			this.checkBox_maskcode.Checked = true;
			this.checkBox_maskcode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_maskcode.Location = new System.Drawing.Point(786, 35);
			this.checkBox_maskcode.Name = "checkBox_maskcode";
			this.checkBox_maskcode.Size = new System.Drawing.Size(96, 21);
			this.checkBox_maskcode.TabIndex = 43;
			this.checkBox_maskcode.Text = "MaskCode?";
			this.checkBox_maskcode.UseVisualStyleBackColor = true;
			// 
			// checkBox_forceReceiveOnce
			// 
			this.checkBox_forceReceiveOnce.AutoSize = true;
			this.checkBox_forceReceiveOnce.Location = new System.Drawing.Point(668, 34);
			this.checkBox_forceReceiveOnce.Name = "checkBox_forceReceiveOnce";
			this.checkBox_forceReceiveOnce.Size = new System.Drawing.Size(107, 21);
			this.checkBox_forceReceiveOnce.TabIndex = 41;
			this.checkBox_forceReceiveOnce.Text = "ReceiveOnce?";
			this.checkBox_forceReceiveOnce.UseVisualStyleBackColor = true;
			// 
			// textBox_station
			// 
			this.textBox_station.Location = new System.Drawing.Point(454, 33);
			this.textBox_station.Name = "textBox_station";
			this.textBox_station.Size = new System.Drawing.Size(41, 23);
			this.textBox_station.TabIndex = 40;
			this.textBox_station.Text = "1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(394, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 39;
			this.label1.Text = "Station：";
			// 
			// checkBox_station_isolation
			// 
			this.checkBox_station_isolation.AutoSize = true;
			this.checkBox_station_isolation.Location = new System.Drawing.Point(262, 35);
			this.checkBox_station_isolation.Name = "checkBox_station_isolation";
			this.checkBox_station_isolation.Size = new System.Drawing.Size(127, 21);
			this.checkBox_station_isolation.TabIndex = 38;
			this.checkBox_station_isolation.Text = "Station Isolation?";
			this.checkBox_station_isolation.UseVisualStyleBackColor = true;
			// 
			// textBox_time_min
			// 
			this.textBox_time_min.Location = new System.Drawing.Point(607, 32);
			this.textBox_time_min.Name = "textBox_time_min";
			this.textBox_time_min.Size = new System.Drawing.Size(39, 23);
			this.textBox_time_min.TabIndex = 37;
			this.textBox_time_min.Text = "20";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(505, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 17);
			this.label2.TabIndex = 36;
			this.label2.Text = "最短接收时间：";
			// 
			// checkBox_RtuOverTcp
			// 
			this.checkBox_RtuOverTcp.AutoSize = true;
			this.checkBox_RtuOverTcp.Location = new System.Drawing.Point(6, 34);
			this.checkBox_RtuOverTcp.Name = "checkBox_RtuOverTcp";
			this.checkBox_RtuOverTcp.Size = new System.Drawing.Size(99, 21);
			this.checkBox_RtuOverTcp.TabIndex = 32;
			this.checkBox_RtuOverTcp.Text = "使用RTU报文";
			this.checkBox_RtuOverTcp.UseVisualStyleBackColor = true;
			// 
			// checkBox_remote_write
			// 
			this.checkBox_remote_write.AutoSize = true;
			this.checkBox_remote_write.Checked = true;
			this.checkBox_remote_write.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_remote_write.Location = new System.Drawing.Point(122, 35);
			this.checkBox_remote_write.Name = "checkBox_remote_write";
			this.checkBox_remote_write.Size = new System.Drawing.Size(123, 21);
			this.checkBox_remote_write.TabIndex = 31;
			this.checkBox_remote_write.Text = "是否允许远程写入";
			this.checkBox_remote_write.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(899, 34);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(87, 21);
			this.checkBox3.TabIndex = 27;
			this.checkBox3.Text = "字符串颠倒";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteServer1);
			this.panel2.Location = new System.Drawing.Point(3, 128);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 513);
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
			this.userControlReadWriteServer1.Size = new System.Drawing.Size(989, 508);
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
			this.Text = "Modbus虚拟服务器";
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
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private DemoControl.UserControlHead userControlHead1;
		private DemoControl.UserControlReadWriteServer userControlReadWriteServer1;
		private System.Windows.Forms.CheckBox checkBox_remote_write;
		private System.Windows.Forms.CheckBox checkBox_RtuOverTcp;
		private System.Windows.Forms.TextBox textBox_time_min;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_station_isolation;
		private System.Windows.Forms.TextBox textBox_station;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox_forceReceiveOnce;
		private System.Windows.Forms.CheckBox checkBox_maskcode;
		private DemoControl.SslServerControl sslServerControl1;
		private DemoControl.ServerSettingControl serverSettingControl1;
	}
}