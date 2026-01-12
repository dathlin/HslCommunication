using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core.Device;
using HslCommunication.MQTT;
using HslCommunication.WebSocket;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo.DemoControl
{
	public partial class DataForwardControl : UserControl
	{
		public DataForwardControl( )
		{
			InitializeComponent( );
		}

		private void button_device_add_Click( object sender, EventArgs e )
		{
			// 新增注册设备
			using (FormRunDeviceAndDataSelect form = new FormRunDeviceAndDataSelect( ))
			{
				if (form.ShowDialog( ) == DialogResult.OK)
				{
					DemoDeviceItem demoDevice = form.SelectedDevice;
					DemoDeviceAddressItem addressItem = form.DeviceAddressItem;
					if (string.IsNullOrEmpty( addressItem.Name ))
					{
						addressItem.Name = addressItem.Address;
					}
					DataForwardItem forwardItem = new DataForwardItem( )
					{
						Device = demoDevice,
						AddressItem = addressItem,
					};

					int index = dataGridView1.Rows.Add( );

					dataGridView1.Rows[index].Cells[0].Value = addressItem.Name;
					dataGridView1.Rows[index].Cells[1].Value = demoDevice.DeviceImage;
					dataGridView1.Rows[index].Cells[2].Value = demoDevice.Device.ToString( );
					dataGridView1.Rows[index].Cells[3].Value = addressItem.Address;
					dataGridView1.Rows[index].Cells[4].Value = addressItem.DataType;
					dataGridView1.Rows[index].Cells[5].Value = addressItem.Length;
					dataGridView1.Rows[index].Tag = forwardItem;

					label_rowcount.Text = "RowCount: " + dataGridView1.Rows.Count;
				}
			}
		}

		private void button_device_remove_Click( object sender, EventArgs e )
		{
			// 删除注册设备
			if (dataGridView1.SelectedRows.Count > 0)
			{
				var device = dataGridView1.SelectedRows[0].Tag as DataForwardItem;
				if (device != null)
				{
					dataGridView1.Rows.RemoveAt( dataGridView1.SelectedRows[0].Index );


					label_rowcount.Text = "RowCount: " + dataGridView1.Rows.Count;
				}
			}
		}

		public void SetMqttServer( MqttServer server )
		{
			mqttServer = server;
		}

		public void SetMqttClient( MqttClient client )
		{
			mqttClient = client;
		}

		public void SetWebSocketServer( WebSocketServer server, Action<string, string, WebSocketSession> addTopic )
		{
			webSocketServer = server;
			addWebSocketTopic = addTopic;
		}

		public static string GetTitle()
		{
			if (Program.Language == 2)
				return "Data Forward";
			else
				return "数据转发";
		}

		private int timer_tick = 1000;
		private System.Threading.Thread thread = null;
		private MqttServer mqttServer;
		private MqttClient mqttClient;
		private WebSocketServer webSocketServer;
		private Action<string, string, WebSocketSession> addWebSocketTopic;


		private string mqttTopic = "A";
		private bool useOneTopic = false;
		private bool thread_running = false;
		private long run_count = 0;

		private void button_start_Click( object sender, EventArgs e )
		{
			// 开始
			if (!int.TryParse( textBox_interval.Text, out timer_tick ))
			{
				MessageBox.Show( "Timer tick input error!" );
				return;
			}

			if (checkBox_use_one_topic.Checked)
			{
				if (string.IsNullOrEmpty( textBox_topic.Text ))
				{
					MessageBox.Show( "MQTT topic can not be null!" );
					return;
				}
			}

			mqttTopic = textBox_topic.Text;
			useOneTopic = checkBox_use_one_topic.Checked;

			run_count = 0;
			thread_running = true;
			thread?.Abort( );
			thread = new System.Threading.Thread( new System.Threading.ThreadStart( ThreadReadData ) );
			thread.IsBackground = true;
			thread.Start( );

			button_start.Enabled = false;
			button_stop.Enabled = true;
		}

		private void button_stop_Click( object sender, EventArgs e )
		{
			// 停止
			thread_running = false;
			thread?.Abort( );
			button_start.Enabled = true;
			button_stop.Enabled = false;
		}

		public void PublishMessageHelper(string topic, string content)
		{
			if (mqttServer != null)
			{
				mqttServer.PublishTopicPayload( topic, Encoding.UTF8.GetBytes( content ) );
			}

			if (mqttClient != null)
			{
				mqttClient.PublishMessage( new MqttApplicationMessage( )
				{
					Topic = topic,
					Payload = Encoding.UTF8.GetBytes( content ),
					QualityOfServiceLevel = HslCommunication.MQTT.MqttQualityOfServiceLevel.AtMostOnce,
					Retain = false
				});
			}

			if (webSocketServer != null)
			{
				webSocketServer.PublishClientPayload( topic, content );
				addWebSocketTopic?.Invoke( topic, content, null );
			}
		}

		private void ReadDataHelpler<T>( DeviceCommunication deviceCommunication, DataGridViewRow row, DataForwardItem item, Func<string, OperateResult<T>> read1, Func<string, ushort, OperateResult<T[]>> read2, JObject json )
		{
			DemoDeviceAddressItem addressItem = item.AddressItem;

			if (addressItem.Length <= 0)
			{
				if (read1 == null)
				{
					OperateResult<T[]> read = read2( addressItem.Address, 1 );
					if (read.IsSuccess && read.Content.Length > 0)
					{
						row.Cells[6].Value = read.Content[0];
						if (useOneTopic)
						{
							if (json != null)
							{
								json[addressItem.GetTopic( )] = new JValue( read.Content[0] );
							}
						}
						else
						{
							PublishMessageHelper( item.AddressItem.GetTopic( ), read.Content[0].ToString( ) );
						}
					}
					else
					{
						row.Cells[6].Value = "Err: " + read.Message;
					}
				}
				else
				{
					OperateResult<T> read = read1( addressItem.Address );
					if (read.IsSuccess)
					{
						row.Cells[6].Value = read.Content;
						if (useOneTopic)
						{
							if (json != null)
							{
								json[addressItem.GetTopic( )] = new JValue( read.Content );
							}
						}
						else
						{
							PublishMessageHelper( item.AddressItem.GetTopic( ), read.Content.ToString( ) );
						}
					}
					else
					{
						row.Cells[6].Value = "Err: " + read.Message;
					}
				}
			}
			else
			{
				OperateResult<T[]> read = read2( addressItem.Address, (ushort)addressItem.Length );
				if (read.IsSuccess)
				{
					row.Cells[6].Value = "[" + string.Join( ", ", read.Content ) + "]";
					if (useOneTopic)
					{
						if (json != null)
						{
							json[addressItem.GetTopic( )] = JArray.FromObject( read.Content );
						}
					}
					else
					{
						PublishMessageHelper( item.AddressItem.GetTopic( ), JArray.FromObject( read.Content ).ToString( ) );
					}
				}
				else
				{
					row.Cells[6].Value = "Err: " + read.Message;
				}
			}
		}

		private void ReadStringHelper( DeviceCommunication deviceCommunication, DataGridViewRow row, DataForwardItem item, JObject json )
		{
			DemoDeviceAddressItem addressItem = item.AddressItem;
			Encoding encoding = Encoding.ASCII;
			if (addressItem.DataType.Equals( "string_unicode", StringComparison.OrdinalIgnoreCase ))
				encoding = Encoding.Unicode;
			else if (addressItem.DataType.Equals( "string_gb2312", StringComparison.OrdinalIgnoreCase ))
				encoding = Encoding.GetEncoding( "gb2312" );
			else if (addressItem.DataType.Equals( "string_utf8", StringComparison.OrdinalIgnoreCase ))
				encoding = Encoding.UTF8;

			OperateResult<string> read = deviceCommunication.ReadString( addressItem.Address, (ushort)addressItem.Length, encoding );
			if (read.IsSuccess)
			{
				row.Cells[6].Value = read.Content;
				if (useOneTopic)
				{
					if (json != null)
					{
						json[addressItem.GetTopic( )] = new JValue( read.Content );
					}
				}
				else
				{
					PublishMessageHelper( item.AddressItem.GetTopic( ), read.Content );
				}
			}
			else
			{
				row.Cells[6].Value = "Err: " + read.Message;
			}
		}

		private void ThreadReadData( )
		{
			while (thread_running)
			{
				useOneTopic = checkBox_use_one_topic.Checked;

				try
				{
					JObject json = new JObject( );
					DateTime start = DateTime.Now;
					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						var item = dataGridView1.Rows[i].Tag as DataForwardItem;
						if (item != null)
						{
							if (item.Device.Device is DeviceCommunication deviceCommunication)
							{
								DemoDeviceAddressItem addressItem = item.AddressItem;
								if (addressItem.DataType.Equals( "short", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadInt16, deviceCommunication.ReadInt16, json );
								}
								else if (addressItem.DataType.Equals( "ushort", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadUInt16, deviceCommunication.ReadUInt16, json );
								}
								else if (addressItem.DataType.Equals( "int", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadInt32, deviceCommunication.ReadInt32, json );
								}
								else if (addressItem.DataType.Equals( "uint", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadUInt32, deviceCommunication.ReadUInt32, json );
								}
								else if (addressItem.DataType.Equals( "long", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadInt64, deviceCommunication.ReadInt64, json );
								}
								else if (addressItem.DataType.Equals( "ulong", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadUInt64, deviceCommunication.ReadUInt64, json );
								}
								else if (addressItem.DataType.Equals( "float", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadFloat, deviceCommunication.ReadFloat, json );
								}
								else if (addressItem.DataType.Equals( "double", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadDouble, deviceCommunication.ReadDouble, json );
								}
								else if (addressItem.DataType.Equals( "bool", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, deviceCommunication.ReadBool, deviceCommunication.ReadBool, json );
								}
								else if (addressItem.DataType.Equals( "byte", StringComparison.OrdinalIgnoreCase ))
								{
									ReadDataHelpler( deviceCommunication, dataGridView1.Rows[i], item, null, deviceCommunication.Read, json );
								}
								else if (addressItem.DataType.Equals( "string_ascii", StringComparison.OrdinalIgnoreCase ))
								{
									ReadStringHelper( deviceCommunication, dataGridView1.Rows[i], item, json );
								}
								else if (addressItem.DataType.Equals( "string_unicode", StringComparison.OrdinalIgnoreCase ))
								{
									ReadStringHelper( deviceCommunication, dataGridView1.Rows[i], item, json );
								}
								else if (addressItem.DataType.Equals( "string_gb2312", StringComparison.OrdinalIgnoreCase ))
								{
									ReadStringHelper( deviceCommunication, dataGridView1.Rows[i], item, json );
								}
								else if (addressItem.DataType.Equals( "string_utf8", StringComparison.OrdinalIgnoreCase ))
								{
									ReadStringHelper( deviceCommunication, dataGridView1.Rows[i], item, json );
								}
								else
								{
									dataGridView1.Rows[i].Cells[6].Value = "Unsupported Type";
								}
							}
						}
					}

					if (useOneTopic)
					{
						PublishMessageHelper( mqttTopic, json.ToString( ) );
					}

					System.Threading.Interlocked.Increment( ref run_count );

					Invoke( new Action( ( ) =>
					{
						label_timecost.Text = "TimeCost: " + (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
						label_run_count.Text = "RunCount: " + run_count.ToString( );
					} ) );
				}
				catch
				{

				}
				System.Threading.Thread.Sleep( timer_tick );
			}
		}

		private void DataForwardControl_SizeChanged( object sender, EventArgs e )
		{
			if (dataGridView1.Size.Width > 900)
			{
				dataGridView1.Columns[6].Width = dataGridView1.Size.Width - 820;
			}

			if (this.Width > 800)
			{
				button_device_add.Location = new Point( this.Width / 2 - 115, button_device_add.Location.Y );
				button_device_remove.Location = new Point( this.Width / 2 + 5, button_device_remove.Location.Y );
			}
		}

		public void SaveToXml( System.Xml.Linq.XElement xmlParent )
		{
			XElement xml = new XElement( "DataForward" );
			xml.SetAttributeValue( "Interval", timer_tick.ToString( ) );
			xml.SetAttributeValue( "UseOneTopic", useOneTopic.ToString( ) );
			xml.SetAttributeValue( "MqttTopic", textBox_topic.Text );
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				var item = dataGridView1.Rows[i].Tag as DataForwardItem;
				if (item != null)
				{
					System.Xml.Linq.XElement device = new XElement( "Device" );
					device.SetAttributeValue( "Name", item.AddressItem.Name );
					device.SetAttributeValue( "Address", item.AddressItem.Address );
					device.SetAttributeValue( "DataType", item.AddressItem.DataType );
					device.SetAttributeValue( "Length", item.AddressItem.Length.ToString( ) );
					xml.Add( device );
				}
			}

			xmlParent.Add( xml );
		}

		public void LoadFromXml( System.Xml.Linq.XElement xmlParent )
		{
			XElement xml = xmlParent.Element( "DataForward" );
			if (xml != null)
			{
				timer_tick            = HslFormContent.GetXmlValue( xml, "Interval", 1000, int.Parse );
				textBox_interval.Text = timer_tick.ToString( );

				useOneTopic = HslFormContent.GetXmlValue( xml, "UseOneTopic", false, bool.Parse );
				checkBox_use_one_topic.Checked = useOneTopic;

				mqttTopic = HslFormContent.GetXmlValue( xml, "MqttTopic", "A", m => m );
				textBox_topic.Text = mqttTopic;

				var devices = xml.Elements( "Device" );
				foreach (var device in devices)
				{
					DemoDeviceAddressItem addressItem = new DemoDeviceAddressItem( )
					{
						Name = device.Attribute( "Name" ).Value,
						Address = device.Attribute( "Address" ).Value,
						DataType = device.Attribute( "DataType" ).Value,
						Length = int.Parse( device.Attribute( "Length" ).Value ),
					};

					DataForwardItem forwardItem = new DataForwardItem( )
					{
						Device = null,
						AddressItem = addressItem,
					};
					int index = dataGridView1.Rows.Add( );
					dataGridView1.Rows[index].Cells[0].Value = addressItem.Name;
					dataGridView1.Rows[index].Cells[1].Value = null;
					dataGridView1.Rows[index].Cells[2].Value = "";
					dataGridView1.Rows[index].Cells[3].Value = addressItem.Address;
					dataGridView1.Rows[index].Cells[4].Value = addressItem.DataType;
					dataGridView1.Rows[index].Cells[5].Value = addressItem.Length;
					dataGridView1.Rows[index].Tag = forwardItem;
				}

				label_rowcount.Text = "RowCount: " + dataGridView1.Rows.Count;
			}
		}

		private void button_device_set_Click( object sender, EventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				using (FormRunDeviceSelect form = new FormRunDeviceSelect( ))
				{
					if (form.ShowDialog( ) == DialogResult.OK)
					{
						for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
						{
							var item = dataGridView1.SelectedRows[i].Tag as DataForwardItem;
							if (item != null)
							{
								DemoDeviceItem demoDevice = form.SelectedDevice;
								item.Device = demoDevice;

								dataGridView1.SelectedRows[i].Cells[1].Value = demoDevice.DeviceImage;
								dataGridView1.SelectedRows[i].Cells[2].Value = demoDevice.Device.ToString( );
							}
						}
					}
				}
			}
		}

		private void DataForwardControl_Load( object sender, EventArgs e )
		{
			if (Program.Language == 2)
			{
				label1.Text = "Interval:";
				checkBox_use_one_topic.Text = "Use One Topic";
				button_device_add.Text = "Add Data";
				button_device_remove.Text = "Remove";
				button_device_set.Text = "Set Device";
				button_start.Text = "Start";
				button_stop.Text = "Stop";
				label25.Text = "Topic List:";
			}
		}
	}

	public class DataForwardItem
	{
		public DemoDeviceItem Device { get; set; }

		public DemoDeviceAddressItem AddressItem { get; set; }
	}
}
