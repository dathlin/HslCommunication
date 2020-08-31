using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using System.Threading;
using HslCommunication.Profinet.IDCard;
using HslCommunication;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormSAMSerial : HslFormContent
	{
		public FormSAMSerial( )
		{
			InitializeComponent( );
			sAMSerial = new SAMSerial( );
		}


		private SAMSerial sAMSerial = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			comboBox3.DataSource = SerialPort.GetPortNames( );
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
			Language( Program.Language );
		}


		private void Language( int language )
		{
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int baudRate ))
			{
				MessageBox.Show( DemoUtils.BaudRateInputWrong );
				return;
			}

			if (!int.TryParse( textBox16.Text, out int dataBits ))
			{
				MessageBox.Show( DemoUtils.DataBitsInputWrong );
				return;
			}

			if (!int.TryParse( textBox17.Text, out int stopBits ))
			{
				MessageBox.Show( DemoUtils.StopBitInputWrong );
				return;
			}
			

			sAMSerial?.Close( );
			sAMSerial = new SAMSerial( );
			
			try
			{
				sAMSerial.SerialPortInni( sp =>
				{
					sp.PortName = comboBox3.Text;
					sp.BaudRate = baudRate;
					sp.DataBits = dataBits;
					sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
					sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
				} );

				sAMSerial.Open( );
				button2.Enabled = true;
				button1.Enabled = false;
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
			sAMSerial.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}




		#endregion

		#region 单数据读取测试


		private void button_sam1_Click( object sender, EventArgs e )
		{
			// 安全模块号
			OperateResult<string> read = sAMSerial.ReadSafeModuleNumber( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox4.Text = "Result:" + read.Content;
			}
		}

		private void button_sam2_Click( object sender, EventArgs e )
		{
			// 检查安全模块状态
			OperateResult read = sAMSerial.CheckSafeModuleStatus( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox4.Text = "检查安全模块状态成功";
			}
		}


		private void button_sam3_Click( object sender, EventArgs e )
		{
			// 寻找卡片
			OperateResult read = sAMSerial.SearchCard( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox4.Text = "寻找卡片成功";
			}
		}

		private void button_sam4_Click( object sender, EventArgs e )
		{
			// 选择卡片
			OperateResult read = sAMSerial.SelectCard( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox4.Text = "选择卡片成功";
			}
		}

		private void button_sam5_Click( object sender, EventArgs e )
		{
			// 读取卡片信息
			OperateResult<IdentityCard> read = sAMSerial.ReadCard( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed:" + read.Message );
			}
			else
			{
				textBox4.Text = read.Content.ToString( );
				//string tms = Encoding.Unicode.GetString( read.Content.Portrait );
				//File.WriteAllBytes( Path.Combine( Application.StartupPath, "cart.bmp" ), read.Content.Portrait );
				//MemoryStream stream = new MemoryStream( read.Content.Portrait );
				//Bitmap bitmap = BitmapFactory.decodeByteArray( image_b, 0, image_b.length );

				//stream.Dispose( );
				//pictureBox2.Image?.Dispose( );
				//pictureBox2.Image = Image.FromFile( Path.Combine( Application.StartupPath, "cart.bmp" ) );
			}
		}



		#endregion

		private void button_sam_start_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox9.Text, out int sleep ))
			{
				MessageBox.Show( "当前的数据错误，必须整数！" );
				return;
			}

			new Thread( new ThreadStart( ThreadBackgroundReadCard ) ) { IsBackground = true }.Start( );
			button_sam_start.Enabled = false;
		}

		private int sleep = 1000;

		private void ThreadBackgroundReadCard( )
		{
			while (true)
			{
				Thread.Sleep( sleep );
				OperateResult search = sAMSerial.SearchCard( );
				if (!search.IsSuccess)
				{
					continue;
				}

				Invoke( new Action( ( ) =>
				{
					textBox10.Text = "";
					pictureBox1.Image = null;
				} ) );
				Thread.Sleep( 100 );

				if (sAMSerial.SelectCard( ).IsSuccess)
				{
					OperateResult<IdentityCard> read = sAMSerial.ReadCard( );
					if (read.IsSuccess)
					{
						Invoke( new Action<IdentityCard>( m =>
						{
							textBox10.Text = read.Content.ToString( );
							//MemoryStream stream = new MemoryStream( read.Content.Portrait );
							//Bitmap bitmap = new Bitmap( stream );
							//stream.Dispose( );
							//pictureBox1.Image?.Dispose( );
							//pictureBox1.Image = bitmap;
						} ), read.Content );
					}
					else
					{
						Invoke( new Action( ( ) =>
						{
							textBox10.Text = $"读卡失败：{read.Message}";
						} ) );
					}
				}
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlCom, comboBox3.Text );
			element.SetAttributeValue( DemoDeviceList.XmlBaudRate, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlDataBits, textBox16.Text );
			element.SetAttributeValue( DemoDeviceList.XmlStopBit, textBox17.Text );
			element.SetAttributeValue( DemoDeviceList.XmlParity, comboBox1.SelectedIndex );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			comboBox3.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlBaudRate ).Value;
			textBox16.Text = element.Attribute( DemoDeviceList.XmlDataBits ).Value;
			textBox17.Text = element.Attribute( DemoDeviceList.XmlStopBit ).Value;
			comboBox1.SelectedIndex = int.Parse( element.Attribute( DemoDeviceList.XmlParity ).Value );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
