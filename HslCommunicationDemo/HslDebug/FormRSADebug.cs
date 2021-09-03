using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormRSADebug : HslFormContent
    {
        public FormRSADebug( )
        {
            InitializeComponent( );
        }

        private void button1_Click( object sender, EventArgs e )
        {


        }



        ///// <summary>
        ///// base64 public key string -> xml public key
        ///// </summary>
        ///// <param name="pubilcKey"></param>
        ///// <returns></returns>
        //public static string ToXmlPublicKey( string pubilcKey )
        //{
        //    RsaKeyParameters p =
        //        PublicKeyFactory.CreateKey( Convert.FromBase64String( pubilcKey ) ) as RsaKeyParameters;
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider( ))
        //    {
        //        RSAParameters rsaParams = new RSAParameters
        //        {
        //            Modulus = p.Modulus.ToByteArrayUnsigned( ),
        //            Exponent = p.Exponent.ToByteArrayUnsigned( )
        //        };
        //        rsa.ImportParameters( rsaParams );
        //        return rsa.ToXmlString( false );
        //    }
        //}

        public static byte[] RSAEncrypt( string publickey, byte[] content )
        {
            publickey = $"<RSAKeyValue><Modulus>{publickey}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider( );
            rsa.FromXmlString( publickey );
            byte[] cipherbytes = rsa.Encrypt( content, false );
            return cipherbytes;
        }

        public static byte[] RSADecrypt( string privatekey, byte[] content )
        {
            privatekey = "";// ToXmlPrivateKey( privatekey );
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider( );
            rsa.FromXmlString( privatekey );
            byte[] cipherbytes = rsa.Decrypt( content, false );
            return cipherbytes;
        }
        private void FormByteTransfer_Load( object sender, EventArgs e )
        {
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 1)
            {
            }
            else
            {
                Text = "RSA encryption and decryption tool";
                label7.Text = "input";
                button3.Text = "Open";
                label2.Text = "Public key";
                button_jiami.Text = "encryption";
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

        private void button2_Click( object sender, EventArgs e )
        {
            // 解密
            byte[] jiemi = RSADecrypt( textBox_pri_key.Text, textBox_jiemi_input.Text.ToHexBytes( ) );
            if (radioButton3.Checked)
                textBox_jiemi_result.Text = jiemi.ToHexString( ' ' );
            else
                textBox_jiemi_result.Text = Encoding.UTF8.GetString( jiemi );
        }

    }
}
