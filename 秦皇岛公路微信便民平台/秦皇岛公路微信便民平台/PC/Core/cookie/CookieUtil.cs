using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web;

namespace Core
{
    public class CryptoUtil
    {
        public static byte[] KEY_64 = { 42, 16, 93, 56, 78, 4, 185, 118 };
        public static byte[] IV_64 = { 55, 118, 46, 79, 36, 89, 167, 3 };

        private static byte[] KEY_192 = { 42, 16, 93, 152, 78, 4, 218, 32, 12, 167, 44, 80, 77, 250, 118, 112, 2, 94, 11, 204, 119, 35, 184, 197 };
        private static byte[] IV_192 = { 55, 118, 246, 81, 36, 11, 167, 3, 10, 5, 62, 12, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 118, 222 };

        //标准的DES加密
        public static string Encrypt(string value1)
        {
            if (value1 != "")
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(value1);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            return "";
        }

        //标准的DES解密
        public static string Decrypt(string value1)
        {
            if (value1 != "")
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                byte[] buffer = Convert.FromBase64String(value1);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            return "";
        }


        private static string Key = "ZrSoftRZ";//加密密钥必须为8位
        //加密算法
        public static string MD5Encrypt(string pToEncrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();

        }


        //解密算法
        public static string MD5Decrypt(string pToDecrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.ASCII.GetString(ms.ToArray());

        }

    }

    public class CookieUtil
    {
        public const string COOKIENULL = null;

        public static void SetEncryptedCookie(string key, string val)
        {
            key = CryptoUtil.Encrypt(key);
            val = CryptoUtil.Encrypt(val);
            SetCookie(key, val);
        }
        public static void SetEncryptedCookie(string key, string val, DateTime expires)
        {
            key = CryptoUtil.Encrypt(key);
            val = CryptoUtil.Encrypt(val);
            SetCookie(key, val, expires);
        }
        public static void SetEncryptedCookie(string key, string val, int DayNum)
        {
            key = CryptoUtil.Encrypt(key);
            val = CryptoUtil.Encrypt(val);
            if (DayNum != 0)
            {
                DateTime expires = DateTime.Now.AddDays(DayNum);
                SetCookie(key, val, expires);
            }
            else
            {
                DateTime expires = DateTime.Now.AddDays(DayNum);
                SetCookie(key, val);
            }
        }
        #region///SetCookie
        private static void SetCookie(string key, string val)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            val = HttpContext.Current.Server.UrlEncode(val);
            HttpCookie cookie = new HttpCookie(key, val);
            SetCookie(cookie);
        }
        private static void SetCookie(string key, string val, DateTime expires)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            val = HttpContext.Current.Server.UrlEncode(val);
            HttpCookie cookie = new HttpCookie(key, val);
            cookie.Expires = expires;
            SetCookie(cookie);
        }
        private static void SetCookie(HttpCookie cookie)
        {
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        #endregion
        public static string GetEncryptedCookieValue(string key)
        {
            key = CryptoUtil.Encrypt(key);
            string val = GetCookieValue(key);
            if (val == COOKIENULL)
                return COOKIENULL;
            val = CryptoUtil.Decrypt(val);
            return val;
        }
        #region///GetCookie
        private static HttpCookie GetCookie(string key)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            return HttpContext.Current.Request.Cookies.Get(key);
        }
        private static string GetCookieValue(string key)
        {
            try
            {
                string val = GetCookie(key).Value;
                val = HttpContext.Current.Server.UrlDecode(val);
                return val;
            }
            catch
            {
                return COOKIENULL;
            }
        }
        #endregion
    }

}