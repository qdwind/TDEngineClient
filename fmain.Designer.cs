
namespace TDEngineClient
{
    partial class fmain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmain));
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.psBar = new System.Windows.Forms.ProgressBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_newsvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editsvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deletesvr = new System.Windows.Forms.ToolStripMenuItem();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_opensvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_closesvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createdb = new System.Windows.Forms.ToolStripMenuItem();
            this.m_dropdb = new System.Windows.Forms.ToolStripMenuItem();
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_table = new System.Windows.Forms.ToolStripMenuItem();
            this.m_field = new System.Windows.Forms.ToolStripMenuItem();
            this.m_point = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createsuper = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createtable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_droptable = new System.Windows.Forms.ToolStripMenuItem();
            this.sp3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_export = new System.Windows.Forms.ToolStripMenuItem();
            this.m_import = new System.Windows.Forms.ToolStripMenuItem();
            this.sp4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_query = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_run = new System.Windows.Forms.ToolStripMenuItem();
            this.m_record = new System.Windows.Forms.ToolStripMenuItem();
            this.m_export_tables = new System.Windows.Forms.ToolStripMenuItem();
            this.m_export_stable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_export_sql = new System.Windows.Forms.ToolStripMenuItem();
            this.m_impor_tables = new System.Windows.Forms.ToolStripMenuItem();
            this.m_impor_stable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_impor_sql = new System.Windows.Forms.ToolStripMenuItem();
            this.m_imports = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuText.SuspendLayout();
            this.SuspendLayout();
            // 
            // spMain
            // 
            this.spMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            resources.ApplyResources(this.spMain, "spMain");
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.psBar);
            this.spMain.Panel1.Controls.Add(this.treeView1);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.tabControl1);
            this.spMain.Panel2.Controls.Add(this.panel2);
            // 
            // psBar
            // 
            resources.ApplyResources(this.psBar, "psBar");
            this.psBar.Name = "psBar";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.menuTree;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 24;
            this.treeView1.Name = "treeView1";
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // menuTree
            // 
            this.menuTree.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_newsvr,
            this.m_editsvr,
            this.m_deletesvr,
            this.sp1,
            this.m_opensvr,
            this.m_closesvr,
            this.m_createdb,
            this.m_dropdb,
            this.sp2,
            this.m_table,
            this.m_field,
            this.m_point,
            this.m_createsuper,
            this.m_createtable,
            this.m_droptable,
            this.sp3,
            this.m_export,
            this.m_import,
            this.sp4,
            this.m_query});
            this.menuTree.Name = "menuTree";
            resources.ApplyResources(this.menuTree, "menuTree");
            // 
            // m_newsvr
            // 
            this.m_newsvr.Name = "m_newsvr";
            resources.ApplyResources(this.m_newsvr, "m_newsvr");
            this.m_newsvr.Click += new System.EventHandler(this.m_newsvr_Click);
            // 
            // m_editsvr
            // 
            this.m_editsvr.Name = "m_editsvr";
            resources.ApplyResources(this.m_editsvr, "m_editsvr");
            this.m_editsvr.Click += new System.EventHandler(this.m_editsvr_Click);
            // 
            // m_deletesvr
            // 
            this.m_deletesvr.Name = "m_deletesvr";
            resources.ApplyResources(this.m_deletesvr, "m_deletesvr");
            this.m_deletesvr.Click += new System.EventHandler(this.m_deletesvr_Click);
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            resources.ApplyResources(this.sp1, "sp1");
            // 
            // m_opensvr
            // 
            this.m_opensvr.Name = "m_opensvr";
            resources.ApplyResources(this.m_opensvr, "m_opensvr");
            this.m_opensvr.Click += new System.EventHandler(this.m_opensvr_Click);
            // 
            // m_closesvr
            // 
            this.m_closesvr.Name = "m_closesvr";
            resources.ApplyResources(this.m_closesvr, "m_closesvr");
            this.m_closesvr.Click += new System.EventHandler(this.m_closesvr_Click);
            // 
            // m_createdb
            // 
            this.m_createdb.Name = "m_createdb";
            resources.ApplyResources(this.m_createdb, "m_createdb");
            this.m_createdb.Tag = "1";
            this.m_createdb.Click += new System.EventHandler(this.m_command_Click);
            // 
            // m_dropdb
            // 
            this.m_dropdb.Name = "m_dropdb";
            resources.ApplyResources(this.m_dropdb, "m_dropdb");
            this.m_dropdb.Tag = "2";
            this.m_dropdb.Click += new System.EventHandler(this.m_command_Click);
            // 
            // sp2
            // 
            this.sp2.Name = "sp2";
            resources.ApplyResources(this.sp2, "sp2");
            // 
            // m_table
            // 
            this.m_table.Name = "m_table";
            resources.ApplyResources(this.m_table, "m_table");
            this.m_table.Click += new System.EventHandler(this.m_table_Click);
            // 
            // m_field
            // 
            this.m_field.Name = "m_field";
            resources.ApplyResources(this.m_field, "m_field");
            this.m_field.Click += new System.EventHandler(this.m_field_Click);
            // 
            // m_point
            // 
            this.m_point.Name = "m_point";
            resources.ApplyResources(this.m_point, "m_point");
            this.m_point.Click += new System.EventHandler(this.m_point_Click);
            // 
            // m_createsuper
            // 
            this.m_createsuper.Name = "m_createsuper";
            resources.ApplyResources(this.m_createsuper, "m_createsuper");
            this.m_createsuper.Tag = "3";
            this.m_createsuper.Click += new System.EventHandler(this.m_command_Click);
            // 
            // m_createtable
            // 
            this.m_createtable.Name = "m_createtable";
            resources.ApplyResources(this.m_createtable, "m_createtable");
            this.m_createtable.Tag = "5";
            this.m_createtable.Click += new System.EventHandler(this.m_command_Click);
            // 
            // m_droptable
            // 
            this.m_droptable.Name = "m_droptable";
            resources.ApplyResources(this.m_droptable, "m_droptable");
            this.m_droptable.Tag = "6";
            this.m_droptable.Click += new System.EventHandler(this.m_command_Click);
            // 
            // sp3
            // 
            this.sp3.Name = "sp3";
            resources.ApplyResources(this.sp3, "sp3");
            // 
            // m_export
            // 
            this.m_export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_export_tables,
            this.m_export_stable,
            this.m_export_sql});
            this.m_export.Name = "m_export";
            resources.ApplyResources(this.m_export, "m_export");
            // 
            // m_import
            // 
            this.m_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_impor_tables,
            this.m_impor_stable,
            this.m_impor_sql});
            this.m_import.Name = "m_import";
            resources.ApplyResources(this.m_import, "m_import");
            // 
            // sp4
            // 
            this.sp4.Name = "sp4";
            resources.ApplyResources(this.sp4, "sp4");
            // 
            // m_query
            // 
            this.m_query.Name = "m_query";
            resources.ApplyResources(this.m_query, "m_query");
            this.m_query.Click += new System.EventHandler(this.m_query_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "server.ico");
            this.imageList1.Images.SetKeyName(1, "db.ico");
            this.imageList1.Images.SetKeyName(2, "stable.ico");
            this.imageList1.Images.SetKeyName(3, "table.ico");
            this.imageList1.Images.SetKeyName(4, "systable.ico");
            this.imageList1.Images.SetKeyName(5, "serveropen.ico");
            this.imageList1.Images.SetKeyName(6, "dbopen.ico");
            this.imageList1.Images.SetKeyName(7, "run.ico");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPre);
            this.panel2.Controls.Add(this.btnFirst);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // btnLast
            // 
            resources.ApplyResources(this.btnLast, "btnLast");
            this.btnLast.Name = "btnLast";
            this.btnLast.Tag = "1";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = "3";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.Name = "btnPre";
            this.btnPre.Tag = "2";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            resources.ApplyResources(this.btnFirst, "btnFirst");
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Tag = "0";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConnectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeServerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            resources.ApplyResources(this.newConnectionToolStripMenuItem, "newConnectionToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // closeServerToolStripMenuItem
            // 
            this.closeServerToolStripMenuItem.Name = "closeServerToolStripMenuItem";
            resources.ApplyResources(this.closeServerToolStripMenuItem, "closeServerToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.explorerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Checked = true;
            this.explorerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            resources.ApplyResources(this.explorerToolStripMenuItem, "explorerToolStripMenuItem");
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQueryToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
            // 
            // newQueryToolStripMenuItem
            // 
            this.newQueryToolStripMenuItem.Name = "newQueryToolStripMenuItem";
            resources.ApplyResources(this.newQueryToolStripMenuItem, "newQueryToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts2,
            this.ts3,
            this.ts1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // ts2
            // 
            resources.ApplyResources(this.ts2, "ts2");
            this.ts2.Name = "ts2";
            // 
            // ts3
            // 
            resources.ApplyResources(this.ts3, "ts3");
            this.ts3.Name = "ts3";
            this.ts3.Spring = true;
            // 
            // ts1
            // 
            resources.ApplyResources(this.ts1, "ts1");
            this.ts1.Name = "ts1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.spMain);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // menuText
            // 
            this.menuText.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_run,
            this.m_record});
            this.menuText.Name = "menuText";
            resources.ApplyResources(this.menuText, "menuText");
            // 
            // m_run
            // 
            this.m_run.Name = "m_run";
            resources.ApplyResources(this.m_run, "m_run");
            this.m_run.Click += new System.EventHandler(this.m_run_Click);
            // 
            // m_record
            // 
            this.m_record.Name = "m_record";
            resources.ApplyResources(this.m_record, "m_record");
            this.m_record.Click += new System.EventHandler(this.m_record_Click);
            // 
            // m_export_tables
            // 
            this.m_export_tables.Name = "m_export_tables";
            resources.ApplyResources(this.m_export_tables, "m_export_tables");
            this.m_export_tables.Click += new System.EventHandler(this.m_export_tables_Click);
            // 
            // m_export_stable
            // 
            this.m_export_stable.Name = "m_export_stable";
            resources.ApplyResources(this.m_export_stable, "m_export_stable");
            // 
            // m_export_sql
            // 
            this.m_export_sql.Name = "m_export_sql";
            resources.ApplyResources(this.m_export_sql, "m_export_sql");
            // 
            // m_impor_tables
            // 
            this.m_impor_tables.Name = "m_impor_tables";
            resources.ApplyResources(this.m_impor_tables, "m_impor_tables");
            this.m_impor_tables.Click += new System.EventHandler(this.m_impor_tables_Click);
            // 
            // m_impor_stable
            // 
            this.m_impor_stable.Name = "m_impor_stable";
            resources.ApplyResources(this.m_impor_stable, "m_impor_stable");
            this.m_impor_stable.Click += new System.EventHandler(this.m_impor_stable_Click);
            // 
            // m_impor_sql
            // 
            this.m_impor_sql.Name = "m_impor_sql";
            resources.ApplyResources(this.m_impor_sql, "m_impor_sql");
            // 
            // m_imports
            // 
            this.m_imports.Name = "m_imports";
            resources.ApplyResources(this.m_imports, "m_imports");
            // 
            // fmain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.menuTree.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripStatusLabel ts3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip menuTree;
        private System.Windows.Forms.ToolStripMenuItem m_table;
        private System.Windows.Forms.ToolStripMenuItem m_field;
        private System.Windows.Forms.ToolStripMenuItem m_query;
        private System.Windows.Forms.ToolStripMenuItem m_opensvr;
        private System.Windows.Forms.ToolStripMenuItem m_closesvr;
        private System.Windows.Forms.ToolStripSeparator sp1;
        private System.Windows.Forms.ContextMenuStrip menuText;
        private System.Windows.Forms.ToolStripMenuItem m_record;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem m_run;
        private System.Windows.Forms.ToolStripMenuItem m_point;
        private System.Windows.Forms.ToolStripSeparator sp2;
        private System.Windows.Forms.ToolStripMenuItem m_createdb;
        private System.Windows.Forms.ToolStripMenuItem m_dropdb;
        private System.Windows.Forms.ToolStripMenuItem m_createsuper;
        private System.Windows.Forms.ToolStripMenuItem m_createtable;
        private System.Windows.Forms.ToolStripMenuItem m_droptable;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_newsvr;
        private System.Windows.Forms.ToolStripMenuItem m_editsvr;
        private System.Windows.Forms.ToolStripMenuItem m_deletesvr;
        private System.Windows.Forms.ToolStripSeparator sp4;
        private System.Windows.Forms.ToolStripMenuItem m_export;
        private System.Windows.Forms.ToolStripMenuItem m_import;
        private System.Windows.Forms.ToolStripStatusLabel ts2;
        private System.Windows.Forms.ToolStripStatusLabel ts1;
        private System.Windows.Forms.ProgressBar psBar;
        private System.Windows.Forms.ToolStripSeparator sp3;
        private System.Windows.Forms.ToolStripMenuItem m_export_tables;
        private System.Windows.Forms.ToolStripMenuItem m_export_stable;
        private System.Windows.Forms.ToolStripMenuItem m_export_sql;
        private System.Windows.Forms.ToolStripMenuItem m_impor_tables;
        private System.Windows.Forms.ToolStripMenuItem m_impor_stable;
        private System.Windows.Forms.ToolStripMenuItem m_impor_sql;
        private System.Windows.Forms.ToolStripMenuItem m_imports;
    }
}

