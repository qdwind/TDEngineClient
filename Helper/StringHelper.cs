using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEngineClient.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// 对字符串进行Base64加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(this string str)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str));
        }

        private static string ConvertToDateTime(object value)
        {
            if (value == null) return "";
            var s = value.ToString();
            if (DateTime.TryParse(s, out DateTime dt))
            {
                if (dt.Kind == DateTimeKind.Utc)
                {
                    dt = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.Local);//转换UTC
                }
                if (dt.Millisecond > 0)
                {
                    s = dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
                }
                else
                {
                    s = dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            return s;
        }

        public static string ToDateTimeString(this object value) => ConvertToDateTime(value);


    }
}
