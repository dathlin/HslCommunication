using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;

namespace HslCommunicationDemo
{
	public partial class FormCharge : HslFormContent
	{
		public FormCharge( )
		{
			InitializeComponent( );
		}

		private Timer timer1s;

		private void FormCharge_Load( object sender, EventArgs e )
		{
			if (Program.IsActive)
			{

			}
			else
			{
				timer1s = new Timer( );
				timer1s.Tick += Timer1s_Tick;
				timer1s.Interval = 500;
				timer1s.Start( );
			}

			if(Program.Language == 2)
			{
				Text = "Charge";
				label17.Text = "The copyright of this component belongs to Hangzhou Hu Gong Iot Technology Co., Ltd., " +
					"commercial use please contact authorization, thank you for China's industrial software industry, " +
					"automation industry support. Any misappropriated software, cracking software, " +
					"commercial use without formal contract authorization is considered infringement, " +
					"will be held accountable according to law, commercial use includes direct integrated sales and internal use of economic benefits.";
				label7.Text = @"One-time payment, permanent authorization
C#+Java+Python all code
Support subsequent updates
Support windows+linux
Consulting QQ:200962190
Email: hsl200909@163.com";
				label9.Text = "Enterprise commercial + source code";
				label8.Text = "Please contact for a quote";
				label3.Text = @"Can only call C# dll
Continuous operation for 20 years
Up to 100 PLCs per project
Software restart and re-time
Scan the QR code below to pay and add vip group
Only for testing environment and academic research";
				label1.Text = "Personal non-commercial";
				label2.Text = "39 $";
			}
		}

		private void Timer1s_Tick( object sender, EventArgs e )
		{
		}

		private void tableLayoutPanel1_Paint( object sender, PaintEventArgs e )
		{

		}

		private void label1_Click( object sender, EventArgs e )
		{

		}
	}
}
