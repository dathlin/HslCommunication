using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Core.Device;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using HslCommunication.ModBus;

namespace HslCommunicationDemo.Modbus
{
	public partial class StationSearchControl : UserControl
	{
		public StationSearchControl( )
		{
			InitializeComponent( );
		}

		public void SetModbus( IModbus modbus )
		{
			this.modbus = modbus;

		}


		/// <summary>
		/// 获取标题信息
		/// </summary>
		/// <returns></returns>
		public static string GetTitle( ) => Program.Language == 1 ? "站号搜索" : "Station Search";



		private IModbus modbus = null;
		private int stationStart = 0; // 站号从0开始
		private int stationStop = 255; // 站号到255结束
		private int receiveTimeout = 500; // 接收超时1秒钟
		private string address = "0";
		private int length = 1; // 读取一个寄存器
		private bool isWordRead = true; // 是否是字读取的方式，默认是字读取
		private Thread thread;
		private bool isRunning = false; // 是否正在运行中

		private void button_start_Click( object sender, EventArgs e )
		{
			// 开始搜索站号
			try
			{
				stationStart = int.Parse( textBox_station_start.Text );
				stationStop = int.Parse( textBox_station_stop.Text );
				receiveTimeout = int.Parse( textBox_timeout.Text );
				address = textBox_address.Text;
				length = int.Parse( textBox_length.Text );
				isWordRead = radioButton_word.Checked;

				if ( stationStart < 0 || stationStart > 255 || stationStop < 0 || stationStop > 255 || stationStart > stationStop )
				{
					if (Program.Language == 1)
						DemoUtils.ShowMessage( "站号范围错误，必须在0-255之间，且起始站号小于结束站号！" );
					else
						DemoUtils.ShowMessage( "The station number range is incorrect. It must be between 0 and 255, and the starting station number is smaller than the ending station number!" );
					return;
				}
				isRunning = true;
				thread = new Thread( ThreadSearchStation );
				thread.IsBackground = true;
				thread.Start( );
			}
			catch( Exception ex )
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "错误，相关的参数输入异常：" + ex.Message );
				else
					DemoUtils.ShowMessage( "Error: Abnormal input of relevant parameters" + ex.Message );
				return;
			}
			textBox_log.Clear( );
			textBox_match.Clear( );


