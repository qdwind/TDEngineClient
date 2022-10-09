
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_createsuper = new System.Windows.Forms.ToolStripMenuItem();
            this.m_createtable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_droptable = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menuText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_run = new System.Windows.Forms.ToolStripMenuItem();
            this.m_record = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuText.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1198, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts2,
            this.ts3,
            this.ts1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1198, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts2
            // 
            this.ts2.AutoSize = false;
            this.ts2.Name = "ts2";
            this.ts2.Size = new System.Drawing.Size(150, 20);
            this.ts2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ts3
            // 
            this.ts3.AutoSize = false;
            this.ts3.Name = "ts3";
            this.ts3.Size = new System.Drawing.Size(1033, 20);
            this.ts3.Spring = true;
            this.ts3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ts1
            // 
            this.ts1.AutoSize = false;
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(150, 20);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 559);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1198, 559);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.menuTree;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 24;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(300, 559);
            this.treeView1.TabIndex = 0;
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
            this.menuTree.Size = new System.Drawing.Size(214, 308);
            // 
            // m_opensvr
            // 
            this.m_opensvr.Name = "m_opensvr";
            this.m_opensvr.Size = new System.Drawing.Size(213, 24);
            this.m_opensvr.Text = "Open Server";
            this.m_opensvr.Click += new System.EventHandler(this.m_opensvr_Click);
            // 
            // m_closesvr
            // 
            this.m_closesvr.Name = "m_closesvr";
            this.m_closesvr.Size = new System.Drawing.Size(213, 24);
            this.m_closesvr.Text = "Close Server";
            this.m_closesvr.Click += new System.EventHandler(this.m_closesvr_Click);
            // 
            // m_createdb
            // 
            this.m_createdb.Name = "m_createdb";
            this.m_createdb.Size = new System.Drawing.Size(213, 24);
            this.m_createdb.Text = "Create Database";
            // 
            // m_dropdb
            // 
            this.m_dropdb.Name = "m_dropdb";
            this.m_dropdb.Size = new System.Drawing.Size(213, 24);
            this.m_dropdb.Text = "Drop Database";
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            this.sp1.Size = new System.Drawing.Size(210, 6);
            // 
            // m_table
            // 
            this.m_table.Name = "m_table";
            this.m_table.Size = new System.Drawing.Size(213, 24);
            this.m_table.Text = "Show Tables";
            this.m_table.Click += new System.EventHandler(this.m_table_Click);
            // 
            // m_field
            // 
            this.m_field.Name = "m_field";
            this.m_field.Size = new System.Drawing.Size(213, 24);
            this.m_field.Text = "Show Fields";
            this.m_field.Click += new System.EventHandler(this.m_field_Click);
            // 
            // m_point
            // 
            this.m_point.Name = "m_point";
            this.m_point.Size = new System.Drawing.Size(213, 24);
            this.m_point.Text = "Measuring Points";
            this.m_point.Click += new System.EventHandler(this.m_point_Click);
            // 
            // sp2
            // 
            this.sp2.Name = "sp2";
            this.sp2.Size = new System.Drawing.Size(210, 6);
            // 
            // m_createsuper
            // 
            this.m_createsuper.Name = "m_createsuper";
            this.m_createsuper.Size = new System.Drawing.Size(213, 24);
            this.m_createsuper.Text = "Create SuperTable";
            // 
            // m_createtable
            // 
            this.m_createtable.Name = "m_createtable";
            this.m_createtable.Size = new System.Drawing.Size(213, 24);
            this.m_createtable.Text = "Create Table";
            // 
            // m_droptable
            // 
            this.m_droptable.Name = "m_droptable";
            this.m_droptable.Size = new System.Drawing.Size(213, 24);
            this.m_droptable.Text = "Drop Table";
            // 
            // m_query
            // 
            this.m_query.Name = "m_query";
            this.m_query.Size = new System.Drawing.Size(213, 24);
            this.m_query.Text = "New Query";
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
            this.tabControl1.Location = new System.Drawing.Point(15, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(471, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(471, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPre);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Location = new System.Drawing.Point(0, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 58);
            this.panel2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(487, 17);
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
            this.numericUpDown1.Size = new System.Drawing.Size(97, 25);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Location = new System.Drawing.Point(618, 17);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(36, 24);
            this.btnLast.TabIndex = 2;
            this.btnLast.Tag = "1";
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(585, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.Tag = "3";
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.Location = new System.Drawing.Point(449, 17);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(36, 24);
            this.btnPre.TabIndex = 2;
            this.btnPre.Tag = "2";
            this.btnPre.Text = "<";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Location = new System.Drawing.Point(415, 17);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(36, 24);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Tag = "0";
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1198, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // menuText
            // 
            this.menuText.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_run,
            this.m_record});
            this.menuText.Name = "menuText";
            this.menuText.Size = new System.Drawing.Size(219, 52);
            // 
            // m_run
            // 
            this.m_run.Name = "m_run";
            this.m_run.Size = new System.Drawing.Size(218, 24);
            this.m_run.Text = "Run SQL";
            this.m_run.Click += new System.EventHandler(this.m_run_Click);
            // 
            // m_record
            // 
            this.m_record.Name = "m_record";
            this.m_record.Size = new System.Drawing.Size(218, 24);
            this.m_record.Text = "General Values SQL";
            this.m_record.Click += new System.EventHandler(this.m_record_Click);
            // 
            // fmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 636);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDEngine Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuTree.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
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
    }
}

