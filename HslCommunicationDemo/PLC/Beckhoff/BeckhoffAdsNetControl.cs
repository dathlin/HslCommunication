using HslCommunication;
using HslCommunication.Profinet.Beckhoff;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Beckhoff
{
	public class BeckhoffAdsNetControl : UserControl
	{
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button3;
		private Label label_result;
		private TextBox textBox_code;
		private Label label_code;
		private System.Windows.Forms.GroupBox groupBox1;

		public BeckhoffAdsNetControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label_result = new System.Windows.Forms.Label();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox_code);
			this.groupBox1.Controls.Add(this.label_code);
			this.groupBox1.Controls.Add(this.label_result);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(858, 226);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ads Function";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(487, 23);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(128, 28);
			this.button5.TabIndex = 19;
			this.button5.Text = "Release Handle";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(353, 26);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(128, 23);
			this.textBox4.TabIndex = 18;
			this.textBox4.Text = "0";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(143, 23);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(128, 28);
			this.button4.TabIndex = 17;
			this.button4.Text = "Read Ads State";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(61, 57);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(791, 117);
			this.textBox3.TabIndex = 16;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 23);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 28);
			this.button3.TabIndex = 15;
			this.button3.Text = "Read Ads Info";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label_result
			// 
			this.label_result.AutoSize = true;
			this.label_result.Location = new System.Drawing.Point(5, 61);
			this.label_result.Name = "label_result";
			this.label_result.Size = new System.Drawing.Size(35, 17);
			this.label_result.TabIndex = 20;
			this.label_result.Text = "结果:";
			// 
			// label_code
			// 
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(6, 179);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(35, 17);
			this.label_code.TabIndex = 21;
			this.label_code.Text = "代码:";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(61, 179);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(791, 45);
			this.textBox_code.TabIndex = 22;
			// 
			// BeckhoffAdsNetControl
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "BeckhoffAdsNetControl";
			this.Size = new System.Drawing.Size(864, 232);
			this.Load += new System.EventHandler(this.BeckhoffAdsNetControl_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		public void SetDevice( BeckhoffAdsNet beckhoffAdsNet, string address )
		{
			this.beckhoffAdsNet = beckhoffAdsNet;
		}

		private BeckhoffAdsNet beckhoffAdsNet;

		private async void button3_Click( object sender, EventArgs e )
		{
			OperateResult<AdsDeviceInfo> read = await beckhoffAdsNet.ReadAdsDeviceInfoAsync( );
			if (read.IsSuccess)
			{
				textBox3.Text = $"Major:{read.Content.Major}{Environment.NewLine}" +
					$"Minor:{read.Content.Minor}{Environment.NewLine}" +
					$"Build:{read.Content.Build}{Environment.NewLine}" +
					$"Name:{read.Content.DeviceName}";
			}
			else
			{
				MessageBox.Show( "Read Faild:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<AdsDeviceInfo> read = {DemoUtils.PlcDeviceName}.ReadAdsDeviceInfo( );";
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			//OperateResult<Student> read2 = beckhoffAdsNet.ReadStruct<Student>( "s=MAIN.zz" );
			//if (read2.IsSuccess)
			//{
			//	textBox3.Text = "Read success:\r\n" + read2.Content.ToJsonString( );
			//}
			//else
			//{
			//	MessageBox.Show( "Read Faild:" + read2.Message );
			//}
			//return;
			OperateResult<ushort, ushort> read = await beckhoffAdsNet.ReadAdsStateAsync( );
			if (read.IsSuccess)
			{
				textBox3.Text = $"Ads State:{read.Content1}{Environment.NewLine}" +
					$"Device State:{read.Content2}{Environment.NewLine}";
			}
			else
			{
				MessageBox.Show( "Read Faild:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<ushort, ushort> read = {DemoUtils.PlcDeviceName}.ReadAdsState( );  // Content1: Ads State  Content2: Device State";
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			if (!uint.TryParse( textBox4.Text, out uint handle ))
			{
				MessageBox.Show( "Handle input not corrent" );
				return;
			}

			OperateResult release = await beckhoffAdsNet.ReleaseSystemHandleAsync( handle );
			if (release.IsSuccess)
			{
				MessageBox.Show( "Release Success!" );
			}
			else
			{
				MessageBox.Show( "Release Failed:" + release.Message );
			}

			textBox_code.Text = $"OperateResult release = {DemoUtils.PlcDeviceName}.ReleaseSystemHandle( {handle} );";
		}

		private void BeckhoffAdsNetControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label_result.Text = "Result:";
				label_code.Text = "Code:";
			}
		}
	}
	public struct Student
	{
		public short A { get; set; }
		public float B { get; set; }
		public short C { get; set; }
	}
}
