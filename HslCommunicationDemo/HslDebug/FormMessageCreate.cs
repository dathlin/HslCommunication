using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Core.Address;
using HslCommunication.ModBus;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Melsec.Helper;
using HslCommunication.Profinet.Omron;
using HslCommunication.Profinet.Omron.Helper;
using HslCommunication.Profinet.Siemens;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.Hyundai;

namespace HslCommunicationDemo.HslDebug
{
	public partial class FormMessageCreate : System.Windows.Forms.Form
	{
		public FormMessageCreate( )
		{
			InitializeComponent( );
		}

		public void AddTreeChild( TreeNode parent, string text, Func<string, ushort, OperateResult<byte[]>> buildReadBool , Func<string, ushort, OperateResult<byte[]>> buildReadWord, bool hex = true )
		{
			MessgaeCreate messgaeCreate = new MessgaeCreate();
			messgaeCreate.BuildReadBool = buildReadBool;
			messgaeCreate.BuildReadWord = buildReadWord;
			messgaeCreate.Text          = text;
			messgaeCreate.HexBinary     = hex;
			TreeNode treeNode = new TreeNode( text );
			treeNode.Tag = messgaeCreate;
			parent.Nodes.Add( treeNode );
		}

		private void FormMessageCreate_Load( object sender, EventArgs e )
		{
			// 三菱
			TreeNode melsec = new TreeNode( "Melsec" );
			AddTreeChild( melsec, "Qna3E-Binary", ( address, length ) =>
			{
				OperateResult<McAddressData> addressResult = melsec1.McAnalysisAddress( address, length, true );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				byte[] command = McBinaryHelper.BuildReadMcCoreCommand( addressResult.Content, true );
				return OperateResult.CreateSuccessResult( McBinaryHelper.PackMcCommand( new MelsecMcNet( ), command ) );
			},
			( address, length ) =>
			{
				OperateResult<McAddressData> addressResult = melsec1.McAnalysisAddress( address, length, true );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				byte[] command = McBinaryHelper.BuildReadMcCoreCommand( addressResult.Content, false );
				return OperateResult.CreateSuccessResult( McBinaryHelper.PackMcCommand( new MelsecMcNet( ), command ) );
			} );
			AddTreeChild( melsec, "Qna3E-Ascii", ( address, length ) =>
			{
				OperateResult<McAddressData> addressResult = melsec1.McAnalysisAddress( address, length, true );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				byte[] command = McAsciiHelper.BuildAsciiReadMcCoreCommand( addressResult.Content, true );
				return OperateResult.CreateSuccessResult( McAsciiHelper.PackMcCommand( melsec1, command ) );
			},
			( address, length ) =>
			{
				OperateResult<McAddressData> addressResult = melsec1.McAnalysisAddress( address, length, true );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				byte[] command = McAsciiHelper.BuildAsciiReadMcCoreCommand( addressResult.Content, false );
				return OperateResult.CreateSuccessResult( McAsciiHelper.PackMcCommand( melsec1, command ) );
			}, false );
			AddTreeChild( melsec, "A1E-Binary", ( address, length ) => MelsecA1ENet.BuildReadCommand( address, length, true, 0xFF ).Then( m => OperateResult.CreateSuccessResult( m[0] )), 
				( address, length ) =>  MelsecA1ENet.BuildReadCommand( address, length, false, 0xFF ).Then( m => OperateResult.CreateSuccessResult( m[0] ) ) );
			AddTreeChild( melsec, "A1E-Ascii", ( address, length )  => MelsecA1EAsciiNet.BuildReadCommand( address, length, true, 0xFF ).Then( m => OperateResult.CreateSuccessResult( m[0] )), 
				( address, length ) => MelsecA1EAsciiNet.BuildReadCommand( address, length, false, 0xFF ).Then( m => OperateResult.CreateSuccessResult( m[0] ) ), false );
			AddTreeChild( melsec, "FxLinks", ( address, length ) =>
			{
				OperateResult<List<byte[]>> command = MelsecFxLinksHelper.BuildReadCommand( melsec2.Station, address, length, true, melsec2.WaittingTime );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( melsec2.PackCommandWithHeader( command.Content[0] ) );
			},
			( address, length ) =>
			{
				OperateResult<List<byte[]>> command = MelsecFxLinksHelper.BuildReadCommand( melsec2.Station, address, length, false, melsec2.WaittingTime );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( melsec2.PackCommandWithHeader( command.Content[0] ) );
			}, false );
			treeView1.Nodes.Add( melsec );

			// 西门子
			TreeNode siemens = new TreeNode( "Siemens" );
			AddTreeChild( siemens, "S7", ( address, length ) =>
			{
				return SiemensS7Net.BuildBitReadCommand(address, 0x01);
			},
			( address, length ) =>
			{
				OperateResult<S7AddressData> addressResult = S7AddressData.ParseFrom( address, length );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return SiemensS7Net.BuildReadCommand( new S7AddressData[] { addressResult.Content }, 0x01 );
			} );
			treeView1.Nodes.Add( siemens );

			// Modbus
			TreeNode modbus = new TreeNode( "Modbus" );
			AddTreeChild( modbus, "Modbus Tcp", ( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadCoil );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.PackCommandToTcp( addressResult.Content[0], 0x00 ) );
			},
			( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadRegister );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.PackCommandToTcp( addressResult.Content[0], 0x00 ) );
			} );
			AddTreeChild( modbus, "Modbus Rtu", ( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadCoil );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.PackCommandToRtu( addressResult.Content[0] ) );
			},
			( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadRegister );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.PackCommandToRtu( addressResult.Content[0] ) );
			} );
			AddTreeChild( modbus, "Modbus Ascii", ( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadCoil );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.TransModbusCoreToAsciiPackCommand( addressResult.Content[0] ) );
			},
			( address, length ) =>
			{
				OperateResult<byte[][]> addressResult = ModbusInfo.BuildReadModbusCommand( address, length, 0x01, true, ModbusInfo.ReadRegister );
				if (!addressResult.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( addressResult );

				return OperateResult.CreateSuccessResult( ModbusInfo.TransModbusCoreToAsciiPackCommand( addressResult.Content[0] ) );
			}, false );
			treeView1.Nodes.Add( modbus );

			// 欧姆龙
			TreeNode omron = new TreeNode( "Omron" );
			AddTreeChild( omron, "Fins Tcp", ( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, true, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( omron1.PackCommandWithHeader( command.Content[0] ) );
			},
			( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, false, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( omron1.PackCommandWithHeader( command.Content[0] ) );
			} );
			AddTreeChild( omron, "Fins Udp", ( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, true, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( omron2.PackCommandWithHeader( command.Content[0] ) );
			},
			( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, false, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( omron2.PackCommandWithHeader( command.Content[0] ) );
			} );
			AddTreeChild( omron, "Host Link", ( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, true, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( OmronHostLinkHelper.PackCommand( omron3, 0x00, command.Content[0] ) );
			},
			( address, length ) =>
			{
				var command = OmronFinsNetHelper.BuildReadCommand( OmronPlcType.CSCJ, address, length, false, int.MaxValue );
				if (!command.IsSuccess) return OperateResult.CreateFailedResult<byte[]>( command );

				return OperateResult.CreateSuccessResult( OmronHostLinkHelper.PackCommand( omron3, 0x00, command.Content[0] ) );
			}, false );
			treeView1.Nodes.Add( omron );


			// 机器人
			TreeNode robot = new TreeNode( "Omron" );
			AddTreeChild( robot, "Hyundai UdpNet", ( address, length ) =>
			{
				HyundaiData hyundaiReceive = new HyundaiData( );
				hyundaiReceive.Command = 'S';
				hyundaiReceive.CharDummy = "ABC";
				hyundaiReceive.State = 5;
				hyundaiReceive.Count = 6;
				hyundaiReceive.Data = new double[] { 1.1d, 2.2d, 3.3d, 4.4d, 5.5d, 6.6d };

				return OperateResult.CreateSuccessResult( hyundaiReceive.ToBytes( ) );
			},
			( address, length ) =>
			{
				HyundaiData hyundaiReceive = new HyundaiData( );
				hyundaiReceive.Command = 'P';
				hyundaiReceive.CharDummy = "CVD";
				hyundaiReceive.State = 7;
				hyundaiReceive.Count = 6;
				hyundaiReceive.Data = new double[] { 5.1d, 5.2d, 5.3d, 5.4d, 6.5d, 100.6d };

				return OperateResult.CreateSuccessResult( hyundaiReceive.ToBytes( ) );
			}, 
			hex: true );
			treeView1.Nodes.Add( robot );

		}


		private HslCommunication.Profinet.Melsec.MelsecMcNet melsec1 = new HslCommunication.Profinet.Melsec.MelsecMcNet( );
		private HslCommunication.Profinet.Melsec.MelsecFxLinks melsec2 = new MelsecFxLinks( );
		private HslCommunication.Profinet.Omron.OmronFinsNet omron1  = new HslCommunication.Profinet.Omron.OmronFinsNet( );
		private HslCommunication.Profinet.Omron.OmronFinsUdp omron2  = new HslCommunication.Profinet.Omron.OmronFinsUdp( );
		private HslCommunication.Profinet.Omron.OmronHostLink omron3 = new HslCommunication.Profinet.Omron.OmronHostLink( );

		public MessgaeCreate MessageCreate { get; set; }

		private void button_read_bool_Click( object sender, EventArgs e )
		{
			// 读取位报文
			TreeNode selectNode = treeView1.SelectedNode;
			if ( selectNode == null ) return;

			if (selectNode.Tag is MessgaeCreate messgaeCreate)
			{
				if (messgaeCreate.BuildReadBool != null)
				{
					OperateResult<byte[]> build = messgaeCreate.BuildReadBool.Invoke( textBox1.Text, ushort.Parse( textBox2.Text ) );
					if (build.IsSuccess)
					{
						messgaeCreate.Result = messgaeCreate.HexBinary ? build.Content.ToHexString( ' ' ) : SoftBasic.GetAsciiStringRender( build.Content );
						MessageCreate = messgaeCreate;
						DialogResult = DialogResult.OK;
					}
					else
					{
						MessageBox.Show( "Build failed: " + build.Message );
					}
				}
			}
		}

		private void button_read_word_Click( object sender, EventArgs e )
		{
			// 读取字报文
			TreeNode selectNode = treeView1.SelectedNode;
			if (selectNode == null) return;

			if (selectNode.Tag is MessgaeCreate messgaeCreate)
			{
				if (messgaeCreate.BuildReadWord != null)
				{
					OperateResult<byte[]> build = messgaeCreate.BuildReadWord.Invoke( textBox1.Text, ushort.Parse( textBox2.Text ) );
					if (build.IsSuccess)
					{
						messgaeCreate.Result = messgaeCreate.HexBinary ? build.Content.ToHexString( ' ' ) : SoftBasic.GetAsciiStringRender( build.Content );
						MessageCreate = messgaeCreate;
						DialogResult = DialogResult.OK;
					}
					else
					{
						MessageBox.Show( "Build failed: " + build.Message );
					}
				}
			}
		}

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode selectNode = treeView1.SelectedNode;
			if (selectNode == null) return;

			if (selectNode.Tag is MessgaeCreate messgaeCreate)
			{
				label3.Text = "协议：" + messgaeCreate.Text;
			}
		}

		private void FormMessageCreate_Shown( object sender, EventArgs e )
		{
			treeView1.ExpandAll( );
		}
	}

	public class MessgaeCreate
	{
		public string Text { get; set; }

		public bool HexBinary { get; set; } = true;

		public Func<string, ushort, OperateResult<byte[]>> BuildReadBool { get; set; }

		public Func<string, ushort, OperateResult<byte[]>> BuildReadWord { get; set; }

		public string Result { get; set; }
	}
}
