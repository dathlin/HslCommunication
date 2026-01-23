using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Database
{
	public class DatabaseHelper
	{
		/// <summary>
		/// 通过 SQL 系统视图获取 TestDb 数据库的所有表和列信息
		/// </summary>
		/// <returns>数据表信息列表</returns>
		public static List<TableInfo> GetAllTablesAndColumnsBySystemView( SqlConnection sqlConnection )
		{
			var tableList = new List<TableInfo>( );

			// 1. 连接数据库（using 自动释放资源，避免内存泄漏）
			SqlConnection conn = sqlConnection;
			try
			{
				// 2. 第一步：查询所有用户数据表名称（排除系统表）
				string getTablesSql = @"
                SELECT name AS TableName
                FROM sys.tables
                WHERE type = 'U' -- U = 用户表，排除系统表、临时表
                ORDER BY name;
            ";
				var tableNames = new List<string>( );
				using (var cmd = new SqlCommand( getTablesSql, conn ))
				using (var reader = cmd.ExecuteReader( ))
				{
					while (reader.Read( ))
					{
						string tableName = reader["TableName"].ToString( );
						tableNames.Add( tableName );
					}
				}

				// 3. 第二步：遍历每张表，查询列信息
				foreach (string tableName in tableNames)
				{
					var tableInfo = new TableInfo { TableName = tableName };
					string getColumnsSql = @"
                    SELECT 
                        c.name AS ColumnName,
                        t.name AS ColumnType,
                        c.max_length AS ColumnLength,
                        CASE WHEN pk.column_id IS NOT NULL THEN 1 ELSE 0 END AS IsPrimaryKey
                    FROM sys.columns c
                    INNER JOIN sys.types t ON c.system_type_id = t.system_type_id
                    LEFT JOIN (
                        SELECT ic.column_id, ic.object_id
                        FROM sys.index_columns ic
                        INNER JOIN sys.indexes i ON ic.index_id = i.index_id AND ic.object_id = i.object_id
                        WHERE i.is_primary_key = 1
                    ) pk ON c.column_id = pk.column_id AND c.object_id = pk.object_id
                    WHERE c.object_id = OBJECT_ID(@TableName) -- 传入表名参数，避免 SQL 注入
                    ORDER BY c.column_id;
                ";

					using (var cmd = new SqlCommand( getColumnsSql, conn ))
					{
						// 传入表名参数（参数化查询，安全防注入）
						cmd.Parameters.AddWithValue( "@TableName", tableName );

						using (var reader = cmd.ExecuteReader( ))
						{
							while (reader.Read( ))
							{
								var columnInfo = new ColumnInfo
								{
									ColumnName = reader["ColumnName"].ToString( ),
									ColumnType = reader["ColumnType"].ToString( ),
									ColumnLength = Convert.ToInt32( reader["ColumnLength"] ),
									IsPrimaryKey = Convert.ToInt32( reader["IsPrimaryKey"] ) == 1
								};
								tableInfo.ColumnList.Add( columnInfo );
							}
						}
					}

					tableList.Add( tableInfo );
				}
			}
			catch (SqlException ex)
			{
				DemoUtils.ShowMessage( $"SQL 操作失败：{ex.Message}（错误码：{ex.Number}）" );
			}
			catch (Exception ex)
			{
				DemoUtils.ShowMessage( $"未知错误：{ex.Message}" );
			}
			return tableList;
		}


		public static ImageList GetDatabaseImageList()
		{
			ImageList imageList = new ImageList( );
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageSize = new Size( 16, 16 );
			imageList.Images.Add( "database", HslCommunicationDemo.Properties.Resources.DatabaseProject_7342_16x );  // 0
			imageList.Images.Add( "table", HslCommunicationDemo.Properties.Resources.Table_748 );                      // 1
			imageList.Images.Add( "column", HslCommunicationDemo.Properties.Resources.column_16xLG );                  // 2
			imageList.Images.Add( "folder", HslCommunicationDemo.Properties.Resources.folder_Closed_16xLG );           // 3
			return imageList;
		}
	}

	public class ExecuteNonQueryTick
	{
		public long Success { get; set; }

		public long Failed { get; set; }
	}

	/// <summary>
	/// 数据表信息（包含表名和列列表）
	/// </summary>
	public class TableInfo
	{
		/// <summary>
		/// 数据表名称
		/// </summary>
		public string TableName { get; set; }

		/// <summary>
		/// 表的列信息列表
		/// </summary>
		public List<ColumnInfo> ColumnList { get; set; } = new List<ColumnInfo>( );

		public override string ToString( )
		{
			return $"数据表：{TableName}（列数：{ColumnList.Count}）";
		}
	}
	/// <summary>
	/// 数据列信息
	/// </summary>
	public class ColumnInfo
	{
		/// <summary>
		/// 列名称
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// 数据类型名称（如 int、varchar、datetime）
		/// </summary>
		public string ColumnType { get; set; }

		/// <summary>
		/// 列长度（varchar/nvarchar 等有效，int 等固定类型为 -1 或 4）
		/// </summary>
		public int ColumnLength { get; set; }

		/// <summary>
		/// 是否为主键
		/// </summary>
		public bool IsPrimaryKey { get; set; }

		public override string ToString( )
		{
			if (IsPrimaryKey)
				return $"{ColumnName} ({ColumnType}) | 主键：{(IsPrimaryKey ? "是" : "否")}";
			else
				return $"{ColumnName} ({ColumnType})";
		}
	}
}
