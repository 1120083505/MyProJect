using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic;
using ZrSoft;
using System.Data;
using Core;
using System.Text;

namespace Core
{
    /// <summary>
    /// 项目内方法
    /// </summary>
    public class GUI
    {
        /// <summary>
        /// 写入log
        /// </summary>
        /// <param name="ModuleName">模块名称</param>
        /// <param name="OperateName">操作</param>
        /// <param name="OperateMemo">操作说明</param>
        public static void InsertLog(string ModuleName, string OperateName, string OperateMemo)
        {
            try
            {
                Sys_Log l = new Sys_Log();
                l.Id = Utils.GetNewDateID();
                l.ModuleName = ModuleName;
                l.OperateMemo = OperateMemo;
                l.PubDate = DateTime.Now;
                l.OperateName = OperateName;
                l.IP = HttpContext.Current.Request.UserHostAddress;
                l.AdminId = LoginInfo.AdminID;
                l.Save();
            }
            catch (Exception e)
            {
                DateTime dt = DateTime.Now;
                string url = HttpContext.Current.Server.MapPath("/Log/") + dt.Year;
                Utils.AutoCreatDir(url);
                url += "/" + dt.Year + "" + dt.Month.ToString("00");
                Utils.AutoCreatDir(url);
                string Content = "\r时间:" + dt.ToString("yyyy-MM-dd HH:mm:ss:fff")
                    + " 操作人：" + LoginInfo.AdminName + "(" + LoginInfo.AdminID + ")"
                    + " 模块名称：" + ModuleName
                    + " 操作：" + OperateName
                    + " 说明：" + OperateMemo
                    + " IP：" + HttpContext.Current.Request.UserHostAddress;
                Utils.WriteFileContinue(url + "/", dt.Year + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00") + ".txt", Content);
            }
        }


        
    }
}

