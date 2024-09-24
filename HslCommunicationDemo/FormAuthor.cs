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
    public partial class FormAuthor : System.Windows.Forms.Form
    {
        public FormAuthor( )
        {
            InitializeComponent( );
        }

        private void FormAuthor_Load( object sender, EventArgs e )
        {
            label1.BackColor = FormLoad.ThemeColor;
            label2.Text = "    作者2013年毕业于中国计量大学自动化专业，2013年-2017年就职于中策橡胶集团有限公司，从事软件开发，开发了大量的工业现场" + 
                "使用的上位机软件，SCADA软件，条码采集监控软件等等，实战经验丰富。离职后将所有的通信经验凝练成了一个通用库，" + 
                "目前该组件已经在全国的使用率非常高，成功应用于数万个项目中，于2020年成立了胡工物联科技有限公司。"+ Environment.NewLine+
                "    作者致力于工业的信息化，智能化建设，大力推行智能制造2025，工业4.0建设，致力于降低所有传统企业的信息化转型的成本，大力发展以通信为核心，"+
                "辅以机器视觉，人工智能技术，将传统的工业转型为，高科技，高智能，绿色的现代化企业。";
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                System.Diagnostics.Process.Start( linkLabel1.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
