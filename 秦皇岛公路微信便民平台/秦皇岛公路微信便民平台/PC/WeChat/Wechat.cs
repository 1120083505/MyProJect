using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeChat_
{
    public class Wechat
    {
        public static string access_token = "";
        public static string appID = "wx562f089a916f10b5";
        public static string appsecret = "d8fcad31500591cd0b56af1e10f5f9ce";
        public static string token = "weixin";
        public static string jsapi_ticket = "";
        public static string PayAppID = "wxd5ccc2a5ef5a1bf3";//支付微信APPID
        public static string PayOpenID = "1235070302";//支付商户号
        public static string mchid = "";//微信支付账号
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        public static bool CheckSignature(String signature, String timestamp, String nonce)
        {
            string token = Wechat.token;
            String[] arr = new String[] { token, timestamp, nonce };
            // 将token、timestamp、nonce三个参数进行字典序排序  
            Array.Sort<String>(arr);

            StringBuilder content = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                content.Append(arr[i]);
            }

            String tmpStr = SHA1_Encrypt(content.ToString());


            // 将sha1加密后的字符串可与signature对比，标识该请求来源于微信  
            return tmpStr != null ? tmpStr.Equals(signature) : false;
        }


        /// <summary>
        /// 使用缺省密钥给字符串加密
        /// </summary>
        /// <param name="Source_String"></param>
        /// <returns></returns>
        public static string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }
        //获取access_token
        public static string Get_access_token()
        {
            string response = "";
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + Wechat.appID + "&secret=" + Wechat.appsecret;
            try
            {
                response = GetPage(url, "", "POST");
                if (!string.IsNullOrEmpty(response))
                {
                    JArray ja = (JArray)JsonConvert.DeserializeObject("[" + response + "]");
                    access_token = ja[0]["access_token"].ToString();
                    Get_jsapi_ticket();
                }
            }
            catch (Exception e)
            {
                return e.Message + "---" + access_token;
            }
            return access_token;
        }

        //获取access_token
        public static string Get_jsapi_ticket()
        {
            string response = "";
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + access_token + "&type=jsapi";
            try
            {
                response = GetPage(url, "", "POST");
                if (!string.IsNullOrEmpty(response))
                {
                    JArray ja = (JArray)JsonConvert.DeserializeObject("[" + response + "]");
                    jsapi_ticket = ja[0]["ticket"].ToString();
                }
            }
            catch (Exception e)
            {
                return e.Message + "---" + response;
            }
            //Utils.WriteFile("d:/", "w.txt", url + ">>>>>>" + response);
            return jsapi_ticket;
        }

        #region 获取页面返回内容
        /// <summary>
        /// 获取页面返回内容
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string GetPage(string posturl, string postData, string Method)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = Method;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }
        #endregion
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long CreatenTimestamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
        /// <summary>
        /// 签名算法        ///本代码来自开源微信SDK项目：https://github.com/night-king/weixinSDK
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, long timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();
            return SHA1_Encrypt(string1);

        }
    }
}
