using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Core.Net;
using HslCommunication;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using HslCommunicationDemo.PLC.Common;
using HslCommunication.Core.Device;

namespace HslCommunicationDemo.DemoControl
{
	public partial class UserControlReadWriteServer : UserControl
	{
		public UserControlReadWriteServer( )
		{
			InitializeComponent( );



			allControls.Add( batchReadControl1 );
		}


		private System.Windows.Forms.Timer timerSecond;
		private List<UserControl> allControls = new List<UserControl>( );


		public void SetReadWriteServerLog( DeviceServer dataServerBase )
		{
			dataServerBase.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
			dataServerBase.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		public void SetReadWriteServer( DeviceServer dataServerBase, string address, int strLength = 10 )
		{
			if (dataServerBase.LogNet == null)
			{
				SetReadWriteServerLog( dataServerBase );
			}

			this.deviceServer = dataServerBase;
			userControlReadWriteOp1.SetReadWriteNet( deviceServer, address, false, strLength );
			batchReadControl1.SetReadWriteNet( deviceServer, address, "" );
			batchReadControl1.SetVariableName( "server" );
			dataTableControl1.SetReadWriteNet( deviceServer );
			dataSimulateControl1.SetReadWriteNet( deviceServer );

			timerSecond?.Dispose( );
			timerSecond = new System.Windows.Forms.Timer( );
			timerSecond.Interval = 1000;
			timerSecond.Tick += TimerSecond_Tick;
			timerSecond.Start( );
		}

		private void TimerSecond_Tick( object sender, EventArgs e )
		{
			if (deviceServer != null)
				label15.Text = deviceServer.OnlineCount.ToString( );
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			if (!checkBox1.Checked && e.HslMessage.Degree != HslCommunication.LogNet.HslMessageDegree.FATAL) return;

			try
			{
				if (InvokeRequired)
				{
					Invoke( new Action<object, HslCommunication.LogNet.HslEventArgs>( LogNet_BeforeSaveToFile ), sender, e );
					return;
				}

				if (textBox1.TextLength > 1000_000) textBox1.Clear( );
				textBox1.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			}
			catch
			{
				return;
			}
		}

		public void SetEnable( bool enbale )
		{
			userControlReadWriteOp1.Enabled = enbale;
			for (int i = 0; i < allControls.Count; i++)
			{
				allControls[i].Enabled = enbale;
			}
			checkBox1.Enabled = enbale;
			checkBox_cycle.Enabled = enbale;
			button_data_import.Enabled = enbale;
			button_import_abort.Enabled = enbale;
			button1.Enabled = enbale;
			button8.Enabled = enbale;
			button9.Enabled = enbale;
			textBox1.Enabled = enbale;
		}

		public void Close( )
		{
			this.userControlReadWriteOp1.Close( );
			this.dataTableControl1.Close( );
			this.dataSimulateControl1.Close( );
		}

		DeviceServer deviceServer;

		private void UserControlReadWriteServer_Load( object sender, EventArgs e )
		{

			if (Program.Language == 2)
			{
				button8.Text = "Load";
				button9.Text = "Save";
				checkBox1.Text = "Display log data?";
				label16.Text = "Client-Online:";
				button1.Text = "Connecting Alien client";

				checkBox_cycle.Text = "Cycle?";
				button_data_import.Text = "DataImport";
				button_import_abort.Text = "ImportAbort";

				tabPage1.Text = "LogInfo";
				tabPage2.Text = "Batch Read";
				tabPage3.Text = "Data Table";
				tabPage4.Text = "Simulate";
			}
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 从文件加载服务器的数据池
			if (deviceServer != null)
			{
				using (OpenFileDialog ofd = new OpenFileDialog( ))
				{
					if (ofd.ShowDialog( ) == DialogResult.OK)
					{
						if (System.IO.File.Exists( ofd.FileName ))
						{
							try
							{
								deviceServer.LoadDataPool( ofd.FileName );
								MessageBox.Show( "Load data finish" );
							}
							catch (Exception ex)
							{
								MessageBox.Show( "Load failed: " + ex.Message );
							}
						}
						else
						{
							MessageBox.Show( $"File[{ofd.FileName}] is not exist！" );
						}
					}
				}
			}
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 将服务器的数据池存储起来
			if (deviceServer != null)
			{
				using (SaveFileDialog sfd = new SaveFileDialog( ))
				{
					sfd.FileName = "123.txt";
					if (sfd.ShowDialog( ) == DialogResult.OK)
					{
						try
						{
							deviceServer.SaveDataPool( sfd.FileName );
							MessageBox.Show( "Save file finish!" );
						}
						catch (Exception ex)
						{
							MessageBox.Show( "Save failed: " + ex.Message );
						}
					}
				}
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 连接异形客户端
			using (FormInputAlien form = new FormInputAlien( ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					if (form.UseHslDtuServer)
					{
						deviceServer.GetCommunicationServer( ).ConnectHslAlientClient( form.IpAddress, form.Port, form.DTU, form.Pwd, form.NeedAckDtuResult );
					}
					else
					{
						deviceServer.GetCommunicationServer( ).ConnectRemoteServer( form.IpAddress, form.Port, form.CustomizeDTU );
					}

					MessageBox.Show( "Add Connection success" );

					//OperateResult connect = deviceServer.GetCommunicationServer().ConnectHslAlientClient( form.IpAddress, form.Port, form.DTU, form.Pwd );
					//if (connect.IsSuccess)
					//{
					//	MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					//}
					//else
					//{
					//	MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message );
					//}
				}
			}
		}

		public UserControlReadWriteOp ReadWriteOpControl => this.userControlReadWriteOp1;

		public BatchReadControl BatchRead
		{
			get => this.batchReadControl1;
		}


		public void AddSpecialFunctionTab( UserControl control, bool show = false, string title = null )
		{
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, control, show, title );
			if (control is AddressExampleControl)
			{

			}
			else
			{
				allControls.Add( control );
				if (control is CodeExampleControl codeExampleControl)
				{
					this.userControlReadWriteOp1.MethodCodeClick += ( object sender, string e ) =>
					{
						codeExampleControl.ReaderReadCode( e );
					};
				}
			}
		}

		public void GetDataTable( XElement element )
		{
			element.RemoveNodes( );
			this.dataTableControl1.GetDataTable( element );
			this.dataSimulateControl1.GetSimulateTable( element );
		}

		public int LoadDataTable( XElement element )
		{
			this.dataSimulateControl1.LoadSimulateTable( element );
			return this.dataTableControl1.LoadDataTable( element );
		}

		public void SelectTabDataTable( )
		{
			this.tabControl1.SelectTab( tabPage3 );
		}

		FileStream fs = null;
		private int timeInterval = 1000;
		private long tickCount = 0;
		private Thread threadWrite;
		private bool writeSuspended = false;
		private bool writeCycle = false;
		private bool abort = false;

		private void button_data_import_Click( object sender, EventArgs e )
		{
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				ofd.Multiselect = false;
				ofd.Filter = "数据文件(*.hsldata)|*.hsldata";

				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					try
					{
						fs = new FileStream( ofd.FileName, FileMode.Open );
						byte[] head = new byte[100];
						fs.Read( head, 0, 100 );

						if (Encoding.ASCII.GetString( head, 0, 7 ) != "HSLDemo")
						{
							MessageBox.Show( "Not the hsl data file! " );
							fs.Dispose( );
							return;
						}

						timeInterval = BitConverter.ToInt32( head, 26 );
						threadWrite = new Thread( new ThreadStart( ThreadReadFile ) );
						tickCount = BitConverter.ToInt64( head, 30 );

						button_data_import.Enabled = false;
						button_import_abort.Enabled = true;
						abort = false;
						threadWrite.Start( );
					}
					catch (Exception ex)
					{
						MessageBox.Show( "Data import failed: " + ex.Message );
						return;
					}

				}
			}
		}

