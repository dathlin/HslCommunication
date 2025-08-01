namespace HslCommunicationDemo.Instrument
{
    partial class FormIEC104Server
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1 = new System.Windows.Forms.Panel();
			this.sslServerControl1 = new HslCommunicationDemo.DemoControl.SslServerControl();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel5 = new System.Windows.Forms.Panel();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
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
			this.userControlHead1.ProtocolInfo = "IEC104 Server";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.sslServerControl1);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.button11);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 68);
			this.panel1.TabIndex = 4;
			// 
			// sslServerControl1
			// 
			this.sslServerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sslServerControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sslServerControl1.Location = new System.Drawing.Point(4, 32);
			this.sslServerControl1.Name = "sslServerControl1";
			this.sslServerControl1.Size = new System.Drawing.Size(991, 30);
			this.sslServerControl1.TabIndex = 41;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(909, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(83, 28);
			this.button3.TabIndex = 40;
			this.button3.Text = "左右布局";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(820, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(83, 28);
			this.button2.TabIndex = 39;
			this.button2.Text = "上下布局";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(208, 5);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(166, 23);
			this.textBox2.TabIndex = 38;
			this.textBox2.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(137, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 37;
			this.label2.Text = "公共单元：";
			// 
			// button11
			// 
			this.button11.Enabled = false;
			this.button11.Location = new System.Drawing.Point(482, 2);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(83, 28);
			this.button11.TabIndex = 36;
			this.button11.Text = "关闭服务";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(392, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 28);
			this.button1.TabIndex = 34;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(63, 5);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(65, 23);
			this.textBox3.TabIndex = 33;
			this.textBox3.Text = "2404";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 32;
			this.label3.Text = "端口号：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Location = new System.Drawing.Point(3, 107);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 535);
			this.panel2.TabIndex = 5;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel4);
			this.splitContainer1.Size = new System.Drawing.Size(995, 533);
			this.splitContainer1.SplitterDistance = 337;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(995, 337);
			this.panel3.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column4});
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(988, 297);
			this.dataGridView1.TabIndex = 3;
			// 
			// Column8
			// 
			this.Column8.HeaderText = "Pub-Add";
			this.Column8.Name = "Column8";
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Address";
			this.Column1.Name = "Column1";
			this.Column1.Width = 102;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Value";
			this.Column2.Name = "Column2";
			this.Column2.Width = 290;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "BL";
			this.Column3.Name = "Column3";
			this.Column3.ToolTipText = "封锁标志";
			this.Column3.Width = 50;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "SB";
			this.Column5.Name = "Column5";
			this.Column5.ToolTipText = "取代标志";
			this.Column5.Width = 50;
			// 
			// Column6
			// 
			this.Column6.HeaderText = "NT";
			this.Column6.Name = "Column6";
			this.Column6.ToolTipText = "刷新标志";
			this.Column6.Width = 50;
			// 
			// Column7
			// 
			this.Column7.HeaderText = "IV";
			this.Column7.Name = "Column7";
			this.Column7.ToolTipText = "有效标志";
			this.Column7.Width = 50;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Time";
			this.Column4.Name = "Column4";
			this.Column4.Width = 180;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.radioButton6);
			this.panel5.Controls.Add(this.radioButton5);
			this.panel5.Controls.Add(this.radioButton4);
			this.panel5.Controls.Add(this.radioButton3);
			this.panel5.Controls.Add(this.radioButton2);
			this.panel5.Controls.Add(this.radioButton1);
			this.panel5.Location = new System.Drawing.Point(3, 304);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(587, 30);
			this.panel5.TabIndex = 2;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(489, 4);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(88, 21);
			this.radioButton6.TabIndex = 5;
			this.radioButton6.Text = "32位比特串";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(384, 4);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(86, 21);
			this.radioButton5.TabIndex = 4;
			this.radioButton5.Text = "短浮点遥测";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(280, 4);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(86, 21);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "标度化遥测";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(179, 4);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(86, 21);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "归一化遥测";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(90, 4);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(74, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "双点遥信";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(4, 4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(74, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "单点遥信";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.textBox1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(995, 192);
			this.panel4.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "消息日志";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(3, 27);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(989, 161);
			this.textBox1.TabIndex = 0;
			// 
			// FormIEC104Server
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userControlHead1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormIEC104Server";
			this.Text = "FormIEC104Server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIEC104Server_FormClosing);
			this.Load += new System.EventHandler(this.FormIEC104Server_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private DemoControl.SslServerControl sslServerControl1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}