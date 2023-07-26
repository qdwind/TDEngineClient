using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private Config MyConfig; //配置文件
        private int PageSize = 100;
        private ListBox TipBox = new ListBox();//提示框

        //private int CurrentPage = 1;

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void InitailForm()
        {
            statusStrip1.Height = 15;
            statusStrip1.Dock = DockStyle.Bottom;
            //statusStrip1.BringToFront();
            spMain.Dock = DockStyle.Fill;
            spMain.BringToFront();


            tabControl1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Bottom;

            //清空控件
            this.tabControl1.TabPages.Clear();
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Padding = new System.Drawing.Point(FormHelper.CLOSE_SIZE, FormHelper.CLOSE_SIZE);
            this.tabControl1.DrawItem += new DrawItemEventHandler(FormHelper.tabControl_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(FormHelper.tabControl_MouseDown);
            this.tabControl1.Appearance = TabAppearance.Normal;
            this.Text = $"{Application.ProductName} {Application.ProductVersion}";
            this.WindowState = FormWindowState.Maximized;

            //添加所有服务
            treeView1.Nodes.Clear();
            for (int i = 0; i < MyConfig.ServerList.Count; i++)
            {
                TreeNode item = new TreeNode();
                item.Text = MyConfig.ServerList[i].IP + (string.IsNullOrEmpty(MyConfig.ServerList[i].AliasName) ? "" : "(" + MyConfig.ServerList[i].AliasName + ")");
                item.Tag = MyConfig.ServerList[i];
                item.ImageIndex = 0;
                treeView1.Nodes.Add(item);
            }

            //显示上次未关闭的查询窗口
            var queries = FileHelper.GetQueriesFromIni();
            foreach (var query in queries)
            {
                var account = MyConfig.ServerList.Where(t => t.IP == query.AccountServer).FirstOrDefault();
                if (account != null)
                {
                    CreateQueryWindow(account, query);
                }
            }
            panel1.Visible = true;

            //初始化tipbox
            TipBox.Width = 260;
            TipBox.Sorted = true;

        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="dbNode"></param>
        private void OpenDB(TreeNode dbNode)
        {
            var account = (dbNode.Tag as Server);

            if (!account.SavePass)//不保存密码时要求密码
            {
                var passFrm = new fpass();
                if (passFrm.ShowDialog() == DialogResult.OK)
                {
                    account.Password = passFrm.Pass;
                    account.SavePass = passFrm.SavePass;
                }
                else
                {
                    return;
                }
            }

            var svrInfo = MyService.GetServerDetail(account);
            if (svrInfo.Connected)
            {
                SetServerNodes(svrInfo, dbNode); //将数据库表添加到节点上
                SaveConfigServers();//保持配置
            }
            else
            {
                MessageBox.Show("无法连接到服务器" + account.Url + "!", "Error", MessageBoxButtons.OK);
            }
           

        }


        /// <summary>
        /// 设置服务器节点
        /// </summary>
        /// <param name="serverDetail"></param>
        /// <param name="dbNode"></param>
        private void SetServerNodes(Server svr, TreeNode dbNode)
        {
            dbNode.Nodes.Clear();

            foreach (var db in svr.DbList)
            {
                var item = new TreeNode();
                item.Tag = db;
                item.Text = db.Name;
                item.ImageIndex = 1;
                item.SelectedImageIndex = 1;

                foreach (var ms in db.Stables)//添加超级表
                {
                    var stabItem = new TreeNode();
                    foreach (var mt in ms.Tables)
                    {
                        var tabItem = new TreeNode();
                        tabItem.Tag = mt;
                        tabItem.Text = $"{mt.table_name}";
                        tabItem.ImageIndex = 3;
                        tabItem.SelectedImageIndex = 3;
                        stabItem.Nodes.Add(tabItem);
                    }
                    stabItem.Tag = ms;
                    stabItem.Text = $"{ms.stable_name}({ms.Tables.Count.ToString()})";
                    stabItem.ImageIndex = 2;
                    stabItem.SelectedImageIndex = 2;
                    item.Nodes.Add(stabItem);
                }

                foreach (var tab in db.SysTables)//系统表
                {
                    var tabItem = new TreeNode();
                    tabItem.Tag = tab;
                    tabItem.Text = $"{tab.table_name}";
                    tabItem.ImageIndex = 4;
                    tabItem.SelectedImageIndex = 4;
                    item.Nodes.Add(tabItem);
                }

                foreach (var tab in db.Tables)//普通表
                {
                    var tabItem = new TreeNode();
                    tabItem.Tag = tab;
                    tabItem.Text = $"{tab.table_name}";
                    tabItem.ImageIndex = 3;
                    tabItem.SelectedImageIndex = 3;
                    item.Nodes.Add(tabItem);
                }


                dbNode.Nodes.Add(item);
            }

            dbNode.Expand();
            dbNode.ImageIndex = 5;
            dbNode.SelectedImageIndex = 5;
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
            if (db == null) return;
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
        private void CreateQueryWindow(Server account, TQueryBox box)
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
        private void CreateQueryWindow(SqlCommandType command, Server account, DataBaseDto db, StableDto stable, TableDto table)
        {
            var caption ="";
            string[] text = new string[] { };

            if (command == SqlCommandType.CreateDatabase)
            {
                caption = $"{account.IP}->sql";
                text = new string[] { $"create database dbname keep 3650 duration 50" };
            }
            else if (command == SqlCommandType.DropDatabase)
            {
                caption = $"{account.IP}->sql";
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


        private Panel CreateQueryPanel(Server account)
        {
            var pnl = new Panel();
            pnl.Height = 30;
            var cmb1 = new ComboBox();
            cmb1.Parent = pnl;
            cmb1.Width = 200;
            cmb1.Top = 5;
            cmb1.Text = $"{account.IP}{(string.IsNullOrEmpty(account.AliasName) ? "" : "(" + account.AliasName + ")")}";
            for (int i = 0; i < MyConfig.ServerList.Count; i++)
            {
                cmb1.Items.Add($"{MyConfig.ServerList[i].IP}{(string.IsNullOrEmpty(MyConfig.ServerList[i].AliasName) ? "" : "(" + MyConfig.ServerList[i].AliasName + ")")}");
            }
            var btn = new Button();
            btn.Left = 210;
            btn.Top = 5;
            btn.Parent = pnl;
            btn.Image = imageList1.Images[7];
            btn.Click += new System.EventHandler(Btn_Click); 
            

            return pnl;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            RunSql();
        }



        /// <summary>
        /// 添加TAB查询窗口
        /// </summary>
        /// <param name="account"></param>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        private void AddTabWindow(Server account, string caption,string[] text)
        {
            //if (db == null) return;
            var tab = new TabPage(caption);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
            tab.AutoScroll = true;

            var qbox = new QueryBox();//保存查询窗口的信息
            qbox.Server = account;
            qbox.TipsDict.AddRange(MyConst.TipsPublicDict);//添加公用TIPS列表
            qbox.DbDict.AddRange(account.GetTipNames()); //添加数据库表名称列表
            qbox.Caption = $"{account.IP}{(string.IsNullOrEmpty(account.AliasName) ? "" : "(" + account.AliasName + ")")}";

            var myText = new TextBox();
            myText.Multiline = true;
            myText.MaxLength = 655360;
            myText.Height = 400;
            myText.Font = new Font(FontFamily.GenericSansSerif, 12);
            myText.ImeMode = ImeMode.Off;
            myText.ScrollBars = ScrollBars.Vertical;
            myText.Dock = DockStyle.Top;
            myText.Lines = text;
            myText.HideSelection = false;

            myText.Tag = qbox; //保存设置项
            myText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            myText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
            myText.ContextMenuStrip = menuText;
            ts2.Text = "Press F5 to Run SQL";
            tab.Controls.Add(myText);

            var pnl = CreateQueryPanel(account);//创建查询工具栏
            pnl.Dock = DockStyle.Top;
            tab.Controls.Add(pnl);


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
            Server account = null;
            StableDto stable = null;
            DataBaseDto db = null;
            var node = treeView1.SelectedNode;
            if (node.Tag is Server)
            {
                account = (node.Tag as Server);
            }
            else if (node.Tag is StableDto)
            {
                stable = (node.Tag as StableDto);

                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = (node.Parent.Tag as DataBaseDto);
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is Server)
                        account = (svrNode.Tag as Server);
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


        private void ExcuteQuery(Server account, string sql, DataGridView dgv)
        {
            dgv.Rows.Clear();
            var result = MyService.ExcuteSql(account, sql);
            if (result != null)
            {
                AddRecords(dgv, result);
                ShowRecordCount(result, account.IP, 1, PageSize);
            }

        }


        /// <summary>
        /// 执行当前SQL
        /// </summary>
        private void RunSql()
        {
            var tp = tabControl1.SelectedTab;
            if (tp == null) return;
            Server account = null;
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
                    if (tbox.Tag is QueryBox)
                    {
                        account = (tbox.Tag as QueryBox).Server;
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
                    var lastPos = tbox.SelectionStart;
                    tbox.Select(firstPos, lastPos - firstPos);
                }
                text = tbox.SelectedText;

                ExcuteQuery(account, text, dgv);
            }
        }

        private void ComputingMesuringPoints(Server account)
        {
            string sql = "";

            StableDto stable = null;
            DataBaseDto db = null;

            var tab = new TabPage(account.IP + "->MesuringPoints");
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



        private NodeItem GetNodeItem(TreeNode node)
        {
            NodeItem item = new NodeItem();
            TreeNode svrNode = null, dbNode = null, sNode = null, tNode = null;
            if (node.Tag is Server)
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

            item.Server = svrNode?.Tag as Server;
            item.Db = dbNode?.Tag as DataBaseDto;
            item.STable = sNode?.Tag as StableDto;
            item.Node = node;

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

        private void CreateTable(Server account, string tableName)
        {
            var key = $"{tableName}@{account.IP}";
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
            var account = new Server();

            if (node.Tag is StableDto)//超级表
            {
                var stable = (node.Tag as StableDto);
                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is Server)
                        account = (svrNode.Tag as Server);
                }
            }
            else if (node.Tag is TableDto) //表
            {
                if (node.Parent != null && node.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is Server)
                        account = (svrNode.Tag as Server);
                }
                else if (node.Parent?.Parent != null && node.Parent.Parent.Tag is DataBaseDto)
                {
                    db = node.Parent.Parent.Tag as DataBaseDto;
                    var svrNode = node.Parent.Parent.Parent;
                    if (svrNode != null && svrNode.Tag is Server)
                        account = (svrNode.Tag as Server);
                }
            }
            db.Account = account;

            return db;
        }

        private void SetMenu(List<ToolStripMenuItem> items,List<ToolStripSeparator> lines =null)
        {
            m_newsvr.Visible = false;
            m_editsvr.Visible = false;
            m_deletesvr.Visible = false;
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
            m_export.Visible = false;
            m_import.Visible = false;
            m_imports.Visible = false;
            //分割线
            sp1.Visible = false;
            sp2.Visible = false;
            sp3.Visible = false;
            sp4.Visible = false;

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

        /// <summary>
        /// 获取用户输入的词
        /// </summary>
        /// <param name="txtBox"></param>
        /// <returns></returns>
        private string GetInputText(TextBox txtBox)
        {
            //捕获键入字符
            var leftPos = txtBox.GetFirstCharIndexOfCurrentLine();
            var line = txtBox.GetLineFromCharIndex(leftPos);
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

            }


            return text;
        }

        /// <summary>
        /// 替换当前输入词
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="txt"></param>
        private void ReplaceInputText(TextBox txtBox, string txt)
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
        private void ShowTipBox(TextBox txtBox,Keys key)
        {
            if ((key < Keys.D0 || key > Keys.Z) && key != Keys.Back && key != Keys.OemPeriod) //合法字符：0..8,A..Z,esc,.
            {
                return;
            }

            var svr = (txtBox.Tag as QueryBox).Server;
            if ((txtBox.Tag as QueryBox).DbDict.Count==0)
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
                var found = dict.Where(t => t.Text.StartsWith(text)).OrderBy(t=>t.Text).Select(t=>t.Text).ToArray();
                if (found.Length > 0)
                {
                    //捕获光标位置
                    var p = FormHelper.GetCursorPos(txtBox);
                    TipBox.Items.Clear();
                    TipBox.Items.AddRange(found);
                    if (TipBox.SelectedIndex == -1)
                    {
                        TipBox.SelectedIndex = 0;
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
        /// 保存当前服务器树到配置文件
        /// </summary>
        /// <returns></returns>
        private bool SaveConfigServers()
        {
            var svrList = new List<Server>();
            for(int i=0;i<treeView1.Nodes.Count;i++)
            {
                var item = GetNodeItem(treeView1.Nodes[i]);
                svrList.Add(item.Server);
            }

            MyConfig.ServerList = svrList;
            FileHelper.SaveServers(svrList);//保存到配置文件
            return true;
        }

        /// <summary>
        /// 导出表/超级表的所有子表文件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ExportTable(NodeItem item, string folderName, List<string> tblist)
        {
            var ret = false;

            if (item.STable != null)
            {
                if (!folderName.EndsWith("\\")) folderName += "\\";
                folderName = $"{folderName}{item.STable.ToString()}";//文件太多，建超级表文件夹
                if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            }

            var filedList = new List<string>();//字段名列表
            var tmpSql = $"describe {item.Db}.{item.STable}";
            var fResult = MyService.ExcuteSql(item.Server, tmpSql);
            if (fResult != null)
            {
                foreach (var rec in fResult.RecordList)
                {
                    if (rec.Count < 3 || rec[3] == "TAG") continue;
                    var fname = rec[0];//字段名
                    if (rec[1] != "INT" && rec[1] != "FLOAT" && rec[1] != "BOOL")
                    {
                        fname = $"'{fname}'";
                    }
                    filedList.Add(fname);
                }
            }

            psBar.Value = 0;
            psBar.Maximum = tblist.Count;
            foreach (var tb in tblist)
            {
                ts2.Text = $"Exporting {tb}...";
                statusStrip1.Refresh();
                var tags = "";
                var sql = $"show create table {item.Db}.{tb}";
                var tagResult = MyService.ExcuteSql(item.Server, sql);
                if (tagResult != null)
                {
                    tags = tagResult.RecordList[0][1];
                    var p1 = tags.IndexOf("TAGS ");
                    if (p1 == -1) continue;
                    tags = tags.Substring(p1, tags.Length - p1);//"tags (...)"
                }

                sql = $"select * from {item.Db}.{tb}";
                var result = MyService.ExcuteSql(item.Server, sql);
                if (result != null)
                {
                    var recs = new List<List<string>>();
                    var myflist = new List<string>();
                    myflist.AddRange(filedList);
                    if (tags != "") myflist.Add(tags);//将tag存入字段行末尾
                    recs.Add(myflist);
                    recs.AddRange(result.RecordList);
                    ret = FileHelper.WriteListToTextFile($"{folderName}\\{tb}.txt", recs);
                }

                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;
            }


            return ret;

        }

        /// <summary>
        /// 导入子表(文件夹)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ImportTable(NodeItem item, string folderName)
        {
            var ret = false;

            //遍历文件
            DirectoryInfo dir = new DirectoryInfo(folderName);
            FileSystemInfo[] files = dir.GetFileSystemInfos();

            psBar.Value = 0;
            psBar.Maximum = files.Length;

            foreach (var file in files)
            {
                if (file.Attributes == FileAttributes.Directory) continue;//忽略文件夹

                var recs = FileHelper.ReadTextFileToList(file.FullName);//读取记录
                if (recs.Count == 0) continue;
                var fields = recs[0]; //读取字段列表和TAGS
                var tags = "";
                if (fields[fields.Count - 1].StartsWith("TAGS"))
                {
                    tags = fields[fields.Count - 1].Replace("\"","'");
                    fields.RemoveAt(fields.Count - 1);
                }

                //生成语句头
                var headSql = new StringBuilder();//语句头
                headSql.Append($"insert into {item.Db}.{file.Name.Replace(file.Extension,"")}");//首行//字段名
                if (item.Table == null)
                {
                    headSql.Append($" using {item.Db}.{item.STable} {tags}");//引用超级表TAGS
                }
                headSql.Append(" values ");

                var sqlList = new List<string>();//sql语句集
                var sql = new StringBuilder();

                for (int i = 1; i < recs.Count; i++)
                {
                    var recStr = new List<string>();
                    for (int j = 0; j < recs[i].Count; j++)
                    {
                        var value = recs[i][j];
                        if (fields[j].StartsWith("'")) value = $"'{value}'"; //字符型加引号
                        recStr.Add(value);
                    }
                    sql.Append($"({string.Join(",",recStr)})");//添加一条记录

                    if (i % 1000 == 0) //每页单独一条SQL语句
                    {
                        sqlList.Add(headSql.ToString()+ sql.ToString());
                        sql.Clear();
                    }
                }
                if (sql.Length > 0)
                    sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句

                //语句生成完成，开始执行
                foreach (var sq in sqlList)
                {
                    var result= ExcuteSql(item.Server, sq);

                }

                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;

            }//单个文件结束


            return ret;

        }


        /// <summary>
        /// 导入超级表文本
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ImportStable(NodeItem item, string fileName)
        {
            var ret = false;


            var recs = FileHelper.ReadTextFileToList(fileName);//读取记录
            var fields = recs[0]; //读取字段列表和TAGS
            var tags = "";
            if (fields[fields.Count - 1].ToLower().StartsWith("tags"))
            {
                tags = fields[fields.Count - 1].Replace("\"", "'");
                fields.RemoveAt(fields.Count - 1);
            }



            var tablePreName = "power_l_";//=====================================

            var sqlList = new List<string>();//sql语句集
            var sql = new StringBuilder();//单条语句
            var headSql = new StringBuilder();//语句头
            var tagPos = fields.Count;//首个tag的索引位置
            var currentTag = "";
            for (int i = 1; i < recs.Count; i++)
            {
                if (recs[i][tagPos] != currentTag) //新子表
                {
                    if (sql.Length > 0)//完成上一子表的SQL语句
                        sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句
                    sql.Clear();//清除已完成语句
                    currentTag = recs[i][tagPos];//产生新TAG
                    headSql.Clear();//生成新子表的SQL语句头
                    headSql.Append($"insert into {item.Db}.{tablePreName}{currentTag}");//子表名
                    headSql.Append($" using {item.Db}.{item.STable} tags('{currentTag}','null')");//引用超级表TAGS =======================
                    headSql.Append(" values ");
                }

                var recStr = new List<string>();
                for (int j = 0; j < fields.Count; j++) //========================
                {
                    var value = recs[i][j];
                    if (fields[j].StartsWith("'")) value = $"'{value}'"; //字符型加引号
                    recStr.Add(value);
                }
                sql.Append($"({string.Join(",", recStr)})");//添加一条记录

                if (i % 1000 == 0) //每页单独一条SQL语句
                {
                    sqlList.Add(headSql.ToString() + sql.ToString());
                    sql.Clear();
                }
            }
            if (sql.Length > 0)
                sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句

            //语句生成完成，开始执行
            psBar.Value = 0;
            psBar.Maximum = sqlList.Count;
            foreach (var sq in sqlList)
            {
                var result = ExcuteSql(item.Server, sq);
                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;
            }


            return ret;

        }


    }
}
