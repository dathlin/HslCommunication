using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HslCommunication.BasicFramework;

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormRegexTest : HslFormContent
	{
		public FormRegexTest( )
		{
			InitializeComponent( );
		}

		private void FormRegexTest_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = SoftBasic.GetEnumValues<RegexOptions>( );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// 正则匹配
			if (string.IsNullOrEmpty( textBox_input.Text ))
			{
				MessageBox.Show( "Please input string" );
				return;
			}

			MatchCollection matches = Regex.Matches( textBox_input.Text, textBox_patter.Text, (RegexOptions)comboBox1.SelectedItem );
			StringBuilder sb = new StringBuilder( );
			sb.Append( "Result Count: " );
			sb.Append( matches.Count );
			sb.AppendLine( );

			for (int i = 0; i < matches.Count; i++)
			{
				sb.Append( "Result[" + i + "]: =============================================================" );
				sb.AppendLine( );
				sb.Append( matches[i].Value );
				sb.AppendLine( );
				sb.AppendLine( );
			}

			textBox_result.Text = sb.ToString( );

			textBox_code.Text = $"MatchCollection matches = System.Text.RegularExpressions.Regex.Matches( \"{textBox_input.Text}\", \"{textBox_patter.Text}\", RegexOptions.{comboBox1.SelectedItem} );";
		}

		private void button2_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"[\u4e00-\u9fa5]";
		}

		private void button3_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?";
		}

		private void button4_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$";
		}

		private void button5_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"((2(5[0-5]|[0-4]\d))|[0-1]?\d{1,2})(\.((2(5[0-5]|[0-4]\d))|[0-1]?\d{1,2})){3}";
		}

		private void button6_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"<(\S*?)[^>]*>.*?|<.*? />";
		}

		private void button7_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"^(13[0-9]|14[5|7]|15[0|1|2|3|4|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";
		}

		private void button8_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"^\d{4}-\d{1,2}-\d{1,2}";
		}

		private void button9_Click( object sender, EventArgs e )
		{
			textBox_patter.Text = @"^[A-Za-z0-9]+$ 或 ^[A-Za-z0-9]{4,40}$";
		}
	}
}
