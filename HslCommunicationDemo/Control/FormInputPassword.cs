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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo.Control
{
	public partial class FormInputPassword : System.Windows.Forms.Form
	{
		public FormInputPassword( )
		{
			InitializeComponent( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox1.Text ))
			{
				MessageBox.Show( Program.Language == 1 ? "当前输入的密码不能为空! " : "The currently entered password cannot be empty! " );
				return;
			}

			if (!Regex.IsMatch( textBox1.Text, @"^[0-9A-Za-z]{4,32}$" ))
			{
				MessageBox.Show( Program.Language == 1 ? "密码只能是数字字母组成，且4~32位之间!" : "The password can only be composed of numeric letters and between 4~32 digits!" );
				return;
			}

			Password = textBox1.Text;
			DialogResult = DialogResult.OK;
		}


		/// <summary>
		/// 获取当前用户输入的密码
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 获取消息提示
		/// </summary>
		public string Tip { get => label1.Text; set => label1.Text = value; }

		private void FormInputPassword_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				label1.Text = "密码:";
				button1.Text = "确认";
				Text = "请输入密码";
			}
		}
	}
}
