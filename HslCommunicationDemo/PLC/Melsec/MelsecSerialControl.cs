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
	public class MelsecSerialControl : SpecialFeaturesControl
	{
		private System.Windows.Forms.Button button_active_plc;
		private System.Windows.Forms.GroupBox groupBox2;

		public MelsecSerialControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button_active_plc = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.button_active_plc);
			this.groupBox2.Location = new System.Drawing.Point(251, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(398, 226);
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
			// MelsecSerialControl
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "MelsecSerialControl";
			this.Controls.SetChildIndex(this.groupBox2, 0);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

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
		}

		public void SetDevice( IMelsecFxSerial melsecFxSerial, string address )
		{
			this.melsec = melsecFxSerial;
			base.SetDevice( melsecFxSerial, address );
		}

		private IMelsecFxSerial melsec;
	}
}
