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
    public class BankAccountController : Controller
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
            VSP_BankAccount entity = new VSP_BankAccount(VSP_BankAccount.Columns.Id, id);
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
            query.TableName = VSP_BankAccount.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<VSP_BankAccount> list = query.Paged(ref total).ExecuteTypedList<VSP_BankAccount>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    CardNum = r.CardNum,
                    BankName = r.BankName,
                    Balance = r.Balance,
                    UserId = r.UserName,
                    AdminId = r.RealName,
                    PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                    Ext1 = r.Ext1,
                    Ext2 = r.Ext2

                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<SP_BankAccount>();
            List<SP_BankAccount> list = sq.ExecuteTypedList<SP_BankAccount>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            CardNum = r.CardNum,
                            BankName = r.BankName,
                            Balance = r.Balance,
                            UserId = r.UserId,
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
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
                query.IsEqualTo(qList, VSP_BankAccount.Columns.Id);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.CardNum);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.BankName);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.UserId);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.AdminId);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.Ext1);
                query.IsEqualTo(qList, VSP_BankAccount.Columns.Ext2);

            }
            else
            {
                //模糊查询  
                query.Like(qList, VSP_BankAccount.Columns.Id);
                query.Like(qList, VSP_BankAccount.Columns.CardNum);
                query.Like(qList, VSP_BankAccount.Columns.BankName);
                query.Like(qList, VSP_BankAccount.Columns.UserId);
                query.Like(qList, VSP_BankAccount.Columns.AdminId);
                query.Like(qList, VSP_BankAccount.Columns.Ext1);
                query.Like(qList, VSP_BankAccount.Columns.Ext2);
            }
            query.IsEqualTo(qList, VSP_BankAccount.Columns.Balance);
            //query.IsGreaterThanOrEqualTo(qList, VSP_BankAccount.Columns.PubDate);  
            //query.IsLessThanOrEqualTo(qList, VSP_BankAccount.Columns.PubDate);  

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
        public JsonResult Create(SP_BankAccount model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
                model.PubDate = DateTime.Now;
                model.Balance = 0;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog(" ", "新增", msg + ":" + model.Id + ",卡号:" + model.CardNum + ",银行名称:" + model.BankName + ",余额:" + model.Balance + ",所属人:" + model.UserId + ",:" + model.AdminId + ",:" + model.PubDate + ",:" + model.Ext1 + ",:" + model.Ext2 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            SP_BankAccount entity = new SP_BankAccount(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(SP_BankAccount model)
        {
            try
            {
                SP_BankAccount entity = new SP_BankAccount(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",卡号:" + model.CardNum
                 + ",银行名称:" + model.BankName
                 + ",余额:" + model.Balance
                 + ",所属人:" + model.UserId
                 + ",:" + model.AdminId
                 + ",:" + model.PubDate
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                    + "";
                    entity.CardNum = model.CardNum;
                    entity.BankName = model.BankName;
                    //entity.Balance = model.Balance;
                    entity.UserId = model.UserId;
                    //entity.AdminId = model.AdminId;
                    //entity.PubDate = model.PubDate;
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
                try
                {
                    //这里书写需要删除的逻辑代码 
                    new Delete().From<SP_BankAccount>().Where(SP_BankAccount.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog(" ", "删除", msg + LogStr);
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
            query.TableName = SP_BankAccount.Schema;
            query.init();
            GetQuery(qList);
            List<SP_BankAccount> list = query.Paged().ExecuteTypedList<SP_BankAccount>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/SP_BankAccount.rdlc");
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
                string ExportName = "SP_BankAccount";
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
                return View("/views/export/error.cshtml");
            }
        }
        #endregion
    }
}