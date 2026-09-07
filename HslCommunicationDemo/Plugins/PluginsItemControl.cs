using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Plugins
{
	public partial class PluginsItemControl : UserControl
	{
		public PluginsItemControl( )
		{
			InitializeComponent( );


			SetStyle( ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true );
			SetStyle( ControlStyles.ResizeRedraw, true );
			SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
		}

		public void SetPluginsDefinition( IEdgePlugins pluginsDefinition )
		{
			this.pluginsDefinition = pluginsDefinition;
			Invalidate( );
		}

		public IEdgePlugins GetPluginsDefinition( )
		{
			return this.pluginsDefinition;
		}

		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );

			if (this.pluginsDefinition == null) return;
			int leftWidth = 30;
			int rightWidth = 50;

			Graphics g = e.Graphics;
			if (pluginsDefinition.Icon16 == null)
			{
				g.FillRectangle( Brushes.White, new Rectangle( 10, 10, 16, 16 ) );
			}
			else
			{
				g.DrawImage( GetImageFromBytes( pluginsDefinition.Icon16 ), new Rectangle( 10, 10, 16, 16 ) );
			}
			float pluginsNameWidth = 0f;
			Brush fontBrush = new SolidBrush( ForeColor );
			using (Font font1 = new Font( Font.FontFamily, 12f, FontStyle.Bold ))
			{
				pluginsNameWidth = g.MeasureString( pluginsDefinition.DllName, font1 ).Width + 5;
				g.DrawString( pluginsDefinition.DllName, font1, fontBrush, new Point( leftWidth, 5 ) );
			}

			string author = "作者 " + pluginsDefinition.Company;
			if (this.pluginsDefinition is ServerPluginItem serverPluginItem)
			{
				author += $", {serverPluginItem.Downloads}个下载";
			}
			g.DrawString( author, Font, fontBrush, new PointF( leftWidth + pluginsNameWidth, 9 ) );


			Rectangle rectangleDesc = new Rectangle( leftWidth, 25, Width - leftWidth - rightWidth, Height - 30 );
			g.DrawString( pluginsDefinition.Description, Font, fontBrush, rectangleDesc );

			Brush back = new SolidBrush( BackColor );
			g.FillRectangle( back, new RectangleF( Width - rightWidth, 0, rightWidth, Height ) );
			g.DrawString( pluginsDefinition.Version.ToString( ), Font, fontBrush, new PointF( Width - rightWidth + 5, 10 ) );

			g.DrawRectangle( Pens.DimGray, new Rectangle( 0, 0, Width - 1, Height - 1 ) );
			back.Dispose( );
			fontBrush.Dispose( );
		}

		public static Image GetImageFromBytes( byte[] buffer )
		{
			MemoryStream ms = new MemoryStream( buffer );
			Image image = Image.FromStream( ms );
			ms.Dispose( );
			return image;
		}
		private IEdgePlugins pluginsDefinition;
	}
}
