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
            new Tip("select * from","", TipType.Standard,false),
            new Tip("from","", TipType.Standard),
            new Tip(".tables","", TipType.Standard,false),
            new Tip(".stables","", TipType.Standard,false),
            new Tip("database","", TipType.Standard),
            new Tip("using","", TipType.Standard),
            new Tip("tags","", TipType.Standard),
            new Tip("describe","", TipType.Standard),
            new Tip("values","", TipType.Standard),
            new Tip("where","", TipType.Standard),
            new Tip("limit","", TipType.Standard),
            new Tip("limit 100","", TipType.Standard,false),
            new Tip("group by","", TipType.Standard),
            new Tip("group","", TipType.Standard),
            new Tip("order by","", TipType.Standard),
            new Tip("order","", TipType.Standard),
            new Tip("interval()","", TipType.Standard,false),
            new Tip("sliding()","", TipType.Standard,false),
            new Tip("sliding","", TipType.Standard),
            new Tip("interval","", TipType.Standard),
            new Tip("partition","", TipType.Standard),
            new Tip("partition by","", TipType.Standard),
            new Tip("distinct","", TipType.Standard),
            new Tip("union","", TipType.Standard),
            new Tip("tbname in('')","", TipType.Standard,false),
            new Tip("tbname","", TipType.Standard),
            new Tip("case when then else end","", TipType.Standard,false),
            new Tip("like '%'","", TipType.Standard,false),
            new Tip("like","", TipType.Standard),
            new Tip("ts","", TipType.Standard),
            new Tip("ts>=now-1d","", TipType.Standard,false),
            new Tip("ts>='2024-01-01 0:00:00'","", TipType.Standard,false),
            new Tip("ts<='2024-01-01 0:00:00'","", TipType.Standard,false),
            new Tip("now","", TipType.Standard),
            new Tip("1h","时", TipType.Standard,false),
            new Tip("1d","日", TipType.Standard,false),
            new Tip("1w","周", TipType.Standard,false),
            new Tip("1n","月", TipType.Standard,false),
            new Tip("1y","年", TipType.Standard,false),
            new Tip("between","", TipType.Standard),
            new Tip("contains","", TipType.Standard),
            new Tip("match","", TipType.Standard),

            new Tip("by","", TipType.Standard,true,false),
            new Tip("case","", TipType.Standard,true,false),
            new Tip("when","", TipType.Standard,true,false),
            new Tip("then","", TipType.Standard,true,false),
            new Tip("else","", TipType.Standard,true,false),
            new Tip("end","", TipType.Standard,true,false),
            new Tip("and","", TipType.Standard,true,false),
            new Tip("or","", TipType.Standard,true,false),
            new Tip("as","", TipType.Standard,true,false),
            new Tip("in","", TipType.Standard,true,false),
            new Tip("not","", TipType.Standard,true,false),
            new Tip("with","", TipType.Standard,true,false),
            new Tip("is","", TipType.Standard,true,false),
            new Tip("null","", TipType.Standard,true,false),

            new Tip("database","", TipType.Standard),
            new Tip("table","", TipType.Standard),
            new Tip("stable","", TipType.Standard),
            new Tip("stream","", TipType.Standard),
            new Tip("index","", TipType.Standard),
            new Tip("topic","", TipType.Standard),
            new Tip("create","", TipType.Standard),
            new Tip("create table","", TipType.Standard,false),
            new Tip("create stable tags","", TipType.Standard,false),
            new Tip("create stream into as  partition by  interval() sliding()","", TipType.Standard,false),
            new Tip("insert","", TipType.Standard),
            new Tip("values","", TipType.Standard),
            new Tip("insert into () values()","", TipType.Standard,false),
            new Tip("insert into using tags() values()","", TipType.Standard,false),
            new Tip("drop","", TipType.Standard),
            new Tip("drop database","", TipType.Standard,false),
            new Tip("drop table","", TipType.Standard,false),
            new Tip("drop stable","", TipType.Standard,false),
            new Tip("alter","", TipType.Standard),
            new Tip("alter table","", TipType.Standard,false),
            new Tip("alter stable","", TipType.Standard,false),
            new Tip("into","", TipType.Standard),
            new Tip("precision","", TipType.Standard),
            new Tip("duration","", TipType.Standard),
            new Tip("session","", TipType.Standard),
            new Tip("trigger","", TipType.Standard),
            new Tip("keep","", TipType.Standard),
            new Tip("primary ","", TipType.Standard),
            new Tip("key","", TipType.Standard),
            new Tip("level","", TipType.Standard),
            new Tip("exists","", TipType.Standard),
            new Tip("delete","", TipType.Standard),
            new Tip("pause stream","", TipType.Standard),
            new Tip("resume stream","", TipType.Standard),

            new Tip("timestamp","", TipType.Standard),
            new Tip("int","", TipType.Standard),
            new Tip("int unsigned","", TipType.Standard),
            new Tip("bigint","", TipType.Standard),
            new Tip("bigint unsigned","", TipType.Standard),
            new Tip("float","", TipType.Standard),
            new Tip("double","", TipType.Standard),
            new Tip("binary","", TipType.Standard),
            new Tip("smallint","", TipType.Standard),
            new Tip("smallint unsigned","", TipType.Standard),
            new Tip("tinyint","", TipType.Standard),
            new Tip("tinyint unsigned","", TipType.Standard),
            new Tip("bool","", TipType.Standard),
            new Tip("nchar","", TipType.Standard),
            new Tip("json","", TipType.Standard),
            new Tip("varchar","", TipType.Standard),
            new Tip("geometry","", TipType.Standard),
            new Tip("varbinary","", TipType.Standard),


            new Tip("_wstart","", TipType.Functions),
            new Tip("_wsend","", TipType.Functions),
            new Tip("_qstart","用户查询时间起", TipType.Functions),
            new Tip("_qend","用户查询时间止", TipType.Functions),
            new Tip("_rowts","ts列", TipType.Functions),
            new Tip("select server_version();","", TipType.Functions),
            new Tip("show","", TipType.Functions),
            new Tip("show databases","", TipType.Functions),
            new Tip("show create database","", TipType.Functions),
            new Tip("show create stable","", TipType.Functions),
            new Tip("show local variables","", TipType.Functions),
            new Tip("show streams","", TipType.Functions),
            new Tip("count(*)","", TipType.Functions),
            new Tip("count","", TipType.Functions),
            new Tip("sum","", TipType.Functions),
            new Tip("first","", TipType.Functions),
            new Tip("bottom","", TipType.Functions),
            new Tip("last","", TipType.Functions),
            new Tip("top","", TipType.Functions),
            new Tip("max","", TipType.Functions),
            new Tip("min","", TipType.Functions),
            new Tip("avg","", TipType.Functions),
            new Tip("abs","", TipType.Functions),
            new Tip("acos","", TipType.Functions),
            new Tip("asin","", TipType.Functions),
            new Tip("atan","", TipType.Functions),
            new Tip("ceil","", TipType.Functions),
            new Tip("cos","", TipType.Functions),
            new Tip("floor","", TipType.Functions),
            new Tip("log","", TipType.Functions),
            new Tip("pow","", TipType.Functions),
            new Tip("sin","", TipType.Functions),
            new Tip("tan","", TipType.Functions),
            new Tip("sqrt","", TipType.Functions),

            new Tip("char_length","", TipType.Functions),
            new Tip("concat","", TipType.Functions),
            new Tip("concat_ws","", TipType.Functions),
            new Tip("ltrim","", TipType.Functions),
            new Tip("rtrim","", TipType.Functions),
            new Tip("spread","", TipType.Functions),
            new Tip("unique","", TipType.Functions),
            new Tip("lower","", TipType.Functions),
            new Tip("upper","", TipType.Functions),
            new Tip("substr","", TipType.Functions),
            new Tip("length","", TipType.Functions),
            new Tip("cast","", TipType.Functions),
            new Tip("round","", TipType.Functions),
            new Tip("to_char","", TipType.Functions),
            new Tip("to_timestamp","", TipType.Functions),
            new Tip("to_unixtimestamp","", TipType.Functions),
            new Tip("to_iso8601","", TipType.Functions),
            new Tip("to_json","", TipType.Functions),

            new Tip("now","", TipType.Functions),
            new Tip("today","", TipType.Functions),
            new Tip("timediff","", TipType.Functions),
            new Tip("timetruncate","", TipType.Functions),
            new Tip("timezone","", TipType.Functions),



        };
    }
}
