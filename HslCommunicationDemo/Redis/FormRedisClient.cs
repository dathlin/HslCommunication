using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet.Redis;
using HslCommunication;

namespace HslCommunicationDemo
{
    #region FormSimplifyNet


    public partial class FormRedisClient : HslFormContent
    {
        public FormRedisClient( )
        {
            InitializeComponent( );
        }

        private void FormClient_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            button2.Enabled = false;

            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "Redis网络客户端";
                label1.Text = "Ip地址：";
                label3.Text = "端口号：";
                button1.Text = "连接";
                button2.Text = "断开连接";
                label6.Text = "密码：";
                button5.Text = "启动短连接";
                button6.Text = "压力测试";
                label7.Text = "指令头：";
                label8.Text = "耗时";
                label9.Text = "数据：";
                button3.Text = "写入";
                label10.Text = "次数：";
                label11.Text = "耗时：";
                button4.Text = "读取";
                label12.Text = "接收：";
            }
            else
            {
                Text = "Redis Client Test";
                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label6.Text = "Password:";
                button5.Text = "Start a short connection";
                button6.Text = "Pressure test";
                label7.Text = "Command:";
                label8.Text = "Take:";
                label9.Text = "Data:";
                button3.Text = "Write";
                label10.Text = "Times:";
                label11.Text = "Take:";
                button4.Text = "Read";
                label12.Text = "Receive:";
            }
        }

        private RedisClient redisClient = new RedisClient( "" );

        private void button1_Click( object sender, EventArgs e )
        {
            // 连接
            redisClient = new RedisClient( textBox3.Text );
            redisClient.IpAddress = textBox1.Text;
            redisClient.Port = int.Parse( textBox2.Text );
            OperateResult connect = redisClient.ConnectServer( );

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

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;

            redisClient.ConnectClose( );
        }

        private int status = 1;
        private void button5_Click( object sender, EventArgs e )
        {
            if (status == 1)
            {
                // 启动短连接
                redisClient.IpAddress = textBox1.Text;
                redisClient.Port = int.Parse( textBox2.Text );

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

        private void button3_Click( object sender, EventArgs e )
        {
            // 写入关键字
            DateTime start = DateTime.Now;
            int count = int.Parse( textBox6.Text );
            for (int i = 0; i < count; i++)
            {
                OperateResult write = redisClient.WriteKey( textBox5.Text, textBox4.Text );
                if (write.IsSuccess)
                {
                    textBox7.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );
                    MessageBox.Show( "success" );
                }
                else
                {
                    textBox7.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );
                    MessageBox.Show( Program.Language == 1 ? "写入失败：" : "Write Failed:" + write.ToMessageShowString( ) );
                }

            }
            
        }

        private void button4_Click( object sender, EventArgs e )
        {
            // 清空
            textBox8.Clear( );
        }

        private void button4_Click_1( object sender, EventArgs e )
        {
            // 读关键字
            DateTime start = DateTime.Now;
            int count = int.Parse( textBox9.Text );
            for (int i = 0; i < count; i++)
            {
                OperateResult<string> read = redisClient.ReadKey( textBox11.Text);
                if (read.IsSuccess)
                {
                    textBox10.Text = read.Content;
                }
                else
                {
                    textBox10.Text = Program.Language == 1 ? "读取失败：" + read.Message : "Read Failed:" + read.Message;
                }

            }
            textBox8.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );
        }

        private void button8_Click( object sender, EventArgs e )
        {
            //OperateResult<string[]> read2 = redisClient.ReadHashKey( "A", new string[] { "123", "456", "789" } );

            //return;
            // 读关键字
            DateTime start = DateTime.Now;
            int count = int.Parse( textBox9.Text );
            for (int i = 0; i < count; i++)
            {
                OperateResult<string> read = redisClient.ReadCustomer( textBox11.Text );
                if (read.IsSuccess)
                {
                    textBox10.Text = read.Content;
                }
                else
                {
                    textBox10.Text = Program.Language == 1 ? "读取失败：" + read.Message : "Read Failed:" + read.Message;
                }

            }
            textBox8.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F2" );
        }


        private Random random = new Random( );
        private void button9_Click( object sender, EventArgs e )
        {
            OperateResult result = redisClient.ListLeftPush( "B", random.Next( 1000 ).ToString( ));
            if (result.IsSuccess)
            {
                MessageBox.Show( "成功" );
            }
            else
            {
                MessageBox.Show( result.Message );
            }
        }

        private void button10_Click( object sender, EventArgs e )
        {
            OperateResult result = redisClient.ListTrim( "B", 0, 2 );
            if (result.IsSuccess)
            {
                MessageBox.Show( "成功" );
            }
            else
            {
                MessageBox.Show( result.Message );
            }
        }

        private void button11_Click( object sender, EventArgs e )
        {
            OperateResult<int> result = redisClient.GetListLength( "B" );
            if (result.IsSuccess)
            {
                MessageBox.Show( "成功：" + result.Content );
            }
            else
            {
                MessageBox.Show( result.Message );
            }
        }

        private void button12_Click( object sender, EventArgs e )
        {
            OperateResult write = redisClient.Publish( textBox5.Text, textBox4.Text );
            if (write.IsSuccess)
            {
                MessageBox.Show( "success" );
            }
            else
            {
                MessageBox.Show( Program.Language == 1 ? "写入失败：" : "Write Failed:" + write.ToMessageShowString( ) );
            }
        }
    }


    #endregion
}
