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
        public List<StableDto> StableList { get; set; } = new List<StableDto>();
        public List<TableDto> TableList { get; set; } = new List<TableDto>();
    }
}