			button_start.Enabled = false;
			button_stop.Enabled = true;
		}

		private void button_stop_Click( object sender, EventArgs e )
		{
			// 停止搜索站号

			isRunning = false;
			button_start.Enabled = true;
			button_stop.Enabled = false;
		}

		private string getString1()
		{
			if (Program.Language == 1)
				return "检测站号中断";
			else
				return "Station number check is interrupted";
		}

		private string getString2( )
		{
			if (Program.Language == 1)
				return "正在检测站号: ";
			else
				return "Checking Station: ";
		}

		private string getString3( )
		{
			if (Program.Language == 1)
				return " 有响应";
			else
				return " Response";
		}

		private string getString4( )
		{
			if (Program.Language == 1)
				return " 没有响应";
			else
				return " None response"; 
		}

		private string getString5( )
		{
			if (Program.Language == 1)
				return "检测站号结束";
			else
				return "Station check is over";
		}

		private void ThreadSearchStation( )
		{
			int station = stationStart;
			BinaryCommunication binaryCommunication = modbus as BinaryCommunication;
			if (binaryCommunication == null)
			{
				Invoke( new Action( ( ) =>
				{
					if (Program.Language == 1)
						textBox_log.AppendText( "设备类型不正确，无法转为 BinaryCommunication 类，准备结束。" + Environment.NewLine );
					else
						textBox_log.AppendText( "The device type is incorrect and cannot be converted to the BinaryCommunication class. Prepare to end." + Environment.NewLine );
					button_stop_Click( null, EventArgs.Empty );
				} ) );
				return;
			}

			byte stationOld = modbus.Station;
			int receiveTimeOutOld = binaryCommunication.ReceiveTimeOut;
			binaryCommunication.ReceiveTimeOut = this.receiveTimeout;

			if (binaryCommunication.CommunicationPipe is PipeTcpNet pipeTcpNet)
			{
				pipeTcpNet.CloseOnRecvTimeOutTick = 10000;
			}

			while (true)
			{
				if (isRunning == false)
				{
					textBox_log.AppendText( getString1( ) + Environment.NewLine );
					if (binaryCommunication.CommunicationPipe is PipeTcpNet pipeTcpNet2)
					{
						pipeTcpNet2.CloseOnRecvTimeOutTick = 1;
					}
					binaryCommunication.ReceiveTimeOut = receiveTimeOutOld;
					modbus.Station = stationOld; // 恢复站号
					return;
				}

				Invoke( new Action( ( ) =>
				{
					textBox_log.AppendText( getString2( ) + station + " ...." );
				} ) );

				modbus.Station = (byte)station;
				if (isWordRead)
				{
					OperateResult<byte[]> read = modbus.Read( address, (ushort)length );
					if (read.IsSuccess)
					{
						Invoke( new Action( ( ) =>
						{
							textBox_log.AppendText( getString3( ) + Environment.NewLine );
							if (Program.Language == 1)
								textBox_match.AppendText( $"站号:{station} 有响应数据：" + read.Content.ToHexString( ' ' ) + Environment.NewLine );
							else
								textBox_match.AppendText( $"Station:{station} Response data：" + read.Content.ToHexString( ' ' ) + Environment.NewLine );

							if (checkBox_stop_match.Checked)
							{
								textBox_log.AppendText( getString5( ) + Environment.NewLine );
								button_stop_Click( null, EventArgs.Empty );
								if (binaryCommunication.CommunicationPipe is PipeTcpNet pipeTcpNet2)
								{
									pipeTcpNet2.CloseOnRecvTimeOutTick = 1;
								}
								binaryCommunication.ReceiveTimeOut = receiveTimeOutOld;
								modbus.Station = stationOld; // 恢复站号
							}
						} ) );						
						HslHelper.ThreadSleep( 200 );
						if (checkBox_stop_match.Checked) return;
					}
					else
					{
						Invoke( new Action( ( ) =>
						{
							textBox_log.AppendText( getString4( ) + Environment.NewLine );
						} ) );
					}
				}
				else
				{
					OperateResult<bool[]> read = modbus.ReadBool( address, (ushort)length );
					if (read.IsSuccess)
					{
						Invoke( new Action( ( ) =>
						{
							textBox_log.AppendText( getString3( ) + Environment.NewLine );
							if (Program.Language == 1)
								textBox_match.AppendText( $"站号:{station} 有响应数据：" + read.Content.ToArrayString( ) + Environment.NewLine );
							else
								textBox_match.AppendText( $"Station:{station} Response data：" + read.Content.ToArrayString( ) + Environment.NewLine );
							if (checkBox_stop_match.Checked)
							{
								textBox_log.AppendText( getString5( ) + Environment.NewLine );
								button_stop_Click( null, EventArgs.Empty );
								if (binaryCommunication.CommunicationPipe is PipeTcpNet pipeTcpNet2)
								{
									pipeTcpNet2.CloseOnRecvTimeOutTick = 1;
								}
								binaryCommunication.ReceiveTimeOut = receiveTimeOutOld;
								modbus.Station = stationOld; // 恢复站号
							}
						} ) );
						HslHelper.ThreadSleep( 200 );
						if (checkBox_stop_match.Checked) return;
					}
					else
					{
						Invoke( new Action( ( ) =>
						{
							textBox_log.AppendText( getString4( ) + Environment.NewLine );
						} ) );
					}
				}
				station++;
				if (station > stationStop)
				{
					Invoke( new Action( ( ) =>
					{
						textBox_log.AppendText( getString5( ) + Environment.NewLine );
						button_stop_Click( null, EventArgs.Empty );
						if (binaryCommunication.CommunicationPipe is PipeTcpNet pipeTcpNet2)
						{
							pipeTcpNet2.CloseOnRecvTimeOutTick = 1;
						}
						binaryCommunication.ReceiveTimeOut = receiveTimeOutOld;
						modbus.Station = stationOld; // 恢复站号
					} ) );
					return;
				}
			}
		}

		private void StationSearchControl_Load( object sender, EventArgs e )
		{
			if( Program.Language == 2 )
			{
				label1.Text = "Station Start:";
				label2.Text = "Station Stop:";
				label3.Text = "ReceiveTimeout:";
				checkBox_stop_match.Text = "Stop if match?";
				button_start.Text = "Start";
				button_stop.Text = "Stop";
				label4.Text = "Read Address:";
				label5.Text = "Read Length:";
				label6.Text = "Log:";
				label7.Text = "Match Staion:";
				radioButton_bool.Text = "Bool Read";
				radioButton_word.Text = "Word Read";
			}
		}
	}
}
