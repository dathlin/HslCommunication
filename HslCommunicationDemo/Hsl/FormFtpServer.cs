using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.Pipe;
using HslCommunication.Enthernet;
using HslCommunication.Enthernet.Ftp;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.MQTT;
using Timer = System.Windows.Forms.Timer;

namespace HslCommunicationDemo
{
	public partial class FormFtpServer : HslFormContent
	{
		public FormFtpServer( )
		{
			InitializeComponent( );

			localFolder = Application.StartupPath + @"\FtpFiles";
			timer1s = new Timer( );
			timer1s.Interval = 1000;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start( );
		}

		private void Timer1s_Tick( object sender, EventArgs e )
		{
			if (ftpServer != null)
			{
				listBox1.DataSource = ftpServer.Sessions;
			}
		}

		private void FormFileClient_Load( object sender, EventArgs e )
		{
			textBox_path.Text = localFolder;
			if (Program.Language == 2)
			{
				label20.Text = "Port:";
				label19.Text = "User:";
				label3.Text = "Pwd:";
				button7.Text = "Start";
				button1.Text = "Close";
			}
		}

		#region Intergration File Client


		private HslCommunication.Enthernet.Ftp.FtpServer ftpServer = null;
		private string localFolder = string.Empty;
		private Timer timer1s = null;
		private string userName = string.Empty;
		private string password = string.Empty;

		#endregion

		private OperateResult CheckAccount(string name, string password, FtpSession session)
		{
			if (name == this.userName &&  password == this.password )
			{
				// 如果不允许某个账户上传
				//if (name == "hsl")
				//{
				//	session.CanUpload = false;
				//	session.CanEdit = false;
				//}
				return OperateResult.CreateSuccessResult( );
			}
			// 一般返回错误码 500-550之间
			return new OperateResult( 500, "user or password is wrong" );
		}

		private void button7_Click_1( object sender, EventArgs e )
		{
			this.userName = textBox_name.Text;
			this.password = textBox_password.Text;
			// 连接
			localFolder = textBox_path.Text;
			button7.Enabled = false;
			ftpServer = new HslCommunication.Enthernet.Ftp.FtpServer( );
			ftpServer.CurrentDirectory = textBox_path.Text;
			ftpServer.LogNet = new LogNetSingle( string.Empty );
			ftpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			ftpServer.AllowAnonymous = checkBox_allow.Checked;
			ftpServer.DownloadOnly = checkBox_downloadOnly.Checked;
			if (!string.IsNullOrEmpty(textBox_pasvPortRange.Text))
			{
				ftpServer.SetPasvPortRange( textBox_pasvPortRange.Text );
			}
			ftpServer.CheckAccountFunction = this.CheckAccount;                 // 自定义的账户检查
			//ftpServer.CheckAccountFunction = new Func<string, string, FtpSession, OperateResult>( ( name, pwd, session ) =>
			//{
			//	if (name == "admin" && pwd == "123456") return OperateResult.CreateSuccessResult( );
			//	return new OperateResult( 500, "user account or password wrong" );
			//} );

			try
			{
				ftpServer.ServerStart( Convert.ToInt32( textBox_port.Text ) );
				panel2.Enabled = true;
				button7.Enabled = false;
				button1.Enabled = true;
				DemoUtils.ShowMessage( StringResources.Language.ConnectServerSuccess );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
				button7.Enabled = true;
			}

			StringBuilder sb = new StringBuilder( );
			sb.AppendLine( "HslCommunication.Enthernet.Ftp.FtpServer ftpServer = new HslCommunication.Enthernet.Ftp.FtpServer( );" );
			sb.AppendLine( $"ftpServer.CurrentDirectory = \"{textBox_path.Text}\";" );
			sb.AppendLine( $"ftpServer.AllowAnonymous = {checkBox_allow.Checked.ToString( ).ToLower( )};" );
			sb.AppendLine( $"ftpServer.DownloadOnly = {checkBox_downloadOnly.Checked.ToString( ).ToLower( )};" );
			if (!string.IsNullOrEmpty( textBox_pasvPortRange.Text ))
			{
				sb.AppendLine( $"ftpServer.SetPasvPortRange( \"{textBox_pasvPortRange.Text}\" );" );
			}
			sb.AppendLine( $"// 自定义的账户检查" );
			sb.AppendLine( @"ftpServer.CheckAccountFunction = new Func<string, string, FtpSession, OperateResult>( ( name, pwd, session ) =>
{
    if (name == ""admin"" && pwd == ""123456"") return OperateResult.CreateSuccessResult( );
    return new OperateResult( 500, ""user account or password wrong"" );
} );" );
sb.AppendLine( @"try
{
    ftpServer.ServerStart( Convert.ToInt32( """ + textBox_port.Text + @""" ) );
}
catch(Exception ex)
{
    Console.WriteLine( ""Server Start failed: "" + ex.ToString() );
}" );


			textBox_code_create.Text = sb.ToString( );

			// 创建本地文件存储的路径
			if (!System.IO.Directory.Exists( localFolder ))
			{
				System.IO.Directory.CreateDirectory( localFolder );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslEventArgs e )
		{
			try
			{
				if (checkBox_stop.Checked == false)
				{
					Invoke( new Action( ( ) =>
					{
						textBox_log.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
					} ) );
				}
			}
			catch (ObjectDisposedException)
			{

			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 选择文件
			using (FolderBrowserDialog ofd = new FolderBrowserDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					textBox_path.Text = ofd.SelectedPath;
				}
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox_name.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox_password.Text );
			element.SetAttributeValue( "Path", textBox_path.Text );
			element.SetAttributeValue( "Allow", checkBox_allow.Checked );
			element.SetAttributeValue( "DownloadOnly", checkBox_downloadOnly.Checked );
			element.SetAttributeValue( "PortRange", textBox_pasvPortRange.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_port.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox_name.Text = element.Attribute( DemoDeviceList.XmlUserName ).Value;
			textBox_password.Text = element.Attribute( DemoDeviceList.XmlPassword ).Value;
			textBox_path.Text = GetXmlValue( element, "Path", textBox_path.Text, m => m );
			checkBox_allow.Checked = GetXmlValue( element, "Allow", true, bool.Parse );
			checkBox_downloadOnly.Checked = GetXmlValue(element, "DownloadOnly", false, bool.Parse );
			textBox_pasvPortRange.Text = GetXmlValue( element, "PortRange", string.Empty, m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			ftpServer?.ServerClose( );
			button7.Enabled = true;
			button1.Enabled = false;
		}


		private void FormMqttFileClient_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button7.Enabled == false) button1_Click( null, EventArgs.Empty );
		}

	}

}
