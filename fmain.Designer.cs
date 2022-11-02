
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_opensvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_closesvr = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createdb = new System.Windows.Forms.ToolStripMenuItem();
            this.m_dropdb = new System.Windows.Forms.ToolStripMenuItem();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_table = new System.Windows.Forms.ToolStripMenuItem();
            this.m_field = new System.Windows.Forms.ToolStripMenuItem();
            this.m_point = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createsuper = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createtable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_droptable = new System.Windows.Forms.ToolStripMenuItem();
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menuText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_run = new System.Windows.Forms.ToolStripMenuItem();
            this.m_record = new System.Windows.Forms.ToolStripMenuItem();
            this.spInner = new System.Windows.Forms.SplitContainer();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spInner)).BeginInit();
            this.spInner.Panel1.SuspendLayout();
            this.spInner.Panel2.SuspendLayout();
            this.spInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // spMain
            // 
            resources.ApplyResources(this.spMain, "spMain");
            this.spMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.treeView1);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.spInner);
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
            this.m_opensvr,
            this.m_closesvr,
            this.m_createdb,
            this.m_dropdb,
            this.sp1,
            this.m_table,
            this.m_field,
            this.m_point,
            this.m_createsuper,
            this.m_createtable,
            this.m_droptable,
            this.sp2,
            this.m_query});
            this.menuTree.Name = "menuTree";
            resources.ApplyResources(this.menuTree, "menuTree");
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
            // sp1
            // 
            this.sp1.Name = "sp1";
            resources.ApplyResources(this.sp1, "sp1");
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
            // sp2
            // 
            this.sp2.Name = "sp2";
            resources.ApplyResources(this.sp2, "sp2");
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
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts2,
            this.ts3,
            this.ts1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
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
            this.panel1.Controls.Add(this.spMain);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
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
            // spInner
            // 
            resources.ApplyResources(this.spInner, "spInner");
            this.spInner.Name = "spInner";
            // 
            // spInner.Panel1
            // 
            this.spInner.Panel1.Controls.Add(this.tabControl1);
            this.spInner.Panel1.Controls.Add(this.panel2);
            // 
            // spInner.Panel2
            // 
            this.spInner.Panel2.Controls.Add(this.lblInfo);
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // fmain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuText.ResumeLayout(false);
            this.spInner.Panel1.ResumeLayout(false);
            this.spInner.Panel2.ResumeLayout(false);
            this.spInner.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spInner)).EndInit();
            this.spInner.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripStatusLabel ts1;
        private System.Windows.Forms.ToolStripStatusLabel ts2;
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
        private System.Windows.Forms.SplitContainer spInner;
        private System.Windows.Forms.Label lblInfo;
    }
}

