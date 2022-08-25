using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;
using TDEngineClient.Helper;

namespace TDEngineClient.Services
{
    public static partial class MyService
    {
        public enum TableType
        {
            CHILD_TABLE = 0,
            NORMAL_TABLE =1,
            SYSTEM_TABLE = 2,
        }

        public class TableDto
        {
            public string table_name { get; set; }
            public string db_name { get; set; }
            public string create_time { get; set; }
            public int columns { get; set; } 
            public string stable_name { get; set; }
            public long uid { get; set; }
            public int vgroup_id { get; set; }
            public int ttl { get; set; }
            public string table_comment { get; set; }
            public string type { get; set; }
        }

        public static List<TableDto> GetTables(TAccount account, string dbName="")
        {
            var dto = new List<TableDto>();
            string _base64Str = THelper.GetBase64Str(account.TUsername, account.TPassword);
            string dbsql, sql;
            if (account.Version == 30)
            {
                dbsql = string.IsNullOrEmpty(dbName) ? "" : $" where db_name='{dbName}'";
                sql = $"select * from information_schema.ins_tables {dbsql};";
            }
            else
            {
                sql = $"show {dbName}.tables;";
            }

            var response = THelper.QueryObjects(account.TUrl, _base64Str, sql);
            if (response.code == 0 && response.data.Count > 0) //获取成功
            {
                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();

                    if (account.Version == 30)
                    {
                        var dbItem = new TableDto
                        {
                            table_name = tempArr[0]?.ToString(),
                            db_name = tempArr[1]?.ToString(),
                            create_time = tempArr[2]?.ToString(),
                            columns = tempArr[3] == null ? 0 : (Int32)tempArr[3],
                            stable_name = tempArr[4]?.ToString(),
                            uid = tempArr[5] == null ? 0 : (Int64)tempArr[5],
                            vgroup_id = tempArr[6] == null ? 0 : (Int32)tempArr[6],
                            ttl = tempArr[7] == null ? 0 : (Int32)tempArr[7],
                            table_comment = tempArr[8]?.ToString(),
                            type = tempArr[9]?.ToString()
                        };
                        dto.Add(dbItem);
                    }
                    else
                    {
                        var dbItem = new TableDto
                        {
                            table_name = tempArr[0]?.ToString(),
                            db_name = dbName,
                            create_time = tempArr[1]?.ToString(),
                            columns = tempArr[2] == null ? 0 : (Int32)tempArr[2],
                            stable_name = tempArr[3]?.ToString(),
                            uid = tempArr[4] == null ? 0 : (Int64)tempArr[4],
                            vgroup_id = tempArr[6] == null ? 0 : (Int32)tempArr[6],
                            ttl = tempArr[5] == null ? 0 : (Int32)tempArr[5],
                            //table_comment = tempArr[8]?.ToString(),
                            type = tempArr[3] == null? TableType.NORMAL_TABLE.ToString(): TableType.CHILD_TABLE.ToString()
                        };
                        dto.Add(dbItem);
                    }

                }
            }
            return dto;
        }
    }
}
