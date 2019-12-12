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
using HslCommunication.Profinet.Beckhoff;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormBeckpffAdsNet : HslFormContent
    {
        public FormBeckpffAdsNet( )
        {
            InitializeComponent( );
        }


        private BeckhoffAdsNet adsNet = null;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Beckoff AdsNet Read PLC Demo";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_bool.Text = "Read Bit";
                button_read_byte.Text = "r-byte";
                button_read_short.Text = "r-short";
                button_read_ushort.Text = "r-ushort";
                button_read_int.Text = "r-int";
                button_read_uint.Text = "r-uint";
                button_read_long.Text = "r-long";
                button_read_ulong.Text = "r-ulong";
                button_read_float.Text = "r-float";
                button_read_double.Text = "r-double";
                button_read_string.Text = "r-string";
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

                button23.Text = "w-byte";
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

            if(!int.TryParse(textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            adsNet?.ConnectClose( );
            adsNet = new BeckhoffAdsNet( textBox1.Text, port );
            try
            {
                adsNet.SetTargetAMSNetId( textBox14.Text );
                OperateResult connect = adsNet.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                    userControlCurve1.ReadWriteNet = adsNet;
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
            adsNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 单数据读取测试

        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            DemoUtils.ReadResultRender( adsNet.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_byte_Click( object sender, EventArgs e )
        {
            // 读取byte变量
            DemoUtils.ReadResultRender( adsNet.ReadByte( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if(textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadFloat( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox5.Text == "1")
                DemoUtils.ReadResultRender( adsNet.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( adsNet.ReadDouble( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( adsNet.ReadString( textBox3.Text, ushort.Parse(textBox12.Text) ), textBox3.Text, textBox4 );
        }

        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button23_Click( object sender, EventArgs e )
        {
            // byte写入
            //byte[] buffer = new byte[500];
            //for (int i = 0; i < 500; i++)
            //{
            //    buffer[i] = (byte)i;
            //}
            //writeResultRender( siemensTcpNet.Write( textBox8.Text, buffer ), textBox8.Text );
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, byte.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( () => adsNet.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }



        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( adsNet, textBox6, textBox9, textBox10 );
        }




        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = adsNet.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

        #region 测试功能代码


        private void Test1( )
        {
            OperateResult<bool> read = adsNet.ReadBool( "M100.4" );
            if (read.IsSuccess)
            {
                bool m100_4 = read.Content;
            }
            else
            {
                // failed
                string err = read.Message;
            }

            OperateResult write = adsNet.Write( "M100.4", true );
            if (write.IsSuccess)
            {
                // success
            }
            else
            {
                // failed
                string err = write.Message;
            }
        }

        private void Test2( )
        {
            byte m100_byte = adsNet.ReadByte( "M100" ).Content;
            short m100_short = adsNet.ReadInt16( "M100" ).Content;
            ushort m100_ushort = adsNet.ReadUInt16( "M100" ).Content;
            int m100_int = adsNet.ReadInt32( "M100" ).Content;
            uint m100_uint = adsNet.ReadUInt32( "M100" ).Content;
            float m100_float = adsNet.ReadFloat( "M100" ).Content;
            double m100_double = adsNet.ReadDouble( "M100" ).Content;
            string m100_string = adsNet.ReadString( "M100", 10 ).Content;

            HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );

        }

        private void Test3()
        {
            // 读取操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            bool M100_7 = adsNet.ReadBool( "M100.7" ).Content;  // 读取M100.7是否通断，注意M100.0等同于M100
            byte byte_M100 = adsNet.ReadByte( "M100" ).Content; // 读取M100的值
            short short_M100 = adsNet.ReadInt16( "M100" ).Content; // 读取M100-M101组成的字
            ushort ushort_M100 = adsNet.ReadUInt16( "M100" ).Content; // 读取M100-M101组成的无符号的值
            int int_M100 = adsNet.ReadInt32( "M100" ).Content;         // 读取M100-M103组成的有符号的数据
            uint uint_M100 = adsNet.ReadUInt32( "M100" ).Content;      // 读取M100-M103组成的无符号的值
            float float_M100 = adsNet.ReadFloat( "M100" ).Content;   // 读取M100-M103组成的单精度值
            long long_M100 = adsNet.ReadInt64( "M100" ).Content;      // 读取M100-M107组成的大数据值
            ulong ulong_M100 = adsNet.ReadUInt64( "M100" ).Content;   // 读取M100-M107组成的无符号大数据
            double double_M100 = adsNet.ReadDouble( "M100" ).Content; // 读取M100-M107组成的双精度值
            string str_M100 = adsNet.ReadString( "M100", 10 ).Content;// 读取M100-M109组成的ASCII字符串数据

            // 写入操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            adsNet.Write( "M100.7", true );                // 写位，注意M100.0等同于M100
            adsNet.Write( "M100", (byte)0x33 );            // 写单个字节
            adsNet.Write( "M100", (short)12345 );          // 写双字节有符号
            adsNet.Write( "M100", (ushort)45678 );         // 写双字节无符号
            adsNet.Write( "M100", 123456789 );             // 写双字有符号
            adsNet.Write( "M100", (uint)3456789123 );      // 写双字无符号
            adsNet.Write( "M100", 123.456f );              // 写单精度
            adsNet.Write( "M100", 1234556434534545L );     // 写大整数有符号
            adsNet.Write( "M100", 523434234234343UL );     // 写大整数无符号
            adsNet.Write( "M100", 123.456d );              // 写双精度
            adsNet.Write( "M100", "K123456789" );// 写ASCII字符串

            OperateResult<byte[]> read = adsNet.Read( "M100", 10 );
            {
                if(read.IsSuccess)
                {
                    byte m100 = read.Content[0];
                    byte m101 = read.Content[1];
                    byte m102 = read.Content[2];
                    byte m103 = read.Content[3];
                    byte m104 = read.Content[4];
                    byte m105 = read.Content[5];
                    byte m106 = read.Content[6];
                    byte m107 = read.Content[7];
                    byte m108 = read.Content[8];
                    byte m109 = read.Content[9];
                }
                else
                {
                    // 发生了异常
                }
            }
        }

        #endregion



    }
}
