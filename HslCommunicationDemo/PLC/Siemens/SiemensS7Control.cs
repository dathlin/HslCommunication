using HslCommunication;
using HslCommunication.Core.Pipe;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC.Siemens
{
	public class SiemensS7Control : UserControl
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button_write_dtltime;
		private System.Windows.Forms.Button button_read_dtltime;
		private System.Windows.Forms.Button button_write_Date;
		private System.Windows.Forms.Button button_read_date;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button_read_string;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_force_address;
		private System.Windows.Forms.Button button_force_clear;
		private System.Windows.Forms.Button button_force_on;
		private System.Windows.Forms.Button button_force_off;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_code;
		private TextBox textBox_code;
		private System.ComponentModel.IContainer components;

		public SiemensS7Control( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.button_force_off = new System.Windows.Forms.Button();
			this.button_force_clear = new System.Windows.Forms.Button();
			this.button_force_on = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_force_address = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button_write_dtltime = new System.Windows.Forms.Button();
			this.button_read_dtltime = new System.Windows.Forms.Button();
			this.button_write_Date = new System.Windows.Forms.Button();
			this.button_read_date = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.button14 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button_read_string = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(492, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(190, 17);
			this.label2.TabIndex = 57;
			this.label2.Text = "强制功能暂时只对 200smart 有效";
			// 
			// button_force_off
			// 
			this.button_force_off.Location = new System.Drawing.Point(783, 34);
			this.button_force_off.Name = "button_force_off";
			this.button_force_off.Size = new System.Drawing.Size(91, 28);
			this.button_force_off.TabIndex = 56;
			this.button_force_off.Text = "强制 Off";
			this.button_force_off.UseVisualStyleBackColor = true;
			this.button_force_off.Click += new System.EventHandler(this.button_force_off_Click);
			// 
			// button_force_clear
			// 
			this.button_force_clear.Location = new System.Drawing.Point(686, 68);
			this.button_force_clear.Name = "button_force_clear";
			this.button_force_clear.Size = new System.Drawing.Size(188, 28);
			this.button_force_clear.TabIndex = 55;
			this.button_force_clear.Text = "取消所有强制";
			this.button_force_clear.UseVisualStyleBackColor = true;
			this.button_force_clear.Click += new System.EventHandler(this.button_force_clear_Click);
			// 
			// button_force_on
			// 
			this.button_force_on.Location = new System.Drawing.Point(686, 34);
			this.button_force_on.Name = "button_force_on";
			this.button_force_on.Size = new System.Drawing.Size(91, 28);
			this.button_force_on.TabIndex = 54;
			this.button_force_on.Text = "强制 On";
			this.button_force_on.UseVisualStyleBackColor = true;
			this.button_force_on.Click += new System.EventHandler(this.button_force_on_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(492, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 52;
			this.label1.Text = "地址：";
			// 
			// textBox_force_address
			// 
			this.textBox_force_address.Location = new System.Drawing.Point(560, 37);
			this.textBox_force_address.Name = "textBox_force_address";
			this.textBox_force_address.Size = new System.Drawing.Size(120, 23);
			this.textBox_force_address.TabIndex = 53;
			this.textBox_force_address.Text = "Q0.0";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(267, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(82, 28);
			this.button3.TabIndex = 35;
			this.button3.Text = "订货号";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button_write_dtltime
			// 
			this.button_write_dtltime.Location = new System.Drawing.Point(388, 160);
			this.button_write_dtltime.Name = "button_write_dtltime";
			this.button_write_dtltime.Size = new System.Drawing.Size(89, 28);
			this.button_write_dtltime.TabIndex = 51;
			this.button_write_dtltime.Text = "DTL time-W";
			this.button_write_dtltime.UseVisualStyleBackColor = true;
			this.button_write_dtltime.Click += new System.EventHandler(this.button_write_dtltime_Click);
			// 
			// button_read_dtltime
			// 
			this.button_read_dtltime.Location = new System.Drawing.Point(300, 160);
			this.button_read_dtltime.Name = "button_read_dtltime";
			this.button_read_dtltime.Size = new System.Drawing.Size(82, 28);
			this.button_read_dtltime.TabIndex = 50;
			this.button_read_dtltime.Text = "DTL time-R";
			this.button_read_dtltime.UseVisualStyleBackColor = true;
			this.button_read_dtltime.Click += new System.EventHandler(this.button_read_dtltime_Click);
			// 
			// button_write_Date
			// 
			this.button_write_Date.Location = new System.Drawing.Point(388, 127);
			this.button_write_Date.Name = "button_write_Date";
			this.button_write_Date.Size = new System.Drawing.Size(89, 28);
			this.button_write_Date.TabIndex = 49;
			this.button_write_Date.Text = "日期写入";
			this.button_write_Date.UseVisualStyleBackColor = true;
			this.button_write_Date.Click += new System.EventHandler(this.button_write_Date_Click);
			// 
			// button_read_date
			// 
			this.button_read_date.Location = new System.Drawing.Point(300, 127);
			this.button_read_date.Name = "button_read_date";
			this.button_read_date.Size = new System.Drawing.Size(82, 28);
			this.button_read_date.TabIndex = 48;
			this.button_read_date.Text = "日期读取";
			this.button_read_date.UseVisualStyleBackColor = true;
			this.button_read_date.Click += new System.EventHandler(this.button_read_date_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(11, 156);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(82, 28);
			this.button12.TabIndex = 47;
			this.button12.Text = "共享测试";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(388, 94);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(89, 28);
			this.button10.TabIndex = 45;
			this.button10.Text = "WString-W";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(300, 95);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(82, 28);
			this.button11.TabIndex = 46;
			this.button11.Text = "WString-R";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(121, 162);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 17);
			this.label5.TabIndex = 44;
			this.label5.Text = "0";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(388, 63);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(89, 28);
			this.button14.TabIndex = 36;
			this.button14.Text = "字符串写入";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(388, 34);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(89, 28);
			this.button8.TabIndex = 43;
			this.button8.Text = "time写入";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button_read_string
			// 
			this.button_read_string.Location = new System.Drawing.Point(300, 64);
			this.button_read_string.Name = "button_read_string";
			this.button_read_string.Size = new System.Drawing.Size(82, 28);
			this.button_read_string.TabIndex = 37;
			this.button_read_string.Text = "字符串读取";
			this.button_read_string.UseVisualStyleBackColor = true;
			this.button_read_string.Click += new System.EventHandler(this.button_read_string_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(300, 34);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(82, 28);
			this.button7.TabIndex = 38;
			this.button7.Text = "time读取";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(3, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(82, 28);
			this.button4.TabIndex = 40;
			this.button4.Text = "热启动";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.Color.Red;
			this.label19.Location = new System.Drawing.Point(60, 93);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(147, 58);
			this.label19.TabIndex = 39;
			this.label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(179, 3);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(82, 28);
			this.button6.TabIndex = 42;
			this.button6.Text = "停止";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(91, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(82, 28);
			this.button5.TabIndex = 41;
			this.button5.Text = "冷启动";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(76, 67);
			this.textBox7.Name = "textBox7";
			this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox7.Size = new System.Drawing.Size(218, 23);
			this.textBox7.TabIndex = 34;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 17);
			this.label10.TabIndex = 31;
			this.label10.Text = "地址：";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(76, 37);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(218, 23);
			this.textBox8.TabIndex = 32;
			this.textBox8.Text = "M100";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 69);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 17);
			this.label9.TabIndex = 33;
			this.label9.Text = "值：";
			// 
			// label_code
			// 
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(8, 199);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(44, 17);
			this.label_code.TabIndex = 58;
			this.label_code.Text = "代码：";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(63, 194);
			this.textBox_code.MinimumSize = new System.Drawing.Size(500, 40);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(911, 43);
			this.textBox_code.TabIndex = 59;
			// 
			// SiemensS7Control
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.textBox_code);
			this.Controls.Add(this.label_code);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button_force_off);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button_force_clear);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button_force_on);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox_force_address);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button_write_dtltime);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button_read_dtltime);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.button_write_Date);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button_read_date);
			this.Controls.Add(this.button_read_string);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.label5);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "SiemensS7Control";
			this.Size = new System.Drawing.Size(977, 241);
			this.Load += new System.EventHandler(this.SiemensS7Control_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private SiemensS7Net siemensTcpNet;

		public void SetDevice( SiemensS7Net siemensTcpNet, string address )
		{
			this.siemensTcpNet = siemensTcpNet;
		}

		private async void button4_Click( object sender, EventArgs e )
		{
			// 热启动
			OperateResult result = await siemensTcpNet.HotStartAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.HotStart( );";
		}

		private async void button5_Click( object sender, EventArgs e )
		{
			// 冷启动
			OperateResult result = await siemensTcpNet.ColdStartAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.ColdStart( );";
		}

		private async void button6_Click( object sender, EventArgs e )
		{
			// 停止
			OperateResult result = await siemensTcpNet.StopAsync( );
			if (result.IsSuccess)
			{
				MessageBox.Show( "Success" );
			}
			else
			{
				MessageBox.Show( "Failed: " + result.Message );
			}

			textBox_code.Text = $"OperateResult result = {DemoUtils.PlcDeviceName}.Stop( );";
		}

		private async void button3_Click( object sender, EventArgs e )
		{
			// 订货号
			OperateResult<string> read = await siemensTcpNet.ReadOrderNumberAsync( );
			if (read.IsSuccess)
			{
				MessageBox.Show( "Order Number：" + read.Content );
			}
			else
			{
				MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadOrderNumber( );";
		}

		private async void button7_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadDateTime( \"{textBox8.Text}\" );";
		}

		private async void button8_Click( object sender, EventArgs e )
		{
			// time写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.Write( \"{textBox8.Text}\", DateTime.Parse( \"{textBox7.Text}\" ) );";
		}

		private async void button_read_string_Click( object sender, EventArgs e )
		{
			// 读取字符串
			OperateResult<string> read = await siemensTcpNet.ReadStringAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadString( \"{textBox8.Text}\" );";
		}

		private async void button14_Click( object sender, EventArgs e )
		{
			// string写入
			DemoUtils.WriteResultRender( await siemensTcpNet.WriteAsync( textBox8.Text, textBox7.Text ), textBox8.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.Write( \"{textBox8.Text}\", \"{textBox7.Text}\" );";
		}

		private async void button11_Click( object sender, EventArgs e )
		{
			// WString 读取
			OperateResult<string> read = await siemensTcpNet.ReadWStringAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content;
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<string> read = {DemoUtils.PlcDeviceName}.ReadWString( \"{textBox8.Text}\" );";
		}

		private async void button10_Click( object sender, EventArgs e )
		{
			// WString 写入
			DemoUtils.WriteResultRender( await siemensTcpNet.WriteWStringAsync( textBox8.Text, textBox7.Text ), textBox8.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteWString( \"{textBox8.Text}\", \"{textBox7.Text}\" );";
		}

		private async void button_read_date_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDateAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadDate( \"{textBox8.Text}\" );";
		}

		private async void button_write_Date_Click( object sender, EventArgs e )
		{
			// date写入
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteDateAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteDate( \"{textBox8.Text}\", DateTime.Parse( \"{textBox7.Text}\" ) );";
		}

		private async void button_read_dtltime_Click( object sender, EventArgs e )
		{
			OperateResult<DateTime> read = await siemensTcpNet.ReadDTLDataTimeAsync( textBox8.Text );
			if (read.IsSuccess)
			{
				textBox7.Text = read.Content.ToString( );
			}
			else
			{
				MessageBox.Show( "Failed:" + read.Message );
			}

			textBox_code.Text = $"OperateResult<DateTime> read = {DemoUtils.PlcDeviceName}.ReadDTLDataTime( \"{textBox8.Text}\" );";
		}

		private async void button_write_dtltime_Click( object sender, EventArgs e )
		{
			// DTL时间写入操作
			if (DateTime.TryParse( textBox7.Text, out DateTime value ))
				DemoUtils.WriteResultRender( await siemensTcpNet.WriteDTLTimeAsync( textBox8.Text, value ), textBox8.Text );
			else
				MessageBox.Show( "DateTime Data is not corrent: " + textBox7.Text );

			textBox_code.Text = $"OperateResult write = {DemoUtils.PlcDeviceName}.WriteDTLTime( \"{textBox8.Text}\", DateTime.Parse( \"{textBox7.Text}\" ) );";

		}

		private void label5_Click( object sender, EventArgs e )
		{

		}

		private void button_force_on_Click( object sender, EventArgs e )
		{
			OperateResult force = siemensTcpNet.ForceBool( textBox_force_address.Text, true );
			if (force.IsSuccess)
			{
				MessageBox.Show( "Force true success!" );
			}
			else
			{
				MessageBox.Show( "Force true failed:" + force.Message );
			}

			textBox_code.Text = $"OperateResult force = {DemoUtils.PlcDeviceName}.ForceBool( \"{textBox_force_address.Text}\", true );";
		}

		private void button_force_off_Click( object sender, EventArgs e )
		{
			OperateResult force = siemensTcpNet.ForceBool( textBox_force_address.Text, false );
			if (force.IsSuccess)
			{
				MessageBox.Show( "Force false success!" );
			}
			else
			{
				MessageBox.Show( "Force false failed:" + force.Message );
			}

			textBox_code.Text = $"OperateResult force = {DemoUtils.PlcDeviceName}.ForceBool( \"{textBox_force_address.Text}\", false );";
		}

		private void button_force_clear_Click( object sender, EventArgs e )
		{
			OperateResult force = siemensTcpNet.CancelAllForce( );
			if (force.IsSuccess)
			{
				MessageBox.Show( "Force true success!" );
			}
			else
			{
				MessageBox.Show( "Force true failed:" + force.Message );
			}

			textBox_code.Text = $"OperateResult force = {DemoUtils.PlcDeviceName}.CancelAllForce( );";
		}

		private PipeTcpNet pipeSocket;
		private SiemensS7Net[] siemensS = new SiemensS7Net[3];

		private int thread_status = 0;
		private int failed = 0;
		private DateTime thread_time_start = DateTime.Now;
		private long successCount = 0;
		private System.Windows.Forms.Timer timer;

		private void button12_Click( object sender, EventArgs e )
		{
			pipeSocket?.Socket?.Close( );
			pipeSocket = new PipeTcpNet( "127.0.0.1", 102 );
			siemensS[0] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[1] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[2] = new SiemensS7Net( SiemensPLCS.S1200 );
			siemensS[0].CommunicationPipe = pipeSocket;
			siemensS[1].CommunicationPipe = pipeSocket;
			siemensS[2].CommunicationPipe = pipeSocket;

			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M100" );
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M200" );
			new Thread( new ParameterizedThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( "M300" );
			button12.Enabled = false;

			timer = new System.Windows.Forms.Timer( );
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			label5.Text = successCount.ToString( );
		}

		private async void thread_test2( object add )
		{
			string address = (string)add;
			SiemensS7Net plc = address == "M100" ? siemensS[0] : address == "M200" ? siemensS[1] : siemensS[2];
			int count = 10000;
			while (count > 0)
			{
				if (!(await plc.WriteAsync( address, (short)count )).IsSuccess) failed++;
				OperateResult<short> read = await plc.ReadInt16Async( address );
				if (!read.IsSuccess) failed++;
				else
				{
					if (read.Content != count) failed++;
				}
				count--;
				successCount++;
			}
			thread_end2( );
		}

		private void thread_end2( )
		{
			if (Interlocked.Decrement( ref thread_status ) == 0)
			{
				pipeSocket?.Socket?.Close( );
				// 执行完成
				Invoke( new Action( ( ) =>
				{
					label5.Text = successCount.ToString( );
					timer.Stop( );
					button12.Enabled = true;
					MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
				} ) );
			}
		}

		private void SiemensS7Control_Load( object sender, EventArgs e )
		{
			if ( Program.Language == 2)
			{
				button_read_string.Text = "r-string";
				button7.Text = "r-time";

				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button14.Text = "w-string";
				button8.Text = "w-time";

				button3.Text = "Order";
				button4.Text = "hot-start";
				button5.Text = "cold-start";
				button6.Text = "stop";

				button_read_date.Text = "r-date";
				button_write_Date.Text = "w-date";

				label1.Text = "Address:";
				button_force_on.Text = "Force On";

				label2.Text = "The enforcement feature is currently only valid for 200smart";
				label_code.Text = "Code:";
			}

			//toolTip1.SetToolTip( button7, "plc.ReadDateTime( string address )" );
			//toolTip1.SetToolTip( button8, "plc.Write( string address, DateTime dateTime )" );
			//toolTip1.SetToolTip( button_read_string, "plc.ReadString( string address )" );
			//toolTip1.SetToolTip( button14, "plc.Write( string address, string value )" );
			//toolTip1.SetToolTip( button11, "plc.ReadWString( string address )" );
			//toolTip1.SetToolTip( button10, "plc.WriteWString( string address, string value )" );
			//toolTip1.SetToolTip( button_read_date, "plc.ReadDate( string address )" );
			//toolTip1.SetToolTip( button_write_Date, "plc.WriteDate( string address, DateTime dateTime )" );
			//toolTip1.SetToolTip( button_read_dtltime, "plc.ReadDTLDataTime( string address )" );
			//toolTip1.SetToolTip( button_write_dtltime, "plc.WriteDTLTime( string address, DateTime dateTime )" );

			//toolTip1.SetToolTip( button_force_on, "plc.ForceBool( string address, true )" );
			//toolTip1.SetToolTip( button_force_off, "plc.ForceBool( string address, false )" );
			//toolTip1.SetToolTip( button_force_clear, "plc.CancelAllForce( );" );
			//toolTip1.SetToolTip( button4, "plc.HotStart( )" );
			//toolTip1.SetToolTip( button5, "plc.ColdStart( )" );
			//toolTip1.SetToolTip( button6, "plc.Stop( )" );
			//toolTip1.SetToolTip( button3, "plc.ReadOrderNumber( )" );
		}

	}
}
