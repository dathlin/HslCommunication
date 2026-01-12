using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Device;
using HslCommunication.Core.Net;
using HslCommunication.Core.Pipe;
using HslCommunication.Core.Security;
using HslCommunication.LogNet;
using HslCommunication.Serial;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo
{
	public class HslFormContent : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public HslFormContent( )
		{
			FormGuid = Guid.NewGuid( ).ToString( "N" );
		}

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

		/// <summary>
		/// 当前窗体的唯一标识符
		/// </summary>
		public string FormGuid { get; private set; }

		public virtual void SaveXmlParameter(XElement element )
		{
			throw new NotImplementedException( "SaveXmlParameter Not Implemented" );
		}

		public System.Drawing.Image DeviceImage { get; set; }

		public void SetProtocolImage( System.Drawing.Image image )
		{
			this.DeviceImage = image;
			foreach (System.Windows.Forms.Control control in this.Controls)
			{
				if (control is UserControlHead userControlHead)
				{
					userControlHead.SetProtocolImage( image );
					break;
				}
			}
		}

		private void SaveDeviceXml( FormInputString form, XElement element, bool showDialog = true )
		{
			if (!showDialog || form.ShowDialog( ) == DialogResult.OK)
			{
				// 保存连接
				element.SetAttributeValue( DemoDeviceList.XmlGuid, Guid.NewGuid( ).ToString( "N" ) );
				element.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
				element.SetAttributeValue( DemoDeviceList.XmlName, form.DeviceAlias );

				if (!string.IsNullOrEmpty( form.Password ))
				{
					element.SetAttributeValue( DemoDeviceList.XmlEncrypt2, Convert.ToBase64String( rsa.Encrypt( Encoding.UTF8.GetBytes( form.Password ), false ) ) );

					XElement encrypt = new XElement( "Device" );
					encrypt.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
					encrypt.SetAttributeValue( DemoDeviceList.XmlName, form.DeviceAlias );

					SaveXmlParameter( encrypt );
					AesCryptography aesCryptography = new AesCryptography( form.Password.PadRight( 32, '0' ) );
					element.SetAttributeValue( DemoDeviceList.XmlEncrypt, aesCryptography.Encrypt( encrypt.ToString( ) ) );
				}
				else
				{
					SaveXmlParameter( element );
				}

				FormMain.Form?.GetPanelLeft( )?.AddDeviceList( element, this );
				DemoUtils.ShowMessage( "Save Success" );
			}
		}

		private static RSACryptoServiceProvider rsa = RSAHelper.CreateRsaProviderFromPublicKey( "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCqzFn3dRlmxu3qk+aCddTdIUFYhc6rxUpERe8XG+Vf8DQ70JnfWVcTmlCxpdIu6R0VWzk03o6F20rai0ZnBI1SkxRta34wm1mPDzEFs/vdY7FBFy153c7S3dwM5t9leSBSVRrV1SVWjlphwnGZ+FwMtGXlZ7W+kI5IY1ONhIRXwQIDAQAB" );

		public void userControlHead1_SaveConnectEvent( object sender, EventArgs e )
		{
			try
			{
				if (xElement == null)
				{
					xElement = new XElement( "Device" );
					using (FormInputString form = new FormInputString( ))
					{
						SaveDeviceXml( form, xElement );
						if (!string.IsNullOrEmpty( form.DeviceAlias ))
							this.Text = form.DeviceAlias;
					}
				}
				else
				{
					string name = xElement.Attribute( DemoDeviceList.XmlName )?.Value;
					using (FormInputString form = new FormInputString( name, this.Password ))
					{
						if (form.ShowDialog( ) == DialogResult.OK)
						{
							if (name != form.DeviceAlias)
							{
								// 需要创建新的配置界面了，删除就的GUID绑定
								string guid = GetXmlValue(xElement, DemoDeviceList.XmlGuid, "", m => m );
								if (!string.IsNullOrEmpty( guid )) FormMain.Form?.GetPanelLeft( )?.RemoveDeviceForm( guid );

								xElement = new XElement( "Device" );
								SaveDeviceXml( form, xElement, showDialog: false );
								this.Text = form.DeviceAlias;
							}
							else
							{
								// 这里是覆盖保存
								// 判断是否加密了，如果是加密的话，需要先进行解密的操作
								this.Password = form.Password;
								string guid = xElement.Attribute( DemoDeviceList.XmlGuid )?.Value;
								xElement = new XElement( "Device" );
								xElement.SetAttributeValue( DemoDeviceList.XmlGuid, guid );
								xElement.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
								xElement.SetAttributeValue( DemoDeviceList.XmlName, form.DeviceAlias );

								if (!string.IsNullOrEmpty( this.Password ))
								{
									AesCryptography aesCryptography = new AesCryptography( Password.PadRight( 32, '0' ) );
									try
									{
										xElement.SetAttributeValue( DemoDeviceList.XmlEncrypt2, Convert.ToBase64String( rsa.Encrypt( Encoding.UTF8.GetBytes( form.Password ), false ) ) );

										XElement encrypt = new XElement( "Device" );
										encrypt.SetAttributeValue( DemoDeviceList.XmlType, this.GetType( ).Name );
										encrypt.SetAttributeValue( DemoDeviceList.XmlName, xElement.Attribute( DemoDeviceList.XmlName )?.Value );

										SaveXmlParameter( encrypt );
										xElement.SetAttributeValue( DemoDeviceList.XmlEncrypt, aesCryptography.Encrypt( encrypt.ToString( ) ) );
										FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement, this );
										DemoUtils.ShowMessage( "Save Success" );
									}
									catch (Exception ex)
									{
										DemoUtils.ShowMessage( (Program.Language == 1 ? "加密失败，无法加载当前的配置信息" : "Encryption failed and the current configuration information could not be loaded ") + ex.Message );
									}
								}
								else
								{
									SaveXmlParameter( xElement );
									FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement, this );
									DemoUtils.ShowMessage( "Save Success" );
								}
							}
						}
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

		private string GetString( )
		{
			if (this.xElement == null) return string.Empty;
			return this.Text;
		}

		protected OperateResult DeviceConnectPLC( DeviceTcpNet device )
		{
			OperateResult connect = null;
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				connect = OperateResult.CreateSuccessResult( );
			}
			else
			{
				connect = device.ConnectServer( );
			}

			if (connect.IsSuccess)
			{
				// 添加到全局的通信数组中去，方便使用
				DemoDevice.AddDevice( this.FormGuid, this.GetString( ), device, this.DeviceImage );
			}
			return connect;
		}

		protected override void OnClosed( EventArgs e )
		{
			// 移除全局的设备信息
			DemoDevice.RemoveDevice( this.FormGuid );

			base.OnClosed( e );
		}

		protected OperateResult DeviceConnectPLC( TcpNetCommunication device )
		{
			OperateResult connect = null;
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				connect = OperateResult.CreateSuccessResult( );
			}
			else
			{
				connect = device.ConnectServer( );
			}

			if (connect.IsSuccess)
			{
				// 添加到全局的通信数组中去，方便使用
				DemoDevice.AddDevice( this.FormGuid, this.GetString( ), device, this.DeviceImage );
			}
			return connect;
		}

		protected OperateResult DeviceConnectPLC( DeviceSerialPort device )
		{
			OperateResult connect = null;
			if (device.CommunicationPipe.GetType( ) == typeof( PipeDtuNet ))
			{
				connect = OperateResult.CreateSuccessResult( );
			}
			else
			{
				connect = device.Open( );
			}


			if (connect.IsSuccess)
			{
				// 添加到全局的通信数组中去，方便使用
				DemoDevice.AddDevice( this.FormGuid, this.GetString( ), device, this.DeviceImage );
			}

			return connect;
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
			// 添加到全局的通信数组中去，方便使用
			DemoDevice.AddDevice( this.FormGuid, this.GetString( ), device, this.DeviceImage );
			return OperateResult.CreateSuccessResult( );
		}


		public void CheckTableDataChanged( UserControlReadWriteDevice userControlReadWriteDevice, FormClosingEventArgs e )
		{
			if (userControlReadWriteDevice.HasTableChanged( ))
			{
				if (Program.Language == 1)
				{
					if (MessageBox.Show( "当前窗口界面的点位表或模拟数据表有未保存的数据，请确认是否退出？", "关闭确认", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
				else
				{
					// 英文
					if (MessageBox.Show( "Unsaved data in the point table or simulation data table of the current window. Confirm exit?", "Exit Check", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
			}
		}

		public void CheckTableDataChanged( UserControlReadWriteServer userControlReadWriteServer, FormClosingEventArgs e )
		{
			if (userControlReadWriteServer.HasTableChanged( ))
			{
				if (Program.Language == 1)
				{
					if (MessageBox.Show( "当前窗口界面的点位表或模拟数据表有未保存的数据，请确认是否退出？", "关闭确认", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
				else
				{
					// 英文
					if (MessageBox.Show( "Unsaved data in the point table or simulation data table of the current window. Confirm exit?", "Exit Check", MessageBoxButtons.YesNo ) == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
			}
		}
	}
}
