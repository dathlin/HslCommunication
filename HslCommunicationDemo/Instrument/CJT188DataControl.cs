using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Instrument.CJT.Helper;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Instrument
{
	public partial class CJT188DataControl : UserControl
	{
		public CJT188DataControl( )
		{
			InitializeComponent( );

			// 添加表格的行
			AddressExampleControl.DataGridSpecifyRowCount( dataGridView1, 15 + 5 + 5 + 2);
			dataGridView1.Rows[0].Cells[0].Value = "计量数据(当前累积流量)";
			dataGridView1.Rows[0].Tag = "90-1F";
			dataGridView1.Rows[0].Cells[3].Value = "90-1F";

			dataGridView1.Rows[1].Cells[0].Value = "计量数据(结算日累积流量)";
			dataGridView1.Rows[1].Tag = "90-1F";

			dataGridView1.Rows[2].Cells[0].Value = "计量数据(实时时间)";
			dataGridView1.Rows[2].Tag = "90-1F";

			for ( int i = 0; i < 12; i++ )
			{
				string add = $"D1-{(32 + i).ToString( "X" )}";
				dataGridView1.Rows[i + 3].Cells[0].Value = $"上{(i + 1)}月结算日计量数据";
				dataGridView1.Rows[i + 3].Tag = add;
				dataGridView1.Rows[i + 3].Cells[3].Value = add;
			}

			dataGridView1.Rows[15].Cells[0].Value = "购入金额.本次购入序号";
			dataGridView1.Rows[16].Cells[0].Value = "购入金额.本次购入金额";
			dataGridView1.Rows[17].Cells[0].Value = "购入金额.累计购入金额";
			dataGridView1.Rows[18].Cells[0].Value = "购入金额.剩余金额";
			dataGridView1.Rows[19].Cells[0].Value = "表状态";
			dataGridView1.Rows[15].Cells[3].Value = "81-05";


			dataGridView1.Rows[20].Cells[0].Value = "价格表.价格一";
			dataGridView1.Rows[21].Cells[0].Value = "价格表.用量一";
			dataGridView1.Rows[22].Cells[0].Value = "价格表.价格二";
			dataGridView1.Rows[23].Cells[0].Value = "价格表.用量二";
			dataGridView1.Rows[24].Cells[0].Value = "价格表.价格三";
			dataGridView1.Rows[20].Cells[3].Value = "81-02";

			dataGridView1.Rows[25].Cells[0].Value = "结算日";
			dataGridView1.Rows[25].Cells[3].Value = "81-03";
			dataGridView1.Rows[26].Cells[0].Value = "抄表日";
			dataGridView1.Rows[26].Cells[3].Value = "81-04";
		}
		public static string GetTitle( ) => Program.Language == 1 ? "数据列表" : "Data List";


		public void SetCjt188( ICjt188 cjt188 )
		{
			this.cjt188 = cjt188;
		}

		private ICjt188 cjt188;

		private void CJT188DataControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "DataList";
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			OperateResult<string[]> read = cjt188.ReadStringArray( "90-1F" );
			if (read.IsSuccess)
			{
				dataGridView1.Rows[0].Cells[1].Value = read.Content[0];
				if (read.Content.Length > 1) dataGridView1.Rows[0].Cells[2].Value = read.Content[1];
				if (read.Content.Length > 2) dataGridView1.Rows[1].Cells[1].Value = read.Content[2];
				if (read.Content.Length > 3) dataGridView1.Rows[1].Cells[2].Value = read.Content[3];
				if (read.Content.Length > 4) dataGridView1.Rows[2].Cells[1].Value = read.Content[4];
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
				return;
			}

			for ( int i = 0; i < 12; i++ )
			{
				if (dataGridView1.Rows[i + 3].Tag is  string address )
				{
					read = cjt188.ReadStringArray( address );
					if (read.IsSuccess)
					{
						dataGridView1.Rows[i + 3].Cells[1].Value = read.Content[0];
						if (read.Content.Length > 1) dataGridView1.Rows[i + 3].Cells[2].Value = read.Content[1];
					}
					else
					{
						DemoUtils.ShowMessage( "Read failed: " + read.Message );
						return;
					}
				}
			}

			read = cjt188.ReadStringArray( "81-05" );
			if (read.IsSuccess)
			{
				dataGridView1.Rows[15].Cells[1].Value = read.Content[0];
				if (read.Content.Length > 1) dataGridView1.Rows[16].Cells[1].Value = read.Content[1];
				if (read.Content.Length > 2) dataGridView1.Rows[17].Cells[1].Value = read.Content[2];
				if (read.Content.Length > 3) dataGridView1.Rows[18].Cells[1].Value = read.Content[3];
				if (read.Content.Length > 4) dataGridView1.Rows[19].Cells[1].Value = read.Content[4];
			}

			read = cjt188.ReadStringArray( "81-02" );
			if (read.IsSuccess)
			{
				dataGridView1.Rows[20].Cells[1].Value = read.Content[0];
				if (read.Content.Length > 1) dataGridView1.Rows[21].Cells[1].Value = read.Content[1];
				if (read.Content.Length > 2) dataGridView1.Rows[22].Cells[1].Value = read.Content[2];
				if (read.Content.Length > 3) dataGridView1.Rows[23].Cells[1].Value = read.Content[3];
				if (read.Content.Length > 4) dataGridView1.Rows[24].Cells[1].Value = read.Content[4];
			}

			read = cjt188.ReadStringArray( "81-03" );
			if (read.IsSuccess) dataGridView1.Rows[25].Cells[1].Value = read.Content[0];

			read = cjt188.ReadStringArray( "81-04" );
			if (read.IsSuccess) dataGridView1.Rows[26].Cells[1].Value = read.Content[0];
		}
	}
}
