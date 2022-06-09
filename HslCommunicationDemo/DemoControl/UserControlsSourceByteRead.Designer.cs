namespace HslCommunicationDemo.DemoControl
{
	partial class UserControlsSourceByteRead
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
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button_read = new System.Windows.Forms.Button();
			this.textBox_length = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_address = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(57, 39);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(606, 137);
			this.textBox10.TabIndex = 17;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 41);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 17);
			this.label13.TabIndex = 16;
			this.label13.Text = "结果：";
			// 
			// button_read
			// 
			this.button_read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_read.Location = new System.Drawing.Point(563, 3);
			this.button_read.Name = "button_read";
			this.button_read.Size = new System.Drawing.Size(103, 28);
			this.button_read.TabIndex = 15;
			this.button_read.Text = "批量读取";
			this.button_read.UseVisualStyleBackColor = true;
			// 
			// textBox_length
			// 
			this.textBox_length.Location = new System.Drawing.Point(343, 6);
			this.textBox_length.Name = "textBox_length";
			this.textBox_length.Size = new System.Drawing.Size(123, 23);
			this.textBox_length.TabIndex = 14;
			this.textBox_length.Text = "10";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(289, 9);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 17);
			this.label12.TabIndex = 13;
			this.label12.Text = "长度：";
			// 
			// textBox_address
			// 
			this.textBox_address.Location = new System.Drawing.Point(57, 6);
			this.textBox_address.Name = "textBox_address";
			this.textBox_address.Size = new System.Drawing.Size(226, 23);
			this.textBox_address.TabIndex = 12;
			this.textBox_address.Text = "100";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 17);
			this.label11.TabIndex = 11;
			this.label11.Text = "地址：";
			// 
			// UserControlsSourceByteRead
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.button_read);
			this.Controls.Add(this.textBox_length);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBox_address);
			this.Controls.Add(this.label11);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "UserControlsSourceByteRead";
			this.Size = new System.Drawing.Size(669, 182);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button_read;
		private System.Windows.Forms.TextBox textBox_length;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox_address;
		private System.Windows.Forms.Label label11;
	}
}
