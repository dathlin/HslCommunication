namespace HslCommunicationDemo.PLC.Common
{
	partial class ConnectControl
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
			this.textBox_lora_head = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_connect_timeout = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_connect_type = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// textBox_lora_head
			// 
			this.textBox_lora_head.Location = new System.Drawing.Point(634, 3);
			this.textBox_lora_head.Name = "textBox_lora_head";
			this.textBox_lora_head.Size = new System.Drawing.Size(109, 23);
			this.textBox_lora_head.TabIndex = 38;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(563, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 17);
			this.label4.TabIndex = 37;
			this.label4.Text = "LoraHead：";
			// 
			// textBox_connect_timeout
			// 
			this.textBox_connect_timeout.Location = new System.Drawing.Point(500, 3);
			this.textBox_connect_timeout.Name = "textBox_connect_timeout";
			this.textBox_connect_timeout.Size = new System.Drawing.Size(52, 23);
			this.textBox_connect_timeout.TabIndex = 36;
			this.textBox_connect_timeout.Text = "5000";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(429, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 35;
			this.label2.Text = "连接超时：";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(361, 3);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(58, 23);
			this.textBox2.TabIndex = 34;
			this.textBox2.Text = "502";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(307, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 33;
			this.label3.Text = "端口号：";
			// 
			// textBox_ip
			// 
			this.textBox_ip.Location = new System.Drawing.Point(126, 3);
			this.textBox_ip.Name = "textBox_ip";
			this.textBox_ip.Size = new System.Drawing.Size(175, 23);
			this.textBox_ip.TabIndex = 32;
			this.textBox_ip.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(72, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 31;
			this.label1.Text = "Ip地址：";
			// 
			// comboBox_connect_type
			// 
			this.comboBox_connect_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_connect_type.FormattingEnabled = true;
			this.comboBox_connect_type.Location = new System.Drawing.Point(1, 2);
			this.comboBox_connect_type.Name = "comboBox_connect_type";
			this.comboBox_connect_type.Size = new System.Drawing.Size(65, 25);
			this.comboBox_connect_type.TabIndex = 39;
			// 
			// ConnectControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.comboBox_connect_type);
			this.Controls.Add(this.textBox_lora_head);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_connect_timeout);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_ip);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "ConnectControl";
			this.Size = new System.Drawing.Size(859, 29);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_lora_head;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_connect_timeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_connect_type;
	}
}
