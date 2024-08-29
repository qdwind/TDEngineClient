using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;
using TDEngineClient.Helper;

namespace TDEngineClient.Services
{
    public static partial class MyService
    {

        public static  Server GetServerDetail(Server account)
        {
            account.Connected = false;
            var dblist = new List<DataBaseDto>();
            string _base64Str = THelper.GetBase64Str(account.Username, account.Password);
            string sql = $"show databases";
            var response = THelper.QueryObjects(account.Url, _base64Str, sql);
            if (response != null && response.data.Count > 0) //获取成功&& response.status == "succ"
            {
                if (response.column_meta.Count > 1)
                {
                    account.Version = 20; //2.x版本
                }
                else
                {
                    account.Version = 30; //3.x版本
                }

                foreach (var db in response.data)
                {
                    var tempArr = db.ToArray();

                    var dbItem = new DataBaseDto
                    {
                        Name = (string)tempArr[0],
                        Account = account
                        //created_time = (string)tempArr[1]
                    };
                    dblist.Add(dbItem);
                }

                account.DbList = dblist;//数据库列表

                if (account.Version == 30)
                {
                    var tabs = GetTables(new DataBaseDto { Account = account });
                    var stabs = GetStables(new DataBaseDto { Account = account });
                    foreach (var db in account.DbList)
                    {
                        var mystabs = stabs.Where(t => t.db_name == db.Name).ToList();//添加超级表
                        foreach (var ms in mystabs)
                        {
                            ms.Tables = tabs.Where(t => t.db_name == db.Name && t.stable_name == ms.stable_name).ToList();//超级表下的子表
                            db.Stables.Add(ms);
                        }
                        db.SysTables = tabs.Where(t => t.db_name == db.Name && t.type == TableType.SYSTEM_TABLE.ToString()).ToList();//系统表
                        db.Tables = tabs.Where(t => t.db_name == db.Name && t.type == TableType.NORMAL_TABLE.ToString()).ToList();//普通表
                    }
                }
                else
                {
                    foreach (var db in account.DbList)
                    {
                        var tabs = MyService.GetTables(db);//所有表
                        var mystabs = MyService.GetStables(db);//添加超级表

                        foreach (var ms in mystabs)
                        {
                            ms.Tables = tabs.Where(t => t.db_name == db.Name && t.stable_name == ms.stable_name).ToList();//超级表下的子表
                            db.Stables.Add(ms);
                        }

                        db.Tables = tabs.Where(t => t.db_name == db.Name && t.stable_name == "").ToList();//普通表
                    }
                }
                account.Connected = true;
            }

            return  account;
        }

    }
}
