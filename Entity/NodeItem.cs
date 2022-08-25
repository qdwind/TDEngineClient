using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TDEngineClient.Services.MyService;

namespace TDEngineClient.Entity
{
    public class NodeItem
    {
        public TAccount Server { get; set; }
        public DataBaseDto Db { get; set; }
        public StableDto STable { get; set; }
        public TableDto Table { get; set; }
    }
}
