using HslCommunication;
using HslCommunication.Enthernet.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Redis
{
	public partial class FormRedisCopy : HslFormContent
	{
		public FormRedisCopy( )
		{
			InitializeComponent( );
		}

		private void FormRedisCopy_Load( object sender, EventArgs e )
		{
			hslPanelHead1.Enabled = false;
			button3.Enabled = false;
		}


		private RedisClient client1 = null;
		private RedisClient client2 = null;

		private void button2_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text, out int port1 ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong ); return;
			}
			if (!int.TryParse( textBox5.Text, out int port2 ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong ); return;
			}

			if (!int.TryParse( textBox8.Text, out int db1 ))
			{
				MessageBox.Show( "DB Block input wrong" ); return;
			}

			if (!int.TryParse( textBox9.Text, out int db2 ))
			{
				MessageBox.Show( "DB Block input wrong" ); return;
			}
			client1?.ConnectClose( );
			client2?.ConnectClose( );
			client1 = new RedisClient( textBox1.Text, port1, textBox3.Text );
			client2 = new RedisClient( textBox6.Text, port2, textBox4.Text );

			OperateResult connect1 = client1.ConnectServer( );
			if (!connect1.IsSuccess)
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + " " + connect1.Message ); return;
			}

			OperateResult connect2 = client2.ConnectServer( );
			if (!connect2.IsSuccess)
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + " " + connect2.Message ); return;
			}

			OperateResult opDb1 = client1.SelectDB( db1 );
			if (!opDb1.IsSuccess) { MessageBox.Show( "client1 DB Block select wrong" ); return; }
			OperateResult opDb2 = client2.SelectDB( db2 );
			if (!opDb2.IsSuccess) { MessageBox.Show( "client2 DB Block select wrong" ); return; }

			button2.Enabled = false;
			button3.Enabled = true;

			hslPanelTextBack1.Enabled = false;
			hslPanelTextBack2.Enabled = false;

			hslPanelHead1.Enabled = true;
			MessageBox.Show( "Success" );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			client1?.ConnectClose( );
			client2?.ConnectClose( );

			hslPanelTextBack1.Enabled = true;
			hslPanelTextBack2.Enabled = true;

			button2.Enabled = true;
			button3.Enabled = false;

			hslPanelHead1.Enabled = false;

			timer?.Dispose( );
			button5.Text = "定时同步";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 清空redis1
			if (MessageBox.Show( "Clear sure?", "check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
			{
				OperateResult op = client1.FlushDB( );
				if (op.IsSuccess)
					MessageBox.Show( "Flush Success!" );
				else
					MessageBox.Show( "Flush Failed!" + op.Message );
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 清空redis2
			if (MessageBox.Show( "Clear sure?", "check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
			{
				OperateResult op = client2.FlushDB( );
				if (op.IsSuccess)
					MessageBox.Show( "Flush Success!" );
				else
					MessageBox.Show( "Flush Failed!" + op.Message );
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 立即同步
			ThreadPool.QueueUserWorkItem( new WaitCallback( RedisCopy ), null );
		}

		private System.Threading.Timer timer = null;

		private void button5_Click( object sender, EventArgs e )
		{
			// 定时同步
			if(button5.Text == "定时同步")
			{
				timer = new System.Threading.Timer( new TimerCallback( RedisCopy ), null, 1000, int.Parse( textBox7.Text ) );
				button5.Text = "关闭同步";
			}
			else
			{
				timer?.Dispose( );
				button5.Text = "定时同步";
			}
		}

		private void MsgShow( string msg, int progress = -1 )
		{
			if (InvokeRequired)
			{
				Invoke( new Action<string, int>( MsgShow ), msg, progress );
				return;
			}

			textBox10.AppendText( DateTime.Now.ToString( ) + " " + msg + Environment.NewLine );
			if (progress > 0) hslProgress1.Value = progress;
		}

		private void RedisCopy( object obj )
		{
			if (client1 == null || client2 == null) return;

			OperateResult<long> opSize = client1.DBSize( );
			if (!opSize.IsSuccess) { MsgShow( "Size Get Failed" ); return; }
			if (opSize.Content == 0) { MsgShow( "No Key Value" ); return; }

			MsgShow( "Getting all key Name" );
			OperateResult<string[]> keyNames = client1.ReadAllKeys( "*" );
			if (!keyNames.IsSuccess) { MsgShow( "Key Names Get Failed" ); return; }


			hslProgress1.Max = keyNames.Content.Length;
			hslProgress1.Value = 0;

			MsgShow( "Begin Copy key value to redis2" );
			for (int i = 0; i < keyNames.Content.Length; i++)
			{
				OperateResult<string> type = client1.ReadKeyType( keyNames.Content[i] );
				if (!type.IsSuccess) { MsgShow( $"Key[{keyNames.Content[i]}] Get type Failed" ); return; }

				MsgShow( $"Copy Key[{keyNames.Content[i]}] Type[{type.Content}] ...", i + 1 );
				if (type.Content == "string")
				{
					OperateResult<string> read = client1.ReadKey( keyNames.Content[i] );
					if (!read.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult write = client2.WriteKey( keyNames.Content[i], read.Content );
					if (!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Copy Failed" ); return; }
				}
				else if (type.Content == "hash")
				{
					OperateResult<string[]> read1 = client1.ReadHashKeys( keyNames.Content[i] );
					if (!read1.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult<string[]> read2 = client1.ReadHashValues( keyNames.Content[i] );
					if (!read2.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult write = client2.WriteHashKey( keyNames.Content[i], read1.Content, read2.Content );
					if (!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Copy Failed" ); return; }
				}
				else if (type.Content == "list")
				{
					OperateResult<string[]> read = client1.ListRange( keyNames.Content[i], 0, -1 );
					if (!read.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult<int> length = client2.GetListLength( keyNames.Content[i] );
					if (!length.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Get Length Failed" ); return; }

					if(length.Content != read.Content.Length)
					{
						OperateResult delete = client2.DeleteKey( keyNames.Content[i] );
						if (!delete.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Delete Failed" ); return; }

						OperateResult write = client2.ListRightPush( keyNames.Content[i], read.Content );
						if (!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Copy Failed" ); return; }
					}
					else
					{
						for (int j = 0; j < read.Content.Length; j++)
						{
							OperateResult write = client2.ListSet( keyNames.Content[i], j, read.Content[j] );
							if (!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Index[{j}] Copy Failed" ); return; }
						}
					}
				}
				else if (type.Content == "set")
				{
					OperateResult<string[]> read = client1.SetMembers( keyNames.Content[i] );
					if (!read.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult delete = client2.DeleteKey( keyNames.Content[i] );
					if (!delete.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Delete Failed" ); return; }

					OperateResult write = client2.SetAdd( keyNames.Content[i], read.Content );
					if(!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Write Failed" ); return; }
				}
				else if (type.Content == "zset")
				{
					OperateResult<string[]> read = client1.ZSetRange( keyNames.Content[i], 0, -1, true );
					if (!read.IsSuccess) { MsgShow( $"Redis1 Key[{keyNames.Content[i]}] Read Failed" ); return; }

					OperateResult delete = client2.DeleteKey( keyNames.Content[i] );
					if (!delete.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Delete Failed" ); return; }

					string[] members = new string[read.Content.Length / 2];
					double[] scores = new double[read.Content.Length / 2];

					for (int j = 0; j < members.Length; j++)
					{
						members[i] = read.Content[i * 2 + 0];
						scores[i] = double.Parse( read.Content[i * 2 + 1] );
					}

					OperateResult write = client2.ZSetAdd( keyNames.Content[i], members, scores );
					if (!write.IsSuccess) { MsgShow( $"Redis2 Key[{keyNames.Content[i]}] Write Failed" ); return; }
				}
			}

			MsgShow( $"Copy Finish" );
		}

		private void button8_Click( object sender, EventArgs e )
		{
			textBox10.Clear( );
		}
	}
}
