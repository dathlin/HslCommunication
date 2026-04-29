using HslCommunication;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Profinet.Siemens.S7PlusHelper;
using HslControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Siemens
{
	public partial class SiemensS7PlusControl : UserControl
	{
		public SiemensS7PlusControl( )
		{
			InitializeComponent( );

			imageList = new ImageList( );
			imageList.Images.Add( "Class_489", global::HslCommunicationDemo.Properties.Resources.Class_489 );
			imageList.Images.Add( "brackets_Square_16xMD", global::HslCommunicationDemo.Properties.Resources.brackets_Square_16xMD );
			imageList.Images.Add( "Enum_582", global::HslCommunicationDemo.Properties.Resources.Enum_582 );
			imageList.Images.Add( "Module_648", global::HslCommunicationDemo.Properties.Resources.Module_648 );

			treeView1.ImageList = imageList;

		}

		private void textBox1_TextChanged( object sender, EventArgs e )
		{

		}

		private void SiemensS7PlusControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 1)
			{
				label1.Text = "刷新间隔：";
				button2.Text = "开始刷新";
				label2.Text = "如果想要使用字符串地址，需要先调用 \"plc.BrowseDB( );\" \"plc.BrowseTags( );\"";
			}
			else
			{
				label1.Text = "Refresh Time:";
				button2.Text = "Refresh";
				label2.Text = "If you want to use string addresses, you need to call \"plc.BrowseDB( );\" \"plc.BrowseTags( );\" first.";
			}
		}

		public void SetDevice( SiemensS7Plus siemensTcpNet, string address )
		{
			this.siemensTcpNet = siemensTcpNet;
		}


		private ImageList imageList;
		private Dictionary<uint, S7ObjectNode> s7Nodes = new Dictionary<uint, S7ObjectNode>( );
		private Dictionary<uint, S7Object> s7Struct = new Dictionary<uint, S7Object>( );
		private SiemensS7Plus siemensTcpNet;

		private void RenderDbBlock( TreeNodeCollection nodes, List<S7Object> s7Object )
		{
			for (int i = 0; i < s7Object.Count; i++)
			{
				TreeNode treeNode = new TreeNode( s7Object[i].Name );
				treeNode.ImageKey = "Class_489";
				treeNode.SelectedImageKey = "Class_489";

				if (s7Object[i].SubObjects?.Count > 0)
				{
					RenderDbBlock( treeNode.Nodes, s7Object[i].SubObjects );
				}
				treeNode.Tag = s7Object[i];
				nodes.Add( treeNode );

				if (s7Object[i].RelationId2 > 0)
				{
					if (!s7Nodes.ContainsKey( s7Object[i].RelationId2 ))
						s7Nodes.Add( s7Object[i].RelationId2, new S7ObjectNode( ) { S7Object = s7Object[i], Node = treeNode } );
				}
			}
		}

		private Dictionary<string, string> tagNameMappig = new Dictionary<string, string>( );
		private void RefreshTagNameMapping( )
		{
			tagNameMappig.Clear( );
			foreach (var item in this.siemensTcpNet.GetTagStringMapping( ))
			{
				if (!tagNameMappig.ContainsKey( item.Value ))
					tagNameMappig.Add( item.Value, item.Key );
				else
					tagNameMappig[item.Value] = item.Key;
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			OperateResult<List<S7Object>> read = this.siemensTcpNet.BrowseDB( );
			if (!read.IsSuccess)
			{
				DemoUtils.ShowMessage( "Read failed: " + read.Message );
				return;
			}

			treeView1.Nodes.Clear( );
			s7Nodes.Clear( );
			RenderDbBlock( treeView1.Nodes, read.Content );

			dataGridView1.Columns[0].HeaderText = "Name";
			dataGridView1.Columns[1].HeaderText = "RelationId";
			dataGridView1.Columns[2].HeaderText = "Vid";
			dataGridView1.Columns[3].HeaderText = "ClassId";
			dataGridView1.Columns[4].HeaderText = "Value";

			OperateResult<List<S7Object>> read2 = this.siemensTcpNet.BrowseTags( );
			if (read2.IsSuccess)
			{
				RefreshTagNameMapping( );

				//DemoUtils.ShowMessage( "Success: " + read.Content.ToJsonString( ) );
				//Clipboard.SetText( read.Content.ToJsonString( ) );

				// 清空原先的数据
				foreach (var item in s7Nodes.Values)
				{
					item.Node.Nodes.Clear( );
				}

				BrowerAllTags( read2.Content );
				DemoUtils.ShowMessage( "Finish!" );
				treeView1.Nodes[0].Expand( );
			}
			else
			{
				DemoUtils.ShowMessage( "Read failed: " + read2.Message );
			}
		}

		public void RenderS7Tags( List<S7Tag> s7Tags )
		{
			int count = s7Tags == null ? 0 : s7Tags.Count;
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, row: count );

			dataGridView1.Columns[0].HeaderText = "Name";
			dataGridView1.Columns[1].HeaderText = "RelationId";
			dataGridView1.Columns[2].HeaderText = "TypeCode";
			dataGridView1.Columns[3].HeaderText = "TypeText";
			dataGridView1.Columns[4].HeaderText = "Value";

			if (count > 0)
			{
				for (int i = 0; i < s7Tags.Count; i++)
				{
					S7Tag child = s7Tags[i];
					DataGridViewRow row = dataGridView1.Rows[i];
					row.Cells[0].Value = child.Name;
					row.Cells[1].Value = child.GetLIDText( );
					row.Cells[2].Value = "0x" + child.TypeCode.ToString( "X" );
					row.Cells[3].Value = child.GetTypeText( );
					row.Cells[4].Value = "";
					row.Cells[5].Value = tagNameMappig.ContainsKey( child.GetLIDText( ) ) ? tagNameMappig[child.GetLIDText( )] : ""; //child.StringAddress;
					row.Tag = child;
				}
			}
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			// 选择了菜单按钮
			TreeNode treeNode = e.Node;
			if (treeNode == null) return;

			if (treeNode.Tag is S7Object obj)
			{
				if (obj.RelationId2 >= 0x80000000)
				{
					RenderS7Tags( obj.S7Tags );
				}
				else
				{
					int count = obj.SubObjects == null ? 0 : obj.SubObjects.Count;
					DemoUtils.DataGridSpecifyRowCount( dataGridView1, row: count );

					dataGridView1.Columns[0].HeaderText = "Name";
					dataGridView1.Columns[1].HeaderText = "RelationId";
					dataGridView1.Columns[2].HeaderText = "Vid";
					dataGridView1.Columns[3].HeaderText = "ClassId";
					dataGridView1.Columns[4].HeaderText = "Value";

					if (count > 0)
					{
						for (int i = 0; i < obj.SubObjects.Count; i++)
						{
							S7Object child = obj.SubObjects[i];
							DataGridViewRow row = dataGridView1.Rows[i];
							row.Cells[0].Value = child.Name;
							row.Cells[1].Value = "0x" + child.RelationId.ToString( "X" );
							row.Cells[2].Value = "0x" + child.RelationId2.ToString( "X" );
							row.Cells[3].Value = child.ClassId.ToString( );
							row.Cells[4].Value = "";
							row.Cells[5].Value = "";
						}
					}
					else
					{
						// 看看treenode下面还有没有节点
						List<S7Tag> tags = new List<S7Tag>( );
						foreach(TreeNode node in treeNode.Nodes)
						{
							if (node.Tag is S7Tag tag)
							{
								tags.Add( tag );
							}
						}
						RenderS7Tags( tags );
					}
				}
			}
			else if (treeNode.Tag is S7Tag tag)
			{
				if (tag.TypeCode == 0x11 && tag.ArrayLength < 0)
				{
					// 这是结构体标量
					List<S7Tag> s7Tags = new List<S7Tag>( );
					foreach (TreeNode item in treeNode.Nodes)
					{
						if (item.Tag is S7Tag child)
						{
							s7Tags.Add( child );
						}
					}
					RenderS7Tags( s7Tags );
				}
				else if (tag.StructID > 0)
				{
					List<S7Tag> s7Tags = new List<S7Tag>( );
					foreach (TreeNode item in treeNode.Nodes)
					{
						if (item.Tag is S7Tag child)
						{
							s7Tags.Add( child );
						}
					}
					RenderS7Tags( s7Tags );
				}
			}
		}

		private void AddS7Struct( TreeNode parent, S7Tag structTag )
		{
			if (!s7Struct.ContainsKey( structTag.StructID ))
			{
				// 如果没有找到结构体定义，结构体资源可能还没有被浏览到，这时先把这个结构体的ID记录下来，等到后续浏览到这个结构体定义的时候，再进行补全
				OperateResult<List<S7Object>> structs = this.siemensTcpNet.BrowseTags( structTag.StructID );
				if (structs.IsSuccess && structs.Content.Count == 1)
				{
					if (!s7Struct.ContainsKey( structTag.StructID ))
					{
						s7Struct.Add( structTag.StructID, structs.Content[0] );
					}
				}
			}

			// 这是个结构体，还要二次遍历
			if (s7Struct.ContainsKey( structTag.StructID ))
			{
				if (s7Struct[structTag.StructID].S7Tags != null)
				{
					List<S7Tag> list = new List<S7Tag>( );
					for (int j = 0; j < s7Struct[structTag.StructID].S7Tags.Count; j++)
					{
						S7Tag s7Tag = s7Struct[structTag.StructID].S7Tags[j].Clone( );
						s7Tag.LID.InsertRange( 0, structTag.LID );
						list.Add( s7Tag );
					}
					AddS7Tags( parent, list );
				}
			}
		}

		private void AddS7Tags( TreeNode parent, List<S7Tag> tags )
		{
			if (tags == null) return;
			if (tags.Count == 0) return;

			for (int i = 0; i < tags.Count; i++)
			{
				TreeNode treeNode = new TreeNode( tags[i].Name );
				treeNode.Tag = tags[i];
				if (tags[i].ArrayLength >= 0)  // 数组
				{
					treeNode.ImageKey = "brackets_Square_16xMD";
					treeNode.SelectedImageKey = "brackets_Square_16xMD";
					if (tags[i].TypeCode == 0x11)
					{
						// 这是个结构体数组，还要二次遍历
						for(int j = 0; j < tags[i].ArrayLength; j++)
						{
							TreeNode arrayNode = new TreeNode( tags[i].Name + "[" + j + "]" );
							arrayNode.ImageKey = "Module_648";
							arrayNode.SelectedImageKey = "Module_648";

							S7Tag s7Tag = tags[i].Clone( );
							s7Tag.Name += "[" + j + "]";
							s7Tag.ArrayLength = -1;
							s7Tag.LID.Add( (ushort)j );
							s7Tag.LID.Add( (ushort)1 );
							arrayNode.Tag = s7Tag;

							AddS7Struct( arrayNode, s7Tag );
							treeNode.Nodes.Add( arrayNode );
						}
					}
				}
				else if (tags[i].TypeCode == 0x11 || tags[i].TypeCode == 0x1f)
				{
					treeNode.ImageKey = "Module_648";
					treeNode.SelectedImageKey = "Module_648";

					//if (tags[i].StructID == 0x0200001f)
					//{
					//	;
					//}
					AddS7Struct( treeNode, tags[i] );
				}
				else
				{
					treeNode.ImageKey = "Enum_582";
					treeNode.SelectedImageKey = "Enum_582";
				}
				parent.Nodes.Add( treeNode );
			}
		}

		private void BrowerAllTags( List<S7Object> objects )
		{
			for (int i = 0; i < objects.Count; i++)
			{
				if (s7Nodes.ContainsKey( objects[i].RelationId ))
				{
					S7Object s7Object = s7Nodes[objects[i].RelationId].S7Object;
					if (objects[i].S7Tags != null)
					{
						s7Object.S7Tags = new List<S7Tag>( );
						for (int j = 0; j < objects[i].S7Tags.Count; j++)
						{
							S7Tag s7Tag = objects[i].S7Tags[j].Clone( );
							s7Tag.LID.Insert( 0, s7Object.RelationId );
							s7Object.S7Tags.Add( s7Tag );
						}

						// 遍历添加点位信息
						AddS7Tags( s7Nodes[objects[i].RelationId].Node, s7Object.S7Tags );
					}
				}
				else
				{
					// 如果没有，这可能是一个结构体的定义
					if (s7Struct.ContainsKey( objects[i].RelationId ))
						s7Struct[objects[i].RelationId] = objects[i];
					else
						s7Struct.Add( objects[i].RelationId, objects[i] );
				}

				if (objects[i].SubObjects != null)
					BrowerAllTags( objects[i].SubObjects );
			}
		}


		private Thread threadRead;
		private bool threadEnable = false;
		private int timeSleep = 1000;

		private void button2_Click( object sender, EventArgs e )
		{
			if (this.siemensTcpNet == null)
			{
				DemoUtils.ShowMessage( "ReadWriteNet device is null, can not refresh! " );
				return;
			}

			if (!threadEnable)
			{
				// 启动刷新的操作
				threadEnable = true;
				button2.Text = Program.Language == 1 ? "停止刷新" : "Stop";
				button2.BackColor = Color.LimeGreen;
				timeSleep = Convert.ToInt32( textBox_time.Text );
				threadRead = new Thread( new ThreadStart( ThreadBack ) );
				threadRead.IsBackground = true;
				threadRead.Start( );
			}
			else
			{
				// 停止线程
				threadEnable = false;
				button2.Text = Program.Language == 1 ? "开始刷新" : "Refresh";
				button2.BackColor = SystemColors.Control;
			}
		}


		private void ThreadBack( )
		{
			while (threadEnable)
			{
				if (dataGridView1.FirstDisplayedCell == null) return;
				int firstRow = dataGridView1.FirstDisplayedCell.RowIndex;
				int rowCount = dataGridView1.DisplayedRowCount( true );

				List<S7Tag> s7Tags = new List<S7Tag>( );
				for (int i = 0; i < rowCount; i++)
				{
					DataGridViewRow dgvr = dataGridView1.Rows[i + firstRow];
					if (dgvr.IsNewRow) continue;

					if (dgvr.Tag is S7Tag tag)
					{
						s7Tags.Add( tag );
					}
				}

				if (s7Tags.Count > 0)
				{
					OperateResult<List<S7Value>> read = this.siemensTcpNet.ReadTags( s7Tags.ToArray( ) );
					try
					{
						Invoke( new Action( ( ) =>
						{
							if (read.IsSuccess)
							{
								for (int i = 0; i < rowCount; i++)
								{
									DataGridViewRow dgvr = dataGridView1.Rows[i + firstRow];
									if (dgvr.IsNewRow) continue;
									if (i < read.Content.Count)
									{
										if (read.Content[i].Value == null)
											dgvr.Cells[4].Value = read.Content[i].Buffer.ToHexString( ' ' );
										else
										{
											if (read.Content[i].Value.GetType( ) == typeof( byte[] ))
												dgvr.Cells[4].Value = read.Content[i].Buffer.ToHexString( ' ' );
											else
												dgvr.Cells[4].Value = read.Content[i].Value.ToJsonString( );
										}
									}
								}
							}
							else
							{
								for (int i = 0; i < rowCount; i++)
								{
									DataGridViewRow dgvr = dataGridView1.Rows[i + firstRow];
									if (dgvr.IsNewRow) continue;
									dgvr.Cells[4].Value = "";
								}
							}
						} ) );
					}
					catch
					{
						return;
					}
				}

				Thread.Sleep( timeSleep );
			}
		}

		private void dataGridView1_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
		{
			DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
			if (row.Tag is S7Tag s7Tag)
			{
				OperateResult<List<S7Value>> read = this.siemensTcpNet.ReadTags( new S7Tag[] { s7Tag } );
				if (read.IsSuccess)
				{
					if (read.Content.Count == 1)
					{
						if (read.Content[0].Value == null)
						{
							row.Cells[4].Value = read.Content[0].Buffer.ToHexString( ' ' );
						}
						else
						{
							row.Cells[4].Value = read.Content[0].Value.ToJsonString( );
						}
					}
					else
						row.Cells[4].Value = read.Content.Select( m => m.Value ).ToArray( ).ToJsonString( );
					//DemoUtils.ShowMessage( "Success: " + read.Content );
				}
				else
				{
					DemoUtils.ShowMessage( "Failed: " + read.Message );
				}
			}
		}

		private void exploreTagToolStripMenuItem_Click( object sender, EventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is S7Object s7Object)
			{
				OperateResult<List<S7Object>> read = this.siemensTcpNet.BrowseTags( s7Object );
				if (read.IsSuccess && read.Content.Count == 1)
				{
					RefreshTagNameMapping( );

					treeNode.Nodes.Clear( );
					if (read.Content[0].S7Tags == null) return;

					for(int i = 0; i < read.Content[0].S7Tags.Count; i++)
					{
						read.Content[0].S7Tags[i].LID.Insert( 0, s7Object.RelationId );
					}
					s7Object.S7Tags = read.Content[0].S7Tags;
					AddS7Tags( treeNode, read.Content[0].S7Tags );
				}
			}
		}

		private void treeView1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			exploreTagToolStripMenuItem_Click( sender, e );
		}

		private void treeView1_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				treeView1.SelectedNode = treeView1.GetNodeAt( e.Location );
				if (treeView1.SelectedNode == null) return;

				contextMenuStrip1.Show( treeView1, e.Location );
			}
		}
	}

	public class S7ObjectNode
	{
		public S7Object S7Object { get; set; }
		public TreeNode Node { get; set; }
	}
}
