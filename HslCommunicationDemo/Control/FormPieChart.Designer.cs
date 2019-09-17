namespace HslCommunicationDemo
{
    partial class FormPieChart
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
            this.userPieChart1 = new HslCommunication.Controls.UserPieChart();
            this.userPieChart2 = new HslCommunication.Controls.UserPieChart();
            this.userPieChart3 = new HslCommunication.Controls.UserPieChart();
            this.userPieChart4 = new HslCommunication.Controls.UserPieChart();
            this.userPieChart5 = new HslCommunication.Controls.UserPieChart();
            this.SuspendLayout();
            // 
            // userPieChart1
            // 
            this.userPieChart1.BackColor = System.Drawing.Color.Transparent;
            this.userPieChart1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPieChart1.Location = new System.Drawing.Point(37, 13);
            this.userPieChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPieChart1.Name = "userPieChart1";
            this.userPieChart1.Size = new System.Drawing.Size(279, 273);
            this.userPieChart1.TabIndex = 0;
            // 
            // userPieChart2
            // 
            this.userPieChart2.BackColor = System.Drawing.Color.Transparent;
            this.userPieChart2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPieChart2.Location = new System.Drawing.Point(364, 13);
            this.userPieChart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPieChart2.Name = "userPieChart2";
            this.userPieChart2.Size = new System.Drawing.Size(279, 273);
            this.userPieChart2.TabIndex = 1;
            // 
            // userPieChart3
            // 
            this.userPieChart3.BackColor = System.Drawing.Color.Transparent;
            this.userPieChart3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPieChart3.IsRenderPercent = true;
            this.userPieChart3.Location = new System.Drawing.Point(688, 13);
            this.userPieChart3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPieChart3.Name = "userPieChart3";
            this.userPieChart3.Size = new System.Drawing.Size(279, 273);
            this.userPieChart3.TabIndex = 2;
            // 
            // userPieChart4
            // 
            this.userPieChart4.BackColor = System.Drawing.Color.Transparent;
            this.userPieChart4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPieChart4.IsRenderPercent = true;
            this.userPieChart4.IsRenderSmall = false;
            this.userPieChart4.Location = new System.Drawing.Point(37, 312);
            this.userPieChart4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPieChart4.Name = "userPieChart4";
            this.userPieChart4.Size = new System.Drawing.Size(279, 273);
            this.userPieChart4.TabIndex = 3;
            // 
            // userPieChart5
            // 
            this.userPieChart5.BackColor = System.Drawing.Color.Transparent;
            this.userPieChart5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPieChart5.Location = new System.Drawing.Point(480, 288);
            this.userPieChart5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPieChart5.Name = "userPieChart5";
            this.userPieChart5.Size = new System.Drawing.Size(362, 344);
            this.userPieChart5.TabIndex = 4;
            // 
            // FormPieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.userPieChart5);
            this.Controls.Add(this.userPieChart4);
            this.Controls.Add(this.userPieChart3);
            this.Controls.Add(this.userPieChart2);
            this.Controls.Add(this.userPieChart1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPieChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "饼图控件";
            this.Load += new System.EventHandler(this.FormPieChart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslCommunication.Controls.UserPieChart userPieChart1;
        private HslCommunication.Controls.UserPieChart userPieChart2;
        private HslCommunication.Controls.UserPieChart userPieChart3;
        private HslCommunication.Controls.UserPieChart userPieChart4;
        private HslCommunication.Controls.UserPieChart userPieChart5;
    }
}