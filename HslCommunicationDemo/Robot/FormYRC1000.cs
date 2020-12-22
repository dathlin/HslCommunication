using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Robot.YASKAWA;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormYRC1000 : HslFormContent
    {
        public FormYRC1000( )
        {
            InitializeComponent( );
        }


        private YRC1000TcpNet YRC1000Tcp = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "YASKAWA Robot Demo";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_string.Text = "r-string";


                label10.Text = "Address:";
                label9.Text = "Value:";

                button14.Text = "w-string";

                groupBox1.Text = "Single Data Read test";
                groupBox2.Text = "Single Data Write test";
                label22.Text = "Parameter name of robot";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
        {
            if (result.IsSuccess)
            {
                textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Read Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender( OperateResult result, string address )
        {
            if (result.IsSuccess)
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }


        #region Connect And Close



        private async void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox2.Text,out int port))
            {
                MessageBox.Show( "端口输入格式不正确！" );
                return;
            }
            
            YRC1000Tcp?.ConnectClose( );
            YRC1000Tcp = new YRC1000TcpNet( textBox1.Text, port );

            try
            {
                OperateResult connect = await YRC1000Tcp.ConnectServerAsync( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( "连接成功！" );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "连接失败！" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            YRC1000Tcp.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }







        #endregion

        #region 单数据读取测试
        

        private async void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            readResultRender( await YRC1000Tcp.ReadStringAsync( textBox3.Text ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试
        

        private async void button14_Click( object sender, EventArgs e )
        {
            // string写入
            try
            {
                writeResultRender( await YRC1000Tcp.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        #endregion


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
    
}
