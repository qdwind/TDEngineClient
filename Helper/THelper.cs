//using Flurl.Http;
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
    }

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

        public static TSuccessResponseBase<List<object>> QueryObjectsAsync(string url, string base64Str, string sql)
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
                return null;
            }
        }





        ///// <summary>
        ///// 提交sql语句
        ///// </summary>
        ///// <param name="url">时序数据库地址</param>
        ///// <param name="base64Str">用户密码经Base64加密后的值</param>
        ///// <param name="sql">sql语句</param>
        ///// <returns></returns>
        //public static async Task<bool> PostSqlAsync(string url, string base64Str, string sql)
        //{
        //    try
        //    {
        //        var response = await url
        //           .WithHeader("Authorization", $"Basic {base64Str}")
        //           .PostStringAsync(sql);

        //        return response.ResponseMessage.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        var e = ex.Message;
        //        return false;
        //    }
        //}



        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="url"></param>
        /// <param name="base64Str"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public static async Task<bool> IsTableExists(string url, string base64Str, string sql)
        //{
        //    var response = await url
        //           .WithHeader("Authorization", $"Basic {base64Str}")
        //           .PostStringAsync(sql)
        //           .ReceiveJson<TSuccessResponseBase<List<object>>>();


        //    return response.data.Count > 0;
        //}



        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="url">时序数据库地址</param>
        /// <param name="base64Str">用户密码经Base64加密后的值</param>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        //public static async Task<TSuccessResponseBase<List<object>>> QueryObjectsAsync(string url, string base64Str, string sql)
        //{
        //    //如果表不存在会报错,在执行本操作之前需要判断表是否存在
        //    var response = new TSuccessResponseBase<List<object>>();
        //    try
        //    {
        //        response = await url
        //                .WithHeader("Authorization", $"Basic {base64Str}")
        //                .PostStringAsync(sql)
        //                .ReceiveJson<TSuccessResponseBase<List<object>>>();

        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = ex.Message;
        //    }
        //    return response;
        //}


        //public static async Task<TResponse> QueryAsync(string url, string base64Str, string sql)
        //{
        //    //如果表不存在会报错,在执行本操作之前需要判断表是否存在
        //    var response = new TResponse();
        //    try
        //    {
        //        response = await url
        //                .WithHeader("Authorization", $"Basic {base64Str}")
        //                .PostStringAsync(sql)
        //                .ReceiveJson<TResponse>();

        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = ex.Message;
        //    }
        //    return response;
        //}


        public static TResponse QueryAsync(string url, string base64Str, string sql)
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
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            var obj = (TResponse)THelper.JsonToObject(text, new TResponse());
                            result = obj;
                        }
                    }
                }
                //if (string.IsNullOrEmpty(result.status))
                //    result.status = ex.Message;
            }
            return result;
        }

    }









}
