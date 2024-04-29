using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Robot.Hyundai;

namespace HslCommunicationDemo.Robot
{
	public partial class FormHyundaiUdp : HslFormContent
	{
		public FormHyundaiUdp( )
		{
			InitializeComponent( );
		}

		private void FormHyundaiUdp_Load( object sender, EventArgs e )
		{
			if(Program.Language == 2)
			{
				label3.Text = "Port";
				button1.Text = "Start";
				button2.Text = "Stop";
				groupBox1.Text = "Robot Real Data";
				groupBox3.Text = "Increment Write";
				groupBox4.Text = "Increment Write";
				button15.Text = "Write";
				groupBox2.Text = "Log";
			}

			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			groupBox3.Enabled = false;
			groupBox4.Enabled = false;
			button2.Enabled = false;
		}

		private HyundaiUdpNet hyundai;

		private void button1_Click( object sender, EventArgs e )
		{
			// 启动服务
			if(!int.TryParse(textBox2.Text, out int port ))
			{
				MessageBox.Show( "Port input wrong!" );
				return;
			}

			try
			{
				hyundai = new HyundaiUdpNet( );
				hyundai.OnHyundaiMessageReceive += Hyundai_OnHyundaiMessageReceive;
				hyundai.LogNet = new HslCommunication.LogNet.LogNetSingle( "" );
				hyundai.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				hyundai.ServerStart( port, modeTcp: false );
				MessageBox.Show( "Start Success" );

				groupBox1.Enabled = true;
				groupBox2.Enabled = true;
				groupBox3.Enabled = true;
				groupBox4.Enabled = true;
				button1.Enabled = false;
				button2.Enabled = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Start Failed: " + ex.Message );
			}
		}

		private void LogNet_BeforeSaveToFile( object sender, HslCommunication.LogNet.HslEventArgs e )
		{
			Invoke( new Action( ( ) =>
			 {
				 textBox19.AppendText( e.HslMessage.ToString( ) + Environment.NewLine );
			 } ) );
		}

		private void Hyundai_OnHyundaiMessageReceive( HyundaiData data )
		{
			// 更新实时数据
			Invoke( new Action( ( ) =>
			{
				textBox1.Text = data.Command.ToString( );
				textBox3.Text = data.CharDummy;
				textBox4.Text = data.State.ToString( );
				textBox5.Text = data.Count.ToString( );
				textBox6.Text = data.IntDummy.ToString( );
				textBox_x.Text = data.Data[0].ToString( );
				textBox_y.Text = data.Data[1].ToString( );
				textBox_z.Text = data.Data[2].ToString( );
				textBox_rx.Text = data.Data[3].ToString( );
				textBox_ry.Text = data.Data[4].ToString( );
				textBox_rz.Text = data.Data[5].ToString( );
			} ) );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// 停止服务
			try
			{
				hyundai.ServerClose( );
				button1.Enabled = true;
				button2.Enabled = false;
				groupBox1.Enabled = false;
				groupBox2.Enabled = false;
				groupBox3.Enabled = false;
				groupBox4.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show( "Close Failed:" + ex.Message );
			}
		}

		private void RenderMoveResult( OperateResult operate, string op )
		{
			if (operate.IsSuccess)
			{
				label29.Text = $"Op[{op}] Result: True   Time:" + DateTime.Now.ToString( "HH:mm:ss.fff" );
			}
			else
			{
				MessageBox.Show( $"Op[{op}] failed : " + operate.Message );
			}
		}

		private void button3_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveX( double.Parse( textBox7.Text ) ), "X" );

		private void button4_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveX( 0 - double.Parse( textBox7.Text ) ), "-X" );

		private void button6_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveY( double.Parse( textBox8.Text ) ), "Y" );

		private void button5_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveY( 0 - double.Parse( textBox8.Text ) ), "-Y" );

		private void button8_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveZ( double.Parse( textBox9.Text ) ), "Z" );

		private void button7_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.MoveZ( 0 - double.Parse( textBox9.Text ) ), "-Z" );

		private void button10_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateX( double.Parse( textBox10.Text ) ), "Rx" );

		private void button9_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateX( 0 - double.Parse( textBox10.Text ) ), "Rx" );

		private void button12_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateY( double.Parse( textBox11.Text ) ), "Ry" );

		private void button11_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateY( 0 - double.Parse( textBox11.Text ) ), "Ry" );

		private void button14_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateZ( double.Parse( textBox12.Text ) ), "Rz" );

		private void button13_Click( object sender, EventArgs e ) => RenderMoveResult( hyundai.RotateZ( 0 - double.Parse( textBox12.Text ) ), "Rz" );

		private void button15_Click( object sender, EventArgs e )
		{
			 DemoUtils.WriteResultRender( ( ) => hyundai.WriteIncrementPos( 
				 double.Parse( textBox18.Text ),
				 double.Parse( textBox17.Text ),
				 double.Parse( textBox16.Text ),
				 double.Parse( textBox15.Text ),
				 double.Parse( textBox14.Text ),
				 double.Parse( textBox13.Text ) ), "X,Y,Z,Rx,Ry,Rz" );
		}
	}
}
