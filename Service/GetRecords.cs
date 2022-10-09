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
            public List<string> FieldType { get; set; } = new List<string>();
            public List<List<string>> RecordList { get; set; } = new List<List<string>>();

            public TAccount DB { get; set; }
            public string TableName { get; set; }
            public long CurrentPage { get; set; }
            public long PageCount { get; set; }
        }

        public static  RecordDto GetRecords(TAccount account, string tableName,long page=1,int pageSize=10)
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
            var tmpresponse =  THelper.Query(account.TUrl, _base64Str, tmpsql);
            if (tmpresponse.code == 0 && tmpresponse.data.Count > 0) //获取成功
            {
                dto.Count = Convert.ToInt64(tmpresponse.data[0][0]);
                if (dto.Count > pageSize)
                {
                    if (dto.Count % pageSize > 0)
                        dto.PageCount = dto.Count / pageSize + 1;
                    else
                        dto.PageCount = dto.Count / pageSize;
                }
                else
                {
                    dto.PageCount = 1;
                }
            }

            string sql = $"select * from {tableName} limit {limit} offset {offset}";

            var response =  THelper.Query(account.TUrl, _base64Str, sql);
            if (response.code == 0) //获取成功
            {
                return ConvertRecordList(dto, response);
            }
            else//获取失败
            {
                return null;
            }
        }

        /// <summary>
        /// 将查询结果集转换为字段和记录列表
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static RecordDto ConvertRecordList(RecordDto dto, TResponse response)
        {
            if (response == null) return dto;
            foreach (var meta in response.column_meta)
            {
                //var tempArr = meta as ;

                dto.FieldList.Add(meta[0].ToString());
                dto.FieldType.Add(meta[1].ToString());
            }

            if (response.data.Count > 0)
            {
                foreach (var record in response.data)
                {
                    var itemList = new List<string>();
                    for (int i = 0; i < record.Count; i++)
                    {
                        var ftype = SqlValueDataType.BINARY;//字段类型
                        if (dto.FieldType.Count > i)
                        {
                            Enum.TryParse(dto.FieldType[i].ToString(), out ftype);
                        }


                        if (ftype == SqlValueDataType.TIMESTAMP)
                        {
                            itemList.Add(record[i].ToDateTimeString());
                        }
                        else
                        {
                            itemList.Add(Convert.ToString(record[i]));
                        }
                    }

                    dto.RecordList.Add(itemList);
                }
            }

            return dto;
        }


    }
}
