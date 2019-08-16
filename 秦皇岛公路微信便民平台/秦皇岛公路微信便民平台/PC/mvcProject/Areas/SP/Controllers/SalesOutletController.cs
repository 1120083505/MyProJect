using Core;
using Microsoft.Reporting.WebForms;
using Models;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using ZrSoft;

namespace mvcProject.Areas.SP.Controllers
{
    public class SalesOutletController : Controller
    {
        public string msg = "";
        public int status = 1;
        private string LogStr = "";
        private ControllerHelper c = new ControllerHelper();
        private QueryPaged query = new QueryPaged();

        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }

        [PowerFilter]
        public ActionResult Info(string id)
        {
            VSP_SaleMain entity = new VSP_SaleMain(VSP_SaleMain.Columns.Id, id);
            ViewBag.Admin = new Sys_Admin(LoginInfo.AdminID);
            SqlQuery sq = new Select().From<VSP_BankAccount>().Where(VSP_BankAccount.Columns.UserId).IsEqualTo(LoginInfo.AdminID);
            List<VSP_BankAccount> list = sq.ExecuteTypedList<VSP_BankAccount>();
            ViewBag.List = list;
            return View(entity);
        }

        [HttpPost]
        public JsonResult GetInfoList(string id)
        {
            SqlQuery sq = new Select().From<VSP_ShangPinInfo>().Where(VSP_ShangPinInfo.Columns.MainId).IsEqualTo(id);
            List<VSP_ShangPinInfo> list = sq.ExecuteTypedList<VSP_ShangPinInfo>();
            VSP_ShangPinInfo Vspm = new VSP_ShangPinInfo();
            Vspm.SumPrice = list.Sum(x => x.SumPrice);
            Vspm.Num = list.Sum(x => x.Num);
            Vspm.Price = list.Sum(x => x.Price);
            Vspm.WareName = "合计";
            list.Add(Vspm);
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            MainId = r.MainId,
                            FormId = r.WareName,
                            Iswarehouse = r.Iswarehouse,
                            Num = r.Num,
                            Price = r.Price,
                            SumPrice = r.SumPrice,
                            Warehouse = r.Name,
                            Customer = r.CustomerName,
                            CustomerId = r.CustomerId,
                            AdminId = r.RealName,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            Memo = r.Memo,
                            Ext1 = r.Ext1,
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3
                        }
              ).ToArray()
            };
            return Json(json);
        }

        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = VSP_SaleMain.Schema;         
            query.init();
            GetQuery(qList);
            query.SqlIn.And(VSP_SaleMain.Columns.Ext1).IsEqualTo("1");
            query.SqlNotIn.And(VSP_SaleMain.Columns.Ext1).IsEqualTo("1");
            query.SqlTotal.And(VSP_SaleMain.Columns.Ext1).IsEqualTo("1");
            int total = 0;
            List<VSP_SaleMain> list = query.Paged(ref total).ExecuteTypedList<VSP_SaleMain>();
            VSP_SaleMain Vspm = new VSP_SaleMain();
            Vspm.TotalPrice = list.Sum(x => x.TotalPrice);
            Vspm.CustomerName = "合计";
            Vspm.OpeningTime = DateTime.Now;
            list.Add(Vspm);
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Customer = r.CustomerName,
                    CustomerId = r.CustomerId,
                    TotalPrice = r.TotalPrice,
                    AdminId = r.RealName,
                    OpeningTime = string.Format("{0:yyyy-MM-dd}", r.OpeningTime),
                    PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                    Ext1 = r.Ext1,
                    Ext2 = r.Ext2,
                    Ext3 = r.Ext3
                })
            };
            return Json(json);
        }

        [HttpPost]
        public JsonResult GetListJson(string id)
        {
            SP_SaleMain SP = new SP_SaleMain(id);
            SqlQuery sq = new Select().From<SP_ShangPinInfo>().Where(SP_ShangPinInfo.Columns.MainId).IsEqualTo(id);
            List<SP_ShangPinInfo> list = sq.ExecuteTypedList<SP_ShangPinInfo>();
            var json = new
            {
                SP.Id,
                SP.Customer,
                OpeningTime = string.Format("{0:yyyy-MM-dd}", SP.PubDate),
                SP.TotalPrice,
                rows = (from r in list
                        select new
                        {
                            r.Id,
                            r.FormId,
                            r.Num,
                            r.Price,
                            r.SumPrice,
                            r.Warehouse,
                            r.Customer,
                            r.Memo
                        }
              ).ToArray()
            };
            return Json(json);
        }

        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<SP_SaleMain>();
            List<SP_SaleMain> list = sq.ExecuteTypedList<SP_SaleMain>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Customer = r.Customer,
                            CustomerId = r.CustomerId,
                            TotalPrice = r.TotalPrice,
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
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
                query.IsEqualTo(qList, VSP_SaleMain.Columns.Id);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.Customer);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.CustomerId);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.AdminId);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.Ext1);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.Ext2);
                query.IsEqualTo(qList, VSP_SaleMain.Columns.Ext3);
            }
            else
            {
                //模糊查询
                query.Like(qList, VSP_SaleMain.Columns.Id);
                query.Like(qList, VSP_SaleMain.Columns.Customer);
                query.Like(qList, VSP_SaleMain.Columns.CustomerId);
                query.Like(qList, VSP_SaleMain.Columns.AdminId);
                query.Like(qList, VSP_SaleMain.Columns.Ext1);
                query.Like(qList, VSP_SaleMain.Columns.Ext2);
                query.Like(qList, VSP_SaleMain.Columns.Ext3);
            }
            query.IsEqualTo(qList, VSP_SaleMain.Columns.TotalPrice);
            query.IsGreaterThanOrEqualTo(qList, VSP_SaleMain.Columns.OpeningTime);
            query.IsLessThanOrEqualTo(qList, VSP_SaleMain.Columns.OpeningTime, "OpeningTime_2");
            //query.IsGreaterThanOrEqualTo(qList, VSP_SaleMain.Columns.EndTime);
            //query.IsLessThanOrEqualTo(qList, VPerDaily.Columns.EndTime,"EndTime_2");
            //query.IsGreaterThanOrEqualTo(qList, VSP_SaleMain.Columns.PubDate);
            //query.IsLessThanOrEqualTo(qList, VSP_SaleMain.Columns.PubDate);
        }

        #endregion 拼接查询条件

        #region Create

        [HttpPost]
        public JsonResult CreateList([System.Web.Http.FromBody]Rootobject model)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (string.IsNullOrEmpty(model.id))
                    {
                        SP_SaleMain SPSM = new SP_SaleMain();
                        SPSM.Id = Utils.GetNewDateID();
                        SPSM.AdminId = LoginInfo.AdminID;
                        SPSM.PubDate = DateTime.Now;
                        SPSM.Customer = model.Customer;
                        SPSM.OpeningTime = DateTime.Parse(model.OpeningTime);
                        SPSM.TotalPrice = decimal.Parse(model.TotalPrice);
                        SPSM.Year = SPSM.OpeningTime.Year.ToString();
                        SPSM.Month = SPSM.OpeningTime.Month.ToString();
                        SPSM.Day = SPSM.OpeningTime.Day.ToString();
                        SPSM.Ext1 = "1";
                        SPSM.Save();
                        foreach (var item in model.Info)
                        {
                            item.MainId = SPSM.Id;
                            item.Id = Utils.GetNewDateID();
                            item.AdminId = LoginInfo.AdminID;
                            item.PubDate = DateTime.Now;
                            item.Customer = SPSM.Customer;
                            item.Iswarehouse = 1;
                            item.Save();
                        }
                    }
                    else
                    {
                        SP_SaleMain SPSM = new SP_SaleMain(model.id);
                        //SPSM.Id = Utils.GetNewDateID();
                        //SPSM.AdminId = LoginInfo.AdminID;
                        //SPSM.PubDate = DateTime.Now;
                        SPSM.Customer = model.Customer;
                        SPSM.OpeningTime = DateTime.Parse(model.OpeningTime);
                        SPSM.TotalPrice = decimal.Parse(model.TotalPrice);
                        SPSM.Year = SPSM.OpeningTime.Year.ToString();
                        SPSM.Month = SPSM.OpeningTime.Month.ToString();
                        SPSM.Day = SPSM.OpeningTime.Day.ToString();
                        SPSM.Ext1 = "1";
                        SPSM.Save();
                        foreach (var item in model.Info)
                        {
                            if (string.IsNullOrEmpty(item.Id))
                            {
                                item.Id = Utils.GetNewDateID();
                                item.MainId = SPSM.Id;
                                item.AdminId = LoginInfo.AdminID;
                                item.PubDate = DateTime.Now;
                                item.Customer = SPSM.Customer;
                                item.Iswarehouse = 1;
                                item.Save();
                            }
                            else
                            {
                                SP_ShangPinInfo SPINFO = new SP_ShangPinInfo(item.Id);
                                SPINFO.FormId = item.FormId;
                                SPINFO.SumPrice = item.SumPrice;
                                SPINFO.Memo = item.Memo;
                                SPINFO.Num = item.Num;
                                SPINFO.Warehouse = item.Warehouse;
                                SPINFO.Customer = item.Customer;
                                SPINFO.Save();
                            }
                        }
                    }
                    scope.Complete();
                    status = 1;
                    msg = Tip.InsertSucceed;
                }
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.InsertFail;
            }

            return ControllerHelper.jsonresult(status, msg);
        }

        [PowerFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Create(SP_SaleMain model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
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
            GUI.InsertLog("销售", "新增", msg + ":" + model.Id + ",客户:" + model.Customer + ",客户ID:" + model.CustomerId + ",总价合计:" + model.TotalPrice + ",录入人:" + model.AdminId + ",录入时间:" + model.PubDate + ",:" + model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion Create

        #region Edit

        [PowerFilter]
        public ActionResult Edit(string id)
        {
            SP_SaleMain entity = new SP_SaleMain(id);
            return View(entity);
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(SP_SaleMain model)
        {
            try
            {
                SP_SaleMain entity = new SP_SaleMain(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",客户:" + model.Customer
                 + ",客户ID:" + model.CustomerId
                 + ",总价合计:" + model.TotalPrice
                 + ",录入人:" + model.AdminId
                 + ",录入时间:" + model.PubDate
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                 + ",:" + model.Ext3
                    + "";
                    entity.Customer = model.Customer;
                    entity.CustomerId = model.CustomerId;
                    entity.TotalPrice = model.TotalPrice;
                    entity.AdminId = model.AdminId;
                    entity.PubDate = model.PubDate;
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
            GUI.InsertLog("销售", "编辑", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion Edit

        #region Delete

        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    //这里书写需要删除的逻辑代码
                    new Delete().From<SP_SaleMain>().Where(SP_SaleMain.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("销售", "删除", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);
        }

        #endregion Delete

        #region 导出到PDF EXCEL WORD

        [PowerFilter]
        public ActionResult Export(string type, string queryStr)
        {
            GridPager pager = new GridPager();
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = SP_SaleMain.Schema;
            query.init();
            GetQuery(qList);
            List<SP_SaleMain> list = query.Paged().ExecuteTypedList<SP_SaleMain>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/SP_SaleMain.rdlc");
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
                string ExportName = "销售";
                GUI.InsertLog("销售", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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

        #endregion 导出到PDF EXCEL WORD
    }

    //public class Info
    //{
    //    public SP_SaleMain Spsm { get; set; }
    //    public List<SP_ShangPinInfo> ModelList { get; set; }
    //}

    public class Rootobject
    {
        public string id { get; set; }
        public string Customer { get; set; }
        public string OpeningTime { get; set; }
        public string TotalPrice { get; set; }
        public List<SP_ShangPinInfo> Info { get; set; }
    }

    public class Info
    {
        public string FormId { get; set; }
        public string Num { get; set; }
        public string Price { get; set; }
        public string SumPrice { get; set; }
        public string Warehouse { get; set; }
        public string Customer { get; set; }
        public string Memo { get; set; }
    }
}