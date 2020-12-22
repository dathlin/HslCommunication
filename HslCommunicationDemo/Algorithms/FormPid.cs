using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Algorithms.PID;

namespace HslCommunicationDemo.Algorithms
{
    public partial class FormPid : HslFormContent
    {
        public FormPid( )
        {
            InitializeComponent( );
        }

        private PIDHelper pIDHelper;
        private Timer timer;

        private void FormPid_Load( object sender, EventArgs e )
        {
            userCurve1.SetLeftCurve( "Pid",null, Color.Green );
            pIDHelper = new PIDHelper( );
            timer = new Timer( );
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start( );
        }


        private void Timer_Tick( object sender, EventArgs e )
        {
            userCurve1.AddCurveData( "Pid", (float)pIDHelper.PidCalculate( ) );
        }

        private void Button1_Click( object sender, EventArgs e )
        {
            try
            {
                pIDHelper.SetValue = double.Parse( textBox5.Text );
            }
            catch
            {
                MessageBox.Show( "Input Wrong, please check the input value!" );
            }
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            try
            {
                pIDHelper.Kp = double.Parse( textBox1.Text );
                pIDHelper.Ki = double.Parse( textBox2.Text );
                pIDHelper.Kd = double.Parse( textBox3.Text );
                pIDHelper.DeadBand = double.Parse( textBox4.Text );
            }
            catch
            {
                MessageBox.Show( "Input Wrong, please check the input value!" );
            }
        }
    }
}
