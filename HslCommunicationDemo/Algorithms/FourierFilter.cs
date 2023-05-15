using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo.Algorithms
{
    public partial class FourierFilter : HslFormContent
    {
        public FourierFilter( )
        {
            InitializeComponent( );
            sources = new float[count];
            values = new float[count];
            filters = new float[count];
            dateTimes = new DateTime[count];
        }

        private Random random;
        private int count = 1024;

        private float[] sources;
        private float[] values;
        private float[] filters;
        private DateTime[] dateTimes;

        private void FourierFilter_Load( object sender, EventArgs e )
        {
            random = new Random( );


            for (int i = 0; i < sources.Length; i++)
            {
                sources[i] = (float)(Math.Sin( 2 * Math.PI * i / 500 ) * 50 + 40);
                values[i] = sources[i];
                if (random.Next( 100 ) < 50) values[i] = sources[i] + random.Next( 101 ) / 20f - 2f;

                dateTimes[i] = DateTime.Now.AddSeconds( i - 1000 );
            }

            filters = HslCommunication.Algorithms.Fourier.FFTFilter.FilterFFT( values, 0.002d );
            hslCurveHistory1.SetLeftCurve( "原始数据", values, Color.LightGray );
            hslCurveHistory1.SetLeftCurve( "滤波数据", filters, Color.Tomato );
            hslCurveHistory1.SetDateTimes( dateTimes );
            hslCurveHistory1.RenderCurveUI( );
        }

        private void Button1_Click( object sender, EventArgs e )
        {
            using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( values.Select( m => (double)m ).ToArray( ), 1000, 600, Color.Blue ) ))
            {
                form.ShowDialog( );
            }
        }

        private void Button2_Click( object sender, EventArgs e )
        {
            try
            {
                filters = HslCommunication.Algorithms.Fourier.FFTFilter.FilterFFT( values, double.Parse( textBox1.Text ) );
                hslCurveHistory1.SetLeftCurve( "滤波数据", filters, Color.Tomato );
                hslCurveHistory1.RenderCurveUI( );
            }
            catch(Exception ex)
            {
                MessageBox.Show( "数据输入错误！" + ex.Message );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( values.Select( m => (double)m ).ToArray( ), 1000, 600, Color.Blue, true ) ))
            {
                form.ShowDialog( );
            }
        }
    }
}
