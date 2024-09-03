using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunicationDemo.Control;
using HslCommunication.LogNet;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Security;
using System.Security.Cryptography;
using HslCommunicationDemo.DemoControl;
using HslCommunication;
using HslCommunication.Core.Device;
using HslCommunication.Core.Pipe;
using HslCommunication.Serial;

namespace HslCommunicationDemo
{
	public class HslFormContent : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			AutoScroll = true;
		}

		public ILogNet LogNet { get; set; }


		public virtual void LoadXmlParameter( XElement element )
		{
			xElement = element;
			Text = xElement.Attribute( DemoDeviceList.XmlName ).Value;
		}

		public void SetXml( XElement element )
		{
			xElement = element;
		}

		/// <summary>
		/// 当前的密码信息
		/// </summary>
		public string Password { get; set; }

		public virtual void SaveXmlParameter(XElement element )
		{
			throw new NotImplementedException( "SaveXmlParameter Not Implemented" );
		}

		public void SetProtocolImage( System.Drawing.Image image )
		{
			foreach (System.Windows.Forms.Control control in this.Controls)
			{
				if (control is UserControlHead userControlHead)
				{
					userControlHead.SetProtocolImage( image );
					break;
				}
			}
		}


		public void userControlHead1_SaveConnectEvent( object sender, EventArgs e )
		{
			try
			{
				if (xElement == null)
				{
					using (FormInputString form = new FormInputString( ))
					{
						if (form.ShowDialog( ) == DialogResult.OK)
						{
							// 保存连接
							xElement = new XElement( "Device" );
							xElement.SetAttributeValue( DemoDeviceList.XmlGuid, Guid.NewGuid( ).ToString( "N" ) );
							xElement.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
							xElement.SetAttributeValue( DemoDeviceList.XmlName, form.DeviceAlias );

							if (!string.IsNullOrEmpty( form.Password ))
							{
								RSACryptoServiceProvider rsa = RSAHelper.CreateRsaProviderFromPublicKey( "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCqzFn3dRlmxu3qk+aCddTdIUFYhc6rxUpERe8XG+Vf8DQ70JnfWVcTmlCxpdIu6R0VWzk03o6F20rai0ZnBI1SkxRta34wm1mPDzEFs/vdY7FBFy153c7S3dwM5t9leSBSVRrV1SVWjlphwnGZ+FwMtGXlZ7W+kI5IY1ONhIRXwQIDAQAB" );
								xElement.SetAttributeValue( DemoDeviceList.XmlEncrypt2, Convert.ToBase64String( rsa.Encrypt( Encoding.UTF8.GetBytes( form.Password ), false ) ) );

								XElement encrypt = new XElement( "Device" );
								encrypt.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
								encrypt.SetAttributeValue( DemoDeviceList.XmlName, form.DeviceAlias );

								SaveXmlParameter( encrypt );
								AesCryptography aesCryptography = new AesCryptography( form.Password.PadRight( 32, '0' ) );
								xElement.SetAttributeValue( DemoDeviceList.XmlEncrypt, aesCryptography.Encrypt( encrypt.ToString( ) ) );
							}
							else
							{
								SaveXmlParameter( xElement );
							}

							FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement );
							MessageBox.Show( "Save Success" );
						}
					}
				}
				else
				{
					// 判断是否加密了，如果是加密的话，需要先进行解密的操作
					if (xElement.Attribute( DemoDeviceList.XmlEncrypt ) != null)
					{
						AesCryptography aesCryptography = new AesCryptography( Password.PadRight( 32, '0' ) );
						try
						{
							XElement encrypt = new XElement( "Device" );
							encrypt.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
							encrypt.SetAttributeValue( DemoDeviceList.XmlName, xElement.Attribute( DemoDeviceList.XmlName )?.Value );

							SaveXmlParameter( encrypt );
							xElement.SetAttributeValue( DemoDeviceList.XmlEncrypt, aesCryptography.Encrypt( encrypt.ToString( ) ) );
							FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement );
							MessageBox.Show( "Save Success" );
						}
						catch (Exception ex)
						{
							MessageBox.Show( (Program.Language == 1 ? "加密失败，无法加载当前的配置信息" : "Encryption failed and the current configuration information could not be loaded ") + ex.Message );
						}
					}
					else
					{
						SaveXmlParameter( xElement );
						FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement );
						MessageBox.Show( "Save Success" );
					}
				}
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( "Save failed:", ex );
			}
		}

		private XElement xElement = null;



		/// <summary>
		/// 从XElement中提取相关的属性信息，如果不存在，就返回默认值
		/// </summary>
		/// <typeparam name="T">最终的类型信息</typeparam>
		/// <param name="element">元素内容</param>
		/// <param name="name">属性的名称</param>
		/// <param name="defaultValue">默认提供的值</param>
		/// <param name="trans">转换方式</param>
		/// <returns>最终的值</returns>
		public static T GetXmlValue<T>( XElement element, string name, T defaultValue, Func<string, T> trans )
		{
			XAttribute attribute = element.Attribute( name );
			if (attribute == null) return defaultValue;

			try
			{
				return trans( attribute.Value );
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <inheritdoc cref="GetXmlValue{T}(XElement, string, T, Func{string, T})"/>
		public static T GetXmlEnum<T>( XElement element, string name, T defaultValue ) where T : struct
		{
			XAttribute attribute = element.Attribute( name );
			if (attribute == null) return defaultValue;

			try
			{
				return SoftBasic.GetEnumFromString<T>( attribute.Value );
			}
			catch
			{
				return defaultValue;
			}
		}


		protected OperateResult DeviceConnectPLC( DeviceTcpNet device )
		{
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				return OperateResult.CreateSuccessResult( );
			}
			else
				return device.ConnectServer( );
		}

		protected OperateResult DeviceConnectPLC( DeviceSerialPort device )
		{
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				return OperateResult.CreateSuccessResult( );
			}
			else
				return device.Open( );
		}
		protected OperateResult DeviceConnectPLC( SerialBase device )
		{
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				return OperateResult.CreateSuccessResult( );
			}
			else
				return device.Open( );
		}

		protected OperateResult DeviceConnectPLC( DeviceUdpNet device )
		{
			return OperateResult.CreateSuccessResult( );
		}
	}
}
