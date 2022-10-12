namespace HslCommunicationDemo
{
    partial class FormS7Server
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
			this.label11 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.textBox_db = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button_db_add = new System.Windows.Forms.Button();
			this.button_db_remove = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button_db_remove);
			this.panel1.Controls.Add(this.button_db_add);
			this.panel1.Controls.Add(this.textBox_db);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.button11);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 45);
			this.panel1.TabIndex = 0;
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label11.Location = new System.Drawing.Point(325, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(340, 41);
			this.label11.TabIndex = 29;
			this.label11.Text = "本服务器不是严格的s7协议，仅支持和HSL组件完美通信。";
			// 
			// button11
			// 
			this.button11.Enabled = false;
			this.button11.Location = new System.Drawing.Point(235, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(83, 28);
			this.button11.TabIndex = 28;
			this.button11.Text = "关闭服务";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(145, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 28);
			this.button1.TabIndex = 4;
			this.button1.Text = "启动服务";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(74, 11);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(65, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "102";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 14);
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
			this.panel2.Location = new System.Drawing.Point(3, 84);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 559);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteServer1
			// 
			this.userControlReadWriteServer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteServer1.Location = new System.Drawing.Point(2, 2);
			this.userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			this.userControlReadWriteServer1.Size = new System.Drawing.Size(990, 552);
			this.userControlReadWriteServer1.TabIndex = 0;
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/10425797.html";
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "s7";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			// 
			// textBox_db
			// 
			this.textBox_db.Location = new System.Drawing.Point(762, 3);
			this.textBox_db.Name = "textBox_db";
			this.textBox_db.Size = new System.Drawing.Size(65, 23);
			this.textBox_db.TabIndex = 31;
			this.textBox_db.Text = "10";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(683, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 17);
			this.label1.TabIndex = 30;
			this.label1.Text = "DB block：";
			// 
			// button_db_add
			// 
			this.button_db_add.Location = new System.Drawing.Point(833, 0);
			this.button_db_add.Name = "button_db_add";
			this.button_db_add.Size = new System.Drawing.Size(61, 28);
			this.button_db_add.TabIndex = 32;
			this.button_db_add.Text = "Add";
			this.button_db_add.UseVisualStyleBackColor = true;
			this.button_db_add.Click += new System.EventHandler(this.button_db_add_Click);
			// 
			// button_db_remove
			// 
			this.button_db_remove.Location = new System.Drawing.Point(900, 0);
			this.button_db_remove.Name = "button_db_remove";
			this.button_db_remove.Size = new System.Drawing.Size(70, 28);
			this.button_db_remove.TabIndex = 33;
			this.button_db_remove.Text = "Remove";
			this.button_db_remove.UseVisualStyleBackColor = true;
			this.button_db_remove.Click += new System.EventHandler(this.button_db_remove_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(683, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(273, 17);
			this.label2.TabIndex = 34;
			this.label2.Text = "用来添加新的独立的DB块支持，无法移除DB1,2,3";
			// 
			// FormS7Server
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
			this.Name = "FormS7Server";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "s7虚拟服务器【数据支持I，Q，M，DB块读写，DB块只有一个，无论是DB1.1还是DB100.1都是指同一个】";
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
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label11;
        private DemoControl.UserControlHead userControlHead1;
        private DemoControl.UserControlReadWriteServer userControlReadWriteServer1;
		private System.Windows.Forms.Button button_db_remove;
		private System.Windows.Forms.Button button_db_add;
		private System.Windows.Forms.TextBox textBox_db;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}