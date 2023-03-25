namespace HslCommunicationDemo.DemoControl
{
	partial class UserControlReadWriteDevice
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
			this.userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.batchReadControl1 = new HslCommunicationDemo.DemoControl.BatchReadControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.batchReadControl2 = new HslCommunicationDemo.DemoControl.BatchReadControl();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// userControlReadWriteOp1
			// 
			this.userControlReadWriteOp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userControlReadWriteOp1.Location = new System.Drawing.Point(0, 0);
			this.userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			this.userControlReadWriteOp1.Size = new System.Drawing.Size(954, 273);
			this.userControlReadWriteOp1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 272);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(954, 282);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.batchReadControl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(946, 252);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "批量读取";
			// 
			// batchReadControl1
			// 
			this.batchReadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.batchReadControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.batchReadControl1.IsSourceReadMode = false;
			this.batchReadControl1.Location = new System.Drawing.Point(3, 3);
			this.batchReadControl1.Name = "batchReadControl1";
			this.batchReadControl1.Size = new System.Drawing.Size(940, 246);
			this.batchReadControl1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.batchReadControl2);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(946, 252);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "报文读取";
			// 
			// batchReadControl2
			// 
			this.batchReadControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.batchReadControl2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.batchReadControl2.IsSourceReadMode = true;
			this.batchReadControl2.Location = new System.Drawing.Point(3, 3);
			this.batchReadControl2.Name = "batchReadControl2";
			this.batchReadControl2.Size = new System.Drawing.Size(940, 246);
			this.batchReadControl2.TabIndex = 1;
			// 
			// UserControlReadWriteDevice
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.userControlReadWriteOp1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "UserControlReadWriteDevice";
			this.Size = new System.Drawing.Size(954, 554);
			this.Load += new System.EventHandler(this.UserControlReadWriteDevice_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UserControlReadWriteOp userControlReadWriteOp1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private BatchReadControl batchReadControl1;
		private System.Windows.Forms.TabPage tabPage2;
		private BatchReadControl batchReadControl2;
	}
}
