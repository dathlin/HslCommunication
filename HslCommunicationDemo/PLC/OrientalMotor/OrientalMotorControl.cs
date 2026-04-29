using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.OrientalMotor;

namespace HslCommunicationDemo.PLC.OrientalMotor
{
	public partial class OrientalMotorControl : UserControl
	{
		public OrientalMotorControl( )
		{
			InitializeComponent( );
		}


		public void SetMotor( OrientalMotorEipNet motor )
		{
			// 这里可以进行一些初始化的操作
			// 例如设置一些默认的值，或者绑定一些事件等
			if ( this.motor != null )
			{
				// 如果之前已经设置过电机，可以在这里进行一些清理工作
				// 例如解绑事件等
				this.motor.OnReceiveData -= Motor_OnReceiveData;
			}

			this.motor = motor;
			this.motor.OnReceiveData += Motor_OnReceiveData;
		}

		private void Motor_OnReceiveData( object sender, OrientalMotorEventArgs e )
		{
			if ( this.motor != null )
			{
				receiveCount++;
				if (checkBox1.Checked == false)
				{
					// 在这里处理接收到的数据，例如更新界面上的显示等
					// 注意：如果需要更新界面，应该使用 Invoke 来确保在 UI 线程上进行操作
					this.Invoke( new Action( ( ) =>
					{
						// 这里可以将接收到的数据转换成字符串或者其他格式来显示
						textBox_times.Text = receiveCount.ToString( );
						textBox_length.Text = e.Content.Length.ToString( );
						textBox_content.Text = e.Content.ToHexString( ' ' );
					} ) );
				}
			}
		}

		private OrientalMotorEipNet motor = null;
		private long receiveCount = 0;
	}

}
