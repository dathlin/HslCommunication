﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Keyence;
using System.Threading;
using HslCommunication;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public partial class FormKeyenceDLEN1 : HslFormContent
	{
		public FormKeyenceDLEN1( )
		{
			InitializeComponent( );
			DemoUtils.SetPanelAnchor( panel1, panel2 );
		}


		private KeyenceDLEN1 keyence = null;

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			panel2.Enabled = false;
			
			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Keyence DL-EN1 Demo";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label6.Text = "address:";
				label7.Text = "result:";

				button_read_string.Text = "r-string";


				groupBox1.Text = "Single Data Read test";
				label22.Text = "";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}

		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			if(!int.TryParse(textBox2.Text,out int port))
			{
				DemoUtils.ShowMessage( "端口输入格式不正确！" );
				return;
			}
			
			keyence?.ConnectClose( );
			keyence = new KeyenceDLEN1( textBox_ip.Text, port );
			keyence.LogNet = LogNet;
			try
			{
				OperateResult connect = await keyence.ConnectServerAsync( );
				if (connect.IsSuccess)
				{
					DemoUtils.ShowMessage( "连接成功！" );
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
				}
				else
				{
					DemoUtils.ShowMessage( "连接失败！" );
				}
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			keyence?.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 单数据读取测试


		private void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			DateTime start = DateTime.Now;
			OperateResult<string[]> read = keyence.ReadByCommand( textBox3.Text.Split( new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries ) );
			label_time.Text = (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
			if (read.IsSuccess)
			{
				textBox_result.Lines = read.Content;
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
			}
		}


		#endregion


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void label7_Click( object sender, EventArgs e )
		{

		}
	}
	
}
