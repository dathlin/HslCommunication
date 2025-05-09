﻿using System;
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
using System.Threading;
using HslCommunication.Profinet.LSIS;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public partial class FormCimonServer : HslFormContent
	{
		public FormCimonServer( )
		{
			InitializeComponent( );
		}

		private void FormSiemens_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				Text = "Cimon Virtual Server" ;
				label3.Text = "Port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label14.Text = "Com:";

				button5.Text = "start com";
			}

			addressExampleControl = new AddressExampleControl( );
			addressExampleControl.SetAddressExample( HslCommunicationDemo.PLC.Cimon.Helper.GetCimonAddress( ) );
			userControlReadWriteServer1.AddSpecialFunctionTab( addressExampleControl, false, DeviceAddressExample.GetTitle( ) );

			codeExampleControl = new CodeExampleControl( );
			userControlReadWriteServer1.AddSpecialFunctionTab( codeExampleControl, false, CodeExampleControl.GetTitle( ) );
			userControlReadWriteServer1.SetEnable( false );
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{
			cimonServer?.ServerClose( );
		}

		#region Server Start


		private HslCommunication.Profinet.Cimon.CimonServer cimonServer;
		private AddressExampleControl addressExampleControl;
		private CodeExampleControl codeExampleControl;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				DemoUtils.ShowMessage( DemoUtils.PortInputWrong );
				return;
			}

			try
			{
				cimonServer = new HslCommunication.Profinet.Cimon.CimonServer();                       // 实例化对象
				cimonServer.OnDataReceived += BusTcpServer_OnDataReceived;
				this.sslServerControl1.InitializeServer( cimonServer );
				cimonServer.ServerStart( port );

				userControlReadWriteServer1.SetReadWriteServer( cimonServer, "D100" );
				button1.Enabled = false;
				userControlReadWriteServer1.SetEnable( true );
				button11.Enabled = true;

				// 设置代码示例
				codeExampleControl.SetCodeText( "server", "", cimonServer );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( ex.Message );
			}
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 停止服务
			cimonServer?.ServerClose( );
			userControlReadWriteServer1.Close( );
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived( object sender, object source, byte[] receive )
		{
			// 我们可以捕获到接收到的客户端的modbus报文
			// 如果是TCP接收的
			if (source is HslCommunication.Core.Net.AppSession session)
			{
				// 获取当前客户的IP地址
				string ip = session.IpAddress;
			}

			// 如果是串口接收的
			if (source is System.IO.Ports.SerialPort serialPort)
			{
				// 获取当前的串口的名称
				string portName = serialPort.PortName;
			}
		}

		#endregion

		private void Button5_Click(object sender, EventArgs e)
		{
			// 启动串口
			if (cimonServer != null)
			{
				try
				{
					cimonServer.StartSerialSlave(textBox10.Text);
					button5.Enabled = false;
					button2.Enabled = true;

					// 设置代码示例
					codeExampleControl.SetCodeText( "server", textBox10.Text, cimonServer );
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage("Start Failed：" + ex.Message);
				}
			}
			else
			{
				DemoUtils.ShowMessage("Start tcp server first please!");
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlCom, textBox10.Text );
			element.SetAttributeValue( "FrameNo", textBox_frameNo.Text );
			this.userControlReadWriteServer1.GetDataTable( element );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox10.Text = element.Attribute( DemoDeviceList.XmlCom ).Value;
			textBox_frameNo.Text = element.Attribute( "FrameNo" ).Value;
			this.userControlReadWriteServer1.LoadDataTable( element );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// 关闭串口
			if (cimonServer != null)
			{
				try
				{
					cimonServer.CloseSerialSlave();
					button2.Enabled = false;
					button5.Enabled = true;
				}
				catch (Exception ex)
				{
					DemoUtils.ShowMessage("Start Failed：" + ex.Message);
				}
			}
			else
			{
				DemoUtils.ShowMessage("Start tcp server first please!");
			}
		}
	}
}
