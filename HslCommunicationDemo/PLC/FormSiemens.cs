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
using System.Xml.Linq;

namespace HslCommunicationDemo
{
    public partial class FormSiemens : HslFormContent
    {
        public FormSiemens( SiemensPLCS siemensPLCS )
        {
            InitializeComponent( );
            siemensPLCSelected = siemensPLCS;
            siemensTcpNet = new SiemensS7Net( siemensPLCS );
        }


        private SiemensS7Net siemensTcpNet = null;
        private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;


        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;

            Language( Program.Language );

            if (siemensPLCSelected == SiemensPLCS.S400)
            {
                textBox15.Text = "0";
                textBox16.Text = "3";
            }
            else if(siemensPLCSelected == SiemensPLCS.S1200)
            {
                textBox15.Text = "0";
                textBox16.Text = "0";
            }
            else if (siemensPLCSelected == SiemensPLCS.S300)
            {
                textBox15.Text = "0";
                textBox16.Text = "2";
            }
            else if (siemensPLCSelected == SiemensPLCS.S1500)
            {
                textBox15.Text = "0";
                textBox16.Text = "0";
            }
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Siemens Read PLC Demo";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";

                button_read_string.Text = "r-string";
                button7.Text = "r-time";
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
                button14.Text = "w-string";
                button8.Text = "w-time";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Special function test";

