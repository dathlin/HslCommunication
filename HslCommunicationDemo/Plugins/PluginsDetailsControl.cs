
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Plugins
{
	public partial class PluginsDetailsControl : UserControl
	{
		public PluginsDetailsControl( )
		{
			InitializeComponent( );

			label1.Visible = false;
			label_files.Visible = false;
		}

		private void PluginsDetailsControl_Load( object sender, EventArgs e )
		{
			linkLabel_url.MouseClick += LinkLabel_url_MouseClick;
			button_unload.Click += Button_unload_Click;
		}

		private void Button_unload_Click( object sender, EventArgs e )
		{
			if (this.pluginsDefinition != null)
			{
				if (this.pageMode == 0)
				{
					PluginUnloadEvent?.Invoke( this.pluginsDefinition );
				}
				else
				{
					PluginInstallEvent?.Invoke( this.pluginsDefinition );
				}
			}
		}

		private void LinkLabel_url_MouseClick( object sender, MouseEventArgs e )
		{
			if (this.pluginsDefinition == null) return;
			if (string.IsNullOrEmpty( this.pluginsDefinition.Http )) return;
			try
			{
				System.Diagnostics.Process.Start( this.pluginsDefinition.Http );
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message );
			}
		}

		/// <summary>
		/// 设置插件的详细信息，将其显示出来
		/// </summary>
		/// <param name="pluginsDefinition">设备插件对象</param>
		public void SetPluginsDefinition( IEdgePlugins pluginsDefinition )
		{
			this.pluginsDefinition = pluginsDefinition;
			if (this.pluginsDefinition == null) return;

			label_name.Text              = this.pluginsDefinition.DllName;
			textBox_install_version.Text = this.pluginsDefinition.Version.ToString( );
			textBox_desc.Text            = this.pluginsDefinition.Description;
			label_author.Text            = this.pluginsDefinition.Company;
			label_date.Text              = this.pluginsDefinition.ReleaseData.ToString( "yyyy-MM-dd" );
			label_version.Text           = this.pluginsDefinition.Version.ToString( );
			linkLabel_url.Text           = this.pluginsDefinition.Http;
			label_framework.Text         = this.pluginsDefinition.Framework;

			if (pluginsDefinition is ServerPluginItem serverPlugin)
			{
				// 浏览的插件，支持远程安装
				SetPageMode( 1 );
				StringBuilder sb = new StringBuilder( );
				sb.AppendLine( "net462" );
				if (serverPlugin.FrameworkFiles != null)
				{
					for(int i = 0; i < serverPlugin.FrameworkFiles.Count; i ++)
					{
						sb.AppendLine( $"    {serverPlugin.FrameworkFiles[i]}" );
					}
				}
				sb.AppendLine( "netstandard" );
				if (serverPlugin.StandardFiles != null)
				{
					for (int i = 0;i < serverPlugin.StandardFiles.Count;i ++)
					{
						sb.AppendLine( $"    {serverPlugin.StandardFiles[i]}");
					}
				}
				label_files.Text = sb.ToString( );
			}
			else
			{
				SetPageMode( 0 );
			}
		}

		/// <summary>
		/// 设置当前控件的显示模式，0：已安装插件，1：未安装插件
		/// </summary>
		/// <param name="pageMode">页面模式: 0：已安装插件，1：未安装插件</param>
		public void SetPageMode( int pageMode )
		{
			this.pageMode = pageMode;
			if (pageMode == 0)
			{
				label2.Text = "已安装";
				button_unload.Text = "卸载";

				label1.Visible = false;
				label_files.Visible = false;
			}
			else if (pageMode == 1)
			{
				label2.Text = "版本";
				button_unload.Text = "安装";

				label1.Visible = true;
				label_files.Visible = true;
			}
		}

		private IEdgePlugins pluginsDefinition = null;
		public delegate void PluginOperateDelegate( IEdgePlugins pluginsDefinition );

		/// <summary>
		/// 当前控件的显示模式，0：已安装插件，1：未安装插件
		/// </summary>
		private int pageMode = 0;  // 当前控件的显示模式，0：已安装插件，1：未安装插件

		/// <summary>
		/// 插件卸载的事件
		/// </summary>
		public event PluginOperateDelegate PluginUnloadEvent;

		/// <summary>
		/// 安装插件的事件
		/// </summary>
		public event PluginOperateDelegate PluginInstallEvent;
	}
}
