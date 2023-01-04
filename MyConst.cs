using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;

namespace TDEngineClient
{
    public static class MyConst
    {
        public static List<Tip> TipsPublicDict = new List<Tip> //提示字典
        {
            new Tip("select","", TipType.Standard),
            new Tip("select * from","", TipType.Standard),
            new Tip("from","", TipType.Standard),
            new Tip(".tables","", TipType.Standard),
            new Tip(".stables","", TipType.Standard),
            new Tip("database","", TipType.Standard),
            new Tip("using","", TipType.Standard),
            new Tip("tags","", TipType.Standard),
            new Tip("values","", TipType.Standard),
            new Tip("insert into","", TipType.Standard),
            new Tip("where","", TipType.Standard),
            new Tip("limit","", TipType.Standard),
            new Tip("limit 100","", TipType.Standard),
            new Tip("group by","", TipType.Standard),
            new Tip("order by","", TipType.Standard),
            new Tip("first","", TipType.Standard),
            new Tip("last","", TipType.Standard),
            new Tip("tbname in('')","", TipType.Standard),


            new Tip("count(*)","", TipType.Functions),
            new Tip("sum()","", TipType.Functions),
            new Tip("first()","", TipType.Functions),
            new Tip("bottom()","", TipType.Functions),
            new Tip("last()","", TipType.Functions),
            new Tip("top()","", TipType.Functions),
            new Tip("max()","", TipType.Functions),
            new Tip("min()","", TipType.Functions),
            new Tip("avg()","", TipType.Functions),
            new Tip("unique()","", TipType.Functions),

            new Tip("select server_version();","", TipType.Functions),
            new Tip("show databases;","", TipType.Functions),
            new Tip("show create database","", TipType.Functions),
            new Tip("show create stable","", TipType.Functions),
            new Tip("show local variables;","", TipType.Functions),
            new Tip("lower()","", TipType.Functions),
            new Tip("upper()","", TipType.Functions),
            new Tip("concat()","", TipType.Functions),
            new Tip("substr()","", TipType.Functions),
            new Tip("to_unixtimestamp()","", TipType.Functions),
            new Tip("now()","", TipType.Functions),
            new Tip("today()","", TipType.Functions),
            new Tip("round()","", TipType.Functions),
            new Tip("to_iso8601()","", TipType.Functions),
            new Tip("to_json()","", TipType.Functions),
            new Tip("timediff()","", TipType.Functions),
        };
    }
}
