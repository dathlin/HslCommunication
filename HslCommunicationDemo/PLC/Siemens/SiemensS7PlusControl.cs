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

		private void button1_Click( object sender, EventArgs e )
		{
			OperateResult<List<S7Object>> read = this.siemensTcpNet.BrowerDB( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read failed: " + read.Message );
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
				//MessageBox.Show( "Success: " + read.Content.ToJsonString( ) );
				//Clipboard.SetText( read.Content.ToJsonString( ) );

				// 清空原先的数据
				foreach (var item in s7Nodes.Values)
				{
					item.Node.Nodes.Clear( );
				}

				BrowerAllTags( read2.Content );
				MessageBox.Show( "Finish!" );
				treeView1.ExpandAll( );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read2.Message );
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
						}
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

			}
		}

		private void treeView1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is S7Tag tag)
			{
				//OperateResult<byte[]> read = this.siemensTcpNet.BrowsrTags( obj );
				//if (read.IsSuccess)
				//{
				//	MessageBox.Show( "Success: " + read.Content.ToHexString( ' ' ) );
				//	Clipboard.SetText( read.Content.ToHexString( ' ' ) );
				//}
				//else
				//{
				//	MessageBox.Show( "Read failed: " + read.Message );
				//}
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
				}
				else if (tags[i].TypeCode == 0x11)
				{
					treeNode.ImageKey = "Module_648";
					treeNode.SelectedImageKey = "Module_648";

					// 这是个结构体，还要二次遍历
					if (s7Struct.ContainsKey( tags[i].StructID ))
					{
						if (s7Struct[tags[i].StructID].S7Tags != null)
						{
							List<S7Tag> list = new List<S7Tag>( );
							for (int j = 0; j < s7Struct[tags[i].StructID].S7Tags.Count; j++)
							{
								S7Tag s7Tag = s7Struct[tags[i].StructID].S7Tags[j].Clone( );
								s7Tag.LID.InsertRange( 0, tags[i].LID );
								list.Add( s7Tag );
							}
							AddS7Tags( treeNode, list );
						}
					}
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
				MessageBox.Show( "ReadWriteNet device is null, can not refresh! " );
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
											dgvr.Cells[4].Value = read.Content[i].Value.ToJsonString( );
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
						row.Cells[4].Value = read.Content[0].Value.ToJsonString( );
					}
					else
						row.Cells[4].Value = read.Content.Select( m => m.Value ).ToArray( ).ToJsonString( );
					//MessageBox.Show( "Success: " + read.Content );
				}
				else
				{
					MessageBox.Show( "Failed: " + read.Message );
				}
			}
		}
	}

	public class S7ObjectNode
	{
		public S7Object S7Object { get; set; }
		public TreeNode Node { get; set; }
	}
}
