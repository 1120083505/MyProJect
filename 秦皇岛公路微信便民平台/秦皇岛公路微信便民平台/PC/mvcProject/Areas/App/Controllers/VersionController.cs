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
namespace mvcProject.Areas.App.Controllers
{
    public class VersionController : Controller
    {
        public string msg = "";
        public int status = 1;
        string LogStr = "";
        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        //[PowerFilter]
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
            query.TableName = App_Version.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<App_Version> list = query.Paged(ref total).ExecuteTypedList<App_Version>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Code = r.Code,
                    //Url = r.Url,
                    Memo = r.Memo,
                    PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                    AdminId = new Sys_Admin(r.AdminId).RealName

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetListall()
        {
            SqlQuery sq = new Select().From<App_Version>();
            List<App_Version> list = sq.ExecuteTypedList<App_Version>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Code = r.Code,
                            Url = r.Url,
                            Memo = r.Memo,
                            PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                            AdminId = r.AdminId

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
                query.IsEqualTo(qList, App_Version.Columns.Id);
                query.IsEqualTo(qList, App_Version.Columns.Code);
                query.IsEqualTo(qList, App_Version.Columns.Url);
                query.IsEqualTo(qList, App_Version.Columns.Memo);
                query.IsEqualTo(qList, App_Version.Columns.AdminId);

            }
            else
            {
                //模糊查询  
                query.Like(qList, App_Version.Columns.Id);
                query.Like(qList, App_Version.Columns.Code);
                query.Like(qList, App_Version.Columns.Url);
                query.Like(qList, App_Version.Columns.Memo);
                query.Like(qList, App_Version.Columns.AdminId);
            }
            query.IsGreaterThanOrEqualTo(qList, App_Version.Columns.PubDate, "PubDate");
            query.IsLessThanOrEqualTo(qList, App_Version.Columns.PubDate, "PubDate_1");  

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
        public JsonResult Create(App_Version model)
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
            GUI.InsertLog("APP版本中心", "新增", msg + ":" + model.Id + ",版本号:" + model.Code + ",:" + model.Url + ",介绍:" + model.Memo + ",发布时间:" + model.PubDate + ",发布人:" + model.AdminId + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            App_Version entity = new App_Version(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(App_Version model)
        {
            try
            {
                App_Version entity = new App_Version(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",版本号:" + model.Code
                 + ",:" + model.Url
                 + ",介绍:" + model.Memo
                 + ",发布时间:" + model.PubDate
                 + ",发布人:" + model.AdminId
                    + "";
                    entity.Code = model.Code;
                    entity.Url = model.Url;
                    entity.Memo = model.Memo;
                    entity.PubDate = model.PubDate;
                    entity.AdminId = model.AdminId;
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
            GUI.InsertLog("APP版本中心", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                App_Version model = new App_Version(id);
                try
                {
                    //这里书写需要删除的逻辑代码  
                    new Delete().From<App_Version>().Where(App_Version.Columns.Id).In(id.Split(','));
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
                GUI.InsertLog("APP版本中心", "删除", msg + ":" + model.Id + ",版本号:" + model.Code + ",:" + model.Url + ",介绍:" + model.Memo + ",发布时间:" + model.PubDate + ",发布人:" + model.AdminId + "");
            }
            else
            {

            }
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
            query.TableName = App_Version.Schema;
            query.init();
            GetQuery(qList);
            List<App_Version> list = query.Paged().ExecuteTypedList<App_Version>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/App_Version.rdlc");
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
                string ExportName = "APP版本中心";
                GUI.InsertLog("APP版本中心", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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