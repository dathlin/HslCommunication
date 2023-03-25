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
	public partial class KeyOperateControl : UserControl
	{
		public KeyOperateControl( )
		{
			InitializeComponent( );
		}

		private void KeyOperateControl_Load( object sender, EventArgs e )
		{
			button_rename.Click   += Button_rename_Click;
            button_ttl.Click      += Button_ttl_Click;
            button_delete.Click   += Button_delete_Click;
            button_move.Click     += Button_move_Click;
		}

        private void Button_move_Click( object sender, EventArgs e )
        {
			if (redisClient != null)
			{
				using (FormInputString formInput = new FormInputString( ))
				{
					formInput.TextInfo = "等待输入新的DB块号:";
					if (formInput.ShowDialog( ) == DialogResult.OK)
					{
						if (int.TryParse( formInput.InputValue, out int db ))
						{
							OperateResult ttl = redisClient.MoveKey( keyName, db );
							if (!ttl.IsSuccess) MessageBox.Show( "移动关键字失败！" + ttl.Message );
							else MessageBox.Show( "移动关键字成功！" );
						}
						else
						{
							MessageBox.Show( "移动关键字失败，在DB块里需要输入数字！" );
						}
					}
				}
			}
		}

        private void Button_delete_Click( object sender, EventArgs e )
		{
			if (redisClient != null)
			{
				if(MessageBox.Show("是否真的确认删除？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
                {
					OperateResult delete = redisClient.DeleteKey( keyName );
					if (!delete.IsSuccess) MessageBox.Show( "删除关键字失败！" + delete.Message );
					else MessageBox.Show( "删除关键字成功！" );
				}
			}
		}

        private void Button_ttl_Click( object sender, EventArgs e )
        {
			if (redisClient != null)
			{
				using (FormInputString formInput = new FormInputString( ))
				{
					formInput.TextInfo = "等待输入新的超时时间，单位秒，-1为永久:";
					if (formInput.ShowDialog( ) == DialogResult.OK)
					{
						if(formInput.InputValue == "-1")
                        {
							OperateResult ttl = redisClient.PersistKey( keyName );
							if(!ttl.IsSuccess) MessageBox.Show( "设置永久失败！" + ttl.Message );
							else MessageBox.Show( "设置永久成功！" );
						}
                        else
                        {
							if(int.TryParse( formInput.InputValue, out int seconds ))
							{
								OperateResult ttl = redisClient.ExpireKey( keyName, seconds );
								if (!ttl.IsSuccess) MessageBox.Show( "设置过期时间失败！" + ttl.Message );
								else MessageBox.Show( "设置过期时间成功！" );
							}
                            else
                            {
								MessageBox.Show( "过期时间输入失败，需要输入数字！" );
							}
						}
					}
				}
			}
		}

        private void Button_rename_Click( object sender, EventArgs e )
		{
			if (redisClient != null)
			{
				using (FormInputString formInput = new FormInputString( ))
				{
					formInput.TextInfo = "等待输入新的关键字名称：";
					if (formInput.ShowDialog( ) == DialogResult.OK)
					{
						OperateResult rename = redisClient.RenameKey( keyName, formInput.InputValue );
						if (!rename.IsSuccess) MessageBox.Show( "重命名失败！" + rename.Message );
						else MessageBox.Show( "重命名成功" );
					}
				}
			}
		}

		[Browsable(true)]
		[Description("获取或设置当前键值的类型表述")]
		[DefaultValue("String:")]
		public string KeyType
		{
			get => label_type.Text;
			set => label_type.Text = value;
		}

		[Browsable(false)]
		public Button LoadValue
		{
			get => button_reload;
		}

		public void SetRedisClient( RedisClient client, string keyName )
		{
			this.redisClient = client;
			this.textBox1.Text = keyName;
			this.keyName = keyName;

			if(client!= null)
			{
				OperateResult<int> ttl = client.OperateNumberFromServer( new string[] { "TTL", keyName } );
				if (ttl.IsSuccess) button_ttl.Text = "TTL:" + ttl.Content;
			}
		}

		private string keyType = string.Empty;                          // 当前键值的类型
		private string keyName = string.Empty;                          // 当前键值的名称
		private RedisClient redisClient = null;
	}
}
