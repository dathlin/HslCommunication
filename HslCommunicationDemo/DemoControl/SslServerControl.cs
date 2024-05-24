using HslCommunication.Core.Device;
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
	public partial class SslServerControl : UserControl
	{
		public SslServerControl( )
		{
			InitializeComponent( );
		}

		private void button_cert_Click( object sender, EventArgs e )
		{
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					textBox_cert.Text = ofd.FileName;
				}
			}
		}

		public void InitializeServer( DeviceServer server )
		{
			if (checkBox_ssl.Checked)
			{
				server.UseSSL( textBox_cert.Text, textBox_cert_password.Text );
			}
		}
	}
}
