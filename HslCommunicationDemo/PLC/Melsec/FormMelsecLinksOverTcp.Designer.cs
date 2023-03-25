namespace HslCommunicationDemo
{
    partial class FormMelsecLinksOverTcp
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
			this.comboBox_format = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.comboBox_format);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBox18);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.textBox15);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label26);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label27);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 46);
			this.panel1.TabIndex = 0;
			// 
			// comboBox_format
			// 
			this.comboBox_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_format.FormattingEnabled = true;
			this.comboBox_format.Items.AddRange(new object[] {
            "1",
            "4"});
			this.comboBox_format.Location = new System.Drawing.Point(683, 9);
			this.comboBox_format.Name = "comboBox_format";
			this.comboBox_format.Size = new System.Drawing.Size(68, 25);
			this.comboBox_format.TabIndex = 42;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(627, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 41;
			this.label2.Text = "格式：";
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(497, 9);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(31, 23);
			this.textBox18.TabIndex = 30;
			this.textBox18.Text = "0";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(444, 12);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(44, 17);
			this.label22.TabIndex = 29;
			this.label22.Text = "超时：";
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(397, 9);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(31, 23);
			this.textBox15.TabIndex = 28;
			this.textBox15.Text = "0";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(348, 12);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(44, 17);
			this.label21.TabIndex = 27;
			this.label21.Text = "站号：";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(558, 11);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(63, 21);
			this.checkBox1.TabIndex = 26;
			this.checkBox1.Text = "和校验";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(245, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(77, 23);
			this.textBox2.TabIndex = 19;
			this.textBox2.Text = "2000";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(191, 12);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(44, 17);
			this.label26.TabIndex = 18;
			this.label26.Text = "端口：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(67, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(109, 23);
			this.textBox1.TabIndex = 17;
			this.textBox1.Text = "192.168.0.100";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(8, 12);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(56, 17);
			this.label27.TabIndex = 16;
			this.label27.Text = "Ip地址：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(874, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(777, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "连接";
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
			this.panel2.Location = new System.Drawing.Point(3, 84);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 558);
			this.panel2.TabIndex = 1;
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
			this.userControlHead1.ProtocolInfo = "fx 计算机链协议 Over Tcp";
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
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 556);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// FormMelsecLinksOverTcp
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
			this.Name = "FormMelsecLinksOverTcp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "三菱PLC访问Demo";
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.ComboBox comboBox_format;
		private System.Windows.Forms.Label label2;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}