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
using HslCommunication.Profinet.Keyence;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormKeyenceBinary : HslFormContent
    {
        public FormKeyenceBinary( )
        {
            InitializeComponent( );
            keyence_net = new KeyenceMcNet( );
        }


        private KeyenceMcNet keyence_net = null;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Keyence Read PLC Demo";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_bool.Text = "Read Bit";
                label23.Text = "X,Y,M,L,V,B";
                button_read_short.Text = "r-short";
                button_read_ushort.Text = "r-ushort";
                button_read_int.Text = "r-int";
                button_read_uint.Text = "r-uint";
                button_read_long.Text = "r-long";
                button_read_ulong.Text = "r-ulong";
                button_read_float.Text = "r-float";
                button_read_double.Text = "r-double";
                button_read_string.Text = "r-string";
                label8.Text = "length:";
                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                label10.Text = "Address:";
                label9.Text = "Value:";
                label19.Text = "Note: The value of the string needs to be converted";
                button24.Text = "Write Bit";
                button22.Text = "w-short";
                button21.Text = "w-ushort";
                button20.Text = "w-int";
                button19.Text = "w-uint";
                button18.Text = "w-long";
                button17.Text = "w-ulong";
                button16.Text = "w-float";
                button15.Text = "w-double";
                button14.Text = "w-string";

                groupBox1.Text = "Single Data Read test";
                groupBox2.Text = "Single Data Write test";
                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";

                button3.Text = "Pressure test, r/w 3,000s";
                label24.Text = "X,Y,M,L,V,B";
                label22.Text = "M100 D100 X1A0 Y1A0";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }

        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            // 连接
            if (!System.Net.IPAddress.TryParse( textBox1.Text, out System.Net.IPAddress address ))
            {
                MessageBox.Show( DemoUtils.IpAddressInputWrong );
                return;
            }

            keyence_net.IpAddress = textBox1.Text;

            if(!int.TryParse(textBox2.Text,out int port))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            keyence_net.Port = port;

            keyence_net.ConnectClose( );

            try
            {
                OperateResult connect = keyence_net.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                    userControlCurve1.ReadWriteNet = keyence_net;
                }
                else
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed );
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
            keyence_net.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }

        
        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            DemoUtils.ReadResultRender( keyence_net.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            DemoUtils.ReadResultRender( keyence_net.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            DemoUtils.ReadResultRender( keyence_net.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            DemoUtils.ReadResultRender( keyence_net.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            DemoUtils.ReadResultRender( keyence_net.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            DemoUtils.ReadResultRender( keyence_net.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            DemoUtils.ReadResultRender( keyence_net.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            DemoUtils.ReadResultRender( keyence_net.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            DemoUtils.ReadResultRender( keyence_net.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( keyence_net.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text,new bool[] { bool.Parse( textBox7.Text ) } ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( () => keyence_net.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }

        
        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( keyence_net, textBox6, textBox9, textBox10 );
        }

        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = keyence_net.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
            if (read.IsSuccess)
            {
                textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
            }
            else
            {
                MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
            }
        }


        #endregion

        #region Use Exmaple

        private void test1()
        {
            // 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

            // if we want read M100-M109, so we can do like this
            OperateResult<bool[]> read = keyence_net.ReadBool( "M100", 10 );
            if(read.IsSuccess)
            {
                bool m100 = read.Content[0];
                // and so on
                // ...
                // then
                bool m109 = read.Content[9];
            }
            else
            {
                // failed, the follow operation is output the wrong msg
                Console.WriteLine( "Read failed: " + read.ToMessageShowString( ) );
            }
        }

        private void test2( )
        {
            // the next we want write data
            bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
            OperateResult read = keyence_net.Write( "M100", values );
            if (read.IsSuccess)
            {
                // success
            }
            else
            {
                // failed
            }
        }


        private void test3( )
        {
            // These are the underlying operations that ignore validation of success
            short d100_short = keyence_net.ReadInt16( "D100" ).Content;
            ushort d100_ushort = keyence_net.ReadUInt16( "D100" ).Content;
            int d100_int = keyence_net.ReadInt32( "D100" ).Content;
            uint d100_uint = keyence_net.ReadUInt32( "D100" ).Content;
            long d100_long = keyence_net.ReadInt64( "D100" ).Content;
            ulong d100_ulong = keyence_net.ReadUInt64( "D100" ).Content;
            float d100_float = keyence_net.ReadFloat( "D100" ).Content;
            double d100_double = keyence_net.ReadDouble( "D100" ).Content;
            // need to specify the text length
            string d100_string = keyence_net.ReadString( "D100", 10 ).Content;
        }
        private void test4( )
        {
            // These are the underlying operations that ignore validation of success
            keyence_net.Write( "D100", (short)5 );
            keyence_net.Write( "D100", (ushort)5 );
            keyence_net.Write( "D100", 5 );
            keyence_net.Write( "D100", (uint)5 );
            keyence_net.Write( "D100", (long)5 );
            keyence_net.Write( "D100", (ulong)5 );
            keyence_net.Write( "D100", 5f );
            keyence_net.Write( "D100", 5d );
            // length should Multiples of 2 
            keyence_net.Write( "D100", "12345678" );
        }


        private void test5( )
        {
            // The complex situation is that you need to parse the byte array yourself.
            // Here's just one example.
            OperateResult<byte[]> read = keyence_net.Read( "D100", 10 );
            if(read.IsSuccess)
            {
                int count = keyence_net.ByteTransform.TransInt32( read.Content, 0 );
                float temp = keyence_net.ByteTransform.TransSingle( read.Content, 4 );
                short name1 = keyence_net.ByteTransform.TransInt16( read.Content, 8 );
                string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
            }
        }

        private void test6( )
        {
            // Custom types of Read and write situations in which type usertype need to be implemented in advance.
            // 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

            OperateResult<UserType> read = keyence_net.ReadCustomer<UserType>( "D100" );
            if (read.IsSuccess)
            {
                UserType value = read.Content;
            }
            // write value
            keyence_net.WriteCustomer( "D100", new UserType( ) );

            // Sets an instance operation for the log.
            keyence_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
        }
        
        #endregion

        #region 压力测试

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;

        private void button3_Click( object sender, EventArgs e )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            button3.Enabled = false;
        }

        private void thread_test2( )
        {
            int count = 500;
            while (count > 0)
            {
                if (!keyence_net.Write( "D100", (short)1234 ).IsSuccess) failed++;
                if (!keyence_net.ReadInt16( "D100" ).IsSuccess) failed++;
                count--;
            }
            thread_end( );
        }

        private void thread_end( )
        {
            if (Interlocked.Decrement( ref thread_status ) == 0)
            {
                // Right Down
                Invoke( new Action( ( ) =>
                {
                    button3.Enabled = true;
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
                } ) );
            }
        }
        
        #endregion

        private void button4_Click( object sender, EventArgs e )
        {
            // 远程启动 -> Remote Start PLC
            OperateResult runResult = keyence_net.RemoteRun( );
            if (runResult.IsSuccess)
            {
                MessageBox.Show( "Run Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + runResult.ToMessageShowString() );
            }
        }

        private void button5_Click( object sender, EventArgs e )
        {
            // 远程停止 -> Remote Stop PLC
            OperateResult runResult = keyence_net.RemoteStop( );
            if (runResult.IsSuccess)
            {
                MessageBox.Show( "Stop Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + runResult.ToMessageShowString( ) );
            }
        }

        private void button6_Click( object sender, EventArgs e )
        {
            // 读取型号 -> Read Plc Type
            OperateResult<string> readResult = keyence_net.ReadPlcType( );
            if (readResult.IsSuccess)
            {
                MessageBox.Show( "Type:" + readResult.Content );
            }
            else
            {
                MessageBox.Show( "Failed: " + readResult.ToMessageShowString( ) );
            }
        }
    }
}
