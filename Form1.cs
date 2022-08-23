using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;
using TDEngineClient.Helper;
using TDEngineClient.Services;
using static TDEngineClient.Services.MyService;

namespace TDEngineClient
{
    public partial class Form1 : Form
    {

        private int PageSize = 30;

        //private int CurrentPage = 1;

        private List<TAccount> ServerList = new List<TAccount>();

        public Form1()
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Bottom;
            //清空控件
            this.tabControl1.TabPages.Clear();
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Padding = new System.Drawing.Point(FormHelper.CLOSE_SIZE, FormHelper.CLOSE_SIZE);
            this.tabControl1.DrawItem += new DrawItemEventHandler(FormHelper.tabControl_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(FormHelper.tabControl_MouseDown);
            this.Text = $"{Application.ProductName} {Application.ProductVersion}";
        }

        private void InitailForm()
        {
            ServerList = FileHelper.GetServersFromIni();//从配置文件获取服务器列表

            //添加所有服务
            treeView1.Nodes.Clear();
            for (int i = 0; i < ServerList.Count; i++)
            {
                TreeNode item = new TreeNode();
                item.Text = ServerList[i].TDatabase + (string.IsNullOrEmpty(ServerList[i].AliasName) ? "" :"("+ ServerList[i].AliasName+")");
                item.Tag = ServerList[i];
                item.ImageIndex = 0;
                treeView1.Nodes.Add(item);
            }

            var queries = FileHelper.GetQueriesFromIni();
            foreach (var query in queries)
            {
                var account= ServerList.Where(t => t.TDatabase == query.AccountDB).FirstOrDefault();
                if (account != null)
                {
                    CreateQueryWindow(account, null, null, query);
                }
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitailForm();
        }

        private async Task AddDbs(TreeNode node, List<DataBaseDto> dbs, TAccount account)
        {
            foreach (var db in dbs)
            {
                var item = new TreeNode();
                item.Tag = db;
                item.Text = db.name;
                item.ImageIndex = 1;
                item.SelectedImageIndex = 1;

                var result = await MyService.GetStables(account, db.name);
                if (result != null)
                {
                    foreach (var st in result)
                    {
                        var subitem = new TreeNode();
                        subitem.Tag = st;
                        subitem.Text = $"{st.name}({st.tables.ToString()})";
                        subitem.ImageIndex = 2;
                        subitem.SelectedImageIndex = 2;
                        item.Nodes.Add(subitem);
                    }
                }
                node.Nodes.Add(item);
            }
        }

        private void AddRecords(DataGridView dgv, RecordDto record)
        {
            dgv.Columns.Clear();
            foreach (var field in record.FieldList)
            {
                dgv.Columns.Add(field, field);
            }

            dgv.Rows.Clear();
            foreach (var rec in record.RecordList)
            {
                var row = new DataGridViewRow();
                for (int i = 0; i < rec.Count; i++)
                {
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                    textboxcell.Value = rec[i];
                    row.Cells.Add(textboxcell);
                }

                dgv.Rows.Add(row);
            }

            ts3.Text = record.Count.ToString();

        }

        private async void CreateTable(TAccount account, string tableName)
        {
            if (tabControl1.TabPages.ContainsKey(tableName))
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tableName];
            }
            else
            {
                tabControl1.TabPages.Add(tableName, tableName);
                var tab = tabControl1.TabPages[tableName];
                tab.AutoScroll = true;
                var dgv = new DataGridView();
                dgv.Parent = tab;
                dgv.Dock = DockStyle.Fill;
                //dgv.Dock = DockStyle.None;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dgv.ReadOnly = true;

                var result = await MyService.GetRecords(account, tableName, 1, PageSize);
                if (result != null)
                {
                    AddRecords(dgv, result);
                    ShowRecordCount(result, tableName, 1, PageSize);
                }
                tabControl1.SelectedTab = tabControl1.TabPages[tableName];
                tab.Tag = result;
            }

        }

        private async void TurnPage(TabPage tp, TurnPageType type, long toPage = 0)
        {
            if (tp == null) return;
            if (tp.Tag is RecordDto)
            {
                var table = (tp.Tag as RecordDto);
                var account = table.DB;
                var tableName = table.TableName;

                var targetPage = table.CurrentPage;
                if (type == TurnPageType.First)
                {
                    targetPage = 1;
                }
                else if (type == TurnPageType.Last)
                {
                    targetPage = table.PageCount;
                }
                else if (type == TurnPageType.Prev)
                {
                    targetPage = table.CurrentPage > 1 ? table.CurrentPage - 1 : table.CurrentPage;
                }
                else if (type == TurnPageType.Next)
                {
                    targetPage = table.CurrentPage < table.PageCount ? table.CurrentPage + 1 : table.CurrentPage;
                }
                else if (type == TurnPageType.ToPage)
                {
                    targetPage = toPage > 0 && toPage <= table.PageCount ? toPage : table.CurrentPage;
                }

                var currentPage = targetPage;

                var result = await MyService.GetRecords(account, tableName, currentPage, PageSize);
                if (result != null)
                {
                    foreach (var ctl in tp.Controls)
                    {
                        if (ctl is DataGridView)
                        {
                            AddRecords(ctl as DataGridView, result);
                            ShowRecordCount(result, tableName, currentPage, PageSize);
                            break;
                        }
                    }

                    tp.Tag = result;
                }
                numericUpDown1.Value = currentPage;
            }

        }

