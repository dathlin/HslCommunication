namespace HslCommunicationDemo
{
    partial class FormOmronCipServer
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.serverSettingControl1 = new HslCommunicationDemo.DemoControl.ServerSettingControl();
			this.sslServerControl1 = new HslCommunicationDemo.DemoControl.SslServerControl();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			this.label2 = new System.Windows.Forms.Label();
			this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.serverSettingControl1);
			this.panel1.Controls.Add(this.sslServerControl1);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Location = new System.Drawing.Point(3, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(997, 65);
			this.panel1.TabIndex = 0;
			// 
			// serverSettingControl1
			// 
			this.serverSettingControl1.buttonCloseAction = null;
			this.serverSettingControl1.buttonSerialAction = null;
			this.serverSettingControl1.buttonStartAction = null;
			this.serverSettingControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.serverSettingControl1.Location = new System.Drawing.Point(2, 1);
			this.serverSettingControl1.Name = "serverSettingControl1";
			this.serverSettingControl1.Size = new System.Drawing.Size(958, 30);
			this.serverSettingControl1.TabIndex = 32;
			this.serverSettingControl1.TextPort = "44818";
			this.serverSettingControl1.TextSerialInfo = "COM4-9600-8-N-1";
			// 
			// sslServerControl1
			// 
			this.sslServerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sslServerControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.sslServerControl1.Location = new System.Drawing.Point(153, 31);
			this.sslServerControl1.Name = "sslServerControl1";
			this.sslServerControl1.Size = new System.Drawing.Size(835, 30);
			this.sslServerControl1.TabIndex = 31;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(3, 35);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(111, 21);
			this.checkBox1.TabIndex = 30;
			this.checkBox1.Text = "写入时创建标签";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.userControlReadWriteServer1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(3, 105);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(997, 537);
			this.panel2.TabIndex = 1;
			// 
			// userControlReadWriteServer1
			// 
			this.userControlReadWriteServer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlReadWriteServer1.Location = new System.Drawing.Point(2, 25);
			this.userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			this.userControlReadWriteServer1.Size = new System.Drawing.Size(990, 511);
			this.userControlReadWriteServer1.TabIndex = 19;
			this.userControlReadWriteServer1.Load += new System.EventHandler(this.userControlReadWriteServer1_Load);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Green;
			this.label2.Location = new System.Drawing.Point(8, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(865, 17);
			this.label2.TabIndex = 18;
			this.label2.Text = "服务器值列表：   A short ; A1  float[20]  ;  B int ;  C   float ;     D  short[20];     " +
    "E  bool;     F  string ;  G  sting[5];   AB.C  short[5];   M  uint[4];  N   long" +
    "";
			// 
			// userControlHead1
			// 
			this.userControlHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			this.userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.userControlHead1.Location = new System.Drawing.Point(0, 0);
			this.userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			this.userControlHead1.Name = "userControlHead1";
			this.userControlHead1.ProtocolInfo = "Cip";
			this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
			this.userControlHead1.TabIndex = 2;
			this.userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(this.userControlHead1_SaveConnectEvent_1);
			// 
			// FormOmronCipServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1004, 645);
			this.Controls.Add(this.userControlHead1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormOmronCipServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Omron PLC虚拟服务器【仅支持单数据，一维数组】";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSiemens_FormClosing);
			this.Load += new System.EventHandler(this.FormSiemens_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DemoControl.UserControlHead userControlHead1;
        private System.Windows.Forms.Label label2;
        private DemoControl.UserControlReadWriteServer userControlReadWriteServer1;
		private System.Windows.Forms.CheckBox checkBox1;
		private DemoControl.SslServerControl sslServerControl1;
		private DemoControl.ServerSettingControl serverSettingControl1;
	}
}