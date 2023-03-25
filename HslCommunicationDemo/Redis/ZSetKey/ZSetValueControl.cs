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
using HslCommunication.BasicFramework;

namespace HslRedisDesktop
{
	public partial class ZSetValueControl : UserControl
	{
		public ZSetValueControl( )
		{
			InitializeComponent( );
		}

		private void ListValueControl_Load( object sender, EventArgs e )
		{
			keyOperateControl1.LoadValue.Click += LoadValue_Click;
			dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
			dataGridView1.SizeChanged += DataGridView1_SizeChanged; ;
			DataGridView1_SizeChanged( null, null );
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[1].Width = dataGridView1.Width - 311;
		}

		private void LoadValue_Click( object sender, EventArgs e )
		{
			RefreshKey( true );
		}

		private void RefreshKey( bool ascend )
		{
			if (redisClient == null) { MessageBox.Show( "当前的连接为空，无法读取！" ); return; }
            OperateResult<string[]> read;
            if (ascend) read = redisClient.Redis.ZSetRange( stringKeyName, 0, - 1, true );
			else read = redisClient.Redis.ZSetReverseRange( stringKeyName, 0, -1, true );

			if (!read.IsSuccess)
			{
				MessageBox.Show( "读取失败：" + read.Message );
			}
			else
			{
				int size = 0;
				for (int i = 0; i < read.Content.Length; i++)
				{
					size += Encoding.UTF8.GetBytes( read.Content[i] ).Length;
				}
				label2.Text = "大小：" + SoftBasic.GetSizeDescription( size );
				label3.Text = (read.Content.Length / 2).ToString( );

				Utils.ControlDataGridViewRow( dataGridView1, read.Content.Length / 2 );
				for (int i = 0; i < read.Content.Length / 2; i++)
				{
					dataGridView1.Rows[i].Cells[0].Value = i;
					dataGridView1.Rows[i].Cells[1].Value = read.Content[i * 2 + 0];
					dataGridView1.Rows[i].Cells[2].Value = read.Content[i * 2 + 1];
				}
			}
		}

		private void DataGridView1_SelectionChanged( object sender, EventArgs e )
		{
			if(dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Cells[1].Value != null)
				{
					string value = dataGridView1.SelectedRows[0].Cells[1].Value.ToString( );

					valueControl1.SetValue( value );
				}
			}
		}

		public void SetNewKey( RedisSettings redisClient, string key )
		{
			if (key != this.stringKeyName)
			{
				valueControl1.SetValue( string.Empty );
			}

			this.redisClient = redisClient;
			this.stringKeyName = key;

			keyOperateControl1.SetRedisClient( redisClient.Redis, key );
			RefreshKey( true );
		}

		
		private string stringKeyName = string.Empty;                // 字符串键名
		private RedisSettings redisClient = null;                     // 当前的连接

		private void button1_Click( object sender, EventArgs e )
		{
			// 插入元素
			using(ZSetValueInsertForm form = new ZSetValueInsertForm(redisClient, stringKeyName ))
			{
				form.ShowDialog( );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 删除元素
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Cells[1].Value != null)
				{
					if (MessageBox.Show( $"确认是否真的删除Key:{stringKeyName} 元素:{dataGridView1.SelectedRows[0].Cells[1].Value.ToString( )} 的数据信息？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
					{
						OperateResult delete = redisClient.Redis.ZSetRemove( stringKeyName, dataGridView1.SelectedRows[0].Cells[1].Value.ToString( ) );
						if (delete.IsSuccess)
						{
							MessageBox.Show( "删除集合元素成功！" );
						}
						else
						{
							MessageBox.Show( "删除集合元素失败！" + delete.Message );
						}
					}
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 升序加载
			RefreshKey( true );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 降序加载
			RefreshKey( false );
		}

        private void button5_Click( object sender, EventArgs e )
        {
			// 筛选范围
			MessageBox.Show( "当前版本暂时不支持！" );
		}
    }
}
