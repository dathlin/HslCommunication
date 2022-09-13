namespace HslCommunicationDemo.MQTT
{
	partial class FormMqttSubscribe
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
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.radioButton_binary = new System.Windows.Forms.RadioButton();
			this.radioButton_json = new System.Windows.Forms.RadioButton();
			this.radioButton_text = new System.Windows.Forms.RadioButton();
			this.radioButton_xml = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.checkBox_long_message_hide = new System.Windows.Forms.CheckBox();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(70, 19);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(559, 23);
			this.textBox5.TabIndex = 11;
			this.textBox5.Text = "A";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 17);
			this.label7.TabIndex = 10;
			this.label7.Text = "Topic：";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(69, 430);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(93, 17);
			this.label10.TabIndex = 35;
			this.label10.Text = "Receive Count:";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.radioButton_binary);
			this.panel3.Controls.Add(this.radioButton_json);
			this.panel3.Controls.Add(this.radioButton_text);
			this.panel3.Controls.Add(this.radioButton_xml);
			this.panel3.Location = new System.Drawing.Point(538, 62);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(246, 28);
			this.panel3.TabIndex = 34;
			// 
			// radioButton_binary
			// 
			this.radioButton_binary.AutoSize = true;
			this.radioButton_binary.Location = new System.Drawing.Point(3, 3);
			this.radioButton_binary.Name = "radioButton_binary";
			this.radioButton_binary.Size = new System.Drawing.Size(62, 21);
			this.radioButton_binary.TabIndex = 29;
			this.radioButton_binary.Text = "Binary";
			this.radioButton_binary.UseVisualStyleBackColor = true;
			// 
			// radioButton_json
			// 
			this.radioButton_json.AutoSize = true;
			this.radioButton_json.Location = new System.Drawing.Point(175, 3);
			this.radioButton_json.Name = "radioButton_json";
			this.radioButton_json.Size = new System.Drawing.Size(52, 21);
			this.radioButton_json.TabIndex = 28;
			this.radioButton_json.Text = "Json";
			this.radioButton_json.UseVisualStyleBackColor = true;
			// 
			// radioButton_text
			// 
			this.radioButton_text.AutoSize = true;
			this.radioButton_text.Checked = true;
			this.radioButton_text.Location = new System.Drawing.Point(65, 3);
			this.radioButton_text.Name = "radioButton_text";
			this.radioButton_text.Size = new System.Drawing.Size(50, 21);
			this.radioButton_text.TabIndex = 26;
			this.radioButton_text.TabStop = true;
			this.radioButton_text.Text = "Text";
			this.radioButton_text.UseVisualStyleBackColor = true;
			// 
			// radioButton_xml
			// 
			this.radioButton_xml.AutoSize = true;
			this.radioButton_xml.Location = new System.Drawing.Point(121, 3);
			this.radioButton_xml.Name = "radioButton_xml";
			this.radioButton_xml.Size = new System.Drawing.Size(48, 21);
			this.radioButton_xml.TabIndex = 27;
			this.radioButton_xml.Text = "Xml";
			this.radioButton_xml.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(458, 56);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(74, 21);
			this.radioButton2.TabIndex = 33;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "追加显示";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(458, 74);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(74, 21);
			this.radioButton1.TabIndex = 32;
			this.radioButton1.Text = "覆盖显示";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(72, 96);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(783, 331);
			this.textBox8.TabIndex = 30;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 98);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 17);
			this.label12.TabIndex = 31;
			this.label12.Text = "Receive：";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(784, 61);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(71, 28);
			this.button4.TabIndex = 29;
			this.button4.Text = "清空";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button8.Location = new System.Drawing.Point(750, 17);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 28);
			this.button8.TabIndex = 37;
			this.button8.Text = "取消订阅";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(646, 17);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(98, 28);
			this.button7.TabIndex = 36;
			this.button7.Text = "订阅";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// checkBox_long_message_hide
			// 
			this.checkBox_long_message_hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_long_message_hide.AutoSize = true;
			this.checkBox_long_message_hide.Checked = true;
			this.checkBox_long_message_hide.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_long_message_hide.Location = new System.Drawing.Point(756, 433);
			this.checkBox_long_message_hide.Name = "checkBox_long_message_hide";
			this.checkBox_long_message_hide.Size = new System.Drawing.Size(99, 21);
			this.checkBox_long_message_hide.TabIndex = 38;
			this.checkBox_long_message_hide.Text = "超长消息简略";
			this.checkBox_long_message_hide.UseVisualStyleBackColor = true;
			// 
			// FormMqttSubscribe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 456);
			this.Controls.Add(this.checkBox_long_message_hide);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label7);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormMqttSubscribe";
			this.Text = "FormMqttSubscribe";
			this.Load += new System.EventHandler(this.FormMqttSubscribe_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton radioButton_binary;
		private System.Windows.Forms.RadioButton radioButton_json;
		private System.Windows.Forms.RadioButton radioButton_text;
		private System.Windows.Forms.RadioButton radioButton_xml;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.CheckBox checkBox_long_message_hide;
	}
}