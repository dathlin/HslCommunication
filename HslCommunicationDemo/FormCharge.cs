using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormCharge : HslFormContent
    {
        public FormCharge( )
        {
            InitializeComponent( );
        }

        private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            FormLoad.OpenWebside( linkLabel1.Text );
        }

        private void FormCharge_Load( object sender, EventArgs e )
        {
            textBox1.Text = @"V8.2.1
1. Cip协议：cip协议开放Eip指令自定义输入，优化指令生成算法。
2. Cip协议：Write(string address, byte[] data)方法提示使用WriteTag信息。
3. NetworkDoubleBase: 修复bool异步读写提示不支持的bug，现在可以使用异步了。
4. SAMSerial：新增身份证阅读器的串口协议，支持读取身份证信息，头像信息还未解密。
5. SAMTcpNet：新增身份证阅读器的串口透传协议，支持读取身份证信息，头像信息还未解密。
6. BeckhoffAdsNet：新增倍福plc的协议，还未通过测试。";
        }
    }
}
