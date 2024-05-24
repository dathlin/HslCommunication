using HslCommunication.Core.Security;
using HslCommunication.LogNet;
using HslCommunicationDemo.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class FormSaveList : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormSaveList( WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel, ImageList imageList, ILogNet logNet, Dictionary<string, int> iconImageIndex )
		{
			InitializeComponent( );
			this.dockPanel1 = dockPanel;
			this.logNet = logNet;
			this.imageList = imageList;
			this.formIconImageIndex = iconImageIndex;
		}

		private void FormSaveList_Load( object sender, EventArgs e )
		{
			CloseButtonVisible = false;
			treeView2.ImageList = imageList;
			treeView2.MouseClick += TreeView2_MouseClick;
			treeView2.MouseDoubleClick += TreeView2_MouseDoubleClick;
			deleteDeviceToolStripMenuItem.Click += DeleteDeviceToolStripMenuItem_Click;

			SetLanguage( );
		}

		public void SetLanguage( )
		{
			if (Program.Language == 1)
			{
				this.Text = "保存列表";
			}
			else
			{
				this.Text = "Save List";
			}
		}

		public bool LoadDeviceList( )
		{
			if (File.Exists( Path.Combine( Application.StartupPath, "devices.xml" ) ))
			{
				deviceList.SetDevices( XElement.Load( Path.Combine( Application.StartupPath, "devices.xml" ) ) );
				RefreshSaveDevices( );
				//tabControl1.SelectedTab = tabPage2;

				return true;
			}
			return false;
		}

		public void AddDeviceList( XElement element )
		{
			deviceList.AddDevice( element );
			RefreshSaveDevices( );
			File.WriteAllText( Path.Combine( Application.StartupPath, "devices.xml" ), deviceList.GetDevices.ToString( ) );
		}

		public void RefreshSaveDevices( )
		{
			treeView2.Nodes.Clear( );
			foreach (var item in deviceList.GetDevices.Elements( ))
			{
				string name = item.Attribute( "Name" ).Value;
				AddTreeNode( treeView2, null, item, name );
			}
			treeView2.ExpandAll( );
		}

		private void DeleteDeviceToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if (treeView2.SelectedNode == null) return;
			if (treeView2.SelectedNode.Tag == null) return;
			if (treeView2.SelectedNode.Tag is XElement element)
			{
				deviceList.DeleteDevice( element );
				RefreshSaveDevices( );
				File.WriteAllText( Path.Combine( Application.StartupPath, "devices.xml" ), deviceList.GetDevices.ToString( ) );
				MessageBox.Show( "Delete Success!" );
			}
		}


		private void TreeView2_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Right)
			{
				treeView2.SelectedNode = treeView2.GetNodeAt( e.Location );
				contextMenuStrip1.Show( treeView2, e.Location );
			}
		}

		private void TreeView2_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			// 从保存的配置文件创建的设备对象
			TreeNode treeNode = treeView2.SelectedNode;
			if (treeNode == null) return;
			if (treeNode.Tag == null) return;

			if (treeNode.Tag is XElement element)
			{
				string type = element.Attribute( DemoDeviceList.XmlType ).Value;
				HslFormContent hslForm = null;
				// 读取类型
				foreach (var item in formTypes)
				{
					if (item.Name == type)
					{
						hslForm = (HslFormContent)item.GetConstructors( )[0].Invoke( null );
						hslForm.LogNet = this.logNet;
						break;
					}
				}

				if (hslForm != null)
				{
					if (treeNode.ImageIndex >= 0)
					{
						hslForm.Icon = Icon.FromHandle( ((Bitmap)imageList.Images[treeNode.ImageIndex]).GetHicon( ) );
						hslForm.SetProtocolImage( (Bitmap)imageList.Images[treeNode.ImageIndex] );
					}
					else
					{
						hslForm.Icon = Icon.FromHandle( Properties.Resources.Method_636.GetHicon( ) );
						hslForm.SetProtocolImage( Properties.Resources.Method_636 );
					}

					// 判断是否加密了，如果是加密的话，需要先进行解密的操作
					if (element.Attribute( DemoDeviceList.XmlEncrypt) != null)
					{
						FormInputPassword inputPassword = new FormInputPassword( );
						if (inputPassword.ShowDialog() == DialogResult.OK)
						{
							AesCryptography aesCryptography = new AesCryptography( inputPassword.Password.PadRight( 32, '0' ) );
							try
							{
								string encrypt = aesCryptography.Decrypt( element.Attribute( DemoDeviceList.XmlEncrypt ).Value );
								hslForm.Show( dockPanel1 );
								hslForm.LoadXmlParameter( XElement.Parse( encrypt ) ); ;
								hslForm.SetXml( element );
								hslForm.Password = inputPassword.Password;
							}
							catch( Exception ex )
							{
								MessageBox.Show( (Program.Language == 1 ? "解密失败，无法加载当前的配置信息" : "Decryption failed and the current configuration information could not be loaded") +
									Environment.NewLine + ex.Message );
							}
						}
					}
					else
					{
						hslForm.Show( dockPanel1 );
						hslForm.LoadXmlParameter( element );
					}
				}
			}
		}

		private void AddTreeNode( TreeView treeView, TreeNode parent, XElement element, string key )
		{
			int index = key.IndexOf( ':' );
			if (index <= 0)
			{
				// 不存在冒号
				TreeNode node = new TreeNode( key );
				node.Tag = element;
				string type = element.Attribute( DemoDeviceList.XmlType ).Value;
				if (formIconImageIndex.ContainsKey( type ))
				{
					node.ImageIndex = formIconImageIndex[type];
					node.SelectedImageIndex = formIconImageIndex[type];
				}
				else
				{
					node.ImageIndex = 0;
					node.SelectedImageIndex = 0;
				}

				if (parent == null)
				{
					treeView.Nodes.Add( node );
				}
				else
				{
					parent.Nodes.Add( node );
				}
			}
			else
			{
				TreeNode parentNode = null;
				if (parent == null)
				{
					for (int i = 0; i < treeView.Nodes.Count; i++)
					{
						if (treeView.Nodes[i].Text == key.Substring( 0, index ))
						{
							parentNode = treeView.Nodes[i];
							break;
						}
					}
				}
				else
				{
					for (int i = 0; i < parent.Nodes.Count; i++)
					{
						if (parent.Nodes[i].Text == key.Substring( 0, index ))
						{
							parentNode = parent.Nodes[i];
							break;
						}
					}
				}


				if (parentNode == null)
				{
					parentNode = new TreeNode( key.Substring( 0, index ) );
					parentNode.ImageKey = "Class_489";
					parentNode.SelectedImageKey = "Class_489";
					AddTreeNode( treeView, parentNode, element, key.Substring( index + 1 ) );

					if (parent == null)
					{
						treeView.Nodes.Add( parentNode );
					}
					else
					{
						parent.Nodes.Add( parentNode );
					}
				}
				else
				{
					AddTreeNode( treeView, parentNode, element, key.Substring( index + 1 ) );
				}
			}
		}


		private DemoDeviceList deviceList = new DemoDeviceList( );
		private ILogNet logNet = null;
		private ImageList imageList;
		private Dictionary<string, int> formIconImageIndex = new Dictionary<string, int>( );
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
		public static Type[] formTypes = Assembly.GetExecutingAssembly( ).GetTypes( );
	}
}
