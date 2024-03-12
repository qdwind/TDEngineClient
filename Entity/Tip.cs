using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class Tip
    {
        public string Text { get; set; }
        public TipType Type { get; set; }

        public string Remark { get; set; }
        public string Keywords { get; set; }

        public Tip(string text,string remark,TipType type)
        {
            Text = text;
            Remark = remark;
            Type = type;
        }

        public override string ToString()
        {
            return Text;
        }

    }



}
