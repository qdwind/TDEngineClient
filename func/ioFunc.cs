using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;
using TDEngineClient.Helper;
using TDEngineClient.Services;

namespace TDEngineClient
{
    /// <summary>
    /// 导入导出函数
    /// </summary>
    partial class fmain
    {

        #region 导入导出

        /// <summary>
        /// 导出表/超级表的所有子表文件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ExportTable(NodeItem item, string folderName, List<string> tblist)
        {
            var ret = false;

            if (item.STable != null)
            {
                if (!folderName.EndsWith("\\")) folderName += "\\";
                folderName = $"{folderName}{item.STable.ToString()}";//文件太多，建超级表文件夹
                if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            }

            var filedList = new List<string>();//字段名列表
            var tmpSql = $"describe {item.Db}.{item.STable}";
            var fResult = MyService.ExcuteSql(item.Server, tmpSql);
            if (fResult != null)
            {
                foreach (var rec in fResult.RecordList)
                {
                    if (rec.Count < 3 || rec[3] == "TAG") continue;
                    var fname = rec[0];//字段名
                    if (rec[1] != "INT" && rec[1] != "FLOAT" && rec[1] != "BOOL")
                    {
                        fname = $"'{fname}'";
                    }
                    filedList.Add(fname);
                }
            }

            psBar.Value = 0;
            psBar.Maximum = tblist.Count;
            foreach (var tb in tblist)
            {
                ts2.Text = $"Exporting {tb}...";
                statusStrip1.Refresh();
                var tags = "";
                var sql = $"show create table {item.Db}.{tb}";
                var tagResult = MyService.ExcuteSql(item.Server, sql);
                if (tagResult != null)
                {
                    tags = tagResult.RecordList[0][1];
                    var p1 = tags.IndexOf("TAGS ");
                    if (p1 == -1) continue;
                    tags = tags.Substring(p1, tags.Length - p1);//"tags (...)"
                }

                sql = $"select * from {item.Db}.{tb}";
                var result = MyService.ExcuteSql(item.Server, sql);
                if (result != null)
                {
                    var recs = new List<List<string>>();
                    var myflist = new List<string>();
                    myflist.AddRange(filedList);
                    if (tags != "") myflist.Add(tags);//将tag存入字段行末尾
                    recs.Add(myflist);
                    recs.AddRange(result.RecordList);
                    ret = FileHelper.WriteListToTextFile($"{folderName}\\{tb}.txt", recs);
                }

                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;
            }
            ts2.Text = $"Export Completed.";
            psBar.Value = 0;
            return ret;

        }

        /// <summary>
        /// 导入子表(文件夹)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ImportTable(NodeItem item, string folderName)
        {
            var ret = false;

            //遍历文件
            DirectoryInfo dir = new DirectoryInfo(folderName);
            FileSystemInfo[] files = dir.GetFileSystemInfos();

            psBar.Value = 0;
            psBar.Maximum = files.Length;

            foreach (var file in files)
            {
                if (file.Attributes == FileAttributes.Directory) continue;//忽略文件夹

                var recs = FileHelper.ReadTextFileToList(file.FullName);//读取记录
                if (recs.Count == 0) continue;
                var fields = recs[0]; //读取字段列表和TAGS
                var tags = "";
                if (fields[fields.Count - 1].StartsWith("TAGS"))
                {
                    tags = fields[fields.Count - 1].Replace("\"", "'");
                    fields.RemoveAt(fields.Count - 1);
                }

                //生成语句头
                var headSql = new StringBuilder();//语句头
                headSql.Append($"insert into {item.Db}.{file.Name.Replace(file.Extension, "")}");//首行//字段名
                if (item.Table == null)
                {
                    headSql.Append($" using {item.Db}.{item.STable} {tags}");//引用超级表TAGS
                }
                headSql.Append(" values ");

                var sqlList = new List<string>();//sql语句集
                var sql = new StringBuilder();

                for (int i = 1; i < recs.Count; i++)
                {
                    var recStr = new List<string>();
                    for (int j = 0; j < recs[i].Count; j++)
                    {
                        var value = recs[i][j];
                        if (fields[j].StartsWith("'")) value = $"'{value}'"; //字符型加引号
                        recStr.Add(value);
                    }
                    sql.Append($"({string.Join(",", recStr)})");//添加一条记录

                    if (i % 1000 == 0) //每页单独一条SQL语句
                    {
                        sqlList.Add(headSql.ToString() + sql.ToString());
                        sql.Clear();
                    }
                }
                if (sql.Length > 0)
                    sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句

                //语句生成完成，开始执行
                foreach (var sq in sqlList)
                {
                    var result = MyService.ExcuteSql(item.Server, sq);

                }

                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;

            }//单个文件结束


            return ret;

        }


        /// <summary>
        /// 导入超级表文本
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ImportStable(NodeItem item, string fileName)
        {
            var ret = false;


            var recs = FileHelper.ReadTextFileToList(fileName);//读取记录
            var fields = recs[0]; //读取字段列表和TAGS
            var tags = "";
            if (fields[fields.Count - 1].ToLower().StartsWith("tags"))
            {
                tags = fields[fields.Count - 1].Replace("\"", "'");
                fields.RemoveAt(fields.Count - 1);
            }



            var tablePreName = "power_l_";//=====================================

            var sqlList = new List<string>();//sql语句集
            var sql = new StringBuilder();//单条语句
            var headSql = new StringBuilder();//语句头
            var tagPos = fields.Count;//首个tag的索引位置
            var currentTag = "";
            for (int i = 1; i < recs.Count; i++)
            {
                if (recs[i][tagPos] != currentTag) //新子表
                {
                    if (sql.Length > 0)//完成上一子表的SQL语句
                        sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句
                    sql.Clear();//清除已完成语句
                    currentTag = recs[i][tagPos];//产生新TAG
                    headSql.Clear();//生成新子表的SQL语句头
                    headSql.Append($"insert into {item.Db}.{tablePreName}{currentTag}");//子表名
                    headSql.Append($" using {item.Db}.{item.STable} tags('{currentTag}','null')");//引用超级表TAGS =======================
                    headSql.Append(" values ");
                }

                var recStr = new List<string>();
                for (int j = 0; j < fields.Count; j++) //========================
                {
                    var value = recs[i][j];
                    if (fields[j].StartsWith("'")) value = $"'{value}'"; //字符型加引号
                    recStr.Add(value);
                }
                sql.Append($"({string.Join(",", recStr)})");//添加一条记录

                if (i % 1000 == 0) //每页单独一条SQL语句
                {
                    sqlList.Add(headSql.ToString() + sql.ToString());
                    sql.Clear();
                }
            }
            if (sql.Length > 0)
                sqlList.Add(headSql.ToString() + sql.ToString());//不足一页的SQL语句

            //语句生成完成，开始执行
            psBar.Value = 0;
            psBar.Maximum = sqlList.Count;
            foreach (var sq in sqlList)
            {
                var result = MyService.ExcuteSql(item.Server, sq);
                if (psBar.Value < psBar.Maximum)
                    psBar.Value += 1;
            }


            return ret;

        }

        #endregion


    }
}
