
namespace TDEngineClient
{
    partial class fexport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_sql = new System.Windows.Forms.RadioButton();
            this.rad_stable = new System.Windows.Forms.RadioButton();
            this.rab_tables = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chklist = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtSaveAs = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_sql);
            this.groupBox1.Controls.Add(this.rad_stable);
            this.groupBox1.Controls.Add(this.rab_tables);
            this.groupBox1.Location = new System.Drawing.Point(25, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Format";
            // 
            // rad_sql
            // 
            this.rad_sql.AutoSize = true;
            this.rad_sql.Location = new System.Drawing.Point(305, 45);
            this.rad_sql.Name = "rad_sql";
            this.rad_sql.Size = new System.Drawing.Size(92, 19);
            this.rad_sql.TabIndex = 2;
            this.rad_sql.Text = "SQL File";
            this.rad_sql.UseVisualStyleBackColor = true;
            // 
            // rad_stable
            // 
            this.rad_stable.AutoSize = true;
            this.rad_stable.Location = new System.Drawing.Point(163, 45);
            this.rad_stable.Name = "rad_stable";
            this.rad_stable.Size = new System.Drawing.Size(116, 19);
            this.rad_stable.TabIndex = 1;
            this.rad_stable.Text = "Stable File";
            this.rad_stable.UseVisualStyleBackColor = true;
            // 
            // rab_tables
            // 
            this.rab_tables.AutoSize = true;
            this.rab_tables.Checked = true;
            this.rab_tables.Location = new System.Drawing.Point(31, 45);
            this.rab_tables.Name = "rab_tables";
            this.rab_tables.Size = new System.Drawing.Size(116, 19);
            this.rab_tables.TabIndex = 0;
            this.rab_tables.TabStop = true;
            this.rab_tables.Text = "Table Files";
            this.rab_tables.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(287, 662);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 39);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(153, 663);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 38);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.chklist);
            this.groupBox2.Location = new System.Drawing.Point(23, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 405);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Tables";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(24, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(440, 25);
            this.txtSearch.TabIndex = 15;
            // 
            // chklist
            // 
            this.chklist.FormattingEnabled = true;
            this.chklist.Location = new System.Drawing.Point(24, 61);
            this.chklist.Name = "chklist";
            this.chklist.Size = new System.Drawing.Size(440, 304);
            this.chklist.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnView);
            this.groupBox3.Controls.Add(this.txtSaveAs);
            this.groupBox3.Location = new System.Drawing.Point(25, 539);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 87);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save To";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(439, 29);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(24, 28);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "▼";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtSaveAs
            // 
            this.txtSaveAs.Enabled = false;
            this.txtSaveAs.Location = new System.Drawing.Point(22, 31);
            this.txtSaveAs.Name = "txtSaveAs";
            this.txtSaveAs.Size = new System.Drawing.Size(420, 25);
            this.txtSaveAs.TabIndex = 13;
            this.txtSaveAs.Text = "D:\\";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(30, 374);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(101, 19);
            this.chkAll.TabIndex = 16;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // fexport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 726);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fexport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_sql;
        private System.Windows.Forms.RadioButton rad_stable;
        private System.Windows.Forms.RadioButton rab_tables;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckedListBox chklist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSaveAs;
        private System.Windows.Forms.CheckBox chkAll;
    }
}