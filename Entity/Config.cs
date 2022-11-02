using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class Config
    {
        public SystemConfig System { get; set; } = new SystemConfig();

        public List<TAccount> ServerList { get; set; } = new List<TAccount>();
    }

    public class SystemConfig
    {
        public string Language { get; set; }
    }
}
