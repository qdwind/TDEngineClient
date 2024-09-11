using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Helper;

namespace TDEngineClient
{
    partial class fmain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lanCode">0:en 1:cn</param>
        private void SetLanguage(int lanCode)
        {
            MyConfig.System.Language = lanCode; //修改语言设置
            FileHelper.SaveSystemConfig(MyConfig.System);//保存到配置文件
            m_en.Checked = lanCode == 0;
            m_cn.Checked = lanCode == 1;

            //更新主窗口的语言显示

            this.Text = lanCode == 0 ? $"{Application.ProductName} {Application.ProductVersion}" : $"TDEngine数据库客户端桌面管理工具 {Application.ProductVersion}";

            //菜单
            fileToolStripMenuItem.Text = lanCode == 0 ? "File" : "文件";
            newConnectionToolStripMenuItem.Text = lanCode == 0 ? "New Connection" : "新建连接";
            closeServerToolStripMenuItem.Text = lanCode == 0 ? "Close Server" : "关闭连接";
            exitToolStripMenuItem.Text = lanCode == 0 ? "Exit" : "退出";

            editToolStripMenuItem.Text = lanCode == 0 ? "Edit" : "编辑";
            copyToolStripMenuItem.Text = lanCode == 0 ? "Copy" : "复制";
            pasteToolStripMenuItem.Text = lanCode == 0 ? "Paste" : "粘贴";
            selectAllToolStripMenuItem.Text = lanCode == 0 ? "Select All" : "全选";

            viewToolStripMenuItem.Text = lanCode == 0 ? "View" : "视图";
            explorerToolStripMenuItem.Text = lanCode == 0 ? "Explorer" : "导航窗格";

            windowToolStripMenuItem.Text = lanCode == 0 ? "Window" : "窗口";
            newQueryToolStripMenuItem.Text = lanCode == 0 ? "New Query" : "新建查询";

            toolToolStripMenuItem.Text = lanCode == 0 ? "Tool" : "工具";
            exportToolStripMenuItem.Text = lanCode == 0 ? "Export..." : "导出...";
            importToolStripMenuItem.Text = lanCode == 0 ? "Import..." : "导入...";
            tableFilesToolStripMenuItem.Text = lanCode == 0 ? "Table Files" : "表";
            stableFileToolStripMenuItem.Text = lanCode == 0 ? "Stable File" : "超级表";
            sQLFileToolStripMenuItem.Text = lanCode == 0 ? "SQL File" : "SQL文件";
            optionsToolStripMenuItem.Text = lanCode == 0 ? "Options" : "选项";

            helpToolStripMenuItem.Text = lanCode == 0 ? "Help" : "帮助";
            m_lan.Text = lanCode == 0 ? "Language" : "语言";
            m_about.Text = lanCode == 0 ? "About" : "关于";

            //树菜单
            m_newsvr.Text = lanCode == 0 ? "New Server..." : "新建服务器...";
            m_editsvr.Text = lanCode == 0 ? "Edit Server" : "编辑服务器";
            m_deletesvr.Text = lanCode == 0 ? "Remove Server" : "删除服务器";
            m_opensvr.Text = lanCode == 0 ? "Open Server" : "打开服务器";
            m_closesvr.Text = lanCode == 0 ? "Close Server" : "关闭服务器";
            m_createdb.Text = lanCode == 0 ? "Create Database" : "创建数据库";
            m_dropdb.Text = lanCode == 0 ? "Drop Database" : "删除数据库";
            m_table.Text = lanCode == 0 ? "Show Tables" : "显示表";
            m_field.Text = lanCode == 0 ? "Show Fields" : "显示字段";
            m_point.Text = lanCode == 0 ? "Measuring Points" : "测点";
            m_createsuper.Text = lanCode == 0 ? "Create SuperTable" : "新建超级表";
            m_createtable.Text = lanCode == 0 ? "Create Table" : "新建表";
            m_droptable.Text = lanCode == 0 ? "Drop Table" : "删除表";
            m_refresh.Text = lanCode == 0 ? "Refresh Database" : "刷新数据库";
            m_export.Text = lanCode == 0 ? "Export..." : "导出...";
            m_import.Text = lanCode == 0 ? "Import" : "导入";
            m_import_tables.Text = lanCode == 0 ? "Table Files" : "表";
            m_import_stable.Text = lanCode == 0 ? "Stable File" : "超级表";
            m_import_sql.Text = lanCode == 0 ? "SQL File" : "SQL文件";
            m_query.Text = lanCode == 0 ? "New Query" : "新建查询";

            //SQL菜单
            m_run.Text = lanCode == 0 ? "Run SQL" : "运行SQL";
            m_record.Text = lanCode == 0 ? "General Values SQL" : "生成数据SQL";
            m_ucase.Text = lanCode == 0 ? "To Upper Case" : "转大写";
            m_lcase.Text = lanCode == 0 ? "To Lower Case" : "转小写";
            m_copy.Text = lanCode == 0 ? "Copy" : "复制";
            m_paste.Text = lanCode == 0 ? "Paste" : "粘贴";
            m_beauti.Text = lanCode == 0 ? "Beautiful SQL" : "美化SQL";
            m_notbeauti.Text = lanCode == 0 ? "Zip SQL" : "压缩SQL";
        }



    }
}
