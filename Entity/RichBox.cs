using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDEngineClient
{
    public class RichBox:RichTextBox
    {
        private class paintHelper : Control
        {
            public void DefaultWndProc(ref Message m)
            {
                this.DefWndProc(ref m);
            }
        }

        private const int WM_PAINT = 0x000F;
        private int lockPaint;
        private bool needPaint;
        private paintHelper pHelp = new paintHelper();

        public void BeginUpdate()
        {
            lockPaint++;
        }

        public void EndUpdate()
        {
            lockPaint--;
            if (lockPaint <= 0)
            {
                lockPaint = 0;
                if (needPaint)
                {
                    this.Refresh();
                    needPaint = false;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (lockPaint <= 0)
                    {
                        base.WndProc(ref m);
                    }
                    else
                    {
                        needPaint = true;
                        pHelp.DefaultWndProc(ref m);
                    }
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
