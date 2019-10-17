using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.Control;

namespace HslCommunicationDemo
{
    public partial class FormSelect : Form
    {
        public static Color ThemeColor = Color.AliceBlue;

        public FormSelect( )
        {
            InitializeComponent( );
        }



        private void FormLoad_Load( object sender, EventArgs e )
        {

            dockPanel1.Theme = vS2015BlueTheme1;


            ThemeColor = menuStrip1.BackColor;
            verisonToolStripMenuItem.Text = "Version: " + HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( );

            if (Settings1.Default.language == 1)
            {
                if (System.Globalization.CultureInfo.CurrentCulture.ToString( ).StartsWith( "zh" ))
                {
                    Program.Language = 1;
                    Language( Program.Language );
                }
                else
                {
                    HslCommunication.StringResources.SeteLanguageEnglish( );
                    Program.Language = 2;
                    Language( Program.Language );
                }
            }
            else
            {
                Program.Language = 2;
                HslCommunication.StringResources.SeteLanguageEnglish( );
                Language( Program.Language );
            }

            support赞助ToolStripMenuItem.Click += Support赞助ToolStripMenuItem_Click;
            TreeViewIni( );

            FormCharge form = new FormCharge( );
            form.Show( dockPanel1 );
        }

        private void Support赞助ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (HslCommunication.BasicFramework.FormSupport form = new HslCommunication.BasicFramework.FormSupport( ))
            {
                form.ShowDialog( );
            }
        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "HslCommunication 测试工具";
                免责条款ToolStripMenuItem.Text = "免责条款";
                论坛toolStripMenuItem.Text = "论坛";
                授权ToolStripMenuItem.Text = "授权";
            }
            else
            {
                Text = "HslCommunication Test Tool";
                论坛toolStripMenuItem.Text = "BBS";
                免责条款ToolStripMenuItem.Text = "Disclaimer";
                授权ToolStripMenuItem.Text = "Authorize";
            }
        }

        private void LinkLabel6_Click( object sender, EventArgs e )
        {
            // English
            HslCommunication.StringResources.SeteLanguageEnglish( );
            Program.Language = 2;
            Language( Program.Language );
            MessageBox.Show( "Select English!" );
        }

        private void LinkLabel5_Click( object sender, EventArgs e )
        {
            // 简体中文
            HslCommunication.StringResources.SetLanguageChinese( );
            Program.Language = 1;
            Language( Program.Language );
            MessageBox.Show( "已选择中文" );
        }

        private void 论坛toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://bbs.hslcommunication.cn/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void OpenWebside( string url )
        {
            try
            {
                System.Diagnostics.Process.Start( url );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void blogsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenWebside( "http://www.cnblogs.com/dathlin/p/7703805.html" );
        }

        private void webSideToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenWebside( "http://www.hslcommunication.cn/" );
        }

        private void mesDemoToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenWebside( "http://118.24.36.220:8081/" );
        }


        private void 简体中文ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 简体中文
            HslCommunication.StringResources.SetLanguageChinese( );
            Program.Language = 1;
            Settings1.Default.language = Program.Language;
            Settings1.Default.Save( );
            Language( Program.Language );
            MessageBox.Show( "已选择中文" );
        }

        private void englishToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // English
            HslCommunication.StringResources.SeteLanguageEnglish( );
            Program.Language = 2;
            Settings1.Default.language = Program.Language;
            Settings1.Default.Save( );
            Language( Program.Language );
            MessageBox.Show( "Select English!" );
        }

        private void 日志ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenWebside( "http://118.24.36.220:8080/html/c136d3de-eab7-9b0f-4bdf-d891297c8018.htm" );
        }


        private void FormLoad_Shown( object sender, EventArgs e )
        {
            System.Threading.ThreadPool.QueueUserWorkItem( new System.Threading.WaitCallback( ThreadPoolCheckVersion ), null );
        }

        private void ThreadPoolCheckVersion( object obj )
        {
            System.Threading.Thread.Sleep( 100 );
            HslCommunication.Enthernet.NetSimplifyClient simplifyClient = new HslCommunication.Enthernet.NetSimplifyClient( "118.24.36.220", 18467 );
            HslCommunication.OperateResult<HslCommunication.NetHandle, string> read = simplifyClient.ReadCustomerFromServer( 1, HslCommunication.BasicFramework.SoftBasic.FrameworkVersion.ToString( ) );
            if (read.IsSuccess)
            {
                HslCommunication.BasicFramework.SystemVersion version = new HslCommunication.BasicFramework.SystemVersion( read.Content2 );
                if (version > HslCommunication.BasicFramework.SoftBasic.FrameworkVersion)
                {
                    // 有更新
                    Invoke( new Action( ( ) =>
                     {
                         if (MessageBox.Show( "服务器有新版本：" + read.Content2 + Environment.NewLine + "是否启动更新？", "检测到更新", MessageBoxButtons.YesNo ) == DialogResult.Yes)
                         {
                             try
                             {
                                 System.Diagnostics.Process.Start( Application.StartupPath + "\\软件自动更新.exe" );
                                 System.Threading.Thread.Sleep( 50 );
                                 Close( );
                             }
                             catch(Exception ex)
                             {
                                 MessageBox.Show( "更新软件丢失，无法启动更新： " + ex.Message );
                             }
                         }
                     } ) );
                }
            }
        }

        private void 免责条款ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Hide( );
            System.Threading.Thread.Sleep( 200 );
            using (FormDisclaimer form = new FormDisclaimer( ))
            {
                form.ShowDialog( );
            }
            System.Threading.Thread.Sleep( 200 );
            Show( );
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            OpenWebside( "https://github.com/dathlin/HslControlsDemo" );
        }

        private void rToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (FormAuthor form = new FormAuthor( ))
            {
                form.ShowDialog( );
            }
        }


        private void TreeViewIni( )
        {
            // 三菱PLC相关
            TreeNode melsecNode = new TreeNode( "Melsec Plc [三菱]" );
            melsecNode.Nodes.Add( new TreeNode( "A-1E (Binary)" ) { Tag = typeof( FormMelsec1EBinary ) } );
            melsecNode.Nodes.Add( new TreeNode( "MC (Binary)" ) { Tag = typeof( FormMelsecBinary ) } );
            melsecNode.Nodes.Add( new TreeNode( "MC (ASCII)" ) { Tag = typeof( FormMelsecAscii ) } );
            melsecNode.Nodes.Add( new TreeNode( "Fx Serial【编程口】" ) { Tag = typeof( FormMelsecSerial ) } );
            melsecNode.Nodes.Add( new TreeNode( "Fx Serial OverTcp" ) { Tag = typeof( FormMelsecSerialOverTcp ) } );
            melsecNode.Nodes.Add( new TreeNode( "Fx Links【485】" ) { Tag = typeof( FormMelsecLinks ) } );
            melsecNode.Nodes.Add( new TreeNode( "Fx Links OverTcp" ) { Tag = typeof( FormMelsecLinksOverTcp ) } );
            melsecNode.Nodes.Add( new TreeNode( "A-3C (format1)" ) { Tag = typeof( FormMelsec3C ) } );
            melsecNode.Nodes.Add( new TreeNode( "A-3C OverTcp" ) { Tag = typeof( FormMelsec3COverTcp ) } );
            melsecNode.Nodes.Add( new TreeNode( "Mc Virtual Server" ) { Tag = typeof( FormMcServer ) } );
            treeView1.Nodes.Add( melsecNode );

            // 西门子PLC相关
            TreeNode siemensNode = new TreeNode( "Siemens Plc [西门子]" );
            siemensNode.Nodes.Add( new TreeNode( "S1200" ) { Tag = typeof( FormSiemensS1200 ) } );
            siemensNode.Nodes.Add( new TreeNode( "S1500" ) { Tag = typeof( FormSiemensS1500 ) } );
            siemensNode.Nodes.Add( new TreeNode( "S300" ) { Tag = typeof( FormSiemensS300 ) } );
            siemensNode.Nodes.Add( new TreeNode( "S400" ) { Tag = typeof( FormSiemensS400 ) } );
            siemensNode.Nodes.Add( new TreeNode( "S200" ) { Tag = typeof( FormSiemensS200 ) } );
            siemensNode.Nodes.Add( new TreeNode( "S200 smart" ) { Tag = typeof( FormSiemensS200Smart ) } );
            siemensNode.Nodes.Add( new TreeNode( "Fetch/Write" ) { Tag = typeof( FormSiemensFW ) } );
            siemensNode.Nodes.Add( new TreeNode( "PPI" ) { Tag = typeof( FormSiemensPPI ) } );
            siemensNode.Nodes.Add( new TreeNode( "PPI OverTcp" ) { Tag = typeof( FormSiemensPPIOverTcp ) } );
            siemensNode.Nodes.Add( new TreeNode( "MPI" ) { Tag = typeof( FormSiemensMPI ) } );
            siemensNode.Nodes.Add( new TreeNode( "S7 Virtual Server" ) { Tag = typeof( FormS7Server ) } );
            treeView1.Nodes.Add( siemensNode );

            // Modbus协议
            TreeNode modbusNode = new TreeNode( "Modbus" );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Tcp" ) { Tag = typeof( FormModbus ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Udp" ) { Tag = typeof( FormModbusUdp ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Tcp[Alien]" ) { Tag = typeof( FormModbusAlien ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Rtu" ) { Tag = typeof( FormModbusRtu ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Rtu OverTcp" ) { Tag = typeof( FormModbusRtuOverTcp ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Ascii" ) { Tag = typeof( FormModbusAscii ) } );
            modbusNode.Nodes.Add( new TreeNode( "Modbus Server" ) { Tag = typeof( FormModbusServer ) } );
            treeView1.Nodes.Add( modbusNode );

            // 欧姆龙PLC相关
            TreeNode omronNode = new TreeNode( "Omron Plc[欧姆龙]" );
            omronNode.Nodes.Add( new TreeNode( "Fins Tcp" ) { Tag = typeof( FormOmron ) } );
            omronNode.Nodes.Add( new TreeNode( "Fins Udp" ) { Tag = typeof( FormOmronUdp ) } );
            omronNode.Nodes.Add( new TreeNode( "EtherNet/IP(CIP)" ) { Tag = typeof( FormOmronCip ) } );
            omronNode.Nodes.Add( new TreeNode( "HostLink 【串口】" ) { Tag = typeof( FormOmronHostLink ) } );
            omronNode.Nodes.Add( new TreeNode( "HostLink OverTcp" ) { Tag = typeof( FormOmronHostLinkOverTcp ) } );
            treeView1.Nodes.Add( omronNode );

            // Lsis PLC
            TreeNode lsisNode = new TreeNode( "LSis Plc" );
            lsisNode.Nodes.Add( new TreeNode( "XGB Fast Enet" ) { Tag = typeof( FormLsisFEnet ) } );
            lsisNode.Nodes.Add( new TreeNode( "XGB Cnet" ) { Tag = typeof( FormLsisCnet ) } );
            lsisNode.Nodes.Add( new TreeNode( "XGB Cnet OverTcp" ) { Tag = typeof( FormLsisCnetOverTcp ) } );
            lsisNode.Nodes.Add( new TreeNode( "LSis Virtual Server" ) { Tag = typeof( FormLSisServer ) } );
            treeView1.Nodes.Add( lsisNode );

            // Keyence PLC
            TreeNode keyencePlc = new TreeNode( "Keyence Plc[基恩士]" );
            keyencePlc.Nodes.Add( new TreeNode( "MC-3E (Binary)" ) { Tag = typeof( FormKeyenceBinary ) } );
            keyencePlc.Nodes.Add( new TreeNode( "MC-3E (ASCII)" ) { Tag = typeof( FormKeyenceAscii ) } );
            keyencePlc.Nodes.Add( new TreeNode( "Nano (ASCII)" ) { Tag = typeof( FormKeyenceNanoSerial ) } );
            keyencePlc.Nodes.Add( new TreeNode( "Nano OverTcp" ) { Tag = typeof( FormKeyenceNanoSerialOverTcp ) } );
            treeView1.Nodes.Add( keyencePlc );

            // Panasonic PLC
            TreeNode panasonicPlc = new TreeNode( "Panasonic Plc[松下]" );
            panasonicPlc.Nodes.Add( new TreeNode( "MC-3E (Binary)" ) { Tag = typeof( FormPanasonicBinary ) } );
            panasonicPlc.Nodes.Add( new TreeNode( "Mewtocol" ) { Tag = typeof( FormPanasonicMew ) } );
            panasonicPlc.Nodes.Add( new TreeNode( "Mewtocol OverTcp" ) { Tag = typeof( FormPanasonicMewOverTcp ) } );
            treeView1.Nodes.Add( panasonicPlc );

            // Allen Bradlly PLC
            TreeNode allenBrandlyPlc = new TreeNode( "AllenBrandly Plc[罗克韦尔]" );
            allenBrandlyPlc.Nodes.Add( new TreeNode( "EtherNet/IP(CIP)" ) { Tag = typeof( FormAllenBrandly ) } );
            treeView1.Nodes.Add( allenBrandlyPlc );

            // Fatek 永宏PLC
            TreeNode fatekNode = new TreeNode( "Fatek Plc[永宏]" );
            fatekNode.Nodes.Add( new TreeNode( "programe [编程口]" ) { Tag = typeof( FormFatekPrograme ) } );
            fatekNode.Nodes.Add( new TreeNode( "programe OverTcp" ) { Tag = typeof( FormFatekProgrameOverTcp ) } );
            treeView1.Nodes.Add( fatekNode );

            // Fuji Plc
            TreeNode fujiNode = new TreeNode( "Fuji Plc[富士]" );
            fujiNode.Nodes.Add( new TreeNode( "SPB [编程口]" ) { Tag = typeof( FormFujiSPB ) } );
            fujiNode.Nodes.Add( new TreeNode( "SPB OverTcp" ) { Tag = typeof( FormFujiSPBOverTcp ) } );
            treeView1.Nodes.Add( fujiNode );

            // Knx
            TreeNode knxNode = new TreeNode( "Knx" );
            knxNode.Nodes.Add( new TreeNode( "Knx" ) { Tag = typeof( PLC.FormKnx ) } );
            treeView1.Nodes.Add( knxNode );

            // Redis 相关
            TreeNode redisNode = new TreeNode( "Redis" );
            redisNode.Nodes.Add( new TreeNode( "Redis Client" ) { Tag = typeof( FormRedisClient ) } );
            redisNode.Nodes.Add( new TreeNode( "Redis Browser" ) { Tag = typeof( Redis.RedisBrowser ) } );
            redisNode.Nodes.Add( new TreeNode( "Redis Subscribe" ) { Tag = typeof( FormRedisSubscribe ) } );
            treeView1.Nodes.Add( redisNode );

            // Mqtt 相关
            TreeNode mqttNode = new TreeNode( "MQTT" );
            mqttNode.Nodes.Add( new TreeNode( "Mqtt Client" ) { Tag = typeof( FormMqttClient ) } );
            mqttNode.Nodes.Add( new TreeNode( "Mqtt Server" ) { Tag = typeof( FormMqttServer ) } );
            treeView1.Nodes.Add( mqttNode );

            // Robot 相关
            TreeNode robotNode = new TreeNode( "Robot[机器人]" );
            robotNode.Nodes.Add( new TreeNode( "EFORT New [新版]" ) { Tag = typeof( Robot.FormEfort ) } );
            robotNode.Nodes.Add( new TreeNode( "EFORT Pre [旧版]" ) { Tag = typeof( Robot.FormEfortPrevious ) } );
            robotNode.Nodes.Add( new TreeNode( "Kuka [库卡]" ) { Tag = typeof( FormKuka ) } );
            robotNode.Nodes.Add( new TreeNode( "YRC1000 [安川]" ) { Tag = typeof( FormYRC1000 ) } );
            robotNode.Nodes.Add( new TreeNode( "ABB Web" ) { Tag = typeof( Robot.FormABBWebApi ) } );
            treeView1.Nodes.Add( robotNode );

            // Debug 相关
            TreeNode debugNode = new TreeNode( "Debug About[调试技术]" );
            debugNode.Nodes.Add( new TreeNode( "Serial [串口调试]" ) { Tag = typeof( FormSerialDebug ) } );
            debugNode.Nodes.Add( new TreeNode( "Tcp/Ip Client [网口调试]" ) { Tag = typeof( FormTcpDebug ) } );
            debugNode.Nodes.Add( new TreeNode( "Tcp/Ip Server [网口调试]" ) { Tag = typeof( FormTcpServer ) } );
            debugNode.Nodes.Add( new TreeNode( "Bytes Data [数据调试]" ) { Tag = typeof( FormByteTransfer ) } );
            debugNode.Nodes.Add( new TreeNode( "Mail [邮件调试]" ) { Tag = typeof( FormMail ) } );
            debugNode.Nodes.Add( new TreeNode( "Order Number [订单号调试]" ) { Tag = typeof( FormSeqCreate ) } );
            debugNode.Nodes.Add( new TreeNode( "Regist [注册码调试]" ) { Tag = typeof( FormRegister ) } );
            treeView1.Nodes.Add( debugNode );

            // HSL 相关
            TreeNode hslNode = new TreeNode( "Hsl Proto[hsl协议]" );
            hslNode.Nodes.Add( new TreeNode( "Simplify Net [同步交互]" ) { Tag = typeof( FormSimplifyNet ) } );
            hslNode.Nodes.Add( new TreeNode( "Simplify Net Alien" ) { Tag = typeof( FormSimplifyNetAlien ) } );
            hslNode.Nodes.Add( new TreeNode( "Complex Net [异步交互]" ) { Tag = typeof( FormComplexNet ) } );
            hslNode.Nodes.Add( new TreeNode( "Udp Net [同步交互]" ) { Tag = typeof( FormUdpNet ) } );
            hslNode.Nodes.Add( new TreeNode( "File Net [文件收发]" ) { Tag = typeof( FormFileClient ) } );
            hslNode.Nodes.Add( new TreeNode( "Log Net [日志记录]" ) { Tag = typeof( FormLogNet ) } );
            hslNode.Nodes.Add( new TreeNode( "Push Net [消息推送]" ) { Tag = typeof( FormPushNet ) } );
            hslNode.Nodes.Add( new TreeNode( "SoftUpdate [软件更新]" ) { Tag = typeof( FormUpdateServer ) } );
            hslNode.Nodes.Add( new TreeNode( "Plain Net [明文交互]" ) { Tag = typeof( FormPlainSocket ) } );
            hslNode.Nodes.Add( new TreeNode( "Http Web" ) { Tag = typeof( FormHttpServer ) } );
            treeView1.Nodes.Add( hslNode );

            // 扫码软件
            TreeNode barCodeNode = new TreeNode( "BarCode[扫码]" );
            barCodeNode.Nodes.Add( new TreeNode( "Sick" ) { Tag = typeof( BarCode.FormSickBarCode ) } );
            treeView1.Nodes.Add( barCodeNode );

            // Instrument 仪器仪表
            TreeNode instrumentNode = new TreeNode( "Instrument [仪器仪表]" );
            instrumentNode.Nodes.Add( new TreeNode( "DAM3601 [阿尔泰科技]" ) { Tag = typeof( FormDAM3601 ) } );
            treeView1.Nodes.Add( instrumentNode );

            // 控件库
            TreeNode controlNode = new TreeNode( "Control [控件库]" );
            controlNode.Nodes.Add( new TreeNode( "Simple Control" ) { Tag = typeof( FormBasicControl ) } );
            controlNode.Nodes.Add( new TreeNode( "Gauge [仪表盘]" ) { Tag = typeof( FormGauge ) } );
            controlNode.Nodes.Add( new TreeNode( "Curve [曲线]" ) { Tag = typeof( FormCurve ) } );
            controlNode.Nodes.Add( new TreeNode( "Pie Chart [饼图]" ) { Tag = typeof( FormPieChart ) } );
            controlNode.Nodes.Add( new TreeNode( "Pipe [管道组态]" ) { Tag = typeof( FormPipe ) } );
            treeView1.Nodes.Add( controlNode );

            // 算法相关 algorithms
            TreeNode algorithmsNode = new TreeNode( "Algorithms [算法]" );
            algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶算法]" ) { Tag = typeof( Algorithms.FourierTransform ) } );
            algorithmsNode.Nodes.Add( new TreeNode( "Fourier [傅立叶滤波]" ) { Tag = typeof( Algorithms.FourierFilter ) } );
            algorithmsNode.Nodes.Add( new TreeNode( "PID [Pid模拟]" ) { Tag = typeof( Algorithms.FormPid ) } );
            treeView1.Nodes.Add( algorithmsNode );

            // 其他界面
            TreeNode othersNode = new TreeNode( "Special [特殊协议]" );
            othersNode.Nodes.Add( new TreeNode( "Open Protocol" ) { Tag = typeof( FormOpenProtocol ) } );
            treeView1.Nodes.Add( othersNode );

            // treeView1.ExpandAll( );
        }

        private void TreeView1_DoubleClick( object sender, EventArgs e )
        {
            TreeNode treeNode = treeView1.SelectedNode;
            if (treeNode == null) return;
            if (treeNode.Tag == null) return;

            if (treeNode.Tag is Type type)
            {
                HslFormContent hslForm = (HslFormContent)type.GetConstructors( )[0].Invoke( null );
                if (hslForm != null) hslForm.Show( dockPanel1 );
            }
        }
    }

    public class FormSiemensS1200 : FormSiemens
    {
        public FormSiemensS1200( ) : base( SiemensPLCS.S1200 )
        {

        }
    }
    public class FormSiemensS1500 : FormSiemens
    {
        public FormSiemensS1500( ) : base( SiemensPLCS.S1500 )
        {

        }
    }
    public class FormSiemensS300 : FormSiemens
    {
        public FormSiemensS300( ) : base( SiemensPLCS.S300 )
        {

        }
    }
    public class FormSiemensS400 : FormSiemens
    {
        public FormSiemensS400( ) : base( SiemensPLCS.S400 )
        {

        }
    }
    public class FormSiemensS200 : FormSiemens
    {
        public FormSiemensS200( ) : base( SiemensPLCS.S200 )
        {

        }
    }
    public class FormSiemensS200Smart : FormSiemens
    {
        public FormSiemensS200Smart( ) : base( SiemensPLCS.S200Smart )
        {

        }
    }
}
