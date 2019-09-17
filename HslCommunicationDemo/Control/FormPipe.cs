using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo.Control
{
    public partial class FormPipe : HslFormContent
    {
        public FormPipe( )
        {
            InitializeComponent( );
            DoubleBuffered = true;
        }

        private void FormPipe_Load( object sender, EventArgs e )
        {
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start( );

            timer2.Interval = 200;
            timer2.Tick += Timer2_Tick;
            timer2.Start( );

            userCurve1.SetLeftCurve( "A", new float[0] );
        }

        private void Timer2_Tick( object sender, EventArgs e )
        {
            if (userBottle1.Value > 0)
            {
                userBottle1.Value--;
                if (userBottle1.Value <= 0)
                {
                    userBottle1.IsOpen = false;
                    userPipe1.MoveSpeed = 0;
                }
            }

            if(userBottle6.Value < 100)
            {
                userBottle6.Value++;
                if (userBottle6.Value >= 100)
                {
                    userBottle6.IsOpen = false;
                    userPipe2.MoveSpeed = 0;
                }
            }


            userCurve1.AddCurveData( "A", random.Next( 100 ) );
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            this.Invalidate( );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            e.Graphics.DrawString( DateTime.Now.Millisecond.ToString(), Font, Brushes.Black, 0, 0 );
            userPipe1.OnPaintMainWindow( e.Graphics );
            userPipe2.OnPaintMainWindow( e.Graphics );
        }


        private Timer timer = new Timer( );
        private Timer timer2 = new Timer( );
        private Random random = new Random( );
    }
}
