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

namespace HslCommunicationDemo.Redis
{
	public partial class FormRedisInput : System.Windows.Forms.Form
	{
		public FormRedisInput( RedisClient redis )
		{
			InitializeComponent( );
			this.redis = redis;
		}

		private RedisClient redis;

		private void FormRedisInput_Load( object sender, EventArgs e )
		{
			tabPage1.Text = "String";
			tabPage2.Text = "Hash";
			tabPage3.Text = "List";
			tabPage4.Text = "Random";
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox1.Text ))
			{
				DemoUtils.ShowMessage( "Key Can not be null" );
			}
			else
			{
				OperateResult write = redis.WriteKey( textBox1.Text, textBox2.Text );
				if (write.IsSuccess)
				{
					DemoUtils.ShowMessage( "Write sucess" );
				}
				else
				{
					DemoUtils.ShowMessage( "Failed:" + write.Message );
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox4.Text ) || string.IsNullOrEmpty( textBox5.Text ))
			{
				DemoUtils.ShowMessage( "Key Can not be null" );
			}
			else
			{
				OperateResult write = redis.WriteHashKey( textBox4.Text, textBox5.Text, textBox3.Text );
				if (write.IsSuccess)
				{
					DemoUtils.ShowMessage( "Write sucess" );
				}
				else
				{
					DemoUtils.ShowMessage( "Failed:" + write.Message );
				}
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( textBox6.Text ) || string.IsNullOrEmpty( textBox7.Text ))
			{
				DemoUtils.ShowMessage( "Key Can not be null" );
			}
			else
			{
				OperateResult write = null;
				if (radioButton2.Checked)
				{
					write = redis.ListRightPush( textBox7.Text, textBox6.Text );
				}
				else
				{
					write = redis.ListLeftPush( textBox7.Text, textBox6.Text );
				}
				
				if (write.IsSuccess)
				{
					DemoUtils.ShowMessage( "Write sucess" );
				}
				else
				{
					DemoUtils.ShowMessage( "Failed:" + write.Message );
				}
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{

			if (string.IsNullOrEmpty( textBox8.Text ))
			{
				DemoUtils.ShowMessage( "Key Can not be null" );
			}
			else
			{
				if (!int.TryParse(textBox10.Text, out int count))
				{
					MessageBox.Show( "Times input wrong!" );
					return;
				}

				int success = 0;
				for (int i = 0; i < count; i++)
				{
					string key = string.Format( textBox8.Text, i );
					string value = string.Format( textBox9.Text, i );
					OperateResult write = redis.WriteKey( key, value );
					if (write.IsSuccess)
					{
						//DemoUtils.ShowMessage( "Write sucess" );
						success++;
					}
					else
					{
						DemoUtils.ShowMessage( $"Write Key [{key}] Failed:" + write.Message );
						break;
					}
				}

				if (success == count)
				{
					DemoUtils.ShowMessage( "Write all sucess" );
				}
			}
		}
	}
}
