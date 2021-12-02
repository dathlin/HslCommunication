using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Profinet.AllenBradley;

namespace HslCommunicationDemo
{
    public partial class FormAllenBrandlyBrowser : HslFormContent
    {
        public FormAllenBrandlyBrowser( )
        {
            InitializeComponent( );
        }

        private void RedisBrowser_Load( object sender, EventArgs e )
        {
            ImageList imageList = new ImageList( );
            imageList.Images.Add( "VirtualMachine",               Properties.Resources.VirtualMachine );
            imageList.Images.Add( "Class_489",                    Properties.Resources.Class_489 );               // 结构体
            imageList.Images.Add( "Enum_582",                     Properties.Resources.Enum_582 );                // 标量数据
            imageList.Images.Add( "brackets_Square_16xMD",        Properties.Resources.brackets_Square_16xMD );   // 数组
            imageList.Images.Add( "Method_636",                   Properties.Resources.Method_636 );              // 
            imageList.Images.Add( "Module_648",                   Properties.Resources.Module_648 );              // 多维数组
            imageList.Images.Add( "Structure_507",                Properties.Resources.Structure_507 );           // 


            treeView1.ImageList = imageList;

            treeView1.Nodes.Add( "Values" );
            panel3.Enabled = false;
            panel4.Dock = DockStyle.Fill;
        }


        private AllenBradleyNet allenBradleyNet = null;

        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int port ))
            {
                MessageBox.Show( DemoUtils.PortInputWrong );
                return;
            }

            if (!byte.TryParse( textBox15.Text, out byte slot ))
            {
                MessageBox.Show( DemoUtils.SlotInputWrong );
                return;
            }

            allenBradleyNet?.ConnectClose( );
            allenBradleyNet = new AllenBradleyNet( );
            allenBradleyNet.IpAddress = textBox1.Text;
            allenBradleyNet.Port = port;
            allenBradleyNet.Slot = slot;

            //if (!string.IsNullOrEmpty( textBox16.Text ))
            //{
            //    allenBradleyNet.PortSlot = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes( textBox16.Text );
            //}

            OperateResult connect = allenBradleyNet.ConnectServer( );
            if (connect.IsSuccess)
            {
                MessageBox.Show( StringResources.Language.ConnectedSuccess );
                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;
                panel3.Enabled = true;
                TagRefresh( );
            }
            else
            {
                MessageBox.Show( StringResources.Language.ConnectedFailed + connect.ToMessageShowString( ) );
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            TagRefresh( );
        }

        private void TagRefresh( )
        {
            treeView1.Nodes[0].Nodes.Clear( );
            // 加载所有的键值信息
            OperateResult<AbTagItem[]> reads = allenBradleyNet.TagEnumerator( );
            if (!reads.IsSuccess) 
            {
                MessageBox.Show( reads.Message );
                return;
            };

            AddTreeNode( treeView1.Nodes[0], reads.Content );

            treeView1.ExpandAll( );
        }

        private void AddTreeNode(TreeNode parent, AbTagItem[] items )
        {
            foreach (var item in items)
            {
                TreeNode treeNode = new TreeNode( item.Name );
                if (item.ArrayDimension == 1)
                {
                    treeNode.ImageKey = "brackets_Square_16xMD";
                    treeNode.SelectedImageKey = "brackets_Square_16xMD";
                }
                else if (item.ArrayDimension > 1)
                {
                    treeNode.ImageKey = "Module_648";
                    treeNode.SelectedImageKey = "Module_648";
                }
                else if (item.IsStruct)
                {
                    treeNode.ImageKey = "Class_489";
                    treeNode.SelectedImageKey = "Class_489";
                }
                else
                {
                    treeNode.ImageKey = "Enum_582";
                    treeNode.SelectedImageKey = "Enum_582";
                }

                treeNode.Tag = item;
                parent.Nodes.Add( treeNode );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            panel3.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;

            allenBradleyNet.ConnectClose( );
        }

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            // 点击了数据信息
            if (e.Node.ImageKey == "Enum_582")
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


        public override void SaveXmlParameter( XElement element )
        {
            element.SetAttributeValue( DemoDeviceList.XmlIpAddress, textBox1.Text );
            element.SetAttributeValue( DemoDeviceList.XmlPort, textBox2.Text );
            element.SetAttributeValue( DemoDeviceList.XmlSlot, textBox15.Text );
        }

        public override void LoadXmlParameter( XElement element )
        {
            base.LoadXmlParameter( element );
            textBox1.Text = element.Attribute( DemoDeviceList.XmlIpAddress ).Value;
            textBox2.Text = element.Attribute( DemoDeviceList.XmlPort ).Value;
            textBox15.Text = element.Attribute( DemoDeviceList.XmlSlot ).Value;
        }

        private void userControlHead1_SaveConnectEvent_1( object sender, EventArgs e )
        {
            userControlHead1_SaveConnectEvent( sender, e );
        }
    }
}
