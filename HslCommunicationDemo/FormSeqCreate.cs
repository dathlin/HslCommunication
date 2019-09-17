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
    #region FormSeqCreate

    public partial class FormSeqCreate : HslFormContent
    {

        public FormSeqCreate( )
        {
            InitializeComponent( );
        }


        private HslCommunication.BasicFramework.SoftNumericalOrder softNumericalOrder;    // 序列号生成器对象

        private void FormSeqCreate_Load( object sender, EventArgs e )
        {
            label1.BackColor = FormLoad.ThemeColor;
            softNumericalOrder = new HslCommunication.BasicFramework.SoftNumericalOrder(
                   "ABC",              // "ABC201711090000001" 中的ABC前缀，代码中仍然可以更改ABC
                   "yyyyMMdd",         // "ABC201711090000001" 中的20171109，可以格式化时间，也可以为""，也可以设置为"yyyyMMddHHmmss";
                   7,                  // "ABC201711090000001" 中的0000001，总位数为7，然后不停的累加，即使日期时间变了，也不停的累加，最好长度设置大一些
                   Application.StartupPath + @"\numericalOrder.txt"  // 该生成器会自动存储当前值到文件去，实例化时从文件加载，自动实现数据同步
                   );


            if (!Program.ShowAuthorInfomation)
            {
                label2.Visible = false;
                linkLabel1.Visible = false;
            }
        }

        private void userButton1_Click( object sender, EventArgs e )
        {
            // 获取流水号，带有默认的数据头，也即实例化中的"ABC"
            string seqNumber = softNumericalOrder.GetNumericalOrder( );
            textBox1.AppendText( seqNumber + Environment.NewLine );
        }

        private void userButton3_Click( object sender, EventArgs e )
        {
            // 获取流水号，带有自定义的数据头
            string seqNumber = softNumericalOrder.GetNumericalOrder( "XYZ" );
            textBox1.AppendText( seqNumber + Environment.NewLine );
        }

        private void userButton2_Click( object sender, EventArgs e )
        {
            // 百万次的流水号测试
            DateTime start = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                string seqNumber = softNumericalOrder.GetNumericalOrder( "XYZ" );
            }
            double spend = (DateTime.Now - start).TotalMilliseconds;
            textBox1.AppendText( "耗时：" + spend + Environment.NewLine );
        }


        // 忽略
        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                System.Diagnostics.Process.Start( linkLabel1.Text );
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
            }
        }
    }


    #endregion
}
