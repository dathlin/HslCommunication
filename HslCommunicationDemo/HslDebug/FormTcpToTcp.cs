using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Enthernet;

namespace HslCommunicationDemo
{
	public partial class FormTcpToTcp : HslFormContent
	{
		public FormTcpToTcp( )
		{
			InitializeComponent( );
		}

		private void FormSerialDebug_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			timer = new Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );

			this.checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
		}

		private void CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if (this.tcpForward != null)
			{
				this.tcpForward.LogMsgFormatBinary = checkBox1.Checked;
			}
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			if(this.tcpForward!=null)
			{
				listBox1.DataSource = this.tcpForward.GetPipeSessions( );
			}
		}

		private void Language( int language )
		{
			if (language == 1)
			{
				Text = "Tcp2TCP";
				label7.Text = "数据接收区：";
				checkBox1.Text = "使用二进制显示";
				button1.Text = "打开转换";
				button2.Text = "关闭转换";
				label4.Text = "缓冲区:";
				label1.Text = "远程IP:";
				label3.Text = "远程端口:";
				label2.Text = "本地端口:";
			}
			else
			{
				Text = "Tcp2TCP";
				label7.Text = "Data receiving Area:";
				checkBox1.Text = "use binary format to show";
				button1.Text = "Open tcp to tcp";
				button2.Text = "Close forward";
				label4.Text = "Cache Size:";
				label1.Text = "Remote IP:";
				label3.Text = "Remote Port:";
				label2.Text = "Local Port:";
			}
		}

		// 01 10 00 64 00 10 20 00 00 00 01 00 02 00 03 00 04 00 05 00 06 00 07 00 08 00 09 00 0A 00 0B 00 0C 00 0D 00 0E 00 0F



		#region Private Member

		private TcpForward tcpForward;
		private Timer timer;

		#endregion

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_cache_size.Text, out int cacheSize ))
			{
				MessageBox.Show( Program.Language == 1 ? "缓存大小输入错误！" : "Cache size input error" );
				return;
			}
			if (!int.TryParse( textBox2.Text, out int remotePort ))
			{
				MessageBox.Show( Program.Language == 1 ? "端口号输入错误！" : "IpAddress port input error" );
				return;
			}
			// 连接服务器
			try
			{
				tcpForward = new TcpForward( int.Parse( textBox1.Text ), textBox3.Text, remotePort );
				tcpForward.LogMsgFormatBinary = checkBox1.Checked;
				tcpForward.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				tcpForward.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				tcpForward.CacheSize = cacheSize;
				tcpForward.ServerStart( );

				button1.Enabled = false;
				button2.Enabled = true;

				MessageBox.Show( StringResources.Language.ConnectServerSuccess );
			}
			catch (Exception ex)
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			if (InvokeRequired)
			{
				Invoke(new Action<object, HslCommunication.LogNet.HslEventArgs>( LogNet_BeforeSaveToFile ), sender, e);
				return;
			}

			textBox6.AppendText( e.HslMessage.ToString( ) + Environment.NewLine);
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 关闭网口
			try
			{
				tcpForward.ServerClose( );
				button2.Enabled = false;
				button1.Enabled = true;
			}
			catch(Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( "LocalPort", textBox1.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox3.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox1.Text = element.Attribute( "LocalPort" ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
