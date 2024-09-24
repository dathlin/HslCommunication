using HslCommunication;
using HslCommunication.Profinet.AllenBradley;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.AllenBrandly
{
	public partial class AllenBrandlyControl : UserControl
	{
		public AllenBrandlyControl( )
		{
			InitializeComponent( );
		}

		public void SetDevice( IReadWriteCip cipNet, string address )
		{
			this.cipNet = cipNet;
			textBox_date_address.Text = address;
			textBox3.Text = address;
		}

		private IReadWriteCip cipNet;

		private void button6_Click( object sender, EventArgs e )
		{
			// 读日期格式
			OperateResult<DateTime> read = cipNet.ReadDate( textBox_date_address.Text );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read failed! " + read.ToMessageShowString( ) );
			}
			else
			{
				textBox_date_render.Text = read.Content.ToString( );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadDate( \"{textBox_date_address.Text}\" );";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 写日期格式
			OperateResult write = cipNet.WriteDate( textBox_date_address.Text, DateTime.Parse( textBox_date_render.Text ) );
			if (!write.IsSuccess)
			{
				MessageBox.Show( "Write failed! " + write.ToMessageShowString( ) );
			}
			else
			{
				MessageBox.Show( "Write Success" );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteDate( \"{textBox_date_address.Text}\", DateTime.Parse( \"{textBox_date_render.Text}\" ) );";
		}

		private void button10_Click( object sender, EventArgs e )
		{
			// 写日期时间格式
			OperateResult write = cipNet.WriteTimeAndDate( textBox_date_address.Text, DateTime.Parse( textBox_date_render.Text ) );
			if (!write.IsSuccess)
			{
				MessageBox.Show( "Write failed! " + write.ToMessageShowString( ) );
			}
			else
			{
				MessageBox.Show( "Write Success" );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteTimeAndDate( \"{textBox_date_address.Text}\", DateTime.Parse( \"{textBox_date_render.Text}\" ) );";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			// 读时间
			OperateResult<TimeSpan> read = cipNet.ReadTime( textBox_date_address.Text );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read failed! " + read.ToMessageShowString( ) );
			}
			else
			{
				textBox_date_render.Text = read.Content.ToString( );
			}

			textBox_code.Text = $"OperateResult<TimeSpan> read = {DemoUtils.PlcDeviceName}.ReadTime( \"{textBox_date_address.Text}\" );";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			// 写时间
			OperateResult write = cipNet.WriteTime( textBox_date_address.Text, TimeSpan.Parse( textBox_date_render.Text ) );
			if (!write.IsSuccess)
			{
				MessageBox.Show( "Write failed! " + write.ToMessageShowString( ) );
			}
			else
			{
				MessageBox.Show( "Write Success" );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteTime( \"{textBox_date_address.Text}\", TimeSpan.Parse( \"{textBox_date_render.Text}\" ) );";
		}

		private void button11_Click( object sender, EventArgs e )
		{
			// 写time of date格式数据
			OperateResult write = cipNet.WriteTimeOfDate( textBox_date_address.Text, TimeSpan.Parse( textBox_date_render.Text ) );
			if (!write.IsSuccess)
			{
				MessageBox.Show( "Write failed! " + write.ToMessageShowString( ) );
			}
			else
			{
				MessageBox.Show( "Write Success" );
			}

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteTimeOfDate( \"{textBox_date_address.Text}\", TimeSpan.Parse( \"{textBox_date_render.Text}\" ) );";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult write = cipNet.WriteTag(
					textBox3.Text,
					Convert.ToUInt16( textBox4.Text, 16 ),
					textBox5.Text.ToHexBytes( ),
					int.Parse( textBox7.Text ) );
				DemoUtils.WriteResultRender( write, textBox3.Text );

				textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteTag( \"{textBox3.Text}\"," +
					$" 0x{Convert.ToUInt16( textBox4.Text, 16 ):X}," +
					$" \"{textBox5.Text}\".ToHexBytes( )," +
					$" {int.Parse( textBox7.Text )} );";
			}
			catch (Exception ex)
			{
				MessageBox.Show( "write failed：" + ex.Message );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OperateResult<ushort, byte[]> read = cipNet.ReadTag( textBox3.Text, ushort.Parse( textBox7.Text ) );
			if (!read.IsSuccess)
			{
				MessageBox.Show( $"Read failed! " + read.ToMessageShowString( ) );
			}
			else
			{
				textBox4.Text = read.Content1.ToString( "X" );
				textBox5.Text = read.Content2.ToHexString( ' ' );
			}

			textBox_code.Text = $"OperateResult<ushort, byte[]> read = {DemoUtils.PlcDeviceName}.ReadTag( \"{textBox3.Text}\", ushort.Parse( \"{textBox7.Text}\" ) );";
		}

		private void button12_Click( object sender, EventArgs e )
		{
			// 读设备类型
			OperateResult<string> read = cipNet.ReadPlcType( );
			if (read.IsSuccess)
			{
				textBox5.Text = read.Content;
			}
			else
			{
				MessageBox.Show( $"Read failed! " + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadPlcType( );";

		}

		private void AllenBrandlyControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				groupBox1.Text = "Time Tag read/write";
				label8.Text = "Data:";
				label2.Text = "Address:";
				groupBox5.Text = "Tag type/data Read Write";
				label4.Text = "Address:";
				label5.Text = "Type:";
				label6.Text = "Data:";
				label7.Text = "Len:";
				button4.Text = "Write";
				button5.Text = "Read";
				button12.Text = "r-plc-type";
				label_code.Text = "Code:";
			}
		}
	}
}
