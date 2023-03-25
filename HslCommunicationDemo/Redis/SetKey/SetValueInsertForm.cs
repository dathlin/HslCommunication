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
    public partial class SetValueInsertForm : Form
    {
        public SetValueInsertForm( RedisSettings settings, string key)
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

            Icon = Icon.FromHandle( HslCommunicationDemo.Properties.Resources.docview_xaml_on_16x16.GetHicon( ) );
        }


        private RedisSettings redisSettings = null;               // Redis的配置信息
        private string key = string.Empty;                        // 等待编辑的键信息

        private void button1_Click( object sender, EventArgs e )
        {
            OperateResult write = this.redisSettings.Redis.SetAdd( this.key, textBox3.Text );
            if(write.IsSuccess)
            {
                MessageBox.Show( "成员写入成功！" );
            }
            else
            {
                MessageBox.Show( "成员写入失败！" + write.Message );
            }
        }

        private void StringValueEditForm_Shown( object sender, EventArgs e )
        {
            textBox3.Focus( );
        }
    }
}
