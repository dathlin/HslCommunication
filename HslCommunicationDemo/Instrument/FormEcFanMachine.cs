using HslCommunication;
using HslCommunication.Profinet.Special;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo.Instrument
{
	public partial class FormEcFanMachine: HslFormContent
	{
		public FormEcFanMachine()
		{
			InitializeComponent();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 读取应急模式速度
			DateTime start = DateTime.Now;
			OperateResult<int> read = EcFanMachine.ReadSpeedEmergency( );
			label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
			DemoUtils.ReadResultRender( read, "应急模式速度", textBox_result );
			codeExampleControl1.ReaderReadCode( "OperateResult<int> read = EcFanMachine.ReadSpeedEmergency( );" );
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 读取最低转速
			DateTime start = DateTime.Now;
			OperateResult<int> read = EcFanMachine.ReadSpeedMin( );
			label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
			DemoUtils.ReadResultRender( read, "最低转速", textBox_result );
			codeExampleControl1.ReaderReadCode( "OperateResult<int> read = EcFanMachine.ReadSpeedMin( );" );
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 读取最高转速
			DateTime start = DateTime.Now;
			OperateResult<int> read = EcFanMachine.ReadSpeedMax( );
			label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
			DemoUtils.ReadResultRender( read, "最高转速", textBox_result );
			codeExampleControl1.ReaderReadCode( "OperateResult<int> read = EcFanMachine.ReadSpeedMax( );" );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// 设置速度
			try
			{
				textBox3.Clear( );
				textBox3.Refresh( );
				DateTime start = DateTime.Now;
				OperateResult<EcFanData> write = EcFanMachine.ControlSpeed( radioButton_run_true.Checked, radioButton4.Checked, int.Parse( textBox1.Text ) );
				label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
				if ( write.IsSuccess )
				{
					textBox3.Text = write.Content.ToString( );
				}
				else
				{
					DemoUtils.ShowMessage( "Write failed: " + write.Message );
				}
				codeExampleControl1.ReaderReadCode( $"OperateResult<EcFanData> write = EcFanMachine.ControlSpeed( {radioButton_run_true.Checked.ToString().ToLower()}, {radioButton4.Checked.ToString().ToLower()}, {int.Parse( textBox1.Text )} );" );
			}
			catch( Exception ex )
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			// 设置站号
			try
			{
				DateTime start = DateTime.Now;
				OperateResult write = EcFanMachine.SetStation( byte.Parse( textBox2.Text ) );
				label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
				if (write.IsSuccess)
				{
					DemoUtils.ShowMessage( "Success" );
				}
				else
				{
					DemoUtils.ShowMessage( "Write failed: " + write.Message );
				}
				codeExampleControl1.ReaderReadCode( $"OperateResult<EcFanData> write = EcFanMachine.ControlSpeed( {radioButton_run_true.Checked.ToString( ).ToLower( )}, {radioButton4.Checked.ToString( ).ToLower( )}, {int.Parse( textBox1.Text )} );" );
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void FormEcFanMachine_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
		private void button1_Click( object sender, EventArgs e )
		{
			// 打开串口
			EcFanMachine?.Close( );
			EcFanMachine = new HslCommunication.Profinet.Special.EcFanMachine( );
			EcFanMachine.LogNet = LogNet;
			EcFanMachine.Station = byte.Parse( textBox_station.Text );

			try
			{
				this.pipeSelectControl1.IniPipe( EcFanMachine );
				OperateResult open = DeviceConnectPLC( EcFanMachine );

				if (open.IsSuccess)
				{
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;


					// 设置代码示例
					codeExampleControl1.SetCodeText( "machine", EcFanMachine, nameof( EcFanMachine.Station ) );
				}
				else
				{
					DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + open.Message + Environment.NewLine +
						"Error: " + open.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 关闭串口
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
			this.pipeSelectControl1.ExtraCloseAction( EcFanMachine );
			EcFanMachine.Close( );
		}

		private EcFanMachine EcFanMachine = null;

		private void FormEcFanMachine_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			this.pipeSelectControl1.SetButtonReference( button1, button2 );
		}




		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation, textBox_station.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, SettingPipe.SerialPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
