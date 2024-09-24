using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin( )
        {
            InitializeComponent( );
        }

        private void FormLogin_Load( object sender, EventArgs e )
        {
            textBox1.Text = "admin";
            textBox2.Text = "123456";
            label3.Text = Program.SystemName;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if(textBox1.Text == "admin" && textBox2.Text == "123456")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show( "用户名或密码错误，请重新输入！" );
            }
        }
    }
}
