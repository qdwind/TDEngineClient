using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class FileHeader
    {
        /// <summary>
        /// TAG列表
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
        /// <summary>
        /// 子表名（其中%1%表示嵌入tag1）
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 根据文件头文本，生成文件头实例
        /// #tags=mac_addr,projectid;tablename=power_l_%1%#
        /// tags必须在前
        /// </summary>
        /// <param name="headerText"></param>
        public FileHeader(string headerText)
        {
            if (!headerText.StartsWith("#") || !headerText.EndsWith("#") || headerText.Length<8) return;//合法性校验
            headerText = headerText.Substring(1, headerText.Length - 2);
            var paraList = headerText.Split(';');
            foreach (var para in paraList)
            {
                if (para.ToLower().StartsWith("tags="))
                {
                    Tags = para.Substring(5, para.Length - 5).Split(',').ToList();
                }
                else if (para.ToLower().StartsWith("tablename="))
                {
                    var tmp = para.Substring(10, para.Length - 10);
                    var ind = tmp.IndexOf('%');
                    if (ind > -1 && int.TryParse(tmp.Substring(ind+1,1),out int tagIndex))
                    {
                        var tag = Tags[tagIndex - 1];
                        tmp.Replace($"%{tagIndex}%", tag);//将参数替换成tag名
                    }
                }

            }

        }


    }
}
