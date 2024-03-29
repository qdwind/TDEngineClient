﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;
using TDEngineClient.Helper;

namespace TDEngineClient.Services
{
    public static partial class MyService
    {
        public static RecordDto ExcuteSql(Server account, string sql, long page = 1, int pageSize = 10)
        {

            //var offset = (page - 1) * pageSize + 1;//起始记录位置(下标从1开始)
            //var limit = pageSize;
            //var recordTo = recordFrom + pageSize - 1;//截至记录位置
            
            var dto = new RecordDto();
            dto.DB = account;
            //dto.CurrentPage = page;
            string _base64Str = THelper.GetBase64Str(account.Username, account.Password);

            var response =  THelper.Query(account.Url, _base64Str, sql);
            if (response.code==0) //获取成功
            {
                dto = ConvertRecordList(dto, response);
            }
            else//获取失败
            {
                //MessageBox.Show("查询错误："+response.status, "Error", MessageBoxButtons.OK);
                dto.FieldList.Add("code");
                dto.FieldList.Add("desc");
                dto.RecordList.Add(new List<string> { response.code.ToString(),response.desc==null?"":response.desc});
            }
            return dto;
        }


    }
}
