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
using HslCommunication.Instrument.IEC;
using System.Threading;
using System.IO.Ports;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormIEC104 : HslFormContent
	{
		public FormIEC104( )
		{
			InitializeComponent( );
		}

		private IEC104 iec104 = null;
		private CodeExampleControl codeExampleControl = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			comboBox_write_type.SelectedIndex = 0;
			comboBox_write_reason.SelectedIndex = 5;
			Language( Program.Language );

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, show: false, CodeExampleControl.GetTitle( ) );
		}


		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "IEC104 Read Demo";
				label21.Text = "Station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button5.Text = "Time";
				label13.Text = "Results:";
				label6.Text = "Type:";
				label7.Text = "Reason:";
				label8.Text = "Address:";
				label9.Text = "Value:";

				button_write_bool.Text = "w-bool";
				button_write_short.Text = "w-short";
				button_write_float.Text = "w-float";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}
		

		#region Connect And Close



		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox_station.Text, out int station ))
			{
				MessageBox.Show( "Station Input wrong!" );
				return;
			}

			iec104?.ConnectClose( );
			iec104 = new IEC104( );
			iec104.Station = station;
			iec104.OnIEC104MessageReceived += Iec104_IEC104MessageReceived;
			iec104.LogNet = LogNet;
			try
			{
				this.pipeSelectControl1.IniPipe( iec104 );
				OperateResult connect = DeviceConnectPLC( iec104 );
				if (connect.IsSuccess)
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;


					codeExampleControl.SetCodeText( "iec104", iec104, nameof( iec104.Station ) );
				}
				else
				{
					MessageBox.Show( HslCommunication.StringResources.Language.ConnectedFailed + connect.Message + Environment.NewLine +
						"Error: " + connect.ErrorCode );
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		public static string Example()
		{
			return
@"iec104.OnIEC104MessageReceived += ( object sender, IEC104MessageEventArgs e ) =>
{
	if (e.TypeID == IEC104.TypeID.M_ME_TF_1 || e.TypeID == IEC104.TypeID.M_ME_NC_1)
	{
		// 短浮点遥测值，带不带时标都处理
		if (e.IsAddressContinuous)
		{
			// 信息对象连续，解析出实际的值
			List<IecValueObject<float>> list = IecValueObject<float>.ParseFloatValue( e );
		}
		else
		{
			// 信息对象不连续，直接显示到文本框
			List<IecValueObject<float>> list = IecValueObject<float>.ParseFloatValue( e );
		}
	}
	else if (e.TypeID == IEC104.TypeID.M_SP_NA_1 || e.TypeID == IEC104.TypeID.M_SP_TB_1)
	{
		// 单点遥信，带品质描述，带不带时标都处理
		if (e.IsAddressContinuous)
		{
			// 信息对象连续
			List<IecValueObject<byte>> list = IecValueObject<byte>.ParseYaoXinValue( e );
		}
		else
		{
			// 信息对象不连续
			List<IecValueObject<byte>> list = IecValueObject<byte>.ParseYaoXinValue( e );
		}
	}
	else if (e.TypeID == IEC104.TypeID.M_DP_NA_1 || e.TypeID == IEC104.TypeID.M_DP_TB_1)
	{
		// 双点遥信，带品质描述，带不带时标都处理
		if (e.IsAddressContinuous)
		{
			// 信息对象连续
			List<IecValueObject<byte>> list = IecValueObject<byte>.ParseYaoXinValue( e );
		}
		else
		{
			// 信息对象不连续
			List<IecValueObject<byte>> list = IecValueObject<byte>.ParseYaoXinValue( e );
		}
	}
	else if (e.TypeID == IEC104.TypeID.M_ME_ND_1)
	{
		// 归一化标度值
		if (e.IsAddressContinuous)
		{
			// 如果当前正在查看单点遥信界面
			List<IecValueObject<short>> list = IecValueObject<short>.ParseInt16Value( e );
		}
		else
		{
			// 信息对象不连续
			List<IecValueObject<short>> list = IecValueObject<short>.ParseInt16Value( e );
			return;
		}
	}
	else if (e.TypeID == IEC104.TypeID.M_ME_NB_1 || e.TypeID == IEC104.TypeID.M_ME_TE_1)
	{
		// 标度化遥测值，不带时标
		if (e.IsAddressContinuous)
		{
			// 如果当前正在查看遥信界面
			List<IecValueObject<short>> list = IecValueObject<short>.ParseInt16Value( e );
		}
		else
		{
			// 信息对象不连续
			List<IecValueObject<short>> list = IecValueObject<short>.ParseInt16Value( e );
		}
	}
	else if (e.TypeID == IEC104.TypeID.C_IC_NA_1)
	{
		// 总召唤
		AppendText( e, string.Empty, e.ASDU );
		return;
	}
};";

		}

		private void AppendText( IEC104MessageEventArgs e, string text, byte[] asdu = null )
		{
			if (asdu == null)
				textBox10.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff " ) + e.ToString( ) + ":  " + text + Environment.NewLine );
			else
				textBox10.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff " ) + e.ToString( ) + ":  " + text + "  ASDU: " + asdu.ToHexString( ' ' ) + Environment.NewLine );
		}

		private void AppendText<T>( IEC104MessageEventArgs e, List<IecValueObject<T>> value )
		{
			StringBuilder sb = new StringBuilder( );
			for (int i = 0; i < value.Count; i++)
			{
				if (e.WithTimeInfo( ))
					sb.Append( $"Address[{value[i].Address}] 品质[{value[i].Quality}] 时标[{value[i].Time}] 值[{value[i].Value}]   " );
				else
					sb.Append( $"Address[{value[i].Address}] 品质[{value[i].Quality}] 值[{value[i].Value}]   " );
			}
			AppendText( e, sb.ToString( ), null );
			return;
		}

		private void RenderDataGridView<T>( List<IecValueObject<T>> value )
		{
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, value.Count );
			for (int i = 0; i < value.Count; i++)
			{
				DataGridViewRow dgvr = dataGridView1.Rows[i];
				dgvr.Cells[0].Value = value[i].Address;
				dgvr.Cells[1].Value = value[i].Value.ToString( );
				dgvr.Cells[2].Value = ((value[i].Quality & 0x10) >> 4).ToString( );
				dgvr.Cells[3].Value = ((value[i].Quality & 0x20) >> 5).ToString( );
				dgvr.Cells[4].Value = ((value[i].Quality & 0x40) >> 6).ToString( );
				dgvr.Cells[5].Value = ((value[i].Quality & 0x80) >> 7).ToString( );
				if (value[i].Time != DateTime.MinValue)
					dgvr.Cells[6].Value = value[i].Time.ToString( "yyyy-MM-dd HH:mm:ss" );
				else
					dgvr.Cells[6].Value = string.Empty;
			}
		}

		private void Iec104_IEC104MessageReceived( object sender, IEC104MessageEventArgs e )
		{
			if (!checkBox1.Checked)
			{
				Invoke( new Action( ( ) =>
				  {
					  if (e.TypeID == IEC104.TypeID.M_ME_TF_1 || e.TypeID == IEC104.TypeID.M_ME_NC_1)
					  {
						  // 短浮点遥测值，带不带时标都处理
						  if (e.IsAddressContinuous)
						  {
							  // 信息对象连续

							  // 如果当前正在查看单点遥信界面
							  if (tabControl1.SelectedTab == tabPage2)
							  {
								  if (radioButton5.Checked)
								  {
									  RenderDataGridView( IecValueObject<float>.ParseFloatValue( e ) );
								  }
							  }
						  }
						  else
						  {
							  // 信息对象不连续，直接显示到文本框
							  AppendText( e, IecValueObject<float>.ParseFloatValue( e ) );
							  return;
						  }
					  }
					  else if (e.TypeID == IEC104.TypeID.M_SP_NA_1 || e.TypeID == IEC104.TypeID.M_SP_TB_1)
					  {
						  // 单点遥信，带品质描述，带不带时标都处理
						  if (e.IsAddressContinuous)
						  {
							  // 信息对象连续

							  // 如果当前正在查看单点遥信界面
							  if (tabControl1.SelectedTab == tabPage2)
							  {
								  if (radioButton1.Checked)
								  {
									  RenderDataGridView( IecValueObject<byte>.ParseYaoXinValue( e ) );
								  }
							  }
						  }
						  else
						  {
							  // 信息对象不连续
							  AppendText( e, IecValueObject<byte>.ParseYaoXinValue( e ) );
							  return;
						  }
					  }
					  else if (e.TypeID == IEC104.TypeID.M_DP_NA_1 || e.TypeID == IEC104.TypeID.M_DP_TB_1)
					  {
						  // 双点遥信，带品质描述，带不带时标都处理
						  if (e.IsAddressContinuous)
						  {
							  // 信息对象连续

							  // 如果当前正在查看单点遥信界面
							  if (tabControl1.SelectedTab == tabPage2)
							  {
								  if (radioButton2.Checked)
								  {
									  RenderDataGridView( IecValueObject<byte>.ParseYaoXinValue( e ) );
								  }
							  }
						  }
						  else
						  {
							  // 信息对象不连续
							  AppendText( e, IecValueObject<byte>.ParseYaoXinValue( e ));
							  return;
						  }
					  }
					  else if ( e.TypeID == IEC104.TypeID.M_ME_ND_1)
					  {
						  // 归一化标度值
						  if (e.IsAddressContinuous)
						  {
							  // 如果当前正在查看单点遥信界面
							  if (tabControl1.SelectedTab == tabPage2)
							  {
								  if (radioButton3.Checked)
								  {
									  RenderDataGridView( IecValueObject<short>.ParseInt16Value( e ) );
								  }
							  }
						  }
						  else
						  {
							  // 信息对象不连续
							  AppendText( e, IecValueObject<short>.ParseInt16Value( e ) );
							  return;
						  }
					  }
					  else if (e.TypeID == IEC104.TypeID.M_ME_NB_1 || e.TypeID == IEC104.TypeID.M_ME_TE_1)
					  {
						  // 标度化遥测值，不带时标
						  if (e.IsAddressContinuous)
						  {
							  // 如果当前正在查看遥信界面
							  if (tabControl1.SelectedTab == tabPage2)
							  {
								  if (radioButton4.Checked)
								  {
									  RenderDataGridView( IecValueObject<short>.ParseInt16Value( e ) );
								  }
							  }
						  }
						  else
						  {
							  // 信息对象不连续
							  AppendText( e, IecValueObject<short>.ParseInt16Value( e ) );
							  return;
						  }
					  }
					  else if ( e.TypeID == IEC104.TypeID.C_IC_NA_1)
					  {
						  // 总召唤
						  AppendText( e, string.Empty, e.ASDU );
						  return;
					  }
					  AppendText( e, string.Empty, e.ASDU );
				  } ) );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			iec104.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
			this.pipeSelectControl1.ExtraCloseAction( iec104 );
		}
		
		#endregion

		#region 报文读取测试

		private void button3_Click( object sender, EventArgs e )
		{
			OperateResult send = iec104.SendFrameIMessage( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) );
			if (!send.IsSuccess)
				MessageBox.Show( "Send Failed：" + send.ToMessageShowString( ) );
		}

		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			this.pipeSelectControl1.SaveXmlParameter( element );
			element.SetAttributeValue( DemoDeviceList.XmlStation,   textBox_station.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.pipeSelectControl1.LoadXmlParameter( element, DemoControl.SettingPipe.TcpPipe );
			textBox_station.Text = element.Attribute( DemoDeviceList.XmlStation ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button5_Click( object sender, EventArgs e )
		{
			textBox4.Text = HslCommunication.Instrument.IEC.Helper.IECHelper.GetAbsoluteTimeScale( DateTime.Now, true ).ToHexString( ' ' );
		}

		private void button_u_start_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x07);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}

			textBox_code.Text = $"OperateResult send = iec104.SendFrameUMessage( 0x07 );";
		}

		private void button_u_stop_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x13);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}

			textBox_code.Text = $"OperateResult send = iec104.SendFrameUMessage( 0x13 );";
		}

		private void button_u_test_Click(object sender, EventArgs e)
		{
			OperateResult send = iec104.SendFrameUMessage(0x43);
			if (send.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + send.Message);
			}

			textBox_code.Text = $"OperateResult send = iec104.SendFrameUMessage( 0x43 );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			// 响应总召唤
			OperateResult send = iec104.TotalSubscriptions( );
			if (send.IsSuccess)
			{
				MessageBox.Show( "Send Success!" );
			}
			else
			{
				MessageBox.Show( "Send failed: " + send.Message );
			}

			textBox_code.Text = $"OperateResult send = iec104.TotalSubscriptions( );";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			// 定时总召唤
			OperateResult send = iec104.TotalSubscriptions( 0x01 );
			if (send.IsSuccess)
			{
				MessageBox.Show( "Send Success!" );
			}
			else
			{
				MessageBox.Show( "Send failed: " + send.Message );
			}

			textBox_code.Text = $"OperateResult send = iec104.TotalSubscriptions( 0x01 );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 越限总召唤
			OperateResult send = iec104.TotalSubscriptions( 0x03 );
			if (send.IsSuccess)
			{
				MessageBox.Show( "Send Success!" );
			}
			else
			{
				MessageBox.Show( "Send failed: " + send.Message );
			}

			textBox_code.Text = $"OperateResult send = iec104.TotalSubscriptions( 0x03 );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 积累量总召唤
			OperateResult send = iec104.SendFrameIMessage( new byte[] { 0x65, 0x01, 0x07, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01 } );
			if (send.IsSuccess)
			{
				MessageBox.Show( "Send Success!" );
			}
			else
			{
				MessageBox.Show( "Send failed: " + send.Message );
			}

			textBox_code.Text = $"OperateResult send = iec104.SendFrameIMessage( new byte[] {{ 0x65, 0x01, 0x07, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01 }} );";
		}

		private void WriteIec( byte[] value )
		{
			byte type = byte.Parse( Regex.Match( comboBox_write_type.SelectedItem.ToString( ), "^[0-9]+" ).Value );
			ushort reason = ushort.Parse( Regex.Match( comboBox_write_reason.SelectedItem.ToString( ), "^[0-9]+" ).Value );
			ushort address = ushort.Parse( textBox_write_address.Text );

			OperateResult send = iec104.WriteIec( type, reason, address, value );

			textBox_code.Text = $"OperateResult send = iec104.WriteIec( \"{type}\", \"{reason}\", \"{address}\", \"{value.ToHexString( )}\".ToHexBytes( ) );";
		}

		private void button_write_bool_Click( object sender, EventArgs e )
		{
			bool value = false;
			if (textBox_write_value.Text == "1") value = true;
			else if (textBox_write_value.Text == "0") value = false;
			else value = bool.Parse( textBox_write_value.Text );

			WriteIec( value ? new byte[] { 0x01 } : new byte[] { 0x00 } );
		}

		private void button_write_short_Click( object sender, EventArgs e )
		{
			WriteIec( BitConverter.GetBytes( short.Parse( textBox_write_value.Text ) ) );
		}

		private void button_write_float_Click( object sender, EventArgs e )
		{
			WriteIec( BitConverter.GetBytes( float.Parse( textBox_write_value.Text ) ) );
		}

	}
}
