using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Common
{
	public partial class ConnectControl : UserControl
	{
		public ConnectControl( )
		{
			InitializeComponent( );

			comboBox_connect_type.SelectedIndexChanged += ComboBox_connect_type_SelectedIndexChanged;
			if (Program.Language == 1)
			{
				comboBox_connect_type.DataSource = new string[] { "直连", "Lora", "MQTT" };
			}
			else
			{
				comboBox_connect_type.DataSource = new string[] { "Direct", "Lora", "MQTT" };
			}

			DemoUtils.SetDeviveIp( textBox_ip );
		}

		private void ComboBox_connect_type_SelectedIndexChanged( object sender, EventArgs e )
		{

		}
	}
}
