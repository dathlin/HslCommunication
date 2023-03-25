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
	public partial class HashValueControl : UserControl
	{
		public HashValueControl( )
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
			dataGridView1.Columns[1].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - 61;
		}

		private void LoadValue_Click( object sender, EventArgs e )
		{
			RefreshKey( );
		}

		private void RefreshKey( )
		{
			if (redisClient == null) { MessageBox.Show( "当前的连接为空，无法读取！" ); return; }
			OperateResult<string[]> read = redisClient.Redis.ReadHashKeyAll( stringKeyName );
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
					dataGridView1.Rows[i].Cells[0].Value = read.Content[i * 2 + 0];
					dataGridView1.Rows[i].Cells[1].Value = read.Content[i * 2 + 1];
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
					selectField = dataGridView1.SelectedRows[0].Cells[0].Value.ToString( );

					valueControl1.SetValue( value );
				}
			}
			else
			{
				selectField = string.Empty;
			}
		}

		public void SetNewKey( RedisSettings redisClient, string key )
		{
			if(key != this.stringKeyName)
			{
				valueControl1.SetValue( string.Empty );
			}

			this.redisClient = redisClient;
			this.stringKeyName = key;

			keyOperateControl1.SetRedisClient( redisClient.Redis, key );
			RefreshKey( );
		}

		

		private string selectField = string.Empty;                  // 当前选择的域
		private string stringKeyName = string.Empty;                // 字符串键名
		private RedisSettings redisClient = null;                     // 当前的连接

		private void button2_Click( object sender, EventArgs e )
		{
			// 编辑域
			if (dataGridView1.SelectedRows.Count > 0)
			{
				using (HashValueEditForm form = new HashValueEditForm( redisClient, this.stringKeyName, this.selectField, valueControl1.KeySourceValue( ) ))
				{
					form.ShowDialog( );
				}
			}
			else
			{
				MessageBox.Show( "请先选择对应的域数据，然后再点击编辑" );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 插入域
			using (HashValueEditForm form = new HashValueEditForm( redisClient, this.stringKeyName, string.Empty, string.Empty ))
			{
				form.ShowDialog( );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 删除域
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if(MessageBox.Show($"确认是否真的删除Key:{stringKeyName} Field:{selectField} 的数据信息？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					OperateResult delete = redisClient.Redis.DeleteHashKey( stringKeyName, selectField );
					if(delete.IsSuccess)
					{
						MessageBox.Show( "删除 Field 成功！" );
					}
					else
					{
						MessageBox.Show( "删除 Field 失败！" + delete.Message );
					}
				}
			}
			else
			{
				MessageBox.Show( "请先选择对应的域数据，然后再点击编辑" );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 刷新域
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dataGridView1.SelectedRows[0];
				string field = row.Cells[0].Value.ToString( );
				OperateResult<string> read = redisClient.Redis.ReadHashKey( stringKeyName, field );
				if (read.IsSuccess)
				{
					row.Cells[1].Value = read.Content;
					valueControl1.SetValue( read.Content );
				}
				else
				{
					MessageBox.Show( "数据读取失败！" + read.Message );
				}
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 定时刷新域
			MessageBox.Show( "当前版本暂时不支持！" );
		}
	}
}
