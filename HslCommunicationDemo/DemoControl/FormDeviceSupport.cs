using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormDeviceSupport : System.Windows.Forms.Form
	{
		public FormDeviceSupport( string formName )
		{
			InitializeComponent( );
			this.formName = formName;
		}

		private async void button1_Click( object sender, EventArgs e )
		{
			if (string.IsNullOrEmpty( this.textBox1.Text ))
			{
				MessageBox.Show( "Model can't be null!" );
				return;
			}

			button1.Enabled = false;

			MqttSyncClient mqtt = new MqttSyncClient( new MqttConnectionOptions( )
			{
				IpAddress = "118.24.36.220",
				Port = 1883,
				UseRSAProvider = true,
			} );
			OperateResult<List<DeviceSupportList>> read = await mqtt.ReadRpcAsync<List<DeviceSupportList>>( "SupportList/UploadSupport",
				new { token = string.Empty, unique = this.formName, model = this.textBox1.Text, qq = this.textBox2.Text, name = this.textBox3.Text } );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Upload data success" );
				System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
			}
			else
			{
				MessageBox.Show( "Request Server failed: " + read.Message );
			}

			button1.Enabled = true;
		}

		private void FormDeviceSupport_Shown( object sender, EventArgs e )
		{
			System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
		}


		private async void ThreadPoolCheckVersion( object obj )
		{
			System.Threading.Thread.Sleep( 100 );

			MqttSyncClient mqtt = new MqttSyncClient( new MqttConnectionOptions( )
			{
				IpAddress = "118.24.36.220",
				Port = 1883,
				UseRSAProvider = true,
			} );
			OperateResult<string> read = await mqtt.ReadRpcAsync<string>( "SupportList/GetDeviceSupport", new { token = string.Empty, unique = this.formName } );
			if (read.IsSuccess)
			{
				if (!string.IsNullOrEmpty( read.Content ))
				{
					List<DeviceSupportList> devices = JArray.Parse( read.Content ).ToObject<List<DeviceSupportList>>( );
					Invoke( new Action<List<DeviceSupportList>>( RenderDevice ), devices );
				}
			}
			else
			{
				MessageBox.Show( "Request Server failed: " + read.Message );
			}

		}

		private void RenderDevice( List<DeviceSupportList> devices )
		{
			if ( devices == null )
			{
				DataGridSpecifyRowCount( dataGridView1, 0 );
				return;
			}
			DataGridSpecifyRowCount( dataGridView1, devices.Count );
			for (int i = 0; i < devices.Count; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = devices[i].Model;
				dataGridView1.Rows[i].Cells[1].Value = devices[i].Name;
				dataGridView1.Rows[i].Cells[2].Value = devices[i].QQ;
				dataGridView1.Rows[i].Cells[3].Value = devices[i].Time.ToString( "yyyy-MM-dd" );
			}
		}

		private string formName = string.Empty;




		/// <summary>
		/// 将 <see cref="DataGridView"/> 的行数控制在指定的行数
		/// </summary>
		/// <param name="dataGridView1">图标控件</param>
		/// <param name="row">指定的行数信息</param>
		public static void DataGridSpecifyRowCount( DataGridView dataGridView1, int row )
		{
			if (dataGridView1.AllowUserToAddRows)
			{
				row++;
			}
			if (dataGridView1.RowCount < row)
			{
				// 扩充
				dataGridView1.Rows.Add( row - dataGridView1.RowCount );
			}
			else if (dataGridView1.RowCount > row)
			{
				int deleteRows = dataGridView1.RowCount - row;
				for (int i = 0; i < deleteRows; i++)
				{
					dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
				}
			}
			if (row > 0)
			{
				dataGridView1.Rows[0].Cells[0].Selected = false;
			}
		}

		private void FormDeviceSupport_Load( object sender, EventArgs e )
		{
			if(Program.Language == 1)
			{
				dataGridView1.Columns[0].HeaderText = "系列及型号";
				dataGridView1.Columns[1].HeaderText = "上传者";
				dataGridView1.Columns[2].HeaderText = "联系方式（QQ）";
				dataGridView1.Columns[3].HeaderText = "上传时间";
			}
		}
	}

	public class DeviceSupportList
	{

		public string Model { get; set; }

		public string Name { get; set; }

		public string QQ { get; set; }

		public DateTime Time { get; set; }
	}
}
