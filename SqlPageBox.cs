using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDEngineClient
{
    public partial class SqlPageBox : UserControl
    {
        private long recordCount;
        /// <summary>
        /// 记录数
        /// </summary>
        public long RecordCount 
        {
            get { return recordCount; }
            set
            {
                recordCount = value;
                if (PageSize == 0) PageSize = 100;//禁止将页面记录设置为0
                if (recordCount % PageSize > 0)
                    Pages = recordCount / PageSize + 1;
                else
                    Pages = recordCount / PageSize;
            }
        }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; } = 100;
        /// <summary>
        /// 页数
        /// </summary>
        public long Pages { get; private set; }

        private long currentPage =1;
        /// <summary>
        /// 当前页
        /// </summary>
        public long CurrentPage { 
            get { return currentPage; }
            set 
            {
                if (value > Pages)
                {
                    currentPage = Pages;//当前页不能超出总页数
                }
                else if(value<1)
                {
                    currentPage = 1;//当前页不能小于1
                }
                else
                {
                    currentPage = value;
                    RecordFrom = (currentPage - 1) * PageSize;
                    RecordTo = (currentPage == Pages ? recordCount : RecordFrom + PageSize) - 1;
                }
                txtCurrentPage.Text = currentPage.ToString();
            }
        }
        /// <summary>
        /// 记录起始数(下标从0开始)
        /// </summary>
        public long RecordFrom { get;private set; }
        /// <summary>
        /// 记录截止数(下标从0开始)
        /// </summary>
        public long RecordTo { get; private set; }

        private bool showPageInfo = true;
        /// <summary>
        /// 是否显示分页信息
        /// </summary>
        public bool ShowPageInfo { get { return showPageInfo; } set { showPageInfo = value; lblInfo.Visible = value; } }
        private bool showText = true;
        /// <summary>
        /// 是否显示文本信息
        /// </summary>
        public bool ShowText { get { return showText; } set { showText = value; lblText.Visible = value; } }

        public SqlPageBox()
        {
            InitializeComponent();
            lblText.Text = "";
            pnlPage.Top = 0;
            this.Height = pnlPage.Height;
            lblInfo.Top = 8;
            lblInfo.Text = "";
        }

        private void pnlPage_Paint(object sender, PaintEventArgs e)
        {

        }
        //定义委托
        public delegate void PageChangHandle(object sender, EventArgs e);
        //定义事件
        public event PageChangHandle PageChanged;


        /// <summary>
        /// 翻页按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButtonClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Name == "btnFirst") //首页
            {
                CurrentPage = 1;
            }
            else if (btn.Name == "btnLast") //末页
            {
                CurrentPage = Pages;
            }
            else if (btn.Name == "btnPre") //前页
            {
                CurrentPage = CurrentPage - 1;
            }
            else if (btn.Name == "btnNext") //后页
            {
                CurrentPage = CurrentPage + 1;
            }

            if (ShowPageInfo)
            {
                lblInfo.Text = $"Page[{CurrentPage}/{Pages}]Record[{RecordFrom + 1}-{RecordTo + 1}/{RecordCount}]";
            }

            if (PageChanged != null)
            {
                PageChanged(sender,e );
            }
        }

        private void SqlPageBox_Resize(object sender, EventArgs e)
        {
            pnlPage.Left = this.Width - pnlPage.Width;
            lblInfo.Left = pnlPage.Left - pnlPage.Width;
        }
    }
}
