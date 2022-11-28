using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class RecordDto
    {
        public long Count { get; set; }
        public List<string> FieldList { get; set; } = new List<string>();
        public List<string> FieldType { get; set; } = new List<string>();
        public List<List<string>> RecordList { get; set; } = new List<List<string>>();

        public Server DB { get; set; }
        public string TableName { get; set; }
        public long CurrentPage { get; set; }
        public long PageCount { get; set; }
    }
}
