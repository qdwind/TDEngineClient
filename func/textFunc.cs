using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;
using TDEngineClient.Helper;
using TDEngineClient.Services;

namespace TDEngineClient
{
    /// <summary>
    /// 文本编辑框输入/关键字词典/颜色控制函数
    /// </summary>
    partial class fmain
    {
        private Color COLOR_NORMAL = Color.Black;
        private Color COLOR_STANDARD_KEY = Color.Blue;
        private Color COLOR_FUNCTION_KEY = Color.Green;
        private Color COLOR_STRING = Color.IndianRed;



        /// <summary>
        /// 获取用户输入的词
        /// </summary>
        /// <param name="txtBox"></param>
        /// <returns></returns>
        private string GetInputText(RichBox txtBox)
        {
            //捕获键入字符
            var leftPos = txtBox.GetFirstCharIndexOfCurrentLine();
            //var line = txtBox.GetLineFromCharIndex(leftPos);
            var lastPos = txtBox.SelectionStart;
            var text = "";
            try
            {
                text = txtBox.Text.Substring(leftPos, lastPos - leftPos);
                var sp = text.LastIndexOf(' ');
                if (sp > 0) text = text.Substring(sp, text.Length - sp);
                text = text.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetInputText:{ex.Message}");
            }


            return text;
        }

        /// <summary>
        /// 替换当前输入词
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="txt"></param>
        private void ReplaceInputText(RichBox txtBox, string txt)
        {
            var leftPos = txtBox.GetFirstCharIndexOfCurrentLine();
            var line = txtBox.GetLineFromCharIndex(leftPos);
            var lastPos = txtBox.SelectionStart;
            var text = txtBox.Text.Substring(leftPos, lastPos - leftPos);
            var sp = text.LastIndexOf(' ') + leftPos;
            txtBox.Select(sp + 1, lastPos - sp - 1);
            txtBox.SelectedText = txt;
        }



        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="txtBox"></param>
        private void ShowTipBox(RichBox txtBox, Keys key)
        {
            if (!MyConfig.System.ShowTip) return;
            if ((key < Keys.D0 || key > Keys.Z) && key != Keys.Back && key != Keys.OemPeriod) //合法字符：0..8,A..Z,esc,.
            {
                return;
            }

            var svr = (txtBox.Tag as QueryBox).Server;
            if ((txtBox.Tag as QueryBox).DbDict.Count == 0)
            {
                var svrInfo = MyService.GetServerDetail(svr);
                if (svrInfo.Connected)
                {
                    (txtBox.Tag as QueryBox).DbDict.AddRange(svr.GetTipNames()); //添加数据库表名称列表
                }
                else
                {
                    MessageBox.Show("无法连接到服务器" + svr.Url + "!", "Error", MessageBoxButtons.OK);
                }
            }

            var text = GetInputText(txtBox);
            if (text.Length > 0)//检索
            {
                var dict = new List<Tip>();
                dict.AddRange((txtBox.Tag as QueryBox).TipsDict);
                dict.AddRange((txtBox.Tag as QueryBox).DbDict);
                //var found = dict.Where(t => t.Text.StartsWith(text)).OrderBy(t=>t.Text).Select(t=>t.Text).ToArray();
                var found = dict.Where(t => t.Visible && t.Text.StartsWith(text)).OrderBy(t => t.Text).ToList();//以关键词开头的

                var foundMids = dict.Where(t => t.Visible && t.Text.Contains(text) && !t.Text.StartsWith(text)).OrderBy(t => t.Text).ToList();//仅包含的
                found.AddRange(foundMids);

                if (found.Count > 0)
                {
                    List<DataGridViewRow> dgs = new List<DataGridViewRow>();
                    for (int i = 0; i < found.Count; i++)
                    {
                        var dg = new DataGridViewRow();
                        dg.Cells.Add(new DataGridViewTextBoxCell() { Value = found[i].Text });
                        dg.Cells.Add(new DataGridViewTextBoxCell() { Value = found[i].Remark });
                        dgs.Add(dg);
                    }

                    TipBox.Rows.Clear();
                    TipBox.Rows.AddRange(dgs.ToArray());



                    //捕获光标位置
                    var p = FormHelper.GetCursorPos(txtBox);


                    //TipBox.Items.AddRange(found);

                    if (TipBox.CurrentRow == null && TipBox.Rows.Count > 0)
                    {
                        TipBox.Rows[0].Selected = true;
                    }


                    TipBox.Left = spMain.Panel1.Width + p.X + 10;
                    TipBox.Top = p.Y + 100;
                    TipBox.Parent = this;
                    TipBox.BringToFront();
                    TipBox.Visible = true;
                    return;
                }

            }
            TipBox.Visible = false;//隐藏
        }

