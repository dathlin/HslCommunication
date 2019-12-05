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
            textBox1.Text = @"V8.2.0
1. 三菱的MC协议支持读取SM和SD，特殊连接继电器，特殊寄存器。
2. PushNet优化相关代码。
3. MelsecMcUdp: 新增三菱的MC协议的UDP通讯类。
4. MelsecMcAsciiUdp: 新增三菱的MC协议的ASCII格式的UDP通讯类。
5. MelsecMcServer: 三菱的虚拟服务器修复数据存储加载的bug。
6. Serial: 串口的基类公开了一个Rts属性，用于某些串口无法读取的设备的情况。
7. OmronFinsServer: 新增欧姆龙的虚拟plc，支持和hsl自身的通讯，支持cio，h区，ar区，d区的通信，不支持E区。
8. AllenBradleyServer: 新增ab plc的虚拟plc，支持和hsl的自身的通讯，在demo里预设了4个变量值。不支持结构体和二维及以上数组读写。
9. Aline: 异形的服务器对象新增一个设置属性，是否反馈注册结果，默认为True。
10. SoftBasic: 数组格式化操作新增格式化的字符串说明。
11. Modbus: 调整Write( string address, bool value )采用05功能码写入，而参数为bool[]的话，采用0F功能码。
12. Modbus: 提供WriteOneRegister方法，写入单个的寄存器，使用06功能码。
13. LogNet: 日志在实例化的时候，添加对当前设置的目录的是否存在的检查，如果不存在，则自动创建目录。
14. Python: 大量代码更新，新增了一个欧姆龙的fins-tcp通信。
15. Java: 大量代码更新，新增了一个AB plc的读写类。
16. 付费调整,，从2019年12月5日起，个人永久授权，2500rmb；企业永久授权：6500rmb，感谢支持，原先已经签合同的以合同价格为准。个人和企业均需签合同。是否含有商用权利以合同为准。";
        }
    }
}
