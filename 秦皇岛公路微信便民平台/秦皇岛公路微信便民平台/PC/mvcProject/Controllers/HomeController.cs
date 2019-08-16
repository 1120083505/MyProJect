using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZrSoft;
using SubSonic;
using System.Data;
using Models;
using Core;

namespace mvcProject.Controllers
{
    public class HomeController : Controller
    {
        DataTable dt = new DataTable();
        //首页
        public ActionResult Index()
        {

            //string ss=GUI.send();

            if (string.IsNullOrEmpty(LoginInfo.AdminID))
            {
                string loginUrl = "/account/index";
                return Redirect(loginUrl);
            }
            return View();
        }
        //首页内页
        [LoginPower]
        public ActionResult Default()
        {
            return View();
        }
        //退出
        [HttpPost]
        public string SignOut()
        {
            GUI.InsertLog("首页", "注销", "成功退出系统！[" + LoginInfo.AdminID + "]" + LoginInfo.AdminName);
            LoginInfo.RoleID = "";
            LoginInfo.AdminID = "";
            LoginInfo.AdminName = "";
            LoginInfo.discount = "";
            return "";
        }
        /// <summary>
        /// 错误页
        /// </summary>
        /// <returns></returns>
        public ActionResult error()
        {
            return View();
        }
        
        //样式
        /// <summary>
        /// 选择样式
        /// </summary>
        /// <param name="themeName">样式名称</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SetTheme(string themeName)
        {
            LoginInfo.Theme = themeName;
            GUI.InsertLog("首页", "主题", "选择主题成功！[" + themeName + "]");
            return Core.ControllerHelper.jsonresult(1, "设置成功！");
        }
        [HttpPost]
        public JsonResult GetTreeList(string id)
        {

            //过滤权限
            if (string.IsNullOrEmpty(id))
            {
                id = "0";
            }
            string sql = "SELECT *,dbo.f_GetPowerCount('" + LoginInfo.RoleID + "',ID) as Count FROM dbo.Sys_Module ";
            DataTable dtB = DataService.GetDataSet(new QueryCommand(sql + " WHERE IsLast=1  order by sort asc")).Tables[0];
            DataTable dtA = DataService.GetDataSet(new QueryCommand(sql + " WHERE IsShow=1 order by sort asc")).Tables[0];
            dt = dtA.Clone();
            for (int i = 0; i < dtB.Rows.Count; i++)
            {
                if (dtB.Rows[i]["count"].ToString() != "0")
                {
                    GetMenu(dtA, id, dtB.Rows[i]["parentid"].ToString(), dtB.Rows[i]["islast"].ToString());
                }
            }
            var json =
                from r in dt.AsEnumerable()
                orderby r["sort"]
                select new
                {
                    text = r["Name"],
                    id = r["Id"],
                    IsLast = r["IsLast"],
                    attributes = new
                    {
                        IsLast = r["IsLast"],
                        Url = r["Url"]
                    },

                    Url = r["Url"],
                    state = int.Parse(r["IsLast"].ToString()) == 1 ? "open" : "closed",
                    iconCls = "icon-roundcheckfill"
                };
            return Json(json);
        }
        public DataRow GetMenu(DataTable dtA, string id, string pid, string islast)
        {
            string filter = "[id]='" + pid + "'";
            if (islast == "0")
            {
                filter = "[parentid]='" + id + "'";
            }

            DataRow[] drs = dtA.Select(filter);
            foreach (DataRow dr in drs)
            {
                string parentid = dr["parentid"].ToString();
                if (parentid == id)
                {
                    DataRow[] tempr = dt.Select("[id]='" + dr["id"] + "'");

                    if (tempr.Length == 0)
                    {
                        if (dr["isLast"].ToString() != "1")
                        {
                            dt.Rows.Add(dr.ItemArray);

                        }
                        else if (int.Parse(dr["count"].ToString()) > 0)
                        {
                            dt.Rows.Add(dr.ItemArray);
                        }
                    }

                }
                else
                {
                    if (dr["isLast"].ToString() != "1")
                    {
                        GetMenu(dtA, id, dr["parentid"].ToString(), "0");
                    }
                }
            }

            return null;
        }


        public ActionResult ModifyPassword()
        {

            return View();
        }
        public string msg = "";
        public int status = 1;
        public class info
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }

        }
        public JsonResult Password(info model)
        {
            Sys_Admin entity = new Sys_Admin(LoginInfo.AdminID);
            entity.LoginPwd = Utils.DESDecryptMethod(entity.LoginPwd);
            if (model.OldPassword == entity.LoginPwd)
            {
                entity.LoginPwd = Utils.DESEncryptMethod(model.NewPassword);

                //EaseMobDemo ease = new EaseMobDemo("YXA6U2WD0J56EeefB5vTyfoqog", "YXA6Qh1T2QgQXeDDQvBoGNp-Fq0HLI0", "qinhuangdao", "1172170921178912");
                //string s = ease.AccountResetPwd(entity.LoginName, Utils.DESDecryptMethod(entity.LoginPwd));
                entity.Save();
                status = 1;
                msg = Tip.EditSucceed;


            }
            else
            {
                status = 0;
                msg = "旧密码不正确";
            }


            return ControllerHelper.jsonresult(status, msg);
        }
        public ActionResult Study()
        {
            return View();
        }

    }
}
