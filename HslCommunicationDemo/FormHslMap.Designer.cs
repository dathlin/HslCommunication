namespace HslCommunicationDemo
{
    partial class FormHslMap
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
            this.userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
            this.hslChinaMap1 = new HslControls.Advanced.HslChinaMap();
            this.SuspendLayout();
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
            this.userControlHead1.Size = new System.Drawing.Size(1004, 32);
            this.userControlHead1.TabIndex = 21;
            // 
            // hslChinaMap1
            // 
            this.hslChinaMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hslChinaMap1.CanMouseMoveHighlight = false;
            this.hslChinaMap1.GraphicColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.hslChinaMap1.Location = new System.Drawing.Point(0, 32);
            this.hslChinaMap1.Name = "hslChinaMap1";
            this.hslChinaMap1.OffsetX = 0;
            this.hslChinaMap1.OffsetY = 0;
            this.hslChinaMap1.ProvinceColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.hslChinaMap1.Size = new System.Drawing.Size(1004, 612);
            this.hslChinaMap1.TabIndex = 22;
            // 
            // FormHslMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.hslChinaMap1);
            this.Controls.Add(this.userControlHead1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormHslMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSL全国使用分布";
            this.Load += new System.EventHandler(this.FormTcpDebug_Load);
            this.Shown += new System.EventHandler(this.FormHslMap_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private DemoControl.UserControlHead userControlHead1;
        private HslControls.Advanced.HslChinaMap hslChinaMap1;
    }
}