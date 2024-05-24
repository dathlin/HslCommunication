using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.MQTT;
using HslCommunication;
using System.Xml.Linq;
using HslCommunication.Reflection;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using HslCommunication.BasicFramework;

namespace HslCommunicationDemo
{
	#region FormMqttFileServer


	public partial class FormMqttFileServer : HslFormContent
	{
		public FormMqttFileServer( )
		{
			InitializeComponent( );
		}

		private void FormClient_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			textBox1.Text = System.IO.Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "ServerFiles" );
			Language( Program.Language );

			timer1s = new Timer( );
			timer1s.Interval = 1000;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start( );
		}

		private void Timer1s_Tick( object sender, EventArgs e )
		{
			if (mqttServer != null)
			{
				label2.Text = "Online Count:" + mqttServer.OnlineCount;

				HslCommunication.Core.MqttFileMonitorItem[] monitorItems = mqttServer.GetMonitorItemsSnapShoot( );
				DataGridSpecifyRowCount( monitorItems.Length );

				long upload = 0;
				long download = 0;
				for (int i = 0; i < monitorItems.Length; i++)
				{
					DataGridViewRow row = dataGridView1.Rows[i];
					HslCommunication.Core.MqttFileMonitorItem item = monitorItems[i];
					row.Cells[0].Value = item.UniqueId.ToString( );
					row.Cells[1].Value = item.EndPoint.ToString( );
					row.Cells[2].Value = item.ClientId;
					row.Cells[3].Value = item.UserName;
					row.Cells[4].Value = item.Operate;
					row.Cells[5].Value = item.Groups;
					row.Cells[6].Value = item.FileName;
					row.Cells[7].Value = item.StartTime.ToString( );
					row.Cells[8].Value = SoftBasic.GetSizeDescription( item.TotalSize );
					row.Cells[9].Value = item.TotalSize == 0 ? "-" : SoftBasic.GetSizeDescription( item.SpeedSecond ) + "/s";
					row.Cells[10].Value = item.TotalSize == 0 ? "-" : ( item.LastUpdateProgress * 100 / item.TotalSize).ToString( ) + "%";

					if (item.Operate == "Upload") upload += item.SpeedSecond;
					if (item.Operate == "Download") download += item.SpeedSecond;
				}

				label6.Text = "Upload:" + SoftBasic.GetSizeDescription( upload ) + "/s";
				label7.Text = "Download:" + SoftBasic.GetSizeDescription( download ) + "/s";
			}
		}



		private void DataGridSpecifyRowCount( int row )
		{
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

		private Timer timer1s;

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "Mqtt File Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				label13.Text = "File Path:";
			}
		}

		private MqttServer mqttServer;

		private void button1_Click( object sender, EventArgs e )
		{
			try
			{
				mqttServer = new MqttServer( );
				mqttServer.ClientVerification += MqttServer_ClientVerification;                      // 登录验证，可以指定账户名密码登录
				mqttServer.FileOperateVerification += MqttServer_FileOperateVerification;            // 客户端文件验证，可以控制某个账户不能上传或删除
				mqttServer.ServerStart( int.Parse( textBox2.Text ) );                                // 启动服务

				mqttServer.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				mqttServer.LogNet.SetMessageDegree( HslCommunication.LogNet.HslMessageDegree.INFO ); // 屏蔽DEBUG等级日志
				mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				mqttServer.UseFileServer( textBox1.Text );                                           // 启动文件服务功能
				mqttServer.OnFileChangedEvent += MqttServer_OnFileChangedEvent;                      // 当有文件上传，下载，删除时触发的时间
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show( "Start Success" );
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Start Failed : " + ex.Message );
			}
		}

		private void MqttServer_OnFileChangedEvent( MqttSession session, HslCommunication.Core.MqttFileOperateInfo operateInfo )
		{
			//mqttServer.LogNet?.WriteInfo( mqttServer.ToString( ), operateInfo.ToJsonString( ) );
		}

		private OperateResult MqttServer_FileOperateVerification( MqttSession session, byte code, string[] groups, string[] fileNames )
		{
			// 进行文件操作时候的验证
			if (string.IsNullOrEmpty( session.UserName ))
			{
				// 用户名为空时，不能删除文件
				if (code == MqttControlMessage.FileDelete)
					return new OperateResult( "Null Account Not Allowed operation" );
			}

			if (session.UserName == "hsl")
			{
				// 用户名为hsl时，不能上传，下载，删除
				if (code == MqttControlMessage.FileUpload || code == MqttControlMessage.FileDelete || code == MqttControlMessage.FileDownload)
					return new OperateResult( "Account hsl not Allowed operation" );
			}

			return OperateResult.CreateSuccessResult( );
		}

		private int MqttServer_ClientVerification( MqttSession mqttSession, string clientId, string userName, string passwrod )
		{
			if (!checkBox1.Checked) return 0;

			if (userName == "admin" && passwrod == "123456")
			{
				return 0; // 成功
			}
			else
			{
				return 5; // 账号密码验证失败
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 textBox8.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			 } ) );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			mqttServer.ServerClose( );
		}


		private void button4_Click( object sender, EventArgs e )
		{
			// 清空
			textBox8.Clear( );
		}

		bool isStop = false;
		private void button7_Click( object sender, EventArgs e )
		{
			if (!isStop)
			{
				button7.Text = "继续";
				isStop = true;
			}
			else
			{
				isStop = false;
				button7.Text = "暂停";
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlFilePath, textBox1.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox1.Text = element.Attribute( DemoDeviceList.XmlFilePath ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}

	#endregion
}
