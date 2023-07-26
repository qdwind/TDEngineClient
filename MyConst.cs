﻿using System;
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
            new Tip("describe","", TipType.Standard),
            new Tip("values","", TipType.Standard),
            new Tip("where","", TipType.Standard),
            new Tip("limit","", TipType.Standard),
            new Tip("limit 100","", TipType.Standard),
            new Tip("group by","", TipType.Standard),
            new Tip("order by","", TipType.Standard),
            new Tip("interval()","", TipType.Standard),
            new Tip("sliding()","", TipType.Standard),
            new Tip("partition by","", TipType.Standard),
            new Tip("distinct","", TipType.Standard),
            new Tip("union","", TipType.Standard),
            new Tip("tbname in('')","", TipType.Standard),
            new Tip("case when then else end","", TipType.Standard),
            new Tip("like '%'","", TipType.Standard),
            new Tip("ts","", TipType.Standard),
            new Tip("ts>='2023-01-01 0:00:00'","", TipType.Standard),
            new Tip("ts<='2023-01-01 0:00:00'","", TipType.Standard),
            new Tip("now","", TipType.Standard),
            new Tip("1m","分", TipType.Standard),
            new Tip("1h","时", TipType.Standard),
            new Tip("1d","日", TipType.Standard),
            new Tip("1w","周", TipType.Standard),
            new Tip("1n","月", TipType.Standard),
            new Tip("1y","年", TipType.Standard),

            new Tip("create","", TipType.Standard),
            new Tip("create table","", TipType.Standard),
            new Tip("create stable tags","", TipType.Standard),
            new Tip("create stream into as  partition by  interval() sliding()","", TipType.Standard),
            new Tip("insert","", TipType.Standard),
            new Tip("insert into () values()","", TipType.Standard),
            new Tip("insert into using tags() values()","", TipType.Standard),
            new Tip("drop","", TipType.Standard),
            new Tip("drop database","", TipType.Standard),
            new Tip("drop table","", TipType.Standard),
            new Tip("drop stable","", TipType.Standard),
            new Tip("alter","", TipType.Standard),
            new Tip("alter table","", TipType.Standard),
            new Tip("alter stable","", TipType.Standard),

            new Tip("_wstart","", TipType.Functions),
            new Tip("_wsend","", TipType.Functions),
            new Tip("_qstart","用户查询时间起", TipType.Functions),
            new Tip("_qend","用户查询时间止", TipType.Functions),
            new Tip("_rowts","ts列", TipType.Functions),
            new Tip("select server_version();","", TipType.Functions),
            new Tip("show databases","", TipType.Functions),
            new Tip("show create database","", TipType.Functions),
            new Tip("show create stable","", TipType.Functions),
            new Tip("show local variables","", TipType.Functions),
            new Tip("show streams","", TipType.Functions),
            new Tip("count(*)","", TipType.Functions),
            new Tip("sum()","", TipType.Functions),
            new Tip("first(*)","", TipType.Functions),
            new Tip("bottom()","", TipType.Functions),
            new Tip("last(*)","", TipType.Functions),
            new Tip("top()","", TipType.Functions),
            new Tip("max()","", TipType.Functions),
            new Tip("min()","", TipType.Functions),
            new Tip("avg()","", TipType.Functions),
            new Tip("abs()","", TipType.Functions),
            new Tip("unique()","", TipType.Functions),
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
