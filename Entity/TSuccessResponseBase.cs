using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    /// <summary>
    /// 响应泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TSuccessResponseBase<T> : TResponseBase
    {
        public List<T> data { get; set; } = new List<T>();
    }

    //public class ColumnItem
    //{
    //    public string name { get; set; }
    //    public string type { get; set; }
    //    public int length { get; set; }

    //}

    /// <summary>
    /// 响应基类
    /// </summary>
    public class TResponseBase
    {
        public List<string> head { get; set; } = new List<string>();
        public List<List<object>> column_meta { get; set; } = new List<List<object>>();
        public int rows { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public string desc { get; set; }
    }

    public class TResponse : TResponseBase
    {
        public List<List<object>> data { get; set; } = new List<List<object>>();
    }


}
