using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Geniitek;
using HslCommunication;
using System.Threading;
using HslCommunication.BasicFramework;

namespace HslCommunicationDemo
{
	#region VibrationSensor


	public partial class FormVibrationSensorClient : HslFormContent
	{
		public FormVibrationSensorClient( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "VibrationSensor Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private VibrationSensorClient client;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if(!ushort.TryParse(textBox5.Text, out ushort station ))
			{
				MessageBox.Show( "Address input wrong!" );
				return;
			}

			client?.ConnectClose( );
			client = new VibrationSensorClient( textBox1.Text, port );
			client.Address = station;
			client.LogNet = new HslCommunication.LogNet.LogNetSingle( string.Empty );
			client.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			client.OnPeekValueReceive += Client_OnPeekValueReceive;
			client.OnActualValueReceive += Client_OnActualValueReceive;
			client.OnNetworkError += WsClient_OnNetworkError;
			OperateResult connect = client.ConnectServer( );
			if (connect.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
			}
		}

		int receiveCount = 0;
		long receiveTotalCount = 0;
		SharpList<VibrationSensorActualValue> actValues = new SharpList<VibrationSensorActualValue>( 1024 );

		private void Client_OnActualValueReceive( VibrationSensorActualValue actualValue )
		{
			// 每秒4000个数据
			receiveCount++;
			receiveTotalCount++;
			actValues.Add( actualValue );
			if (receiveCount == 4096)
			{
				Invoke( new Action( ( ) =>
				 {
					 textBox19.Text = actualValue.AcceleratedSpeedX.ToString( );
					 textBox18.Text = actualValue.AcceleratedSpeedY.ToString( );
					 textBox17.Text = actualValue.AcceleratedSpeedZ.ToString( );
					 textBox20.Text = receiveTotalCount.ToString( );
				 } ) );
				receiveCount = 0;
			}
		}

		private void Client_OnPeekValueReceive( VibrationSensorPeekValue peekValue )
		{
			// 显示出来
			if (InvokeRequired)
			{
				Invoke( new Action<VibrationSensorPeekValue>( Client_OnPeekValueReceive ), peekValue );
				return;
			}

			textBox4.Text      = peekValue.AcceleratedSpeedX.ToString( );
			textBox6.Text      = peekValue.AcceleratedSpeedY.ToString( );
			textBox7.Text      = peekValue.AcceleratedSpeedZ.ToString( );

			textBox11.Text     = peekValue.SpeedX.ToString( );
			textBox10.Text     = peekValue.SpeedY.ToString( );
			textBox9.Text      = peekValue.SpeedZ.ToString( );

			textBox14.Text     = peekValue.OffsetX.ToString( );
			textBox13.Text     = peekValue.OffsetY.ToString( );
			textBox12.Text     = peekValue.OffsetZ.ToString( );

			textBox16.Text     = peekValue.Temperature.ToString( );
			textBox15.Text     = peekValue.Voltage.ToString( );
		}

		private void WsClient_OnNetworkError( object sender, EventArgs e )
		{
			// 当网络异常的时候触发，可以在此处重连服务器
			if (sender is VibrationSensorClient client)
			{
				// 开始重连服务器，直到连接成功为止
				client.LogNet?.WriteInfo( "网络异常，准备10秒后重新连接。" );
				while (true)
				{
					// 每隔10秒重连
					System.Threading.Thread.Sleep( 10_000 );
					client.LogNet?.WriteInfo( "准备重新连接服务器..." );
					OperateResult connect = client.ConnectServer( );
					if (connect.IsSuccess)
					{
						// 连接成功后，可以在下方break之前进行订阅，或是数据初始化操作
						client.LogNet?.WriteInfo( "连接服务器成功！" );
						break;
					}
					client.LogNet?.WriteInfo( "连接失败，准备10秒后重新连接。" );
				}
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			try
			{
				Invoke( new Action( ( ) =>
				 {
						textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				 } ) );
			}
			catch
			{

			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			client?.ConnectClose( );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult send = client.SetReadStatus( );

			if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );

			textBox_code.Text = $"OperateResult send = client.SetReadStatus( );";
		}



		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 切换读取实时的数据信息
			OperateResult send = client.SetReadActual( );

			if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );

			textBox_code.Text = $"OperateResult send = client.SetReadActual( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 设置间隔时间
			if(int.TryParse(textBox3.Text, out int seconds ))
			{
				OperateResult send = client.SetReadStatusInterval( seconds );

				if (!send.IsSuccess) MessageBox.Show( "Send Failed:" + send.Message );
				else
				{
					MessageBox.Show( "Success" );
				}

				textBox_code.Text = $"OperateResult send = client.SetReadStatusInterval( {seconds} );";
			}
		}
	}

	#endregion
}
