using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslRedisDesktop
{
    public partial class ContactControl : UserControl
    {
        public ContactControl( )
        {
            InitializeComponent( );
        }

        private void panel1_Paint( object sender, PaintEventArgs e )
        {
            e.Graphics.DrawLine( Pens.LightGray, new Point( 0, 35 ), new Point( panel1.Width, 35 ) );
            e.Graphics.DrawLine( Pens.LightGray, new Point( 100, 75 ), new Point( panel1.Width - 100, 75 ) );
            e.Graphics.DrawLine( Pens.LightGray, new Point( 100, 110 ), new Point( panel1.Width - 100, 110 ) );
        }

        private void StartControl_Load( object sender, EventArgs e )
        {
            StartControl_SizeChanged( null, null );
        }

        private void StartControl_SizeChanged( object sender, EventArgs e )
        {
            panel1.Location = new Point( this.Width / 2 - panel1.Width / 2, this.Height / 2 - panel1.Height / 2 );
        }
    }
}
