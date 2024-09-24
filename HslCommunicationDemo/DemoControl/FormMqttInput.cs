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

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormMqttInput : System.Windows.Forms.Form
	{
		public FormMqttInput( )
		{
			InitializeComponent( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			MqttConnectionOptions = new MqttConnectionOptions( );
			MqttConnectionOptions.IpAddress = textBox_ip.Text;
			MqttConnectionOptions.Port = int.Parse( textBox_port.Text );
			MqttConnectionOptions.ClientId = textBox_clientid.Text;
			if (!string.IsNullOrEmpty( textBox_name.Text ))
			{
				MqttConnectionOptions.Credentials = new MqttCredential( textBox_name.Text, textBox_password.Text );
			}
			ReadTopic = textBox_read_topic.Text;
			WriteTopic= textBox_write_topic.Text;
			DialogResult = DialogResult.OK;
		}

		public MqttConnectionOptions MqttConnectionOptions { get; set; }

		public string ReadTopic { get; set; }

		public string WriteTopic { get; set; }

		private void FormMqttInput_Load( object sender, EventArgs e )
		{

		}
	}
}
