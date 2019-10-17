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
            textBox1.Text = @"V8.1.2
1. Lsis: 感谢埃及朋友的支持，demo增加了bool操作。
2. Knx驱动：增加测试demo，完善驱动，测试通过，有需要的朋友可以查看信息。
3. IntegrationFileClient: 完善文件的收发类，新增重载的构造方法，传入ip地址及端口即可。
4. melsec: 三菱的MC协议部分错误代码关联了文本信息，在测试的时候即可弹出错误信息，方便排查，常见了已经绑定。
5. melsec: 新增3e协议的随机字批量读取操作，支持跨地址，跨数据类型混合交叉读取，一次即可读完。
6. fileserver: 修复linux下的bug，新增上传文件后的触发事件，将文件的信息都传递给调用者。
7. SiemensMpi: 添加MPI协议，并完善demo，等待测试。
8. 本组件从v8.0.0开始进入付费授权模式，详细参考官方：http://www.hslcommunication.cn/ 。
";
        }
    }
}
