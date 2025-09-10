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
using System.Xml.Linq;

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

		public void InitializeServer( HslCommunication.Core.Net.CommunicationTcpServer server )
		{
			if (checkBox_ssl.Checked)
			{
				server.UseSSL( textBox_cert.Text, textBox_cert_password.Text );
			}
		}

		public bool IsUseSSL( ) => checkBox_ssl.Checked;

		public void AddServerCode( StringBuilder sb, string name = "server" )
		{
			if (IsUseSSL( ))
				sb.AppendLine( $"{name}.UseSSL( \"" + textBox_cert.Text + "\", \"" + textBox_cert_password.Text + "\" );" );
		}

		public void SaveXmlParameter( XElement element )
		{
			if (checkBox_ssl.Checked) element.SetAttributeValue( "UseSsl", checkBox_ssl.Checked );
			if (!string.IsNullOrEmpty( textBox_cert.Text )) element.SetAttributeValue( "SslCertFile", textBox_cert.Text );
			if (!string.IsNullOrEmpty( textBox_cert_password.Text )) element.SetAttributeValue( "SslCertPwd", textBox_cert_password.Text );

		}

		public void LoadXmlParameter( XElement element )
		{
			checkBox_ssl.Checked = HslFormContent.GetXmlValue( element, "UseSsl", false, bool.Parse );
			textBox_cert.Text = HslFormContent.GetXmlValue( element, "SslCertFile", "", m => m );
			textBox_cert_password.Text = HslFormContent.GetXmlValue( element, "SslCertPwd", "", m => m );
		}
	}
}
