namespace HslCommunicationDemo
{
    partial class FormOmronUdp
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
			this.checkBox_isstringreverse = new System.Windows.Forms.CheckBox();
			this.textBox_sid = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_gct = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox_sa1 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.checkBox_isstringreverse);
			this.panel1.Controls.Add(this.textBox_sid);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox_gct);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.textBox_sa1);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.label21);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 64);
			this.panel1.TabIndex = 0;
			// 
			// checkBox_isstringreverse
			// 
			this.checkBox_isstringreverse.AutoSize = true;
			this.checkBox_isstringreverse.Checked = true;
			this.checkBox_isstringreverse.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_isstringreverse.Location = new System.Drawing.Point(396, 39);
			this.checkBox_isstringreverse.Name = "checkBox_isstringreverse";
			this.checkBox_isstringreverse.Size = new System.Drawing.Size(127, 21);
			this.checkBox_isstringreverse.TabIndex = 19;
			this.checkBox_isstringreverse.Text = "Is string reverse?";
			this.checkBox_isstringreverse.UseVisualStyleBackColor = true;
			// 
			// textBox_sid
			// 
			this.textBox_sid.Location = new System.Drawing.Point(567, 10);
			this.textBox_sid.Name = "textBox_sid";
			this.textBox_sid.Size = new System.Drawing.Size(34, 23);
			this.textBox_sid.TabIndex = 18;
			this.textBox_sid.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(522, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 17);
			this.label5.TabIndex = 17;
			this.label5.Text = "SID:";
			// 
			// textBox_gct
			// 
			this.textBox_gct.Location = new System.Drawing.Point(482, 10);
			this.textBox_gct.Name = "textBox_gct";
			this.textBox_gct.Size = new System.Drawing.Size(34, 23);
			this.textBox_gct.TabIndex = 16;
			this.textBox_gct.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(441, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 17);
			this.label2.TabIndex = 15;
			this.label2.Text = "GCT:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(616, 10);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(82, 25);
			this.comboBox1.TabIndex = 14;
			// 
			// textBox_sa1
			// 
			this.textBox_sa1.Location = new System.Drawing.Point(396, 10);
			this.textBox_sa1.Name = "textBox_sa1";
			this.textBox_sa1.Size = new System.Drawing.Size(40, 23);
			this.textBox_sa1.TabIndex = 9;
			this.textBox_sa1.Text = "192";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(285, 13);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(110, 17);
			this.label23.TabIndex = 8;
			this.label23.Text = "本机网络号(SA1)：";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(866, 3);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(122, 45);
			this.label22.TabIndex = 7;
			this.label22.Text = "D100 C100 W100 H100 A100";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(792, 1);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(68, 17);
			this.label21.TabIndex = 6;
			this.label21.Text = "地址示例：";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(709, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(82, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "创建对象";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(230, 10);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(48, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "9600";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(176, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "端口号：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(58, 10);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(114, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "192.168.0.100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 13);
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
			this.panel2.Controls.Add(this.userControlReadWriteDevice1);
			this.panel2.Location = new System.Drawing.Point(3, 102);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 541);
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
			this.userControlHead1.ProtocolInfo = "Fins Udp";
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
			this.userControlReadWriteDevice1.Size = new System.Drawing.Size(995, 539);
			this.userControlReadWriteDevice1.TabIndex = 0;
			// 
			// FormOmronUdp
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
			this.Name = "FormOmronUdp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "欧姆龙PLC访问Demo";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox_sa1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBox1;
        private DemoControl.UserControlHead userControlHead1;
		private System.Windows.Forms.TextBox textBox_sid;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_gct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox_isstringreverse;
		private DemoControl.UserControlReadWriteDevice userControlReadWriteDevice1;
	}
}