        public void ShowRecordCount(RecordDto rec, string tableName, long page = 1, int pageSize = 10)
        {
            var offset = (page - 1) * pageSize + 1;//起始记录位置(下标从1开始)
            var limit = pageSize;
            //var count = rec.Count;
            //var Pages = rec.PageCount;
            string info = $"Page[{rec.CurrentPage}/{rec.PageCount}] Record[{offset}-{offset + pageSize - 1}/{rec.Count}]";
            ts3.Text = info;
        }

        private void CreateQueryWindow(TAccount account, DataBaseDto db, StableDto stable,TQueryBox box=null)
        {
            //if (db == null) return;
            var tab = new TabPage(box == null ? db.name + "->Query" : box.Caption);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
            tab.AutoScroll = true;

            var myText = new TextBox();
            myText.Multiline = true;
            myText.MaxLength = 655360;
            myText.Height = 400;
            myText.Font = new Font(FontFamily.GenericSansSerif, 12);
            myText.ScrollBars = ScrollBars.Vertical;
            myText.Dock = DockStyle.Top;
            if (box != null)
            {
                var lines = box.Text.Split(new string[] { "\\r\\n"}, StringSplitOptions.None);
                myText.Lines = lines;
            }
            else if (db != null && stable != null)
            {
                myText.Text = $"select * from {db.name}.{stable.name} limit 20";
            }
            myText.Tag = account;
            myText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            myText.ContextMenuStrip = menuText;
            ts2.Text = "Press F5 to Run SQL";
            tab.Controls.Add(myText);


            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            //dgv.Dock = DockStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.ReadOnly = true;
            tab.Controls.Add(dgv);
            dgv.BringToFront();
        }

        private async void ExcuteQuery(TAccount account, string sql, DataGridView dgv)
        {
            dgv.Rows.Clear();
            var result = await MyService.ExcuteSql(account, sql);
            if (result != null)
            {
                AddRecords(dgv, result);
                ShowRecordCount(result, account.TDatabase, 1, PageSize);
            }

        }


        private async void CreateQueryResult(TabPageType tpType)
        {
            string sql = "";
            string caption = "";
            TAccount account = null;
            StableDto stable = null;
            DataBaseDto db = null;
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                account = (node.Tag as TAccount);
            }
            else if (node.Tag is StableDto)
            {
                stable = (node.Tag as StableDto);

                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = (node.Parent.Tag as DataBaseDto);
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
            }
            if (account == null || db == null) return;

            if (tpType == TabPageType.Tables)
            {
                caption = "Tables";
                sql = $"show {db.name}.tables";
            }
            else if (tpType == TabPageType.Describe)
            {
                caption = "Describe";
                sql = $"describe {db.name}.{stable.name}";
            }
            else if (tpType == TabPageType.Variables)
            {
                caption = "Variables";
                sql = $"show variables";
            }

            var tab = new TabPage(caption);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
            tab.AutoScroll = true;
            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            //dgv.Dock = DockStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.ReadOnly = true;
            tab.Controls.Add(dgv);

