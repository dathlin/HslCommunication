using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public partial class FormActive : Form
	{
		public FormActive( )
		{
			InitializeComponent( );
			activePath = System.IO.Path.Combine( Application.StartupPath, "active.txt" );
			Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );
		}

		string activePath = string.Empty;

		private void button1_Click( object sender, EventArgs e )
		{
			if (HslCommunication.Authorization.SetAuthorizationCode( textBox1.Text ))
			{
				MessageBox.Show( "激活成功!" );
				System.IO.File.WriteAllText( activePath, string.Empty, Encoding.UTF8 );
				System.IO.FileInfo fileInfo = new System.IO.FileInfo( activePath );
				string key = fileInfo.CreationTime.ToString( "yyyy-MM-dd-mm-ss" );
				HslCommunication.Core.Security.AesCryptography aesCryptography = new HslCommunication.Core.Security.AesCryptography( key + key );
				System.IO.File.WriteAllBytes( activePath, aesCryptography.Encrypt( Encoding.UTF8.GetBytes( textBox1.Text ) ) );
				DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show( "激活失败！" );
			}
		}

		private void FormActive_Load( object sender, EventArgs e )
		{

		}
	}
}
