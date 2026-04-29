namespace HslCommunicationDemo.PLC.OrientalMotor
{
	partial class OrientalMotorControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_times = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_content = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_length = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Receive Times:";
			// 
			// textBox_times
			// 
			this.textBox_times.Location = new System.Drawing.Point(104, 5);
			this.textBox_times.Name = "textBox_times";
			this.textBox_times.Size = new System.Drawing.Size(108, 23);
			this.textBox_times.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Data:";
			// 
			// textBox_content
			// 
			this.textBox_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_content.Location = new System.Drawing.Point(49, 34);
			this.textBox_content.Multiline = true;
			this.textBox_content.Name = "textBox_content";
			this.textBox_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_content.Size = new System.Drawing.Size(707, 248);
			this.textBox_content.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(218, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Length:";
			// 
			// textBox_length
			// 
			this.textBox_length.Location = new System.Drawing.Point(288, 4);
			this.textBox_length.Name = "textBox_length";
			this.textBox_length.Size = new System.Drawing.Size(108, 23);
			this.textBox_length.TabIndex = 5;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(443, 5);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(102, 21);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "Stop Receive";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// OrientalMotorControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox_length);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_content);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_times);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "OrientalMotorControl";
			this.Size = new System.Drawing.Size(759, 285);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_times;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_content;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_length;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
