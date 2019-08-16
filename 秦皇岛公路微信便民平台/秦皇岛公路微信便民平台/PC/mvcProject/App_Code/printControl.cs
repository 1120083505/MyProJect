using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using SubSonic;
using ZrSoft;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using System.Resources;

namespace Core
{
    public class printControl
    {
        /// <summary>
        /// 生成权限按钮
        /// </summary>
        /// <param name="actionUrl">当前的url</param>
        /// <returns></returns>
        public static string PowerLinkBtn(string actionUrl)
        {
            try
            {
                Core.langHelper langhelper = new Core.langHelper();
                HttpContextBase contextWrapper = new HttpContextWrapper(HttpContext.Current);
                RouteData routeData = RouteTable.Routes.GetRouteData(contextWrapper);
                //string FormatStr = "<a href=\"#\" id=\"btn{0}\" class=\"easyui-linkbutton\" data-options=\"plain:true,iconCls:'{1}'\">{2}</a>";
                string FormatStr = "<button id=\"btn{0}\" class=\"layui-btn layui-btn-primary  layui-btn-small\"><i class=\"layui-icon\">&#x{1}</i> {2} </button></a>";
                string RStr = "";
                string controller = routeData.Values["controller"].ToString();
                string[] columns = { 
                               Sys_ModuleOperate.Columns.KeyCode,
                               "Sys_ModuleOperate.Icon",
                               "Sys_ModuleOperate.KeyCode"
                               };
                SqlQuery sq = new Select(columns).From<Sys_Power>()
                    .LeftOuterJoin(Sys_ModuleOperate.IdColumn, Sys_Power.ModuleOperateIDColumn)
                    .LeftOuterJoin(Sys_Module.IdColumn, Sys_ModuleOperate.ModuleIDColumn)
                    .Where(Sys_Module.Columns.EnName).IsEqualTo(controller)
                    .AndExpression(Sys_Power.Columns.RoleID).IsEqualTo(LoginInfo.RoleID)
                    .AndExpression(Sys_ModuleOperate.Columns.IsBtn).IsEqualTo(1)
                    .AndExpression(Sys_ModuleOperate.Columns.KeyCode).IsNotEqualTo("Search")
                    .OrderAsc("Sys_ModuleOperate.Sort");
                DataTable dt = sq.ExecuteDataSet().Tables[0];
                foreach (DataRow m in dt.Rows)
                {
                    RStr += string.Format(FormatStr, m["KeyCode"], m["Icon"], langhelper.GetLangString(m["KeyCode"].ToString()));
                }
                return RStr;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static string ifrSrc()
        {
            return "<iframe width='100%' height='98%' scrolling='auto' frameborder='0'' src='{0}'></iframe>";
        }
        /// <summary>
        /// 查询方式
        /// </summary>
        /// <returns>生成精确查询和模糊查询两个按钮</returns>
        public static string SerachType()
        {
            return "<span class=\"st\">查询方式：<label><input type=\"radio\" name=\"searchtype\" value=\"0\" checked=\"checked\" />精确查询</label>"
                    + "<label><input type=\"radio\" name=\"searchtype\" value=\"1\" />模糊查询</label></span>";
        }
    }
}
