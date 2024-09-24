using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Instrument.Light;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo.Light
{
	public partial class FormShineInLight : HslFormContent
	{
		public FormShineInLight( )
		{
			InitializeComponent( );
		}

		private void FormShineInLight_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
		}

		private ShineInLightSourceController lightSourceController;

		private void button2_Click( object sender, EventArgs e )
		{
			lightSourceController?.Close( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
			this.pipeSelectControl1.ExtraCloseAction( lightSourceController );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			lightSourceController?.Close( );
			lightSourceController = new ShineInLightSourceController( );

			try
			{
				this.pipeSelectControl1.IniPipe( lightSourceController );
				lightSourceController.LogNet = new HslCommunication.LogNet.LogNetFileSize( "" );
				lightSourceController.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				OperateResult open = DeviceConnectPLC( lightSourceController );
				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			textBox12.BeginInvoke( new Action(( ) =>
			{
				textBox12.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			} ));
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 读取一次
			if(!byte.TryParse(textBox15.Text, out byte channel ))
			{
				MessageBox.Show( "通道号输入错误，为十进制的整数。" );
				return;
			}

			OperateResult<ShineInLightData> read = lightSourceController.Read( channel );
			if(!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
				return;
			}

			ShowLightData( read.Content );

			textBox_code.Text = $"OperateResult<ShineInLightData> read = lightSourceController.Read( {textBox15.Text} );";
		}

		private void ShowLightData( ShineInLightData data )
		{
			textBox1.Text = data.Color.ToString( );
			if      (data.Color == 1) label5.Text = "红色";
			else if (data.Color == 2) label5.Text = "绿色";
			else if (data.Color == 3) label5.Text = "蓝色";
			else if (data.Color == 4) label5.Text = "白色";
			else label5.Text = "未知";

			textBox3.Text = data.Light.ToString( );
			textBox4.Text = data.LightDegree.ToString( );
			textBox5.Text = data.WorkMode.ToString( );
			if      (data.WorkMode == 0) label9.Text = "延时常亮";
			else if (data.WorkMode == 1) label9.Text = "通道一频闪";
			else if (data.WorkMode == 2) label9.Text = "通道二频闪";
			else if (data.WorkMode == 3) label9.Text = "通道一二频闪";
			else if (data.WorkMode == 4) label9.Text = "普通常亮";
			else if (data.WorkMode == 5) label9.Text = "关闭";
			else label9.Text = "未知";

			textBox6.Text = data.Address.ToString( );
			textBox7.Text = data.PulseWidth.ToString( );
			textBox8.Text = data.Channel.ToString( );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 写入操作
			ShineInLightData data = new ShineInLightData( );
			if (radioButton1.Checked) data.Color = 1;
			else if (radioButton2.Checked) data.Color = 2;
			else if (radioButton3.Checked) data.Color = 3;
			else if (radioButton4.Checked) data.Color = 4;

			if (!byte.TryParse( textBox14.Text, out byte light ))
			{
				MessageBox.Show( "光源亮度输入失败，需要输入十进制的整数" ); return;
			}
			data.Light = light;

			if (!byte.TryParse( textBox13.Text, out byte lightDegress ))
			{
				MessageBox.Show( "光源亮度等级输入失败，需要输入十进制的整数" ); return;
			}
			data.LightDegree = lightDegress;

			if (radioButton5.Checked) data.WorkMode = 0;
			else if (radioButton6.Checked) data.WorkMode = 1;
			else if (radioButton7.Checked) data.WorkMode = 2;
			else if (radioButton8.Checked) data.WorkMode = 3;
			else if (radioButton9.Checked) data.WorkMode = 4;
			else if (radioButton10.Checked) data.WorkMode = 5;

			if (!byte.TryParse(textBox11.Text, out byte address ))
			{
				MessageBox.Show( "地址位输入失败，需要输入十进制的整数" ); return;
			}
			data.Address = address;

			if (!byte.TryParse( textBox10.Text, out byte width ))
			{
				MessageBox.Show( "脉冲宽度输入失败，需要输入十进制的整数" ); return;
			}
			data.PulseWidth = width;

			if (!byte.TryParse( textBox9.Text, out byte channel ))
			{
				MessageBox.Show( "通道输入失败，需要输入十进制的整数" ); return;
			}
			data.Channel = channel;

			OperateResult write = lightSourceController.Write( data );
			if (write.IsSuccess)
			{
				MessageBox.Show( "写入成功" );
			}
			else
			{
				MessageBox.Show( "写入失败:" + write.ToMessageShowString( ) );
			}

			textBox_code2.Text = $"OperateResult write = lightSourceController.Write( \"{data.GetSourceData( ).ToHexString( )}\".ToHexBytes( ) );";
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
		}
		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, DemoControl.SettingPipe.SerialPipe );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}
	}
}
