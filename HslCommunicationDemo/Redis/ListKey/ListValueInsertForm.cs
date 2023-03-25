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

namespace HslRedisDesktop
{
    public partial class ListValueInsertForm : Form
    {
        public ListValueInsertForm( RedisSettings settings, string key )
        {
            InitializeComponent( );
            this.redisSettings = settings;
            this.key = key;
        }

        private void StringValueEditForm_Load( object sender, EventArgs e )
        {
            textBox1.Text = $"{this.redisSettings.Name}[{this.redisSettings.IpAddress}:{this.redisSettings.Port}]";
            textBox2.Text = this.key;
            textBox4.Text = this.redisSettings.DBBlock.ToString( );

            Icon = Icon.FromHandle( HslCommunicationDemo.Properties.Resources.brackets_Square_16xMD.GetHicon( ) );
            ListValueInsertForm_SizeChanged( null, null );
        }


        private RedisSettings redisSettings = null;               // Redis的配置信息
        private string key = string.Empty;                        // 等待编辑的键信息

        private void button1_Click( object sender, EventArgs e )
        {
            if(radioButton1.Checked)
            {
                OperateResult write = this.redisSettings.Redis.ListLeftPush( this.key, textBox3.Text );
                if (write.IsSuccess)
                {
                    MessageBox.Show( "列表数据从左侧插入成功！" );
                }
                else
                {
                    MessageBox.Show( "列表数据从左侧插入失败！" + write.Message );
                }
            }
            else
            {
                OperateResult write = this.redisSettings.Redis.ListRightPush( this.key, textBox3.Text );
                if (write.IsSuccess)
                {
                    MessageBox.Show( "列表数据从右侧插入成功！" );
                }
                else
                {
                    MessageBox.Show( "列表数据从右侧插入失败！" + write.Message );
                }
            }
        }

        private void StringValueEditForm_Shown( object sender, EventArgs e )
        {
            textBox3.Focus( );
        }

        private void ListValueInsertForm_SizeChanged( object sender, EventArgs e )
        {
            button1.Location = new Point( this.Width / 2 - button1.Width / 2, this.Height - 100 );
        }
    }
}
