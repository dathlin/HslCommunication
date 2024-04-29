using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.AllenBradley;
using System.Text.RegularExpressions;

namespace HslCommunicationDemo
{
	public partial class FormAllenBrandlyBrowser : HslFormContent
	{
		public FormAllenBrandlyBrowser( )
		{
			InitializeComponent( );
		}

		private void RedisBrowser_Load( object sender, EventArgs e )
		{
			DemoUtils.SetDeviveIp( textBox_ip );
			ImageList imageList = new ImageList( );
			imageList.Images.Add( "VirtualMachine",               Properties.Resources.VirtualMachine );
			imageList.Images.Add( "Class_489",                    Properties.Resources.Class_489 );               // 结构体
			imageList.Images.Add( "Enum_582",                     Properties.Resources.Enum_582 );                // 标量数据
			imageList.Images.Add( "brackets_Square_16xMD",        Properties.Resources.brackets_Square_16xMD );   // 数组
			imageList.Images.Add( "Method_636",                   Properties.Resources.Method_636 );              // 
			imageList.Images.Add( "Module_648",                   Properties.Resources.Module_648 );              // 多维数组
			imageList.Images.Add( "Structure_507",                Properties.Resources.Structure_507 );           // 


			treeView1.ImageList = imageList;

			treeView1.Nodes.Add( "Values" );
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
			treeViewSelectedNode = treeView1.Nodes[0];
			panel3.Enabled = false;
			panel4.Dock = DockStyle.Fill;

			dataGridView1.SizeChanged += DataGridView1_SizeChanged;
		}

		private void DataGridView1_SizeChanged( object sender, EventArgs e )
		{
			dataGridView1.Columns[5].Width = dataGridView1.Width - 21 - 435;
		}

		private AllenBradleyNet allenBradleyNet = null;

