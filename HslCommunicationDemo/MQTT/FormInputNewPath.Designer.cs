namespace HslCommunicationDemo.MQTT
{
	partial class FormInputNewPath
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
			this.textBox_path_old = new System.Windows.Forms.TextBox();
			this.textBox_path_new = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "当前路径:";
			// 
			// textBox_path_old
			// 
			this.textBox_path_old.Location = new System.Drawing.Point(110, 22);
			this.textBox_path_old.Name = "textBox_path_old";
			this.textBox_path_old.Size = new System.Drawing.Size(322, 23);
			this.textBox_path_old.TabIndex = 1;
			// 
			// textBox_path_new
			// 
			this.textBox_path_new.Location = new System.Drawing.Point(110, 61);
			this.textBox_path_new.Name = "textBox_path_new";
			this.textBox_path_new.Size = new System.Drawing.Size(322, 23);
			this.textBox_path_new.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "新的路径:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(153, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(155, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormInputNewPath
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(491, 149);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_path_new);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_path_old);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(507, 188);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(507, 188);
			this.Name = "FormInputNewPath";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormInputNewPath";
			this.Load += new System.EventHandler(this.FormInputNewPath_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_path_old;
		private System.Windows.Forms.TextBox textBox_path_new;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
	}
}