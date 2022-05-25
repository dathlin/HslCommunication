namespace HslCommunicationDemo.HslDebug
{
	partial class FormMessageCreate
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.hslPanelHead1 = new HslControls.HslPanelHead();
			this.button_read_word = new System.Windows.Forms.Button();
			this.button_read_bool = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.hslPanelHead1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(227, 469);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// hslPanelHead1
			// 
			this.hslPanelHead1.Controls.Add(this.button_read_word);
			this.hslPanelHead1.Controls.Add(this.button_read_bool);
			this.hslPanelHead1.Controls.Add(this.textBox2);
			this.hslPanelHead1.Controls.Add(this.label2);
			this.hslPanelHead1.Controls.Add(this.textBox1);
			this.hslPanelHead1.Controls.Add(this.label1);
			this.hslPanelHead1.Location = new System.Drawing.Point(233, 40);
			this.hslPanelHead1.Name = "hslPanelHead1";
			this.hslPanelHead1.Size = new System.Drawing.Size(562, 140);
			this.hslPanelHead1.TabIndex = 1;
			this.hslPanelHead1.Text = "读取";
			// 
			// button_read_word
			// 
			this.button_read_word.Location = new System.Drawing.Point(189, 93);
			this.button_read_word.Name = "button_read_word";
			this.button_read_word.Size = new System.Drawing.Size(162, 38);
			this.button_read_word.TabIndex = 5;
			this.button_read_word.Text = "Build Read Byte/Word";
			this.button_read_word.UseVisualStyleBackColor = true;
			this.button_read_word.Click += new System.EventHandler(this.button_read_word_Click);
			// 
			// button_read_bool
			// 
			this.button_read_bool.Location = new System.Drawing.Point(14, 93);
			this.button_read_bool.Name = "button_read_bool";
			this.button_read_bool.Size = new System.Drawing.Size(162, 38);
			this.button_read_bool.TabIndex = 4;
			this.button_read_bool.Text = "Build Read Bool";
			this.button_read_bool.UseVisualStyleBackColor = true;
			this.button_read_bool.Click += new System.EventHandler(this.button_read_bool_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(426, 43);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(109, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(357, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Length:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(94, 43);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(257, 23);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Address:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(233, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "协议：";
			// 
			// FormMessageCreate
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(800, 469);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.hslPanelHead1);
			this.Controls.Add(this.treeView1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormMessageCreate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormMessageCreate";
			this.Load += new System.EventHandler(this.FormMessageCreate_Load);
			this.Shown += new System.EventHandler(this.FormMessageCreate_Shown);
			this.hslPanelHead1.ResumeLayout(false);
			this.hslPanelHead1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private HslControls.HslPanelHead hslPanelHead1;
		private System.Windows.Forms.Button button_read_word;
		private System.Windows.Forms.Button button_read_bool;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
	}
}