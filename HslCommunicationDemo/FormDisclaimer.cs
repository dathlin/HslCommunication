using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Enthernet;

namespace HslCommunicationDemo
{
    public partial class FormDisclaimer : System.Windows.Forms.Form
    {
        public FormDisclaimer( )
        {
            InitializeComponent( );
        }

        private void FormDisclaimer_Load( object sender, EventArgs e )
        {
            label1.BackColor = FormLoad.ThemeColor;
        }

        private void FormDisclaimer_Shown( object sender, EventArgs e )
        {
            System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( GetDataFromServer ), null );
        }


        private long countOld = 1;
        private Dictionary<string, long> loginData = new Dictionary<string, long>( );
        private HslCommunication.Core.SimpleHybirdLock hybirdLock = new HslCommunication.Core.SimpleHybirdLock( );

        private void AddDict( string address )
        {
            if (string.IsNullOrEmpty( address )) return;

            if (address.IndexOf( ' ' ) > 0)
            {
                address = address.Substring( 0, address.IndexOf( ' ' ) );
            }

            hybirdLock.Enter( );
            if (loginData.ContainsKey( address ))
            {
                loginData[address]++;
            }
            else
            {
                loginData.Add( address, 1 );
            }
            hybirdLock.Leave( );

            countOld++;
        }

        private void GetDataFromServer( object obj )
        {
            NetSimplifyClient simplifyClient = new HslCommunication.Enthernet.NetSimplifyClient( "118.24.36.220", 18467 );
            HslCommunication.OperateResult<HslCommunication.NetHandle, string> read = simplifyClient.ReadCustomerFromServer( 1000, HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( ) );
            if (!read.IsSuccess) return;
            System.IO.MemoryStream ms = new System.IO.MemoryStream( Encoding.Unicode.GetBytes( read.Content2 ) );
            System.IO.StreamReader sr = new System.IO.StreamReader( ms, Encoding.Unicode );

            hybirdLock.Enter( );
            loginData.Clear( );
            while (true)
            {
                string city = sr.ReadLine( );
                if (city == null) break;

                string count = sr.ReadLine( );
                loginData.Add( city, long.Parse( count ) );
            }
            sr.Close( );
            hybirdLock.Leave( );
            ms.Close( );


            List<dataMy> list = new List<dataMy>( );
            hybirdLock.Enter( );

            foreach (var m in loginData)
            {
                list.Add( new dataMy( m.Key, m.Value ) );
            }

            hybirdLock.Leave( );

            list.Sort( );
            list.Reverse( );

            // RenderDataTable( dataGridView1, list );

            // 统计省份功能
            List<dataMy> shengfen = new List<dataMy>( );
            List<dataMy> others = new List<dataMy>( );
            for (int i = 0; i < list.Count; i++)
            {
                string tmp = string.Empty;
                if (list[i].Key.IndexOf( '省' ) > 0)
                {
                    tmp = list[i].Key.Substring( 0, list[i].Key.IndexOf( '省' ) + 1 );
                }
                else if (list[i].Key.Contains( "北京市" ))
                {
                    tmp = "北京市";
                }
                else if (list[i].Key.Contains( "上海市" ))
                {
                    tmp = "上海市";
                }
                else if (list[i].Key.Contains( "天津市" ))
                {
                    tmp = "天津市";
                }
                else if (list[i].Key.Contains( "重庆市" ))
                {
                    tmp = "重庆市";
                }
                else if (list[i].Key.IndexOf( '区' ) > 0)
                {
                    tmp = list[i].Key.Substring( 0, list[i].Key.IndexOf( '区' ) + 1 );
                }
                else
                {
                    tmp = list[i].Key;
                    others.Add( new dataMy( tmp, list[i].Value ) );
                    continue;
                }

                if (string.IsNullOrEmpty( tmp )) continue;
                dataMy dataMy = shengfen.Find( m => m.Key == tmp );
                if (dataMy == null)
                {
                    shengfen.Add( new dataMy( tmp, list[i].Value ) );
                }
                else
                {
                    dataMy.Value += list[i].Value;
                }
            }

            Invoke( new Action( ( ) =>
            {
                shengfen.Sort( );
                shengfen.Reverse( );
                RenderDataTable( dataGridView1, shengfen );

                others.Sort( );
                others.Reverse( );
                RenderDataTable( dataGridView3, others );

            } ));

        }


        private long RenderDataTable( DataGridView dataGridView, List<dataMy> datas )
        {
            long count = 0;
            while (dataGridView.RowCount < datas.Count)
            {
                dataGridView.Rows.Add( );
            }

            while (dataGridView.RowCount > datas.Count)
            {
                dataGridView.Rows.RemoveAt( 0 );
            }

            // 赋值
            for (int i = 0; i < datas.Count; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = datas[i].Key;
                dataGridView.Rows[i].Cells[1].Value = datas[i].Value.ToString( );
                count += datas[i].Value;
            }

            return count;
        }

        private void dataGridView1_CellClick( object sender, DataGridViewCellEventArgs e )
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                string shengfen = dataGridView1.Rows[index].Cells[0].Value.ToString( );

                List<dataMy> list = new List<dataMy>( );
                hybirdLock.Enter( );

                foreach (var m in loginData)
                {
                    if (m.Key.Contains( shengfen ))
                    {
                        list.Add( new dataMy( m.Key, m.Value ) );
                    }
                }

                hybirdLock.Leave( );

                list.Sort( );
                list.Reverse( );
                RenderDataTable( dataGridView2, list );

            }
        }
    }



    public class dataMy : IComparable<dataMy>
    {
        public dataMy( )
        {

        }

        public dataMy( string key, long value )
        {
            Key = key;
            Value = value;
        }


        public string Key { get; set; }
        public long Value { get; set; }

        public int CompareTo( dataMy other )
        {
            return Value.CompareTo( other.Value );
        }
    }
}
