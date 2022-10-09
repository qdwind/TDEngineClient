using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class TAccount
    {
        public string TUrl { get; set; } = "";
        public string TUsername { get; set; } = "";
        public string TPassword { get; set; } = "";
        public string TServer { get; set; } = "";
        public string AliasName { get; set; } = "";
        public string Info { get; set; } = "";
        public int Version { get; set; }
    }
}
