using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;
using HslCommunication.ModBus;
using HslCommunication.Core.Net;
using HslCommunication.DTU;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Core.Pipe;

namespace HslCommunicationDemo
{
	public partial class FormDtuServer : HslFormContent
	{
		public FormDtuServer( )
		{
			InitializeComponent( );
			logNet = new HslCommunication.LogNet.LogNetSingle( "" );
		}


		private HslCommunication.LogNet.ILogNet logNet = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

			timer = new Timer( );
			timer.Tick += Timer_Tick;
			timer.Interval = 1000;
			timer.Start( );

			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			if (IsHandleCreated)
			{
				Invoke( new Action( ( ) =>
				 {
					 textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
				 } ) );
			}
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			// 显示在线信息
			if (dTUServer != null)
			{
				PipeDtuNet[] sessions = dTUServer.GetPipeSessions( );
				listBox1.DataSource = sessions.Where( m => m != null ).ToArray( );

				label2.Text = "Client Count:" + sessions.Length;
				int onlineCount = 0;
				for (int i = 0; i < sessions.Length; i++)
				{
					if (sessions[i] != null && !sessions[i].IsConnectError( )) onlineCount++;
				}
				label5.Text = "Online Count：" + onlineCount;
			}
		}



		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Alien Modbus Tcp Read Demo";

				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}


		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Alien Server

		/**************************************************************************************************
         * 
         *    说明：异形服务器的创建，为异形Modbus-Tcp客户端的创建提供必要的网络支撑
         * 
         **************************************************************************************************/

		private DTUServer dTUServer = null;

		private void DtuServerStart( int port )
		{
			List<DTUSettingType> settingTypes = new List<DTUSettingType>( );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10000", DtuType = "ModbusRtuOverTcp", JsonParameter = new { Station = 1 }.ToJsonString( ) } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10001", DtuType = "ModbusRtuOverTcp", JsonParameter = new { Station = 1 }.ToJsonString( ) } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10002", DtuType = "ModbusRtuOverTcp", JsonParameter = new { Station = 1 }.ToJsonString( ) } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10003", DtuType = "ModbusRtuOverTcp", JsonParameter = new { Station = 1 }.ToJsonString( ) } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10004", DtuType = "ModbusTcpNet", JsonParameter = new { Station = 1 }.ToJsonString( ) } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10005", DtuType = "MelsecMcNet" } );
			settingTypes.Add( new DTUSettingType( ) { DtuId = "10006", DtuType = "SiemensS7Net", JsonParameter = new { SiemensPLCS = SiemensPLCS.S1200.ToString( ) }.ToJsonString( ) } );

			dTUServer = new DTUServer( settingTypes );
			dTUServer.OnClientConnected += NetworkAlien_OnClientConnected;
			dTUServer.LogNet = logNet;
			dTUServer.SetPassword( Encoding.ASCII.GetBytes( textBox3.Text ) );
			dTUServer.ServerStart( port );

			comboBox1.DataSource = settingTypes.ToArray( );
			if (settingTypes.Count > 0)
			{
				comboBox1.SelectedIndex = 0;
			}
		}

		private void ComboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (dTUServer != null)
			{
				if (comboBox1.SelectedItem is DTUSettingType id)
				{
					if (!string.IsNullOrEmpty( id.DtuId ))
					{
						userControlReadWriteOp1.SetReadWriteNet( dTUServer[id.DtuId], "0" );
					}
				}
			}
		}

		private void NetworkAlien_OnClientConnected( PipeDtuNet pipe )
		{
			Invoke( new Action( ( ) =>
			 {
			 } ) );
		}

		#endregion

		#region Connect And Close

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( "端口输入不正确！" );
				return;
			}

			try
			{
				DtuServerStart( port );

				MessageBox.Show( "等待服务器的连接！" );
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;

			dTUServer?.ServerClose( );
			// 通知下线
		}

		#endregion


		private Timer timer;

	}
}
