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
namespace mvcProject.Areas.Sys.Controllers
{
    public class RatingController : Controller
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
        [PowerFilter]
        public ActionResult Info(string id)
        {
            Sys_Rating entity = new Sys_Rating(id);
            return View(entity);
        }
        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = Sys_Rating.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<Sys_Rating> list = query.Paged(ref total).ExecuteTypedList<Sys_Rating>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Type = r.Type,
                    Name = r.Name,
                    Memo = r.Memo,
                    AdminId = r.AdminId,
                    PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                    EditAdminId = r.EditAdminId,
                    EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate)

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<Sys_Rating>();
            List<Sys_Rating> list = sq.ExecuteTypedList<Sys_Rating>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Type = r.Type,
                            Name = r.Name,
                            Memo = r.Memo,
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate)

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
                query.IsEqualTo(qList, Sys_Rating.Columns.Id);
                query.IsEqualTo(qList, Sys_Rating.Columns.Name);
                query.IsEqualTo(qList, Sys_Rating.Columns.Memo);
                query.IsEqualTo(qList, Sys_Rating.Columns.AdminId);
                query.IsEqualTo(qList, Sys_Rating.Columns.EditAdminId);

            }
            else
            {
                //模糊查询  
                query.Like(qList, Sys_Rating.Columns.Id);
                query.Like(qList, Sys_Rating.Columns.Name);
                query.Like(qList, Sys_Rating.Columns.Memo);
                query.Like(qList, Sys_Rating.Columns.AdminId);
                query.Like(qList, Sys_Rating.Columns.EditAdminId);
            }
            query.IsEqualTo(qList, Sys_Rating.Columns.Type);
            //query.IsGreaterThanOrEqualTo(qList, Sys_Rating.Columns.PubDate);  
            //query.IsLessThanOrEqualTo(qList, Sys_Rating.Columns.PubDate);  
            //query.IsGreaterThanOrEqualTo(qList, Sys_Rating.Columns.EditPubDate);  
            //query.IsLessThanOrEqualTo(qList, Sys_Rating.Columns.EditPubDate);  

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
        public JsonResult Create(Sys_Rating model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
                model.PubDate = DateTime.Now;
                model.EditAdminId = LoginInfo.AdminID;
                model.EditPubDate = DateTime.Now;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog("等级说明", "新增", msg + ":" + model.Id + ",类别:" + model.Type + ",名称:" + model.Name + ",备注:" + model.Memo + ",:" + model.AdminId + ",:" + model.PubDate + ",:" + model.EditAdminId + ",:" + model.EditPubDate + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Rating entity = new Sys_Rating(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Rating model)
        {
            try
            {
                Sys_Rating entity = new Sys_Rating(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",类别:" + model.Type
                 + ",名称:" + model.Name
                 + ",备注:" + model.Memo
                 + ",:" + model.AdminId
                 + ",:" + model.PubDate
                 + ",:" + model.EditAdminId
                 + ",:" + model.EditPubDate
                    + "";
                    entity.Type = model.Type;
                    entity.Name = model.Name;
                    entity.Memo = model.Memo;
                    entity.AdminId = model.AdminId;
                    entity.PubDate = model.PubDate;
                    entity.EditAdminId = model.EditAdminId;
                    entity.EditPubDate = model.EditPubDate;
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
            GUI.InsertLog("等级说明", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    //这里书写需要删除的逻辑代码 
                    new Delete().From<Sys_Rating>().Where(Sys_Rating.Columns.Id).In(id.Split(','))
                    .Execute();
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
            }
            else
            {

            }
            GUI.InsertLog("等级说明", "删除", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region 导出到PDF EXCEL WORD
        [PowerFilter]
        public ActionResult Export(string type, string queryStr)
        {
            GridPager pager = new GridPager();
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = Sys_Rating.Schema;
            query.init();
            GetQuery(qList);
            List<Sys_Rating> list = query.Paged().ExecuteTypedList<Sys_Rating>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/Sys_Rating.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("DataSet", list);
                localReport.DataSources.Add(reportDataSource);
                if (type.ToLower() == "print")
                {
                    //直接打印
                    ReportPrint.Run(localReport);
                    return View("/views/export/print.cshtml");
                }

                string reportType = type;
                string mimeType;
                string encoding;
                string fileNameExtension;

                string deviceInfo =
                    "<DeviceInfo>" +
                    "<OutPutFormat>" + type + "</OutPutFormat>" +
                    "<PageWidth>11in</PageWidth>" +
                    "<PageHeight>11in</PageHeight>" +
                    "<MarginTop>0.5in</MarginTop>" +
                    "<MarginLeft>1in</MarginLeft>" +
                    "<MarginRight>1in</MarginRight>" +
                    "<MarginBottom>0.5in</MarginBottom>" +
                    "</DeviceInfo>";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = localReport.Render(
                    reportType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings
                    );
                string ExportName = "等级说明";
                GUI.InsertLog("等级说明", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
                switch (type.ToLower())
                {
                    case "pdf":
                        ExportName += ".pdf";
                        break;
                    case "image":
                        ExportName += ".png";
                        break;
                    case "excel":
                        ExportName += ".xls";
                        break;
                    case "word":
                        ExportName += ".doc";
                        break;
                }
                return File(renderedBytes, mimeType, ExportName);
            }
            catch (Exception ex)
            {
                Utils.WriteFile("D://", "222.txt", ex.Message);
                return View("/views/export/error.cshtml");
            }
        }
        #endregion
    }
}