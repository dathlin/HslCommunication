namespace HslCommunicationDemo
{
    partial class FormGauge
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.userGaugeChart5 = new HslCommunication.Controls.UserGaugeChart();
            this.userGaugeChart4 = new HslCommunication.Controls.UserGaugeChart();
            this.userGaugeChart3 = new HslCommunication.Controls.UserGaugeChart();
            this.userGaugeChart2 = new HslCommunication.Controls.UserGaugeChart();
            this.userGaugeChart1 = new HslCommunication.Controls.UserGaugeChart();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(673, 1);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(331, 638);
            this.propertyGrid1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(350, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 75);
            this.label1.TabIndex = 35;
            this.label1.Text = "该控件的基本属性可由右侧的控件界面设置";
            // 
            // userGaugeChart5
            // 
            this.userGaugeChart5.BackColor = System.Drawing.Color.Transparent;
            this.userGaugeChart5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGaugeChart5.IsTextUnderPointer = false;
            this.userGaugeChart5.Location = new System.Drawing.Point(338, 13);
            this.userGaugeChart5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGaugeChart5.Name = "userGaugeChart5";
            this.userGaugeChart5.Size = new System.Drawing.Size(316, 179);
            this.userGaugeChart5.TabIndex = 34;
            this.userGaugeChart5.UnitText = "km/H";
            this.userGaugeChart5.Value = 50D;
            // 
            // userGaugeChart4
            // 
            this.userGaugeChart4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.userGaugeChart4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGaugeChart4.Location = new System.Drawing.Point(353, 435);
            this.userGaugeChart4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGaugeChart4.Name = "userGaugeChart4";
            this.userGaugeChart4.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.userGaugeChart4.Size = new System.Drawing.Size(301, 183);
            this.userGaugeChart4.TabIndex = 32;
            this.userGaugeChart4.Value = 50D;
            // 
            // userGaugeChart3
            // 
            this.userGaugeChart3.BackColor = System.Drawing.Color.Transparent;
            this.userGaugeChart3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGaugeChart3.Location = new System.Drawing.Point(12, 435);
            this.userGaugeChart3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGaugeChart3.Name = "userGaugeChart3";
            this.userGaugeChart3.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.userGaugeChart3.Size = new System.Drawing.Size(320, 197);
            this.userGaugeChart3.TabIndex = 31;
            this.userGaugeChart3.Value = 60D;
            // 
            // userGaugeChart2
            // 
            this.userGaugeChart2.BackColor = System.Drawing.Color.Transparent;
            this.userGaugeChart2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGaugeChart2.IsBigSemiCircle = true;
            this.userGaugeChart2.IsTextUnderPointer = false;
            this.userGaugeChart2.Location = new System.Drawing.Point(12, 196);
            this.userGaugeChart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGaugeChart2.Name = "userGaugeChart2";
            this.userGaugeChart2.SegmentCount = 14;
            this.userGaugeChart2.Size = new System.Drawing.Size(320, 245);
            this.userGaugeChart2.TabIndex = 30;
            this.userGaugeChart2.UnitText = "km/H";
            this.userGaugeChart2.Value = 50D;
            this.userGaugeChart2.ValueMax = 140D;
            // 
            // userGaugeChart1
            // 
            this.userGaugeChart1.BackColor = System.Drawing.Color.Transparent;
            this.userGaugeChart1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGaugeChart1.IsTextUnderPointer = false;
            this.userGaugeChart1.Location = new System.Drawing.Point(12, 13);
            this.userGaugeChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGaugeChart1.Name = "userGaugeChart1";
            this.userGaugeChart1.SegmentCount = 5;
            this.userGaugeChart1.Size = new System.Drawing.Size(320, 183);
            this.userGaugeChart1.TabIndex = 29;
            this.userGaugeChart1.UnitText = "km/h";
            this.userGaugeChart1.Value = -100D;
            this.userGaugeChart1.ValueAlarmMin = -180D;
            this.userGaugeChart1.ValueMax = -100D;
            this.userGaugeChart1.ValueStart = -200D;
            // 
            // FormGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userGaugeChart5);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.userGaugeChart4);
            this.Controls.Add(this.userGaugeChart3);
            this.Controls.Add(this.userGaugeChart2);
            this.Controls.Add(this.userGaugeChart1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGauge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "仪表盘控件";
            this.Load += new System.EventHandler(this.FormGauge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslCommunication.Controls.UserGaugeChart userGaugeChart4;
        private HslCommunication.Controls.UserGaugeChart userGaugeChart3;
        private HslCommunication.Controls.UserGaugeChart userGaugeChart2;
        private HslCommunication.Controls.UserGaugeChart userGaugeChart1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private HslCommunication.Controls.UserGaugeChart userGaugeChart5;
        private System.Windows.Forms.Label label1;
    }
}