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
using HslCommunication.Enthernet.Redis;
using System.IO;
using Newtonsoft.Json.Linq;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.Redis;
using HslCommunicationDemo;

namespace HslRedisDesktop
{
	public partial class FormRedisMain : HslFormContent
	{
		public FormRedisMain( )
		{
			InitializeComponent( );

			if (File.Exists( SettingsPath ))
			{
				redisSettings = JArray.Parse( SoftSecurity.MD5Decrypt( File.ReadAllText( SettingsPath, Encoding.UTF8 ), "oa8H01kz" ) ).ToObject<List<RedisSettings>>( );
			}
			else
			{
				redisSettings = new List<RedisSettings>( );
			}
		}

        #region 窗体 Load Show Close

        private void FormMain_Load( object sender, EventArgs e )
		{
			ImageList imageList = new ImageList( );
			imageList.Images.Add( "loading", HslCommunicationDemo.Properties.Resources.loading );
			imageList.Images.Add( "VirtualMachine", HslCommunicationDemo.Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489", HslCommunicationDemo.Properties.Resources.Class_489 );
			imageList.Images.Add( "redis", HslCommunicationDemo.Properties.Resources.redis );
			imageList.Images.Add( "redis_db", HslCommunicationDemo.Properties.Resources.redis_db );
			imageList.Images.Add( "Method_636", HslCommunicationDemo.Properties.Resources.Method_636 );
			imageList.Images.Add( "Structure_507", HslCommunicationDemo.Properties.Resources.Structure_507 );
			imageList.Images.Add( "Module_648", HslCommunicationDemo.Properties.Resources.Module_648 );
			imageList.Images.Add( "docview_xaml_on_16x16", HslCommunicationDemo.Properties.Resources.docview_xaml_on_16x16 );
			imageList.Images.Add( "Enum_582", HslCommunicationDemo.Properties.Resources.Enum_582 );                              // string
			imageList.Images.Add( "brackets_Square_16xMD", HslCommunicationDemo.Properties.Resources.brackets_Square_16xMD );    // 数组
			imageList.Images.Add( "Table_748", HslCommunicationDemo.Properties.Resources.Table_748 );                            // 哈希
			imageList.Images.Add( "zset", HslCommunicationDemo.Properties.Resources.zset );                                      // 集合
			imageList.Images.Add( "Tag_7213", HslCommunicationDemo.Properties.Resources.Tag_7213 );                              // 有序集合

			treeView1.ImageList = imageList;

			LoadRedisSettings( );

			// DB块右键
			新增KeyToolStripMenuItem.Click += 新增KeyToolStripMenuItem_Click;
			刷新数据ToolStripMenuItem.Click += 刷新数据ToolStripMenuItem_Click;
			过滤KeyToolStripMenuItem.Click += 过滤KeyToolStripMenuItem_Click;
			清除所有KeyToolStripMenuItem.Click += 清除所有KeyToolStripMenuItem_Click;
			// Redis右键
			刷新所有数据ToolStripMenuItem.Click += 刷新所有数据ToolStripMenuItem_Click;
			服务器状态ToolStripMenuItem.Click += 服务器状态ToolStripMenuItem_Click;
			控制台操作ToolStripMenuItem.Click += 控制台操作ToolStripMenuItem_Click;
			修改连接配置ToolStripMenuItem.Click += 修改连接配置ToolStripMenuItem_Click;
			修改密码ToolStripMenuItem.Click += 修改密码ToolStripMenuItem_Click;
			断开当前连接ToolStripMenuItem.Click += 断开当前连接ToolStripMenuItem_Click;
			删除当前链接ToolStripMenuItem.Click += 删除当前链接ToolStripMenuItem_Click;
			// 分类器右键
			展开所有ToolStripMenuItem.Click += 展开所有ToolStripMenuItem_Click;

			FormClosing += FormMain_FormClosing;

			// 显示初始的界面信息
			CreateRedisShowTagControl<StartControl>( );
		}

		private void FormMain_Shown( object sender, EventArgs e )
		{
			treeView1.SelectedNode = null;

			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.MouseDown += TreeView1_MouseDown;
		}

		private void FormMain_FormClosing( object sender, FormClosingEventArgs e )
		{
			foreach (TreeNode item in treeView1.Nodes)
			{
				if (item != null)
				{
					if (item.Tag is RedisSettings redisSettings)
					{
						redisSettings.Redis?.ConnectClose( );
					}
				}
			}
		}

		#endregion

		#region Redis 右键菜单

		private void 刷新所有数据ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			RefreshRedisKey( select, true );
		}

