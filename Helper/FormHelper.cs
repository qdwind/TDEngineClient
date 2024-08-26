using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDEngineClient.Helper
{
    public static class FormHelper
    {
        public const int CLOSE_SIZE = 12;
        public static void tabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                var ctl = sender as TabControl;
                Rectangle myTabRect = ctl.GetTabRect(e.Index);

                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.LightGray : Color.White;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //先添加TabPage属性   
                bool isActive = ctl.SelectedIndex == e.Index;
                e.Graphics.DrawString(ctl.TabPages[e.Index].Text, ctl.Font, new SolidBrush(isActive? Color.Black:Color.Gray), myTabRect.X + 2, myTabRect.Y + 5);

                //e.Graphics.DrawLine(new Pen(isActive? Color.Black:Color.White, 1), new Point(myTabRect.X,myTabRect.Y+myTabRect.Height), new Point(myTabRect.X+myTabRect.Width,myTabRect.Y+myTabRect.Height));


                //再画一个矩形框(模拟关闭按钮)
                using (Pen p = new Pen(e.State == DrawItemState.Selected ? Color.LightGray : Color.White))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //画关闭符号
                using (Pen objpen = new Pen(Color.Black)) //new Pen(e.State == DrawItemState.Selected ? Color.Black : Color.WhiteSmoke))
                {
                    //"\"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(objpen, p1, p2);

                    //"/"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(objpen, p3, p4);
                }

                e.Graphics.Dispose();
            }
            catch (Exception)
            {

            }
        }


        /// <summary>
        /// 关闭TAB标签事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tabControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;

                //计算关闭区域   
                Rectangle myTabRect = (sender as TabControl).GetTabRect((sender as TabControl).SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right
                 && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isClose == true)
                {
                    (sender as TabControl).TabPages.Remove((sender as TabControl).SelectedTab);
                }
            }
        }

        /// <summary>
        /// 获取输入光标位置
        /// </summary>
        /// <param name="textBox1"></param>
        /// <returns></returns>
        public static Point GetCursorPos(this RichBox textBox1)
        {
            Graphics gc = textBox1.CreateGraphics();
            int wd = (int)gc.MeasureString("x", textBox1.Font).Width;
            int ht = (int)gc.MeasureString("x", textBox1.Font).Height;
            Point p2 = textBox1.GetPositionFromCharIndex(textBox1.SelectionStart - 1);
            Point p = textBox1.Location;
            if (textBox1.Text.Length > 0)
            {
                if (textBox1.Text[textBox1.SelectionStart - 1] == '\n' || textBox1.Text[textBox1.SelectionStart - 1] == '\r')

                {
                    p.Y += p2.Y + 2 * ht;
                }
                else
                {
                    p.X += p2.X + wd;
                    p.Y += p2.Y + ht;
                }
            }
            else
            {
                p.Y += p2.Y + ht;
            }
            return p;
        }



    }
}
