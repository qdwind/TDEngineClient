using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Entity
{
    /// <summary>
    /// TD字段类型
    /// </summary>
    public enum SqlValueDataType
    {
        TIMESTAMP = 1,
        INT = 2,
        INT_UNSIGNED = 3,
        BIGINT = 4,
        BIGINT_UNSIGNED = 5,
        FLOAT = 6,
        DOUBLE = 7,
        BINARY = 8,
        SMALLINT = 9,
        SMALLINT_UNSIGNED = 10,
        TINYINT = 11,
        TINYINT_UNSIGNED = 12,
        BOOL = 13,
        NCHAR = 14,
        JSON = 15,
        VARCHAR = 16
    }
}
