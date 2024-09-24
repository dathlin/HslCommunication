using HslCommunication;
using HslCommunication.ModBus;
using HslCommunicationDemo.PLC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.Modbus
{
	public class ModbusControl : UserControl
	{
		private System.Windows.Forms.Button button_Readwrite;
		private System.Windows.Forms.TextBox textBox_write_value;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_write_address;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_read_length;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_read_address;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_read_result;
		private TextBox textBox_code;
		private Label label_code;
		private System.Windows.Forms.GroupBox groupBox1;

		public ModbusControl( )
		{
			InitializeComponent( );
		}

		private void InitializeComponent( )
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox_read_result = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button_Readwrite = new System.Windows.Forms.Button();
			this.textBox_write_value = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_write_address = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_read_length = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_read_address = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label_code = new System.Windows.Forms.Label();
			this.textBox_code = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox_code);
			this.groupBox1.Controls.Add(this.label_code);
			this.groupBox1.Controls.Add(this.textBox_read_result);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.button_Readwrite);
			this.groupBox1.Controls.Add(this.textBox_write_value);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox_write_address);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox_read_length);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox_read_address);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(808, 259);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "0x17 Function Test";
			// 
			// textBox_read_result
			// 
			this.textBox_read_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_read_result.Location = new System.Drawing.Point(118, 85);
			this.textBox_read_result.Multiline = true;
			this.textBox_read_result.Name = "textBox_read_result";
			this.textBox_read_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_read_result.Size = new System.Drawing.Size(684, 128);
			this.textBox_read_result.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Read Result:";
			// 
			// button_Readwrite
			// 
			this.button_Readwrite.Location = new System.Drawing.Point(460, 21);
			this.button_Readwrite.Name = "button_Readwrite";
			this.button_Readwrite.Size = new System.Drawing.Size(154, 27);
			this.button_Readwrite.TabIndex = 8;
			this.button_Readwrite.Text = "Read And Write";
			this.button_Readwrite.UseVisualStyleBackColor = true;
			this.button_Readwrite.Click += new System.EventHandler(this.button_Readwrite_Click);
			// 
			// textBox_write_value
			// 
			this.textBox_write_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_write_value.Location = new System.Drawing.Point(346, 53);
			this.textBox_write_value.Name = "textBox_write_value";
			this.textBox_write_value.Size = new System.Drawing.Size(456, 23);
			this.textBox_write_value.TabIndex = 7;
			this.textBox_write_value.Text = "12 34 56 78";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(256, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Hex Value:";
			// 
			// textBox_write_address
			// 
			this.textBox_write_address.Location = new System.Drawing.Point(118, 54);
			this.textBox_write_address.Name = "textBox_write_address";
			this.textBox_write_address.Size = new System.Drawing.Size(132, 23);
			this.textBox_write_address.TabIndex = 5;
			this.textBox_write_address.Text = "100";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Write Address:";
			// 
			// textBox_read_length
			// 
			this.textBox_read_length.Location = new System.Drawing.Point(346, 22);
			this.textBox_read_length.Name = "textBox_read_length";
			this.textBox_read_length.Size = new System.Drawing.Size(92, 23);
			this.textBox_read_length.TabIndex = 3;
			this.textBox_read_length.Text = "10";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Read Length:";
			// 
			// textBox_read_address
			// 
			this.textBox_read_address.Location = new System.Drawing.Point(118, 23);
			this.textBox_read_address.Name = "textBox_read_address";
			this.textBox_read_address.Size = new System.Drawing.Size(132, 23);
			this.textBox_read_address.TabIndex = 1;
			this.textBox_read_address.Text = "100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Read Address:";
			// 
			// label_code
			// 
			this.label_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_code.AutoSize = true;
			this.label_code.Location = new System.Drawing.Point(10, 221);
			this.label_code.Name = "label_code";
			this.label_code.Size = new System.Drawing.Size(42, 17);
			this.label_code.TabIndex = 11;
			this.label_code.Text = "Code:";
			// 
			// textBox_code
			// 
			this.textBox_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_code.Location = new System.Drawing.Point(118, 218);
			this.textBox_code.Multiline = true;
			this.textBox_code.Name = "textBox_code";
			this.textBox_code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_code.Size = new System.Drawing.Size(684, 37);
			this.textBox_code.TabIndex = 12;
			// 
			// ModbusControl
			// 
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Name = "ModbusControl";
			this.Size = new System.Drawing.Size(814, 265);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		private IModbus modbus;

		public void SetDevice( IModbus modbus, string address )
		{
			this.modbus = modbus;
		}

		private void button_Readwrite_Click( object sender, EventArgs e )
		{
			if (!ushort.TryParse(textBox_read_length.Text, out ushort length ))
			{
				MessageBox.Show( "Read length input wrong, need input number, example: 10" );
				return;
			}

			OperateResult<byte[]> read = modbus.ReadWrite( textBox_read_address.Text, length, textBox_write_address.Text, textBox_write_value.Text.ToHexBytes( ) );
			if (read.IsSuccess)
			{
				textBox_read_result.Text = DateTime.Now.ToString( ) + Environment.NewLine + read.Content.ToHexString( ' ' );
			}
			else
			{
				MessageBox.Show( "Read failed: " + read.Message );
			}

			textBox_code.Text = $"OperateResult<byte[]> read = {DemoUtils.ModbusDeviceName}." +
				$"ReadWrite( \"{textBox_read_address.Text}\", {length}, \"{textBox_write_address.Text}\", \"{textBox_write_value.Text}\".ToHexBytes( ) );";
		}
	}
}
