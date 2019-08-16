using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using SubSonic;
using ZrSoft;
using Core;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace mvcProject.Areas.Sys.Controllers
{
    public class PowerController : Controller
    {
        public string msg = "";
        public int status = 1;

        ControllerHelper c = new ControllerHelper(); 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(string RoleId, string ModuleId)
        {
            string sql = "SELECT *,(SELECT COUNT(1) FROM Sys_Power WHERE roleID='{0}' AND Sys_Power.ModuleOperateID=Sys_ModuleOperate.ID) AS Total FROM dbo.Sys_ModuleOperate"
                + " WHERE ModuleID='{1}'";
            sql = string.Format(sql, RoleId, ModuleId);
            DataTable dt = DataService.GetDataSet(new QueryCommand(sql)).Tables[0];
            var json = new
            {
                rows = (from r in dt.AsEnumerable()
                        select new
                        {
                            Id = r["Id"],
                            Icon = r["Icon"],
                            KeyCode = r["KeyCode"],
                            Name = r["Name"],
                            IsHas = int.Parse(r["Total"].ToString()) > 0 ? true : false
                        }
                        ).ToArray()

            };
            return Json(json);
        }

        [HttpPost]
        [PowerFilter(ActionName = "Save")]
        public JsonResult UpdatePower(string OkIds, string NoIds, string RoleId)
        {
            try
            {
                string[] ok = OkIds.Split(',');
                for (int i = 0; i < ok.Length - 1; i++)
                {
                    Sys_Power s = new Sys_Power();
                    s.Id = Utils.GetNewDateID() + i;
                    s.ModuleOperateID = ok[i];
                    s.RoleID = RoleId;
                    s.Save();
                }
                if (NoIds.Length > 1)
                {
                    string sql = "DELETE Sys_Power WHERE ModuleOperateID IN(" + NoIds.Substring(0, NoIds.Length - 1) + ") AND RoleID='" + RoleId + "' ";
                    DataService.ExecuteQuery(new QueryCommand(sql));
                }
                status = 1;
                msg = Tip.SaveSucceed;

            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.SaveFail + Utils.NoHTML(e.Message);
            }
            return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
        }
        /// <summary>
        /// 提交更改权限
        /// </summary>
        /// <param name="powerids"></param>
        /// <param name="pType"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        [PowerFilter(ActionName = "Accept")]
        public JsonResult ChangePower(string powerids, int pType, string pid)
        {
            try
            {
                DataTable dt = new Select().From<Sys_Power>().Where(Sys_Power.Columns.Id).IsNull()
                    .ExecuteDataSet().Tables[0];
                new Delete().From<Sys_Power>()
                    .Where(Sys_Power.Columns.RoleID).IsEqualTo(pid)
                    .Execute();
                int i = 0;
                foreach (string powerid in powerids.Split(','))
                {
                    //DataRow dr = dt.NewRow();
                    //System.Threading.Thread.Sleep(50);
                    //dr["ID"] = Utils.GetNewDateID() + Guid.NewGuid().ToString().Substring(0, 5) + i;
                    //dr["RoleId"] = pid;
                    //dr["ModuleOperateID"] = powerid;
                    //dt.Rows.Add(dr); 
                    SqlQuery sq = new Select().From<Sys_ModuleOperate>().Where(Sys_ModuleOperate.Columns.Id).IsEqualTo(powerid);
                    if (sq.GetRecordCount() > 0)
                    {
                        i++;
                        DataRow dr = dt.NewRow();
                        //System.Threading.Thread.Sleep(50);
                        dr["ID"] = Utils.GetNewDateID() + i;
                        dr["RoleId"] = pid;
                        dr["ModuleOperateID"] = powerid;
                        dt.Rows.Add(dr);
                    }
                }

                //if (!string.IsNullOrEmpty(powerids))
                //{
                string sqcon = ConfigurationManager.ConnectionStrings["ZrSoft"].ConnectionString;
                SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(sqcon, SqlBulkCopyOptions.CheckConstraints);
                sqlbulkcopy.DestinationTableName = "Sys_Power";//数据库中的表名
                sqlbulkcopy.WriteToServer(dt);
                //}
                status = 1;
                msg = Tip.OperateSucceed;
            }
            catch (Exception e)
            {
                status = 0;
                msg = e.Message;
            }
            return ControllerHelper.jsonresult(status, msg);
        }

    }

}
