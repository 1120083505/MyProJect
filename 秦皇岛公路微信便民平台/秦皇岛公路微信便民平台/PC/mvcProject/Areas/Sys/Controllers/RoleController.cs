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
    public class RoleController : Controller
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
            query.TableName = Sys_Role.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<Sys_Role> list = query.Paged(ref total).ExecuteTypedList<Sys_Role>();
            var json = new
           {
               total = total,
               pager = query.pager,
               rows = list.Select((r, i) => new
               {
                   RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                   Id = r.Id,
                   Name = r.Name,
                   Memo = r.Memo,
                   PubDate = r.PubDate.ToString("yyyy-MM-dd")
               })
           };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetListall()
        {
            SqlQuery sq = new Select().From<Sys_Role>();
            List<Sys_Role> list = sq.ExecuteTypedList<Sys_Role>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Memo = r.Memo,
                            PubDate = r.PubDate.ToString("yyyy-MM-dd")

                        }
                ).ToArray()
            };
            return Json(json);
        }
        //获取所有的数据
        [HttpPost]
        public JsonResult GetAllList()
        {
            string[] columns = { 
                               Sys_Role.Columns.Id,
                               Sys_Role.Columns.Name
                               };
            SqlQuery sq = new Select(columns).From<Sys_Role>();
            List<Sys_Role> list = sq.ExecuteTypedList<Sys_Role>();
            var json = new
            {
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name

                        }).ToArray()

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
                query.IsEqualTo(qList, Sys_Role.Columns.Id);
                query.IsEqualTo(qList, Sys_Role.Columns.Name);
                query.IsEqualTo(qList, Sys_Role.Columns.Memo);

            }
            else
            {
                //模糊查询  
                query.Like(qList, Sys_Role.Columns.Id);
                query.Like(qList, Sys_Role.Columns.Name);
                query.Like(qList, Sys_Role.Columns.Memo);
            }
            //query.IsGreaterThanOrEqualTo(qList, Sys_Role.Columns.PubDate);  
            //query.IsLessThanOrEqualTo(qList, Sys_Role.Columns.PubDate);  

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
        public JsonResult Create(Sys_Role model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.PubDate = DateTime.Now;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog(" ", "新增", msg + ":" + model.Id + ",角色名称:" + model.Name + ",备注:" + model.Memo + ",操作日期:" + model.PubDate + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Role entity = new Sys_Role(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Role model)
        {
            try
            {
                Sys_Role entity = new Sys_Role(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",角色名称:" + model.Name
                 + ",备注:" + model.Memo
                 + ",操作日期:" + model.PubDate
                    + "";
                    entity.Name = model.Name;
                    entity.Memo = model.Memo;
                    entity.PubDate = model.PubDate;
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
                Sys_Role model = new Sys_Role(id);
                try
                {
                    //这里书写需要删除的逻辑代码  
                    Sys_Role.Delete(id);
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
                GUI.InsertLog(" ", "删除", msg + ":" + model.Id + ",角色名称:" + model.Name + ",备注:" + model.Memo + ",操作日期:" + model.PubDate + "");
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
            query.TableName = Sys_Role.Schema;
            query.init();
            GetQuery(qList);
            List<Sys_Role> list = query.Paged().ExecuteTypedList<Sys_Role>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/Sys_Role.rdlc");
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
                string ExportName = "Sys_Role";
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
