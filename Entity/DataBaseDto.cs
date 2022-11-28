using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public class DataBaseDto
    {
        public string Name { get; set; }
        public string CreatedTime { get; set; }

        public Server Account { get; set; }
    }
}
