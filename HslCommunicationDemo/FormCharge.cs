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
            textBox1.Text = @"V8.1.3
1. Lsis: 感谢埃及朋友的支持，demo完善了cpu类型的选择。
2. LogNet:新增移除关键字的接口方法，修复linux运行路径解析的bug，完善api文档的示例代码。
3. 大量的细节优化，变量名称单次拼写错误的修复。
4. Modbus: 当地址为x=3;100时，读正常，写入异常的问题修复，功能码自动替换为0x10。
5. FileNet: 修复高并发下载时的下载异常的问题，调整指令头的超时时间。
6. AB plc: 公开一个新的api接口，运行配置一些比较高级的数据。
7. 接下来计划：1.完善hsl的demo，api文档，准备基础的入门视频；2.开始完善java版本的代码，java版本只对超级VIP群开放。
8. 本组件从v8.0.0开始进入付费授权模式，详细参考官方：http://www.hslcommunication.cn/ 。";
        }
    }
}
