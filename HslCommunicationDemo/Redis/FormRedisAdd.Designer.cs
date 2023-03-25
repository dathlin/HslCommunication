namespace HslRedisDesktop
{
	partial class FormRedisAdd
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ip Address:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(122, 51);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(246, 23);
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(122, 86);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(246, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "6379";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(122, 121);
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = '*';
			this.textBox3.Size = new System.Drawing.Size(182, 23);
			this.textBox3.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(69, 161);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 30);
			this.button1.TabIndex = 6;
			this.button1.Text = "Connection Test";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(206, 161);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(118, 30);
			this.button2.TabIndex = 7;
			this.button2.Text = "Finish";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(122, 15);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(246, 23);
			this.textBox4.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Name:";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(310, 123);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(58, 21);
			this.checkBox1.TabIndex = 10;
			this.checkBox1.Text = "Show";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// FormRedisAdd
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(398, 211);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(414, 250);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(414, 250);
			this.Name = "FormRedisAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or edit a redis client";
			this.Load += new System.EventHandler(this.FormRedisAdd_Load);
			this.Shown += new System.EventHandler(this.FormRedisAdd_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}