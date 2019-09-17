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
    public partial class FormCurve : HslFormContent
    {
        public FormCurve( )
        {
            InitializeComponent( );
        }


        private float[] GetRandomValueByCount( int count, float min, float max )
        {
            float[] data = new float[count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (float)random.NextDouble( ) * (max - min) + min;
            }
            return data;
        }


        private void FormCurve_Load( object sender, EventArgs e )
        {

            random = new Random( );

            userCurve1.SetLeftCurve( "A", GetRandomValueByCount( 12, 0, 200 ), Color.DodgerBlue );
            userCurve1.SetCurveText( new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" } );

            userCurve3.SetLeftCurve( "A", GetRandomValueByCount( 400, 100, 150 ), Color.Tomato );
            userCurve3.SetRightCurve( "B", GetRandomValueByCount( 400, 1.2f, 2.0f ), Color.LimeGreen );

            userCurve2.SetLeftCurve( "A", null, Color.DodgerBlue );
            userCurve2.SetLeftCurve( "B", null, Color.Tomato );
            userCurve2.SetRightCurve( "C", null, Color.LimeGreen );
            userCurve2.SetRightCurve( "D", null, Color.Orchid );


            timerTick = new Timer( );
            timerTick.Interval = 300;
            timerTick.Tick += TimerTick_Tick;
            timerTick.Start( );

        }

        private void TimerTick_Tick( object sender, EventArgs e )
        {
            userCurve2.AddCurveData(
                new string[] { "A", "B", "C", "D" },
                new float[]
                {
                    random.Next(170,190),
                    random.Next(140,160),
                    (float)random.NextDouble()*0.5f+1f,
                    (float)random.NextDouble()*1f+2f,
                }
            );
            userCurve2.SetCurveVisible( new string[] { "A", "B" }, isVisiable );
        }


        private Timer timerTick = null;
        private Random random;

        private void userButton6_Click( object sender, EventArgs e )
        {
            // 做辅助曲线
            if (float.TryParse( textBox1.Text, out float value ))
            {
                userCurve2.AddLeftAuxiliary( value, Color.Yellow );
            }
        }

        private void userButton8_Click( object sender, EventArgs e )
        {
            // 右辅助曲线
            if (float.TryParse( textBox1.Text, out float value ))
            {
                userCurve2.AddRightAuxiliary( value, Color.Chocolate );
            }
        }

        private void userButton7_Click( object sender, EventArgs e )
        {
            // 移除辅助曲线
            if (float.TryParse( textBox1.Text, out float value ))
            {
                userCurve2.RemoveAuxiliary( value );
            }
        }

        private bool isVisiable = true;
        private void userButton1_Click( object sender, EventArgs e )
        {
            isVisiable = !isVisiable;
            userCurve2.SetCurveVisible( new string[] { "A", "B" }, isVisiable );
        }
    }
}
