using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;
using HslCommunication;
using System.Threading;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormSimplifyNet : HslFormContent
    {
        public FormSimplifyNet( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            textBox3.Text = Guid.Empty.ToString( );
            button2.Enabled = false;

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "Simplify网络客户端";
                label1.Text = "Ip地址：";
                label3.Text = "端口号：";
                button1.Text = "连接";
                button2.Text = "断开连接";
                label6.Text = "令牌：";
                button5.Text = "启动短连接";
                button6.Text = "压力测试";
                label7.Text = "指令头：";
                label8.Text = "举例：12345 或是1.1.1";
                label9.Text = "数据：";
                button3.Text = "发送";
                label10.Text = "次数：";
                label11.Text = "耗时：";
                button4.Text = "清空";
                label12.Text = "接收：";
            }
            else
            {
                Text = "Simplify Net Client Test";
                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label6.Text = "Token:";
                button5.Text = "Start a short connection";
                button6.Text = "Pressure test";
                label7.Text = "Command:";
                label8.Text = "Example: 12345 or 1.1.1";
                label9.Text = "Data:";
                button3.Text = "Send";
                label10.Text = "Times:";
                label11.Text = "Take:";
                button4.Text = "Clear";
                label12.Text = "Receive:";
            }
        }

        private NetSimplifyClient simplifyClient = new NetSimplifyClient( );

        private async void button1_Click( object sender, EventArgs e )
        {
            // 连接
            simplifyClient.IpAddress = textBox1.Text;
            simplifyClient.Port = int.Parse( textBox2.Text );
            simplifyClient.ReceiveTimeOut = int.Parse( textBox11.Text );
            simplifyClient.Token = new Guid( textBox3.Text );
            simplifyClient.SetLoginAccount( textBox9.Text, textBox10.Text );
            OperateResult connect = await simplifyClient.ConnectServerAsync( );

            if(connect.IsSuccess)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;
                button5.Enabled = false;
                MessageBox.Show( StringResources.Language.ConnectServerSuccess );
            }
            else
            {
                MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
            }
        }

        private async void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;

            await simplifyClient.ConnectCloseAsync( );
        }

        private int status = 1;
        private void button5_Click( object sender, EventArgs e )
        {
            if (status == 1)
            {
                // 启动短连接
                simplifyClient.IpAddress = textBox1.Text;
                simplifyClient.Port = int.Parse( textBox2.Text );
                simplifyClient.Token = new Guid( textBox3.Text );

                button1.Enabled = false;
                button2.Enabled = false;
                panel2.Enabled = true;
                status = 2;
                button5.Text = Program.Language == 1 ? "重新选择连接" : "Choose again";
            }
            else
            {
                status = 1;
                button1.Enabled = true;
                panel2.Enabled = false;
                button5.Text = Program.Language == 1 ? "启动短连接" : "Start a short connection";
            }
        }

        private async void button3_Click( object sender, EventArgs e )
        {
            button3.Enabled = false;
            // 数据发送
            NetHandle handle = new NetHandle( );
            if (textBox5.Text.IndexOf( '.' ) >= 0)
            {
                string[] values = textBox5.Text.Split( '.' );
                handle = new NetHandle( byte.Parse( values[0] ), byte.Parse( values[1] ), ushort.Parse( values[2] ) );
            }
            else
            {
                handle = int.Parse( textBox5.Text );
            }


            int count = int.Parse( textBox6.Text );
            DateTime start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                OperateResult<string> read = await simplifyClient.ReadFromServerAsync( handle, textBox4.Text );
                if (read.IsSuccess)
                {
                    textBox8.AppendText( read.Content + Environment.NewLine );
                }
                else
                {
                    MessageBox.Show( Program.Language == 1 ? "读取失败：" : "Read Failed:" + read.ToMessageShowString( ) );
                }
            }

            textBox7.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );

            button3.Enabled = true;
        }

        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox8.Clear( );
        }

        private async void Button7_Click( object sender, EventArgs e )
        {
            // 数据发送
            NetHandle handle = new NetHandle( );
            if (textBox5.Text.IndexOf( '.' ) >= 0)
            {
                string[] values = textBox5.Text.Split( '.' );
                handle = new NetHandle( byte.Parse( values[0] ), byte.Parse( values[1] ), ushort.Parse( values[2] ) );
            }
            else
            {
                handle = int.Parse( textBox5.Text );
            }


            int count = int.Parse( textBox6.Text );
            DateTime start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                OperateResult<NetHandle,string[]> read = await simplifyClient.ReadCustomerFromServerAsync( handle, textBox4.Text.Split(new char[] { ';' } ) );
                if (read.IsSuccess)
                {
                    textBox8.Lines = read.Content2;
                }
                else
                {
                    MessageBox.Show( Program.Language == 1 ? "读取失败：" : "Read Failed:" + read.ToMessageShowString( ) );
                }
            }

            textBox7.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );
        }

        private void button6_Click( object sender, EventArgs e )
        {
            PressureTest2( );
        }

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        // 压力测试，开3个线程，每个线程进行读写操作，看使用时间
        private void PressureTest2( )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            button3.Enabled = false;
        }

        private async void thread_test2( )
        {
            int count = 1000;
            while (count > 0)
            {
                if (!(await simplifyClient.ReadCustomerFromServerAsync( 1, "" )).IsSuccess) failed++;
                count--;
            }
            thread_end( );
        }

        private void thread_end( )
        {
            if (Interlocked.Decrement( ref thread_status ) == 0)
            {
                // 执行完成
                Invoke( new Action( ( ) =>
                {
                    button3.Enabled = true;
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Read Failed：" + failed );
                } ) );
            }
        }


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlTimeout, textBox11.Text );
            element.SetAttributeValue( DemoDeviceList.XmlToken, textBox3.Text );
            element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox9.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox10.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox11.Text = element.Attribute( DemoDeviceList.XmlTimeout ).Value;
            textBox3.Text = element.Attribute( DemoDeviceList.XmlToken ).Value;
            textBox9.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
            textBox10.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }


    #endregion
}
