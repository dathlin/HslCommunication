using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static HslCommunicationDemo.FormSecsGem;
using System.Windows.Forms;
using HslCommunication.Secs.Types;

namespace HslCommunicationDemo.PLC.Secs
{
	public class SecsHelper
	{
		public static void EditSecsItemToolStripMenuItem_Click( TreeView treeView1, Action<SecsTreeItem> RenderSelectedSecs, bool server )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is SecsTreeItem secsTreeItem)
			{
				FormServerSecsItem form = new FormServerSecsItem( secsTreeItem, server );
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					treeNode.Text = form.SecsTreeItem.GetTreeNodeText( );
					treeNode.Tag = form.SecsTreeItem;
					RenderSelectedSecs( form.SecsTreeItem );
				}
			}
		}

		public static void DeleteSecsItemToolStripMenuItem_Click( TreeView treeView1 )
		{
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode == null) return;

			if (treeNode.Tag is SecsTreeItem secsTreeItem)
			{
				string message = $"确认删除 {secsTreeItem.GetTreeNodeText( )} 的功能？";
				if (Program.Language == 2)
				{
					message = "Confirm delete {secsTreeItem. GetTreeNodeText ()} ?";
				}
				if (MessageBox.Show( message, Program.Language == 2 ? "Delete Check" : "删除确认", MessageBoxButtons.YesNo ) == DialogResult.Yes)
				{
					treeNode.Remove( );
				}
			}
		}

		private static TreeNode FindNodeS( TreeView treeView1, SecsTreeItem secsTreeItem )
		{
			for (int i = 0; i < treeView1.Nodes.Count; i++)
			{
				TreeNode node = treeView1.Nodes[i];
				int s = Convert.ToInt32( node.Text.Substring( 1 ) );

				if (s == secsTreeItem.S) return node;
				if (s > secsTreeItem.S)
				{
					TreeNode node2 = new TreeNode( "S" + secsTreeItem.S );
					treeView1.Nodes.Insert( i, node2 );
					return node2;
				}
			}

			// 都没有，就在最后面插入节点信息
			TreeNode node3 = new TreeNode( "S" + secsTreeItem.S );
			treeView1.Nodes.Add( node3 );
			return node3;
		}

		private static void InsertNodeF( TreeNode parent, SecsTreeItem secsTreeItem )
		{
			for (int i = 0; i < parent.Nodes.Count; i++)
			{
				TreeNode node = parent.Nodes[i];
				Match match = Regex.Match( node.Text, "F[0-9]+" );
				if (!match.Success) continue;

				int f = Convert.ToInt32( match.Value.Substring( 1 ) );
				if (f == secsTreeItem.F)
				{
					node.Text = secsTreeItem.GetTreeNodeText( );
					node.Tag = secsTreeItem;
					return;
				}
				else if (f > secsTreeItem.F)
				{
					// 要插入一个节点
					TreeNode node2 = new TreeNode( secsTreeItem.GetTreeNodeText( ) );
					node2.Tag = secsTreeItem;
					parent.Nodes.Insert( i, node2 );
					return;
				}
			}

			TreeNode node3 = new TreeNode( secsTreeItem.GetTreeNodeText( ) );
			node3.Tag = secsTreeItem;
			parent.Nodes.Add( node3 );
		}

		public static void AddNewSecsItemToolStripMenuItem_Click( TreeView treeView1, Action<SecsTreeItem> RenderSelectedSecs, bool server )
		{
			SecsTreeItem secsTreeItem = new SecsTreeItem( s: 1, f: 1, w: false, SecsValue.EmptySecsValue( ), "Test" );
			TreeNode treeNode = treeView1.SelectedNode;
			if (treeNode != null)
			{
				if (treeNode.Tag is SecsTreeItem item)
				{
					secsTreeItem = item;  // 如果有选中的话，从这个当前选中的复制内容
				}
			}

			FormServerSecsItem form = new FormServerSecsItem( secsTreeItem, server );
			if (form.ShowDialog( ) == DialogResult.OK)
			{
				// 开始寻找对应的功能码
				TreeNode node = FindNodeS( treeView1, form.SecsTreeItem );
				if (node == null)
				{
					MessageBox.Show( "failed, node is null" );
					return;
				}
				InsertNodeF( node, form.SecsTreeItem );
				RenderSelectedSecs( form.SecsTreeItem );
			}
		}

	}
}
