using HslCommunication;
using HslCommunication.Profinet.Panasonic;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Panasonic
{
	public class MewtocolControl : UserControl
	{
		public MewtocolControl( )
		{
			InitializeComponent( );
		}
		private System.Windows.Forms.TextBox textBox1;
		private Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Button button5;

		private void InitializeComponent( )
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(3, 37);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(807, 159);
			this.textBox1.TabIndex = 29;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(3, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(108, 28);
			this.button5.TabIndex = 28;
			this.button5.Text = "Plc-Type";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(3, 199);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 30;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(53, 199);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.Size = new System.Drawing.Size(757, 57);
			this.textBox_code.TabIndex = 31;
			// 
			// MewtocolControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button5);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "MewtocolControl";
			this.Size = new System.Drawing.Size(813, 259);
			this.Load += new System.EventHandler(this.MewtocolControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = mewtocol == null ? mewtocolOverTcp.ReadPlcType( ) : mewtocol.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox1.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content;
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";
		}

		public void SetDevice( PanasonicMewtocol mewtocol, string address )
		{
			this.mewtocol = mewtocol;
		}


		public void SetDevice( PanasonicMewtocolOverTcp mewtocolOverTcp, string address )
		{
			this.mewtocolOverTcp = mewtocolOverTcp;
		}

		private PanasonicMewtocol mewtocol;
		private PanasonicMewtocolOverTcp mewtocolOverTcp;

		private void MewtocolControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_code.Text = "Code:";
			}
		}
	}
}
