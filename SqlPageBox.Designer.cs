
namespace TDEngineClient
{
    partial class SqlPageBox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPage = new System.Windows.Forms.Panel();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.txtCurrentPage);
            this.pnlPage.Controls.Add(this.btnLast);
            this.pnlPage.Controls.Add(this.btnNext);
            this.pnlPage.Controls.Add(this.btnPre);
            this.pnlPage.Controls.Add(this.btnFirst);
            this.pnlPage.Location = new System.Drawing.Point(264, 7);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(212, 34);
            this.pnlPage.TabIndex = 11;
            this.pnlPage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPage_Paint);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLast.Location = new System.Drawing.Point(168, 5);
            this.btnLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(36, 24);
            this.btnLast.TabIndex = 9;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.PageButtonClick);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(136, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 24);
            this.btnNext.TabIndex = 10;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.PageButtonClick);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPre.Location = new System.Drawing.Point(41, 5);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(36, 24);
            this.btnPre.TabIndex = 11;
            this.btnPre.Tag = "";
            this.btnPre.Text = "<";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.PageButtonClick);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFirst.Location = new System.Drawing.Point(6, 5);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(36, 24);
            this.btnFirst.TabIndex = 12;
            this.btnFirst.Tag = "";
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.PageButtonClick);
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentPage.Location = new System.Drawing.Point(78, 8);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(51, 18);
            this.txtCurrentPage.TabIndex = 13;
            this.txtCurrentPage.Text = "1";
            this.txtCurrentPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(16, 14);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(89, 19);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "lblText";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(165, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(63, 15);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "lblInfo";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SqlPageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pnlPage);
            this.Name = "SqlPageBox";
            this.Size = new System.Drawing.Size(527, 50);
            this.Resize += new System.EventHandler(this.SqlPageBox_Resize);
            this.pnlPage.ResumeLayout(false);
            this.pnlPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblText;
    }
}
