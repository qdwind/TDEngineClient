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
        public class StableDto
        {
            public string stable_name { get; set; }
            public string db_name { get; set; }
            public string created_time { get; set; }
            public int columns { get; set; }
            public int tags { get; set; }
            public string last_update { get; set; }
            public string table_comment { get; set; }
            public string watermark { get; set; }
            public string max_delay { get; set; }
            public string rollup { get; set; }
        }

        public static async Task<List<StableDto>> GetStables(TAccount account,string dbName="")
        {
            var dto = new List<StableDto>();
            string _base64Str = THelper.GetBase64Str(account.TUsername, account.TPassword);
            string dbsql, sql;
            if (account.Version == 30)
            {
                dbsql = string.IsNullOrEmpty(dbName) ? "" : $" where db_name='{dbName}'";
                sql = $"select * from information_schema.ins_stables {dbsql};";
            }
            else
            {
                sql = $"show {dbName}.stables;";
            }

            var response = THelper.QueryObjectsAsync(account.TUrl, _base64Str, sql);
            if (response.code == 0 && response.data.Count > 0) //获取成功
            {
                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();

                    if (account.Version == 30)
                    {
                        var dbItem = new StableDto
                        {
                            stable_name = tempArr[0]?.ToString(),
                            db_name = tempArr[1]?.ToString(),
                            created_time = tempArr[2]?.ToString(),
                            columns = tempArr[3] == null ? 0 : (Int32)tempArr[3],
                            tags = tempArr[4] == null ? 0 : (Int32)tempArr[4],
                            last_update = tempArr[5]?.ToString(),
                            table_comment = tempArr[6]?.ToString(),
                            watermark = tempArr[7]?.ToString(),
                            max_delay = tempArr[8]?.ToString(),
                            rollup = tempArr[9]?.ToString()
                        };
                        dto.Add(dbItem);
                    }
                    else
                    {
                        var dbItem = new StableDto
                        {
                            stable_name = tempArr[0]?.ToString(),
                            db_name = dbName,
                            created_time = tempArr[1]?.ToString(),
                            columns = tempArr[2] == null ? 0 : (Int32)tempArr[2],
                            tags = tempArr[3] == null ? 0 : (Int32)tempArr[3]
                        };
                        dto.Add(dbItem);
                    }

                    
                }
            }


            return dto;
        }
    }
}
