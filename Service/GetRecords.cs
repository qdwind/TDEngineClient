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
        public class RecordDto
        {
            public long Count { get; set; }
            public List<string> FieldList { get; set; } = new List<string>();
            public List<List<string>> RecordList { get; set; } = new List<List<string>>();

            public TAccount DB { get; set; }
            public string TableName { get; set; }
            public long CurrentPage { get; set; }
            public long PageCount { get; set; }
        }

        public static async Task<RecordDto> GetRecords(TAccount account, string tableName,long page=1,int pageSize=10)
        {
            
            var offset = (page - 1) * pageSize;//起始记录位置(下标从0开始)
            var limit = pageSize;
            //var recordTo = recordFrom + pageSize - 1;//截至记录位置

            var dto = new RecordDto();
            dto.DB = account;
            dto.TableName = tableName;
            dto.CurrentPage = page;
            string _base64Str = THelper.GetBase64Str(account.TUsername, account.TPassword);


            string tmpsql = $"select count(*) from {tableName}";
            var tmpresponse =  THelper.QueryAsync(account.TUrl, _base64Str, tmpsql);
            if (tmpresponse.code == 0 && tmpresponse.data.Count > 0) //获取成功
            {
                dto.Count = Convert.ToInt64(tmpresponse.data[0][0]);
                dto.PageCount = dto.Count / pageSize;
            }



            string sql = $"select * from {tableName} limit {limit} offset {offset}";
            var response =  THelper.QueryAsync(account.TUrl, _base64Str, sql);
            if (response.code == 0 && response.data.Count > 0) //获取成功
            {
                foreach (var meta in response.column_meta)
                {
                    //var tempArr = meta as ;

                    dto.FieldList.Add(meta[0].ToString());
                }


                foreach (var record in response.data)
                {
                    var itemList = new List<string>();
                    foreach (var item in record)
                    {
                        
                        itemList.Add(Convert.ToString(item));
                    }

                    dto.RecordList.Add(itemList);
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
