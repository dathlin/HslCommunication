using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.LogNet;

namespace HslCommunicationDemo
{
	public partial class FormLogNet : HslFormContent
	{
		public FormLogNet()
		{
			InitializeComponent( );
		}

		#region ILogNet


		private void FormLogNet_Load( object sender, EventArgs e )
		{
			logNet = new LogNetSingle( "log.txt" ); 
			// logNet = new LogNetDateTime( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Logs" ), GenerateMode.ByEveryDay, 10 );
			comboBox1.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslMessageDegree>( );
			comboBox1.SelectedItem = HslMessageDegree.DEBUG;
			comboBox2.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslMessageDegree>( );
			comboBox2.SelectedItem = HslMessageDegree.DEBUG;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

			logNet.FiltrateKeyword( "123" );  // 过滤关键字123的存储
			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			if (Program.Language == 2)
			{
				label1.Text = "Log Degree:";
				label6.Text = "Save Degree:";
				label2.Text = "Time Offset:";
				button_hour_offset.Text = "Set";
				label3.Text = "KeyWord:";
				checkBox1.Text = "Cancel Save?";
				label4.Text = "Message:";
				button3.Text = "Load File";
				button4.Text = "Clear File";
				button8.Text = "LogViewer";
				label5.Text = "Content:";
				label9.Text = "Code:";

				button1.Text = "w-Message";
				button5.Text = "w-NewLine";
				button6.Text = "w-Description";
				button7.Text = "w-Exception";
				button9.Text = "Raise Exception";
			}

			textBox_code.Text = $"ILogNet logNet = new LogNetSingle( \"log.txt\" );  // 如果传入 string.Empty 则不存文件";
		}

		private void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
		{
			if(e.ExceptionObject is Exception ex)
			{
				logNet?.WriteException( "UnhandledException", ex );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			e.HslMessage.Cancel = checkBox1.Checked;
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			HslMessageDegree degree = (HslMessageDegree)comboBox2.SelectedItem;
			logNet.SetMessageDegree( degree );
		}

		private ILogNet logNet;               // 日志

		private void button1_Click( object sender, EventArgs e )
		{
			// 写日志
			HslMessageDegree degree = (HslMessageDegree)comboBox1.SelectedItem;

			// 两种方法，第一种
			logNet.RecordMessage( degree, textBox1.Text, textBox2.Text );

			// 第二种
			//if(degree == HslMessageDegree.DEBUG)
			//{
			//    logNet.WriteDebug( textBox1.Text, textBox2.Text );
			//}
			//else if(degree == HslMessageDegree.INFO)
			//{
			//    logNet.WriteInfo( textBox1.Text, textBox2.Text );
			//}
			//else if(degree == HslMessageDegree.WARN)
			//{
			//    logNet.WriteWarn( textBox1.Text, textBox2.Text );
			//}
			//else if (degree == HslMessageDegree.ERROR)
			//{
			//    logNet.WriteError( textBox1.Text, textBox2.Text );
			//}
			//else if (degree == HslMessageDegree.FATAL)
			//{
			//    logNet.WriteFatal( textBox1.Text, textBox2.Text );
			//}

			textBox_code.Text = $"logNet.RecordMessage( HslMessageDegree.{degree}, \"{textBox1.Text}\", \"{textBox2.Text}\" );";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			logNet.WriteNewLine( );

			textBox_code.Text = "logNet.WriteNewLine( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			logNet.WriteDescrition( textBox2.Text );

			textBox_code.Text = $"logNet.WriteDescrition( \"{textBox2.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			try
			{
				int i = 0;
				int j = 100 / i;
			}
			catch(Exception ex)
			{
				logNet.WriteException( textBox1.Text, ex );

				textBox_code.Text = $"logNet.WriteException( \"{textBox1.Text}\", ex );";
			}
		}

		private int threadCount = 3;
		private void button2_Click( object sender, EventArgs e )
		{
			threadCount = 3;
			// 100万条日志写入测试
			for (int i = 0; i < threadCount; i++)
			{
				new System.Threading.Thread( new System.Threading.ThreadStart( ThreadLogTest ) )
				{
					IsBackground = true,
				}.Start( );
			}
			
			button2.Enabled = false;
		}

		private void ThreadLogTest()
		{
			DateTime start = DateTime.Now;
			for (int i = 0; i < 330000; i++)
			{
				logNet.WriteInfo( "key", "这是一条测试日志" );
			}

			TimeSpan ts = DateTime.Now - start;

			if (Interlocked.Decrement(ref threadCount) == 0)
			{
				Invoke( new Action( ( ) =>
				{
					MessageBox.Show( "完成！耗时：" + ts.TotalMilliseconds.ToString( "F3" ) + " 毫秒" );
					button2.Enabled = true;
				} ) );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if (System.IO.File.Exists( "log.txt" ))
			{
				// 显示日志信息
				using (System.IO.StreamReader sr = new System.IO.StreamReader( "log.txt", Encoding.UTF8 ))
				{
					textBox3.Text = sr.ReadToEnd( );
				}
			}
			else
			{
				MessageBox.Show( StringResources.Language.FileNotExist );
			}

			textBox_code.Text = $"string content = File.ReadAllText( \"log.txt\", Encoding.UTF8 );";
		}


		#endregion

		private void button4_Click( object sender, EventArgs e )
		{
			// 清空文件
			System.IO.File.WriteAllBytes( "log.txt", new byte[0] );

			textBox_code.Text = "System.IO.File.WriteAllBytes( \"log.txt\", new byte[0] );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			if (File.Exists( "log.txt" ))
			{
				using (FormLogNetView form = new FormLogNetView( "log.txt" ))
				{
					form.OpenDialogDefaultPath = Application.StartupPath;        // 如果需要指定默认的打开文件的路径
					form.ShowDialog( );
				}
			}
			else
			{
				using (FormLogNetView form = new FormLogNetView( ))
				{
					form.ShowDialog( );
				}
			}

			textBox_code.Text = @"using (FormLogNetView form = new FormLogNetView( ""log.txt"" ))
{
	form.OpenDialogDefaultPath = Application.StartupPath;        // 如果需要指定默认的打开文件的路径
	form.ShowDialog( );
}";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			FormSiemensFW formSiemensFW = null;
			formSiemensFW.AcceptButton = button1;
		}

		private void button_hour_offset_Click( object sender, EventArgs e )
		{
			logNet.HourDeviation = int.Parse( textBox_hour_offset.Text );
			MessageBox.Show( "Finish" );
		}
	}
}
