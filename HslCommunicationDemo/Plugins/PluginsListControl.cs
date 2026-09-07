
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HslCommunicationDemo.Plugins.PluginsDetailsControl;

namespace HslCommunicationDemo.Plugins
{
	public partial class PluginsListControl : UserControl
	{
		public PluginsListControl( )
		{
			InitializeComponent( );
			pluginsItemControls = new List<PluginsItemControl>( );
		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			KeyDown += ItemControl_KeyDown;
		}

		/// <summary>
		/// 根据搜索条件去列表里搜索符合的插件，然后显示
		/// </summary>
		/// <param name="condition">条件信息，如果为空，则表示不进行数据筛选</param>
		public void SetSearchCondition( string condition )
		{
			if (this.definitions == null) return;
			if(string.IsNullOrEmpty(condition))
			{
				ShowPlugins( this.definitions );
			}
			else
			{
				IEnumerable<IEdgePlugins> list = this.definitions.Where( m => m.DllName.Contains( condition ) || m.Company.Contains( condition ) );
				ShowPlugins( list.ToArray( ) );
			}
		}

		/// <summary>
		/// 重置当前的所有的插件列表信息
		/// </summary>
		/// <param name="pluginsDefinitions">定义的插件列表</param>
		public void SetPlugins( IEdgePlugins[] pluginsDefinitions )
		{
			if (pluginsDefinitions == null) return;
			this.definitions = pluginsDefinitions;
			ShowPlugins( this.definitions );
		}

		/// <summary>
		/// 显示指定的插件内容信息，这里只是根据传入的列表进行控件显示
		/// </summary>
		/// <param name="pluginsDefinitions">插件列表信息</param>
		private void ShowPlugins( IEdgePlugins[] pluginsDefinitions )
		{
			while (pluginsItemControls.Count > pluginsDefinitions.Length)
			{
				pluginsItemControls[pluginsItemControls.Count - 1].Dispose( );
				pluginsItemControls.RemoveAt( pluginsItemControls.Count - 1 );

			}
			while (pluginsItemControls.Count < pluginsDefinitions.Length)
			{
				PluginsItemControl itemControl = new PluginsItemControl( );
				itemControl.Location = new Point( 5, 5 + pluginsItemControls.Count * 65 );
				itemControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				itemControl.Size = new Size( this.Width - 10, 60 );
				this.Controls.Add( itemControl );
				pluginsItemControls.Add( itemControl );
				itemControl.MouseClick += ItemControl_MouseClick;
				itemControl.KeyDown += ItemControl_KeyDown;
			}

			for (int i = 0; i < pluginsItemControls.Count; i++)
			{
				pluginsItemControls[i].SetPluginsDefinition( pluginsDefinitions[i] );
			}
			if (pluginsItemSelected != null)
			{
				pluginsItemSelected.BackColor = Color.Transparent;
				pluginsItemSelected = null;
			}
		}

		public void ItemControl_KeyDown( object sender, KeyEventArgs e )
		{
			if(e.KeyCode == Keys.Up)
			{
				int index = pluginsItemControls.IndexOf( pluginsItemSelected );
				if(index > 0)
				{
					ItemControl_MouseClick( pluginsItemControls[index - 1], new MouseEventArgs( MouseButtons.Left, 1, 1, 1, 1 ) );
				}
			}
			else if(e.KeyCode == Keys.Down)
			{
				int index = pluginsItemControls.IndexOf( pluginsItemSelected );
				if (index >= 0 && index < pluginsItemControls.Count - 2)
				{
					ItemControl_MouseClick( pluginsItemControls[index + 1], new MouseEventArgs( MouseButtons.Left, 1, 1, 1, 1 ) );
				}
			}
		}

		private void ItemControl_MouseClick( object sender, MouseEventArgs e )
		{
			if (e.Button == MouseButtons.Left)
			{
				if (sender is PluginsItemControl control)
				{
					if (!object.ReferenceEquals( control, pluginsItemSelected ))
					{
						// 发生了选择控件
						if (pluginsItemSelected != null)
						{
							pluginsItemSelected.BackColor = Color.Transparent;
						}
						pluginsItemSelected = control;
						pluginsItemSelected.BackColor = Color.Wheat;
						PluginSelectEvent?.Invoke( control.GetPluginsDefinition( ) );
					}
				}
			}
		}

		/// <summary>
		/// 插件控件选择的事件
		/// </summary>
		public event PluginOperateDelegate PluginSelectEvent;
		private IEdgePlugins[] definitions;
		private List<PluginsItemControl> pluginsItemControls;
		private PluginsItemControl pluginsItemSelected = null;      // 当前选择的控件信息
	}
}
