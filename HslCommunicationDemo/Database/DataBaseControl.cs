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
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Database
{
	public partial class DataBaseControl : UserControl
	{
		public DataBaseControl( )
		{
			InitializeComponent( );


			forwardControl = new DataForwardControl( );
			panel4.Controls.Add( forwardControl );
			forwardControl.Dock = DockStyle.Fill;
			forwardControl.SetSqlMode( );

			dataGridView_table.CellFormatting += DataGridView_table_CellFormatting;

			if (Program.Language == 2)
			{
				tabPage1.Text = "Task";
				tabPage2.Text = "SQL Query";
				button_query.Text = "Query";
				tabPage3.Text = "Table";
				label6.Text = "Information";
			}
		}

		protected override void OnSizeChanged( EventArgs e )
		{
			base.OnSizeChanged( e );

			if (this.Width > 300)
			{
				Column_sql.Width = dataGridView_sql.Width - 261;
			}
		}

		private void DataGridView_table_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
		{
			// 1. 排除表头和空值
			if (e.RowIndex < 0 || e.Value == null || e.Value == DBNull.Value)
			{
				return;
			}

			// 2. 判断单元格值是否为 DateTime 类型
			if (e.Value is DateTime dateValue)
			{
				// 3. 设置格式化显示（包含秒和毫秒）
				e.Value = dateValue.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
				// 4. 标记格式化完成，避免后续默认格式化覆盖
				e.FormattingApplied = true;
			}
		}

		public void SaveToXml( XElement element )
		{
			XElement xml = new XElement( "DatabaseCommand" );
			for (int i = 0; i < dataGridView_sql.Rows.Count; i++)
			{
				DataGridViewRow row = dataGridView_sql.Rows[i];
				if (row.IsNewRow) continue;
				if (row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value) continue;

				XElement commandXml = new XElement( "Command" );
				commandXml.SetAttributeValue( "Cmd", row.Cells[0].Value );

				xml.Add( commandXml );
			}
			element.Add( xml );

			this.forwardControl.SaveToXml( element );
		}

		public void LoadFromXml( System.Xml.Linq.XElement xmlParent )
		{
			XElement xml = xmlParent.Element( "DatabaseCommand" );
			if (xml != null)
			{
				List<string> list = new List<string>();
				var commands = xml.Elements( "Command" );
				foreach (var command in commands)
				{
					string cmd = command.Attribute( "Cmd" ).Value;
					list.Add( cmd );
				}

				if (list.Count > 0)
				{
					DemoUtils.DataGridSpecifyRowCount( dataGridView_sql, list.Count );
					for (int i = 0; i < list.Count; i++)
					{
						dataGridView_sql.Rows[i].Cells[0].Value = list[i];
					}
				}
			}

			this.forwardControl.LoadFromXml( xmlParent );
		}

		public void SetSqlCommand( string sql )
		{
			tabControl1.SelectTab( tabPage2 );
			this.textBox_sql.Text = sql;
		}

		public void SetTip( string tip )
		{
			label8.Text = tip;
		}

		public void SetTimeCost( DateTime start )
		{
			TimeSpan timeSpan = DateTime.Now - start;
			if (Program.Language == 1)
			{
				this.label_timecost.Text = $"耗时: " + DemoUtils.GetTimeCost( start );
			}
			else
			{
				this.label_timecost.Text = $"Time Cost: " + DemoUtils.GetTimeCost( start );
			}
		}

		/// <summary>
		/// 批量SQL语句的显示区域
		/// </summary>
		public DataGridView DataGridViewSql => this.dataGridView_sql;

		/// <summary>
		/// 显示数据库表格的信息
		/// </summary>
		public DataGridView DataGridViewTable => this.dataGridView_table;

		/// <summary>
		/// 等待执行的SQL语句
		/// </summary>
		public TextBox TextBoxSql => this.textBox_sql;

		/// <summary>
		/// 执行SQL语句的按钮
		/// </summary>
		public Button ButtonSqlExecute => this.button_query;

		/// <summary>
		/// 执行SQL语句的结果
		/// </summary>
		public TextBox TextBoxSqlResult => this.textBox3;

		/// <summary>
		/// 执行SQL语句结果的控件
		/// </summary>
		public TabControl TabControlSql => this.tabControl2;

		/// <summary>
		/// 数据转发的控制控件
		/// </summary>
		public DataForwardControl ForwardControl => this.forwardControl;

		private DataForwardControl forwardControl;
	}
}
