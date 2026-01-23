using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Database
{
	public partial class FormSqlServer : HslFormContent
	{
		public FormSqlServer( )
		{
			InitializeComponent( );
			treeView1.ImageList = DatabaseHelper.GetDatabaseImageList( );

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.dataBaseControl1.TabControlSql, codeExampleControl, false, CodeExampleControl.GetTitle( ) );

			this.dataBaseControl1.ButtonSqlExecute.Click += button_query_Click;
			this.dataBaseControl1.ForwardControl.onDataPublished += ForwardControl_onDataPublished;
		}

		private void FormSqlServer_Load( object sender, EventArgs e )
		{
			Text = "SqlServerDemo";

			if (Program.Language == 2)
			{
				button1.Text = "Connect";
				button2.Text = "Close";
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			sqlConnectionStringBuilder = new SqlConnectionStringBuilder
			{
				DataSource = textBox_ip.Text, // 服务器IP/实例名
				InitialCatalog = textBox_db.Text, // 数据库名称
				UserID = textBox_name.Text, // 用户名
				Password = textBox_password.Text, // 密码
				TrustServerCertificate = checkBox_TrustServerCertificate.Checked, // 是否忽略 SSL 证书验证（本地测试必备）
				ConnectTimeout = 30 // 连接超时时间
			};

			sqlConnection = new SqlConnection( sqlConnectionStringBuilder.ConnectionString );
			try
			{
				sqlConnection.Open( );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( StringResources.Language.ConnectedFailed + ex.Message );
				Console.Write( StringResources.Language.ConnectedFailed + ex.Message );
				return;
			}

			DemoUtils.ShowMessage( StringResources.Language.ConnectedSuccess );

			treeView1.Nodes.Clear( );
			var tableList = DatabaseHelper.GetAllTablesAndColumnsBySystemView( sqlConnection );
			TreeNode db = new TreeNode( textBox_db.Text );
			db.Tag = sqlConnectionStringBuilder.InitialCatalog;
			db.ImageKey = "database";
			db.SelectedImageKey = "database";
			foreach (var table in tableList)
			{
				TreeNode tableNode = new TreeNode( table.TableName );
				tableNode.Tag = table;
				tableNode.ImageKey = "table";
				tableNode.SelectedImageKey = "table";

				TreeNode columnNode = new TreeNode( "Columns" );
				columnNode.ImageKey = "folder";
				columnNode.SelectedImageKey = "folder";
				foreach (var column in table.ColumnList)
				{
					TreeNode colNode = new TreeNode( column.ToString( ) );
					colNode.ImageKey = "column";
					colNode.SelectedImageKey = "column";
					colNode.Tag = column;
					columnNode.Nodes.Add( colNode );
				}
				tableNode.Nodes.Add( columnNode );
				db.Nodes.Add( tableNode );
			}
			treeView1.Nodes.Add( db );
			treeView1.Nodes[0].Expand( );

			button1.Enabled = false;
			button2.Enabled = true;

			StringBuilder stringBuilder = new StringBuilder( );
			stringBuilder.AppendLine( @"SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
{
	DataSource = """ + textBox_ip.Text + @""", // 服务器IP/实例名
	InitialCatalog = """ + textBox_db.Text + @""", // 数据库名称
	UserID = """ + textBox_name.Text + @""", // 用户名
	Password = """ + textBox_password.Text + @""", // 密码
	TrustServerCertificate = " + checkBox_TrustServerCertificate.Checked.ToString( ).ToLower( ) + @", // 是否忽略 SSL 证书验证（本地测试必备）
	ConnectTimeout = 30 // 连接超时时间
};" );
			stringBuilder.AppendLine( "SqlConnection sqlConnection = new SqlConnection( sqlConnectionStringBuilder.ConnectionString );" );
			stringBuilder.AppendLine( @"try
{
	sqlConnection.Open( );
}
catch (Exception ex)
{
	Console.Write( StringResources.Language.ConnectedFailed + ex.Message );
	return;
}
" );
			codeExampleControl.RenderExampleCode( stringBuilder );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			sqlConnection.Close( );
			button1.Enabled = true;
			button2.Enabled = false;
		}

		private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder( );
		private SqlConnection sqlConnection;
		private CodeExampleControl codeExampleControl;

		private void treeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode node = treeView1.GetNodeAt( e.Location );
				if (node != null)
				{
					treeView1.SelectedNode = node;
					if (node.Tag is TableInfo table)
					{
						contextMenuStrip1.Show( treeView1, e.Location );
					}
				}
			}
		}

		private void selectTop1000ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// Select Top 1000 语句演示
			if (treeView1.SelectedNode?.Tag is TableInfo table)
			{
				string sql = $"SELECT TOP 1000 * FROM [{table.TableName}]";
				this.dataBaseControl1.SetSqlCommand( sql );
			}
		}

		private void deleteRowToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// DELETE 语句演示
			if (treeView1.SelectedNode?.Tag is TableInfo table)
			{
				string columnName = table.ColumnList.FirstOrDefault( c => true )?.ColumnName;
				string sql = $"DELETE FROM [dbo].[{table.TableName}] WHERE [{columnName}] = @{columnName}";
				this.dataBaseControl1.SetSqlCommand( sql );
			}
		}
		private string GetColumnParameterInfo( ColumnInfo column )
		{
			if (column.ColumnType == "datetime")
			{
				return "GETDATE()";
			}
			return "@" + column.ColumnName;
		}


		private void insertToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// Insert 语句演示
			if (treeView1.SelectedNode?.Tag is TableInfo table)
			{
				var columnNames = table.ColumnList.Select( c => "[" + c.ColumnName + "]" ).ToArray( );
				var paramNames = table.ColumnList.Select( GetColumnParameterInfo ).ToArray( );
				string sql = $"INSERT INTO [dbo].[{table.TableName}] ({string.Join( ", ", columnNames )}) VALUES ({string.Join( ", ", paramNames )})";
				this.dataBaseControl1.SetSqlCommand( sql );
			}
		}

		private void tRUNCATEToolStripMenuItem_Click( object sender, EventArgs e )
		{
			// truncate table
			if (treeView1.SelectedNode?.Tag is TableInfo table)
			{
				string sql = $"TRUNCATE TABLE [dbo].[{table.TableName}]";
				this.dataBaseControl1.SetSqlCommand( sql );
			}
		}

		private void button_query_Click( object sender, EventArgs e )
		{
			// 执行 SQL 语句
			if (sqlConnection == null)
			{
				DemoUtils.ShowMessage( "请先连接数据库！" );
				return;
			}

			string sql = dataBaseControl1.TextBoxSql.Text;
			try
			{
				DateTime start = DateTime.Now;
				if (Regex.IsMatch(sql, @"Select [\S\s]+ From", RegexOptions.IgnoreCase))
				{
					SqlDataAdapter adapter = new SqlDataAdapter( sql, sqlConnection );
					DataTable dataTable = new DataTable( );
					adapter.Fill( dataTable );
					dataBaseControl1.DataGridViewTable.DataSource = dataTable;
					adapter.Dispose( );

					dataBaseControl1.TextBoxSqlResult.Text = $"{DateTime.Now} 执行查询成功，返回行数：{dataTable.Rows.Count}";
				}
				else
				{
					SqlCommand sqlCommand = new SqlCommand( sql, sqlConnection );
					int affectedRows = sqlCommand.ExecuteNonQuery( );
					dataBaseControl1.TextBoxSqlResult.Text = $"{DateTime.Now} 执行成功，受影响的行数：{affectedRows}";
					sqlCommand.Dispose( );
				}
				dataBaseControl1.SetTimeCost( start );
			}
			catch (SqlException ex)
			{
				DemoUtils.ShowMessage( $"SQL 操作失败：{ex.Message}（错误码：{ex.Number}）" );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( $"未知错误：{ex.Message}" );
			}
		}


		private void ForwardControl_onDataPublished( object sender, Dictionary<string, object> dict )
		{
			for(int i = 0; i < dataBaseControl1.DataGridViewSql.Rows.Count; i++)
			{
				DataGridViewRow row = dataBaseControl1.DataGridViewSql.Rows[i];
				if (row.IsNewRow) continue;

				string sql = row.Cells[0].Value?.ToString( );
				if (string.IsNullOrEmpty( sql )) continue;

				ExecuteNonQueryTick nonQueryTick = null;
				if (row.Tag == null)
				{
					nonQueryTick = new ExecuteNonQueryTick( );
					row.Tag = nonQueryTick;
				}
				else
				{
					nonQueryTick = row.Tag as ExecuteNonQueryTick;
				}


				try
				{
					using (SqlCommand sqlCommand = new SqlCommand( sql, sqlConnection ))
					{
						foreach (var keyValue in dict)
						{
							sqlCommand.Parameters.AddWithValue( keyValue.Key, keyValue.Value );
						}
						int affects = sqlCommand.ExecuteNonQuery( );

						nonQueryTick.Success += affects;
					}
				}
				catch
				{
					nonQueryTick.Failed += 1;
				}
				row.Cells[1].Value = nonQueryTick.Success;
				row.Cells[2].Value = nonQueryTick.Failed;
			}
		}


		public override void SaveXmlParameter( XElement element )
		{
			this.dataBaseControl1.SaveToXml( element );
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox_port.Text );
			element.SetAttributeValue( DemoDeviceList.XmlUserName, textBox_name.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPassword, textBox_password.Text );
			element.SetAttributeValue( "Database", textBox_db.Text );
			element.SetAttributeValue( "TrustServerCertificate", checkBox_TrustServerCertificate.Checked );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.dataBaseControl1.LoadFromXml( element );
			textBox_ip.Text = GetXmlValue( element, DemoDeviceList.XmlIpAddress, textBox_ip.Text, m => m );
			textBox_port.Text = GetXmlValue( element, DemoDeviceList.XmlPort, textBox_port.Text, m => m );
			textBox_name.Text = GetXmlValue( element, DemoDeviceList.XmlUserName, textBox_name.Text, m => m );
			textBox_password.Text = GetXmlValue( element, DemoDeviceList.XmlPassword, textBox_password.Text, m => m );
			textBox_db.Text = GetXmlValue( element, "Database", textBox_db.Text, m => m );
			checkBox_TrustServerCertificate.Checked = GetXmlValue( element, "TrustServerCertificate", true, bool.Parse );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void FormSqlServer_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (e.Cancel) return;
			this.dataBaseControl1.ForwardControl.ActionWhenClosing( );
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );

		}
	}

}
