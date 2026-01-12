using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication.MQTT;
using Newtonsoft.Json.Linq;

namespace HslCommunicationDemo.MQTT
{
	public partial class MqttTopicControl : UserControl
	{
		public MqttTopicControl( )
		{
			InitializeComponent( );
		}



		private Dictionary<string, TopicSaveItem> all_dicts = new Dictionary<string, TopicSaveItem>( );
		private TopicSaveItem selectedItem = null;

		public Func<byte[], string> GetStringFromPayload { get; set; }

		private void RenderTopicSaveItem( TopicSaveItem item )
		{
			if (item != null)
			{
				textBox_topic_topic.Text = item.Topic;
				checkBox_topic_retain.Checked = item.Message.Retain;
				textBox_topic_publishTime.Text = item.ReceiveDateTime.ToString( HslCommunicationDemo.DemoUtils.DateTimeFormate );
				if (item.Session != null)
					textBox_topic_publishSession.Text = item.Session.ToString( );
				else
					textBox_topic_publishSession.Text = string.Empty;

				string tmp = GetStringFromPayload( item.Message.Payload );
				if (radioButton_topic_render_json.Checked)
				{
					try
					{
						tmp = JObject.Parse( tmp ).ToString( );
					}
					catch
					{
					}
				}
				textBox_topic_payload.Text = tmp;

				if (item.Message.Payload != null) label_topic_size.Text = SoftBasic.GetSizeDescription( item.Message.Payload.LongLength );
				else label_topic_size.Text = "0";
			}
			else
			{
				textBox_topic_topic.Text = string.Empty;
				checkBox_topic_retain.Checked = false;
				textBox_topic_publishTime.Text = string.Empty;
				textBox_topic_publishSession.Text = string.Empty;
				textBox_topic_payload.Text = string.Empty;
				label_topic_size.Text = "0";
			}
		}

		public void RenderTopic( MqttSession session, MqttApplicationMessage message )
		{
			TopicSaveItem currentItem = GetSavedTopicItem( session, message );

			if (currentItem != null)
			{
				if (currentItem.ViewRow != null)
				{
					currentItem.RenderRow( );
				}
				else
				{
					int index = dataGridView1.Rows.Add( );
					currentItem.RenderRow( dataGridView1.Rows[index] );
				}

				if (checkBox_stop.Checked == false)
				{
					if (object.ReferenceEquals( currentItem, selectedItem ))
					{
						RenderTopicSaveItem( currentItem );
					}
				}
			}
		}

		private TopicSaveItem GetSavedTopicItem( MqttSession session, MqttApplicationMessage message )
		{
			// 如果 session 为空，则是服务器自己发布的消息
			TopicSaveItem currentItem;
			lock (all_dicts)
			{
				if (all_dicts.ContainsKey( message.Topic ))
				{
					all_dicts[message.Topic].Session = session;
					all_dicts[message.Topic].Message = message;
					all_dicts[message.Topic].ReceiveDateTime = DateTime.Now;
					all_dicts[message.Topic].Count++;
					currentItem = all_dicts[message.Topic];
				}
				else
				{
					TopicSaveItem item = new TopicSaveItem( );
					item.Topic = message.Topic;
					item.Message = message;
					item.ReceiveDateTime = DateTime.Now;
					item.Session = session;
					item.Count = 1;

					currentItem = item;
					all_dicts.Add( message.Topic, item );
				}
			}
			return currentItem;
		}

		private void dataGridView1_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (dataGridView1.SelectedRows[0].Tag is TopicSaveItem item)
				{
					RenderTopicSaveItem( item );
					selectedItem = item;
				}
			}
		}

		private void button7_Click( object sender, EventArgs e )
		{
			// 删除当前选中的主题信息
			if (selectedItem == null) return;
			if (string.IsNullOrEmpty( textBox_topic_topic.Text )) return;

			dataGridView1.Rows.Remove( selectedItem.ViewRow );
			DeleteTopicItem( selectedItem );
			selectedItem = null;
			RenderTopicSaveItem( null );
		}
		private void DeleteTopicItem( TopicSaveItem item )
		{
			lock (all_dicts)
			{
				if (all_dicts.ContainsKey( item.Topic ))
				{
					all_dicts.Remove( item.Topic );
				}
			}
		}

	}
}
