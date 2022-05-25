namespace HslCommunicationDemo.MQTT
{
	partial class FormWillTopicSetting
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
			this.textBox_topic = new System.Windows.Forms.TextBox();
			this.textBox_message = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Wiil Topic:";
			// 
			// textBox_topic
			// 
			this.textBox_topic.Location = new System.Drawing.Point(93, 17);
			this.textBox_topic.Name = "textBox_topic";
			this.textBox_topic.Size = new System.Drawing.Size(240, 23);
			this.textBox_topic.TabIndex = 1;
			// 
			// textBox_message
			// 
			this.textBox_message.Location = new System.Drawing.Point(22, 79);
			this.textBox_message.Multiline = true;
			this.textBox_message.Name = "textBox_message";
			this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_message.Size = new System.Drawing.Size(311, 154);
			this.textBox_message.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Wiil Message:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 249);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(135, 37);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormWillTopicSetting
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(348, 307);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_message);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_topic);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormWillTopicSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "WillTopicSetting";
			this.Load += new System.EventHandler(this.FormWillTopicSetting_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_topic;
		private System.Windows.Forms.TextBox textBox_message;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
	}
}