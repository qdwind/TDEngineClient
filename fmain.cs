using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;
using TDEngineClient.Helper;
using TDEngineClient.Services;
using static TDEngineClient.Services.MyService;

namespace TDEngineClient
{
    public partial class fmain : Form
    {

        public fmain()
        {
            MyConfig = FileHelper.GetConfig();//读取配置文件
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(MyConfig.System.Language);
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitailForm();
        }


        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 ||e.KeyCode ==Keys.F1) //按F5(或F1)时执行SQL语句
            {
                RunSql();
            }
            else
            {
                ts3.Text = "Text Length "+(sender as TextBox).Text.Length.ToString();
            }
        }


        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            var item = GetCurrentNodeItem();
            //if(item.Type == NodeItemType.Server)


            var node = (sender as TreeView).SelectedNode;
            if (node.Tag is TAccount) //服务器
            {
                if (node.Nodes.Count == 0)
                    OpenDB(node);
            }
            else if (node.Tag is StableDto)//超级表
            {
                var db = GetNodeDb(node);
                var stable = (node.Tag as StableDto);
                CreateTable(db.Account, $"{db.Name}.{stable.stable_name}");
            }
            else if (node.Tag is TableDto) //表
            {
                var db = GetNodeDb(node);
                var table = (node.Tag as TableDto);
                var tableName = $"{db.Name}.{table.table_name}";
                CreateTable(db.Account, tableName);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var type = (TurnPageType)Convert.ToInt32((sender as Button).Tag);
            TurnPage(tabControl1.SelectedTab, type);

        }

        private void m_table_Click(object sender, EventArgs e)
        {
            CreateQueryResult(TabPageType.Tables); //显示表
        }

        private void m_field_Click(object sender, EventArgs e)
        {
            CreateQueryResult(TabPageType.Describe); //显示字段
        }

        private void m_query_Click(object sender, EventArgs e)
        {
            var item = GetCurrentNodeItem();
            CreateQueryWindow(item.Db, item.STable, item.Table); //创建SQL窗口
        }


        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(numericUpDown1.Value.ToString(), out int num))
                {

                    TurnPage(tabControl1.SelectedTab,  TurnPageType.ToPage,num);
                }

            }
        }

        private void m_opensvr_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                OpenDB(node);
            }
        }


        private void m_closesvr_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                node.Nodes.Clear();
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
            }
        }

        private void m_record_Click(object sender, EventArgs e)
        {
            var tp = tabControl1.SelectedTab;
            if (tp == null) return;
            TextBox tbox = null;
            foreach (var ctl in tp.Controls)
            {
                if (ctl is TextBox)
                {
                    tbox = (ctl as TextBox);
                    break;
                }
            }
            if (tbox == null) return;

            var fieldStr = tbox.SelectedText.Length > 2 ? tbox.SelectedText : tbox.Text;
            ftool frm2 = new ftool(fieldStr);
            frm2.ShowDialog();
            tbox.AppendText(frm2.Sql);

        }

        private void m_run_Click(object sender, EventArgs e)
        {
            RunSql();
        }



        private void m_point_Click(object sender, EventArgs e)
        {
            TAccount account = null;
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                account = (node.Tag as TAccount);
            }
            else if (node.Tag is StableDto)
            {
                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
            }
            if (account == null) return;

            ComputingMesuringPoints(account);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mylist = new List<TQueryBox>();
            foreach ( var tab in tabControl1.TabPages)
            {
                if (tab is TabPage && (tab as TabPage).Text.Contains("->Query"))
                {
                    var tabText = new TQueryBox();
                    tabText.Caption=(tab as TabPage).Text;
                    
                    foreach (var ctl in (tab as TabPage).Controls)
                    {
                        if (ctl is TextBox)
                        {
                            if ((ctl as TextBox).Tag is TAccount)
                            {
                                tabText.AccountServer = ((ctl as TextBox).Tag as TAccount).TServer;
                            }
                            string sTxt = "";
                            foreach (string s in (ctl as TextBox).Lines)
                            {
                                sTxt = sTxt + s + "\\r\\n";//每行末尾都加一个回车 \r\n
                            }
                            tabText.Text = sTxt;
                            break;
                        }
                    }

                    mylist.Add(tabText);
                }
            }
            FileHelper.SaveQueriesToIni(mylist);
        }

        /// <summary>
        /// 设置右键菜单显示项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = (sender as TreeView).SelectedNode;
                if (node == null)
                {
                    SetMenu(new List<ToolStripMenuItem> {});
                }
                else if (node.Tag is TAccount) //服务器
                {
                    SetMenu(new List<ToolStripMenuItem> { m_opensvr, m_closesvr, m_createdb });
                }
                else if (node.Tag is DataBaseDto)//数据库
                {
                    SetMenu(new List<ToolStripMenuItem> { m_dropdb,m_createsuper,m_createtable, m_point,m_query },new List<ToolStripSeparator> { sp1,sp2});
                }
                else if (node.Tag is StableDto)//超级表
                {
                    SetMenu(new List<ToolStripMenuItem> { m_createtable, m_table,m_field,m_query },new List<ToolStripSeparator> { sp2 });

                    //var db = GetNodeDb(node);
                    //var stable = (node.Tag as StableDto);

                }
                else if (node.Tag is TableDto) //表
                {
                    SetMenu(new List<ToolStripMenuItem> { m_field, m_droptable, m_query }, new List<ToolStripSeparator> { sp2 });

                    //var db = GetNodeDb(node);
                    //var table = (node.Tag as TableDto);
                    //var tableName = $"{db.Name}.{table.table_name}";

                }


            }
        }

        /// <summary>
        /// 创建删除的操作命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_command_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem && int.TryParse((sender as ToolStripMenuItem).Tag.ToString(),out int cmd))
            {
                var item = GetCurrentNodeItem();
                CreateQueryWindow((SqlCommandType)cmd, item.Server, item.Db, item.STable, item.Table);
            }
        }


    }
}
