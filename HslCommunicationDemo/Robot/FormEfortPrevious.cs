using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.EFORT;
using HslCommunication;
using System.Xml.Linq;
using HslCommunicationDemo.DemoControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HslCommunicationDemo.Robot
{
	public partial class FormEfortPrevious : FormEfort
	{
		public FormEfortPrevious( )
		{
			InitializeComponent( );

			userControlHead1.ProtocolInfo = "Previous";
		}

		private ER7BC10Previous efortRobot;
		protected override void button1_Click( object sender, EventArgs e )
		{
			try
			{
				// 连接
				efortRobot = new ER7BC10Previous( textBox1.Text, int.Parse( textBox2.Text ) );
				efortRobot.ConnectTimeOut = 2000;

				OperateResult connect = efortRobot.ConnectServer( );
				if (connect.IsSuccess)
				{
					MessageBox.Show( StringResources.Language.ConnectedSuccess );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					// 设置示例代码
					codeExampleControl.SetCodeText( "robot", efortRobot );
				}
				else
				{
					MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
				}
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( ex );
			}
		}

		protected override void button2_Click( object sender, EventArgs e )
		{
			efortRobot?.ConnectClose( );
			base.button2_Click( sender, e );
		}

		protected override OperateResult<EfortData> ReadFromRobot( )
		{
			return efortRobot.ReadEfortData( );
		}
	}
}
