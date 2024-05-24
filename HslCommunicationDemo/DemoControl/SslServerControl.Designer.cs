namespace HslCommunicationDemo.DemoControl
{
	partial class SslServerControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent( )
		{
			this.textBox_cert_password = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button_cert = new System.Windows.Forms.Button();
			this.textBox_cert = new System.Windows.Forms.TextBox();
			this.checkBox_ssl = new System.Windows.Forms.CheckBox();
			this.borderPanel1 = new HslCommunicationDemo.DemoControl.BorderPanel();
			this.borderPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox_cert_password
			// 
			this.textBox_cert_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_cert_password.Location = new System.Drawing.Point(914, 3);
			this.textBox_cert_password.Name = "textBox_cert_password";
			this.textBox_cert_password.PasswordChar = '*';
			this.textBox_cert_password.Size = new System.Drawing.Size(234, 23);
			this.textBox_cert_password.TabIndex = 46;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(832, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 45;
			this.label1.Text = "Password：";
			// 
			// button_cert
			// 
			this.button_cert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_cert.Location = new System.Drawing.Point(742, 1);
			this.button_cert.Name = "button_cert";
			this.button_cert.Size = new System.Drawing.Size(84, 27);
			this.button_cert.TabIndex = 44;
			this.button_cert.Text = "Cert File";
			this.button_cert.UseVisualStyleBackColor = true;
			this.button_cert.Click += new System.EventHandler(this.button_cert_Click);
			// 
			// textBox_cert
			// 
			this.textBox_cert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_cert.Location = new System.Drawing.Point(82, 3);
			this.textBox_cert.Name = "textBox_cert";
			this.textBox_cert.Size = new System.Drawing.Size(651, 23);
			this.textBox_cert.TabIndex = 43;
			// 
			// checkBox_ssl
			// 
			this.checkBox_ssl.AutoSize = true;
			this.checkBox_ssl.Location = new System.Drawing.Point(4, 4);
			this.checkBox_ssl.Name = "checkBox_ssl";
			this.checkBox_ssl.Size = new System.Drawing.Size(72, 21);
			this.checkBox_ssl.TabIndex = 42;
			this.checkBox_ssl.Text = "SSL/TLS";
			this.checkBox_ssl.UseVisualStyleBackColor = true;
			// 
			// borderPanel1
			// 
			this.borderPanel1.Controls.Add(this.checkBox_ssl);
			this.borderPanel1.Controls.Add(this.textBox_cert_password);
			this.borderPanel1.Controls.Add(this.textBox_cert);
			this.borderPanel1.Controls.Add(this.label1);
			this.borderPanel1.Controls.Add(this.button_cert);
			this.borderPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.borderPanel1.Location = new System.Drawing.Point(0, 0);
			this.borderPanel1.Name = "borderPanel1";
			this.borderPanel1.Size = new System.Drawing.Size(1151, 30);
			this.borderPanel1.TabIndex = 47;
			// 
			// SslServerControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.borderPanel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "SslServerControl";
			this.Size = new System.Drawing.Size(1151, 30);
			this.borderPanel1.ResumeLayout(false);
			this.borderPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_cert_password;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_cert;
		private System.Windows.Forms.TextBox textBox_cert;
		private System.Windows.Forms.CheckBox checkBox_ssl;
		private BorderPanel borderPanel1;
	}
}
