using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    public enum SqlCommandType
    {
        CreateDatabase=1,
        DropDatabase =2,
        CreateStable=3,
        DropStable=4,
        CreateTable=5,
        DropTable=6,

    }
}
