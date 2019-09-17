using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.ABB;
using HslCommunication;

namespace HslCommunicationDemo.Robot
{
    public partial class FormABBWebApi : HslFormContent
    {
        public FormABBWebApi( )
        {
            InitializeComponent( );
        }

        private ABBWebApiClient webApiClient;

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                webApiClient = new ABBWebApiClient( textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text );
                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Input Data is wrong! please int again!" + Environment.NewLine + ex.Message );
            }
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            if(comboBox1.SelectedIndex == 0)
            {
                OperateResult<string> read = webApiClient.ReadString( textBox5.Text );
                if (read.IsSuccess)
                {
                    textBox6.Text = read.Content;
                    webBrowser1.DocumentText = read.Content;
                }
                else
                {
                    MessageBox.Show( "Read Failed:" + read.Message );
                }
            }
            else
            {
                OperateResult write = webApiClient.Write( textBox5.Text, textBox7.Text );
                if (write.IsSuccess)
                {
                    MessageBox.Show( "Write Success" );
                }
                else
                {
                    MessageBox.Show( "Read Failed:" + write.Message );
                }
            }
        }

        private void FormABBWebApi_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
        }

        private void RadioButton2_CheckedChanged( object sender, EventArgs e )
        {
            if (radioButton2.Checked)
            {
                textBox6.Visible = false;
                webBrowser1.Visible = true;
            }
        }

        private void RadioButton1_CheckedChanged( object sender, EventArgs e )
        {
            if (radioButton1.Checked)
            {
                textBox6.Visible = true;
                webBrowser1.Visible = false;
            }
        }

        private void Button3_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetErrorState( );
            if(!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button4_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetJointTarget( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button5_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetSpeedRatio( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button6_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetOperationMode( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button7_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetCtrlState( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button8_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetIOIn( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button9_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetIOOut( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button11_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetIO2In( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button10_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetIO2Out( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }

        private void Button12_Click( object sender, EventArgs e )
        {
            OperateResult<string> read = webApiClient.GetLog( );
            if (!read.IsSuccess)
            {
                MessageBox.Show( "Read Failed:" + read.Message );
            }
            else
            {
                textBox6.Text = read.Content;
            }
        }
    }
}