                button3.Text = "Order";
                button4.Text = "hot-start";
                button5.Text = "cold-start";
                button6.Text = "stop";
            }
        }
        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        
        #region Connect And Close
        
        private void button1_Click( object sender, EventArgs e )
        {
            if(!int.TryParse(textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            siemensTcpNet.IpAddress = textBox1.Text;
            siemensTcpNet.Port = port;
            try
            {
                if (siemensPLCSelected != SiemensPLCS.S200Smart)
                {
                    siemensTcpNet.Rack = byte.Parse( textBox15.Text );
                    siemensTcpNet.Slot = byte.Parse( textBox16.Text );
                }


                OperateResult connect = siemensTcpNet.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                    userControlReadWriteOp1.SetReadWriteNet( siemensTcpNet, "M100", true );
                }
                else
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
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
            siemensTcpNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 单数据读取测试


        private async void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            OperateResult<string> read = await siemensTcpNet.ReadStringAsync( textBox8.Text );
            if (read.IsSuccess)
            {
                textBox7.Text = read.Content;
            }
            else
            {
                MessageBox.Show( "Failed:" + read.Message );
            }
        }

        private async void Button7_Click( object sender, EventArgs e )
        {
            OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
            if (read.IsSuccess)
            {
                textBox7.Text = read.Content.ToString( );
            }
            else
            {
                MessageBox.Show( "Failed:" + read.Message );
            }
        }

        #endregion

        #region 单数据写入测试

        private async void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );
        }


        private async void Button8_Click( object sender, EventArgs e )
        {
            // time写入
            if (DateTime.TryParse( textBox7.Text, out DateTime value ))
                DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
            else
                MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );
        }


        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( siemensTcpNet, textBox6, textBox9, textBox10 );


            //siemensTcpNet.Write( "M100.0", true ).
            //    Then( ( ) => siemensTcpNet.ReadInt16( "M1100" ) ).
            //    Then( content => siemensTcpNet.Write( "M200", true ) );

            // 比如我有个简单的需求，先读M100.0，如果是true，我就写M101.0为true，否则返回确认没有件的失败消息
            // 以前的写法
            // OperateResult<bool> readbool = siemensTcpNet.ReadBool( "M100.0" );
            // if (!readbool.IsSuccess) return readbool;

            // if (readbool.Content) return siemensTcpNet.Write( "M101.0", true );
            // else return new OperateResult( "当前位置没有件" );

            // 现在写法
            // var result = siemensTcpNet.ReadBool( "M100.0" ).Check( content => content == true, "当前位置没有件" ).Then( () => siemensTcpNet.Write( "M101.0", true ) );
            // DemoUtils.WriteResultRender( result, "Test" );
        }

        private async void button3_Click( object sender, EventArgs e )
        {
            // 订货号
            OperateResult<string> read = await siemensTcpNet.ReadOrderNumberAsync( );
            if (read.IsSuccess)
            {
                textBox10.Text = "Order Number：" + read.Content;
            }
            else
            {
                MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
            }
        }

        #endregion

        #region 报文读取测试


        private async void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = await siemensTcpNet.ReadFromCoreServerAsync( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
            OperateResult<bool> read = siemensTcpNet.ReadBool( "M100.4" );
            if (read.IsSuccess)
            {
                bool m100_4 = read.Content;
            }
            else
            {
                // failed
                string err = read.Message;
            }

            OperateResult write = siemensTcpNet.Write( "M100.4", true );
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
            byte m100_byte = siemensTcpNet.ReadByte( "M100" ).Content;
            short m100_short = siemensTcpNet.ReadInt16( "M100" ).Content;
            ushort m100_ushort = siemensTcpNet.ReadUInt16( "M100" ).Content;
            int m100_int = siemensTcpNet.ReadInt32( "M100" ).Content;
            uint m100_uint = siemensTcpNet.ReadUInt32( "M100" ).Content;
            float m100_float = siemensTcpNet.ReadFloat( "M100" ).Content;
            double m100_double = siemensTcpNet.ReadDouble( "M100" ).Content;
            string m100_string = siemensTcpNet.ReadString( "M100", 10 ).Content;

            HslCommunication.Core.IByteTransform ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );

        }

        private void Test3()
        {
            // 读取操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            bool M100_7 = siemensTcpNet.ReadBool( "M100.7" ).Content;  // 读取M100.7是否通断，注意M100.0等同于M100
            byte byte_M100 = siemensTcpNet.ReadByte( "M100" ).Content; // 读取M100的值
            short short_M100 = siemensTcpNet.ReadInt16( "M100" ).Content; // 读取M100-M101组成的字
            ushort ushort_M100 = siemensTcpNet.ReadUInt16( "M100" ).Content; // 读取M100-M101组成的无符号的值
            int int_M100 = siemensTcpNet.ReadInt32( "M100" ).Content;         // 读取M100-M103组成的有符号的数据
            uint uint_M100 = siemensTcpNet.ReadUInt32( "M100" ).Content;      // 读取M100-M103组成的无符号的值
            float float_M100 = siemensTcpNet.ReadFloat( "M100" ).Content;   // 读取M100-M103组成的单精度值
            long long_M100 = siemensTcpNet.ReadInt64( "M100" ).Content;      // 读取M100-M107组成的大数据值
            ulong ulong_M100 = siemensTcpNet.ReadUInt64( "M100" ).Content;   // 读取M100-M107组成的无符号大数据
            double double_M100 = siemensTcpNet.ReadDouble( "M100" ).Content; // 读取M100-M107组成的双精度值
            string str_M100 = siemensTcpNet.ReadString( "M100", 10 ).Content;// 读取M100-M109组成的ASCII字符串数据

            // 写入操作，这里的M100可以替换成I100,Q100,DB20.100效果时一样的
            siemensTcpNet.Write( "M100.7", true );                // 写位，注意M100.0等同于M100
            siemensTcpNet.Write( "M100", (byte)0x33 );            // 写单个字节
            siemensTcpNet.Write( "M100", (short)12345 );          // 写双字节有符号
            siemensTcpNet.Write( "M100", (ushort)45678 );         // 写双字节无符号
            siemensTcpNet.Write( "M100", 123456789 );             // 写双字有符号
            siemensTcpNet.Write( "M100", (uint)3456789123 );      // 写双字无符号
            siemensTcpNet.Write( "M100", 123.456f );              // 写单精度
            siemensTcpNet.Write( "M100", 1234556434534545L );     // 写大整数有符号
            siemensTcpNet.Write( "M100", 523434234234343UL );     // 写大整数无符号
            siemensTcpNet.Write( "M100", 123.456d );              // 写双精度
            siemensTcpNet.Write( "M100", "K123456789" );// 写ASCII字符串

            OperateResult<byte[]> read = siemensTcpNet.Read( "M100", 10 );
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

        private async void button4_Click( object sender, EventArgs e )
        {
            // 热启动
            OperateResult result = await siemensTcpNet.HotStartAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private async void button5_Click( object sender, EventArgs e )
        {
            // 冷启动
            OperateResult result = await siemensTcpNet.ColdStartAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private async void button6_Click( object sender, EventArgs e )
        {
            // 停止
            OperateResult result = await siemensTcpNet.StopAsync( );
            if (result.IsSuccess)
            {
                MessageBox.Show( "Success" );
            }
            else
            {
                MessageBox.Show( "Failed: " + result.Message );
            }
        }

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        private long successCount = 0;
        private System.Windows.Forms.Timer timer;


        private void button9_Click( object sender, EventArgs e )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test1 ) ) { IsBackground = true, }.Start( );
            button9.Enabled = false;

            timer = new System.Windows.Forms.Timer( );
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start( );
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            label2.Text = successCount.ToString( );
        }

        private async void thread_test1( )
        {
            int count = 100000;
            while (count > 0)
            {
                if (!(await siemensTcpNet.WriteAsync( "M100", (short)1234 )).IsSuccess) failed++;
                if (!(await siemensTcpNet.ReadInt16Async( "M100" ) ).IsSuccess) failed++;
                count--;
                successCount++;
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
                    label2.Text = successCount.ToString( );
                    timer.Stop( );
                    button9.Enabled = true;
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
                } ) );
            }
        }



        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlRack, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox16.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox15.Text = element.Attribute( DemoDeviceList.XmlRack ).Value;
            textBox16.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
