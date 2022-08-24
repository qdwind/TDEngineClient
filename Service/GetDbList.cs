﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;
using TDEngineClient.Helper;

namespace TDEngineClient.Services
{
    public static partial class MyService
    {
        public class DataBaseDto
        {
            public string name { get; set; }
            public string created_time { get; set; }

        }

        public static async Task<List<DataBaseDto>> GetDbList(TAccount account)
        {
            var dto = new List<DataBaseDto>();
            string _base64Str = THelper.GetBase64Str(account.TUsername, account.TPassword);
            string sql = $"show databases";
            //var response = await THelper.QueryObjectsAsync(account.TUrl, _base64Str, sql);
            var response = THelper.QueryObjectsAsync(account.TUrl, _base64Str, sql);
            if (response!=null  && response.data.Count > 0) //获取成功&& response.status == "succ"
            {
                if (response.column_meta.Count > 1)
                {
                    account.Version = 20;
                }
                else
                {
                    account.Version = 30;
                }

                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();

                    var dbItem = new DataBaseDto
                    {
                        name = (string)tempArr[0]
                        //created_time = (string)tempArr[1]
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
