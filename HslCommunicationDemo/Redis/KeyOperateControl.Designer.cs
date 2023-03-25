namespace HslRedisDesktop
{
	partial class KeyOperateControl
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
			this.label_type = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_rename = new System.Windows.Forms.Button();
			this.button_ttl = new System.Windows.Forms.Button();
			this.button_delete = new System.Windows.Forms.Button();
			this.button_move = new System.Windows.Forms.Button();
			this.button_reload = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label_type
			// 
			this.label_type.AutoSize = true;
			this.label_type.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_type.Location = new System.Drawing.Point(3, 5);
			this.label_type.Name = "label_type";
			this.label_type.Size = new System.Drawing.Size(48, 17);
			this.label_type.TabIndex = 0;
			this.label_type.Text = "String:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.Location = new System.Drawing.Point(57, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(394, 23);
			this.textBox1.TabIndex = 1;
			// 
			// button_rename
			// 
			this.button_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_rename.Location = new System.Drawing.Point(457, 1);
			this.button_rename.Name = "button_rename";
			this.button_rename.Size = new System.Drawing.Size(64, 25);
			this.button_rename.TabIndex = 2;
			this.button_rename.Text = "重命名";
			this.button_rename.UseVisualStyleBackColor = true;
			// 
			// button_ttl
			// 
			this.button_ttl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_ttl.Location = new System.Drawing.Point(527, 1);
			this.button_ttl.Name = "button_ttl";
			this.button_ttl.Size = new System.Drawing.Size(82, 25);
			this.button_ttl.TabIndex = 3;
			this.button_ttl.Text = "TTL:-1";
			this.button_ttl.UseVisualStyleBackColor = true;
			// 
			// button_delete
			// 
			this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_delete.Location = new System.Drawing.Point(615, 1);
			this.button_delete.Name = "button_delete";
			this.button_delete.Size = new System.Drawing.Size(55, 25);
			this.button_delete.TabIndex = 4;
			this.button_delete.Text = "删除";
			this.button_delete.UseVisualStyleBackColor = true;
			// 
			// button_move
			// 
			this.button_move.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_move.Location = new System.Drawing.Point(676, 1);
			this.button_move.Name = "button_move";
			this.button_move.Size = new System.Drawing.Size(55, 25);
			this.button_move.TabIndex = 5;
			this.button_move.Text = "移动";
			this.button_move.UseVisualStyleBackColor = true;
			// 
			// button_reload
			// 
			this.button_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_reload.Location = new System.Drawing.Point(737, 1);
			this.button_reload.Name = "button_reload";
			this.button_reload.Size = new System.Drawing.Size(55, 25);
			this.button_reload.TabIndex = 6;
			this.button_reload.Text = "重加载";
			this.button_reload.UseVisualStyleBackColor = true;
			// 
			// KeyOperateControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.button_reload);
			this.Controls.Add(this.button_move);
			this.Controls.Add(this.button_delete);
			this.Controls.Add(this.button_ttl);
			this.Controls.Add(this.button_rename);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label_type);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "KeyOperateControl";
			this.Size = new System.Drawing.Size(796, 28);
			this.Load += new System.EventHandler(this.KeyOperateControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_type;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button_rename;
		private System.Windows.Forms.Button button_ttl;
		private System.Windows.Forms.Button button_delete;
		private System.Windows.Forms.Button button_move;
		private System.Windows.Forms.Button button_reload;
	}
}