		private void button1_Click( object sender, EventArgs e )
		{
			if (!int.TryParse( textBox2.Text, out int port ))
			{
				MessageBox.Show( DemoUtils.PortInputWrong );
				return;
			}

			if (!byte.TryParse( textBox15.Text, out byte slot ))
			{
				MessageBox.Show( DemoUtils.SlotInputWrong );
				return;
			}
			dictStructDefine = new Dictionary<int, AbTagItem[]>( );

			allenBradleyNet?.ConnectClose( );
			allenBradleyNet = new AllenBradleyNet( );
			allenBradleyNet.IpAddress = textBox_ip.Text;
			allenBradleyNet.Port = port;
			allenBradleyNet.Slot = slot;

			if (!string.IsNullOrEmpty( textBox16.Text ))
			{
				allenBradleyNet.MessageRouter = new MessageRouter( textBox16.Text );
			}

			OperateResult connect = allenBradleyNet.ConnectServer( );
			if (connect.IsSuccess)
			{
				MessageBox.Show( StringResources.Language.ConnectedSuccess );
				button2.Enabled = true;
				button1.Enabled = false;
				panel2.Enabled = true;
				panel3.Enabled = true;
				//allenBradleyNet.LogNet = new HslCommunication.LogNet.LogNetFileSize( "" );
				//allenBradleyNet.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				TagRefresh( );
			}
			else
			{
				MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 //textBox5.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			 } ) );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			TagRefresh( );
		}

		private void TagRefresh( )
		{
			treeView1.Nodes[0].Nodes.Clear( );
			// 加载所有的键值信息
			OperateResult<AbTagItem[]> reads = allenBradleyNet.TagEnumerator( );
			if (!reads.IsSuccess) 
			{
				MessageBox.Show( reads.Message );
				return;
			};
			rootTags = reads.Content;
			AddTreeNode( treeView1.Nodes[0], reads.Content, string.Empty, true, true );

			treeView1.Nodes[0].Expand( );
		}

		private string GetIamgeKeyByTag( AbTagItem abTag )
		{
			if (abTag.ArrayDimension == 1)
			{
				return "brackets_Square_16xMD";
			}
			else if (abTag.ArrayDimension > 1)
			{
				return "Module_648";
			}
			else if (abTag.IsStruct)
			{
				return "Class_489";
			}
			else
			{
				return "Enum_582";
			}
		}

		private void RenderDataGridView( AbTagItem[] items )
		{
			if ( items == null ) items = new AbTagItem[0];
			// 在 DataGridView 显示
			DemoUtils.DataGridSpecifyRowCount( dataGridView1, items.Length );
			for (int i = 0; i < items.Length; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString( );
				dataGridView1.Rows[i].Cells[1].Value = treeView1.ImageList.Images[GetIamgeKeyByTag( items[i] )];
				dataGridView1.Rows[i].Cells[2].Value = items[i].Name;
				dataGridView1.Rows[i].Cells[3].Value = items[i].SymbolType.ToString( "X" );
				dataGridView1.Rows[i].Cells[4].Value = items[i].GetTypeText( );
				if (items[i].Tag != null)
				{
					dataGridView1.Rows[i].Cells[5].Value = items[i].Tag.ToString( );
				}
				else
				{
					dataGridView1.Rows[i].Cells[5].Value = "";
				}
			}
		}

		private void AddTreeNode(TreeNode parent, AbTagItem[] items, string parentName, bool showDataGrid, bool regexMatch )
		{
			foreach (var item in items)
			{
				if (regexMatch && !string.IsNullOrEmpty( textBox_regex.Text ) && !Regex.IsMatch( item.Name, textBox_regex.Text ))
				{
					continue;
				}

				TreeNode treeNode         = new TreeNode( item.Name );
				treeNode.Name             = string.IsNullOrEmpty( parentName ) ? item.Name : parentName + "." + item.Name;
				treeNode.ImageKey         = GetIamgeKeyByTag(item);
				treeNode.SelectedImageKey = GetIamgeKeyByTag( item );
				treeNode.Tag              = item;
				parent.Nodes.Add( treeNode );

				if (item.IsStruct)
				{
					OperateResult<AbTagItem[]> read = GetStruct( item );
					if (!read.IsSuccess) continue;

					item.Members = read.Content;
					if (item.ArrayDimension == 0)
					{
						AddTreeNode( treeNode, read.Content, treeNode.Name, false, false );
					}
					else if (item.ArrayDimension == 1)
					{
						for (int i = 0; i < item.ArrayLength[0]; i++)
						{
							TreeNode treeNodeChild         = new TreeNode( item.Name + $"[{i}]" );
							treeNodeChild.Name             = string.IsNullOrEmpty( parentName ) ? item.Name + $"[{i}]" : parentName + "." + item.Name + $"[{i}]";
							treeNodeChild.ImageKey         = GetIamgeKeyByTag( item );
							treeNodeChild.SelectedImageKey = GetIamgeKeyByTag( item );
							AbTagItem abTag      = new AbTagItem( );
							abTag.Name           = item.Name + $"[{i}]";
							abTag.InstanceID     = item.InstanceID;
							abTag.SymbolType     = item.SymbolType;
							abTag.IsStruct       = item.IsStruct;
							abTag.ArrayDimension = 0;
							abTag.ArrayLength    = item.ArrayLength;
							abTag.Members        = AbTagItem.CloneBy( item.Members );

							treeNodeChild.Tag = abTag;
							AddTreeNode( treeNodeChild, read.Content, treeNodeChild.Name, false, false );
							treeNode.Nodes.Add( treeNodeChild );
						}
					}
					else if (item.ArrayDimension == 2) 
					{
						for (int i = 0; i < item.ArrayLength[0]; i++)
						{
							for(int j = 0; j < item.ArrayLength[1]; j++)
							{
								TreeNode treeNodeChild = new TreeNode( item.Name + $"[{i},{j}]" );
								treeNodeChild.Name = string.IsNullOrEmpty( parentName ) ? item.Name + $"[{i},{j}]" : parentName + "." + item.Name + $"[{i},{j}]";
								treeNodeChild.ImageKey = GetIamgeKeyByTag( item );
								treeNodeChild.SelectedImageKey = GetIamgeKeyByTag( item );
								AbTagItem abTag = new AbTagItem( );
								abTag.Name = item.Name + $"[{i},{j}]";
								abTag.InstanceID = item.InstanceID;
								abTag.SymbolType = item.SymbolType;
								abTag.IsStruct = item.IsStruct;
								abTag.ArrayDimension = 0;
								abTag.ArrayLength = item.ArrayLength;
								abTag.Members = AbTagItem.CloneBy( item.Members );

								treeNodeChild.Tag = abTag;
								AddTreeNode( treeNodeChild, read.Content, treeNodeChild.Name, false, false );
								treeNode.Nodes.Add( treeNodeChild );
							}
						}
					}
				}
			}

			if (showDataGrid) RenderDataGridView( items );
		}

		private OperateResult<AbTagItem[]> GetStruct( AbTagItem tagItem )
		{
			int typeCode = tagItem.SymbolType & 0x0fff;
			if (dictStructDefine.ContainsKey( typeCode ))
				return OperateResult.CreateSuccessResult( AbTagItem.CloneBy( dictStructDefine[typeCode] ) );
			OperateResult<AbTagItem[]> read = allenBradleyNet.StructTagEnumerator( tagItem );
			if (read.IsSuccess) dictStructDefine.Add( typeCode, AbTagItem.CloneBy( read.Content ) );
			return read;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 断开连接
			panel3.Enabled = false;
			button1.Enabled = true;
			button2.Enabled = false;

			allenBradleyNet.ConnectClose( );
		}

		private void ShowDataRoots( )
		{
			if (rootTags != null)
			{
				foreach (var item in rootTags)
				{
					// 不是结构体及数组的情况则给予显示
					if(!item.IsStruct)
					{
						if (item.ArrayDimension == 0)
						{
							if (item.SymbolType == AllenBradleyHelper.CIP_Type_Byte)
							{
								OperateResult<byte> read = allenBradleyNet.ReadByte( item.Name );
								if (read.IsSuccess) item.Tag = (sbyte)read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Word)
							{
								OperateResult<short> read = allenBradleyNet.ReadInt16( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_DWord)
							{
								OperateResult<int> read = allenBradleyNet.ReadInt32( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_LInt)
							{
								OperateResult<long> read = allenBradleyNet.ReadInt64( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_USInt)
							{
								OperateResult<byte> read = allenBradleyNet.ReadByte( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UInt)
							{
								OperateResult<ushort> read = allenBradleyNet.ReadUInt16( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UDint)
							{
								OperateResult<uint> read = allenBradleyNet.ReadUInt32( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_ULint)
							{
								OperateResult<ulong> read = allenBradleyNet.ReadUInt64( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Bool)
							{
								OperateResult<bool> read = allenBradleyNet.ReadBool( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Real)
							{
								OperateResult<float> read = allenBradleyNet.ReadFloat( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Double)
							{
								OperateResult<double> read = allenBradleyNet.ReadDouble( item.Name );
								if (read.IsSuccess) item.Tag = read.Content;
							}
							else if ((item.SymbolType | 0x0f00) == 0x0fc1)
							{
								int index = item.SymbolType >> 8;
								OperateResult<byte[]> read = allenBradleyNet.Read( item.Name, 1 );
								if (read.IsSuccess) item.Tag = read.Content[0].GetBoolByIndex( index );
							}
						}
						else if (item.ArrayDimension == 1)
						{
							if (item.SymbolType == AllenBradleyHelper.CIP_Type_Byte)
							{
								OperateResult<byte[]> read = allenBradleyNet.Read( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess)
								{
									sbyte[] data = new sbyte[read.Content.Length];
									for (int i = 0; i < data.Length; i++)
									{
										data[i] = (sbyte)read.Content[i];
									}
									item.Tag = data.ToArrayString( );
								}
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Word)
							{
								OperateResult<short[]> read = allenBradleyNet.ReadInt16( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_DWord)
							{
								OperateResult<int[]> read = allenBradleyNet.ReadInt32( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_LInt)
							{
								OperateResult<long[]> read = allenBradleyNet.ReadInt64( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_USInt)
							{
								OperateResult<byte[]> read = allenBradleyNet.Read( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UInt)
							{
								OperateResult<ushort[]> read = allenBradleyNet.ReadUInt16( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UDint)
							{
								OperateResult<uint[]> read = allenBradleyNet.ReadUInt32( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_ULint)
							{
								OperateResult<ulong[]> read = allenBradleyNet.ReadUInt64( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Real)
							{
								OperateResult<float[]> read = allenBradleyNet.ReadFloat( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Double)
							{
								OperateResult<double[]> read = allenBradleyNet.ReadDouble( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = read.Content.ToArrayString( );
							}
							else if (item.SymbolType == AllenBradleyHelper.CIP_Type_D3)
							{
								OperateResult<int[]> read = allenBradleyNet.ReadInt32( item.Name, (ushort)item.ArrayLength[0] );
								if (read.IsSuccess) item.Tag = SoftBasic.BoolArrayToString( allenBradleyNet.ByteTransform.TransByte( read.Content ).ToBoolArray( ) );
							}
						}
					}
				}
			}
		}
		private void ReadStruct( AbTagItem tagItem, string tagName )
		{
			if (!tagItem.IsStruct) return;

			OperateResult<byte[]> read = allenBradleyNet.Read( tagName, 1 );
			if(!read.IsSuccess) return;

			if (tagItem.Members == null) return;

			foreach (var item in tagItem.Members)
			{
				if (!item.IsStruct)
				{
					if (item.ArrayDimension == 0)
					{
						if      (item.SymbolType == AllenBradleyHelper.CIP_Type_Byte)   item.Tag = ((sbyte)read.Content[item.ByteOffset]).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Word)   item.Tag = allenBradleyNet.ByteTransform.TransInt16(  read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_DWord)  item.Tag = allenBradleyNet.ByteTransform.TransInt32(  read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_LInt)   item.Tag = allenBradleyNet.ByteTransform.TransInt64(  read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_USInt)  item.Tag = allenBradleyNet.ByteTransform.TransByte(   read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UInt)   item.Tag = allenBradleyNet.ByteTransform.TransUInt16( read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UDint)  item.Tag = allenBradleyNet.ByteTransform.TransUInt32( read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_ULint)  item.Tag = allenBradleyNet.ByteTransform.TransUInt64( read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Bool)   item.Tag = allenBradleyNet.ByteTransform.TransBool(   read.Content, item.ByteOffset * 8 + item.ArrayLength[0] ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Real)   item.Tag = allenBradleyNet.ByteTransform.TransSingle( read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Double) item.Tag = allenBradleyNet.ByteTransform.TransDouble( read.Content, item.ByteOffset ).ToString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_D3)     item.Tag = SoftBasic.BoolArrayToString( allenBradleyNet.ByteTransform.TransByte( read.Content, item.ByteOffset, 4 ).ToBoolArray( ) );
					}
					else if (item.ArrayDimension == 1)
					{
						if      (item.SymbolType == AllenBradleyHelper.CIP_Type_Byte)   item.Tag = Encoding.UTF8.GetString( read.Content, item.ByteOffset, item.ArrayLength[0] );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Word)   item.Tag = allenBradleyNet.ByteTransform.TransInt16(  read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_DWord)  item.Tag = allenBradleyNet.ByteTransform.TransInt32(  read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_LInt)   item.Tag = allenBradleyNet.ByteTransform.TransInt64(  read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_USInt)  item.Tag = allenBradleyNet.ByteTransform.TransByte(   read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UInt)   item.Tag = allenBradleyNet.ByteTransform.TransUInt16( read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_UDint)  item.Tag = allenBradleyNet.ByteTransform.TransUInt32( read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_ULint)  item.Tag = allenBradleyNet.ByteTransform.TransUInt64( read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Real)   item.Tag = allenBradleyNet.ByteTransform.TransSingle( read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_Double) item.Tag = allenBradleyNet.ByteTransform.TransDouble( read.Content, item.ByteOffset, item.ArrayLength[0] ).ToArrayString( );
						else if (item.SymbolType == AllenBradleyHelper.CIP_Type_D3)     item.Tag = SoftBasic.BoolArrayToString( allenBradleyNet.ByteTransform.TransByte( read.Content, item.ByteOffset, item.ArrayLength[0] * 4 ).ToBoolArray( ));
					}
				}
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			if (treeViewSelectedNode == null) return;
			if (treeViewSelectedNode.Tag is AbTagItem tagItem)
			{
				if (tagItem.IsStruct )
				{
					// 结构体本身才给与显示
					if( tagItem.ArrayDimension == 0)
					{
						ReadStruct( tagItem, treeViewSelectedNode.Name );
						RenderDataGridView( tagItem.Members );
						return;
					}
				}
				if (treeViewSelectedNode.Parent.ImageKey == "VirtualMachine")
				{
					ShowDataRoots( );
					RenderDataGridView( rootTags );
				}
			}
			else if (treeViewSelectedNode.ImageKey == "VirtualMachine")
			{
				ShowDataRoots( );
				RenderDataGridView( rootTags );
			}
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			// 点击了数据信息
			treeViewSelectedNode = e.Node;
			RenderDataGridViewBySelect( e.Node );
		}

		private void RenderDataGridViewBySelect( TreeNode treeNode )
		{
			if (treeNode.Tag is AbTagItem tagItem)
			{
				textBox4.Text = treeNode.Name;
				if (tagItem.IsStruct)
				{
					RenderStructDataSelect( treeNode );
				}
				else
				{
					if (treeNode.Parent.Tag is AbTagItem parentTag)
					{
						if (parentTag.IsStruct && parentTag.ArrayDimension == 1)
						{
							RenderDataGridView( parentTag.Members );
						}
					}
					else if (treeNode.Parent.Tag == null)
					{
						RenderDataGridView( rootTags );
					}
				}
			}
			else if (treeNode.ImageKey == "VirtualMachine")
			{
				textBox4.Text = string.Empty;
				RenderDataGridView( rootTags );
			}
		}

		private void RenderStructDataSelect( TreeNode treeNode )
		{
			if (treeNode.Tag is AbTagItem tagItem)
			{
				if (tagItem.IsStruct)
				{
					if (tagItem.ArrayDimension == 0)
						RenderDataGridView( tagItem.Members );
					else
						RenderStructDataSelect( treeNode.Parent );
				}
			}
			else
			{
				RenderDataGridView( rootTags );
			}
		}


		private TreeNode treeViewSelectedNode = null;
		private AbTagItem[] rootTags = null;
		private Dictionary<int, AbTagItem[]> dictStructDefine;


		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox_ip.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
			element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox15.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox_ip.Text  = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text  = element.Attribute( DemoDeviceList.XmlPort ).Value;
			textBox15.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
