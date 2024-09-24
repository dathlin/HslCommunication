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

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormHandShake : System.Windows.Forms.Form
	{
		public FormHandShake( List<byte[]> handShake )
		{
			InitializeComponent( );
			this.handShake = handShake;
		}

		private void button_clear_Click( object sender, EventArgs e )
		{
			textBox1.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
		}

		private void button_ok_Click( object sender, EventArgs e )
		{
			List<byte[]> handShake = new List<byte[]>( );
			if (!string.IsNullOrEmpty( textBox1.Text )) handShake.Add( radioButton_binary.Checked ? textBox1.Text.ToHexBytes( ) : Encoding.ASCII.GetBytes( textBox1.Text ) );
			if (!string.IsNullOrEmpty( textBox2.Text )) handShake.Add( radioButton_binary.Checked ? textBox2.Text.ToHexBytes( ) : Encoding.ASCII.GetBytes( textBox2.Text ) );
			if (!string.IsNullOrEmpty( textBox3.Text )) handShake.Add( radioButton_binary.Checked ? textBox3.Text.ToHexBytes( ) : Encoding.ASCII.GetBytes( textBox3.Text ) );

			this.handShake = handShake;
			DialogResult = DialogResult.OK;
		}

		private List<byte[]> handShake = null;

		public List<byte[]> HandShake => this.handShake;

		private void FormHandShake_Load( object sender, EventArgs e )
		{
			if (this.handShake != null)
			{
				if (handShake.Count > 0) textBox1.Text = radioButton_binary.Checked ? handShake[0].ToHexString( ' ' ) : SoftBasic.GetAsciiStringRender( handShake[0] );
				if (handShake.Count > 1) textBox2.Text = radioButton_binary.Checked ? handShake[1].ToHexString( ' ' ) : SoftBasic.GetAsciiStringRender( handShake[1] );
				if (handShake.Count > 2) textBox3.Text = radioButton_binary.Checked ? handShake[2].ToHexString( ' ' ) : SoftBasic.GetAsciiStringRender( handShake[2] );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 西门子报文
			textBox1.Text = new byte[22] {
				0x03, 0x00, 0x00, 0x16, 0x11, 0xE0, 0x00, 0x00, 0x00, 0x01, 0x00, 0xC0, 0x01, 0x0A, 0xC1, 0x02,
				0x01, 0x02, 0xC2, 0x02, 0x01, 0x00 }.ToHexString( ' ' );

			textBox2.Text = new byte[25] {
				0x03,0x00,0x00,0x19,0x02,0xF0,0x80,0x32,0x01,0x00,0x00,0x04,0x00,0x00,0x08,0x00,
				0x00,0xF0,0x00,0x00,0x01,0x00,0x01,0x01,0xE0 }.ToHexString( ' ' );

			textBox3.Text = string.Empty;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			// FinsTcp
			textBox1.Text = new byte[]
			{
				0x46, 0x49, 0x4E, 0x53, // FINS
				0x00, 0x00, 0x00, 0x0C, // 后面的命令长度
				0x00, 0x00, 0x00, 0x00, // 命令码
				0x00, 0x00, 0x00, 0x00, // 错误码
				0x00, 0x00, 0x00, 0x00  // 节点号, 为0的话，自动获取
			}.ToHexString( ' ' );
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// CIP协议
			textBox1.Text = HslCommunication.Profinet.AllenBradley.AllenBradleyHelper.RegisterSessionHandle().ToHexString( ' ' );
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
		}
	}
}
