using HslControls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
				userButton1.Text = "专用图形";
				userButton2.Text = "专用图形";
				userButton3.Text = "专用图形";
			}
			else
			{
				Text = "FFT Test";
				label5.Text = "FFT Fast discrete Fourier transform";
				label1.Text = "The waveform of the square sweep and the transformed";
				label3.Text = "Waveform after sine wave and transform";
				label6.Text = "Waveform after mixed sweep and transform";
				userButton1.Text = "Graphics";
				userButton2.Text = "Graphics";
				userButton3.Text = "Graphics";
			}
		}

		private void Squarewave( )
		{
			// 信号一，方波信号
			double[] data = GetWave1( );

			userCurve1.SetCurve( key: "A", 0, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f, CurveStyle.Curve );

			double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );
			
			userCurve2.ReferenceAxisLeft.Max = (float)trans.Max( );
			userCurve2.ReferenceAxisRight.Max = (float)trans.Max( );
			userCurve2.SetCurve( key: "A", 0, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f, CurveStyle.Curve );
		}

		private void Sinawave( )
		{
			// 信号二，正弦波叠加，额外增加了一个干扰信号

			double[] data = GetWave2( );

			userCurve4.SetCurve( key: "A", 0, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f, CurveStyle.Curve );

			double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );

			userCurve3.ReferenceAxisLeft.Max = (float)trans.Max( );
			userCurve3.ReferenceAxisRight.Max = (float)trans.Max( );
			userCurve3.SetCurve( key: "A", 0, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f, CurveStyle.Curve );

		}

		private void Others()
		{
			// 信号三，阶跃信号
			double[] data = GetWave3( );

			userCurve6.SetCurve( key: "A", 0, data: data.Select( m => (float)m ).ToArray( ), lineColor: Color.Red, thickness: 1f, CurveStyle.Curve );

			double[] trans = HslCommunication.Algorithms.Fourier.FFTHelper.FFT( data );

			userCurve5.ReferenceAxisLeft.Max = (float)trans.Max( );
			userCurve5.ReferenceAxisRight.Max = (float)trans.Max( );
			userCurve5.SetCurve( key: "A", 0, data: trans.Select( m => (float)m ).ToArray( ), lineColor: Color.Blue, thickness: 1f, CurveStyle.Curve );
		}

		private void userButton1_Click( object sender, EventArgs e )
		{
			double[] data = GetWave1( );

			using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
			{
				form.ShowDialog( );
			}
			
		}

		private void userButton2_Click( object sender, EventArgs e )
		{
			double[] data = GetWave2( );

			using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
			{
				form.ShowDialog( );
			}
		}

		private void userButton3_Click( object sender, EventArgs e )
		{
			double[] data = GetWave3( );

			using (FormImage form = new FormImage( HslCommunication.Algorithms.Fourier.FFTHelper.GetFFTImage( data, 1000, 600, Color.Blue ) ))
			{
				form.ShowDialog( );
			}
		}

		private void userButton6_Click( object sender, EventArgs e )
		{
			// 信号1的逆变操作
			try
			{
				float[] value = HslCommunication.Algorithms.Fourier.FFTFilter.FilterFFT( GetWave1( ), double.Parse( textBox_curve1.Text ) ).Select( m => (float)m ).ToArray( );
				userCurve1.SetLeftCurve( "滤波数据", value, Color.DodgerBlue );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "数据输入错误！" + ex.Message );
			}
		}
		private void userButton5_Click( object sender, EventArgs e )
		{
			// 信号2的逆变操作
			try
			{
				float[] value = HslCommunication.Algorithms.Fourier.FFTFilter.FilterFFT( GetWave2( ), double.Parse( textBox_curve2.Text ) ).Select( m => (float)m ).ToArray( );
				userCurve4.SetLeftCurve( "滤波数据", value, Color.DodgerBlue );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "数据输入错误！" + ex.Message );
			}
		}
		private void userButton4_Click( object sender, EventArgs e )
		{
			// 信号3的逆变操作
			try
			{
				float[] value = HslCommunication.Algorithms.Fourier.FFTFilter.FilterFFT( GetWave3( ), double.Parse( textBox_curve3.Text ) ).Select( m => (float)m ).ToArray( );
				userCurve6.SetLeftCurve( "滤波数据", value, Color.DodgerBlue );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "数据输入错误！" + ex.Message );
			}
		}

		private double[] GetWave1( )
		{
			// 信号一，方波信号
			double[] data = new double[256];
			for (int i = 0; i < data.Length / 2; i++)
			{
				data[i] = 5;
			}
			return data;
		}

		private double[] GetWave2( )
		{
			// 信号二，正弦波叠加，额外增加了一个干扰信号

			double[] data = new double[256];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = 6 * Math.Sin( i * Math.PI / 128 ) + 5 + 0.5f * Math.Cos( i * 8 * Math.PI / 128 );
			}
			return data;
		}

		private double[] GetWave3( )
		{
			// 信号三，阶跃信号
			double[] data = new double[256];
			for (int i = 0; i < data.Length; i++)
			{
				if (i > 140 && i < 160)
				{
					data[i] = -5;
				}
			}
			return data;
		}

	}
}
