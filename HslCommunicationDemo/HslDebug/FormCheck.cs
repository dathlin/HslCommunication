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
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Serial;

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormCheck : HslFormContent
	{
		public FormCheck( )
		{
			InitializeComponent( );
		}

		private void FormCheck_Load( object sender, EventArgs e )
		{

		}

		#region CRC16

		private void button_crc16_calcu_Click( object sender, EventArgs e )
		{
			byte[] crc_code = textBox_crc16_code.Text.ToHexBytes( );
			byte[] crc_fill = textBox_crc16_fill.Text.ToHexBytes( );

			byte[] source = radioButton_crc16_hex.Checked ? textBox_crc16_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_crc16_source.Text );


			byte[] result = HslCommunication.Serial.SoftCRC16.CRC16Only( source, 0, source.Length, crc_code[0], crc_code[1], crc_fill[0], crc_fill[1] );
			textBox_crc16.Text = result.ToHexString( ' ' );
			textBox_crc16_ascii.Text = SoftBasic.GetAsciiStringRender( result );

			string code = radioButton_crc16_hex.Checked ? $"\"{textBox_crc16_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_crc16_source.Text}\" )";
			textBox_code.Text = $"byte[] result = HslCommunication.Serial.SoftCRC16.CRC16Only( {code}, 0, {source.Length}, {crc_code[0]}, {crc_code[1]}, {crc_fill[0]}, {crc_fill[1]} );";
		}

		private void button_crc16_check_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_crc16_hex.Checked ? textBox_crc16_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_crc16_source.Text );
			bool check = HslCommunication.Serial.SoftCRC16.CheckCRC16( source );
			MessageBox.Show( check ? "Good!" : "Bad!" );

			string code = radioButton_crc16_hex.Checked ? $"\"{textBox_crc16_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_crc16_source.Text}\" )";
			textBox_code.Text = $"bool check = HslCommunication.Serial.SoftCRC16.CheckCRC16( {code} );";
		}

		#endregion

		#region FCS


		private void button_fcs_calcu_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_fcs_hex.Checked ? textBox_fcs_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_fcs_source.Text );
			int left = Convert.ToInt32( textBox_fcs_left.Text );
			int right = Convert.ToInt32( textBox_fcs_right.Text );

			byte[] result = SoftLRC.CalculateFcs( source, left, right );
			textBox_fcs.Text = result.ToHexString( ' ' );
			textBox_fcs_ascii.Text = SoftBasic.GetAsciiStringRender( result );

			string code = radioButton_fcs_hex.Checked ? $"\"{textBox_fcs_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_fcs_source.Text}\" )";
			textBox_code.Text = $"byte[] result = SoftLRC.CalculateFcs( {code}, {left}, {right} );";
		}

		private void button_fcs_check_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_fcs_hex.Checked ? textBox_fcs_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_fcs_source.Text );
			int left = Convert.ToInt32( textBox_fcs_left.Text );
			int right = Convert.ToInt32( textBox_fcs_right.Text );

			byte[] fcs = SoftLRC.CalculateFcs( source, left, right );
			bool check = source[source.Length - right] == fcs[0] && source[source.Length - right + 1] == fcs[1];
			MessageBox.Show( check ? "Good!" : "Bad!" );

			string code = radioButton_fcs_hex.Checked ? $"\"{textBox_fcs_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_fcs_source.Text}\" )";
			textBox_code.Text = $"byte[] result = SoftLRC.CalculateFcs( {code}, {left}, {right} );";
		}


		#endregion

		#region ACC

		private void button_acc_calcu_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_acc_hex.Checked ? textBox_acc_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_acc_source.Text );
			int left  = Convert.ToInt32( textBox_acc_left.Text );
			int right = Convert.ToInt32( textBox_acc_right.Text );

			byte[] result = new byte[] { (byte)SoftLRC.CalculateAcc( source, left, right ) };

			textBox_acc.Text       = result.ToHexString( ' ' );
			textBox_acc_ascii.Text = SoftBasic.GetAsciiStringRender( result );

			string code = radioButton_acc_hex.Checked ? $"\"{textBox_acc_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_acc_source.Text}\" )";
			textBox_code.Text = $"byte[] result = new byte[] {{ (byte)SoftLRC.CalculateAcc( {code}, {left}, {right} ) }};";
		}

		private void button_acc_check_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_acc_hex.Checked ? textBox_acc_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_acc_source.Text );
			int left  = Convert.ToInt32( textBox_acc_left.Text );
			int right = Convert.ToInt32( textBox_acc_right.Text );


			bool check = SoftLRC.CalculateAccAndCheck( source, left, right );
			MessageBox.Show( check ? "Good!" : "Bad!" );

			string code = radioButton_acc_hex.Checked ? $"\"{textBox_acc_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_acc_source.Text}\" )";
			textBox_code.Text = $"bool check = SoftLRC.CalculateAccAndCheck( {code}, {left}, {right} );";
		}

		#endregion

		#region LRC

		private void button_lrc_calcu_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_lrc_hex.Checked ? textBox_lrc_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_lrc_source.Text );
			int left  = Convert.ToInt32( textBox_lrc_left.Text );
			int right = Convert.ToInt32( textBox_lrc_right.Text );

			byte[] result          = new byte[] { SoftLRC.LRC( source, left, right ) };
			textBox_lrc.Text       = result.ToHexString( ' ' );
			textBox_lrc_ascii.Text = SoftBasic.GetAsciiStringRender( result );


			string code = radioButton_lrc_hex.Checked ? $"\"{textBox_lrc_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_lrc_source.Text}\" )";
			textBox_code.Text = $"byte[] result = new byte[] {{ SoftLRC.LRC( {code}, {left}, {right} ) }};";
		}

		private void button_lrc_check_Click( object sender, EventArgs e )
		{
			byte[] source = radioButton_lrc_hex.Checked ? textBox_lrc_source.Text.ToHexBytes( ) : SoftBasic.GetFromAsciiStringRender( textBox_lrc_source.Text );
			int left  = Convert.ToInt32( textBox_lrc_left.Text );
			int right = Convert.ToInt32( textBox_lrc_right.Text );

			byte[] lrc = new byte[] { SoftLRC.LRC( source, left, right ) };

			bool check = source[source.Length - right] == lrc[0];
			MessageBox.Show( check ? "Good!" : "Bad!" );

			string code = radioButton_lrc_hex.Checked ? $"\"{textBox_lrc_source.Text}\".ToHexBytes( )" : $"SoftBasic.GetFromAsciiStringRender( \"{textBox_lrc_source.Text}\" )";
			textBox_code.Text = $"byte[] result = new byte[] {{ SoftLRC.LRC( {code}, {left}, {right} ) }};";
		}


		#endregion

	}
}
