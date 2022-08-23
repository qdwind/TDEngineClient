using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class SqlValueItem
    {
        public string Text { get; set; }
        public SqlValueDataType DataType { get; set; }
        public SqlValueModeType Mode { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Step { get; set; }
        public List<string> SelectList { get; set; } = new List<string>();
    }


}
