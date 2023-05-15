using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Core.Net;
using HslCommunication;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteServer : UserControl
	{
		public UserControlReadWriteServer( )
		{
			InitializeComponent( );
		}


		private System.Windows.Forms.Timer timerSecond;

		public void SetReadWriteServer( NetworkDataServerBase dataServerBase, string address, int strLength = 10 )
		{
			this.dataServerBase = dataServerBase;
			this.dataServerBase.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
			this.dataServerBase.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			userControlReadWriteOp1.SetReadWriteNet( dataServerBase, address, false, strLength );

			timerSecond?.Dispose( );
			timerSecond = new System.Windows.Forms.Timer( );
			timerSecond.Interval = 1000;
			timerSecond.Tick += TimerSecond_Tick;
			timerSecond.Start( );
		}

		private void TimerSecond_Tick( object sender, EventArgs e )
		{
			label15.Text = dataServerBase.OnlineCount.ToString( );
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			if (!checkBox1.Checked) return;

			try
			{
				if (InvokeRequired)
				{
					Invoke( new Action<object, HslCommunication.LogNet.HslEventArgs>( LogNet_BeforeSaveToFile ), sender, e );
					return;
				}

				if (textBox1.TextLength > 1000_000) textBox1.Clear( );
				textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			}
			catch
			{
				return;
			}
		}

		NetworkDataServerBase dataServerBase;

		private void UserControlReadWriteServer_Load( object sender, EventArgs e )
		{

			if (Program.Language == 2)
			{
				button8.Text = "Load";
				button9.Text = "Save";
				button10.Text = "Timed writing";
				checkBox1.Text = "Display log data?";
				label16.Text = "Client-Online:";
				button1.Text = "Connecting Alien client";
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 从文件加载服务器的数据池
			if (dataServerBase != null)
			{
				using(OpenFileDialog ofd = new OpenFileDialog( ))
				{
					if (ofd.ShowDialog() == DialogResult.OK)
					{
						if (System.IO.File.Exists( ofd.FileName ))
						{
							try
							{
								dataServerBase.LoadDataPool( ofd.FileName );
								MessageBox.Show( "Load data finish" );
							}
							catch (Exception ex)
							{
								MessageBox.Show( "Load failed: " + ex.Message );
							}
						}
						else
						{
							MessageBox.Show( $"File[{ofd.FileName}] is not exist！" );
						}
					}
				}
			}
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 将服务器的数据池存储起来
			if (dataServerBase != null)
			{
				using (SaveFileDialog sfd = new SaveFileDialog( ))
				{
					sfd.FileName = "123.txt";
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						try
						{
							dataServerBase.SaveDataPool( sfd.FileName );
							MessageBox.Show( "Save file finish!" );
						}
						catch (Exception ex)
						{
							MessageBox.Show( "Save failed: " + ex.Message );
						}
					}
				}
			}
		}


		private Random random = new Random( );
		private string timerAddress = string.Empty;
		private long timerValue = 0;
		private Timer timerWrite = null;
		private bool timeWriteEnable = false;

		private void button10_Click( object sender, EventArgs e )
		{
			if (timeWriteEnable)
			{
				// 停止定时器
				timeWriteEnable = false;
				timerWrite?.Dispose( );
				button10.Text = Program.Language == 2 ? "Timed writing" : "定时写";
			}
			else
			{
				// 启动定时器
				timeWriteEnable = true;
				timerWrite = new Timer( );
				timerWrite.Interval = 300;
				timerWrite.Tick += TimerWrite_Tick;
				timerWrite.Start( );
				timerAddress = userControlReadWriteOp1.GetWriteAddress( );
				button10.Text = Program.Language == 2 ? "Stop Timer" : "停止写入";
			}
		}

		private void TimerWrite_Tick( object sender, EventArgs e )
		{
			ushort value = (ushort)(Math.Sin( 2 * Math.PI * timerValue / 100 ) * 100 + 100);
			dataServerBase.Write( timerAddress, value );
			timerValue++;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接异形客户端
			using (FormInputAlien form = new FormInputAlien( ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					OperateResult connect = dataServerBase.ConnectHslAlientClient( form.IpAddress, form.Port, form.DTU, form.Pwd );
					if (connect.IsSuccess)
					{
						MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					}
					else
					{
						MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
					}
				}
			}
		}
	}
}
