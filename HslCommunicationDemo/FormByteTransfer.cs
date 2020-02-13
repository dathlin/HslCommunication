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
    public partial class FormByteTransfer : HslFormContent
    {
        public FormByteTransfer( )
        {
            InitializeComponent( );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            byte[] buffer = null;
            RadioButton radioButton = null;

            try
            {
                if (radioButton1.Checked)
                {
                    buffer = new byte[] { (byte.Parse( textBox1.Text )) };
                    radioButton = radioButton1;
                }
                else if(radioButton2.Checked)
                {
                    buffer = BitConverter.GetBytes( short.Parse( textBox1.Text ) );
                    radioButton = radioButton2;
                }
                else if (radioButton3.Checked)
                {
                    buffer = BitConverter.GetBytes( ushort.Parse( textBox1.Text ) );
                    radioButton = radioButton3;
                }
                else if (radioButton4.Checked)
                {
                    buffer = BitConverter.GetBytes( int.Parse( textBox1.Text ) );
                    radioButton = radioButton4;
                }
                else if (radioButton5.Checked)
                {
                    buffer = BitConverter.GetBytes( uint.Parse( textBox1.Text ) );
                    radioButton = radioButton5;
                }
                else if (radioButton6.Checked)
                {
                    buffer = BitConverter.GetBytes( long.Parse( textBox1.Text ) );
                    radioButton = radioButton6;
                }
                else if (radioButton7.Checked)
                {
                    buffer = BitConverter.GetBytes( ulong.Parse( textBox1.Text ) );
                    radioButton = radioButton7;
                }
                else if (radioButton8.Checked)
                {
                    buffer = BitConverter.GetBytes( float.Parse( textBox1.Text ) );
                    radioButton = radioButton8;
                }
                else if (radioButton9.Checked)
                {
                    buffer = BitConverter.GetBytes( double.Parse( textBox1.Text ) );
                    radioButton = radioButton9;
                }
                else if (radioButton10.Checked)
                {
                    buffer = Encoding.ASCII.GetBytes( textBox1.Text );
                    radioButton = radioButton10;
                }
                else if (radioButton11.Checked)
                {
                    buffer = Encoding.Unicode.GetBytes( textBox1.Text );
                    radioButton = radioButton11;
                }
                else if (radioButton12.Checked)
                {
                    buffer = Encoding.UTF8.GetBytes( textBox1.Text );
                    radioButton = radioButton12;
                }
                else if (radioButton13.Checked)
                {
                    buffer = Encoding.UTF32.GetBytes( textBox1.Text );
                    radioButton = radioButton13;
                }
                else if (radioButton14.Checked)
                {
                    buffer = Encoding.Default.GetBytes( textBox1.Text );
                    radioButton = radioButton13;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message );
                return;
            }


            textBox2.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " [" + textBox1.Text + "] ["+ radioButton.Text.PadRight(7,' ') + "] Length[" + buffer.Length + "] " +
                HslCommunication.BasicFramework.SoftBasic.ByteToHexString( buffer, ' ' ) + Environment.NewLine);

        }

        private void FormByteTransfer_Load( object sender, EventArgs e )
        {
            Language( Program.Language );
        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "字节转换工具";
                label7.Text = "等待转换的值：";
                label3.Text = "整型数据：";
                label6.Text = "浮点数据：";
                label8.Text = "字符数据：";
                label1.Text = "输出：(Hex)";
                button1.Text = "转换";
                button2.Text = "反向转换";
            }
            else
            {
                Text = "ByteTransform Tools";
                label7.Text = "Input value:";
                label3.Text = "Integer:";
                label6.Text = "Float:";
                label8.Text = "String:";
                label1.Text = "Output:(Hex)";
                button1.Text = "Conversion";
                button2.Text = "Re-conversion";
            }
        }


        private void FormByteTransfer_Shown( object sender, EventArgs e )
        {
            textBox1.Focus( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            string value = string.Empty;
            RadioButton radioButton = null;

            try
            {
                if (radioButton1.Checked)
                {
                    value = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text )[0].ToString( );
                    radioButton = radioButton1;
                }
                else if (radioButton2.Checked)
                {
                    value = BitConverter.ToInt16( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton2;
                }
                else if (radioButton3.Checked)
                {
                    value = BitConverter.ToUInt16( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton3;
                }
                else if (radioButton4.Checked)
                {
                    value = BitConverter.ToInt32( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton4;
                }
                else if (radioButton5.Checked)
                {
                    value = BitConverter.ToUInt32( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton5;
                }
                else if (radioButton6.Checked)
                {
                    value = BitConverter.ToInt64( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton6;
                }
                else if (radioButton7.Checked)
                {
                    value = BitConverter.ToUInt64( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton7;
                }
                else if (radioButton8.Checked)
                {
                    value = BitConverter.ToSingle( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton8;
                }
                else if (radioButton9.Checked)
                {
                    value = BitConverter.ToDouble( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ), 0 ).ToString( );
                    radioButton = radioButton9;
                }
                else if (radioButton10.Checked)
                {
                    value = Encoding.ASCII.GetString( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) ).ToString( );
                    radioButton = radioButton10;
                }
                else if (radioButton11.Checked)
                {
                    value = Encoding.Unicode.GetString( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) ).ToString( );
                    radioButton = radioButton11;
                }
                else if (radioButton12.Checked)
                {
                    value = Encoding.UTF8.GetString( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) ).ToString( );
                    radioButton = radioButton12;
                }
                else if (radioButton13.Checked)
                {
                    value = Encoding.UTF32.GetString( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) ).ToString( );
                    radioButton = radioButton13;
                }
                else if (radioButton14.Checked)
                {
                    value = Encoding.Default.GetString( HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox1.Text ) ).ToString( );
                    radioButton = radioButton13;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
                return;
            }


            textBox2.AppendText( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff" ) + " [" + textBox1.Text + "] [" + radioButton.Text.PadRight( 7, ' ' ) + "]  " +
                value + Environment.NewLine );
        }
    }
}
