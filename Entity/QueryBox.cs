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
        public TAccount Server { get; set; }


        public List<string> TipsDict = new List<string>(); //提示字典
    }
}
