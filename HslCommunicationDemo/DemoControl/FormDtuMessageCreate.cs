﻿using HslCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormDtuMessageCreate : System.Windows.Forms.Form
	{
		public FormDtuMessageCreate( )
		{
			InitializeComponent( );
		}

		public void SetDtuId( string id, string pwd )
		{
			textBox_id.Text = id;
			textBox_password.Text = pwd;
		}


		private void FormDtuMessageCreate_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				// 英文
				Text = "DTU Message Create";
				label1.Text = "Unique ID:";
				label2.Text = "(Up to 11 chars)";
				label3.Text = "Pwd:";
				label4.Text = "(6 chars)";
				button1.Text = "Calculate DTU package";
				checkBox1.Text = "Return the DTU result";

				checkBox2.Text = "Length use ASCII";
				label7.Text = "Format:";
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty(textBox_id.Text))
			{
				DemoUtils.ShowMessage( "Unique ID can't be null" );
				return;
			}

			if (!Regex.IsMatch( textBox_id.Text, "^[0-9]{1,11}$" ))
			{
				DemoUtils.ShowMessage( "Unique IDs can only be between 1 and 11 characters" );
				return;
			}

			if (!Regex.IsMatch( textBox_password.Text, "^[\\S]{6}$" ))
			{
				DemoUtils.ShowMessage( "The password needs 6 characters" );
				return;
			}


			byte[] buffer = new byte[30];
			buffer[0] = (byte)'H';
			buffer[1] = (byte)'S';
			buffer[2] = (byte)'L';
			if (checkBox2.Checked)
			{
				buffer[3] = 0x31;
				buffer[4] = 0x39;
			}
			else
			{
				buffer[4] = 0x19;
			}
			Encoding.ASCII.GetBytes( textBox_id.Text ).CopyTo( buffer, 5 );
			Encoding.ASCII.GetBytes( textBox_password.Text ).CopyTo( buffer, 16 );

			if (!string.IsNullOrEmpty( textBox_ip_address.Text ))
			{
				try
				{
					IPAddress iPAddress = IPAddress.Parse( textBox_ip_address.Text );
					iPAddress.GetAddressBytes( ).CopyTo( buffer, 22 );
				}
				catch( Exception ex )
				{
					DemoUtils.ShowMessage( "Ip Address input wrong: " + ex.Message );
					return;
				}
			}

			if (!string.IsNullOrEmpty( textBox_ip_port.Text ))
			{
				if (ushort.TryParse(textBox_ip_port.Text, out ushort port))
				{
					buffer[26] = BitConverter.GetBytes( port )[0];
					buffer[27] = BitConverter.GetBytes( port )[1];
				}
				else
				{
					DemoUtils.ShowMessage( "Port input wrong " );
					return;
				}
			}
			if (!checkBox1.Checked)
			{
				// 没选中，不需要返回结果，状态值给1
				buffer[28] = 0x01;
			}

			if (radioButton1.Checked)
				textBox5.Text = buffer.ToHexString( );
			else
			{
				buffer[3] = 0x31;
				buffer[4] = 0x39;

				for (int i = 0; i < 11; i++)
				{
					if (buffer[i + 5] == 0x00)
						buffer[i + 5] = 0x20;
				}
				for (int i = 22; i < 28; i++)
				{
					buffer[i] = 0x30;
				}

				if (buffer[28] == 0x00) buffer[28] = 0x30;
				else buffer[28] = 0x31;

				buffer[29] = 0x30;
				textBox5.Text = Encoding.ASCII.GetString( buffer );
			}
		}
	}
}
