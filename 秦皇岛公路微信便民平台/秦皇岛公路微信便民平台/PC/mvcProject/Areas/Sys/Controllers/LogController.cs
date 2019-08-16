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
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Text;
using DevExpress.Web.Mvc;
namespace mvcProject.Areas.Sys.Controllers
{
    public class LogController : Controller
    {
        public string msg = "";
        public int status = 1;
        string LogStr = "";
        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = Sys_Log.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<Sys_Log> list = query.Paged(ref total).ExecuteTypedList<Sys_Log>();
            foreach (var item in list)
            {
                item.AdminId = new Sys_Admin(item.AdminId).RealName;
            }
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    ModuleName = r.ModuleName,
                    OperateName = r.OperateName,
                    OperateMemo = r.OperateMemo,
                    PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                    AdminId = r.AdminId,
                    IP = r.IP

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetListall()
        {
            SqlQuery sq = new Select().From<Sys_Log>();
            List<Sys_Log> list = sq.ExecuteTypedList<Sys_Log>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            ModuleName = r.ModuleName,
                            OperateName = r.OperateName,
                            OperateMemo = r.OperateMemo,
                            PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                            AdminId = r.AdminId,
                            IP = r.IP

                        }
                ).ToArray()
            };
            return Json(json);
        }
        #region 拼接查询条件
        //拼接查询条件  
        public void GetQuery(List<QueryModel> qList)
        {
            GetQuery(qList, null);
        }
        public void GetQuery(List<QueryModel> qList, string[] coulums)
        {
            if (c.GetQueryStr(qList, "searchtype") == "0")
            {
                //精确查询  
                query.IsEqualTo(qList, Sys_Log.Columns.Id);
                query.IsEqualTo(qList, Sys_Log.Columns.ModuleName);
                query.IsEqualTo(qList, Sys_Log.Columns.OperateName);
                query.IsEqualTo(qList, Sys_Log.Columns.OperateMemo);
                query.IsEqualTo(qList, Sys_Log.Columns.AdminId);
                query.IsEqualTo(qList, Sys_Log.Columns.IP);

            }
            else
            {
                //模糊查询  
                query.Like(qList, Sys_Log.Columns.Id);
                query.Like(qList, Sys_Log.Columns.ModuleName);
                query.Like(qList, Sys_Log.Columns.OperateName);
                query.Like(qList, Sys_Log.Columns.OperateMemo);               
                query.Like(qList, Sys_Log.Columns.AdminId);
                query.Like(qList, Sys_Log.Columns.IP);
            }
            query.IsGreaterThanOrEqualTo(qList, Sys_Log.Columns.PubDate);
            query.IsLessThanOrEqualTo(qList, Sys_Log.Columns.PubDate);  

        }
        #endregion
        #region Create

        [PowerFilter]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Create(Sys_Log model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.PubDate = DateTime.Now;
                model.AdminId = LoginInfo.AdminID;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog("操作日志", "新增", msg + ":" + model.Id + ",模块名称:" + model.ModuleName + ",操作名称:" + model.OperateName + ",操作说明:" + model.OperateMemo + ",操作时间:" + model.PubDate + ",操作人:" + model.AdminId + ",IP:" + model.IP + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Log entity = new Sys_Log(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Log model)
        {
            try
            {
                Sys_Log entity = new Sys_Log(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",模块名称:" + model.ModuleName
                 + ",操作名称:" + model.OperateName
                 + ",操作说明:" + model.OperateMemo
                 + ",操作时间:" + model.PubDate
                 + ",操作人:" + model.AdminId
                 + ",IP:" + model.IP
                    + "";
                    entity.ModuleName = model.ModuleName;
                    entity.OperateName = model.OperateName;
                    entity.OperateMemo = model.OperateMemo;
                    entity.PubDate = model.PubDate;
                    entity.AdminId = model.AdminId;
                    entity.IP = model.IP;
                    entity.Save();
                    status = 1;
                    msg = Tip.EditSucceed;
                }
                else
                {
                    status = 0;
                    msg = Tip.EditFail;
                }
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.EditFail + Utils.NoHTML(e.Message);
            }
            GUI.InsertLog("操作日志", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Sys_Log model = new Sys_Log(id);
                try
                {
                    //这里书写需要删除的逻辑代码  
                    Sys_Log.Delete(id);
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
                GUI.InsertLog("操作日志", "删除", msg + ":" + model.Id + ",模块名称:" + model.ModuleName + ",操作名称:" + model.OperateName + ",操作说明:" + model.OperateMemo + ",操作时间:" + model.PubDate + ",操作人:" + model.AdminId + ",IP:" + model.IP + "");
            }
            else
            {

            }
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
  
        public ActionResult Export()
        {
            return View();
        }

        public List<Model.Sys_LogModel> GetModule(string queryStr)
        {
            GridPager pager = new GridPager();            
            query.pager = pager;
            query.TableName = Sys_Log.Schema;            
            query.init();            
            List<Model.Sys_LogModel> modulelist = query.SqlTotal.ExecuteTypedList<Model.Sys_LogModel>();
            return modulelist;
        }

        mvcProject.Report.XtraReport1 report = new mvcProject.Report.XtraReport1();

        public ActionResult DocumentViewerPartial(string query)
        {
            report.DataSource = GetModule(query);
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerPartialExport(string query)
        {
            report.DataSource = GetModule(query);
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}