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
namespace mvcProject.Areas.SP.Controllers
{
    public class ShangPinController : Controller
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
            SP_ShangPin entity = new SP_ShangPin(id);
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
            query.TableName = VSP_ShangPin.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<VSP_ShangPin> list = query.Paged(ref total).ExecuteTypedList<VSP_ShangPin>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    WareName = r.WareName,
                    WareType = r.Name,
                    WarePrice = r.WarePrice,
                    Specifications = r.Specifications,
                    SellingPrice = r.SellingPrice,
                    Warehouse = r.Warehouse,
                    Memo = r.Memo,
                    AdminId = r.RealName,
                    Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                    Ext1 = r.Ext1,
                    Ext2 = r.Ext2,
                    Ext3 = r.Ext3

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<SP_ShangPin>();
            List<SP_ShangPin> list = sq.ExecuteTypedList<SP_ShangPin>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            WareName = r.WareName,
                            WareType = r.WareType,
                            WarePrice = r.WarePrice,
                            Specifications = r.Specifications,
                            SellingPrice = r.SellingPrice,
                            Warehouse = r.Warehouse,
                            Memo = r.Memo,
                            AdminId = r.AdminId,
                            Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                            Ext1 = r.Ext1,
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

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
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Id);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.WareName);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.WareType);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Specifications);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Warehouse);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Memo);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.AdminId);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Ext1);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Ext2);
                query.IsEqualTo(qList, VSP_ShangPin.Columns.Ext3);

            }
            else
            {
                //模糊查询  
                query.Like(qList, VSP_ShangPin.Columns.Id);
                query.Like(qList, VSP_ShangPin.Columns.WareName);
                query.Like(qList, VSP_ShangPin.Columns.WareType);
                query.Like(qList, VSP_ShangPin.Columns.Specifications);
                query.Like(qList, VSP_ShangPin.Columns.Warehouse);
                query.Like(qList, VSP_ShangPin.Columns.Memo);
                query.Like(qList, VSP_ShangPin.Columns.AdminId);
                query.Like(qList, VSP_ShangPin.Columns.Ext1);
                query.Like(qList, VSP_ShangPin.Columns.Ext2);
                query.Like(qList, VSP_ShangPin.Columns.Ext3);
            }
            query.IsEqualTo(qList, VSP_ShangPin.Columns.WarePrice);
            query.IsEqualTo(qList, VSP_ShangPin.Columns.SellingPrice);
            //query.IsGreaterThanOrEqualTo(qList, SP_ShangPin.Columns.Pubdate);  
            //query.IsLessThanOrEqualTo(qList, SP_ShangPin.Columns.Pubdate);  

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
        public JsonResult Create(SP_ShangPin model)
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
            GUI.InsertLog("商品", "新增", msg + ":" + model.Id + ",商品名称:" + model.WareName + ",商品类型:" + model.WareType + ",进货价:" + model.WarePrice + ",规格型号:" + model.Specifications + ",销售价:" + model.SellingPrice + ",所属仓库:" + model.Warehouse + ",备注:" + model.Memo + ",:" + model.AdminId + ",:" + model.Pubdate + ",:" + model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            SP_ShangPin entity = new SP_ShangPin(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(SP_ShangPin model)
        {
            try
            {
                SP_ShangPin entity = new SP_ShangPin(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",商品名称:" + model.WareName
                 + ",商品类型:" + model.WareType
                 + ",进货价:" + model.WarePrice
                 + ",规格型号:" + model.Specifications
                 + ",销售价:" + model.SellingPrice
                 + ",所属仓库:" + model.Warehouse
                 + ",备注:" + model.Memo
                 + ",:" + model.AdminId
                 + ",:" + model.Pubdate
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                 + ",:" + model.Ext3
                    + "";
                    entity.WareName = model.WareName;
                    entity.WareType = model.WareType;
                    entity.WarePrice = model.WarePrice;
                    entity.Specifications = model.Specifications;
                    entity.SellingPrice = model.SellingPrice;
                    entity.Warehouse = model.Warehouse;
                    entity.Memo = model.Memo;
                    entity.AdminId = model.AdminId;
                    entity.Pubdate = model.Pubdate;
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
            GUI.InsertLog("商品", "编辑", msg + LogStr);
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
                    new Delete().From<SP_ShangPin>().Where(SP_ShangPin.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("商品", "删除", msg + LogStr);
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
            query.TableName = SP_ShangPin.Schema;
            query.init();
            GetQuery(qList);
            List<SP_ShangPin> list = query.Paged().ExecuteTypedList<SP_ShangPin>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/SP_ShangPin.rdlc");
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
                string ExportName = "商品";
                GUI.InsertLog("商品", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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