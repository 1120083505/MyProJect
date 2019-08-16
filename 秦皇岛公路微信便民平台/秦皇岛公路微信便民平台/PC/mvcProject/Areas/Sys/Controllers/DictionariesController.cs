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
    public class DictionariesController : Controller
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
            query.TableName = Sys_Dictionaries.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<Sys_Dictionaries> list = query.Paged(ref total).ExecuteTypedList<Sys_Dictionaries>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    LimitLoginCount = r.LimitLoginCount,
                    LimitLoginTime = r.LimitLoginTime,
                    Ident = r.Ident == 0 ? "Ip限制" : "错误登录次数限制"
                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetListall()
        {
            SqlQuery sq = new Select().From<Sys_Dictionaries>();
            List<Sys_Dictionaries> list = sq.ExecuteTypedList<Sys_Dictionaries>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            LimitLoginCount = r.LimitLoginCount,
                            LimitLoginTime = r.LimitLoginTime,
                            Ident = r.Ident

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
                query.IsEqualTo(qList, Sys_Dictionaries.Columns.Id);

            }
            else
            {
                //模糊查询  
                query.Like(qList, Sys_Dictionaries.Columns.Id);
            }
            query.IsEqualTo(qList, Sys_Dictionaries.Columns.LimitLoginCount);
            query.IsEqualTo(qList, Sys_Dictionaries.Columns.LimitLoginTime);
            query.IsEqualTo(qList, Sys_Dictionaries.Columns.Ident);

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
        public JsonResult Create(Sys_Dictionaries model)
        {
            try
            {
                SqlQuery sq = new Select().From<Sys_Dictionaries>()
                    .Where(Sys_Dictionaries.Columns.Ident)
                    .IsEqualTo(model.Ident);
                if (sq.GetRecordCount() > 0)
                {
                    status = 0;
                    msg = Tip.InsertFail;
                }

                else
                {
                    model.Id = Utils.GetNewDateID();
                    model.Save();
                    status = 1;
                    msg = Tip.InsertSucceed;
                }
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog(" ", "新增", msg + "Id:" + model.Id + ",限制登录次数:" + model.LimitLoginCount + ",限制登录时长:" + model.LimitLoginTime + ",判断是否限制IP登录标识(0、同Ip限制1、错误次数):" + model.Ident + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Dictionaries entity = new Sys_Dictionaries(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Dictionaries model)
        {
            try
            {
                Sys_Dictionaries entity = new Sys_Dictionaries(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",限制登录次数:" + model.LimitLoginCount
                 + ",限制登录时长:" + model.LimitLoginTime
                 + ",判断是否限制IP登录标识(0、同Ip限制1、错误次数):" + model.Ident
                    + "";
                    entity.LimitLoginCount = model.LimitLoginCount;
                    entity.LimitLoginTime = model.LimitLoginTime;
                    entity.Ident = model.Ident;
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
            GUI.InsertLog(" ", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Sys_Dictionaries model = new Sys_Dictionaries(id);
                try
                {
                    //这里书写需要删除的逻辑代码  
                    Sys_Dictionaries.Delete(id);
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
                GUI.InsertLog(" ", "删除", msg + "Id:" + model.Id + ",限制登录次数:" + model.LimitLoginCount + ",限制登录时长:" + model.LimitLoginTime + ",判断是否限制IP登录标识(0、同Ip限制1、错误次数):" + model.Ident + "");
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
            query.TableName = Sys_Dictionaries.Schema;
            query.init();
            GetQuery(qList);
            List<Sys_Dictionaries> list = query.Paged().ExecuteTypedList<Sys_Dictionaries>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/Sys_Dictionaries.rdlc");
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
                string ExportName = "Sys_Dictionaries";
                GUI.InsertLog(" ", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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