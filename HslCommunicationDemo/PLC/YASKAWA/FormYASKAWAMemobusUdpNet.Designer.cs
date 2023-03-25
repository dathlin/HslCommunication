namespace HslCommunicationDemo
{
    partial class FormYASKAWAMemobusUdpNet
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
			this.textBox_cpu_to = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_cpu_from = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.userControlReadWriteDevice1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteDevice();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox_cpu_to);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox_cpu_from);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox19);
			this.panel1.Controls.Add(this.label28);
			this.panel1.Controls.Add(this.textBox20);
			this.panel1.Controls.Add(this.label29);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 50);
			this.panel1.TabIndex = 0;
			// 
			// textBox_cpu_to
			// 
			this.textBox_cpu_to.Location = new System.Drawing.Point(636, 11);
			this.textBox_cpu_to.Name = "textBox_cpu_to";
			this.textBox_cpu_to.Size = new System.Drawing.Size(31, 23);
			this.textBox_cpu_to.TabIndex = 42;
			this.textBox_cpu_to.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(561, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 17);
			this.label2.TabIndex = 41;
			this.label2.Text = "Cpu To：";
			// 
			// textBox_cpu_from
			// 
			this.textBox_cpu_from.Location = new System.Drawing.Point(510, 11);
			this.textBox_cpu_from.Name = "textBox_cpu_from";
			this.textBox_cpu_from.Size = new System.Drawing.Size(31, 23);
			this.textBox_cpu_from.TabIndex = 40;
			this.textBox_cpu_from.Text = "1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(431, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 17);
			this.label1.TabIndex = 39;
			this.label1.Text = "Cpu From：";
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(233, 10);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(53, 23);
			this.textBox19.TabIndex = 32;
			this.textBox19.Text = "9999";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(185, 13);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(44, 17);
			this.label28.TabIndex = 31;
			this.label28.Text = "端口：";
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(64, 10);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(109, 23);
			this.textBox20.TabIndex = 30;
			this.textBox20.Text = "192.168.0.10";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(10, 13);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(56, 17);
			this.label29.TabIndex = 29;
			this.label29.Text = "Ip地址：";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(307, 10);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(95, 25);
			this.comboBox1.TabIndex = 14;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(808, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(90, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(701, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "实例化";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 89);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 553);
			this.panel2.TabIndex = 1;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Memobus Udp";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.SupportListVisiable = true;
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// userControlReadWriteDevice1
			// 
			this.userControlReadWriteDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userControlReadWriteDevice1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteDevice1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteDevice1.Name = "userControlReadWriteDevice1";
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 551);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// FormYASKAWAMemobusUdpNet
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
			this.Name = "FormYASKAWAMemobusUdpNet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "安川PLC访问Demo";
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_cpu_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label29;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_cpu_to;
		private System.Windows.Forms.Label label2;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}