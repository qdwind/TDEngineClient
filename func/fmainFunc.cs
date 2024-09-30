using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private DataGridView TipBox = new DataGridView();//提示框

        private const string CAPTION_QUERY = "->"; //查询标签
        private const string CAPTION_SQL = "->Sql"; //创建标签
        private const string CAPTION_POINT = "->MesuringPoints"; //测点

        private DateTime LastDbClickTime; //最近的双击时间




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
            //panel2.Dock = DockStyle.Bottom;

            //清空控件
            this.tabControl1.TabPages.Clear();
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            this.tabControl1.Appearance = TabAppearance.Normal;
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
            TipBox.Width = 400;
            TipBox.Columns.Add("text","text");
            TipBox.Columns.Add("tip", "tip");
            TipBox.Columns[0].Width = 300;
            TipBox.Columns[1].Width = 80;
            TipBox.ReadOnly = true;
            TipBox.AllowUserToAddRows = false;
            TipBox.ColumnHeadersVisible = false;
            TipBox.RowHeadersVisible = false;
            TipBox.EditMode = DataGridViewEditMode.EditProgrammatically;
            TipBox.AllowUserToResizeRows = false;
            TipBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TipBox.BackgroundColor = Color.White;
            TipBox.CellBorderStyle = DataGridViewCellBorderStyle.None;
            
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
        /// 刷新数据库
        /// </summary>
        private void RefreshDB()
        {
            var item = GetNodeItem(treeView1.SelectedNode);

            var account = item.Server; 

            var svrInfo = MyService.GetDbDetail(account,item.Db);
            if (svrInfo.Connected)
            {
                var db = svrInfo.DbList.Where(t => t.Name == item.Db.Name).FirstOrDefault();
                RefreshDbNodes(db, treeView1.SelectedNode);//将数据库表添加到节点上
               
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

        private void RefreshDbNodes(DataBaseDto db, TreeNode dbNode)
        {
            dbNode.Nodes.Clear();//清空数据库下的子节点

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
                dbNode.Nodes.Add(stabItem);
            }

            foreach (var tab in db.SysTables)//系统表
            {
                var tabItem = new TreeNode();
                tabItem.Tag = tab;
                tabItem.Text = $"{tab.table_name}";
                tabItem.ImageIndex = 4;
                tabItem.SelectedImageIndex = 4;
                dbNode.Nodes.Add(tabItem);
            }

            foreach (var tab in db.Tables)//普通表
            {
                var tabItem = new TreeNode();
                tabItem.Tag = tab;
                tabItem.Text = $"{tab.table_name}";
                tabItem.ImageIndex = 3;
                tabItem.SelectedImageIndex = 3;
                dbNode.Nodes.Add(tabItem);
            }

            dbNode.Expand();
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
            var caption = $"{db.Name}@{(string.IsNullOrEmpty(db.Account.AliasName) ? db.Account.IP : db.Account.AliasName)}{CAPTION_QUERY}";

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
                caption = $"{(string.IsNullOrEmpty(account.AliasName) ? account.Url : account.AliasName)}{CAPTION_SQL}";
                text = new string[] { $"create database dbname keep 3650 duration 50" };
            }
            else if (command == SqlCommandType.DropDatabase)
            {
                caption = $"{(string.IsNullOrEmpty(db.Account.AliasName) ? db.Account.IP : db.Account.AliasName)}{CAPTION_SQL}";
                text = new string[] { $"drop database {db.Name}" };
            }
            else if (command == SqlCommandType.CreateStable)
            {
                caption = $"{db.Name}{CAPTION_SQL}";
                text = new string[] { $"create stable {db.Name}.stablename (ts timestamp, intfield int, strfield binary(20)) tags (strfield binary(20))" };
            }
            else if (command == SqlCommandType.DropStable)
            {
                caption = $"{db.Name}{CAPTION_SQL}";
                text = new string[] { $"drop stable {stable.stable_name}" };
            }
            else if (command == SqlCommandType.CreateTable)
            {
                if (stable == null)//直接建表
                {
                    caption = $"{db.Name}{CAPTION_SQL}";
                    text = new string[] { $"create table {db.Name}.tablename (ts timestamp, intfield int, strfield binary(20))" };
                }
                else //在超级表下建子表
                {
                    caption = $"{db.Name}.{stable.stable_name}{CAPTION_SQL}";
                    text = new string[] { $"create table {db.Name}.tablename using {db.Name}.{stable.stable_name} tags ('value1', 'value2')" };
                }
            }
            else if (command == SqlCommandType.DropTable)
            {
                caption = $"{db.Name}{CAPTION_SQL}";
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
            while (tabControl1.TabPages.ContainsKey(caption))
            {
                caption = caption + "0";//避免重复名字
            }

            var tab = new TabPage($"{caption}");
            tab.Name = caption;
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedTab = tab;
            tab.AutoScroll = true;

            var qbox = new QueryBox();//保存查询窗口的信息
            qbox.Server = account;
            qbox.TipsDict.AddRange(MyConst.TipsPublicDict);//添加公用TIPS列表
            qbox.DbDict.AddRange(account.GetTipNames()); //添加数据库表名称列表
            qbox.Caption = $"{account.IP}{(string.IsNullOrEmpty(account.AliasName) ? "" : "(" + account.AliasName + ")")}";

            var myText = new RichBox();
            myText.Multiline = true;
            myText.MaxLength = 655360;
            myText.Height = 400;
            myText.Font = new Font(FontFamily.GenericSansSerif, 12);
            myText.ImeMode = ImeMode.Off;
            myText.ScrollBars = RichTextBoxScrollBars.Vertical;
            myText.Dock = DockStyle.Top;
            myText.Lines = text;
            myText.HideSelection = false;


            myText.Tag = qbox; //保存设置项
            myText.MouseClick += new MouseEventHandler(this.TextBoxMouseClick);
            myText.MouseDoubleClick += new MouseEventHandler(this.TextBoxMouseDoubleClick);
            myText.KeyDown += new KeyEventHandler(this.TextBoxKeyDown);
            myText.KeyUp += new KeyEventHandler(this.TextBoxKeyUp);
            myText.TextChanged += new EventHandler(this.TextBoxTextChanged);
            RefreshColors(myText);


            myText.ContextMenuStrip = menuText;
            ts2.Text = "Press F5 to Run SQL";
            tab.Controls.Add(myText);

            var pnl = CreateQueryPanel(account);//创建查询工具栏
            pnl.Dock = DockStyle.Top;
            tab.Controls.Add(pnl);

            var spl = new Splitter();
            spl.Dock = DockStyle.Top;
            tab.Controls.Add(spl);
            spl.BringToFront();

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
                ts2.Text = sql;
            }

        }


        private void ExcuteQuery(Server account, string sql, DataGridView dgv)
        {
            dgv.Rows.Clear();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = MyService.ExcuteSql(account, sql);
            stopWatch.Stop();
            if (result != null)
            {
                AddRecords(dgv, result);
                //ShowRecordCount(result, account.IP, 1, PageSize);
                ts3.Text = $"{result.RecordList.Count} Records,{stopWatch.ElapsedMilliseconds/1000f}s";
                ts2.Text = sql;
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
            RichBox tbox = null;
            foreach (var ctl in tp.Controls)
            {
                if (ctl is DataGridView)
                {
                    dgv = (ctl as DataGridView);
                }
                else if (ctl is RichBox)
                {
                    tbox = (ctl as RichBox);
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
                    //var line = tbox.GetLineFromCharIndex(firstPos);
                    var lastPos = tbox.SelectionStart;
                    tbox.Select(firstPos, lastPos - firstPos);
                }
                text = tbox.SelectedText;

                ExcuteQuery(account, text, dgv);
            }
        }

        /// <summary>
        /// 转换大小写
        /// </summary>
        private void ChangeCase(bool toUp)
        {
            var tp = tabControl1.SelectedTab;
            if (tp == null) return;
            RichBox tbox = null;
            foreach (var ctl in tp.Controls)
            {
                if (ctl is RichBox)
                {
                    tbox = (ctl as RichBox);
                    break;
                }
            }
            if (tbox != null && !string.IsNullOrEmpty(tbox.SelectedText))
            {
                var text = toUp ? tbox.SelectedText.ToUpper() : tbox.SelectedText.ToLower();
                tbox.SelectedText = text;
            }
        }


        private NodeItem GetNodeItem(TreeNode node)
        {
            NodeItem item = new NodeItem();
            if (node == null) return item;
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
            var key = $"{tableName}@{(string.IsNullOrEmpty(account.AliasName)? account.IP:account.AliasName)}";
            if (tabControl1.TabPages.ContainsKey(key))
            {
                tabControl1.SelectedTab = tabControl1.TabPages[key];
            }
            else
            {
                tabControl1.TabPages.Add(key, key);
                var tab = tabControl1.TabPages[key];
                tab.AutoScroll = true;


                var pageBox = new SqlPageBox();//添加分页栏组件
                pageBox.Dock = DockStyle.Bottom;
                tab.Controls.Add(pageBox);
                pageBox.BringToFront();
                pageBox.PageSize = PageSize;
                pageBox.PageChanged += new SqlPageBox.PageChangHandle(this.PageBox_PageChanged);

                var dgv = new DataGridView();
                dgv.Parent = tab;
                dgv.Dock = DockStyle.Fill;
                //dgv.Dock = DockStyle.None;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BringToFront();

                //dgv.ReadOnly = true;

                var result = MyService.GetRecords(account, tableName, 1, PageSize);
                if (result != null)
                {
                    AddRecords(dgv, result);
                    //ShowRecordCount(result, tableName, 1, PageSize);
                    pageBox.RecordCount = result.Count;
                }
                tabControl1.SelectedTab = tabControl1.TabPages[key];
                tab.Tag = result;
            }

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
            m_createsuper.Visible = false;
            m_createtable.Visible = false;
            m_droptable.Visible = false;
            m_refresh.Visible = false;
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

        public void PageBox_PageChanged(object sender, EventArgs e)
        {
            if (!(sender is SqlPageBox)) return;
            if (!((sender as SqlPageBox).Parent is TabPage)) return;
            var tp = (sender as SqlPageBox).Parent as TabPage;

            if (tp.Tag is RecordDto)
            {
                var table = (tp.Tag as RecordDto);
                var account = table.DB;
                var tableName = table.TableName;

                var currentPage = (sender as SqlPageBox).CurrentPage;


                var result = MyService.GetRecords(account, tableName, currentPage, PageSize);
                if (result != null)
                {
                    foreach (var ctl in tp.Controls)
                    {
                        if (ctl is DataGridView)
                        {
                            AddRecords(ctl as DataGridView, result);
                            //ShowRecordCount(result, tableName, currentPage, PageSize);
                            break;
                        }
                    }

                    tp.Tag = result;
                }
                //numericUpDown1.Value = currentPage;
            }
        }

    }
}
