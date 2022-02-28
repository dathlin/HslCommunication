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
using HslCommunication.Profinet.Siemens;
using HslCommunication;
using System.IO.Ports;

namespace HslCommunicationDemo
{
    public partial class FormSiemensMPI : HslFormContent
    {
        public FormSiemensMPI( )
        {
            InitializeComponent( );
            siemensMPI = new SiemensMPI( );
        }


        private SiemensMPI siemensMPI = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );
            comboBox3.DataSource = SerialPort.GetPortNames( );
            try
            {
                comboBox3.SelectedIndex = 0;
            }
            catch
            {
                comboBox3.Text = "COM3";
            }
            comboBox1.SelectedIndex = 2;
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Siemens Read PLC Demo";


                label1.Text = "parity:";
                label3.Text = "Stop bits";
                label27.Text = "Com:";
                label26.Text = "BaudRate";
                label25.Text = "Data bits";
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
                label8.Text = "length:";
                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";

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

                button23.Text = "w-byte";
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        
        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int baudRate ))
            {
                MessageBox.Show( DemoUtils.BaudRateInputWrong );
                return;
            }

            if (!int.TryParse( textBox16.Text, out int dataBits ))
            {
                MessageBox.Show( DemoUtils.DataBitsInputWrong );
                return;
            }

            if (!int.TryParse( textBox17.Text, out int stopBits ))
            {
                MessageBox.Show( DemoUtils.StopBitInputWrong );
                return;
            }


            siemensMPI?.Close( );
            siemensMPI = new SiemensMPI( );

            try
            {
                siemensMPI.SerialPortInni( sp =>
                {
                    sp.PortName = comboBox3.Text;
                    sp.BaudRate = baudRate;
                    sp.DataBits = dataBits;
                    sp.StopBits = stopBits == 0 ? StopBits.None : (stopBits == 1 ? StopBits.One : StopBits.Two);
                    sp.Parity = comboBox1.SelectedIndex == 0 ? Parity.None : (comboBox1.SelectedIndex == 1 ? Parity.Odd : Parity.Even);
                } );
                siemensMPI.Open( );
                siemensMPI.Station = byte.Parse( textBox15.Text );

                if (checkBox1.Checked)
                {
                    OperateResult hand = siemensMPI.Handle( );
                    if (!hand.IsSuccess)
                    {
                        MessageBox.Show( "Hand Failed:" + hand.Message );
                        return;
                    }
                }

                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlCurve1.ReadWriteNet = siemensMPI;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            siemensMPI.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        

        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // Clipboard.SetText( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( SiemensPPI.BuildReadCommand( 2, textBox3.Text, 1, true ).Content, ' ' ) );
            // 读取bool变量
            if(textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadBool( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_byte_Click( object sender, EventArgs e )
        {
            // 读取byte变量
                DemoUtils.ReadResultRender( siemensMPI.ReadByte( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadInt16( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt16( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadInt32( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt32( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadInt64( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadUInt64( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadFloat( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox1.Text == "1")
                DemoUtils.ReadResultRender( siemensMPI.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( siemensMPI.ReadDouble( textBox3.Text, ushort.Parse( textBox1.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( siemensMPI.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            //MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( SiemensPPI.BuildWriteCommand( siemensPPI.Station, textBox8.Text, new byte[] { 1 } ).Content, ' ' ) );
            //return;
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button23_Click( object sender, EventArgs e )
        {
            // byte写入
            try
            {
                //byte[] buffer = new byte[500];
                //for (int i = 0; i < 500; i++)
                //{
                //    buffer[i] = (byte)i;
                //}
                //writeResultRender( siemensTcpNet.Write( textBox8.Text, buffer ), textBox8.Text );
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, byte.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // Clipboard.SetText( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( SiemensPPI.BuildWriteCommand( 2, textBox8.Text, new byte[] { 0x12, 0x34 } ).Content, ' ' ) );

            // short写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            try
            {
                DemoUtils.WriteResultRender( siemensMPI.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        
        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( siemensMPI, textBox6, textBox9, textBox10 );
        }

        

        #endregion

        #region 报文读取测试

        


        #endregion

        #region 测试功能代码


        private void Test1( )
        {
            OperateResult<bool> read = siemensMPI.ReadBool( "M100.4" );
            if (read.IsSuccess)
            {
                bool m100_4 = read.Content;
            }
            else
            {
                // failed
                string err = read.Message;
            }

            OperateResult write = siemensMPI.Write( "M100.4", true );
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
            byte m100_byte = siemensMPI.ReadByte( "M100" ).Content;
            short m100_short = siemensMPI.ReadInt16( "M100" ).Content;
            ushort m100_ushort = siemensMPI.ReadUInt16( "M100" ).Content;
            int m100_int = siemensMPI.ReadInt32( "M100" ).Content;
            uint m100_uint = siemensMPI.ReadUInt32( "M100" ).Content;
            float m100_float = siemensMPI.ReadFloat( "M100" ).Content;
            double m100_double = siemensMPI.ReadDouble( "M100" ).Content;
            string m100_string = siemensMPI.ReadString( "M100", 10 ).Content;

            HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );

        }

        private void Test3()
        {
            // 读取操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            bool M100_7 = siemensMPI.ReadBool( "M100.7" ).Content;  // 读取M100.7是否通断，注意M100.0等同于M100
            byte byte_M100 = siemensMPI.ReadByte( "M100" ).Content; // 读取M100的值
            short short_M100 = siemensMPI.ReadInt16( "M100" ).Content; // 读取M100-M101组成的字
            ushort ushort_M100 = siemensMPI.ReadUInt16( "M100" ).Content; // 读取M100-M101组成的无符号的值
            int int_M100 = siemensMPI.ReadInt32( "M100" ).Content;         // 读取M100-M103组成的有符号的数据
            uint uint_M100 = siemensMPI.ReadUInt32( "M100" ).Content;      // 读取M100-M103组成的无符号的值
            float float_M100 = siemensMPI.ReadFloat( "M100" ).Content;   // 读取M100-M103组成的单精度值
            long long_M100 = siemensMPI.ReadInt64( "M100" ).Content;      // 读取M100-M107组成的大数据值
            ulong ulong_M100 = siemensMPI.ReadUInt64( "M100" ).Content;   // 读取M100-M107组成的无符号大数据
            double double_M100 = siemensMPI.ReadDouble( "M100" ).Content; // 读取M100-M107组成的双精度值
            string str_M100 = siemensMPI.ReadString( "M100", 10 ).Content;// 读取M100-M109组成的ASCII字符串数据

            // 写入操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            siemensMPI.Write( "M100.7", true );                // 写位，注意M100.0等同于M100
			siemensMPI.Write( "M100", (short)(byte)0x33 );            // 写单个字节
            siemensMPI.Write( "M100", (short)12345 );          // 写双字节有符号
            siemensMPI.Write( "M100", (ushort)45678 );         // 写双字节无符号
            siemensMPI.Write( "M100", 123456789 );             // 写双字有符号
            siemensMPI.Write( "M100", (uint)3456789123 );      // 写双字无符号
            siemensMPI.Write( "M100", 123.456f );              // 写单精度
            siemensMPI.Write( "M100", 1234556434534545L );     // 写大整数有符号
            siemensMPI.Write( "M100", 523434234234343UL );     // 写大整数无符号
            siemensMPI.Write( "M100", 123.456d );              // 写双精度
            siemensMPI.Write( "M100", "K123456789" );// 写ASCII字符串

            OperateResult<byte[]> read = siemensMPI.Read( "M100", 10 );
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
