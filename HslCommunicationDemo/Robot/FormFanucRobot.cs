using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Robot.EFORT;
using HslCommunication.Robot.FANUC;
using HslCommunication;
using HslCommunication.BasicFramework;
using System.Xml.Linq;
using System.Diagnostics;
using HslCommunicationDemo.DemoControl;

namespace HslCommunicationDemo.Robot
{
	public partial class FormFanucRobot : HslFormContent
	{
		public FormFanucRobot( )
		{
			InitializeComponent( );
		}

		private string[] encodingLists;
		private CodeExampleControl codeExampleControl;

		private void FormEfort_Load( object sender, EventArgs e )
		{
			panel2.Enabled = false;
			button2.Enabled = false;

			if(Program.Language == 2)
			{
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label2.Text = "The writing operation needs to be careful and the data needs to be checked.";
				tabPage1.Text = "General read";
				tabPage2.Text = "Professional reading and writing";
				groupBox1.Text = "Special Function Test";
			}

			comboBox1.DataSource = typeof( FanucData ).GetProperties( ).Select( m => m.Name ).ToArray( );
			this.linkLabel1.LinkClicked += LinkLabel1_LinkClicked;

			encodingLists = new string[]
			{
				nameof(Encoding.Default),
				nameof(Encoding.ASCII),
				nameof(Encoding.UTF8),
				nameof(Encoding.Unicode),
				nameof(Encoding.BigEndianUnicode),
				"GB2312",
			};
			comboBox_encoding.DataSource = encodingLists;
			comboBox_encoding.SelectedIndex = 0;

			codeExampleControl = new CodeExampleControl( );
			DemoUtils.AddSpecialFunctionTab( this.tabControl1, codeExampleControl, false, CodeExampleControl.GetTitle( ) );
		}

		private Encoding GetEncoding( )
		{
			string text = comboBox_encoding.SelectedItem != null ? comboBox_encoding.SelectedItem.ToString( ) : comboBox_encoding.Text;
			if (text == nameof( Encoding.Default )) return Encoding.Default;
			if (text == nameof( Encoding.ASCII )) return Encoding.ASCII;
			if (text == nameof( Encoding.UTF8 )) return Encoding.UTF8;
			if (text == nameof( Encoding.Unicode )) return Encoding.Unicode;
			if (text == nameof( Encoding.BigEndianUnicode )) return Encoding.BigEndianUnicode;
			return Encoding.GetEncoding( text );
		}

		private void LinkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			Process.Start( this.linkLabel1.Text );
		}

		private FanucInterfaceNet fanuc;

