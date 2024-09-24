using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormPropertyModify : System.Windows.Forms.Form
	{
		public FormPropertyModify( )
		{
			InitializeComponent( );
		}

		public void SetObject( object obj ){
			label1.Text = "Object: " + obj.ToString( );
			this.propertyGrid1.SelectedObject = obj;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
		}
	}
}
