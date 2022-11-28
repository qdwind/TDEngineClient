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


        public static List<StableDto> GetStables(DataBaseDto database)
        {
            var dto = new List<StableDto>();
            var account = database.Account;
            string _base64Str = THelper.GetBase64Str(account.Username, account.Password);
            string dbsql, sql;
            if (account.Version == 30)
            {
                dbsql = string.IsNullOrEmpty(database.Name) ? "" : $" where db_name='{database.Name}'";
                sql = $"select * from information_schema.ins_stables {dbsql};";
            }
            else
            {
                sql = $"show {database.Name}.stables;";
            }

            var response = THelper.QueryObjects(account.Url, _base64Str, sql);
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
                            db_name = database.Name,
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
