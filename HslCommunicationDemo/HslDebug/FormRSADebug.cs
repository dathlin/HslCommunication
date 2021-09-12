using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication;
using System.Security.Cryptography;
using HslCommunication.Core.Security;

namespace HslCommunicationDemo
{
	public partial class FormRSADebug : HslFormContent
	{
		public FormRSADebug( )
		{
			InitializeComponent( );
		}



		private void FormByteTransfer_Load( object sender, EventArgs e )
		{
			Language( Program.Language );

			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider( );
			textBox_pri_key.Text = Convert.ToBase64String( rsa.GetPEMPrivateKey( ) );
			textBox_pub_key.Text = Convert.ToBase64String( rsa.GetPEMPublicKey( ) );

			StringBuilder sb = new StringBuilder( );
			for (int i = 0; i < 117; i++)
			{
				sb.Append( "1" );
			}
			textBox_jiami_input.Text = sb.ToString( );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				Text = "RSA encryption and decryption tool";
				label7.Text = "Original data: (Drag the file to the box below in non-admin mode)";
				label2.Text = "Public key";
				label4.Text = "Private Key";
				button_jiami.Text = "Encrypt";
				button_jiemi.Text = "Decrypt";
				label1.Text = "Output(HEX)";
				label6.Text = "Output(HEX)";
				label5.Text = "Encrypted data";
				label3.Text = "DataType:";
				label8.Text = "DataType:";
				button1.Text = "Result Save As";
			}
		}


		private void FormByteTransfer_Shown( object sender, EventArgs e )
		{

		}

		private void button3_Click( object sender, EventArgs e )
		{
		}

		private void textBox2_DragEnter( object sender, DragEventArgs e )
		{
		}

		private void textBox2_DragDrop( object sender, DragEventArgs e )
		{

		}

		#region 等待解密的数据的拖拽

		private void textBox_jiemi_input_DragDrop( object sender, DragEventArgs e )
		{
			string fileName = ((System.Array)e.Data.GetData( DataFormats.FileDrop )).GetValue( 0 ).ToString( );
			if (File.Exists( fileName ))
			{
				textBox_jiemi_input.Text = File.ReadAllBytes( fileName ).ToHexString( ' ' );
			}

			this.textBox_jiami_input.Cursor = Cursors.IBeam; //还原鼠标形状
		}

		private void textBox_jiemi_input_DragEnter( object sender, DragEventArgs e )
		{
			if (e.Data.GetDataPresent( DataFormats.FileDrop ))
			{
				e.Effect = DragDropEffects.Link;
				this.textBox_jiami_input.Cursor = Cursors.Arrow;  //指定鼠标形状（更好看）  
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pri_key_DragEnter( object sender, DragEventArgs e )
		{
			if (e.Data.GetDataPresent( DataFormats.FileDrop ))
			{
				e.Effect = DragDropEffects.Link;
				this.textBox_pri_key.Cursor = Cursors.Arrow;  //指定鼠标形状（更好看）  
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pri_key_DragDrop( object sender, DragEventArgs e )
		{
			string fileName = ((System.Array)e.Data.GetData( DataFormats.FileDrop )).GetValue( 0 ).ToString( );
			if (File.Exists( fileName ))
			{
				textBox_pri_key.Text = File.ReadAllText( fileName, Encoding.UTF8 );
			}

			this.textBox_pri_key.Cursor = Cursors.IBeam; //还原鼠标形状
		}
		#endregion


		private void button2_Click( object sender, EventArgs e )
		{
			RSACryptoServiceProvider rsa = RSAHelper.CreateRsaProviderFromPrivateKey( textBox_pri_key.Text );
			// 解密
			byte[] jiemi = rsa.Decrypt( textBox_jiemi_input.Text.ToHexBytes( ), false );
			if (radioButton3.Checked)
				textBox_jiemi_result.Text = jiemi.ToHexString( ' ' );
			else
				textBox_jiemi_result.Text = Encoding.UTF8.GetString( jiemi );
		}

		private void textBox_jiami_input_DragEnter( object sender, DragEventArgs e )
		{
			if (e.Data.GetDataPresent( DataFormats.FileDrop ))
			{
				e.Effect = DragDropEffects.Link;
				this.textBox_jiami_input.Cursor = Cursors.Arrow;  //指定鼠标形状（更好看）  
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_jiami_input_DragDrop( object sender, DragEventArgs e )
		{
			string fileName = ((System.Array)e.Data.GetData( DataFormats.FileDrop )).GetValue( 0 ).ToString( );
			if (File.Exists( fileName ))
			{
				textBox_jiami_input.Text = File.ReadAllText( fileName, Encoding.UTF8 );
			}

			this.textBox_jiami_input.Cursor = Cursors.IBeam; //还原鼠标形状
		}

		private void textBox_pub_key_DragEnter( object sender, DragEventArgs e )
		{
			if (e.Data.GetDataPresent( DataFormats.FileDrop ))
			{
				e.Effect = DragDropEffects.Link;
				this.textBox_pub_key.Cursor = Cursors.Arrow;  //指定鼠标形状（更好看）  
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pub_key_DragDrop( object sender, DragEventArgs e )
		{
			string fileName = ((System.Array)e.Data.GetData( DataFormats.FileDrop )).GetValue( 0 ).ToString( );
			if (File.Exists( fileName ))
			{
				textBox_pub_key.Text = File.ReadAllText( fileName, Encoding.UTF8 );
			}

			this.textBox_pub_key.Cursor = Cursors.IBeam; //还原鼠标形状
		}


		private void button1_Click( object sender, EventArgs e )
		{
			RSACryptoServiceProvider rsa = HslCommunication.Core.Security.RSAHelper.CreateRsaProviderFromPublicKey(
				textBox_pub_key.Text );
			// 加密

			byte[] jiami = null;
			if (radioButton1.Checked)
				jiami = rsa.Encrypt( textBox_jiami_input.Text.ToHexBytes( ), false );
			else
				jiami = rsa.Encrypt( Encoding.UTF8.GetBytes( textBox_jiami_input.Text ), false );

			textBox_jiami_result.Text = jiami.ToHexString( ' ' );
			label9.Text = "" + jiami.Length;
		}

		private void button1_Click_1( object sender, EventArgs e )
		{
			// 加密结果另存为
			SaveFileDialog dialog = new SaveFileDialog( );
			if (dialog.ShowDialog( ) == DialogResult.OK)
			{
				File.WriteAllBytes( dialog.FileName, textBox_jiami_result.Text.ToHexBytes( ) );

				MessageBox.Show( "Save Success" );
			}
		}
	}
}
