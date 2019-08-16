using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;

namespace mvcProject.Controllers
{
    public class TimeLimitController : Controller
    {
        public int status = 0;
        public string msg = "";
        //
        // GET: /TimeLimit/

        public ActionResult Index()
        {
            return View();
        }
        /*修改时间*/
        public JsonResult updateTk(string tk, string pwd)
        {
            try
            {
                if (!isRight(pwd))
                {
                    status = 0;
                    msg = "密码错误";
                    return ControllerHelper.jsonresult(status, msg);
                }
                if (tk == "38564")
                {
                    errorHelper.SetErrorText(tk);
                    status = 1;
                    msg = "成功";
                }
                else if (tk.Length == 15)
                {
                    string strdate = errorHelper.GetDate(tk);
                    try
                    {
                        DateTime.Parse(strdate);
                        errorHelper.SetErrorText(tk);
                        status = 1;
                        msg = "成功";
                    }
                    catch
                    {
                        status = 0;
                        msg = "失败";
                    }
                }
                else
                {
                    status = 0;
                    msg = "失败";
                }
            }
            catch
            {
                status = 0;
                msg = "失败";
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        /*修改注册码*/
        public JsonResult updateMk(string mk, string pwd)
        {
            try
            {
                if (!isRight(pwd))
                {
                    status = 0;
                    msg = "密码错误";
                    return ControllerHelper.jsonresult(status, msg);
                }
                errorHelper.SetInfo(mk);
                status = 1;
                msg = "成功";
            }
            catch
            {
                status = 0;
                msg = "失败";
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        /*判断密码*/
        public bool isRight(string pwd)
        {
            if (pwd == "goodmorningye")
            {
                return true;
            }
            return false;
        }
    }
}