		private int GetUInt32( Stream stream, out int value )
		{
			byte[] buffer = new byte[4];
			int result = stream.Read( buffer, 0, 4 );
			value = BitConverter.ToInt32( buffer, 0 );

			return result;
		}
		private int GetString( Stream stream, int len, out string value )
		{
			byte[] buffer = new byte[len];
			int result = stream.Read( buffer, 0, len );
			value = Encoding.UTF8.GetString( buffer );
			return result;
		}

		private void ThreadReadFile( )
		{
			DateTime lastTime = DateTime.Now.AddMilliseconds( -timeInterval );

			while (true)
			{
				fs.Position = 100;
				int dealCount = 0;
				while (true)
				{
					if (timeInterval > 0) Thread.Sleep( timeInterval );
					if (abort) break;
					if (writeSuspended) continue;

					if (GetUInt32( fs, out int count ) <= 0)
					{
						break;
					}
					dealCount++;

					StringBuilder log = new StringBuilder( $"Write address[{dealCount}/{tickCount}]:" );
					for (int i = 0; i < count; i++)
					{
						if (GetUInt32( fs, out int addressLength ) <= 0) break;
						if (GetString( fs, addressLength, out string address ) <= 0) break;
						if (GetUInt32( fs, out int readLength ) <= 0) break;
						int success = fs.ReadByte( );
						if (success == 0x00)
						{
							// 有成功的数据
							if (GetUInt32( fs, out int contentLength ) <= 0) break;
							// 准备写入服务器数据
							byte[] buffer = new byte[contentLength];
							int expect = fs.Read( buffer, 0, contentLength );
							if (expect != contentLength) break;

							OperateResult write = deviceServer.Write( address, buffer );
							if (write.IsSuccess)
							{
								log.Append( $"{address}[len:{buffer.Length}]" );
								if (i != count - 1) log.Append( ";" );
							}
							else
							{
								deviceServer.LogNet?.WriteError( deviceServer.ToString( ), "Write address: " + address + " failed: " + write.Message );
							}
						}
						else if (success == 0x01)
						{
							// Bool数据信息
							if (GetUInt32( fs, out int contentLength ) <= 0) break;
							// 准备写入服务器数据
							int byteLength = (contentLength + 7) / 8;
							byte[] buffer = new byte[byteLength];
							int expect = fs.Read( buffer, 0, byteLength );
							if (expect != byteLength) break;

							OperateResult write = deviceServer.Write( address, buffer.ToBoolArray( ).SelectBegin( contentLength ) );
							if (write.IsSuccess)
							{
								log.Append( $"{address}[len-bool:{contentLength}]" );
								if (i != count - 1) log.Append( ";" );
							}
							else
							{
								deviceServer.LogNet?.WriteError( deviceServer.ToString( ), "Write address[Bool]: " + address + " failed: " + write.Message );
							}
						}
					}

					deviceServer.LogNet?.WriteInfo( deviceServer.ToString( ), log.ToString( ) );
				}

				if (!writeCycle) break;
				if (abort) break;
			}

			deviceServer.LogNet?.WriteInfo( "Finish!" );
			fs.Close( );
			fs.Dispose( );
			Invoke( new Action( ( ) =>
			{
				button_data_import.Enabled = true;
			} ) );
		}

		private void checkBox_cycle_CheckedChanged( object sender, EventArgs e )
		{
			this.writeCycle = checkBox_cycle.Checked;
		}

		private void button_import_abort_Click( object sender, EventArgs e )
		{
			abort = true;
			button_data_import.Enabled = true;
			button_import_abort.Enabled = false;
		}

		private void label16_Click( object sender, EventArgs e )
		{
			using (FormPipeSessionList form = new FormPipeSessionList( ))
			{
				form.SetPipeSessions( this.deviceServer.GetCommunicationServer( ) );
				form.ShowDialog( );
			}
		}
	}
}
