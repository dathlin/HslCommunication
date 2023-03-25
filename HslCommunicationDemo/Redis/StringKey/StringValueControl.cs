using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Enthernet.Redis;
using HslCommunication;

namespace HslRedisDesktop
{
	public partial class StringValueControl : UserControl
	{
		public StringValueControl( )
		{
			InitializeComponent( );
		}


		private void StringValueControl_Load( object sender, EventArgs e )
		{
			keyOperateControl1.LoadValue.Click += LoadValue_Click;
		}

		public void SetNewKey( RedisSettings redisSettings, string key )
		{
			this.redisSettings = redisSettings;
			this.stringKeyName = key;

			keyOperateControl1.SetRedisClient( redisSettings.Redis, key );
			RefreshKey( );
		}

		private void LoadValue_Click( object sender, EventArgs e )
		{
			RefreshKey( );
		}

		private void RefreshKey( )
		{
			if (redisSettings == null) { MessageBox.Show( "当前的连接为空，无法读取！" ); return; }
			if (redisSettings.Redis == null) { MessageBox.Show( "当前的连接为空，无法读取！" ); return; }
			OperateResult<string> read = redisSettings.Redis.ReadKey( stringKeyName );
			if(!read.IsSuccess)
			{
				MessageBox.Show( "读取失败：" + read.Message );
			}
			else
			{
				valueControl1.SetValue( read.Content );
			}
		}

		private string stringKeyName = string.Empty;                // 字符串键名
		private RedisSettings redisSettings = null;                     // 当前的连接

		private void button1_Click( object sender, EventArgs e )
		{
			// 编辑了内容
			using (StringValueEditForm form = new StringValueEditForm( this.redisSettings, this.stringKeyName, valueControl1.KeySourceValue( ) ))
			{
				form.ShowDialog( );
			}
		}

        private void button5_Click( object sender, EventArgs e )
        {
			// 定时刷新
			MessageBox.Show( "当前版本暂时不支持！" );
        }
    }
}
