using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Database
{
	public partial class FormLocalFile : HslFormContent
	{
		public FormLocalFile( )
		{
			InitializeComponent( );

			this.dataForwardControl1.onDataPublished += ForwardControl_onDataPublished;
			renderAction = new Action<string>( DealWithString );

			this.dataForwardControl1.OnStart = this.Start;
			this.dataForwardControl1.OnStop = this.Stop;

			this.textBox2.Text = DateTime.Now.AddHours( 1 ).ToString( "yyyy-MM-dd HH:mm:ss" );
		}

		private void FormLocalFile_Load( object sender, EventArgs e )
		{
			this.Text = "LocalFile[Txt]";
			this.dataForwardControl1.SetSqlMode( );
			panel2.Enabled = false;
		}

		private long runCount = 0;
		private DateTime dateTimeFinish = DateTime.Now;
		private string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
		private string stringFormat = string.Empty;
		private Action<string> renderAction = null;
		private Dictionary<string, object> lastValues = new Dictionary<string, object>( );
		private string filePath = string.Empty;

		private string RegexReplaceMode1( Match match )
		{
			string value = match.Value.Substring( 1, match.Value.Length - 2 );
			if (value == "@DateTime")
			{
				return "DateTime";
			}

			return value;
		}

		private string RegexReplaceMode2( Match match )
		{
			if (lastValues == null) return match.Value;

			string name = match.Value.Substring( 1, match.Value.Length - 2 );
			if (name == "@DateTime")
			{
				return DateTime.Now.ToString( dateTimeFormat );
			}
			if (lastValues.ContainsKey( name ))
			{
				return Convert.ToString( lastValues[name] );
			}
			return match.Value;
		}


		private void DealWithString( string str )
		{
			textBox5.AppendText( str + Environment.NewLine );
		}

		private void ForwardControl_onDataPublished( object sender, Dictionary<string, object> dict )
		{
			runCount++;

			if (runCount == 1)
			{
				// 第一次执行
				stringFormat = textBox_format.Text;
				if (radioButton1.Checked)
				{
					int seconds = Convert.ToInt32( textBox1.Text );
					dateTimeFinish = DateTime.Now.AddSeconds( seconds );
				}
				else
				{
					dateTimeFinish = DateTime.Parse( textBox2.Text );
				}

				if (!string.IsNullOrEmpty( textBox3.Text ))
				{
					dateTimeFormat = textBox3.Text;
				}

				if (checkBox1.Checked)
				{
					// 先写入列名
					string head = Regex.Replace( stringFormat, @"{[^}]+}", new MatchEvaluator( RegexReplaceMode1 ) );
					Invoke( renderAction, head );
					WriteFile( head );
				}
			}

			lastValues = dict;
			string result = Regex.Replace( stringFormat, @"{[^}]+}", new MatchEvaluator( RegexReplaceMode2 ) );
			Invoke( renderAction, result );
			WriteFile( result );
		}

		private void WriteFile( string content )
		{
			try
			{
				if (string.IsNullOrEmpty( filePath )) return;
				using (StreamWriter sw = new StreamWriter( filePath, true, Encoding.UTF8 ))
				{
					content = content.Replace( "\\t", "\t" );
					sw.Write( content );
					if (radioButton3.Checked)
					{
						sw.Write( "\r\n" );
					}
					else if (radioButton4.Checked)
					{
						sw.Write( "\n" );
					}
					else
					{
						sw.Write( textBox6.Text );
					}
				}
			}
			catch(Exception ex)
			{
				Invoke( renderAction, "Write file exception：" + ex.Message );
			}
		}

		public void Start( )
		{
			label6.Text = "运行中";
			label6.BackColor = Color.LimeGreen;
		}

		public void Stop( )
		{
			label6.Text = "未运行";
			label6.BackColor = Color.FromArgb( 224, 224, 224 );
			runCount = 0;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 开始
			if (!string.IsNullOrEmpty(textBox_file.Text))
			{
				if (File.Exists(textBox_file.Text))
				{
					checkBox1.Checked = false;
				}
				else
				{
					checkBox1.Checked = true;
				}
			}

			this.filePath = textBox_file.Text;
			button1.Enabled = false;
			button2.Enabled = true;
			panel2.Enabled = true;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.dataForwardControl1.ActionWhenClosing( );
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
		}



		public override void SaveXmlParameter( XElement element )
		{
			this.dataForwardControl1.SaveToXml( element );
			element.SetAttributeValue( "FilePath", textBox_file.Text );
			int recordMode = radioButton1.Checked ? 0 : 1;
			element.SetAttributeValue( "RecordMode", recordMode );
			element.SetAttributeValue( "Seconds", textBox1.Text );
			element.SetAttributeValue( "FinishTime", textBox2.Text );
			element.SetAttributeValue( "TimeFormat", textBox3.Text );
			int appendMode = radioButton3.Checked ? 0 : (radioButton4.Checked ? 1 : 2);
			element.SetAttributeValue( "AppendMode", appendMode );
			element.SetAttributeValue( "CustomAppend", textBox6.Text );
			element.SetAttributeValue( "SaveFormat", textBox_format.Text );
		}

		public override void LoadXmlParameter( XElement element )
		{
			base.LoadXmlParameter( element );
			this.dataForwardControl1.LoadFromXml( element );
			textBox_file.Text = GetXmlValue( element, "FilePath", string.Empty, m => m );
			int recordMode = GetXmlValue( element, "RecordMode", 0, m => Convert.ToInt32( m ) );
			if (recordMode == 0)
			{
				radioButton1.Checked = true;
			}
			else
			{
				radioButton2.Checked = true;
			}
			textBox1.Text = GetXmlValue( element, "Seconds", "60", m => m );
			textBox2.Text = GetXmlValue( element, "FinishTime", DateTime.Now.AddHours( 1 ).ToString( "yyyy-MM-dd HH:mm:ss" ), m => m );
			textBox3.Text = GetXmlValue( element, "TimeFormat", "yyyy-MM-dd HH:mm:ss.fff", m => m );
			int appendMode = GetXmlValue( element, "AppendMode", 0, m => Convert.ToInt32( m ) );
			if (appendMode == 0)
			{
				radioButton3.Checked = true;
			}
			else if (appendMode == 1)
			{
				radioButton4.Checked = true;
			}
			else
			{
				radioButton5.Checked = true;
			}
			textBox6.Text = GetXmlValue( element, "CustomAppend", ",", m => m );
			textBox_format.Text = GetXmlValue( element, "SaveFormat", "{@DateTime},{A},{B}", m => m );
		}

		private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
		{
			userControlHead1_SaveConnectEvent( sender, e );
		}

		private void FormLocalFile_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (button1.Enabled == false) button2_Click( null, EventArgs.Empty );
		}
	}
}
