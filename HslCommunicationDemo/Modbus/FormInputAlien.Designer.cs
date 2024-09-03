namespace HslCommunicationDemo
{
    partial class FormInputAlien
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputAlien));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox_ack_result = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip 地址：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(211, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "端口号：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "唯一ID：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(87, 44);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(120, 23);
			this.textBox_ip.TabIndex = 3;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(269, 44);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(72, 23);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "10000";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(87, 77);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(254, 23);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "12345678901";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(127, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 28);
			this.button1.TabIndex = 6;
			this.button1.Text = "确认";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(87, 106);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(254, 23);
			this.textBox4.TabIndex = 8;
			this.textBox4.Text = "123456";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "密码：";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButton2);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Location = new System.Drawing.Point(7, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 37);
			this.panel1.TabIndex = 9;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(177, 8);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(134, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "自定义报文的注册包";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(12, 8);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(144, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "使用HSL格式的注册包";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Location = new System.Drawing.Point(7, 75);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(339, 103);
			this.panel2.TabIndex = 10;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(254, 96);
			this.textBox1.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "注册包：";
			// 
			// checkBox_ack_result
			// 
			this.checkBox_ack_result.AutoSize = true;
			this.checkBox_ack_result.Location = new System.Drawing.Point(19, 138);
			this.checkBox_ack_result.Name = "checkBox_ack_result";
			this.checkBox_ack_result.Size = new System.Drawing.Size(99, 21);
			this.checkBox_ack_result.TabIndex = 11;
			this.checkBox_ack_result.Text = "要求返回结果";
			this.checkBox_ack_result.UseVisualStyleBackColor = true;
			// 
			// FormInputAlien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(361, 222);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox_ip);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox_ack_result);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormInputAlien";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormInputAlien";
			this.Load += new System.EventHandler(this.FormInputAlien_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox_ack_result;
	}
}