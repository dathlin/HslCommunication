using HslCommunication;
using HslCommunication.Profinet.Omron.Helper;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HslCommunicationDemo.PLC.Omron
{
	public class HostLinkCModeControl : UserControl
	{
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label_code;
		private TextBox textBox_code;
		private System.Windows.Forms.Label label5;

		public HostLinkCModeControl( )
		{
			InitializeComponent( );

			if (Program.Language == 2)
			{
				comboBox4.DataSource = new string[] { "programming", "running", "monitoring" };

				label5.Text = "Result:";
				label_code.Text = "Code:";
			}
			else
			{
				comboBox4.DataSource = new string[] { "编程模式", "运行模式", "监视模式" };
			}
		}

		private void InitializeComponent( )
		{
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// comboBox4
			// 
			this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(241, 6);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(157, 25);
			this.comboBox4.TabIndex = 15;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(404, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(101, 28);
			this.button5.TabIndex = 14;
			this.button5.Text = "Set Mode";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(115, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(101, 28);
			this.button4.TabIndex = 13;
			this.button4.Text = "Read Mode";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(101, 28);
			this.button3.TabIndex = 11;
			this.button3.Text = "Read Type";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(64, 40);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(742, 108);
			this.textBox3.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "结果：";
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(0, 155);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 16;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(64, 152);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(742, 56);
			this.textBox_code.TabIndex = 17;
			// 
			// HostLinkCModeControl
			// 
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.comboBox4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label5);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "HostLinkCModeControl";
			this.Size = new System.Drawing.Size(809, 211);
			this.Load += new System.EventHandler(this.HostLinkCModeControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void SetDevice( IHostLinkCMode hostLink, string address )
		{
			this.hostLink = hostLink;
		}

		private IHostLinkCMode hostLink;

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = hostLink.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox3.Text = "Result：" + read.Content;
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OperateResult<int> read = hostLink.ReadPlcMode( );
			if (read.IsSuccess)
			{
				textBox3.Text = "Result：" + read.Content + Environment.NewLine +
					(read.Content == 0 ? "编程模式" : read.Content == 1 ? "运行模式" : "监视模式");
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<int> read = {DemoUtils.PlcDeviceName}.ReadPlcMode( );  // 0:编程模式(programing) 1:运行模式(run) 2:监视模式(monitor)";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult op = hostLink.ChangePlcMode( (byte)comboBox4.SelectedIndex );
			if (op.IsSuccess)
			{
				MessageBox.Show( "success" );
			}
			else
			{
				MessageBox.Show( "failed:" + op.Message );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.ChangePlcMode( {(byte)comboBox4.SelectedIndex} );";
		}

		private void HostLinkCModeControl_Load( object sender, EventArgs e )
		{

		}
	}
}
