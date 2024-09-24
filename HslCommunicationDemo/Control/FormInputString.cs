using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Control
{
	public partial class FormInputString : System.Windows.Forms.Form
	{
		public FormInputString( )
		{
			InitializeComponent( );
		}

		public FormInputString( string alias )
		{
			this.DeviceAlias = alias;
		}

		private void FormInputString_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				Text = "Please enter a string";
				label1.Text= "Please enter the alias information. If \":\" is entered in the middle, it will be used as the category separator";
				button1.Text = "ok";

				label2.Text = "The password, if empty, means not encrypted and consists of fewer than 32 numbers or letters";
				label3.Text = "Please enter your password again:";
				label_tips.Text = "Tip: If the datasheet has configuration information, it will be stored together";
			}

			this.textBox1.Text = this.DeviceAlias;
		}

		public string DeviceAlias { get; set; }

		/// <summary>
		/// 当前存储的设备信息的密码
		/// </summary>
		public string Password { get; set; }

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox1.Text ))
			{
				MessageBox.Show( "Value can not be null" );
				return;
			}

			if (!string.IsNullOrEmpty( textBox2.Text ))
			{
				if (!Regex.IsMatch( textBox2.Text, @"^[0-9A-Za-z]{4,32}$" ))
				{
					MessageBox.Show( Program.Language == 1 ? "密码只能是数字字母组成，且4~32位之间!" : "The password can only be composed of numeric letters and between 4~32 digits!" );
					return;
				}

				if (textBox2.Text != textBox3.Text)
				{
					MessageBox.Show( Program.Language == 1 ? "两次密码输入不一致，请重新输入" : "The password is entered inconsistently twice, please re-enter it" );
					return;
				}
				Password = textBox2.Text;
			}
			else if (!string.IsNullOrEmpty( textBox3.Text ))
			{
				MessageBox.Show( Program.Language == 1 ? "两次密码输入不一致，请重新输入" : "The password is entered inconsistently twice, please re-enter it" );
				return;
			}


			DeviceAlias = textBox1.Text;
			DialogResult = DialogResult.OK;
		}
	}
}
