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
    public partial class FourierTransform : HslFormContent
    {
        public FourierTransform( )
        {
            InitializeComponent( );
        }

        private void 傅立叶变换_Load( object sender, EventArgs e )
        {

            // 方波
            Squarewave( );

            // 正弦波加干扰信号
            Sinawave( );

            // 无规律波
            Others( );

            Language( Program.Language );

        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "傅里叶变换测试";
                label5.Text = "FFT 快速离散傅立叶变换";
                label1.Text = "方波及变换后的波形";
                label3.Text = "正弦波及变换后的波形";
                label6.Text = "混合波及变换后的波形";
                userButton1.UIText = "专用图形";
                userButton2.UIText = "专用图形";
                userButton3.UIText = "专用图形";
            }
            else
            {
                Text = "FFT Test";
                label5.Text = "FFT Fast discrete Fourier transform";
                label1.Text = "The waveform of the square sweep and the transformed";
                label3.Text = "Waveform after sine wave and transform";
                label6.Text = "Waveform after mixed sweep and transform";
                userButton1.UIText = "Graphics";
                userButton2.UIText = "Graphics";
                userButton3.UIText = "Graphics";
            }
        }

        private void Squarewave( )
        {
            // 信号一，方波信号
            double[] data = new double[256];
            for (int i = 0; i < data.Length / 2; i++)
            {
                data[i] = 5;
            }

            userCurve1.SetCurve( key: "A", isLeft: true, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f );

            double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );
            
            userCurve2.ValueMaxLeft = (float)trans.Max( );
            userCurve2.ValueMaxRight = (float)trans.Max( );
            userCurve2.SetCurve( key: "A", isLeft: true, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f );
        }

        private void Sinawave( )
        {
            // 信号二，正弦波叠加，额外增加了一个干扰信号

            double[] data = new double[256];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 5 * Math.Sin( i * Math.PI / 128 ) + 5 + 0.5f * Math.Cos( i * 8 * Math.PI / 128 );
            }

            userCurve4.SetCurve( key: "A", isLeft: true, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f );

            double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );

            userCurve3.ValueMaxLeft = (float)trans.Max( );
            userCurve3.ValueMaxRight = (float)trans.Max( );
            userCurve3.SetCurve( key: "A", isLeft: true, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f );

        }

        private void Others()
        {
            double[] data = new double[256];
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 140 && i < 160)
                {
                    data[i] = 5;
                }
            }

            userCurve6.SetCurve( key: "A", isLeft: true, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f );

            double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );

            userCurve5.ValueMaxLeft = (float)trans.Max( );
            userCurve5.ValueMaxRight = (float)trans.Max( );
            userCurve5.SetCurve( key: "A", isLeft: true, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f );
        }

        private void userButton1_Click( object sender, EventArgs e )
        {
            double[] data = new double[256];
            for (int i = 0; i < data.Length / 2; i++)
            {
                data[i] = 5;
            }

            using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
            {
                form.ShowDialog( );
            }
            
        }

        private void userButton2_Click( object sender, EventArgs e )
        {
            // 信号二，正弦波叠加，额外增加了一个干扰信号

            double[] data = new double[256];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 5 * Math.Sin( i * Math.PI / 128 ) + 5 + 0.5f * Math.Cos( i * 8 * Math.PI / 128 );
            }

            using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
            {
                form.ShowDialog( );
            }
        }

        private void userButton3_Click( object sender, EventArgs e )
        {
            double[] data = new double[256];
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 140 && i < 160)
                {
                    data[i] = 5;
                }
            }

            using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
            {
                form.ShowDialog( );
            }
        }
    }
}
