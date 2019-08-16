using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SubSonic;
using ZrSoft;

namespace Core
{
    public class printControl
    {
        public static string PowerLinkBtn(string actionUrl)
        {
            try
            {
                string FormatStr = "<a href=\"#\" id=\"btn{0}\" class=\"easyui-linkbutton\" data-options=\"plain:true,iconCls:'{1}'\">{2}</a>";
                string RStr = "";
                string[] strs = actionUrl.Split('/');
                string controller = strs[2];
                string[] columns = { 
                               Sys_ModuleOperate.Columns.KeyCode,
                               "Sys_ModuleOperate.Icon",
                               "Sys_ModuleOperate.Name"
                               };
                SqlQuery sq = new Select(columns).From<Sys_Power>()
                    .LeftOuterJoin(Sys_ModuleOperate.IdColumn, Sys_Power.ModuleOperateIDColumn)
                    .LeftOuterJoin(Sys_Module.IdColumn, Sys_ModuleOperate.ModuleIDColumn)
                    .Where(Sys_Module.Columns.EnName).IsEqualTo(controller)
                    .AndExpression(Sys_Power.Columns.RoleID).IsEqualTo(LoginInfo.RoleID)
                    .AndExpression(Sys_ModuleOperate.Columns.IsBtn).IsEqualTo(1)
                    .OrderAsc("Sys_ModuleOperate.Sort");
                DataTable dt = sq.ExecuteDataSet().Tables[0];
                foreach (DataRow m in dt.Rows)
                {
                    RStr += string.Format(FormatStr, m["KeyCode"], m["Icon"], m["Name"]);
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
        public static string SerachType()
        {
            return "<span class=\"st\">查询方式：<label><input type=\"radio\" name=\"searchtype\" value=\"0\" checked=\"checked\" />精确查询</label>"
                    + "<label><input type=\"radio\" name=\"searchtype\" value=\"1\" />模糊查询</label></span>";
        }
    }
}
