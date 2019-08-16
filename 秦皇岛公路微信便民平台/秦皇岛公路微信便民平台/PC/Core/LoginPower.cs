using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Core;

namespace Core
{
    /// <summary>
    /// 登录权限判断
    /// </summary>
    //public class LoginPower : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        if (string.IsNullOrEmpty(LoginInfo.AdminID))
    //        {
    //            string loginUrl = "/account/index";
    //            filterContext.Result = new RedirectResult(loginUrl);
    //            JsonResult json = new JsonResult();
    //            json.Data = "{Status:'0',Memo:'您还未登陆！还好，你的IP已经记录在系统中..请勿非法操作！'}";
    //            filterContext.Result = json;
    //        }
    //    }
    //}
    public class LoginPower : AuthorizeAttribute
    {
        /// <summary>
        /// 判断权限登陆
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //return base.AuthorizeCore(httpContext);
            if (string.IsNullOrWhiteSpace(LoginInfo.AdminID))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 具体操作
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "/account/index";
            filterContext.HttpContext.Response.Redirect(loginUrl);
        }
    }
}
