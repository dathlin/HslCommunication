using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormPingIpAddress : HslFormContent
	{
		public FormPingIpAddress( )
		{
			InitializeComponent( );
		}

		private void FormPingIpAddress_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				this.Text = "Ping IP Test Tool";
				label1.Text = "Start IP:";
				label2.Text = "End IP:";
				label4.Text = "Thread Count:";
				button1.Text = "Start Test";
				button2.Text = "Stop Test";
				label5.Text = "Good:";
				label8.Text = "Normal:";
				label10.Text = "Poor:";
				label12.Text = "Bad:";
			}
			else
			{
				label1.Text = "起始IP地址：";
				label2.Text = "结束IP地址：";
				label4.Text = "使用线程数：";
				button1.Text = "开始测试";
				button2.Text = "结束测试";
			}
		}


		/// <summary>
		/// 分析指定IP地址的网络状态
		/// </summary>
		public async Task<NetworkStatusResult> AnalyzeNetworkStatusAsync( IPAddress ipAddress, int pingCount = 10 )
		{
			var result = new NetworkStatusResult { Target = ipAddress.ToString( ) };

			// 发送多次ping请求以获取更准确的结果
			for (int i = 0; i < pingCount; i++)
			{
				using (var ping = new Ping( ))
				{
					var reply = await ping.SendPingAsync( ipAddress, 1000 );
					result.PingReplies.Add( reply );

					// 仅统计成功的ping请求
					if (reply.Status == IPStatus.Success)
					{
						result.TotalSuccess++;
						result.TotalRoundtripTime += reply.RoundtripTime;
					}

					// 添加小延迟避免过于频繁的请求
					await Task.Delay( 100 );
				}
			}

			// 计算统计数据
			result.PacketLossRate = 1.0 - (double)result.TotalSuccess / pingCount;
			if (result.TotalSuccess > 0)
			{
				result.AverageRoundtripTime = result.TotalRoundtripTime / result.TotalSuccess;
			}


			// 根据延迟和丢包率评估网络状态
			result.Status = EvaluateNetworkStatus( result.AverageRoundtripTime, result.PacketLossRate );
			if (result.TotalSuccess == 0) // 如果没有成功的ping请求，则认为网络不可达
			{
				result.Status = NetworkStatus.Bad;
			}

			return result;
		}

		/// <summary>
		/// 根据延迟和丢包率评估网络状态
		/// </summary>
		private NetworkStatus EvaluateNetworkStatus( long averageLatency, double packetLossRate )
		{
			// 评估标准（可根据实际需求调整）
			if (averageLatency < this.latencyGood && packetLossRate < 0.05)
			{
				return NetworkStatus.Good; // 延迟低于50ms且丢包率低于5%
			}
			else if (averageLatency < this.latencyNormal && packetLossRate < 0.15)
			{
				return NetworkStatus.Normal; // 延迟低于150ms且丢包率低于15%
			}
			else
			{
				return NetworkStatus.Poor; // 否则认为网络状态差
			}
		}


		private void button1_Click( object sender, EventArgs e )
		{
			// 开始启动网络状态分析
			// 1. 获取用户输入的IP地址，是一个地址范围
			int[] ip1 = textBox_ip_start.Text.Split( '.' ).Select( s => int.Parse( s ) ).ToArray( );
			int[] ip2 = textBox_ip_stop.Text.Split( '.' ).Select( s => int.Parse( s ) ).ToArray( );

			if (ip1.Length != 4 || ip2.Length != 4)
			{
				MessageBox.Show( "IP地址格式不正确，请输入正确的IP地址格式！" );
				return;
			}
			if (ip1[0] != ip2[0] || ip1[1] != ip2[1])
			{
				MessageBox.Show( "只支持同一网段的IP地址范围，请输入正确的IP地址范围！" );
				return;
			}
			List<PingResult> results = new List<PingResult>( );
			for (int i = ip1[2]; i <= ip2[2]; i++)
			{
				for (int j = ip1[3]; j <= ip2[3]; j++)
				{
					string ipAddress = $"{ip1[0]}.{ip1[1]}.{i}.{j}";
					try
					{
						IPAddress address = IPAddress.Parse( ipAddress );
						var pingResult = new PingResult { IpAddress = ipAddress };
						results.Add( pingResult );
					}
					catch (Exception ex)
					{
						MessageBox.Show( $"解析IP地址 {ipAddress} 时发生错误: {ex.Message}" );
					}
				}
			}

			// 2. 开始多个线程来处理这些IP地址
			int threadCount = 10; // 可以根据实际情况调整线程数
			if (!int.TryParse( textBox_thread_count.Text, out threadCount ) || threadCount <= 0 || threadCount > 10000)
			{
				MessageBox.Show( "线程数必须是正整数，请输入正确的线程数！" );
				return;
			}

			this.latencyGood = int.Parse( textBox1.Text );
			this.latencyNormal = int.Parse( textBox3.Text );

			this.pingResults = results;
			this.threadRunning = true; // 设置线程正在运行的标志
			index = 0;
			dealCount = 0;
			threads = new Thread[threadCount];
			for( int i = 0; i < threadCount; i++ )
			{
				threads[i] = new Thread( new ParameterizedThreadStart( ThreadPing ) );
				threads[i].IsBackground = true;
				threads[i].Start( i );
			}

			button1.Enabled = false;
			button2.Enabled = true;
			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 250; // 每250毫秒更新一次
			timer.Tick +=Timer_Tick;
			timer.Start( );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 强制停止所有线程
			button1.Enabled = true;
			button2.Enabled = false;
			this.threadRunning = false; // 设置线程不再运行的标志
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			pictureBox1.Invalidate( ); // 重绘PictureBox以更新显示
		}

		private int getDealIndex( )
		{
			lock(lockObject)
			{
				if (index < this.pingResults.Count)
				{
					int result = index;
					index++;
					return result;
				}
				return -1;
			}
		}

		private async void ThreadPing( object obj )
		{
			int id = (int)obj;
			while(true)
			{
				int index = getDealIndex( );
				if (index < 0)
				{
					Invoke( new Action( ( ) =>
					{
						textBox2.AppendText( DateTime.Now.ToString( DemoUtils.DateTimeFormate ) + $" Thread[{id}] finish" + Environment.NewLine );
						if (Interlocked.Increment( ref dealCount ) >= threads.Length)
						{
							textBox2.AppendText( DateTime.Now.ToString( DemoUtils.DateTimeFormate ) + $" All task finish" + Environment.NewLine );
							timer?.Stop( );
							pictureBox1.Invalidate( ); // 重绘PictureBox以更新显示
							button1.Enabled = true;
							button2.Enabled = false;
						}
					} ) );
					return;
				}

				if (this.threadRunning == false)
				{
					Invoke( new Action( ( ) =>
					{
						textBox2.AppendText( DateTime.Now.ToString( DemoUtils.DateTimeFormate ) + $" Thread[{id}] stop" + Environment.NewLine );
					} ) );
					return;
				}

				PingResult pingResult = pingResults[index];
				DateTime start = DateTime.Now;

				pingResult.NetworkStatus = await AnalyzeNetworkStatusAsync( IPAddress.Parse( pingResult.IpAddress ), 4 );
				Invoke( new Action( ( ) =>
				{
					// (DateTime.Now - start).TotalMilliseconds.ToString("F0")
					textBox2.AppendText( DateTime.Now.ToString( DemoUtils.DateTimeFormate ) + $" Thread[{id}] deal ip: {pingResult.IpAddress}  Avg-Time: {pingResult.NetworkStatus.AverageRoundtripTime}ms LossRate:{(pingResult.NetworkStatus.PacketLossRate*100):F2}%" + Environment.NewLine );
				} ) );
			}
		}



		private List<PingResult> pingResults = new List<PingResult>( );
		private Thread[] threads = null;
		private object lockObject = new object( );
		private int index = 0;
		private int dealCount = 0;
		private System.Windows.Forms.Timer timer;
		private int latencyGood = 50;
		private int latencyNormal = 150;
		private bool threadRunning = false; // 是否正在运行线程

		private void pictureBox1_Paint( object sender, PaintEventArgs e )
		{
			// 0.250
			int item_width = 50;
			int item_height = 20;

			int x = 0;
			int y = 0;
			int total = this.pingResults.Count;
			for (int i = 0; i < total; i++)
			{
				PingResult pingResult = this.pingResults[i];
				// 绘制每个IP地址的状态
				Color color;
				if (pingResult.NetworkStatus == null) color = Color.WhiteSmoke;
				else
				{
					switch (pingResult.NetworkStatus.Status)
					{
						case NetworkStatus.Good:
							color = Color.LimeGreen;
							break;
						case NetworkStatus.Normal:
							color = Color.Yellow;
							break;
						case NetworkStatus.Poor:
							color = Color.Pink;
							break;
						case NetworkStatus.Bad:
							color = Color.Tomato;
							break;
						default:
							color = Color.WhiteSmoke;
							break;
					}
				}
				e.Graphics.FillRectangle( new SolidBrush( color ), x, y, item_width, item_height );
				if (pingResult.NetworkStatus == null)
					e.Graphics.DrawRectangle( Pens.LightGray, x, y, item_width - 1, item_height - 1 );
				else
					e.Graphics.DrawRectangle( Pens.Gray, x, y, item_width - 1, item_height - 1 );

				e.Graphics.DrawString( Regex.Match( pingResult.IpAddress, @"[0-9]+\.[0-9]+$" ).Value, this.Font, Brushes.Black, 
					new RectangleF( x, y, item_width, item_height ), HslControls.HslHelper.StringFormatCenter );

				x += item_width + 2; // +2是为了留出一点间距
				if (x >= (pictureBox1.Width - item_width - 2))
				{
					x = 0;
					y += item_height + 2; // +2是为了留出一点间距
				}
			}
		}

		private void panel2_Resize( object sender, EventArgs e )
		{
			pictureBox1.Invalidate( );
		}

		#region XML Save Load

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip_start.Text );
			element.SetAttributeValue( "IpAddress2", textBox_ip_stop.Text );
			element.SetAttributeValue( "ThreadCount", textBox_thread_count.Text );
			element.SetAttributeValue( "RoundtripTime1", textBox1.Text );
			element.SetAttributeValue( "RoundtripTime2", textBox3.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip_start.Text = GetXmlValue( element, DemoDeviceList.XmlIpAddress, "192.168.0.1", m => m );
			textBox_ip_stop.Text = GetXmlValue( element, "IpAddress2", "192.168.0.255", m => m );
			textBox_thread_count.Text = GetXmlValue( element, "ThreadCount", "10", m => m );
			textBox1.Text = GetXmlValue( element, "RoundtripTime1", "50", m => m );
			textBox3.Text = GetXmlValue( element, "RoundtripTime2", "150", m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		#endregion

	}

	public class PingResult
	{
		public string IpAddress { get; set; }

		/// <summary>
		/// 为NULL则表示还没有结果
		/// </summary>
		public NetworkStatusResult NetworkStatus { get; set; }
	}

	/// <summary>
	/// 网络状态结果
	/// </summary>
	public class NetworkStatusResult
	{
		public string Target { get; set; }
		public long AverageRoundtripTime { get; set; }
		public double PacketLossRate { get; set; }
		public int TotalSuccess { get; set; }
		public long TotalRoundtripTime { get; set; }
		public NetworkStatus Status { get; set; }
		public System.Collections.Generic.List<PingReply> PingReplies { get; } = new System.Collections.Generic.List<PingReply>( );
	}

	/// <summary>
	/// 网络状态等级
	/// </summary>
	public enum NetworkStatus
	{
		Good,     // 好
		Normal,   // 一般
		Poor,     // 差
		Bad,      // 不可达
	}
}
