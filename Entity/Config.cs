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

        public List<Server> ServerList { get; set; } = new List<Server>();
    }

    public class SystemConfig
    {
        public int Language { get; set; } = 0;
        public bool ColoredKey { get; set; }
        public bool ShowTip { get; set; }
    }
}
