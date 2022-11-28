using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class StableDto
    {
        public string stable_name { get; set; }
        public string db_name { get; set; }
        public string created_time { get; set; }
        public int columns { get; set; }
        public int tags { get; set; }
        public string last_update { get; set; }
        public string table_comment { get; set; }
        public string watermark { get; set; }
        public string max_delay { get; set; }
        public string rollup { get; set; }
    }
}
