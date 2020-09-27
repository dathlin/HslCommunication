using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet.Redis;
using HslCommunication;

namespace HslCommunicationDemo
{
	#region FormSimplifyNet


	public partial class FormRedisSubscribe : HslFormContent
	{
		public FormRedisSubscribe( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			if(Program.Language == 2)
			{
				label1.Text = "IP:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "DisConnect";
				label6.Text = "Password";
				label7.Text = "Keyword: all input is batch subscription";
				button3.Text = "Subscribe";
				button4.Text = "UnSubscribe";
				label12.Text = "Time:";
				label10.Text = "Count:";
				label9.Text = "Data:";
			}
		}
		

		private RedisSubscribe redisSubscribe = null;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				redisSubscribe = new RedisSubscribe( textBox1.Text, int.Parse( textBox2.Text ) );
				redisSubscribe.Password = textBox3.Text;
				redisSubscribe.OnRedisMessageReceived += RedisSubscribe_OnRedisMessageReceived;
			}
			catch(Exception ex)
			{
				MessageBox.Show( "输入错误：" + ex.Message );
				return;
			}
			OperateResult connect = redisSubscribe.ConnectServer( );

			if(connect.IsSuccess)
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

		private void RedisSubscribe_OnRedisMessageReceived( string topic, string message )
		{
			ShowSubscribe( topic, message );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			redisSubscribe.ConnectClose( );
		}

		private int count = 0;

		private void ShowSubscribe( string key, string content )
		{
			if (InvokeRequired)
			{
				Invoke( new Action<string, string>( ShowSubscribe ), key, content );
				return;
			}

			count++;
			label11.Text = DateTime.Now.ToString( );
			label8.Text = count.ToString( );

			textBox4.AppendText( DateTime.Now.ToString( ) + $"  Topic:[{key}] Message:{content}" );
			textBox4.AppendText( Environment.NewLine );
		}

		private Random random = new Random( );

		private void button3_Click( object sender, EventArgs e )
		{
			// 订阅操作
			OperateResult sub = redisSubscribe.SubscribeMessage( textBox5.Text );
			if (sub.IsSuccess)
			{
				MessageBox.Show( "订阅成功" );
			}
			else
			{
				MessageBox.Show( "订阅失败" );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 取消订阅
			OperateResult sub = redisSubscribe.UnSubscribeMessage( textBox5.Text );
			if (sub.IsSuccess)
			{
				MessageBox.Show( "取消订阅成功" );
			}
			else
			{
				MessageBox.Show( "取消订阅失败" );
			}
		}
	}


	#endregion
}
