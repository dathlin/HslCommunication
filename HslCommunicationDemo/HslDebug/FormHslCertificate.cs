using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HslCommunication;
using HslCommunication.Core.Security;

namespace HslCommunicationDemo
{
	public partial class FormHslCertificate : HslFormContent
	{
		public FormHslCertificate( )
		{
			InitializeComponent( );
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider( );
			textBox_pri_key.Text = Convert.ToBase64String( rsa.GetPEMPrivateKey( ) );
			textBox_pub_key.Text = Convert.ToBase64String( rsa.GetPEMPublicKey( ) );

			textBox_NotBefore.Text = DateTime.Now.ToString( "yyyy-MM-dd" );
			textBox_NotAfter.Text = DateTime.Now.AddYears( 1 ).ToString( "yyyy-MM-dd" );

			textBox_createDate.Text = DateTime.Now.ToString( "yyyy-MM-dd" );

			Language( Program.Language );
		}

		private void Language( int language )
		{
			if (language == 1)
			{
			}
			else
			{
				groupBox1.Text = "Public and private keys";
				label2.Text = "Public:";
				label3.Text = "Data formate:";
				label4.Text = "Private:";
				groupBox2.Text = "Certificate information";
				label1.Text = "Issuing:";
				label5.Text = "Holder:";
				label6.Text = "Not Before:";
				label7.Text = "Not After:";
				label11.Text = "Create Date:";
				label_hours.Text = "Hours: ";
				label8.Text = "Key Word:";
				label9.Text = "Unique:";
				label10.Text = "Extra info (key-value pairs + line breaks): For example: A: Hello";

				button_create.Text = "Create certificate";
				button_load.Text = "Load certificate";
				button_verify.Text = "Verify certificate";
			}
		}

		private void button_create_Click( object sender, EventArgs e )
		{
			byte[] pubKey = radioButton2.Checked ? Convert.FromBase64String( textBox_pub_key.Text ) : textBox_pub_key.Text.ToHexBytes( );
			byte[] priKey = radioButton2.Checked ? Convert.FromBase64String( textBox_pri_key.Text ) : textBox_pri_key.Text.ToHexBytes( );

			HslCertificate certificate = new HslCertificate( pubKey, priKey );
			certificate.From = textBox_From.Text;
			certificate.To = textBox_To.Text;
			certificate.NotBefore   = DateTime.Parse( textBox_NotBefore.Text );
			certificate.NotAfter    = DateTime.Parse( textBox_NotAfter.Text );
			certificate.CreateTime  = DateTime.Parse( textBox_createDate.Text );
			certificate.EffectiveHours = Convert.ToInt32( textBox_hours.Text );
			certificate.KeyWord = textBox_KeyWord.Text;
			certificate.UniqueID = textBox_Unique.Text;

			if (textBox_Descriptions.Lines?.Length > 0)
			{
				certificate.Descriptions = new Dictionary<string, string>( );
				foreach (var item in textBox_Descriptions.Lines)
				{
					string[] tmp = item.Split( new char[] { ',', '/', ':' }, StringSplitOptions.RemoveEmptyEntries );
					if (tmp.Length == 2)
					{
						certificate.Descriptions.Add( tmp[0], tmp[1] );
					}
				}
			}

			using(SaveFileDialog sfd = new SaveFileDialog( ))
			{
				sfd.FileName = "hsl.cert";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllBytes( sfd.FileName, certificate.GetSaveBytes( ) );
				}
			}

			string str = "创建证书完成，是否复制证书到剪切板？";
			if (Program.Language == 2) str = "After creating the certificate, do you want to copy the certificate to the clipboard?";
			if (MessageBox.Show( str, "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Clipboard.SetText( Convert.ToBase64String( certificate.GetSaveBytes( ) ) );
			}
		}

		private void button_load_Click( object sender, EventArgs e )
		{
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					try
					{
						byte[] data = File.ReadAllBytes( ofd.FileName );
						HslCertificate certificate = HslCertificate.CreateFrom( data );

						textBox_pub_key.Text = radioButton2.Checked ? Convert.ToBase64String( certificate.PublicKey ) : certificate.PublicKey.ToHexString( ' ' );
						textBox_From.Text = certificate.From;
						textBox_To.Text = certificate.To;
						textBox_NotBefore.Text = certificate.NotBefore.ToString( "yyyy-MM-dd HH:mm:ss" );
						textBox_NotAfter.Text = certificate.NotAfter.ToString( "yyyy-MM-dd HH:mm:ss" );
						textBox_KeyWord.Text = certificate.KeyWord;
						textBox_Unique.Text = certificate.UniqueID;
						textBox_createDate.Text = certificate.CreateTime.ToString( "yyyy-MM-dd" );
						textBox_hours.Text = certificate.EffectiveHours.ToString( );

						if (certificate.Descriptions?.Count > 0)
						{
							StringBuilder sb = new StringBuilder( );
							foreach (var item in certificate.Descriptions)
							{
								sb.Append( item.Key );
								sb.Append( ":" );
								sb.Append( item.Value );
								sb.Append( Environment.NewLine );
							}
							textBox_Descriptions.Text = sb.ToString( ).TrimEnd( '\r', '\n' );
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show( "Verify failed: " + ex.Message );
					}
				}
			}
		}

		private void button_verify_Click( object sender, EventArgs e )
		{
			// 先获取公钥，如果没有在输入框里输入公钥，则为空，就校验证书的签名是否匹配本身，但是这样不安全，为了确保是自己发出的证书，必须校验公钥数据本身
			// Obtain the public key first, if you do not enter the public key in the input box, it is empty, and verify whether the signature of the certificate matches itself,
			// but this is not safe, in order to ensure that it is a certificate issued by yourself, you must verify the public key data itself
			byte[] pubKey = string.IsNullOrEmpty( textBox_pub_key.Text ) ? null : radioButton2.Checked ? Convert.FromBase64String( textBox_pub_key.Text ) : textBox_pub_key.Text.ToHexBytes( );
			using (OpenFileDialog ofd = new OpenFileDialog( ))
			{
				if (ofd.ShowDialog( ) == DialogResult.OK)
				{
					try
					{
						byte[] data = File.ReadAllBytes( ofd.FileName );
						if (HslCertificate.VerifyCer( pubKey, data ))
						{
							MessageBox.Show( "Verify success" );
						}
						else
						{
							MessageBox.Show( "Verify failed" );
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show( "Verify failed: " + ex.Message );
					}
				}
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			textBox_Unique.Text = Guid.NewGuid( ).ToString( );
		}
	}
}
