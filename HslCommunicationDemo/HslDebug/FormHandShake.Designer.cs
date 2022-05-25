namespace HslCommunicationDemo.HslDebug
{
	partial class FormHandShake
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_hex = new System.Windows.Forms.RadioButton();
			this.radioButton_binary = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button_clear = new System.Windows.Forms.Button();
			this.button_ok = new System.Windows.Forms.Button();
			this.button_cancel = new System.Windows.Forms.Button();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "握手报文1";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 36);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(609, 23);
			this.textBox1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this.radioButton_hex);
			this.panel3.Controls.Add(this.radioButton_binary);
			this.panel3.Location = new System.Drawing.Point(96, 4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(155, 28);
			this.panel3.TabIndex = 32;
			// 
			// radioButton_hex
			// 
			this.radioButton_hex.AutoSize = true;
			this.radioButton_hex.Location = new System.Drawing.Point(86, 3);
			this.radioButton_hex.Name = "radioButton_hex";
			this.radioButton_hex.Size = new System.Drawing.Size(57, 21);
			this.radioButton_hex.TabIndex = 1;
			this.radioButton_hex.Text = "ASCII";
			this.radioButton_hex.UseVisualStyleBackColor = true;
			// 
			// radioButton_binary
			// 
			this.radioButton_binary.AutoSize = true;
			this.radioButton_binary.Checked = true;
			this.radioButton_binary.Location = new System.Drawing.Point(7, 3);
			this.radioButton_binary.Name = "radioButton_binary";
			this.radioButton_binary.Size = new System.Drawing.Size(62, 21);
			this.radioButton_binary.TabIndex = 0;
			this.radioButton_binary.TabStop = true;
			this.radioButton_binary.Text = "Binary";
			this.radioButton_binary.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 31;
			this.label6.Text = "数据格式：";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 69);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(609, 23);
			this.textBox2.TabIndex = 34;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 17);
			this.label2.TabIndex = 33;
			this.label2.Text = "握手报文2";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(96, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(609, 23);
			this.textBox3.TabIndex = 36;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 107);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 17);
			this.label3.TabIndex = 35;
			this.label3.Text = "握手报文3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 17);
			this.label4.TabIndex = 37;
			this.label4.Text = "常见握手:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(93, 135);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 27);
			this.button1.TabIndex = 38;
			this.button1.Text = "SiemensS7";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(185, 135);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 27);
			this.button2.TabIndex = 39;
			this.button2.Text = "FinsTcp";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(277, 135);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(86, 27);
			this.button3.TabIndex = 40;
			this.button3.Text = "cip";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button_clear
			// 
			this.button_clear.Location = new System.Drawing.Point(619, 4);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(86, 27);
			this.button_clear.TabIndex = 41;
			this.button_clear.Text = "Clear";
			this.button_clear.UseVisualStyleBackColor = true;
			this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
			// 
			// button_ok
			// 
			this.button_ok.Location = new System.Drawing.Point(277, 273);
			this.button_ok.Name = "button_ok";
			this.button_ok.Size = new System.Drawing.Size(138, 41);
			this.button_ok.TabIndex = 42;
			this.button_ok.Text = "OK";
			this.button_ok.UseVisualStyleBackColor = true;
			this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
			// 
			// button_cancel
			// 
			this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_cancel.Location = new System.Drawing.Point(-421, 285);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(138, 41);
			this.button_cancel.TabIndex = 43;
			this.button_cancel.Text = "CANCEL";
			this.button_cancel.UseVisualStyleBackColor = true;
			// 
			// FormHandShake
			// 
			this.AcceptButton = this.button_ok;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.button_cancel;
			this.ClientSize = new System.Drawing.Size(717, 338);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.button_ok);
			this.Controls.Add(this.button_clear);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormHandShake";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HandShake";
			this.Load += new System.EventHandler(this.FormHandShake_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton_hex;
		private System.Windows.Forms.RadioButton radioButton_binary;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button_clear;
		private System.Windows.Forms.Button button_ok;
		private System.Windows.Forms.Button button_cancel;
	}
}