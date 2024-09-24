using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.MQTT
{
	public partial class FormWillTopicSetting : System.Windows.Forms.Form
	{
		public FormWillTopicSetting( string topic, string message )
		{
			InitializeComponent( );

			this.topic = topic;
			this.message = message;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.topic = textBox_topic.Text;
			this.message = textBox_message.Text;
			this.DialogResult = DialogResult.OK;
		}

		private string topic;
		private string message;

		private void FormWillTopicSetting_Load( object sender, EventArgs e )
		{
			textBox_topic.Text = topic;
			textBox_message.Text = message;
		}

		public string Topic => topic;

		public string Message => message;
	}
}
