using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class Tip
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public TipType Type { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        /// 显示颜色
        /// </summary>
        public bool Colored { get; set; }
        /// <summary>
        /// 显示在快捷输入
        /// </summary>
        public bool Visible { get; set; }


        public Tip(string text, string remark, TipType type, bool colored=true,bool visible =true)
        {
            Text = text;
            Remark = remark;
            Type = type;
            Colored = colored;
            Visible = visible;
        }

        public override string ToString()
        {
            return Text;
        }

    }



}
