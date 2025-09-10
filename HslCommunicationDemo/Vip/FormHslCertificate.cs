using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Vip
{
	public partial class FormHslCertificate : Form
	{
		public FormHslCertificate( MqttSyncClient rpc, CertificateItem item )
		{
			InitializeComponent( );

			this.hslCertificateControl1.SetRpcClient(rpc);
			this.hslCertificateControl1.RenderHslCertificate( item );
		}

		public void RenderHslCertificate( CertificateItem cert )
		{
			this.hslCertificateControl1.RenderHslCertificate( cert );
		}


	}
}
