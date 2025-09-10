using HslCommunication;
using HslCommunication.Core.Security;
using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Vip
{
	public partial class HslCertificateControl : UserControl
	{
		public HslCertificateControl( )
		{
			InitializeComponent( );
			SizeChanged += HslCertificateControl_SizeChanged;
		}

		private void HslCertificateControl_SizeChanged( object sender, EventArgs e )
		{
			if (this.Width > 200 && this.Height > 200)
				button_create.Location = new Point( this.Width / 2 - button_create.Width / 2, this.Height - 48 );
		}

		private void HslCertificateControl_Load( object sender, EventArgs e )
		{
			textBox_createDate.Text = DateTime.Now.ToString( "yyyy-MM-dd" );
			textBox_NotBefore.Text = DateTime.Now.ToString( "yyyy-MM-dd" );
			textBox_NotAfter.Text = DateTime.Now.AddYears( 1 ).ToString( "yyyy-MM-dd" );
			SetEditMode( false );
			if (Program.Language == 2)
			{
				linkLabel1.Text = "Edit Mode";
			}
		}

		public void SetCompanyName( string company )
		{
			textBox_From.Text = company;
		}

		public void RenderHslCertificate( CertificateItem cert )
		{
			this.certificateItem = cert;
			HslCertificate certificate = cert.Certificate;
			if (certificate == null)
			{
				textBox_To.Text = string.Empty;
				textBox_Unique.Text = string.Empty;
				textBox_Descriptions.Text = string.Empty;
				return;
			}
			textBox_From.Text = certificate.From;
			textBox_To.Text = certificate.To;
			textBox_NotBefore.Text = certificate.NotBefore.ToString( "yyyy-MM-dd" );
			textBox_NotAfter.Text = certificate.NotAfter.ToString( "yyyy-MM-dd" );
			textBox_createDate.Text = certificate.CreateTime.ToString( "yyyy-MM-dd" );
			textBox_hours.Text = certificate.EffectiveHours.ToString( );
			textBox_KeyWord.Text = certificate.KeyWord;
			textBox_Unique.Text = certificate.UniqueID;

			StringBuilder descriptions = new StringBuilder( );
			foreach (var item in certificate.Descriptions)
			{
				descriptions.AppendLine( $"{item.Key}:{item.Value}" );
				if (item.Key.Equals( "语言", StringComparison.OrdinalIgnoreCase ))
				{
					if (item.Value.Equals( "DotNet", StringComparison.OrdinalIgnoreCase ))
						radioButton_dotnet.Checked = true;
					else
						radioButton_java.Checked = true;
				}
			}
			textBox_Descriptions.Text = descriptions.ToString( );


			// 查看模式下
			if (editMode) SetEditMode( false );
		}

		public void SetReadOnly( bool readOnly )
		{
			textBox_To.ReadOnly = readOnly;
			textBox_NotBefore.ReadOnly = readOnly;
			textBox_NotAfter.ReadOnly = readOnly;
			textBox_hours.ReadOnly = readOnly;
			textBox_Unique.ReadOnly = readOnly;
			textBox_Descriptions.ReadOnly = readOnly;
			radioButton_dotnet.Enabled = !readOnly;
			radioButton_java.Enabled = !readOnly;
		}

		public void SetRpcClient( MqttSyncClient rpc )
		{
			this.rpc = rpc;
		}

		public void SetEditMode( bool edit )
		{
			SetReadOnly( !edit );
			editMode = edit;

			if (edit)
				button_create.Text = Program.Language == 1 ? "创建证书" : "Create Certificate";
			else
				button_create.Text = Program.Language == 1 ? "导出密钥" : "Export Key";
		}

		private void button_create_Click( object sender, EventArgs e )
		{
			if (editMode == false)
			{
				if (this.certificateItem != null)
				{
					Clipboard.SetText( Convert.ToBase64String( this.certificateItem.CertBinary ) );
					if (Program.Language == 1)
						DemoUtils.ShowMessage( "证书密钥已经复制到剪贴板\r\n\r\n" + Convert.ToBase64String( this.certificateItem.CertBinary ) );
					else
						DemoUtils.ShowMessage( "Certificate Key has been copied to clipboard: \r\n\r\n" + Convert.ToBase64String( this.certificateItem.CertBinary ) );
				}
				else
				{
					if (Program.Language == 1)
						DemoUtils.ShowMessage( "当前没有任何证书信息！" );
					else
						DemoUtils.ShowMessage( "No Certificate Information Exist!" );
				}
				return;
			}

			if (string.IsNullOrEmpty(textBox_To.Text))
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "请输入证书的使用者/持有者信息！" );
				else
					DemoUtils.ShowMessage( "Please Input the User Name of Certificate!" );
				return;
			}

			if (!DateTime.TryParse( textBox_NotBefore.Text, out DateTime notBefore ))
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "请输入正确的证书生效时间！" );
				else
					DemoUtils.ShowMessage( "Please Input the NotBefore DateTime of Certificate!" );
				return;
			}

			if (!DateTime.TryParse( textBox_NotAfter.Text, out DateTime notAfter ))
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "请输入正确的证书失效时间！" );
				else
					DemoUtils.ShowMessage( "Please Input the NotAfter DateTime of Certificate!" );
				return;
			}

			if (!int.TryParse(textBox_hours.Text, out int hours ))
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "请输入正确的有效小时数！" );
				else
					DemoUtils.ShowMessage( "Please Input the Hours value!" );
				return;
			}

			OperateResult<string> createCert = rpc.ReadRpc<string>( radioButton_dotnet.Checked ? "CreateDotNetCertificate" : "CreateJavaCertificate",
				new { userName = textBox_To.Text, startDate = textBox_NotBefore.Text, finishDate = textBox_NotAfter.Text, hours = int.Parse( textBox_hours.Text ), unique = textBox_Unique.Text, keyValues = textBox_Descriptions.Lines } );

			if (createCert.IsSuccess)
			{
				Clipboard.SetText( createCert.Content );
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "创建证书成功，已经复制到剪贴板\r\n\r\n" + createCert.Content );
				else
					DemoUtils.ShowMessage( "Create Certificate Success! Ctrl+V to Get String: \r\n\r\n" + createCert.Content );
			}
			else
			{
				if (Program.Language == 1)
					DemoUtils.ShowMessage( "创建证书失败: " + createCert.Message );
				else
					DemoUtils.ShowMessage( "Create Certificate Failed: " + createCert.Message );
			}
		}

		private CertificateItem certificateItem;
		private MqttSyncClient rpc = null;
		private bool editMode = false;

		private void linkLabel1_Click( object sender, EventArgs e )
		{
			SetEditMode( true );
		}
	}
}
