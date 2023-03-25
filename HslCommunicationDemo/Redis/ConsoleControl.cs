using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Enthernet.Redis;

namespace HslRedisDesktop
{
    public partial class ConsoleControl : UserControl
    {
        public ConsoleControl( )
        {
            InitializeComponent( );
        }

        private void textBox2_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.redisSettings == null) return;
                if (string.IsNullOrEmpty( textBox2.Text )) return;

                if (redisSettings != null)
                {
                    textBox1.AppendText( ">> " + textBox2.Text + Environment.NewLine );
                    byte[] byteCommand = RedisHelper.PackStringCommand( textBox2.Text.Split( ' ' ) );

                    OperateResult<byte[]> read = redisSettings.Redis.ReadFromCoreServer( byteCommand );
                    if (!read.IsSuccess)
                    {
                        textBox1.AppendText( ">> Error:" + read.Message + Environment.NewLine );
                        return;
                    }

                    if (read.IsSuccess)
                    {
                        if (read.Content[0] == '+')
                        {
                            textBox1.AppendText( ">> " + Encoding.UTF8.GetString( read.Content ).TrimEnd( '\r', '\n' ) + Environment.NewLine );
                        }
                        else if(read.Content[0] == ':' )
                        {
                            OperateResult<long> operate = RedisHelper.GetLongNumberFromCommandLine( read.Content );
                            if (operate.IsSuccess)
                            {
                                textBox1.AppendText( ">> Integer(" + operate.Content + ")" + Environment.NewLine );
                            }
                            else
                            {
                                textBox1.AppendText( ">> Error:" + operate.Message + Environment.NewLine );
                            }
                        }
                        else if (read.Content[0] == '$' )
                        {
                            OperateResult<string[]> operate = RedisHelper.GetStringFromCommandLine( read.Content );
                            if (operate.IsSuccess)
                            {
                                textBox1.AppendText( ">> " + operate.Content[0] + Environment.NewLine );
                            }
                            else
                            {
                                textBox1.AppendText( ">> Error:" + operate.Message + Environment.NewLine );
                            }
                        }
                        else if (read.Content[0] == '*')
                        {
                            OperateResult<string[]> operate = RedisHelper.GetStringsFromCommandLine( read.Content );
                            if (operate.IsSuccess)
                            {
                                for (int i = 0; i < operate.Content.Length; i++)
                                {
                                    textBox1.AppendText( ">>(" + i + ") " + operate.Content[i] + Environment.NewLine );
                                }
                            }
                            else
                            {
                                textBox1.AppendText( ">> Error:" + operate.Message + Environment.NewLine );
                            }
                        }
                        else
                        {
                            textBox1.AppendText( ">> " + Encoding.UTF8.GetString( read.Content ) + Environment.NewLine );
                        }
                    }
                    else
                    {
                        textBox1.AppendText( ">> Faild: " + read.Message + Environment.NewLine );
                    }
                }
            }
        }

        /// <summary>
        /// 设置当前的连接对象信息
        /// </summary>
        /// <param name="settings"></param>
        public void SetRedis(RedisSettings settings )
        {
            this.redisSettings = settings;
        }

        private RedisSettings redisSettings;

        private void ConsoleControl_Load( object sender, EventArgs e )
        {
            textBox2.Focus( );
        }
    }
}