		private void 服务器状态ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			MessageBox.Show( "暂时没有实现！" );
		}

		private void 控制台操作ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			if (select.Tag is RedisSettings settings)
			{
				CreateRedisShowTagControl<ConsoleControl>( );
				if (userControl is ConsoleControl console)
				{
					console.SetRedis( settings );
				}
			}
		}

		private void 修改连接配置ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			if (select.Tag is RedisSettings settings)
			{
				using (FormRedisAdd form = new FormRedisAdd( settings ))
				{
					if (form.ShowDialog( ) == DialogResult.OK)
					{
						if (settings.Redis != null)
						{
							settings.Redis.ConnectClose( );
							settings.Redis = null;
						}
						SaveRedisSettings( );
						if (MessageBox.Show( "当前的连接配置已经更新，是否重新刷新数据？", "刷新确认", MessageBoxButtons.YesNo ) == DialogResult.OK) RefreshRedisKey( select, true );
					}
				}
			}
		}

		private void 修改密码ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			if (select.Tag is RedisSettings redisSettings)
			{
				if (redisSettings.Redis == null)
				{
					redisSettings.Redis = redisSettings.GetClient( );
					OperateResult connect = redisSettings.Redis.ConnectServer( );
					if (!connect.IsSuccess) { MessageBox.Show( $"连接Redis[{redisSettings.Name}] IpAddress:{redisSettings.IpAddress} 失败！" ); return; }
				}

				FormInputString form = new FormInputString( );
				form.TextInfo = "请输入新的密码：";
				if(form.ShowDialog() == DialogResult.OK)
				{
					OperateResult change;
					if (string.IsNullOrEmpty( form.InputValue ))
					{
						change = redisSettings.Redis.ReadCustomer( "CONFIG SET requirepass " );
					}
					else
					{
						change = redisSettings.Redis.ReadCustomer( "CONFIG SET requirepass " + form.InputValue );
					}

					if (change.IsSuccess)
					{
						MessageBox.Show( "修改密码成功！" );
						redisSettings.Password = form.InputValue;
						if (redisSettings.Redis != null)
						{
							redisSettings.Redis.ConnectClose( );
							redisSettings.Redis = null;
						}
						SaveRedisSettings( );
						RefreshRedisKey( select, true );
					}
					else
					{
						MessageBox.Show( "修改密码失败！" + change.Message );
					}
				}
			}
		}

		private void 断开当前连接ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			if (select.Tag is RedisSettings settings)
			{
				settings.Redis?.ConnectClose( );
				settings.Redis = null;
				select.Nodes.Clear( );
			}
		}

		private void 删除当前链接ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "VirtualMachine") return;

			if (select.Tag is RedisSettings settings)
			{
				settings?.Redis?.ConnectClose( );
				redisSettings.Remove( settings );

				// 配置存储
				SaveRedisSettings( );
			}

			treeView1.Nodes.Remove( select );

		}

		#endregion

		#region Redis DB块右键菜单

		private void 新增KeyToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "redis_db") return;

			RedisSettings redisSettings = select.Parent.Tag as RedisSettings;
			if (redisSettings == null) { MessageBox.Show( "获取当前的Redis配置信息失败！" ); return; }
			if (redisSettings.Redis == null) { MessageBox.Show( "获取当前的Redis连接客户端失败！" ); return; }

			using (FormRedisInput redisInput = new FormRedisInput( redisSettings.Redis ))
			{
				redisInput.ShowDialog( );
			}

		}

		private void 刷新数据ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "redis_db") return;

			RefreshDbKeys( select, true );
		}

		private void 过滤KeyToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "redis_db") return;

			if(select.Tag is DbSettings dbSettings)
			{
				using (FormInputString formInput = new FormInputString( ))
				{
					formInput.TextInfo = "请输入新的过滤条件：";
					formInput.InputValue = dbSettings.Filter;

					if (formInput.ShowDialog( ) == DialogResult.OK)
					{
						dbSettings.Filter = formInput.InputValue;
						RefreshDbKeys( select, true );
					}
				}
			}
		}

		private void 清除所有KeyToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "redis_db") return;
			RedisSettings redisSettings = select.Parent.Tag as RedisSettings;
			if (redisSettings == null) { MessageBox.Show( "获取当前的Redis配置信息失败！" ); return; }

			if (MessageBox.Show( $"请确认是否清除当前db块[{redisSettings.DBBlock}]的所有数据，当前的操作不可逆，请谨慎操作。", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
			{
				if (redisSettings.Redis == null) { MessageBox.Show( "获取当前的Redis连接客户端失败！" ); return; }

				OperateResult flush = redisSettings.Redis.FlushDB( );
				if(!flush.IsSuccess) { MessageBox.Show( "获取当前的Redis清除数据失败！" ); return; }
				MessageBox.Show( "当前的DB块" + redisSettings.DBBlock + " 清除完成，请手动刷新。" );
			}
		}

		#endregion

		#region 分类器右键菜单

		private void 展开所有ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select == null) return;
			if (select.ImageKey != "Class_489") return;

			select.ExpandAll( );
		}

		#endregion

		#region TreeView 交互逻辑

		private void TreeView1_MouseDown( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode node = treeView1.GetNodeAt( e.Location );
				if (treeView1.SelectedNode != node) treeView1.SelectedNode = node;

				TreeNode select = treeView1.SelectedNode;
				if (select == null) return;


				if (select.ImageKey == "redis_db")
				{
					contextMenuStrip_db.Show( treeView1, e.Location );
				}
				else if (select.ImageKey == "VirtualMachine")
				{
					contextMenuStrip_redis.Show( treeView1, e.Location );
				}
				else if (select.ImageKey == "Class_489")
				{
					contextMenuStrip_class.Show( treeView1, e.Location );
				}
			}
		}

		private void TreeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode select = treeView1.SelectedNode;
			if (select.ImageKey == "VirtualMachine")
			{
				RefreshRedisKey( select );
			}
			else if (select.ImageKey == "redis_db")
			{
				RefreshDbKeys( select, false );
			}
			else if (select.ImageKey == "Enum_582" || select.ImageKey == "brackets_Square_16xMD" || select.ImageKey == "Table_748" ||
				select.ImageKey == "docview_xaml_on_16x16" || select.ImageKey == "zset")
			{
				TreeNode dbNode = GetDbNode( select );
				TreeNode redisNode = GetRedisNode( select );

				if (redisNode.Tag is RedisSettings redisSettings)
				{
					if (dbNode.Tag is DbSettings dbSettings)
					{
						if (redisSettings.DBBlock != dbSettings.DBNumber)
						{
							OperateResult change = redisSettings.Redis.SelectDB( dbSettings.DBNumber );
							if (!change.IsSuccess) { MessageBox.Show( $"当前{redisSettings.Redis} 切换db块{dbSettings.DBNumber} 失败！" + change.Message ); return; }
							redisSettings.DBBlock = dbSettings.DBNumber;
						}

						// 终于可以显示了
						if (select.ImageKey == "Enum_582")
							StringKeySelect( redisSettings, select.Text );
						else if (select.ImageKey == "brackets_Square_16xMD")
							ListKeySelect( redisSettings, select.Text );
						else if (select.ImageKey == "Table_748")
							HashKeySelect( redisSettings, select.Text );
						else if (select.ImageKey == "docview_xaml_on_16x16")
							SetKeySelect( redisSettings, select.Text );
						else if (select.ImageKey == "zset")
							ZSetKeySelect( redisSettings, select.Text );
					}
				}
			}
		}

		private TreeNode GetRedisNode(TreeNode treeNode )
		{
			if (treeNode.ImageKey == "VirtualMachine") return treeNode;
			return GetRedisNode( treeNode.Parent );
		}

		private TreeNode GetDbNode( TreeNode treeNode )
		{
			if (treeNode.ImageKey == "redis_db") return treeNode;
			return GetDbNode( treeNode.Parent );
		}

		#endregion

		#region Refresh Key

		private void RefreshRedisKey( TreeNode select, bool reload = false )
		{
			if (select.Tag is RedisSettings redisSettings)
			{
				if (reload) select.Nodes.Clear( );

				if (redisSettings.Redis == null)
				{
					redisSettings.Redis = redisSettings.GetClient( );
					OperateResult connect = redisSettings.Redis.ConnectServer( );
					if (!connect.IsSuccess) { MessageBox.Show( $"连接Redis[{redisSettings.Name}] IpAddress:{redisSettings.IpAddress} 失败\r\n" + connect.Message ); return; }
				}

				if (select.Nodes.Count == 0 || reload)
				{
					for (int i = 0; i < 16; i++)
					{
						if(i == 0)
						{
							OperateResult selectDb = redisSettings.Redis.SelectDB( i );
							if (!selectDb.IsSuccess) { MessageBox.Show( "Redis读取失败！" + selectDb.Message ); return; };
						}
						else
						{
							OperateResult selectDb = redisSettings.Redis.SelectDB( i );
							if (!selectDb.IsSuccess) break;
						}

						redisSettings.DBBlock = i;

						OperateResult<long> keyCount = redisSettings.Redis.DBSize( );
						if (!keyCount.IsSuccess)
						{
							MessageBox.Show( "当前加载数据块失败！原因：" + keyCount.Message );
							return;
						}

						TreeNode dbTree = new TreeNode( $"db{i} ({keyCount.Content})" );
						dbTree.ImageKey = "redis_db";
						dbTree.SelectedImageKey = "redis_db";
						dbTree.Tag = new DbSettings( ) { DBNumber = i };

						select.Nodes.Add( dbTree );
					}

					if(redisSettings.Redis.SelectDB( 0 ).IsSuccess) redisSettings.DBBlock = 0;
					select.Expand( );
				}
			}
		}

		private void RefreshDbKeys( TreeNode select, bool reload = false )
		{
			if (select.Tag is DbSettings dbSettings)
			{
				RedisSettings redisSettings = select.Parent.Tag as RedisSettings;
				int dbBlock = dbSettings.DBNumber;

				if (redisSettings == null) { MessageBox.Show( "获取当前的Redis配置信息失败！" ); return; }
				if (redisSettings.Redis == null) { MessageBox.Show( "获取当前的Redis连接客户端失败！" ); return; }

				if (reload) select.Nodes.Clear( );

				// 如果没有子节点就加载数据信息
				if (select.Nodes.Count == 0)
				{
					// 切换当前实际选择的db块号
					int dbBlockOld = redisSettings.DBBlock;
					if (redisSettings.DBBlock != dbBlock)
					{
						OperateResult selectDb = redisSettings.Redis.SelectDB( dbBlock );
						if (!selectDb.IsSuccess) { MessageBox.Show( $"当前客户端[{redisSettings.Name}] 切换DB{dbBlock} 失败！" ); return; }

						redisSettings.DBBlock = dbBlock;
					}

					OperateResult<string[]> reads = redisSettings.Redis.ReadAllKeys( dbSettings.Filter );
					if (!reads.IsSuccess) { MessageBox.Show( "遍历所有的节点信息失败！" ); return; }

					// 重新更新db块的数据信息
					if (dbSettings.Filter == "*")
						select.Text = $"db{dbBlock} ({reads.Content.Length})";
					else
						select.Text = $"db{dbBlock} ({reads.Content.Length}) [{dbSettings.Filter}]";

					// 填充tree
					foreach (var item in reads.Content)
					{
						AddTreeNode( select, redisSettings.Redis, item, item );
					}

					// 如果db块发生了切换，则切换回去
					if(dbBlockOld != redisSettings.DBBlock)
					{
						OperateResult selectDb = redisSettings.Redis.SelectDB( dbBlockOld );
						if (!selectDb.IsSuccess) { MessageBox.Show( $"当前客户端[{redisSettings.Name}] 切换回DB{dbBlockOld} 失败！" ); return; }

						redisSettings.DBBlock = dbBlockOld;
					}
				}

				select.Expand( );
			}
		}

		private void AddTreeNode( TreeNode parent, RedisClient redisClient, string key, string infactKey )
		{
			int index = key.IndexOf( ':' );
			if (index <= 0)
			{
				// 不存在冒号
				TreeNode node = new TreeNode( infactKey );
				node.Tag = infactKey;
				// 读取类型
				OperateResult<string> type = redisClient.ReadKeyType( infactKey );
				if (type.Content == "string")
				{
					node.ImageKey = "Enum_582";
					node.SelectedImageKey = "Enum_582";
				}
				else if (type.Content == "list")
				{
					node.ImageKey = "brackets_Square_16xMD";
					node.SelectedImageKey = "brackets_Square_16xMD";
				}
				else if (type.Content == "hash")
				{
					node.ImageKey = "Table_748";
					node.SelectedImageKey = "Table_748";
				}
				else if (type.Content == "set")
				{
					node.ImageKey = "docview_xaml_on_16x16";
					node.SelectedImageKey = "docview_xaml_on_16x16";
				}
				else if (type.Content == "zset")
				{
					node.ImageKey = "zset";
					node.SelectedImageKey = "zset";
				}

				parent.Nodes.Add( node );
			}
			else
			{

				TreeNode parentNode = null;
				for (int i = 0; i < parent.Nodes.Count; i++)
				{
					if (parent.Nodes[i].Text == key.Substring( 0, index ))
					{
						parentNode = parent.Nodes[i];
						break;
					}
				}

				if (parentNode == null)
				{
					parentNode = new TreeNode( key.Substring( 0, index ) );
					parentNode.ImageKey = "Class_489";
					parentNode.SelectedImageKey = "Class_489";
					AddTreeNode( parentNode, redisClient, key.Substring( index + 1 ), infactKey );
					parent.Nodes.Add( parentNode );
				}
				else
				{
					AddTreeNode( parentNode, redisClient, key.Substring( index + 1 ), infactKey );
				}

			}
		}

		#endregion

		#region Value Select

		private void CreateRedisShowTagControl<T>( ) where T : UserControl, new()
		{
			T control = new T( );
			panel1.Controls.Add( control );
			control.Location = new Point( 0, 0 );
			control.Size = new Size( panel1.Width - 1, panel1.Height - 1 );
			control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			if (userControl != null) panel1.Controls.Remove( userControl );
			userControl?.Dispose( );
			userControl = control;
		}

		private void StringKeySelect( RedisSettings redisSettings, string key )
		{
			if (userControl == null || (userControl as StringValueControl) == null)
			{
				CreateRedisShowTagControl<StringValueControl>( );
			}

			if(userControl is StringValueControl stringValueControl)
			{
				stringValueControl.SetNewKey( redisSettings, key );
			}
		}

		private void ListKeySelect( RedisSettings redis, string key )
		{
			if (userControl == null || (userControl as ListValueControl) == null)
			{
				CreateRedisShowTagControl<ListValueControl>( );
			}

			if (userControl is ListValueControl listValueControl)
			{
				listValueControl.SetNewKey( redis, key );
			}
		}

		private void HashKeySelect( RedisSettings redis, string key )
		{
			if (userControl == null || (userControl as HashValueControl) == null)
			{
				CreateRedisShowTagControl<HashValueControl>( );
			}

			if (userControl is HashValueControl hashValueControl)
			{
				hashValueControl.SetNewKey( redis, key );
			}
		}

		private void SetKeySelect( RedisSettings redis, string key )
		{
			if (userControl == null || (userControl as SetValueControl) == null)
			{
				CreateRedisShowTagControl<SetValueControl>( );
			}

			if (userControl is SetValueControl setValueControl)
			{
				setValueControl.SetNewKey( redis, key );
			}
		}

		private void ZSetKeySelect( RedisSettings redis, string key )
		{
			if (userControl == null || (userControl as ZSetValueControl) == null)
			{
				CreateRedisShowTagControl<ZSetValueControl>( );
			}

			if (userControl is ZSetValueControl setValueControl)
			{
				setValueControl.SetNewKey( redis, key );
			}
		}


		#endregion

		private void LoadRedisSettings( )
		{
			treeView1.Nodes.Clear( );
			for (int i = 0; i < redisSettings.Count; i++)
			{
				TreeNode node = new TreeNode( redisSettings[i].Name );
				node.ImageKey = "VirtualMachine";
				node.SelectedImageKey = "VirtualMachine";
				node.Tag = redisSettings[i];
				treeView1.Nodes.Add( node );
			}
		}

		private void SaveRedisSettings( )
		{
			File.WriteAllText( SettingsPath, SoftSecurity.MD5Encrypt(JArray.FromObject( redisSettings ).ToString( ), "oa8H01kz" ), Encoding.UTF8 );
		}

		private List<RedisSettings> redisSettings = new List<RedisSettings>( );                // 当前的服务器的列表信息
		private UserControl userControl = null;
		private string SettingsPath = Path.Combine( Application.StartupPath, "redisConnect.txt" );

		private void button1_Click( object sender, EventArgs e )
		{
			// 新增服务器
			using(FormRedisAdd form = new FormRedisAdd( null ))
			{
				while (true)
				{
					if (form.ShowDialog( ) == DialogResult.OK)
					{
						if (redisSettings.Find( m => m.Name == form.Settings.Name ) == null)
						{
							break;
						}
						else
						{
							MessageBox.Show( "当前输入的服务器别名已经存在，请重新输入！" );
						}
					}
					else
					{
						return;
					}
				}

				redisSettings.Add( form.Settings );
				// 配置存储
				SaveRedisSettings( );

				// 添加列表显示
				TreeNode node = new TreeNode( form.Settings.Name );
				node.ImageKey = "VirtualMachine";
				node.SelectedImageKey = "VirtualMachine";
				node.Tag = form.Settings;
				treeView1.Nodes.Add( node );
			}
		}
	}
}
