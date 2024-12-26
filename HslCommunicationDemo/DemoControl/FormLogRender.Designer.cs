namespace HslCommunicationDemo.DemoControl
{
	partial class FormLogRender
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox_stop_render = new System.Windows.Forms.CheckBox();
            this.button_regex_filter = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox_output_file = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(906, 216);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "日志等级:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 25);
            this.comboBox1.TabIndex = 2;
            // 
            // checkBox_stop_render
            // 
            this.checkBox_stop_render.AutoSize = true;
            this.checkBox_stop_render.Location = new System.Drawing.Point(187, 6);
            this.checkBox_stop_render.Name = "checkBox_stop_render";
            this.checkBox_stop_render.Size = new System.Drawing.Size(123, 21);
            this.checkBox_stop_render.TabIndex = 3;
            this.checkBox_stop_render.Text = "暂停显示日志输出";
            this.checkBox_stop_render.UseVisualStyleBackColor = true;
            // 
            // button_regex_filter
            // 
            this.button_regex_filter.Location = new System.Drawing.Point(502, 2);
            this.button_regex_filter.Name = "button_regex_filter";
            this.button_regex_filter.Size = new System.Drawing.Size(97, 27);
            this.button_regex_filter.TabIndex = 5;
            this.button_regex_filter.Text = "正则过滤";
            this.button_regex_filter.UseVisualStyleBackColor = true;
            this.button_regex_filter.Click += new System.EventHandler(this.button_regex_filter_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(342, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 23);
            this.textBox2.TabIndex = 6;
            // 
            // checkBox_output_file
            // 
            this.checkBox_output_file.AutoSize = true;
            this.checkBox_output_file.Location = new System.Drawing.Point(609, 6);
            this.checkBox_output_file.Name = "checkBox_output_file";
            this.checkBox_output_file.Size = new System.Drawing.Size(131, 21);
            this.checkBox_output_file.TabIndex = 7;
            this.checkBox_output_file.Text = "输出到文件(log.txt)";
            this.checkBox_output_file.UseVisualStyleBackColor = true;
            // 
            // FormLogRender
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(909, 247);
            this.Controls.Add(this.checkBox_output_file);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_regex_filter);
            this.Controls.Add(this.checkBox_stop_render);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormLogRender";
            this.Text = "日志显示";
            this.Load += new System.EventHandler(this.FormLogRender_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox_stop_render;
        private System.Windows.Forms.Button button_regex_filter;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox_output_file;
    }
}