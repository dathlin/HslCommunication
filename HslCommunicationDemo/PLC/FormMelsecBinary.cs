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
using HslCommunication.Profinet.Melsec;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormMelsecBinary : HslFormContent
    {
        public FormMelsecBinary()
        {
            InitializeComponent( );
            melsec_net = new MelsecMcNet( );
        }


        private MelsecMcNet melsec_net = null;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Melsec Read PLC Demo";

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

            melsec_net.IpAddress = textBox1.Text;

            if(!int.TryParse(textBox2.Text,out int port))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            melsec_net.Port = port;

            melsec_net.ConnectClose( );

            try
            {
                OperateResult connect = melsec_net.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                    userControlCurve1.ReadWriteNet = melsec_net;
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
            melsec_net.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }







        #endregion

        #region 单数据读取测试



        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadBool( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadInt16( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadUInt16( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadInt32( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadUInt32( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadInt64( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadUInt64( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadFloat( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( melsec_net.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( melsec_net.ReadDouble( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( melsec_net.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, new bool[] { bool.Parse( textBox7.Text ) } ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( () => melsec_net.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }




        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( melsec_net, textBox6, textBox9, textBox10 );
        }



        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = melsec_net.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
        
        #region 测试使用

        private void test1()
        {
            OperateResult<bool[]> read = melsec_net.ReadBool( "M100", 10 );
            if(read.IsSuccess)
            {
                bool m100 = read.Content[0];
                // and so on
                bool m109 = read.Content[9];
            }
            else
            {
                // failed
            }
        }

        private void test2( )
        {
            bool[] values = new bool[] { true, false, true, true, false, true, false, true, true, false };
            OperateResult read = melsec_net.Write( "M100", values );
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
            short d100_short = melsec_net.ReadInt16( "D100" ).Content;
            ushort d100_ushort = melsec_net.ReadUInt16( "D100" ).Content;
            int d100_int = melsec_net.ReadInt32( "D100" ).Content;
            uint d100_uint = melsec_net.ReadUInt32( "D100" ).Content;
            long d100_long = melsec_net.ReadInt64( "D100" ).Content;
            ulong d100_ulong = melsec_net.ReadUInt64( "D100" ).Content;
            float d100_float = melsec_net.ReadFloat( "D100" ).Content;
            double d100_double = melsec_net.ReadDouble( "D100" ).Content;
            // need to specify the text length
            string d100_string = melsec_net.ReadString( "D100", 10 ).Content;
        }
        private void test4( )
        {
            melsec_net.Write( "D100", (short)5 );
            melsec_net.Write( "D100", (ushort)5 );
            melsec_net.Write( "D100", 5 );
            melsec_net.Write( "D100", (uint)5 );
            melsec_net.Write( "D100", (long)5 );
            melsec_net.Write( "D100", (ulong)5 );
            melsec_net.Write( "D100", 5f );
            melsec_net.Write( "D100", 5d );
            // length should Multiples of 2 
            melsec_net.Write( "D100", "12345678" );
        }


        private void test5( )
        {
            OperateResult<byte[]> read = melsec_net.Read( "D100", 10 );
            if(read.IsSuccess)
            {
                int count = melsec_net.ByteTransform.TransInt32( read.Content, 0 );
                float temp = melsec_net.ByteTransform.TransSingle( read.Content, 4 );
                short name1 = melsec_net.ByteTransform.TransInt16( read.Content, 8 );
                string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
            }
        }

        private void test6( )
        {
            OperateResult<UserType> read = melsec_net.ReadCustomer<UserType>( "D100" );
            if (read.IsSuccess)
            {
                UserType value = read.Content;
            }
            // write value
            melsec_net.WriteCustomer( "D100", new UserType( ) );

            melsec_net.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

        }

        // private MelsecMcAsciiNet melsec_ascii_net = null;

        #endregion

        #region 压力测试

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        // 压力测试，开3个线程，每个线程进行读写操作，看使用时间
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
                if (!melsec_net.Write( "D100", (short)1234 ).IsSuccess) failed++;
                if (!melsec_net.ReadInt16( "D100" ).IsSuccess) failed++;
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
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
                } ) );
            }
        }




        #endregion

        private void button4_Click( object sender, EventArgs e )
        {
            // 远程启动
            OperateResult runResult = melsec_net.RemoteRun( );
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
            // 远程停止
            OperateResult runResult = melsec_net.RemoteStop( );
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
            // 读取型号
            OperateResult<string> readResult = melsec_net.ReadPlcType( );
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

    public class UserType : HslCommunication.IDataTransfer
    {
        #region IDataTransfer

        private HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.RegularByteTransform();


        public ushort ReadCount => 10;

        public void ParseSource( byte[] Content )
        {
            int count = ByteTransform.TransInt32( Content, 0 );
            float temp = ByteTransform.TransSingle( Content, 4 );
            short name1 = ByteTransform.TransInt16( Content, 8 );
            string barcode = Encoding.ASCII.GetString( Content, 10, 10 );
        }

        public byte[] ToSource( )
        {
            byte[] buffer = new byte[20];
            ByteTransform.TransByte( count ).CopyTo( buffer, 0 );
            ByteTransform.TransByte( temp ).CopyTo( buffer, 4 );
            ByteTransform.TransByte( name1 ).CopyTo( buffer, 8 );
            Encoding.ASCII.GetBytes( barcode ).CopyTo( buffer, 10 );
            return buffer;
        }


        #endregion


        #region Public Data

        public int count { get; set; }

        public float temp { get; set; }

        public short name1 { get; set; }

        public string barcode { get; set; }

        #endregion
    }
}
