using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using ZrSoft;
using SubSonic;
using System.Data;

namespace Core
{
    /// <summary>
    /// 权限过滤器[默认为当前Action,Controller]
    /// </summary>
    public class PowerFilter : ActionFilterAttribute
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(LoginInfo.AdminID))
            {
                string loginUrl = "/account/index";
                filterContext.Result = new RedirectResult(loginUrl);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ControllerName))
                {
                    ControllerName = filterContext.RouteData.Values["controller"].ToString();
                }
                if (string.IsNullOrWhiteSpace(ActionName))
                {
                    ActionName = filterContext.RouteData.Values["action"].ToString();
                }
                //判断权限
                string[] columns = { 
                                   Sys_Power.Columns.Id,
                                   Sys_Power.Columns.ModuleOperateID,
                                   Sys_Power.Columns.RoleID,
                                   Sys_ModuleOperate.Columns.KeyCode,
                                   Sys_Module.Columns.EnName
                                   };
                SqlQuery sq = new Select(columns).From<Sys_Power>().LeftOuterJoin(Sys_ModuleOperate.IdColumn, Sys_Power.ModuleOperateIDColumn)
                    .LeftOuterJoin(Sys_Module.IdColumn, Sys_ModuleOperate.ModuleIDColumn);
                if (ActionName.ToLower() == "index")
                {
                    sq.Where(Sys_Module.Columns.EnName).IsEqualTo(ControllerName);
                }
                else
                {
                    sq.Where(Sys_Module.Columns.EnName).IsEqualTo(ControllerName);
                    sq.AndExpression(Sys_ModuleOperate.Columns.KeyCode).IsEqualTo(ActionName);
                }
                sq.AndExpression(Sys_Power.Columns.RoleID).IsEqualTo(LoginInfo.RoleID);
                if (sq.GetRecordCount() == 0)
                {
                    filterContext.Result = new RedirectResult("/account/nopower");
                }
            }
        }
    }
}
