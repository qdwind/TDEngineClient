using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TDEngineClient.Services.MyService;

namespace TDEngineClient.Entity
{
    public class NodeItem
    {
        public Server Server { get; set; }
        public DataBaseDto Db { get; set; }
        public StableDto STable { get; set; }
        public TableDto Table { get; set; }
        public TreeNode Node { get; set; }
    }
}
