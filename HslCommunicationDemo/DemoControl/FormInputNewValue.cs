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
	public partial class FormInputNewValue : System.Windows.Forms.Form
	{
		public FormInputNewValue( string old )
		{
			InitializeComponent( );
			this.oldString = old;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			//if (string.IsNullOrEmpty( textBox1.Text ))
			//{
			//	MessageBox.Show( Program.Language == 1 ? "当前输入的值不能为空! " : "The currently entered Value cannot be empty! " );
			//	return;
			//}

			InputValue = textBox1.Text;
			DialogResult = DialogResult.OK;
		}


		/// <summary>
		/// 获取当前用户输入的值信息
		/// </summary>
		public string InputValue { get; set; }

		/// <summary>
		/// 获取消息提示
		/// </summary>
		public string Tip { get => label1.Text; set => label1.Text = value; }

		private void FormInputPassword_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				//label1.Text = "密码:";
				//button1.Text = "确认";
				//Text = "请输入密码";
			}

			if (!string.IsNullOrEmpty( oldString ))
				textBox1.Text = oldString;
		}

		private string oldString = "";
	}
}
