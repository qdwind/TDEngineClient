﻿//using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDEngineClient.Entity;

using System.Runtime.Serialization.Json;

namespace TDEngineClient.Helper
{

    public static class THelper
    {
        /// <summary>
        /// 获取Base64字符串
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static string GetBase64Str(string userName, string password)
        {
            //if (userName.IsNullOrEmpty()) throw new ArgumentException("userName cannot be null");
            //if (password.IsNullOrEmpty()) throw new ArgumentException("password cannot be null");
            string temp = $"{userName}:{password}";
            return temp.Base64Encode();
        }

        public static object JsonToObject(string jsonStrig, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonStrig));
            return serializer.ReadObject(mStream);
        }

        /// <summary>
        /// 往头部加信息
        /// </summary>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }

        public static TSuccessResponseBase<List<object>> QueryObjects(string url, string base64Str, string sql)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                //往头部加入自定义验证信息
                SetHeaderValue(request.Headers, "Authorization", $"Basic {base64Str}");

                byte[] buffer = encoding.GetBytes(sql);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    var obj = (TSuccessResponseBase<List<object>>)THelper.JsonToObject(jsonStr, new TSuccessResponseBase<List<object>>());
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in QueryObjects:{ex.Message}");
                return null;
            }
        }




        public static TResponse Query(string url, string base64Str, string sql)
        {
            var result = new TResponse();
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                //往头部加入自定义验证信息
                SetHeaderValue(request.Headers, "Authorization", $"Basic {base64Str}");

                byte[] buffer = encoding.GetBytes(sql);
                request.ContentLength = buffer.Length;
                //request.MaximumResponseHeadersLength = 1024*1024;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    var obj = (TResponse)THelper.JsonToObject(jsonStr, new TResponse());
                    result = obj;
                }
                response.Close();
            }
            catch (WebException ex)
            {
                //using (WebResponse response = ex.Response)
                //{
                //    HttpWebResponse httpResponse = (HttpWebResponse)response;
                //    using (Stream data = response.GetResponseStream())
                //    {
                //        using (var reader = new StreamReader(data))
                //        {
                //            string text = reader.ReadToEnd();
                //            var obj = (TResponse)THelper.JsonToObject(text, new TResponse());
                //            result = obj;
                //        }
                //    }
                //}
                //if (string.IsNullOrEmpty(result.status))
                result.code = -1;//返回错误
                result.desc = ex.Message;//错误信息
            }
            return result;
        }

    }









}
