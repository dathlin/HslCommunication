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
    public partial class ZSetValueInsertForm : Form
    {
        public ZSetValueInsertForm( RedisSettings settings, string key )
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
            textBox5.Text = "0";
            Icon = Icon.FromHandle( HslCommunicationDemo.Properties.Resources.zset.GetHicon( ) );
        }


        private RedisSettings redisSettings = null;               // Redis的配置信息
        private string key = string.Empty;                        // 等待编辑的键信息

        private void button1_Click( object sender, EventArgs e )
        {
            if(!double.TryParse( textBox5.Text, out double sco ))
            {
                MessageBox.Show( "得分的值不能转化为数值，请重新输入！" );
                return;
            }

            OperateResult write = this.redisSettings.Redis.ZSetAdd( this.key, textBox3.Text, sco );
            if(write.IsSuccess)
            {
                MessageBox.Show( "有序集合元素写入成功！" );
            }
            else
            {
                MessageBox.Show( "有序集合元素写入失败！" + write.Message );
            }
        }

        private void StringValueEditForm_Shown( object sender, EventArgs e )
        {
            textBox3.Focus( );
        }
    }
}
