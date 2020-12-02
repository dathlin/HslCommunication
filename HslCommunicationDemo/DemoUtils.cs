using HslCommunication;
using HslCommunication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    /// <summary>
    /// DEMO程序的一些静态变量信息
    /// </summary>
    public class DemoUtils
    {
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T">类型对象</typeparam>
        /// <param name="result">读取的结果值</param>
        /// <param name="address">地址信息</param>
        /// <param name="textBox">输入的控件</param>
        public static void ReadResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
        {
            if (result.IsSuccess)
            {
                if (result.Content is Array)
                {
                    textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {HslCommunication.BasicFramework.SoftBasic.ArrayFormat(result.Content)}{Environment.NewLine}" );
                }
                else
                {
                    textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
                }
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Read Failed {Environment.NewLine}Reason：{result.ToMessageShowString( )}" );
            }
        }
        
        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result">写入的结果信息</param>
        /// <param name="address">地址信息</param>
        public static void WriteResultRender( OperateResult result, string address )
        {
            if (result.IsSuccess)
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result">写入的结果信息</param>
        /// <param name="address">地址信息</param>
        public static void WriteResultRender( OperateResult result )
        {
            if (result.IsSuccess)
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"Success" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result">写入的结果信息</param>
        /// <param name="address">地址信息</param>
        public static void WriteResultRender( Func<OperateResult> write, string address )
        {
            try
            {
                OperateResult result = write( );
                if (result.IsSuccess)
                {
                    MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
                }
                else
                {
                    MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
                }
            }
            catch(Exception ex)
            {
                // 主要是为了捕获写入的值不正确的情况
                MessageBox.Show( "Data for writting is not corrent: " + ex.Message );
            }
        }

        public static void BulkReadRenderResult( HslCommunication.Core.IReadWriteNet readWrite, TextBox addTextBox, TextBox lengthTextBox, TextBox resultTextBox )
        {
            try
            {
                OperateResult<byte[]> read = readWrite.Read( addTextBox.Text, ushort.Parse( lengthTextBox.Text ) );
                if (read.IsSuccess)
                {
                    resultTextBox.Text = "Result：" + HslCommunication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
                }
                else
                {
                    MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Read Failed：" + ex.Message );
            }
        }

        public static readonly string IpAddressInputWrong = "IpAddress input wrong";
        public static readonly string PortInputWrong = "Port input wrong";
        public static readonly string SlotInputWrong = "Slot input wrong";
        public static readonly string BaudRateInputWrong = "Baud rate input wrong";
        public static readonly string DataBitsInputWrong = "Data bit input wrong";
        public static readonly string StopBitInputWrong = "Stop bit input wrong";
    }
}
