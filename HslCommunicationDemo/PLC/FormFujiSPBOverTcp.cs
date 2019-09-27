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
using HslCommunication.Profinet.Fuji;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormFujiSPBOverTcp : HslFormContent
    {
        public FormFujiSPBOverTcp( )
        {
            InitializeComponent( );
            fujiSPB = new FujiSPBOverTcp( );
        }


        private FujiSPBOverTcp fujiSPB = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Fuji Read PLC Demo";

                label27.Text = "Ip:";
                label26.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

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

                label24.Text = "X,Y,M,L,V,B";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        

        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if (!System.Net.IPAddress.TryParse( textBox1.Text, out System.Net.IPAddress address ))
            {
                MessageBox.Show( DemoUtils.IpAddressInputWrong );
                return;
            }

            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }



            fujiSPB?.ConnectClose( );
            fujiSPB = new FujiSPBOverTcp( );
            fujiSPB.IpAddress = textBox1.Text;
            fujiSPB.Port = port;

            try
            {
                fujiSPB.Station = byte.Parse( textBox15.Text );
                OperateResult connect = fujiSPB.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );

                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;

                    userControlCurve1.ReadWriteNet = fujiSPB;
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
            fujiSPB.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }



        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            //DemoUtils.ReadResultRender( fatekProgram.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadInt16( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt16( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadInt32( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt32( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadInt64( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadUInt64( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadFloat( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox12.Text == "1")
                DemoUtils.ReadResultRender( fujiSPB.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( fujiSPB.ReadDouble( textBox3.Text, ushort.Parse( textBox12.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( fujiSPB.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            //DemoUtils.WriteResultRender( ( ) => fatekProgram.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( () => fujiSPB.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }
        

        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( fujiSPB, textBox6, textBox9, textBox10 );
        }



        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = fujiSPB.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

        private void test3( )
        {
            short d100_short = fujiSPB.ReadInt16( "D100" ).Content;
            ushort d100_ushort = fujiSPB.ReadUInt16( "D100" ).Content;
            int d100_int = fujiSPB.ReadInt32( "D100" ).Content;
            uint d100_uint = fujiSPB.ReadUInt32( "D100" ).Content;
            long d100_long = fujiSPB.ReadInt64( "D100" ).Content;
            ulong d100_ulong = fujiSPB.ReadUInt64( "D100" ).Content;
            float d100_float = fujiSPB.ReadFloat( "D100" ).Content;
            double d100_double = fujiSPB.ReadDouble( "D100" ).Content;
            // need to specify the text length
            string d100_string = fujiSPB.ReadString( "D100", 10 ).Content;
        }
        private void test4( )
        {
            fujiSPB.Write( "D100", (short)5 );
            fujiSPB.Write( "D100", (ushort)5 );
            fujiSPB.Write( "D100", 5 );
            fujiSPB.Write( "D100", (uint)5 );
            fujiSPB.Write( "D100", (long)5 );
            fujiSPB.Write( "D100", (ulong)5 );
            fujiSPB.Write( "D100", 5f );
            fujiSPB.Write( "D100", 5d );
            // length should Multiples of 2 
            fujiSPB.Write( "D100", "12345678" );
        }


        private void test5( )
        {
            OperateResult<byte[]> read = fujiSPB.Read( "D100", 10 );
            if(read.IsSuccess)
            {
                int count = fujiSPB.ByteTransform.TransInt32( read.Content, 0 );
                float temp = fujiSPB.ByteTransform.TransSingle( read.Content, 4 );
                short name1 = fujiSPB.ByteTransform.TransInt16( read.Content, 8 );
                string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
            }
        }

        private void test6( )
        {
            OperateResult<UserType> read = fujiSPB.ReadCustomer<UserType>( "D100" );
            if (read.IsSuccess)
            {
                UserType value = read.Content;
            }
            // write value
            fujiSPB.WriteCustomer( "D100", new UserType( ) );

            fujiSPB.LogNet = new HslCommunication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );

        }


        #endregion

    }
}
