using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormInputAlien : HslFormContent
	{
		public FormInputAlien( )
		{
			InitializeComponent( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if(!IPAddress.TryParse(textBox_ip.Text,out IPAddress address))
			{
				MessageBox.Show( "IP地址填写失败" );
				return;
			}

			if(!int.TryParse(textBox2.Text,out int port))
			{
				MessageBox.Show( "端口号填写失败！" );
				return;
			}

			IpAddress = address.ToString( );
			Port = port;
			DTU = textBox3.Text;
			Pwd = textBox4.Text;
			UseRegistration = checkBox1.Checked;

			DialogResult = DialogResult.OK;
		}


		/// <summary>
		/// IP地址
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// 端口号
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// DTU的唯一ID信息
		/// </summary>
		public string DTU { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd { get; set; }

		/// <summary>
		/// 是否使用注册包
		/// </summary>
		public bool UseRegistration { get; set; }

		private void FormInputAlien_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			if (Program.Language == 2)
			{
				label1.Text = "Ip:";
				label2.Text = "Port:";
				label3.Text = "ID:";
				label4.Text = "Pwd:";
				checkBox1.Text = "Use Hsl Registration package?";
			}
		}
	}
}
