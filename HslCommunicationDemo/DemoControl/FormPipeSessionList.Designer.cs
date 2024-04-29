namespace HslCommunicationDemo.DemoControl
{
	partial class FormPipeSessionList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPipeSessionList));
			this.pipeSessionListControl1 = new HslCommunicationDemo.DemoControl.PipeSessionListControl();
			this.SuspendLayout();
			// 
			// pipeSessionListControl1
			// 
			this.pipeSessionListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pipeSessionListControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.pipeSessionListControl1.Location = new System.Drawing.Point(0, 0);
			this.pipeSessionListControl1.Name = "pipeSessionListControl1";
			this.pipeSessionListControl1.Size = new System.Drawing.Size(800, 450);
			this.pipeSessionListControl1.TabIndex = 0;
			// 
			// FormPipeSessionList
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pipeSessionListControl1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPipeSessionList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SessionList";
			this.ResumeLayout(false);

		}

		#endregion

		private PipeSessionListControl pipeSessionListControl1;
	}
}