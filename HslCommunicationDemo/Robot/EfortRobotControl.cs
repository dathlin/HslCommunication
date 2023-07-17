using HslCommunication.Robot.EFORT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Robot
{
	public partial class EfortRobotControl : UserControl
	{
		public EfortRobotControl( )
		{
			InitializeComponent( );
		}

		public void RenderRobotData( EfortData efortData )
		{
			if (InvokeRequired)
			{
				try
				{
					Invoke( new Action<EfortData>( RenderRobotData ), efortData );
				}
				catch
				{

				}

				return;
			}


			textBox4.Text = efortData.PacketStart;
			textBox6.Text = efortData.PacketOrders.ToString( );
			textBox7.Text = efortData.PacketHeartbeat.ToString( );
			textBox5.Text = efortData.PacketEnd.ToString( );

			if (efortData.ErrorStatus == 1)
			{
				label13.BackColor = Color.Red;
				label12.BackColor = SystemColors.Control;
			}
			else
			{
				label13.BackColor = SystemColors.Control;
				label12.BackColor = Color.Red;
			}

			if (efortData.HstopStatus == 1)
			{
				label15.BackColor = Color.Red;
				label14.BackColor = SystemColors.Control;
			}
			else
			{
				label15.BackColor = SystemColors.Control;
				label14.BackColor = Color.Red;
			}

			if (efortData.AuthorityStatus == 1)
			{
				label18.BackColor = Color.Red;
				label17.BackColor = SystemColors.Control;
			}
			else
			{
				label18.BackColor = SystemColors.Control;
				label17.BackColor = Color.Red;
			}

			if (efortData.ServoStatus == 1)
			{
				label22.BackColor = Color.Red;
				label21.BackColor = SystemColors.Control;
			}
			else
			{
				label22.BackColor = SystemColors.Control;
				label21.BackColor = Color.Red;
			}

			if (efortData.AxisMoveStatus == 1)
			{
				label25.BackColor = Color.Red;
				label24.BackColor = SystemColors.Control;
			}
			else
			{
				label25.BackColor = SystemColors.Control;
				label24.BackColor = Color.Red;
			}

			if (efortData.ProgMoveStatus == 1)
			{
				label28.BackColor = Color.Red;
				label27.BackColor = SystemColors.Control;
			}
			else
			{
				label28.BackColor = SystemColors.Control;
				label27.BackColor = Color.Red;
			}

			if (efortData.ProgLoadStatus == 1)
			{
				label31.BackColor = Color.Red;
				label30.BackColor = SystemColors.Control;
			}
			else
			{
				label31.BackColor = SystemColors.Control;
				label30.BackColor = Color.Red;
			}

			if (efortData.ProgHoldStatus == 1)
			{
				label34.BackColor = Color.Red;
				label33.BackColor = SystemColors.Control;
			}
			else
			{
				label34.BackColor = SystemColors.Control;
				label33.BackColor = Color.Red;
			}

			if (efortData.ModeStatus == 1)
			{
				label39.BackColor = Color.Red;
				label37.BackColor = SystemColors.Control;
				label36.BackColor = SystemColors.Control;
			}
			else if (efortData.ModeStatus == 2)
			{
				label39.BackColor = SystemColors.Control;
				label37.BackColor = Color.Red;
				label36.BackColor = SystemColors.Control;
			}
			else
			{
				label39.BackColor = SystemColors.Control;
				label37.BackColor = SystemColors.Control;
				label36.BackColor = Color.Red;
			}

			label40.Text = efortData.SpeedStatus.ToString( ) + " %";
			label46.Text = efortData.ProjectName;
			label48.Text = efortData.ProgramName;
			label72.Text = efortData.DbDeviceTime.ToString( );


			textBox8.Text = GetStringFromArray( efortData.IoDOut );
			textBox9.Text = GetStringFromArray( efortData.IoDIn );
			textBox10.Text = GetStringFromArray( efortData.IoIOut );
			textBox11.Text = GetStringFromArray( efortData.IoIIn );
			textBox12.Text = efortData.ErrorText;

			textBox13.Text = efortData.DbAxisPos[0].ToString( );
			textBox20.Text = efortData.DbAxisPos[1].ToString( );
			textBox24.Text = efortData.DbAxisPos[2].ToString( );
			textBox28.Text = efortData.DbAxisPos[3].ToString( );
			textBox32.Text = efortData.DbAxisPos[4].ToString( );
			textBox36.Text = efortData.DbAxisPos[5].ToString( );
			textBox40.Text = efortData.DbAxisPos[6].ToString( );

			textBox16.Text = efortData.DbCartPos[0].ToString( );
			textBox17.Text = efortData.DbCartPos[1].ToString( );
			textBox21.Text = efortData.DbCartPos[2].ToString( );
			textBox25.Text = efortData.DbCartPos[3].ToString( );
			textBox29.Text = efortData.DbCartPos[4].ToString( );
			textBox33.Text = efortData.DbCartPos[5].ToString( );

			textBox14.Text = efortData.DbAxisSpeed[0].ToString( );
			textBox19.Text = efortData.DbAxisSpeed[1].ToString( );
			textBox23.Text = efortData.DbAxisSpeed[2].ToString( );
			textBox27.Text = efortData.DbAxisSpeed[3].ToString( );
			textBox31.Text = efortData.DbAxisSpeed[4].ToString( );
			textBox35.Text = efortData.DbAxisSpeed[5].ToString( );
			textBox39.Text = efortData.DbAxisSpeed[6].ToString( );

			textBox46.Text = efortData.DbAxisAcc[0].ToString( );
			textBox45.Text = efortData.DbAxisAcc[1].ToString( );
			textBox44.Text = efortData.DbAxisAcc[2].ToString( );
			textBox43.Text = efortData.DbAxisAcc[3].ToString( );
			textBox42.Text = efortData.DbAxisAcc[4].ToString( );
			textBox41.Text = efortData.DbAxisAcc[5].ToString( );
			textBox37.Text = efortData.DbAxisAcc[6].ToString( );

			textBox53.Text = efortData.DbAxisAccAcc[0].ToString( );
			textBox52.Text = efortData.DbAxisAccAcc[1].ToString( );
			textBox51.Text = efortData.DbAxisAccAcc[2].ToString( );
			textBox50.Text = efortData.DbAxisAccAcc[3].ToString( );
			textBox49.Text = efortData.DbAxisAccAcc[4].ToString( );
			textBox48.Text = efortData.DbAxisAccAcc[5].ToString( );
			textBox47.Text = efortData.DbAxisAccAcc[6].ToString( );

			textBox15.Text = efortData.DbAxisTorque[0].ToString( );
			textBox18.Text = efortData.DbAxisTorque[1].ToString( );
			textBox22.Text = efortData.DbAxisTorque[2].ToString( );
			textBox26.Text = efortData.DbAxisTorque[3].ToString( );
			textBox30.Text = efortData.DbAxisTorque[4].ToString( );
			textBox34.Text = efortData.DbAxisTorque[5].ToString( );
			textBox38.Text = efortData.DbAxisTorque[6].ToString( );

			textBox60.Text = efortData.DbAxisDirCnt[0].ToString( );
			textBox59.Text = efortData.DbAxisDirCnt[1].ToString( );
			textBox58.Text = efortData.DbAxisDirCnt[2].ToString( );
			textBox57.Text = efortData.DbAxisDirCnt[3].ToString( );
			textBox56.Text = efortData.DbAxisDirCnt[4].ToString( );
			textBox55.Text = efortData.DbAxisDirCnt[5].ToString( );
			textBox54.Text = efortData.DbAxisDirCnt[6].ToString( );

			textBox67.Text = efortData.DbAxisTime[0].ToString( );
			textBox66.Text = efortData.DbAxisTime[1].ToString( );
			textBox65.Text = efortData.DbAxisTime[2].ToString( );
			textBox64.Text = efortData.DbAxisTime[3].ToString( );
			textBox63.Text = efortData.DbAxisTime[4].ToString( );
			textBox62.Text = efortData.DbAxisTime[5].ToString( );
			textBox61.Text = efortData.DbAxisTime[6].ToString( );
		}

		private string GetStringFromArray( Array array )
		{
			StringBuilder sb = new StringBuilder( "[" );
			foreach (var item in array)
			{
				sb.Append( item.ToString( ) + "," );
			}
			sb.Append( "]" );
			return sb.ToString( );
		}

	}
}
