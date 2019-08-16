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
    public class CustomerController : Controller
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
            SP_Customer entity = new SP_Customer(id);
            entity.AdminId = new Sys_Admin(entity.AdminId).RealName;
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
            query.TableName = SP_Customer.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<SP_Customer> list = query.Paged(ref total).ExecuteTypedList<SP_Customer>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    CustomerName = r.CustomerName,
                    Phone = r.Phone,
                    Address = r.Address,
                    Memo = r.Memo,
                    BankAccount = r.BankAccount,
                    AdminId = new Sys_Admin(r.AdminId).RealName,
                    Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                    Ext1 = r.Ext1,
                    Ext2 = r.Ext2

                })
            };
            return Json(json);
        }
       
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<SP_Customer>();
            List<SP_Customer> list = sq.ExecuteTypedList<SP_Customer>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            CustomerName = r.CustomerName,
                            Phone = r.Phone,
                            Address = r.Address,
                            Memo = r.Memo,
                            BankAccount = r.BankAccount,
                            AdminId = r.AdminId,
                            Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                            Ext1 = r.Ext1,
                            Ext2 = r.Ext2

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
                query.IsEqualTo(qList, SP_Customer.Columns.Id);
                query.IsEqualTo(qList, SP_Customer.Columns.CustomerName);
                query.IsEqualTo(qList, SP_Customer.Columns.Phone);
                query.IsEqualTo(qList, SP_Customer.Columns.Address);
                query.IsEqualTo(qList, SP_Customer.Columns.Memo);
                query.IsEqualTo(qList, SP_Customer.Columns.BankAccount);
                query.IsEqualTo(qList, SP_Customer.Columns.AdminId);
                query.IsEqualTo(qList, SP_Customer.Columns.Ext1);
                query.IsEqualTo(qList, SP_Customer.Columns.Ext2);

            }
            else
            {
                //模糊查询  
                query.Like(qList, SP_Customer.Columns.Id);
                query.Like(qList, SP_Customer.Columns.CustomerName);
                query.Like(qList, SP_Customer.Columns.Phone);
                query.Like(qList, SP_Customer.Columns.Address);
                query.Like(qList, SP_Customer.Columns.Memo);
                query.Like(qList, SP_Customer.Columns.BankAccount);
                query.Like(qList, SP_Customer.Columns.AdminId);
                query.Like(qList, SP_Customer.Columns.Ext1);
                query.Like(qList, SP_Customer.Columns.Ext2);
            }
            //query.IsGreaterThanOrEqualTo(qList, SP_Customer.Columns.Pubdate);  
            //query.IsLessThanOrEqualTo(qList, SP_Customer.Columns.Pubdate);  

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
        public JsonResult Create(SP_Customer model)
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
            GUI.InsertLog("客户表", "新增", msg + ":" + model.Id + ",客户名称:" + model.CustomerName + ",联系电话:" + model.Phone + ",地址:" + model.Address + ",备注:" + model.Memo + ",银行账户:" + model.BankAccount + ",录入人:" + model.AdminId + ",录入时间:" + model.Pubdate + ",:" + model.Ext1 + ",:" + model.Ext2 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            SP_Customer entity = new SP_Customer(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(SP_Customer model)
        {
            try
            {
                SP_Customer entity = new SP_Customer(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",客户名称:" + model.CustomerName
                 + ",联系电话:" + model.Phone
                 + ",地址:" + model.Address
                 + ",备注:" + model.Memo
                 + ",银行账户:" + model.BankAccount
                 + ",录入人:" + model.AdminId
                 + ",录入时间:" + model.Pubdate
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                    + "";
                    entity.CustomerName = model.CustomerName;
                    entity.Phone = model.Phone;
                    entity.Address = model.Address;
                    entity.Memo = model.Memo;
                    entity.BankAccount = model.BankAccount;
                    //entity.AdminId = model.AdminId;
                    //entity.Pubdate = model.Pubdate;
                    entity.Ext1 = model.Ext1;
                    entity.Ext2 = model.Ext2;
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
            GUI.InsertLog("客户表", "编辑", msg + LogStr);
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
                    new Delete().From<SP_Customer>().Where(SP_Customer.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("客户表", "删除", msg + LogStr);
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
            query.TableName = SP_Customer.Schema;
            query.init();
            GetQuery(qList);
            List<SP_Customer> list = query.Paged().ExecuteTypedList<SP_Customer>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/SP_Customer.rdlc");
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
                string ExportName = "客户表";
                GUI.InsertLog("客户表", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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