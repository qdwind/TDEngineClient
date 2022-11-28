using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    /// <summary>
    /// 查询窗口类
    /// </summary>
    public class QueryBox
    {
        public string Caption { get; set; } = "";
        public string Text { get; set; } = "";
        public Server Server { get; set; }

        public List<Tip> TipsDict = new List<Tip>(); //公共语法提示字典
        public List<Tip> DbDict = new List<Tip>();   //数据库提示字典
    }
}
