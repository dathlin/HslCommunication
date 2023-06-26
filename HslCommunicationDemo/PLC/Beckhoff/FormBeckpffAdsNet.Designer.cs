namespace HslCommunicationDemo
{
    partial class FormBeckhoffAdsNet
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
			this.textBox_ams_port = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox_auto = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox_tag = new System.Windows.Forms.CheckBox();
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
			this.panel1.Controls.Add(this.textBox_ams_port);
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.textBox15);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.textBox14);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkBox_auto);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.checkBox_tag);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1011, 79);
			this.panel1.TabIndex = 0;
			// 
			// textBox_ams_port
			// 
			this.textBox_ams_port.Location = new System.Drawing.Point(379, 52);
			this.textBox_ams_port.Name = "textBox_ams_port";
			this.textBox_ams_port.Size = new System.Drawing.Size(72, 23);
			this.textBox_ams_port.TabIndex = 19;
			this.textBox_ams_port.Text = "851";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label17.Location = new System.Drawing.Point(456, 54);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(402, 17);
			this.label17.TabIndex = 16;
			this.label17.Text = "TwinCAT2，端口号801,811,821,831；TwinCAT3，端口号为851,852,853";
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(273, 27);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(179, 23);
			this.textBox15.TabIndex = 14;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(179, 30);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(98, 17);
			this.label15.TabIndex = 13;
			this.label15.Text = "Sender NetId：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(473, 4);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(167, 17);
			this.label8.TabIndex = 12;
			this.label8.Text = "示例：192.168.1.100.1.1:801";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(273, 2);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(179, 23);
			this.textBox14.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(179, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 17);
			this.label5.TabIndex = 10;
			this.label5.Text = "Target NetId：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(641, 23);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(82, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "断开连接";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(561, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(62, 27);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(114, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "48898";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(114, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip地址：";
			// 
			// checkBox_auto
			// 
			this.checkBox_auto.AutoSize = true;
			this.checkBox_auto.Location = new System.Drawing.Point(178, 54);
			this.checkBox_auto.Name = "checkBox_auto";
			this.checkBox_auto.Size = new System.Drawing.Size(115, 21);
			this.checkBox_auto.TabIndex = 17;
			this.checkBox_auto.Text = "自动AMS NetId";
			this.checkBox_auto.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Green;
			this.label6.Location = new System.Drawing.Point(310, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 17);
			this.label6.TabIndex = 20;
			this.label6.Text = "Ams Port:";
			// 
			// checkBox_tag
			// 
			this.checkBox_tag.AutoSize = true;
			this.checkBox_tag.Checked = true;
			this.checkBox_tag.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_tag.Location = new System.Drawing.Point(473, 28);
			this.checkBox_tag.Name = "checkBox_tag";
			this.checkBox_tag.Size = new System.Drawing.Size(75, 21);
			this.checkBox_tag.TabIndex = 15;
			this.checkBox_tag.Text = "标签缓存";
			this.checkBox_tag.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 118);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1011, 538);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(1009, 536);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12051529.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "ADS";
			this.userControlHead1.Size = new System.Drawing.Size(1018, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormBeckhoffAdsNet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1018, 658);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormBeckhoffAdsNet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "倍福PLC访问Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBox_tag;
        private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox_ams_port;
		private System.Windows.Forms.CheckBox checkBox_auto;
		private System.Windows.Forms.Label label6;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}