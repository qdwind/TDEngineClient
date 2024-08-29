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
        private const string CONFIGFILE = "config.ini"; //配置文件
        private const int SERVERCOUNT = 20;//可配置服务器数
        private const string INI_QUERY_KEY = "query"; //查询记录键

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

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            var myconfig = new Config();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CONFIGFILE);//在当前程序路径创建
            if (File.Exists(filePath))
            {
                for (int i = 1; i < SERVERCOUNT+1; i++)
                {
                    string server = Read("server" + i.ToString(), "server", "", filePath);
                    if (string.IsNullOrEmpty(server)) break;
                    string port = Read("server" + i.ToString(), "port", "", filePath);
                    string user = Read("server" + i.ToString(), "user", "", filePath);
                    string pass = Read("server" + i.ToString(), "pass", "", filePath);
                    string alias = Read("server" + i.ToString(), "alias", "", filePath);
                    string info = Read("server" + i.ToString(), "info", "", filePath);
                    string savepass = Read("server" + i.ToString(), "savepass", "", filePath);
                    Server account = new Server();
                    if (string.IsNullOrEmpty(user))
                    {
                        account.Url = $"https://{server}/rest/sql?token={pass}"; //token模式
                    }
                    else
                    {
                        account.Url = $"http://{server}:{port}/rest/sql"; //用户名模式
                    }
                    account.Username = user;
                    account.Password = pass;
                    account.IP = server;
                    if (int.TryParse(port, out int p))
                    {
                        account.Port = p;
                    }
                    account.AliasName = alias;
                    account.Info = info;
                    account.SavePass = savepass == "true";
                    myconfig.ServerList.Add(account);
                }

                if (int.TryParse(Read("system", "language", "", filePath), out int lanCode))
                {
                    myconfig.System.Language = lanCode;
                   
                }
                myconfig.System.ColoredKey = Read("system", "coloredkey", "", filePath) == "true";
                myconfig.System.ShowTip = Read("system", "showtip", "", filePath) == "true";

            }
            return myconfig;
        }

        public static List<TQueryBox> GetQueriesFromIni()
        {
            List<TQueryBox> slist = new List<TQueryBox>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (File.Exists(filePath))
            {
                var qlist = ReadSections(filePath, INI_QUERY_KEY);
                foreach (var q in qlist)
                {
                    string text = Read(INI_QUERY_KEY, q, "", filePath);
                    if (string.IsNullOrEmpty(text)) continue;
                    var item = new TQueryBox();
                    var names = q.Split('|');
                    if (names.Length > 1)
                    {
                        item.Caption = names[1];
                        item.AccountServer = names[0];
                    }
                    item.Text = text;
                    
                    slist.Add(item);
                }
            }
            return slist;
        }

        /// <summary>
        /// 保存服务器列表
        /// </summary>
        /// <param name="servers"></param>
        public static void SaveServers(List<Server> servers)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }

            if (File.Exists(filePath))
            {
                for (int i = 1; i < SERVERCOUNT +1; i++)
                {
                    DeleteSection($"server{i}", filePath);//先全部清除
                }

                for (int i = 0; i < servers.Count; i++)
                {
                    var svrSection = $"server{i+1}";
                    Write(svrSection, "server", servers[i].IP, filePath);
                    Write(svrSection, "port", servers[i].Port.ToString(), filePath);
                    Write(svrSection, "user", servers[i].Username, filePath);
                    Write(svrSection, "pass", servers[i].Password, filePath);
                    Write(svrSection, "alias", servers[i].AliasName, filePath);
                    Write(svrSection, "info", servers[i].Info, filePath);
                    Write(svrSection, "savepass", servers[i].SavePass ? "true" : "false", filePath);

                }
            }
        }

        /// <summary>
        /// 保存其他配置
        /// </summary>
        /// <param name="sysConfig"></param>
        public static void SaveSystemConfig(SystemConfig sysConfig)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//在当前程序路径创建
            if (File.Exists(filePath))
            {
                Write("system", "language", sysConfig.Language.ToString(), filePath);
                Write("system", "coloredkey", sysConfig.ColoredKey?"true":"false", filePath);
                Write("system", "showtip", sysConfig.ShowTip?"true":"false", filePath);
            }
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
                DeleteSection(INI_QUERY_KEY, filePath);//清除
                foreach (var query in queries)
                {
                    Write(INI_QUERY_KEY, query.AccountServer + "|" + query.Caption, query.Text, filePath);
                }
            }
            return true;
        }


        public static bool WriteListToTextFile(string txtFile,List<List<string>> list,char splitor='\t')
        {
            bool result = false;

            try
            {
                //创建一个文件流，用以写入或者创建一个StreamWriter 
                FileStream fs = new FileStream(txtFile, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Flush();
                // 使用StreamWriter来往文件中写入内容 
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                foreach (var item in list)
                {
                    sw.WriteLine(string.Join(splitor.ToString(), item));
                }

                //关闭此文件 
                sw.Flush();
                sw.Close();
                fs.Close();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static List<List<string>> ReadTextFileToList(string fileName, char splitor = '\t')
        {
            List<List<string>> list = new List<List<string>>();

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                //使用StreamReader类来读取文件 
                sr.BaseStream.Seek(0, SeekOrigin.Begin);

                // 从数据流中读取每一行，直到文件的最后一行 
                string tmp = sr.ReadLine();

                while (tmp != null)
                {
                    list.Add(tmp.Split(splitor).ToList());
                    tmp = sr.ReadLine();
                }

                //关闭此StreamReader对象 

                sr.Close();

                fs.Close();
            }
            catch(Exception ex)
            {

            }

            return list;

        }



    }
}
