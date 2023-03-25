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
    public partial class StartControl : UserControl
    {
        public StartControl( )
        {
            InitializeComponent( );
        }

        private void panel1_Paint( object sender, PaintEventArgs e )
        {
            e.Graphics.DrawLine( Pens.LightGray, new Point( 0, 78 ), new Point( panel1.Width, 78 ) );
        }

        private void StartControl_Load( object sender, EventArgs e )
        {
            label2.Text = "Version: " + Utils.Version.ToString( );
            StartControl_SizeChanged( null, null );
        }

        private void StartControl_SizeChanged( object sender, EventArgs e )
        {
            panel1.Location = new Point( this.Width / 2 - panel1.Width / 2, this.Height / 2 - panel1.Height / 2 );
        }
    }
}
