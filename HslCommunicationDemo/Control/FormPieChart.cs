using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormPieChart : HslFormContent
    {
        public FormPieChart( )
        {
            InitializeComponent( );
        }

        private void FormPieChart_Load( object sender, EventArgs e )
        {
            charts[0] = userPieChart1;
            charts[1] = userPieChart2;
            charts[2] = userPieChart3;
            charts[3] = userPieChart4;
            charts[4] = userPieChart5;


            timerTick = new Timer( );
            timerTick.Interval = 5000;
            timerTick.Tick += TimerTick_Tick;
            timerTick.Start( );

            TimerTick_Tick( sender, e );
        }

        private void TimerTick_Tick( object sender, EventArgs e )
        {
            for (int j = 0; j < 5; j++)
            {
                
                List<string> data = new List<string>( );
                List<int> ints = new List<int>( );
                for (int i = 0; i < random.Next( 4, 12 ); i++)
                {
                    data.Add( random.Next( 100, 999 ).ToString( ) );
                    ints.Add( random.Next( 0, 5 ) );
                }

                charts[j].SetDataSource(
                    data.ToArray( ),
                    ints.ToArray( ) );
            }

        }

        private HslCommunication.Controls.UserPieChart[] charts = new HslCommunication.Controls.UserPieChart[5];
        private Random random = new Random( );
        private Timer timerTick = null;
    }
}
