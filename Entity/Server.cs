using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TDEngineClient.Services.MyService;

namespace TDEngineClient.Entity
{
    public class Server
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string IP { get; set; } = "";
        public int Port { get; set; }
        public string Url { get; set; } = "";
        public string AliasName { get; set; } = "";
        public string Info { get; set; } = "";
        public int Version { get; set; }
        public bool SavePass { get; set; } = true;

        public List<DataBaseDto> DbList { get; set; } = new List<DataBaseDto>();



        public bool Connected { get; set; } = false;

        /// <summary>
        /// 获取所有数据库名/表名/超级表名
        /// </summary>
        /// <returns></returns>
        public List<Tip> GetTipNames()
        {
            var tips = new List<Tip>();
            foreach (var db in DbList)
            {
                tips.Add(new Tip(db.Name, AliasName, TipType.Names));
                foreach (var st in db.Stables)
                {
                    tips.Add(new Tip($"{db.Name}.{st.stable_name}", db.Name, TipType.Names));
                    foreach (var tb in st.Tables)
                    {
                        tips.Add(new Tip($"{db.Name}.{tb.table_name}", st.stable_name, TipType.Names));
                    }
                }
                foreach (var tb in db.Tables)
                {
                    tips.Add(new Tip($"{db.Name}.{tb.table_name}", db.Name, TipType.Names));
                }
                foreach (var tb in db.SysTables)
                {
                    tips.Add(new Tip($"{db.Name}.{tb.table_name}", db.Name, TipType.Names));
                }
            }


            return tips;
        }


        public override string ToString()
        {
            return AliasName == "" ? IP : AliasName;
        }
    }
}
