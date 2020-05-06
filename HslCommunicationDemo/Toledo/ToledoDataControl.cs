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
            label10.Text = data.Unit;
            textBox2.Text = data.Tare.ToString( );
        }
    }
}