        /// <summary>
        /// 设置引号内文本颜色
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="pairStr"></param>
        /// <param name="color"></param>
        private void SetColorQuote(RichTextBox textBox, char pairStr, Color color,bool ignoreBefore=false)
        {
            char[] ss = textBox.Text.ToCharArray();
            int myFirst = -1;//记录上一个出现位置
            int myBlack = 0;//记录上一次黑字体位置

            for (int i = 0; i < textBox.Text.Length - 1; i++)
            {
                if (ss[i] == pairStr)
                {
                    if (myFirst > 0)//找到了成对
                    {
                        textBox.Select(myFirst, i - myFirst+1);
                        if (textBox.SelectionColor != COLOR_STRING)//字符色保持不变
                            textBox.SelectionColor = color;
                        myFirst = -1;
                        myBlack = i + 1;
                    }
                    else //找到了第一次出现
                    {
                        myFirst = i;
                        if (i > myBlack &&!ignoreBefore)
                        {
                            textBox.Select(myBlack, i - myBlack);
                            textBox.SelectionColor = COLOR_NORMAL;
                        }
                        myBlack = i + 1;
                    }
                }

            }
        }

        /// <summary>
        /// 设置关键字颜色
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="keys"></param>
        /// <param name="color"></param>
        private void SetColorKeys(RichBox textBox, List<string> keys, Color color)
        {
            char[] allowChars = new char[] { ' ', '(', ')', '\n' }; //允许关键字后的字符

            foreach (var key in keys)
            {
                int cnt = 0;
                int M = key.Length;
                int N = textBox.Text.Length;
                char[] ss = textBox.Text.ToCharArray(), pp = key.ToCharArray();
                if (M > N) continue;


                for (int i = 0; i < N - M + 1; i++)
                {
                    int j;
                    for (j = 0; j < M; j++)
                    {
                        if (ss[i + j] != pp[j]) break;
                    }
                    if (j == key.Length)//找到匹配
                    {
                        if (ss.Length > i + j)
                        {
                            if (!allowChars.Contains(ss[i + j])) continue; //确保关键字是全字匹配的
                        }
                        textBox.Select(i, key.Length);
                        if (textBox.SelectionColor != COLOR_STRING)//字符色保持不变
                            textBox.SelectionColor = color;
                        cnt++;
                    }
                }
            }


        }

        /// <summary>
        /// 刷新字体颜色显示
        /// </summary>
        /// <param name="textBox"></param>
        private void RefreshColors(RichBox textBox)
        {
            if (!MyConfig.System.ColoredKey) return;
            textBox.BeginUpdate();
            int index = textBox.SelectionStart;    //记录修改的位置
            int len = textBox.SelectionLength;//记录原来的选择

            SetColorQuote(textBox, '\'', COLOR_STRING);
            SetColorQuote(textBox, '\"', COLOR_STRING, true);
            SetColorKeys(textBox, MyConst.TipsPublicDict.Where(t => t.Colored && t.Type == TipType.Standard).Select(t => t.Text).ToList(), COLOR_STANDARD_KEY);
            SetColorKeys(textBox, MyConst.TipsPublicDict.Where(t => t.Colored && t.Type == TipType.Functions).Select(t => t.Text).ToList(), COLOR_FUNCTION_KEY);

            textBox.Select(index, len);     //返回修改的位置
            textBox.SelectionColor = Color.Black;//还原颜色

            textBox.EndUpdate();
        }

        /// <summary>
        /// 美化SQL语句格式
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="onlyZip"></param>
        /// <returns></returns>
        private string BeautiSql(string sql, bool onlyZip = false)
        {
            var keys = new List<string> { "select", "from", "where", "order by", "group by" };
            var enter = $"\r\n";

            sql = sql.Replace("\n", "");//删除换行
            sql = sql.Replace("\r", "");//删除换行
            while (sql.Contains($"  ")) //删除多余空格
            {
                sql = sql.Replace($"  ", $" ");
            }

            if (onlyZip) return sql;

            foreach (var key in keys)
            {
                sql = sql.Replace(key, $"{enter}{key}{enter}");//换行关键词
            }
            if (sql.StartsWith(enter))
            {
                sql = sql.Remove(0, 2);//清除起始位置的回车符
            }

            sql = sql.Replace(",", $",{enter}");//逗号换行


            return sql;
        }


    }
}
