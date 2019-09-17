using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.BasicFramework;

namespace HslCommunicationDemo
{
    #region SoftMail

    public partial class FormMail : HslFormContent
    {
        public FormMail( )
        {
            InitializeComponent( );
        }

        private void FormMail_Load( object sender, EventArgs e )
        {
            textBox3.Text = "<html><body style=\"background-color:PowderBlue;\"><h1>Look! Styles and colors</h1><p style=\"font-family:verdana;color:red\">This text is in Verdana and red</p><p style=\"font-family:times;color:green\">This text is in Times and green</p><p style=\"font-size:30px\">This text is 30 pixels high</p></body></html> ";
            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "邮件发送测试";
                label7.Text = "发送地址：";
                label9.Text = "主题：";
                label1.Text = "内容：(字符串)";
                textBox1.Text = "测试主题";
                textBox4.Text = "测试内容";
                button3.Text = "发送";
                label8.Text = "发送地址：";
                label6.Text = "主题：";
                label3.Text = "内容：(html)";
                textBox2.Text = "测试主题";
                button1.Text = "发送";
            }
            else
            {
                Text = "Mail Send Test";
                label7.Text = "Address:";
                label9.Text = "Subject:";
                label1.Text = "String Content:";
                textBox1.Text = "Test Subject";
                textBox4.Text = "Test Content";
                button3.Text = "Send";
                label8.Text = "Address:";
                label6.Text = "Subject:";
                label3.Text = "Html Content:";
                textBox2.Text = "Test Subject";
                button1.Text = "Send";
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            // 发送普通的文本
            try
            {
                // SoftMail.MailSystem163.SendMail( "[你的邮件地址]", "[这是主题]", "[这是内容]" );
                SoftMail.MailSystem163.SendMail( textBox5.Text, textBox1.Text, textBox4.Text );
                MessageBox.Show( "发送成功！" );
            }
            catch (Exception ex)
            {
                SoftBasic.ShowExceptionMessage( ex );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            // 发送html文本
            try
            {
                // SoftMail.MailSystem163.SendMail( "[你的邮件地址]", "[这是主题]", "[上面的html内容]",true );
                SoftMail.MailSystem163.SendMail( textBox6.Text, textBox2.Text, textBox3.Text, true );
                MessageBox.Show( "发送成功！" );
            }
            catch (Exception ex)
            {
                SoftBasic.ShowExceptionMessage( ex );
            }
        }
    }


    #endregion
}
