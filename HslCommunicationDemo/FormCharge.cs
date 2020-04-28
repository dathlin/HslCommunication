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
			}
		}

		int tick = 0;
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
