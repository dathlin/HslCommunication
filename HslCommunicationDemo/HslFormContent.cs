using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunicationDemo.Control;
using HslCommunication.LogNet;
using HslCommunication.BasicFramework;

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


		public virtual void LoadXmlParameter(XElement element )
		{
			xElement = element;
			Text = xElement.Attribute( DemoDeviceList.XmlName ).Value;
		}

		public virtual void SaveXmlParameter(XElement element )
		{
			throw new NotImplementedException( "SaveXmlParameter Not Implemented" );
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
							SaveXmlParameter( xElement );
							FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement );
							MessageBox.Show( "Save Success" );
						}
					}
				}
				else
				{
					SaveXmlParameter( xElement );
					FormMain.Form?.GetPanelLeft( )?.AddDeviceList( xElement );
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

	}
}
