using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class BorderPanel : Panel
	{
		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );

			if (Width > 2 && Height > 2)
				e.Graphics.DrawRectangle( Pens.LightGray, new Rectangle( 0, 0, Width - 1, Height - 1 ) );
		}
	}
}
