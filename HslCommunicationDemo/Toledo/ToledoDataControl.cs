using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Profinet.Toledo;

namespace HslCommunicationDemo.Toledo
{
    public partial class ToledoDataControl : UserControl
    {
        public ToledoDataControl( )
        {
            InitializeComponent( );
        }

        private void ToledoDataControl_Load( object sender, EventArgs e )
        {

        }

        public void SetToledoData( ToledoStandardData data )
        {
            if (data.Suttle)
            {
                label2.BackColor = Color.Red;
                label1.BackColor = SystemColors.Control;
            }
            else
            {
                label1.BackColor = Color.Red;
                label2.BackColor = SystemColors.Control;
            }

            if (data.Symbol)
            {
                label3.BackColor = Color.Red;
                label4.BackColor = SystemColors.Control;
            }
            else
            {
                label4.BackColor = Color.Red;
                label3.BackColor = SystemColors.Control;
            }

            if (data.BeyondScope)
            {
                label6.BackColor = Color.Red;
                label5.BackColor = SystemColors.Control;
            }
            else
            {
                label5.BackColor = Color.Red;
                label6.BackColor = SystemColors.Control;
            }

            if (data.DynamicState)
            {
                label7.BackColor = Color.Red;
                label8.BackColor = SystemColors.Control;
            }
            else
            {
                label8.BackColor = Color.Red;
                label7.BackColor = SystemColors.Control;
            }

            textBox1.Text = data.Weight.ToString( );
            label10.Text  = data.Unit;
            textBox2.Text = data.Tare.ToString( );

            if (Program.Language == 1)
                label13.Text = data.DataValid ? "有效" : "无效";
            else
                label13.Text = data.DataValid ? "Valid" : "Invalid";

            if (data.IsTenExtend)
            {
                if (Program.Language == 1)
                {
                    textBox3.Text = data.TareType == 0 ? "无皮重" : data.TareType == 1 ? "按键去皮" : data.TareType == 2 ? "预置皮重" : "皮重内存";
                }
                else
                {
                    textBox3.Text = data.TareType == 0 ? "without tare" : data.TareType == 1 ? "key peeling" : data.TareType == 2 ? "Preset tare" : "Tare memory";
                }
            }
            else
            {
                textBox3.Text = string.Empty;
            }
        }
    }
}