		private async void button1_Click( object sender, EventArgs e )
		{
			try
			{
				// 连接
				fanuc = new FanucInterfaceNet( textBox1.Text, int.Parse( textBox2.Text ) );
				fanuc.ConnectTimeOut = 2000;
				fanuc.LogNet = this.LogNet;
				fanuc.StringEncoding = GetEncoding( );


				button1.Enabled = false;
				OperateResult connect = await fanuc.ConnectServerAsync( );
				if(connect.IsSuccess)
				{
					MessageBox.Show( "连接成功" );
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;

					userControlReadWriteOp1.SetReadWriteNet( fanuc, "D1", true );

					// 设置代码示例
					codeExampleControl.SetCodeText( "robot", fanuc, nameof( fanuc.StringEncoding ) );
				}
				else
				{
					button1.Enabled = true;
					MessageBox.Show( "连接失败" );
				}
			}
			catch(Exception ex)
			{
				SoftBasic.ShowExceptionMessage( ex );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			fanuc?.ConnectClose( );
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private async void button_read_short_Click( object sender, EventArgs e )
		{
			// 刷新数据
			OperateResult<FanucData> read = await fanuc.ReadFanucDataAsync( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
			else
			{
				textBox8.Text = Newtonsoft.Json.Linq.JObject.FromObject( read.Content ).ToString( );
			}
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			OperateResult<FanucData> read = await fanuc.ReadFanucDataAsync( );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
			else
			{
				textBox8.Text = read.Content.ToString( );
			}
		}

		private void button31_Click( object sender, EventArgs e )
		{
			OperateResult<string> read = fanuc.ReadString( comboBox1.Text.ToString( ) );
			if (!read.IsSuccess)
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
			else
			{
				textBox8.Text = read.Content;
			}
		}

		private string TransBoolArrayToString(bool[] array )
		{
			return SoftBasic.ArrayFormat( array.Select( m => m ? 1 : 0 ).ToArray( ) ).Replace( ",", "" );
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			// SDO
			OperateResult<bool[]> read = await fanuc.ReadSDOAsync( 1, 100 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SDO:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// SDO2
			OperateResult<bool[]> read = await fanuc.ReadSDOAsync( 10001, 100 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SDO[1000x]:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			// SDO3
			OperateResult<bool[]> read = await fanuc.ReadSDOAsync( 11001, 100 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SDO[1100x]:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button7_Click( object sender, EventArgs e )
		{
			// SDI
			OperateResult<bool[]> read = await fanuc.ReadSDIAsync( 1, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SDI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button8_Click( object sender, EventArgs e )
		{
			// RDO
			OperateResult<bool[]> read = await fanuc.ReadRDOAsync( 1, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "RDO:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button9_Click( object sender, EventArgs e )
		{
			// RDI
			OperateResult<bool[]> read = await fanuc.ReadRDIAsync( 1, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "RDI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button10_Click( object sender, EventArgs e )
		{
			// SO
			OperateResult<bool[]> read = await fanuc.ReadSOAsync( 0, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SO:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// SI
			OperateResult<bool[]> read = await fanuc.ReadSIAsync( 0, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "SI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button12_Click( object sender, EventArgs e )
		{
			// UO
			OperateResult<bool[]> read = await fanuc.ReadUOAsync( 1, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "UO:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button13_Click( object sender, EventArgs e )
		{
			// UI
			OperateResult<bool[]> read = await fanuc.ReadUIAsync( 1, 10 );
			if (read.IsSuccess)
			{
				textBox3.Text = "UI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			// GO
			OperateResult<ushort[]> read = await fanuc.ReadGOAsync( 1, 3 );
			if (read.IsSuccess)
			{
				textBox3.Text = "GO:" + SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button15_Click( object sender, EventArgs e )
		{
			// GO2
			OperateResult<ushort[]> read = await fanuc.ReadGOAsync( 10001, 3 );
			if (read.IsSuccess)
			{
				textBox3.Text = "GO[1000x]:" + SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button16_Click( object sender, EventArgs e )
		{
			// GI
			OperateResult<ushort[]> read = await fanuc.ReadGIAsync( 1, 3 );
			if (read.IsSuccess)
			{
				textBox3.Text = "GI:" + SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button17_Click( object sender, EventArgs e )
		{
			// AO
			OperateResult<ushort[]> read = await fanuc.ReadGOAsync( 1001, 3 );
			if (read.IsSuccess)
			{
				textBox3.Text = "AO:" + SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button18_Click( object sender, EventArgs e )
		{
			// AI
			OperateResult<ushort[]> read = await fanuc.ReadGIAsync( 1001, 2 );
			if (read.IsSuccess)
			{
				textBox3.Text = "AI:" + SoftBasic.ArrayFormat( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button19_Click( object sender, EventArgs e )
		{
			// WO
			OperateResult<bool[]> read = await fanuc.ReadSDOAsync( 8001, 5 );
			if (read.IsSuccess)
			{
				textBox3.Text = "WO:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button20_Click( object sender, EventArgs e )
		{
			// WI
			OperateResult<bool[]> read = await fanuc.ReadSDIAsync( 8001, 5 );
			if (read.IsSuccess)
			{
				textBox3.Text = "WI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private async void button21_Click( object sender, EventArgs e )
		{
			// WSI
			OperateResult<bool[]> read = await fanuc.ReadSDIAsync( 8401, 1 );
			if (read.IsSuccess)
			{
				textBox3.Text = "WSI:" + TransBoolArrayToString( read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed！" + read.Message );
			}
		}

		private int w_sdo = 0;
		private async void button22_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			// SDO
			int intStartIndex = ReferenceEquals( sender, button22 ) ? 1 : ReferenceEquals( sender, button23 ) ? 10001 : 11001;
			w_sdo++;

			bool[] value = new bool[100];
			if (w_sdo % 2 == 1)
			{
				for (int i = 0; i < value.Length; i++)
				{
					value[i] = true;
				}
			}

			OperateResult write = await fanuc.WriteSDOAsync( (ushort)intStartIndex, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private int w_sdi = 0;
		private async void button25_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			w_sdi++;

			bool[] value = new bool[10];
			if (w_sdi % 2 == 1)
			{
				for (int i = 0; i < value.Length; i++)
				{
					value[i] = true;
				}
			}

			OperateResult write = await fanuc.WriteSDIAsync( 1, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private int w_rdo = 0;
		private async void button26_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			w_rdo++;

			bool[] value = new bool[8];
			if (w_rdo % 2 == 1)
			{
				for (int i = 0; i < value.Length; i++)
				{
					value[i] = true;
				}
			}

			OperateResult write = await fanuc.WriteRDOAsync( 1, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private int w_rdi = 0;
		private async void button27_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			w_rdi++;

			bool[] value = new bool[8];
			if (w_rdi % 2 == 1)
			{
				for (int i = 0; i < value.Length; i++)
				{
					value[i] = true;
				}
			}

			OperateResult write = await fanuc.WriteRDIAsync( 1, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private int w_go = 0;
		private async void button28_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			int intStartIndex = ReferenceEquals( sender, button28 ) ? 1 : 10001;
			w_go++;

			ushort[] value = new ushort[3];
			for (int i = 0; i < value.Length; i++)
			{
				value[i] = (ushort)((w_go % 3 + 1) * 11);
			}

			OperateResult write = await fanuc.WriteGOAsync( (ushort)intStartIndex, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private int w_gi = 0;
		private async void button30_Click( object sender, EventArgs e )
		{
			if (MessageBox.Show( StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.Cancel) return;

			w_gi++;

			ushort[] value = new ushort[3];
			for (int i = 0; i < value.Length; i++)
			{
				value[i] = (ushort)((w_gi % 3 + 1) * 11);
			}

			OperateResult write = await fanuc.WriteGIAsync( 1, value );
			if (write.IsSuccess)
			{
				MessageBox.Show( "Write Success！value:" + value[0] );
			}
			else
			{
				MessageBox.Show( "Write Failed！" + write.Message );
			}
		}

		private void button32_Click( object sender, EventArgs e )
		{
			try
			{
				OperateResult<byte[]> read = fanuc.Read( byte.Parse( textBox4.Text ), ushort.Parse( textBox5.Text ), ushort.Parse( textBox6.Text ) );
				if (read.IsSuccess)
				{
					textBox3.Text = "Data: " + read.Content.ToHexString( ' ' );
				}
				else
				{
					MessageBox.Show( "Write Failed！" + read.Message );
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Read Failed: " + ex.Message );
			}
		}

		public override void SaveXmlParameter( XElement element )
		{
			element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
			element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
			textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

	}
}
