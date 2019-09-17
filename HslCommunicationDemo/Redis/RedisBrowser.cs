using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Enthernet.Redis;

namespace HslCommunicationDemo.Redis
{
    public partial class RedisBrowser : HslFormContent
    {
        public RedisBrowser( )
        {
            InitializeComponent( );
        }

        private void RedisBrowser_Load( object sender, EventArgs e )
        {
            ImageList imageList = new ImageList( );
            imageList.Images.Add( "VirtualMachine", Properties.Resources.VirtualMachine );
            imageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
            imageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );             // string
            imageList.Images.Add( "brackets_Square_16xMD", Properties.Resources.brackets_Square_16xMD );   // 数组
            imageList.Images.Add( "Method_636", Properties.Resources.Method_636 );         // 哈希
            imageList.Images.Add( "Module_648", Properties.Resources.Module_648 );         // 集合
            imageList.Images.Add( "Structure_507", Properties.Resources.Structure_507 );   // 有序集合


            treeView1.ImageList = imageList;

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].ImageKey = "VirtualMachine";
                treeView1.Nodes[i].SelectedImageKey = "VirtualMachine";
            }

            panel3.Enabled = false;
            panel4.Dock = DockStyle.Fill;
            panel4.Visible = false;
            panel5.Dock = DockStyle.Fill;
            panel5.Visible = false;

            timer1s = new Timer( );
            timer1s.Interval = 800;
            timer1s.Tick += Timer1s_Tick;
            timer1s.Start( );
        }


        private RedisClient redisClient = null;
        private Timer timer1s = null;

        private void button1_Click( object sender, EventArgs e )
        {
            redisClient = new RedisClient( textBox3.Text );
            redisClient.IpAddress = textBox1.Text;
            redisClient.Port = int.Parse( textBox2.Text );
            OperateResult connect = redisClient.ConnectServer( );

            if (connect.IsSuccess)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                panel3.Enabled = true;
                MessageBox.Show( StringResources.Language.ConnectServerSuccess );
                RedisRefresh( );
            }
            else
            {
                MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            RedisRefresh( );
        }

        private void RedisRefresh( )
        {
            treeView1.Nodes[0].Nodes.Clear( );
            // 加载所有的键值信息
            OperateResult<string[]> reads = redisClient.ReadAllKeys( "*" );
            if (!reads.IsSuccess) return;

            // 填充tree
            foreach (var item in reads.Content)
            {
                AddTreeNode( treeView1.Nodes[0], item, item );
            }

            treeView1.ExpandAll( );
        }

        private void AddTreeNode(TreeNode parent, string key, string infactKey )
        {
            int index = key.IndexOf( ':' );
            if(index <= 0)
            {
                // 不存在冒号
                TreeNode node = new TreeNode( infactKey );
                node.Tag = infactKey;
                // 读取类型
                OperateResult<string> type = redisClient.ReadKeyType( infactKey );
                if(type.Content == "string")
                {
                    node.ImageKey = "Enum_582";
                    node.SelectedImageKey = "Enum_582";
                }
                else if(type.Content == "list")
                {
                    node.ImageKey = "brackets_Square_16xMD";
                    node.SelectedImageKey = "brackets_Square_16xMD";
                }
                else if(type.Content == "hash")
                {
                    node.ImageKey = "Method_636";
                    node.SelectedImageKey = "Method_636";
                }
                else if (type.Content == "set")
                {
                    node.ImageKey = "Module_648";
                    node.SelectedImageKey = "Module_648";
                }
                else if (type.Content == "zset")
                {
                    node.ImageKey = "Structure_507";
                    node.SelectedImageKey = "Structure_507";
                }

                parent.Nodes.Add( node );
            }
            else
            {

                TreeNode node = null;
                for (int i = 0; i < parent.Nodes.Count; i++)
                {
                    if(parent.Nodes[i].Text == key.Substring( 0, index ))
                    {
                        node = parent.Nodes[i];
                        break;
                    }
                }

                if (node == null)
                {
                    node = new TreeNode( key.Substring( 0, index ) );
                    node.ImageKey = "Class_489";
                    node.SelectedImageKey = "Class_489";
                    AddTreeNode( node, key.Substring( index + 1 ), infactKey );
                    parent.Nodes.Add( node );
                }
                else
                {
                    AddTreeNode( node, key.Substring( index + 1 ), infactKey );
                }
                
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            panel3.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;

            redisClient.ConnectClose( );
        }

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            // 点击了数据信息
            if (e.Node.ImageKey == "Enum_582")
            {
                panel4.Visible = true;
                panel4.BringToFront( );
                textBox4.Text = e.Node.Tag.ToString( );
                DateTime start = DateTime.Now;
                OperateResult<string> read = redisClient.ReadKey( e.Node.Tag.ToString( ) );

                label5.Text = "Time: " + (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";
                label4.Text = "Size: " + HslCommunication.BasicFramework.SoftBasic.GetSizeDescription( Encoding.UTF8.GetBytes( read.Content ).Length );
                if (read.IsSuccess)
                {
                    textBox5.Text = read.Content;


                    lastNodeSelected = e.Node.Tag.ToString( );
                    selectRowIndex = -1;
                }
                else
                {
                    MessageBox.Show( read.Message );
                }

            }
            else if (e.Node.ImageKey == "brackets_Square_16xMD")
            {
                panel5.Visible = true;
                panel5.BringToFront( );
                label7.Text = "list key:";
                textBox7.Text = string.Empty;
                dataGridView1.Rows.Clear( );
                if (e.Node.Tag.ToString( ) != lastNodeSelected) selectRowIndex = -1;
                this.Refresh( );
                textBox6.Text = e.Node.Tag.ToString( );

                
                DateTime start = DateTime.Now;
                OperateResult<string[]> read = redisClient.ListRange( e.Node.Tag.ToString( ), 0, -1 );
                if (!read.IsSuccess)
                {
                    textBox7.Text = read.Message;
                    return;
                }
                label12.Text = "Time: " + (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";

                int size = 0;
                for (int i = 0; i < read.Content.Length; i++)
                {
                    size += Encoding.UTF8.GetBytes( read.Content[i] ).Length;
                }

                label13.Text = "Size: " + HslCommunication.BasicFramework.SoftBasic.GetSizeDescription( size );
                label11.Text = "Array: " + read.Content.Length;
                if (read.IsSuccess)
                {
                    for (int i = 0; i < read.Content.Length; i++)
                    {
                        dataGridView1.Rows.Add( i, read.Content[i] );
                    }


                    lastNodeSelected = e.Node.Tag.ToString( );
                }
                else
                {
                    MessageBox.Show( read.Message );
                }
            }
            else if (e.Node.ImageKey == "Method_636")
            {
                panel5.Visible = true;
                panel5.BringToFront( );
                label7.Text = "hash key:";
                textBox7.Text = string.Empty;
                dataGridView1.Rows.Clear( );
                if (e.Node.Tag.ToString( ) != lastNodeSelected) selectRowIndex = -1;
                this.Refresh( );

                textBox6.Text = e.Node.Tag.ToString( );
                DateTime start = DateTime.Now;
                OperateResult<string[]> read = redisClient.ReadHashKeyAll( e.Node.Tag.ToString( ) );
                if (!read.IsSuccess)
                {
                    textBox7.Text = read.Message;
                    return;
                }
                label12.Text = "Time: " + (DateTime.Now - start).TotalMilliseconds.ToString( "F0" ) + " ms";

                int size = 0;
                for (int i = 0; i < read.Content.Length; i++)
                {
                    size += Encoding.UTF8.GetBytes( read.Content[i] ).Length;
                }

                label13.Text = "Size: " + HslCommunication.BasicFramework.SoftBasic.GetSizeDescription( size );
                label11.Text = "Array: " + read.Content.Length;
                if (read.IsSuccess)
                {
                    for (int i = 0; i < read.Content.Length / 2; i++)
                    {
                        dataGridView1.Rows.Add( read.Content[2 * i + 0], read.Content[2 * i + 1] );
                    }


                    lastNodeSelected = e.Node.Tag.ToString( );
                }
                else
                {
                    MessageBox.Show( read.Message );
                }
            }
            else if( e.Node.ImageKey == "Class_489")
            {

            }
            else
            {
                MessageBox.Show( "Not supported" );
            }

            treeViewSelectedNode = e.Node;
        }

        private string lastNodeSelected = string.Empty;
        private TreeNode treeViewSelectedNode = null;
        private int selectRowIndex = -1;

        private void Timer1s_Tick( object sender, EventArgs e )
        {
            if(treeViewSelectedNode != null)
            {
                if (checkBox1.Checked)
                {
                    treeView1_AfterSelect( null, new TreeViewEventArgs( treeViewSelectedNode ) );

                    if (selectRowIndex >= 0)
                    {
                        textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString( );
                        label9.Text = "Size: " + HslCommunication.BasicFramework.SoftBasic.GetSizeDescription( Encoding.UTF8.GetBytes( textBox7.Text ).Length );
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
        }

        private void panel5_SizeChanged( object sender, EventArgs e )
        {
            if (panel5.Width > 0)
            {
                dataGridView1.Columns[1].Width = panel5.Width - 175;
            }
        }

        private void dataGridView1_CellClick( object sender, DataGridViewCellEventArgs e )
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    selectRowIndex = e.RowIndex ;
                    textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString( );
                    label9.Text = "Size: " + HslCommunication.BasicFramework.SoftBasic.GetSizeDescription( Encoding.UTF8.GetBytes( textBox7.Text ).Length );
                }
            }
        }

        private void Button4_Click( object sender, EventArgs e )
        {
            // delete key
            OperateResult delete = redisClient.DeleteKey( textBox4.Text );
            if (delete.IsSuccess)
            {
                MessageBox.Show( "Delect Success!" );
            }
            else
            {
                MessageBox.Show( "Delect Failed:" + delete.Message );
            }
        }

        private void Button5_Click( object sender, EventArgs e )
        {
            OperateResult delete = redisClient.DeleteKey( textBox6.Text );
            if (delete.IsSuccess)
            {
                MessageBox.Show( "Delect Success!" );
            }
            else
            {
                MessageBox.Show( "Delect Failed:" + delete.Message );
            }
        }

        private void Button6_Click( object sender, EventArgs e )
        {
            OperateResult<DateTime> read = redisClient.ReadServerTime( );
            if (read.IsSuccess)
            {
                toolStripStatusLabel1.Text = "ServerTime: " + read.Content.ToString( "yyyy-MM-dd HH:mm:ss" );
            }
            else
            {
                MessageBox.Show( "ReadTime Failed:" + read.Message );
            }
        }
    }
}
