namespace HslCommunicationDemo.DemoControl
{
	partial class FormDtuMessageCreate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDtuMessageCreate));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_id = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_password = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_ip_address = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_ip_port = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "唯一ID标识：";
			// 
			// textBox_id
			// 
			this.textBox_id.Location = new System.Drawing.Point(114, 28);
			this.textBox_id.Name = "textBox_id";
			this.textBox_id.Size = new System.Drawing.Size(201, 23);
			this.textBox_id.TabIndex = 1;
			this.textBox_id.Text = "10000";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(321, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "(最多11个字符)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(448, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "密码：";
			// 
			// textBox_password
			// 
			this.textBox_password.Location = new System.Drawing.Point(504, 28);
			this.textBox_password.Name = "textBox_password";
			this.textBox_password.Size = new System.Drawing.Size(98, 23);
			this.textBox_password.TabIndex = 4;
			this.textBox_password.Text = "000000";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Gray;
			this.label4.Location = new System.Drawing.Point(608, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "(6个字符)";
			// 
			// textBox_ip_address
			// 
			this.textBox_ip_address.Location = new System.Drawing.Point(114, 68);
			this.textBox_ip_address.Name = "textBox_ip_address";
			this.textBox_ip_address.Size = new System.Drawing.Size(167, 23);
			this.textBox_ip_address.TabIndex = 7;
			this.textBox_ip_address.Text = "192.168.0.1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 17);
			this.label5.TabIndex = 6;
			this.label5.Text = "IP Address:";
			// 
			// textBox_ip_port
			// 
			this.textBox_ip_port.Location = new System.Drawing.Point(389, 68);
			this.textBox_ip_port.Name = "textBox_ip_port";
			this.textBox_ip_port.Size = new System.Drawing.Size(81, 23);
			this.textBox_ip_port.TabIndex = 9;
			this.textBox_ip_port.Text = "10000";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(302, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "IP Port:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(236, 108);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(176, 37);
			this.button1.TabIndex = 10;
			this.button1.Text = "计算注册包";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(12, 166);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(670, 89);
			this.textBox5.TabIndex = 11;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(501, 70);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(99, 21);
			this.checkBox1.TabIndex = 12;
			this.checkBox1.Text = "返回注册结果";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// FormDtuMessageCreate
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(694, 267);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_ip_port);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox_ip_address);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_id);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(710, 306);
			this.MinimumSize = new System.Drawing.Size(710, 306);
			this.Name = "FormDtuMessageCreate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DTU消息创建界面";
			this.Load += new System.EventHandler(this.FormDtuMessageCreate_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_id;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_password;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_ip_address;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_ip_port;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}