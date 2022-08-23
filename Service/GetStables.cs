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
            public string name { get; set; }
            public string created_time { get; set; }
            public long columns { get; set; }
            public long tags { get; set; }
            public long tables { get; set; }
        }

        public static async Task<List<StableDto>> GetStables(TAccount account,string dbName)
        {
            var dto = new List<StableDto>();
            string _base64Str = THelper.GetBase64Str(account.TUsername, account.TPassword);
            string sql = $"show {dbName}.stables";
            var response =  THelper.QueryObjectsAsync(account.TUrl, _base64Str, sql);
            if (response.code ==0 && response.data.Count > 0) //获取成功
            {
                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();
                    var dbItem = new StableDto
                    {
                        name = (string)tempArr[0]
                        //created_time = (string)tempArr[1],
                        //columns = (Int32)tempArr[2]
                        //tags = (Int32)tempArr[3],
                        //tables = (Int32)tempArr[4],
                    };
                    dto.Add(dbItem);
                }
                return dto;
            }
            else//获取失败
            {
                return null;
            }
        }
    }
}
