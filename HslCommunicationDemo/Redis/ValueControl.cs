using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using HslCommunication.BasicFramework;

namespace HslRedisDesktop
{
	public partial class ValueControl : UserControl
	{
		public ValueControl( )
		{
			InitializeComponent( );
		}

		public void SetValue( string value )
		{
			this.value = value;
			ShowValue( );
		}

		private void ShowValue( )
		{
			try
			{
				int size = Encoding.UTF8.GetBytes( value ).Length;
				label2.Text = "大小: " + SoftBasic.GetSizeDescription( size );

				if (radioButton1.Checked)
				{
					textBox1.Text = value;
				}
				else if (radioButton2.Checked)
				{
					textBox1.Text = JsonConvert.DeserializeObject( value ).ToString( );
				}
				else if (radioButton3.Checked)
				{
					textBox1.Text = XElement.Parse( value ).ToString( );
				}
			}
			catch
			{
				textBox1.Text = value;
			}
		}



		private void ValueControl_Load( object sender, EventArgs e )
		{
			radioButton1.CheckedChanged += RadioButton_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton_CheckedChanged;
			radioButton3.CheckedChanged += RadioButton_CheckedChanged;
		}

		private void RadioButton_CheckedChanged( object sender, EventArgs e )
		{
			ShowValue( );
		}

		/// <summary>
		/// 获取到键的原始值，没有被修改之后的。
		/// </summary>
		/// <returns>原始值信息</returns>
		public string KeySourceValue( ) => value;

		private string value = string.Empty;


		#region Search

		int lastSeachIndex = -1;
		string searchCondition = string.Empty;
		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			// 搜索数据信息
			if (string.IsNullOrEmpty( textBox1.Text ) || string.IsNullOrEmpty( textBox2.Text ))
			{
				MessageBox.Show( "输入的字符串为空，无法进行查找。" );
				return;
			};

			if(string.IsNullOrEmpty( searchCondition ))
			{
				searchCondition = textBox2.Text;
			}
			else
			{
				if (searchCondition != textBox2.Text)
				{
					lastSeachIndex = -1;
					searchCondition = textBox2.Text;
				}
			}
			int index = textBox1.Text.IndexOf( textBox2.Text, lastSeachIndex == -1 ? 0 : lastSeachIndex );
			if (index == -1)
			{
				MessageBox.Show( "没有找到相关的数据信息。" );
				lastSeachIndex = -1;
				return;
			}

			lastSeachIndex = index + 1;

			textBox1.SelectionStart = index;
			textBox1.SelectionLength = textBox2.Text.Length;
			textBox1.ScrollToCaret( );
			textBox1.Focus( );
		}

		private void textBox2_KeyDown( object sender, KeyEventArgs e )
		{
			if(e.KeyCode == Keys.Enter)
			{
				linkLabel1_LinkClicked( null, null );

			}
		}

		#endregion

	}

}
