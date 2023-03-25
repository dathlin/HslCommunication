using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.BasicFramework;

namespace HslRedisDesktop
{
    public class Utils
    {
        public static SystemVersion Version { get; set; } = new SystemVersion( "1.1.0" );

        public static void ControlDataGridViewRow( DataGridView dataGridView, int row )
        {
            int rowCount = dataGridView.RowCount;
            if (rowCount < row)
            {
                for (int i = 0; i < row - rowCount; i++)
                {
                    dataGridView.Rows.Add( );
                }
            }
            else if (rowCount > row)
            {
                for (int i = 0; i < rowCount - row; i++)
                {
                    dataGridView.Rows.RemoveAt( dataGridView.RowCount - 1 );
                }
            }

            foreach (DataGridViewRow viewRow in dataGridView.SelectedRows)
            {
                viewRow.Selected = false;
            }
        }

    }
}
