using HslCommunication;
using HslCommunication.Profinet.Siemens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Siemens
{
	public partial class SiemensWebApiControl : UserControl
	{
		public SiemensWebApiControl( )
		{
			InitializeComponent( );
		}

		private SiemensWebApi siemensTcpNet;

		public void SetReadWriteNet( SiemensWebApi siemensTcpNet )
		{
			this.siemensTcpNet = siemensTcpNet;
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			// 批量读取
			OperateResult<JToken[]> read = await siemensTcpNet.ReadAsync( textBox6.Text.Split( new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries ) );

			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}
			else
			{
				JArray json = new JArray( );
				for (int i = 0; i < read.Content.Length; i++)
				{
					json.Add( read.Content[i] );

				}
				textBox10.Text = json.ToString( );

			}

			textBox_code.Text = $"OperateResult<JToken[]> read = {DemoUtils.PlcDeviceName}.Read( \"{textBox6.Text}\".Split( new char[] {';'}, StringSplitOptions.RemoveEmptyEntries ) );";
		}

		private void button25_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult<byte[]> read = siemensTcpNet.Read( textBox6.Text, 0 );
				if (read.IsSuccess)
				{
					textBox10.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
				}
				else
				{
					MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
				}

				textBox_code.Text = $"OperateResult<byte[]> read = {DemoUtils.PlcDeviceName}.Read( \"{textBox6.Text}\", 0 );";
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Read Failed：" + ex.Message );
			}
		}



		private async void button4_Click( object sender, EventArgs e )
		{
			OperateResult<double> read = await siemensTcpNet.ReadVersionAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( read.Content.ToString( ) );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<double> read = {DemoUtils.PlcDeviceName}.ReadVersion( );";
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			OperateResult read = await siemensTcpNet.ReadPingAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Ping Success" );
			}
			else
			{
				MessageBox.Show( "Read Failed: " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult read = {DemoUtils.PlcDeviceName}.ReadPing( );";
		}

		private async void button7_Click_1( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadDateTime( \"{textBox8.Text}\" );";
		}

		private async void button8_Click( object sender, EventArgs e )
		{
			// time写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.Write( \"{textBox8.Text}\", DateTime.Parse( \"{textBox7.Text}\" ) )";
		}

		private void SiemensWebApiControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				button7.Text = "r-time";
				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";

				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button8.Text = "w-time";

				groupBox3.Text = "Bulk Read test";
				groupBox5.Text = "Special function test";

				button3.Text = "Order";

				label_code.Text = "Code:";
			}
		}
	}
}
