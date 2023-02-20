namespace HslCommunicationDemo.DemoControl
{
	partial class FormSaveList
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
			this.components = new System.ComponentModel.Container();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView2
			// 
			this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView2.Location = new System.Drawing.Point(0, 0);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(221, 561);
			this.treeView2.TabIndex = 1;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDeviceToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(152, 26);
			// 
			// deleteDeviceToolStripMenuItem
			// 
			this.deleteDeviceToolStripMenuItem.Image = global::HslCommunicationDemo.Properties.Resources.action_Cancel_16xLG;
			this.deleteDeviceToolStripMenuItem.Name = "deleteDeviceToolStripMenuItem";
			this.deleteDeviceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.deleteDeviceToolStripMenuItem.Text = "DeleteDevice";
			// 
			// FormSaveList
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(221, 561);
			this.Controls.Add(this.treeView2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSaveList";
			this.Text = "Save List";
			this.Load += new System.EventHandler(this.FormSaveList_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteDeviceToolStripMenuItem;
	}
}