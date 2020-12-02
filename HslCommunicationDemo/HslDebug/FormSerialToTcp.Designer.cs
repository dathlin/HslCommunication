namespace HslCommunicationDemo
{
    partial class FormSerialToTcp
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.checkBox5);
			this.panel1.Controls.Add(this.comboBox2);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.textBox17);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.textBox16);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(15, 44);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(978, 74);
			this.panel1.TabIndex = 7;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(82, 43);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(118, 23);
			this.textBox1.TabIndex = 19;
			this.textBox1.Text = "502";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 18;
			this.label2.Text = "Tcp Port：";
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(578, 17);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(84, 21);
			this.checkBox5.TabIndex = 17;
			this.checkBox5.Text = "RtsEnable";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(62, 12);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(84, 25);
			this.comboBox2.TabIndex = 16;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "无",
            "奇",
            "偶"});
			this.comboBox1.Location = new System.Drawing.Point(503, 14);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(59, 25);
			this.comboBox1.TabIndex = 15;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(460, 17);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(44, 17);
			this.label24.TabIndex = 14;
			this.label24.Text = "奇偶：";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(430, 14);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(23, 23);
			this.textBox17.TabIndex = 13;
			this.textBox17.Text = "1";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(371, 17);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(56, 17);
			this.label23.TabIndex = 12;
			this.label23.Text = "停止位：";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(334, 14);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(24, 23);
			this.textBox16.TabIndex = 11;
			this.textBox16.Text = "8";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(272, 17);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 17);
			this.label22.TabIndex = 10;
			this.label22.Text = "数据位：";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(852, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 28);
			this.button2.TabIndex = 5;
			this.button2.Text = "关闭转换";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(740, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "打开转换";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(219, 14);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(47, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "9600";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(152, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "波特率：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Com口：";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.checkBox1);
			this.panel2.Controls.Add(this.textBox6);
			this.panel2.Controls.Add(this.checkBox4);
			this.panel2.Controls.Add(this.checkBox3);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Location = new System.Drawing.Point(15, 125);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(978, 513);
			this.panel2.TabIndex = 13;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(11, 30);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(955, 472);
			this.textBox6.TabIndex = 21;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Checked = true;
			this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox4.Location = new System.Drawing.Point(366, 3);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(99, 21);
			this.checkBox4.TabIndex = 20;
			this.checkBox4.Text = "是否显示时间";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new System.Drawing.Point(146, 3);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(123, 21);
			this.checkBox3.TabIndex = 19;
			this.checkBox3.Text = "是否显示发送数据";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 4);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "数据接收区：";
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
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 14;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(545, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(135, 21);
			this.checkBox1.TabIndex = 22;
			this.checkBox1.Text = "是否使用二进制通信";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// FormSerialToTcp
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
			this.Name = "FormSerialToTcp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "串口转TCP调试工具";
			this.Load += new System.EventHandler(this.FormSerialDebug_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}