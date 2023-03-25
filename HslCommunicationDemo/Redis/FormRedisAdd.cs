using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Enthernet.Redis;
using HslCommunication;
using System.Net;

namespace HslRedisDesktop
{
	public partial class FormRedisAdd : Form
	{
		public FormRedisAdd( RedisSettings redisSettings )
		{
			InitializeComponent( );
			settings = redisSettings ?? new RedisSettings( )
			{
				IpAddress = "127.0.0.1",
				Port = 6379,
				Password = string.Empty
			};

			if (redisSettings != null) textBox4.ReadOnly = true;
		}

		private void FormRedisAdd_Load( object sender, EventArgs e )
		{
			Icon = Icon.FromHandle( HslCommunicationDemo.Properties.Resources.action_add_16xLG.GetHicon( ) );

			textBox4.Text = this.settings.Name;
			textBox1.Text = this.settings.IpAddress;
			textBox2.Text = this.settings.Port.ToString( );
			textBox3.Text = this.settings.Password;

			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (checkBox1.Checked)
			{
				textBox3.PasswordChar = (char)0;
			}
			else
			{
				textBox3.PasswordChar = '*';
			}
		}

		private RedisSettings settings = null;

		/// <summary>
		/// 获取配置的信息
		/// </summary>
		public RedisSettings Settings => settings;

		private OperateResult CheckInput( )
		{
			if(string.IsNullOrEmpty( textBox4.Text )) return new OperateResult( "Server name can not be empty!" );
			if (!IPAddress.TryParse( textBox1.Text, out IPAddress address )) return new OperateResult( "Ip address input failed!" );
			if (!int.TryParse( textBox2.Text, out int port )) return new OperateResult( "port input failed!" );
			return OperateResult.CreateSuccessResult( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 通信测试
			OperateResult input = CheckInput( );
			if (!input.IsSuccess)
			{
				MessageBox.Show( "Input failed!" + input.Message );
				return;
			}

			RedisClient redis = new RedisClient( textBox1.Text, int.Parse( textBox2.Text ), textBox3.Text );
			OperateResult connect = redis.ConnectServer( );
			if(connect.IsSuccess)
			{
				MessageBox.Show( "Connect Success!" );
			}
			else
			{
				MessageBox.Show( "Connect Failed: " + connect.Message );
			}
			redis.ConnectClose( );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 配置完成
			OperateResult input = CheckInput( );
			if (!input.IsSuccess)
			{
				MessageBox.Show( "Input failed!" + input.Message );
				return;
			}

			settings.Name = textBox4.Text;
			settings.IpAddress = textBox1.Text;
			settings.Port = int.Parse( textBox2.Text );
			settings.Password = textBox3.Text;

			DialogResult = DialogResult.OK;
		}

		private void FormRedisAdd_Shown( object sender, EventArgs e )
		{
			textBox4.Focus( );
		}
	}
}
