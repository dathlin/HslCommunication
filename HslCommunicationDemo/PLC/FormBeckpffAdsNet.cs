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
using System.Xml.Linq;

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
                label8.Text = "case: 192.168.1.100.1.1:801 or 192.168.1.100.1.1";
                checkBox1.Text = "Tag Cache";
                label17.Text = "TwinCAT2, port number 801; TwinCAT3, port number 851";

                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
                groupBox5.Text = "Special function test";

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

            adsNet?.ConnectClose( );
            adsNet = new BeckhoffAdsNet( textBox1.Text, port );
            try
            {
                adsNet.SetTargetAMSNetId( textBox14.Text );
                adsNet.SetSenderAMSNetId( textBox15.Text );
                adsNet.UseTagCache = checkBox1.Checked;
                OperateResult connect = adsNet.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;

                    userControlReadWriteOp1.SetReadWriteNet( adsNet, "M100", true );
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

        private async void button3_Click( object sender, EventArgs e )
        {
            OperateResult<AdsDeviceInfo> read = await adsNet.ReadAdsDeviceInfoAsync( );
            if (read.IsSuccess)
            {
                textBox3.Text = $"Major:{read.Content.Major}{Environment.NewLine}" +
                    $"Minor:{read.Content.Minor}{Environment.NewLine}" +
                    $"Build:{read.Content.Build}{Environment.NewLine}" +
                    $"Name:{read.Content.DeviceName}";
            }
            else
            {
                MessageBox.Show( "Read Faild:" + read.Message );
            }
        }

        private async void button4_Click( object sender, EventArgs e )
        {
            OperateResult<ushort,ushort> read = await adsNet.ReadAdsStateAsync( );
            if (read.IsSuccess)
            {
                textBox3.Text = $"Ads State:{read.Content1}{Environment.NewLine}" +
                    $"Device State:{read.Content2}{Environment.NewLine}";
            }
            else
            {
                MessageBox.Show( "Read Faild:" + read.Message );
            }
        }

        private async void button5_Click( object sender, EventArgs e )
        {
            if(!uint.TryParse(textBox4.Text, out uint handle ))
            {
                MessageBox.Show( "Handle input not corrent" );
                return;
            }

            OperateResult release = await adsNet.ReleaseSystemHandleAsync( handle );
            if (release.IsSuccess)
            {
                MessageBox.Show( "Release Success!" );
            }
            else
            {
                MessageBox.Show( "Release Failed:" + release.Message );
            }
        }



        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlTarget, textBox14.Text );
            element.SetAttributeValue( DemoDeviceList.XmlSender, textBox15.Text );
            element.SetAttributeValue( DemoDeviceList.XmlTagCache, checkBox1.Checked );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox14.Text = element.Attribute( DemoDeviceList.XmlTarget ).Value;
            textBox15.Text = element.Attribute( DemoDeviceList.XmlSender ).Value;
            checkBox1.Checked = bool.Parse( element.Attribute( DemoDeviceList.XmlTagCache ).Value );
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
