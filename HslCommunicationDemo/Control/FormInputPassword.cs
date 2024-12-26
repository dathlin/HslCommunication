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

		/// <summary>
		/// 字符串模式 0: 密码   1: 整数信息
		/// </summary>
		public int StringMode { get; set; }

		private void button1_Click( object sender, EventArgs e )
		{
			if (StringMode == 0)
			{
				if (string.IsNullOrEmpty( textBox1.Text ))
				{
					DemoUtils.ShowMessage( Program.Language == 1 ? "当前输入的密码不能为空! " : "The currently entered password cannot be empty! " );
					return;
				}

				if (!Regex.IsMatch( textBox1.Text, @"^[0-9A-Za-z]{4,32}$" ))
				{
					DemoUtils.ShowMessage( Program.Language == 1 ? "密码只能是数字字母组成，且4~32位之间!" : "The password can only be composed of numeric letters and between 4~32 digits!" );
					return;
				}
			}
			else if (StringMode == 1)
			{
				if(!string.IsNullOrEmpty( textBox1.Text ))
				{
					try
					{
						int value = Convert.ToInt32( textBox1.Text );
					}
					catch
					{
						DemoUtils.ShowMessage( Program.Language == 1 ? "当前输入的不是数字，请重新输入数字! " : "The current input is not a number, please re-enter the number!" );
						return;
					}
				}
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
			if (StringMode == 0)
			{
				if (Program.Language == 1)
				{
					label1.Text = "密码:";
					button1.Text = "确认";
					Text = "请输入密码";
				}
			}
			else if (StringMode == 1)
			{
				if(Program.Language == 1)
				{
					label1.Text = "数量:";
					button1.Text = "确认";
					Text = "请输入数量信息，可以为空";
				}
				else
				{
					label1.Text = "Length:";
					button1.Text = "OK";
					Text = "Please enter quantity information, can be empty";
				}
				textBox1.PasswordChar = (char)0;
			}
		}
	}
}
