using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core;
using Microsoft.Reporting.WebForms;
using Models;
using SubSonic;
using ZrSoft;

namespace mvcProject.Areas.CK.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ControllerHelper c = new ControllerHelper();
        private string LogStr = "";
        public string msg = "";
        private readonly QueryPaged query = new QueryPaged();
        public int status = 1;

        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }

        [PowerFilter]
        public ActionResult Info(string id)
        {
            var entity = new CK_Warehouse(id);
            entity.AdminId = new Sys_Admin(entity.AdminId).RealName;
            return View(entity);
        }

        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            var qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = CK_Warehouse.Schema;
            query.init();
            GetQuery(qList);
            var total = 0;
            var list = query.Paged(ref total).ExecuteTypedList<CK_Warehouse>();
            var json = new
            {
                total,
                query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = i++ + (pager.page - 1) * pager.rows + 1,
                    r.Id,
                    r.Name,
                    r.Area,
                    r.Ardess,
                    r.Stock,
                    r.Memo,
                    AdminId = new Sys_Admin(r.AdminId).RealName,
                    Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                    r.Ext1,
                    r.Ext2,
                    r.Ext3
                })
            };
            return Json(json);
        }

        [HttpPost]
        public JsonResult GetAllList()
        {
            var sq = new Select().From<CK_Warehouse>();
            var list = sq.ExecuteTypedList<CK_Warehouse>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            r.Id,
                            r.Name,
                            r.Area,
                            r.Ardess,
                            r.Stock,
                            r.Memo,
                            r.AdminId,
                            Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                            r.Ext1,
                            r.Ext2,
                            r.Ext3
                        }
                    ).ToArray()
            };
            return Json(json);
        }

        #region Delete  

        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                try
                {
                    //这里书写需要删除的逻辑代码 
                    new Delete().From<CK_Warehouse>().Where(CK_Warehouse.Columns.Id).In(id.Split(','))
                        .Execute();
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }

            GUI.InsertLog(" 仓库", "删除", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion

        #region 导出到PDF EXCEL WORD 

        [PowerFilter]
        public ActionResult Export(string type, string queryStr)
        {
            var pager = new GridPager();
            var qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = CK_Warehouse.Schema;
            query.init();
            GetQuery(qList);
            var list = query.Paged().ExecuteTypedList<CK_Warehouse>();
            var localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/CK_Warehouse.rdlc");
                var reportDataSource = new ReportDataSource("DataSet", list);
                localReport.DataSources.Add(reportDataSource);
                if (type.ToLower() == "print")
                {
                    //直接打印
                    ReportPrint.Run(localReport);
                    return View("/views/export/print.cshtml");
                }

                var reportType = type;
                string mimeType;
                string encoding;
                string fileNameExtension;

                var deviceInfo =
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
                var ExportName = " 仓库";
                GUI.InsertLog(" 仓库", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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
                query.IsEqualTo(qList, CK_Warehouse.Columns.Id);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Name);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Ardess);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Stock);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Memo);
                query.IsEqualTo(qList, CK_Warehouse.Columns.AdminId);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Ext1);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Ext2);
                query.IsEqualTo(qList, CK_Warehouse.Columns.Ext3);
            }
            else
            {
                //模糊查询  
                query.Like(qList, CK_Warehouse.Columns.Id);
                query.Like(qList, CK_Warehouse.Columns.Name);
                query.Like(qList, CK_Warehouse.Columns.Ardess);
                query.Like(qList, CK_Warehouse.Columns.Stock);
                query.Like(qList, CK_Warehouse.Columns.Memo);
                query.Like(qList, CK_Warehouse.Columns.AdminId);
                query.Like(qList, CK_Warehouse.Columns.Ext1);
                query.Like(qList, CK_Warehouse.Columns.Ext2);
                query.Like(qList, CK_Warehouse.Columns.Ext3);
            }

            query.IsEqualTo(qList, CK_Warehouse.Columns.Area);
            //query.IsGreaterThanOrEqualTo(qList, CK_Warehouse.Columns.Pubdate);  
            //query.IsLessThanOrEqualTo(qList, CK_Warehouse.Columns.Pubdate);  
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
        public JsonResult Create(CK_Warehouse model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
                model.Pubdate = DateTime.Now;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }

            GUI.InsertLog(" 仓库", "新增",
                msg + ":" + model.Id + ",仓库名称:" + model.Name + ",面积:" + model.Area + ",地址:" + model.Ardess + ",库存:" +
                model.Stock + ",备注:" + model.Memo + ",录入人:" + model.AdminId + ",录入时间:" + model.Pubdate + ",:" +
                model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion

        #region Edit  

        [PowerFilter]
        public ActionResult Edit(string id)
        {
            var entity = new CK_Warehouse(id);
            return View(entity);
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(CK_Warehouse model)
        {
            try
            {
                var entity = new CK_Warehouse(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                             + "Id:" + model.Id
                             + ",仓库名称:" + model.Name
                             + ",面积:" + model.Area
                             + ",地址:" + model.Ardess
                             + ",库存:" + model.Stock
                             + ",备注:" + model.Memo
                             + ",录入人:" + model.AdminId
                             + ",录入时间:" + model.Pubdate
                             + ",:" + model.Ext1
                             + ",:" + model.Ext2
                             + ",:" + model.Ext3
                             + "";
                    entity.Name = model.Name;
                    entity.Area = model.Area;
                    entity.Ardess = model.Ardess;
                    entity.Stock = model.Stock;
                    entity.Memo = model.Memo;
                    //entity.AdminId = model.AdminId;
                    //entity.Pubdate = model.Pubdate;
                    entity.Ext1 = model.Ext1;
                    entity.Ext2 = model.Ext2;
                    entity.Ext3 = model.Ext3;
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

            GUI.InsertLog(" 仓库", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion
    }
}