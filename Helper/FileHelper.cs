using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;

namespace TDEngineClient.Helper
{
    public static class FileHelper
    {
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string fileName);

        [DllImport("kernel32",EntryPoint ="GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key, string def, byte[] retVal, int size, string fileName);

        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string section, string key, string val, string fileName);


        public static string Read(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        public static int Write(string section, string key, string value, string filePath)
        {
            //CheckPath(filePath);
            return WritePrivateProfileString(section, key, value, filePath);
        }

        public static int DeleteSection(string section, string filePath)
        {
            return Write(section, null, null, filePath);
        }

        public static int DeleteKey(string section, string key, string filePath)
        {
            return Write(section, key, null, filePath);
        }

        public static List<TAccount> GetServersFromIni()
        {
            List<TAccount> slist = new List<TAccount>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (File.Exists(filePath))
            {
                for (int i = 1; i < 10; i++)
                {
                    string server = Read("server" + i.ToString(), "server", "", filePath);
                    if (string.IsNullOrEmpty(server)) break;
                    string port = Read("server" + i.ToString(), "port", "", filePath);
                    string user = Read("server" + i.ToString(), "user", "", filePath);
                    string pass = Read("server" + i.ToString(), "pass", "", filePath);
                    string alias = Read("server" + i.ToString(), "alias", "", filePath);
                    string info = Read("server" + i.ToString(), "info", "", filePath);
                    TAccount account = new TAccount();
                    account.TUrl = $"http://{server}:{port}/rest/sql";
                    account.TUsername = user;
                    account.TPassword = pass;
                    account.TDatabase = server;
                    account.AliasName = alias;
                    account.Info = info;
                    slist.Add(account);
                }

            }
            return slist;
        }

        public static List<TQueryBox> GetQueriesFromIni()
        {
            List<TQueryBox> slist = new List<TQueryBox>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (File.Exists(filePath))
            {
                var qlist = ReadSections(filePath,"query");
                foreach (var q in qlist)
                {
                    string text = Read("query" ,q, "", filePath);
                    if (string.IsNullOrEmpty(text)) break;
                    var item = new TQueryBox();
                    var names = q.Split('|');
                    if (names.Length > 1)
                    {
                        item.Caption = names[1];
                        item.AccountDB = names[0];
                    }
                    item.Text = text;
                    
                    slist.Add(item);
                }
            }
            return slist;
        }

        public static void AddService(string server, string port, string user, string pass)
        {
            //TAccount account = new TAccount();
            //account.TUrl = $"http://{server}:{port}/rest/sql";
            //account.TUsername = user;
            //account.TPassword = pass;
            //account.TDatabase = server;
            //ServerList.Add(account);

            //var svrSection = "server" + ServerList.Count.ToString();
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            //if (File.Exists(filePath))
            //{
            //    IniHelper.Write(svrSection, "server", server, filePath);
            //    IniHelper.Write(svrSection, "port", port, filePath);
            //    IniHelper.Write(svrSection, "user", user, filePath);
            //    IniHelper.Write(svrSection, "pass", pass, filePath);

            //}
        }

        public static List<string> ReadSections(string iniFiename, string section = null)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileStringA(section, null, null, buf, buf.Length, iniFiename);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }


        public static bool SaveQueriesToIni(List<TQueryBox> queries)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (File.Exists(filePath))
            {
                DeleteSection("query", filePath);//清除
                foreach (var query in queries)
                {
                    Write("query", query.AccountDB + "|" + query.Caption, query.Text, filePath);
                }
            }
            return true;
        }

    }
}
