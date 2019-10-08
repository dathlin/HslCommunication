using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.ModBus;
using System.Threading;

namespace HslCommunicationDemo
{
    public partial class FormModbusUdp : HslFormContent
    {
        public FormModbusUdp( )
        {
            InitializeComponent( );
        }


        private ModbusUdpNet busTcpClient = null;

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;

            Language( Program.Language );
        }


        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Modbus Tcp Over Udp Read Demo";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                label21.Text = "station";
                checkBox1.Text = "address from 0";
                checkBox3.Text = "string reverse";
                button1.Text = "Open";
                button2.Text = "Close";
                
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_bool.Text = "r-coil";
                button4.Text = "r-discrete";
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
                button24.Text = "w-coil";
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


            }
        }

        private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (busTcpClient != null)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.ABCD;break;
                    case 1: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
                    case 2: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
                    case 3: busTcpClient.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
                    default:break;
                }
            }
        }

        private void CheckBox3_CheckedChanged( object sender, EventArgs e )
        {
            if (busTcpClient != null)
            {
                busTcpClient.IsStringReverse = checkBox3.Checked;
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


            if(!int.TryParse(textBox2.Text,out int port))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }


            if(!byte.TryParse(textBox15.Text,out byte station))
            {
                MessageBox.Show( "Station input is wrong！" );
                return;
            }

            busTcpClient = new ModbusUdpNet( textBox1.Text, port, station );
            busTcpClient.AddressStartWithZero = checkBox1.Checked;


            ComboBox1_SelectedIndexChanged( null, new EventArgs( ) );  // 设置数据服务
            busTcpClient.IsStringReverse = checkBox3.Checked;

            try
            {
                MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlCurve1.ReadWriteNet = busTcpClient;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadCoil( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadCoil( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button4_Click_1( object sender, EventArgs e )
        {
            // 读取离散输入bool变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadDiscrete( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadDiscrete( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            if(textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadInt16( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );

            // 这一行是测试读取short数组的代码，忽略就行
            // short[] values = busTcpClient.ReadInt16( "100", 2 ).Content;
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt16( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadInt32(  textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadInt32( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt32( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadInt64( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadUInt64( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadFloat( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            if (textBox16.Text == "1")
                DemoUtils.ReadResultRender( busTcpClient.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
            else
                DemoUtils.ReadResultRender( busTcpClient.ReadDouble( textBox3.Text, ushort.Parse( textBox16.Text ) ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( busTcpClient.ReadString( textBox3.Text , ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            try
            {
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            try
            {
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , short.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , ushort.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , int.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , uint.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , long.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , ulong.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , float.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , double.Parse( textBox7.Text ) ), textBox8.Text );
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
                DemoUtils.WriteResultRender( busTcpClient.Write( textBox8.Text , textBox7.Text ), textBox8.Text );
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
            DemoUtils.BulkReadRenderResult( busTcpClient, textBox6, textBox9, textBox10 );
        }



        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = busTcpClient.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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

        #region 压力测试

        private void button4_Click( object sender, EventArgs e )
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

        private void thread_test2( )
        {
            int count = 500;
            while (count > 0)
            {
                if (!busTcpClient.Write( "100", (short)1234 ).IsSuccess) failed++;
                if (!busTcpClient.ReadInt16( "100" ).IsSuccess) failed++;
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
        
        #endregion

        #region Test Function


        private void Test1()
        {
            OperateResult<bool[]> read = busTcpClient.ReadCoil( "100", 10 );
            if(read.IsSuccess)
            {
                bool coil_100 = read.Content[0];
                // and so on 
                bool coil_109 = read.Content[9];
            }
            else
            {
                // failed
                string err = read.Message;
            }
        }


        private void Test2()
        {
            bool[] values = new bool[] { true, false, false, false, true, true, false, true, false, false };
            OperateResult write = busTcpClient.Write( "100", values );
            if (write.IsSuccess)
            {
                // success
            }
            else
            {
                // failed
                string err = write.Message;
            }

            HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseWordTransform( );
        }



        #endregion
        
    }
}
