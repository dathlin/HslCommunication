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
using HslCommunication.Profinet.Omron;
using HslCommunication;
using HslCommunication.Profinet.AllenBradley;

namespace HslCommunicationDemo
{
    public partial class FormOmronCip : HslFormContent
    {
        public FormOmronCip( )
        {
            InitializeComponent( );
            omronCipNet = new OmronCipNet( "192.168.0.110" );
        }


        private OmronCipNet omronCipNet = null;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Omron Read PLC Demo";
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
                label8.Text = "length:";
                label11.Text = "Address:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";
                button3.Text = "Build";
                label2.Text = "Start:";

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
                groupBox4.Text = "CIP reading test, hex string needs to be filled in";

                button23.Text = "w-byte";
                label22.Text = "plc tag name";
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


            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            if (!byte.TryParse( textBox15.Text, out byte slot ))
            {
                MessageBox.Show( DemoUtils.SlotInputWrong );
                return;
            }

            omronCipNet.IpAddress = textBox1.Text;
            omronCipNet.Port = port;
            omronCipNet.Slot = slot;

            try
            {
                OperateResult connect = omronCipNet.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                    userControlCurve1.ReadWriteNet = omronCipNet;
                }
                else
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
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
            omronCipNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }







        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            if(textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadBool( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_byte_Click( object sender, EventArgs e )
        {
            // MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( textBox3.Text ).Content, ' ' ) );
            // 读取byte变量
            DemoUtils.ReadResultRender( omronCipNet.ReadByte( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadInt16( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt16( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadInt32( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt32( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadInt64( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadUInt64( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadFloat( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox14.Text == "1")
                DemoUtils.ReadResultRender( omronCipNet.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( omronCipNet.ReadDouble( textBox3.Text, ushort.Parse( textBox14.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( omronCipNet.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            //MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildWriteCommand( textBox8.Text, AllenBradleyHelper.CIP_Type_Bool, (bool.Parse( textBox7.Text ) ?
            //   new byte[] { 0xFF } : new byte[] { 0x00 }) ).Content , ' ') );
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button23_Click( object sender, EventArgs e )
        {
            // byte写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, byte.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( ( ) => omronCipNet.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }




        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            try
            {
                //    OperateResult write = allenBradleyNet.Write( "Array", new short[] { 101, 102, 103, 104, 105, 106 } );

                // OperateResult<short[]> readResult = allenBradleyNet.ReadInt16( "Array", 300 );

                OperateResult<byte[]> read = null;
                if (!textBox6.Text.Contains( ";" ))
                {
                    //MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( new string[] { textBox6.Text }, new int[] { int.Parse(textBox9.Text) } ).Content , ' ') );
                    read = omronCipNet.ReadSegment( textBox6.Text, ushort.Parse( textBox12.Text ), ushort.Parse( textBox9.Text ) );
                }
                else
                {
                    //MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( textBox6.Text.Split( ';' ) ).Content, ' ' ) );
                    read = omronCipNet.Read( textBox6.Text.Split( ';' ) );
                }

                if (read.IsSuccess)
                {
                    textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
                }
                else
                {
                    MessageBox.Show( "Read failed：" + read.ToMessageShowString( ) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Read failed：" + ex.Message );
            }
        }

        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = omronCipNet.ReadCipFromServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
            if (read.IsSuccess)
            {
                textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
            }
            else
            {
                MessageBox.Show( "Read failed：" + read.ToMessageShowString( ) );
            }
        }


        #endregion

        private void Button3_Click( object sender, EventArgs e )
        {
            try
            {
                //    OperateResult write = allenBradleyNet.Write( "Array", new short[] { 101, 102, 103, 104, 105, 106 } );

                // OperateResult<short[]> readResult = allenBradleyNet.ReadInt16( "Array", 300 );

                //MessageBox.Show( HslCommunication.BasicFramework.SoftBasic.ByteToHexString( allenBradleyNet.BuildReadCommand( new string[] { textBox6.Text }, new int[] { int.Parse(textBox9.Text) } ).Content , ' ') );
                byte[] read = AllenBradleyHelper.PackRequestReadSegment( textBox6.Text, ushort.Parse( textBox12.Text ), ushort.Parse( textBox9.Text ) );

                textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read, ' ' );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Build failed：" + ex.Message );
            }
        }
    }
}
