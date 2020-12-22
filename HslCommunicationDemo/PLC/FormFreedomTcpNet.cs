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
using HslCommunication.Profinet.Freedom;
using HslCommunication;

namespace HslCommunicationDemo
{
	public partial class FormFreedomTcpNet : HslFormContent
	{
		public FormFreedomTcpNet( )
		{
			InitializeComponent( );
			freedom = new FreedomTcpNet( );
		}


		private FreedomTcpNet freedom = null;


		private void FormSiemens_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			Language( Program.Language );


			comboBox2.SelectedIndex = 3;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
		}

		private void ComboBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if (freedom != null)
			{
				switch (comboBox2.SelectedIndex)
				{
					case 0: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.ABCD; break;
					case 1: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.BADC; break;
					case 2: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.CDAB; break;
					case 3: freedom.ByteTransform.DataFormat = HslCommunication.Core.DataFormat.DCBA; break;
					default: break;
				}
			}
		}

		private void Language( int language )
		{
			if (language == 2)
			{
				Text = "Free protocol access based on Tcp ip";

				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";

				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";


				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
			}
		}

		private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
		{

		}

		#region Connect And Close



		private async void button1_Click( object sender, EventArgs e )
		{
			freedom.IpAddress = textBox1.Text;

			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if (radioButton1.Checked) freedom.ByteTransform = new HslCommunication.Core.RegularByteTransform( );
			if (radioButton2.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseBytesTransform( );
			if (radioButton3.Checked) freedom.ByteTransform = new HslCommunication.Core.ReverseWordTransform( );

			ComboBox2_SelectedIndexChanged( null, null );
			freedom.ByteTransform.IsStringReverseByteWord = checkBox3.Checked;

			freedom.Port = port;

			freedom.ConnectClose( );

			button1.Enabled = false;
			freedom.ConnectTimeOut = 3000; // 连接3秒超时
			OperateResult connect = await freedom.ConnectServerAsync( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( HslCommunication.StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				userControlReadWriteOp1.SetReadWriteNet( freedom, "", true );
			}
			else
			{
				MessageBox.Show( connect.Message );
				button1.Enabled = true;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			freedom.ConnectClose( );
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		#endregion

		#region 批量读取测试

		private void button25_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = freedom.Read( textBox6.Text, 0 );
			if (read.IsSuccess)
			{
				textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}


		#endregion

		#region 报文读取测试


		private void button26_Click( object sender, EventArgs e )
		{
			OperateResult<byte[]> read = freedom.ReadFromCoreServer( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
			if (read.IsSuccess)
			{
				textBox11.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content, ' ' );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
		}

		#endregion
		

	}

}
