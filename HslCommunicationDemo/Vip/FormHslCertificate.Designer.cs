namespace HslCommunicationDemo.Vip
{
	partial class FormHslCertificate
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
			this.hslCertificateControl1 = new HslCommunicationDemo.Vip.HslCertificateControl();
			this.SuspendLayout();
			// 
			// hslCertificateControl1
			// 
			this.hslCertificateControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.hslCertificateControl1.Location = new System.Drawing.Point(3, 3);
			this.hslCertificateControl1.Name = "hslCertificateControl1";
			this.hslCertificateControl1.Size = new System.Drawing.Size(730, 468);
			this.hslCertificateControl1.TabIndex = 0;
			// 
			// FormHslCertificate
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(738, 482);
			this.Controls.Add(this.hslCertificateControl1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "FormHslCertificate";
			this.Text = "HslCertificate [证书界面]";
			this.ResumeLayout(false);

		}

		#endregion

		private HslCertificateControl hslCertificateControl1;
	}
}