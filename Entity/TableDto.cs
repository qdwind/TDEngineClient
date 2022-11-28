using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class TableDto
    {
        public string table_name { get; set; }
        public string db_name { get; set; }
        public string create_time { get; set; }
        public int columns { get; set; }
        public string stable_name { get; set; }
        public long uid { get; set; }
        public int vgroup_id { get; set; }
        public int ttl { get; set; }
        public string table_comment { get; set; }
        public string type { get; set; }
    }
}
