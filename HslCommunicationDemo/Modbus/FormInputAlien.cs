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
            if(!IPAddress.TryParse(textBox1.Text,out IPAddress address))
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

    }
}
