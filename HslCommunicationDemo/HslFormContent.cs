using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunicationDemo.Control;

namespace HslCommunicationDemo
{
	public class HslFormContent : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );
			AutoScroll = true;
		}


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
							FormSelect.Form.AddDeviceList( xElement );
							MessageBox.Show( "Save Success" );
						}
					}
				}
				else
				{
					SaveXmlParameter( xElement );
					FormSelect.Form.AddDeviceList( xElement );
				}
			}
			catch (Exception ex)
			{
				HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage( "Save failed:", ex );
			}
		}

		private XElement xElement = null;

	}
}
