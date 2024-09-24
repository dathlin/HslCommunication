using HslCommunication;
using HslCommunication.Profinet.Melsec.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Melsec
{
	public class MelsecSerialControl : UserControl
	{
		private System.Windows.Forms.Button button_active_plc;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.GroupBox groupBox2;

		public MelsecSerialControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button_active_plc = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button_active_plc);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(933, 184);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Serial Function";
			// 
			// button_active_plc
			// 
			this.button_active_plc.Location = new System.Drawing.Point(18, 25);
			this.button_active_plc.Name = "button_active_plc";
			this.button_active_plc.Size = new System.Drawing.Size(90, 28);
			this.button_active_plc.TabIndex = 24;
			this.button_active_plc.Text = "激活PLC";
			this.button_active_plc.UseVisualStyleBackColor = true;
			this.button_active_plc.Click += new System.EventHandler(this.button_active_plc_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 196);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(35, 17);
			this.label_code.TabIndex = 2;
			this.label_code.Text = "代码:";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(54, 193);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(882, 47);
			this.textBox_code.TabIndex = 3;
			// 
			// MelsecSerialControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "MelsecSerialControl";
			this.Size = new System.Drawing.Size(939, 243);
			this.Load += new System.EventHandler(this.MelsecSerialControl_Load);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void button_active_plc_Click( object sender, EventArgs e )
		{
			OperateResult active = melsec.ActivePlc( );
			if (active.IsSuccess)
			{
				MessageBox.Show( "Active Successful" );
			}
			else
			{
				MessageBox.Show( "Failed: " + active.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.ActivePlc( );";
		}

		public void SetDevice( IMelsecFxSerial melsecFxSerial, string address )
		{
			this.melsec = melsecFxSerial;
		}

		private IMelsecFxSerial melsec;

		private void MelsecSerialControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
