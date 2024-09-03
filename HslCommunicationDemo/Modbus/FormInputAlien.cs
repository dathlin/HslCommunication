using HslCommunication;
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
			UseHslDtuServer = radioButton1.Checked;
			if (!IPAddress.TryParse( textBox_ip.Text, out IPAddress address ))
			{
				MessageBox.Show( "IP地址填写失败" );
				return;
			}

			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( "端口号填写失败！" );
				return;
			}

			IpAddress = address.ToString( );
			Port      = port;

			if (UseHslDtuServer)
			{
				DTU = textBox3.Text;
				Pwd = textBox4.Text;
				NeedAckDtuResult = checkBox_ack_result.Checked;
			}
			else
			{
				if (!string.IsNullOrEmpty(textBox1.Text))
				{
					CustomizeDTU = textBox1.Text.ToHexBytes( );
				}
			}

			DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// 获取或设置是否使用
		/// </summary>
		public bool UseHslDtuServer { get; set; } = true;

		/// <summary>
		/// IP地址
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// 端口号
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// 通知服务器是否需要返回注册结果报文
		/// </summary>
		public bool NeedAckDtuResult { get; set; }

		/// <summary>
		/// DTU的唯一ID信息
		/// </summary>
		public string DTU { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd { get; set; }

		/// <summary>
		/// 使用了自定义的注册包
		/// </summary>
		public byte[] CustomizeDTU { get; set; }

		private void FormInputAlien_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			checkBox_ack_result.Checked = true;
			if (Program.Language == 2)
			{
				label1.Text = "Ip:";
				label2.Text = "Port:";
				label3.Text = "ID:";
				label4.Text = "Pwd:";
				radioButton1.Text = "Use HSL-DTU package";
				radioButton2.Text = "Customize package";
				checkBox_ack_result.Text = "Need ack DTU result";
				label5.Text = "DTU-Msg:";
				button1.Text = "OK";
			}
			panel2.Visible = false;

		}

		private void radioButton1_CheckedChanged( object sender, EventArgs e )
		{
			// hsl注册包
			panel2.Visible = false;
		}

		private void radioButton2_CheckedChanged( object sender, EventArgs e )
		{
			panel2.Visible = true;
			panel2.BringToFront( );
		}
	}
}
