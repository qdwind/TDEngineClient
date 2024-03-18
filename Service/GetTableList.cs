using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;
using TDEngineClient.Helper;
using System.Linq;

namespace TDEngineClient.Services
{
    public static partial class MyService
    {




        public static List<TableDto> GetTables(DataBaseDto database)
        {
            var dto = new List<TableDto>();
            var account = database.Account;
            string _base64Str = THelper.GetBase64Str(account.Username, account.Password);
            string dbsql, sql;
            if (account.Version == 30)
            {
                dbsql = string.IsNullOrEmpty(database.Name) ? "" : $" where db_name='{database.Name}'";
                sql = $"select * from information_schema.ins_tables {dbsql};";
            }
            else
            {
                sql = $"show {database.Name}.tables;";
            }

            var response = THelper.QueryObjects(account.Url, _base64Str, sql);
            if (response.code == 0 && response.data.Count > 0) //获取成功
            {
                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();

                    if (account.Version == 30)
                    {
                        var ver32 = tempArr.Length == 9;//3.2版删掉了vgroup_id字段
                        var dbItem = new TableDto
                        {
                            table_name = tempArr[0]?.ToString(),
                            db_name = tempArr[1]?.ToString(),
                            create_time = tempArr[2]?.ToString(),
                            columns = tempArr[3] == null ? 0 : (Int32)tempArr[3],
                            stable_name = tempArr[4]?.ToString(),
                            uid = tempArr[5] == null ? 0 : (Int64)tempArr[5],

                            vgroup_id = ver32?0:( tempArr[6] == null ? 0 : (Int32)tempArr[6]),
                            ttl = tempArr[ver32 ? 6:7] == null ? 0 : (Int32)tempArr[ver32? 6:7],
                            table_comment = tempArr[ver32?7: 8]?.ToString(),
                            type = tempArr[ver32 ?8: 9]?.ToString()
                        };
                        dto.Add(dbItem);
                    }
                    else
                    {
                        var dbItem = new TableDto
                        {
                            table_name = tempArr[0]?.ToString(),
                            db_name = database.Name,
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
                dto = dto.OrderBy(t => t.table_name).ToList();//按表名排序
            }
            return dto;
        }
    }
}
