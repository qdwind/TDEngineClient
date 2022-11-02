using System;
using System.Collections.Generic;
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
    partial class fmain 
    {
        private Config MyConfig;
        private int PageSize = 100;

        //private int CurrentPage = 1;

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void InitailForm()
        {
            spInner.Dock = DockStyle.Fill;
            spInner.SplitterDistance = spInner.Width - 100;
            lblInfo.Text = "";

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
            this.WindowState = FormWindowState.Maximized;

            //添加所有服务
            treeView1.Nodes.Clear();
            for (int i = 0; i < MyConfig.ServerList.Count; i++)
            {
                TreeNode item = new TreeNode();
                item.Text = MyConfig.ServerList[i].TServer + (string.IsNullOrEmpty(MyConfig.ServerList[i].AliasName) ? "" : "(" + MyConfig.ServerList[i].AliasName + ")");
                item.Tag = MyConfig.ServerList[i];
                item.ImageIndex = 0;
                treeView1.Nodes.Add(item);
            }

            //显示上次未关闭的查询窗口
            var queries = FileHelper.GetQueriesFromIni();
            foreach (var query in queries)
            {
                var account = MyConfig.ServerList.Where(t => t.TServer == query.AccountServer).FirstOrDefault();
                if (account != null)
                {
                    CreateQueryWindow(account, query);
                }
            }

        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="dbNode"></param>
        private void OpenDB(TreeNode dbNode)
        {
            var account = (dbNode.Tag as TAccount);
            var result = MyService.GetDbList(account);
            if (result != null)
            {
                dbNode.Nodes.Clear();
                if (account.Version == 30)
                {
                    AddDbsV30(dbNode, result);
                }
                else
                {
                    AddDbsV20(dbNode, result);
                }

                dbNode.Expand();
                dbNode.ImageIndex = 5;
                dbNode.SelectedImageIndex = 5;
            }
            else
            {
                MessageBox.Show("无法连接到服务器" + account.TUrl + "!", "Error", MessageBoxButtons.OK);
            }
        }

        private void AddDbsV20(TreeNode node, List<DataBaseDto> dbs)
        {
            foreach (var db in dbs)
            {
                var item = new TreeNode();
                item.Tag = db;
                item.Text = db.Name;
                item.ImageIndex = 1;
                item.SelectedImageIndex = 1;

                var tabs = MyService.GetTables(db);//所有表
                var mystabs = MyService.GetStables(db);//添加超级表
                foreach (var ms in mystabs)
                {
                    var stabItem = new TreeNode();
                    var mytabs = tabs.Where(t => t.db_name == db.Name && t.stable_name == ms.stable_name).ToList();//超级表下的子表
                    foreach (var mt in mytabs)
                    {
                        var tabItem = new TreeNode();
                        tabItem.Tag = mt;
                        tabItem.Text = $"{mt.table_name}";
                        tabItem.ImageIndex = 3;
                        tabItem.SelectedImageIndex = 3;
                        stabItem.Nodes.Add(tabItem);
                    }


                    stabItem.Tag = ms;
                    stabItem.Text = $"{ms.stable_name}({mytabs.Count.ToString()})";
                    stabItem.ImageIndex = 2;
                    stabItem.SelectedImageIndex = 2;
                    item.Nodes.Add(stabItem);
                }

                var nortabs = tabs.Where(t => t.db_name == db.Name && t.stable_name == "").ToList();//普通表
                foreach (var tab in nortabs)
                {
                    var tabItem = new TreeNode();
                    tabItem.Tag = tab;
                    tabItem.Text = $"{tab.table_name}";
                    tabItem.ImageIndex = 3;
                    tabItem.SelectedImageIndex = 3;
                    item.Nodes.Add(tabItem);
                }


                node.Nodes.Add(item);
            }
        }

        private void AddDbsV30(TreeNode node, List<DataBaseDto> dbs)
        {
            var account = dbs[0].Account;
            var tabs = MyService.GetTables(new DataBaseDto { Account =account});
            var stabs = MyService.GetStables(new DataBaseDto { Account = account });

            foreach (var db in dbs)
            {
                var item = new TreeNode();
                item.Tag = db;
                item.Text = db.Name;
                item.ImageIndex = 1;
                item.SelectedImageIndex = 1;

                var mystabs = stabs.Where(t => t.db_name == db.Name).ToList();//添加超级表
                foreach (var ms in mystabs)
                {
                    var stabItem = new TreeNode();
                    var mytabs = tabs.Where(t => t.db_name == db.Name && t.stable_name == ms.stable_name).ToList();//超级表下的子表
                    foreach (var mt in mytabs)
                    {
                        var tabItem = new TreeNode();
                        tabItem.Tag = mt;
                        tabItem.Text = $"{mt.table_name}";
                        tabItem.ImageIndex = 3;
                        tabItem.SelectedImageIndex = 3;
                        stabItem.Nodes.Add(tabItem);
                    }


                    stabItem.Tag = ms;
                    stabItem.Text = $"{ms.stable_name}({mytabs.Count.ToString()})";
                    stabItem.ImageIndex = 2;
                    stabItem.SelectedImageIndex = 2;
                    item.Nodes.Add(stabItem);
                }

                var systabs = tabs.Where(t => t.db_name == db.Name && t.type == TableType.SYSTEM_TABLE.ToString()).ToList();//系统表
                foreach (var tab in systabs)
                {
                    var tabItem = new TreeNode();
                    tabItem.Tag = tab;
                    tabItem.Text = $"{tab.table_name}";
                    tabItem.ImageIndex = 4;
                    tabItem.SelectedImageIndex = 4;
                    item.Nodes.Add(tabItem);
                }
                var nortabs = tabs.Where(t => t.db_name == db.Name && t.type == TableType.NORMAL_TABLE.ToString()).ToList();//普通表
                foreach (var tab in nortabs)
                {
                    var tabItem = new TreeNode();
                    tabItem.Tag = tab;
                    tabItem.Text = $"{tab.table_name}";
                    tabItem.ImageIndex = 3;
                    tabItem.SelectedImageIndex = 3;
                    item.Nodes.Add(tabItem);
                }


                node.Nodes.Add(item);
            }
        }

        /// <summary>
        /// 创建查询命令窗口
        /// </summary>
        /// <param name="account"></param>
        /// <param name="db"></param>
        /// <param name="stable"></param>
        /// <param name="table"></param>
        /// <param name="box"></param>
        private void CreateQueryWindow(DataBaseDto db, StableDto stable, TableDto table)
        {
            var caption = db.Name + "->Query";
            string[] text = new string[] { };

            if (db != null && table != null)
            {
                text = new string[] { $"select * from {db.Name}.{table.table_name} limit 100" };
            }
            else if (db != null && stable != null)
            {
                text = new string[] { $"select * from {db.Name}.{stable.stable_name} limit 100" };
            }

            AddTabWindow(db.Account, caption, text);
        }

        /// <summary>
        /// 根据历史记录恢复查询窗口
        /// </summary>
        /// <param name="db"></param>
        /// <param name="stable"></param>
        /// <param name="table"></param>
        /// <param name="box"></param>
        private void CreateQueryWindow(TAccount account, TQueryBox box)
        {
            if (box == null) return;
            var lines = box.Text.Split(new string[] { "\\r\\n" }, StringSplitOptions.None);
            AddTabWindow(account, box.Caption, lines);
        }


        /// <summary>
        /// 根据操作命令创建SQL窗口
        /// </summary>
        /// <param name="command"></param>
        /// <param name="account"></param>
        /// <param name="db"></param>
        /// <param name="stable"></param>
        /// <param name="table"></param>
        private void CreateQueryWindow(SqlCommandType command, TAccount account, DataBaseDto db, StableDto stable, TableDto table)
        {
            var caption ="";
            string[] text = new string[] { };

            if (command == SqlCommandType.CreateDatabase)
            {
                caption = $"{account.TServer}->sql";
                text = new string[] { $"create database dbname keep 3650 duration 50" };
            }
            else if (command == SqlCommandType.DropDatabase)
            {
                caption = $"{account.TServer}->sql";
                text = new string[] { $"drop database {db.Name}" };
            }
            else if (command == SqlCommandType.CreateStable)
            {
                caption = $"{db.Name}->sql";
                text = new string[] { $"create stable {db.Name}.stablename (ts timestamp, intfield int, strfield binary(20)) tags (strfield binary(20))" };
            }
            else if (command == SqlCommandType.DropStable)
            {
                caption = $"{db.Name}->sql";
                text = new string[] { $"drop stable {stable.stable_name}" };
            }
            else if (command == SqlCommandType.CreateTable)
            {
                if (stable == null)//直接建表
                {
                    caption = $"{db.Name}->sql";
                    text = new string[] { $"create table {db.Name}.tablename (ts timestamp, intfield int, strfield binary(20))" };
                }
                else //在超级表下建子表
                {
                    caption = $"{db.Name}.{stable.stable_name}->sql";
                    text = new string[] { $"create table {db.Name}.tablename using {db.Name}.{stable.stable_name} tags ('value1', 'value2')" };
                }
            }
            else if (command == SqlCommandType.DropTable)
            {
                caption = $"{db.Name}->sql";
                text = new string[] { $"drop table {db.Name}.{table.table_name}" };
            }

            AddTabWindow(account, caption, text);
        }



        /// <summary>
        /// 添加TAB
        /// </summary>
        /// <param name="account"></param>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        private void AddTabWindow(TAccount account, string caption,string[] text)
        {
            //if (db == null) return;
            var tab = new TabPage(caption);
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
            myText.Lines = text;

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



        /// <summary>
        /// 显示查询结果窗口
        /// </summary>
        /// <param name="tpType"></param>
        private void CreateQueryResult(TabPageType tpType)
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
                sql = $"show {db.Name}.tables";
            }
            else if (tpType == TabPageType.Describe)
            {
                caption = "Describe";
                sql = $"describe {db.Name}.{stable.stable_name}";
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

            var result = MyService.ExcuteSql(account, sql);
            if (result != null)
            {
                AddRecords(dgv, result);
                ts3.Text = result.RecordList.Count.ToString() + " Records";
            }

        }


        private void ExcuteQuery(TAccount account, string sql, DataGridView dgv)
        {
            dgv.Rows.Clear();
            var result = MyService.ExcuteSql(account, sql);
            if (result != null)
            {
                AddRecords(dgv, result);
                ShowRecordCount(result, account.TServer, 1, PageSize);
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
                if (string.IsNullOrEmpty(tbox.SelectedText))
                {
                    var firstPos = tbox.GetFirstCharIndexOfCurrentLine();
                    var line = tbox.GetLineFromCharIndex(firstPos);
                    var lastPos = tbox.GetFirstCharIndexFromLine(line + 1);
                    tbox.Select(firstPos, lastPos - firstPos);
                }
                text = tbox.SelectedText;

                ExcuteQuery(account, text, dgv);
            }
        }

        private void ComputingMesuringPoints(TAccount account)
        {
            string sql = "";

            StableDto stable = null;
            DataBaseDto db = null;

            var tab = new TabPage(account.TServer + "->MesuringPoints");
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

            if (account.Version == 30)
            {
                //TODO
            }
            else
            {
                sql = $"show databases";
                var result1 = MyService.ExcuteSql(account, sql);
                if (result1 != null)
                {
                    int totalTb = 0;
                    int totalFd = 0;
                    int totalPt = 0;

                    foreach (var rec in result1.RecordList)
                    {
                        var row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value = rec[0] }); //库名
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value = rec[2] }); //表个数
                        totalTb += int.Parse(rec[2]);

                        var fieldNum = "0";
                        sql = $"show {rec[0]}.stables";
                        var result2 = MyService.ExcuteSql(account, sql);
                        if (result2 == null || result2.RecordList.Count == 0) continue;

                        fieldNum = result2.RecordList[0][2];
                        row.Cells.Add(new DataGridViewTextBoxCell() { Value = fieldNum }); //字段个数
                        totalFd += int.Parse(fieldNum);

                        if (int.TryParse(rec[2], out int x) && int.TryParse(fieldNum, out int y))
                        {
                            var pt = x * (y - 1);
                            row.Cells.Add(new DataGridViewTextBoxCell() { Value = pt }); //测点个数(不含ts)
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

        }



        private NodeItem GetCurrentNodeItem()
        {
            NodeItem item = new NodeItem();
            var node = treeView1.SelectedNode;
            TreeNode svrNode = null, dbNode = null, sNode = null, tNode = null;
            if (node.Tag is TAccount)
            {
                svrNode = node;
            }
            if (node.Tag is DataBaseDto)
            {
                svrNode = node.Parent;
                dbNode = node;
            }
            else if (node.Tag is StableDto)
            {
                svrNode = node.Parent?.Parent;
                dbNode = node.Parent;
                sNode = node;
            }
            else if (node.Tag is TableDto)
            {
                tNode = node;
                item.Table = tNode?.Tag as TableDto;
                if (item.Table.type == TableType.CHILD_TABLE.ToString())
                {
                    svrNode = node.Parent?.Parent?.Parent;
                    dbNode = node.Parent?.Parent;
                    sNode = node.Parent;
                }
                else
                {
                    svrNode = node.Parent?.Parent;
                    dbNode = node.Parent;
                }
            }

            item.Server = svrNode?.Tag as TAccount;
            item.Db = dbNode?.Tag as DataBaseDto;
            item.STable = sNode?.Tag as StableDto;


            return item;
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

        private void CreateTable(TAccount account, string tableName)
        {
            var key = $"{tableName}@{account.TServer}";
            if (tabControl1.TabPages.ContainsKey(key))
            {
                tabControl1.SelectedTab = tabControl1.TabPages[key];
            }
            else
            {
                tabControl1.TabPages.Add(key, key);
                var tab = tabControl1.TabPages[key];
                tab.AutoScroll = true;
                var dgv = new DataGridView();
                dgv.Parent = tab;
                dgv.Dock = DockStyle.Fill;
                //dgv.Dock = DockStyle.None;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //dgv.ReadOnly = true;

                var result = MyService.GetRecords(account, tableName, 1, PageSize);
                if (result != null)
                {
                    AddRecords(dgv, result);
                    ShowRecordCount(result, tableName, 1, PageSize);
                }
                tabControl1.SelectedTab = tabControl1.TabPages[key];
                tab.Tag = result;
            }

        }

        private void TurnPage(TabPage tp, TurnPageType type, long toPage = 0)
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

                if (targetPage == table.CurrentPage) return;//已在目标页，无须改变

                var currentPage = targetPage;

                var result = MyService.GetRecords(account, tableName, currentPage, PageSize);
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
            var offsetMax = offset + pageSize - 1;
            if (offsetMax > rec.Count) offsetMax = rec.Count;
            string info = $"Page[{rec.CurrentPage}/{rec.PageCount}] Record[{offset}-{offsetMax}/{rec.Count}]";
            ts3.Text = info;
        }

        /// <summary>
        /// 获取节点对应的数据库
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private DataBaseDto GetNodeDb(TreeNode node)
        {
            var db = new DataBaseDto();
            var account = new TAccount();

            if (node.Tag is StableDto)//超级表
            {
                var stable = (node.Tag as StableDto);
                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
            }
            else if (node.Tag is TableDto) //表
            {
                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
                else if (node.Parent?.Parent != null && node.Parent.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is TAccount)
                        account = (svrNode.Tag as TAccount);
                }
            }
            db.Account = account;

            return db;
        }

        private void SetMenu(List<ToolStripMenuItem> items,List<ToolStripSeparator> lines =null)
        {
            m_opensvr.Visible = false;
            m_closesvr.Visible = false;
            m_createdb.Visible = false;
            m_dropdb.Visible = false;
            m_table.Visible = false;
            m_field.Visible = false;
            m_point.Visible = false;
            m_createsuper.Visible = false;
            m_createtable.Visible = false;
            m_droptable.Visible = false;
            m_query.Visible = false;
            //分割线
            sp1.Visible = false;
            sp2.Visible = false;

            if (items != null)
            {
                foreach (var item in items)
                {
                    item.Visible = true;
                }
            }

            if (lines != null)
            {
                foreach (var line in lines)
                {
                    line.Visible = true;
                }
            }

        }



        
    }
}
