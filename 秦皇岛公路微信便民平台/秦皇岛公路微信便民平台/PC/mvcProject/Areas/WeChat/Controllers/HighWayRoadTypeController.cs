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
namespace mvcProject.Areas.WeChat.Controllers
{
    public class HighWayRoadTypeController : Controller
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
            WeChat_HighWayRoadType entity = new WeChat_HighWayRoadType(id);
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
            query.TableName = WeChat_HighWayRoadType.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<WeChat_HighWayRoadType> list = query.Paged(ref total).ExecuteTypedList<WeChat_HighWayRoadType>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Name = r.Name,
                    Type = r.Type,
                    AdminId = r.AdminId,
                    PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                    EditAdminId = r.EditAdminId,
                    EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                    Memo = r.Memo

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<WeChat_HighWayRoadType>();
            List<WeChat_HighWayRoadType> list = sq.ExecuteTypedList<WeChat_HighWayRoadType>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Type = r.Type,
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                            Memo = r.Memo

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
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.Id);
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.Name);
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.Type);
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.AdminId);
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.EditAdminId);
                query.IsEqualTo(qList, WeChat_HighWayRoadType.Columns.Memo);

            }
            else
            {
                //模糊查询  
                query.Like(qList, WeChat_HighWayRoadType.Columns.Id);
                query.Like(qList, WeChat_HighWayRoadType.Columns.Name);
                query.Like(qList, WeChat_HighWayRoadType.Columns.Type);
                query.Like(qList, WeChat_HighWayRoadType.Columns.AdminId);
                query.Like(qList, WeChat_HighWayRoadType.Columns.EditAdminId);
                query.Like(qList, WeChat_HighWayRoadType.Columns.Memo);
            }
            //query.IsGreaterThanOrEqualTo(qList, WeChat_HighWayRoadType.Columns.PubDate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_HighWayRoadType.Columns.PubDate);  
            //query.IsGreaterThanOrEqualTo(qList, WeChat_HighWayRoadType.Columns.EditPubDate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_HighWayRoadType.Columns.EditPubDate);  

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
        public JsonResult Create(WeChat_HighWayRoadType model)
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
            GUI.InsertLog("类型", "新增", msg + ":" + model.Id + ",类型名称:" + model.Name + ",类型:" + model.Type + ",操作人:" + model.AdminId + ",操作时间:" + model.PubDate + ",最后修改人:" + model.EditAdminId + ",最后修改时间:" + model.EditPubDate + ",备注:" + model.Memo + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            WeChat_HighWayRoadType entity = new WeChat_HighWayRoadType(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(WeChat_HighWayRoadType model)
        {
            try
            {
                WeChat_HighWayRoadType entity = new WeChat_HighWayRoadType(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",类型名称:" + model.Name
                 + ",类型:" + model.Type
                 + ",操作人:" + model.AdminId
                 + ",操作时间:" + model.PubDate
                 + ",最后修改人:" + LoginInfo.AdminID
                 + ",最后修改时间:" + DateTime.Now
                 + ",备注:" + model.Memo
                    + "";
                    entity.Name = model.Name;
                    entity.Type = model.Type;
                    entity.AdminId = model.AdminId;
                    entity.PubDate = model.PubDate;
                    entity.EditAdminId = LoginInfo.AdminID;
                    entity.EditPubDate = DateTime.Now;
                    entity.Memo = model.Memo;
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
            GUI.InsertLog("类型", "编辑", msg + LogStr);
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
                    new Delete().From<WeChat_HighWayRoadType>().Where(WeChat_HighWayRoadType.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("类型", "删除", msg + LogStr);
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
            query.TableName = WeChat_HighWayRoadType.Schema;
            query.init();
            GetQuery(qList);
            List<WeChat_HighWayRoadType> list = query.Paged().ExecuteTypedList<WeChat_HighWayRoadType>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/WeChat_HighWayRoadType.rdlc");
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
                string ExportName = "类型";
                GUI.InsertLog("类型", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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
                return View("/views/export/error.cshtml");
            }
        }
        #endregion
    }
}