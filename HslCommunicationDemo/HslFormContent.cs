using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HslCommunicationDemo
{
    public class HslFormContent : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            AutoScroll = true;
        }
    }
}
