using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.EFORT;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Robot
{
	public partial class FormEfort : HslFormContent
	{
		public FormEfort( )
		{
			InitializeComponent( );
		}

		private void FormEfort_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			threadRead = new System.Threading.Thread( ThreadReadRobot );
			threadRead.IsBackground = true;
			threadRead.Start( );


			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}
		protected CodeExampleControl codeExampleControl;

		private void RenderErrorMessage(string msg )
		{
			if(InvokeRequired)
			{
				try
				{
					Invoke( new Action<string>( RenderErrorMessage ), msg );
				}
				catch
				{

				}
				return;
			}


			label74.Text = "异常消息：[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + "] " + msg;
			label74.BackColor = Color.Blue;
			System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( Reset ), null );

		}


		private void Reset( object obj )
		{
			System.Threading.Thread.Sleep( 2000 );
			label74.Invoke( new Action( ( ) =>
			{
				label74.BackColor = Color.Transparent;
			} ) );
		}


		private ER7BC10 efortRobot;

		protected virtual async void button1_Click( object sender, EventArgs e )
		{
			try
			{
				// 连接
				efortRobot = new ER7BC10( textBox1.Text, int.Parse( textBox2.Text ) );
				efortRobot.ConnectTimeOut = 2000;

				OperateResult connect = await efortRobot.ConnectServerAsync( );
				if(connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					// 设置示例代码
					codeExampleControl.SetCodeText( "robot", efortRobot );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
				}
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		protected virtual void button2_Click( object sender, EventArgs e )
		{
			isReadPlc = false;
			efortRobot?.ConnectClose( );
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
			threadRead?.Abort( );
			button3.Enabled = true;
		}

		protected virtual OperateResult<EfortData> ReadFromRobot( )
		{
			return efortRobot.ReadEfortData( );
		}

		private void button_read_short_Click( object sender, EventArgs e )
		{
			// 刷新数据
			OperateResult<EfortData> read = ReadFromRobot( );
			if(!read.IsSuccess)
			{
				MessageBox.Show( "读取失败！" + read.Message );
			}
			else
			{
				efortRobotControl1.RenderRobotData( read.Content );
			}
		}


		private void ThreadReadRobot( )
		{
			while(true)
			{
				System.Threading.Thread.Sleep( timeSpeep );
				if (isReadPlc)
				{
					OperateResult<EfortData> read = ReadFromRobot( );
					if (read.IsSuccess)
					{
						efortRobotControl1.RenderRobotData( read.Content );
					}
					else
					{
						RenderErrorMessage( read.Message );
					}
				}
			}
		}


		private System.Threading.Thread threadRead;
		private int timeSpeep = 1000;
		private bool isReadPlc = false;

		private void button3_Click( object sender, EventArgs e )
		{
			try
			{
				// 定时读取
				timeSpeep = int.Parse( textBox3.Text );
				isReadPlc = true;
				button3.Enabled = false;
			}
			catch(Exception ex)
			{
				// 因为有可能时间文本的格式输入错误
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
