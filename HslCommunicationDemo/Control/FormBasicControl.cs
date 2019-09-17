using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormBasicControl : HslFormContent
    {
        public FormBasicControl( )
        {
            InitializeComponent( );
        }

        private void FormBasicControl_Load( object sender, EventArgs e )
        {
            random = new Random( );
            timerTick = new Timer( );
            timerTick.Interval = 1000;
            timerTick.Tick += TimerTick_Tick;
            timerTick.Start( );

            Language( Program.Language );

            userDrum1.Text = Program.Language == 1 ? "锅炉1#\r\n123.45 ℃" : "Boiler 1#\r\n123.45 ℃";
        }

        private void Language( int language )
        {
            if (language == 1)
            {
                Text = "常用的简单控件";
                label1.Text = "基础样式";
                label2.Text = "选中样式";
                label3.Text = "禁用样式";
                label8.Text = "状态灯控件，目前只有简单的颜色";
                label4.Text = "闪烁";
                label6.Text = "进度条控件，允许设置背景，文本，还有简单的动画";
                label7.Text = "随机";
                label9.Text = "旋转开关控件，只有2个状态";
                label10.Text = "罐子控件";
                label5.Text = "时钟控件";
                button1.Text = "右下角弹窗";
            }
            else
            {
                Text = "Common simple controls";
                label1.Text = "Base style";
                label2.Text = "Check Style";
                label3.Text = "Disabling styles";
                label8.Text = "Status light control, currently only a simple color";
                label4.Text = "Flashing";
                label6.Text = "Progress bar controls, allowing setting of backgrounds, text, and simple animations";
                label7.Text = "Random";
                label9.Text = "Rotary switch control, only 2 states";
                label10.Text = "Container control";
                label5.Text = "Clock control";
                button1.Text = "pop-up window";
            }
        }

        private void TimerTick_Tick( object sender, EventArgs e )
        {
            if(userLantern3.LanternBackground == Color.Gray)
            {
                userLantern3.LanternBackground = Color.Tomato;
            }
            else
            {
                userLantern3.LanternBackground = Color.Gray;
            }

            int value = random.Next( 101 );
            userVerticalProgress7.Value = value;
            userVerticalProgress8.Value = value;

            if (userBottle1.Value > 0)
            {
                userBottle1.Value--;
                if(userBottle1.Value== 0)
                {
                    userBottle1.IsOpen = false;
                }
            }
        }

        private Timer timerTick = null;
        private Random random;

        private void button1_Click( object sender, EventArgs e )
        {
            // 右下角弹窗，存在10s就关闭，时间小于0就是无穷大
            HslCommunication.BasicFramework.FormPopup popup = new HslCommunication.BasicFramework.FormPopup( "This is a test message!", Color.Blue, 5000 );
            popup.Show( );
        }
    }
}
