using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Core
{
    public class errorHelper
    {
        /// <summary>
        /// 路径
        /// </summary>
        public static string url = "/errorHelper";
        /// <summary>
        /// 月数,可以不用注册码
        /// </summary>
        public static int month = 3;
        /// <summary>
        /// 从error.txt读取
        /// </summary>
        /// <returns>若返回1则永久,否则返回年月日字符串</returns>
        public static string GetErrorDate()
        {
            string result = "";
            string path = HttpContext.Current.Server.MapPath(url + "/error.txt");
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                result = sr.ReadToEnd();
            }

            return result == "38564" ? "1" : GetDate(result);
        }
        /// <summary>
        /// 往error.txt写入
        /// </summary>
        /// <param name="inputString"></param>
        public static void SetErrorText(string inputString)
        {
            string path = HttpContext.Current.Server.MapPath(url + "/error.txt");
            using (StreamWriter sr = new StreamWriter(path, false, Encoding.Default))
            {
                sr.Write(inputString);
            }
        }
        /// <summary>
        /// 将乱序字符串转为年月日字符串
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetDate(string number)
        {
            string year = number[3].ToString() + number[7].ToString() + number[11].ToString() + number[6].ToString();
            string month = number[8].ToString() + number[9].ToString();
            string day = number[4].ToString() + number[14].ToString();
            string strdate = year + "-" + month + "-" + day;
            return strdate;
        }
        /// <summary>
        /// 获得机器硬件信息
        /// </summary>
        /// <returns></returns>
        public static string getCPUCode_MAC()
        {

            string cpuInfo = "";//cpu序列号  
            string mac = ""; //获取网卡硬件地址 
            string HDid = ""; //获取硬盘ID
            try
            {
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementBaseObject managebaseobj in moc)
                {
                    cpuInfo = managebaseobj.Properties["ProcessorId"].Value.ToString();
                    if (!cpuInfo.Equals(""))
                    {
                        break;
                    }
                }
                ManagementClass moc2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc3 = moc2.GetInstances();
                foreach (ManagementObject mo in moc3)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                ManagementClass mclass = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection mocole = mclass.GetInstances();
                foreach (ManagementObject mo in mocole)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                }
                //cpuInfo += "+" + System.Guid.NewGuid().ToString();
                //Method.AddnewSetting(Application.ExecutablePath, userid + "guidcode", userid + "#" + cpuInfo + "," + mac + "+" + HDid + "$");
            }
            catch
            {

            }
            return (cpuInfo + mac + HDid).Replace(" ", "");
        }
        /// <summary>
        /// 对硬件信息加密
        /// </summary>
        /// <param name="TextToHash"></param>
        /// <returns></returns>
        private static string HashTextMD5_ComputeHash(string TextToHash)
        {
            MD5CryptoServiceProvider md5;
            byte[] bytValue;
            byte[] bytHash;
            md5 = new MD5CryptoServiceProvider();
            bytValue = System.Text.Encoding.UTF8.GetBytes(TextToHash);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            return Convert.ToBase64String(bytHash);
        }
        /// <summary>
        /// 判断是否注册
        /// </summary>
        /// <returns></returns>
        public static bool ZhuCe()
        {
            string txtInfo = "";
            string path = HttpContext.Current.Server.MapPath(url + "/info.txt");
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                txtInfo = sr.ReadToEnd();
            }
            string computerInfo = HashTextMD5_ComputeHash(getCPUCode_MAC());
            if (txtInfo == computerInfo)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写入info.txt 注册码
        /// </summary>
        public static void SetInfo(string inputString)
        {
            string path = HttpContext.Current.Server.MapPath(url + "/info.txt");
            using (StreamWriter sr = new StreamWriter(path, false, Encoding.Default))
            {
                sr.Write(inputString);
            }
        }
        /// <summary>
        /// 测试是否可以登录使用
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<int, string> CanUse()
        {
            int status = 0;
            string msg = "登陆失败,请重新尝试!错误代码:";
            try
            {
                string strDate = GetErrorDate();
                if (strDate != "1")
                {
                    DateTime dtlimit = DateTime.Parse(strDate);
                    DateTime dtNow = DateTime.Now;
                    if (dtlimit < dtNow)
                        status = 3;
                    else
                    {
                        if (dtlimit > dtNow.AddMonths(month))
                            //判断注册码
                            if (!ZhuCe())
                                status = 2;
                            else
                                status = 1;
                        else
                            status = 1;
                    }
                }
                else
                {
                    //判断注册码
                    if (!ZhuCe())
                        status = 2;
                    else
                        status = 1;
                }
            }
            catch
            {
                status = 4;
            }
            return new KeyValuePair<int, string>(status, msg + status.ToString());
        }
    }
}