            var result = await MyService.ExcuteSql(account, sql);
            if (result != null)
            {
                AddRecords(dgv, result);
                ts3.Text = result.RecordList.Count.ToString() + " Records";
            }

        }



        /// <summary>
        /// 执行当前SQL
        /// </summary>
        private void RunSql()
        {
            var tp = tabControl1.SelectedTab;
            if (tp == null) return;
            TAccount account = null;
            DataGridView dgv = null;
            TextBox tbox = null;
            foreach (var ctl in tp.Controls)
            {
                if (ctl is DataGridView)
                {
                    dgv = (ctl as DataGridView);
                }
                else if (ctl is TextBox)
                {
                    tbox = (ctl as TextBox);
                    if (tbox.Tag is TAccount)
                    {
                        account = (tbox.Tag as TAccount);
                    }
                }
            }
            if (dgv != null && tbox != null)
            {
                var text = tbox.Text;
                if (!string.IsNullOrEmpty(tbox.SelectedText))
                {
                    text = tbox.SelectedText;
                }

                ExcuteQuery(account, text, dgv);
            }
        }


        /// <summary>
        /// 按F5时执行SQL语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSql();
            }
            else
            {
                ts3.Text = "Text Length "+(sender as TextBox).Text.Length.ToString();
            }
        }


        private async void treeView1_DoubleClick(object sender, EventArgs e)
        {
            var item = GetCurrentNodeItem();
            //if(item.Type == NodeItemType.Server)


            var node = (sender as TreeView).SelectedNode;
            if (node.Tag is TAccount)
            {
                if (node.Nodes.Count == 0)
                    OpenDB(node);
            }
            else if (node.Tag is StableDto)
            {
                var stable = (node.Tag as StableDto);
                string dbName = "";
                var account = new TAccount();

                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    dbName = (node.Parent.Tag as DataBaseDto).name;
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
                var tableName = $"{dbName}.{stable.name}";

                CreateTable(account, tableName);


            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var type = (TurnPageType)Convert.ToInt32((sender as Button).Tag);
            TurnPage(tabControl1.SelectedTab, type);

        }

        private void m1_Click(object sender, EventArgs e)
        {
            CreateQueryResult(TabPageType.Tables);
        }

        private void m2_Click(object sender, EventArgs e)
        {
            CreateQueryResult(TabPageType.Describe);
        }

        private void m3_Click(object sender, EventArgs e)
        {
            var item = GetCurrentNodeItem();
            CreateQueryWindow(item.Server, item.Db, item.STable);
        }

        private void m4_Click(object sender, EventArgs e)
        {
            CreateQueryResult(TabPageType.Variables);
        }

        private NodeItem GetCurrentNodeItem()
        {
            NodeItem item = new NodeItem();
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                item.Server = (node.Tag as TAccount);
                item.Type = NodeItemType.Server;
            }
            else if (node.Tag is StableDto)
            {
                item.STable = (node.Tag as StableDto);
                item.Type = NodeItemType.Stable;

                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    item.Db = (node.Parent.Tag as DataBaseDto);
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        item.Server = (svrNode.Tag as TAccount);
                }
            }
            return item;
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

        private async void m_opendb_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                OpenDB(node);
            }
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="dbNode"></param>
        private async void OpenDB(TreeNode dbNode)
        {
            var account = (dbNode.Tag as TAccount);
            var result = await MyService.GetDbList(account);
            if (result != null)
            {
                dbNode.Nodes.Clear();
                await AddDbs(dbNode, result, account);
                dbNode.Expand();
            }
            else
            {
                MessageBox.Show("无法连接到服务器" + account.TUrl + "!", "Error", MessageBoxButtons.OK);
            }
        }


        private void m_closedb_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node.Tag is TAccount)
            {
                node.Nodes.Clear();
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
            Form2 frm2 = new Form2(fieldStr);
            frm2.ShowDialog();
            tbox.AppendText(frm2.Sql);

        }

        private void m_run_Click(object sender, EventArgs e)
        {
            RunSql();
        }

        private async void ComputingMesuringPoints(TAccount account)
        {
            string sql = "";

            StableDto stable = null;
            DataBaseDto db = null;

            var tab = new TabPage(account.TDatabase+"->MesuringPoints");
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
            tab.AutoScroll = true;
            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            //dgv.Dock = DockStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.ReadOnly = true;
            tab.Controls.Add(dgv);
            dgv.Columns.Add("Database", "Database");
            dgv.Columns.Add("Tables", "Tables");
            dgv.Columns.Add("Fields", "Fields");
            dgv.Columns.Add("Points", "Points");

            sql = $"show databases";
            var result1 = await MyService.ExcuteSql(account, sql);
            if (result1 != null)
            {
                int totalTb = 0;
                int totalFd = 0;
                int totalPt = 0;

                foreach (var rec in result1.RecordList)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value =rec[0]}); //库名
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = rec[2] }); //表个数
                    totalTb += int.Parse(rec[2]);

                    var fieldNum = "0";
                    sql = $"show {rec[0]}.stables";
                    var result2 = await MyService.ExcuteSql(account, sql);
                    if (result2 != null)
                    {
                        fieldNum = result2.RecordList[0][2];
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value = fieldNum}); //字段个数
                        totalFd += int.Parse(fieldNum);
                    }
                    if (int.TryParse(rec[2], out int x) && int.TryParse(fieldNum, out int y))
                    {
                        var pt = x * (y - 1);
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value =pt}); //测点个数(不含ts)
                        totalPt += pt;
                    }

                    dgv.Rows.Add(row);
                }
                //统计行
                var row1 = new DataGridViewRow();
                row1.Cells.Add(new DataGridViewTextBoxCell() { Value = "[Total]" }); 
                row1.Cells.Add(new DataGridViewTextBoxCell() { Value = totalTb }); 
                row1.Cells.Add(new DataGridViewTextBoxCell() { Value = totalFd });
                row1.Cells.Add(new DataGridViewTextBoxCell() { Value = totalPt });
                dgv.Rows.Add(row1);
            }

            ts3.Text = result1.RecordList.Count.ToString() + " Records";


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
                                tabText.AccountDB = ((ctl as TextBox).Tag as TAccount).TDatabase;
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
    }
}
