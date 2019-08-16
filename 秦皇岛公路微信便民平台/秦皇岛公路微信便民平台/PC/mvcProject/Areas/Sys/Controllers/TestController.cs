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
using Model;
namespace mvcProject.Areas.Sys.Controllers
{
    public class TestController : Controller
    {
        public string msg = "";
        public int status = 1;
        ControllerHelper c = new ControllerHelper();
        [PowerFilter]
        public ActionResult Index()
        {
            ViewBag.ColumnsJson = GetColumnsJson().Data;
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            
            List<QueryModel> qList = c.getQList(queryStr);
            SqlQuery sq = GetQuery(qList);
            QueryHelper.Order(sq, pager.order, pager.sort);
            pager.totalRows = sq.GetRecordCount();
            List<Sys_TestModel> list = sq.Paged(pager.page, pager.rows).ExecuteTypedList<Sys_TestModel>();
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        //select r 
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Title = r.Title,
                            price = r.price,
                            count = r.count,
                            PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                            AdminId = r.AdminId,
                            OtherMemo = r.OtherMemo

                        }
                ).ToArray(),
                footer = new object[]
                    { new{
                        Name = "合计",
                        price = "1008.2",
                        count = "当前页合计",
                        PubDate =" 10.8"
                    }}
            };
            return Json(json);
        }
        //测试数组
        public JsonResult GetTest()
        {
            SqlQuery sq = new Select().Top("3").From<Sys_Test>();
            List<Sys_Test> list = sq.ExecuteTypedList<Sys_Test>();
            var json = new
            {
                rows = (from r in list
                        //select r 
                        select new
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Title = r.Title,
                            price = r.price,
                            count = r.count,
                            PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                            AdminId = r.AdminId,
                            OtherMemo = (from l in list
                                         select l.count).ToArray()
                        }
                ).ToArray()
            };
            return Json(json);
        }
        public JsonResult GetColumnsJson()
        {
            var res = new JsonResult();
            var json = new object[] { 
                new { field="Id",title="",width=100,hidden=true},
                new { field="Name",title="测试名称",width=100,sortable=true},
                new { field="Title",title="标题",width=100,sortable=true },
                new { field="price",title="价格",width=100,sortable=true },
                new { field="count",title="计数",width=100,sortable=true },
                new { field="PubDate",title="操作时间",width=100,sortable=true },
                new { field="AdminId",title="操作员",width=100,sortable=true },
                new { field="OtherMemo",title="备注",width=100,sortable=true }
            };
            res.Data = json;
            return res;
        }
        #region 拼接查询条件
        //拼接查询条件  
        public SqlQuery GetQuery(List<QueryModel> qList)
        {
            return GetQuery(qList, null);
        }
        public SqlQuery GetQuery(List<QueryModel> qList, string[] coulums)
        {
            SqlQuery sq = new SqlQuery();
            if (coulums == null)
            {
                sq = new Select().From<Sys_Test>();
            }
            else
            {
                sq = new Select(coulums).From<Sys_Test>();
            }
            if (c.GetQueryStr(qList, "searchtype") == "0")
            {
                //精确查询  
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.Id);
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.Name);
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.Title);
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.price);
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.AdminId);
                QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.OtherMemo);

            }
            else
            {
                //模糊查询  
                QueryHelper.Like(qList, sq, Sys_Test.Columns.Id);
                QueryHelper.Like(qList, sq, Sys_Test.Columns.Name);
                QueryHelper.Like(qList, sq, Sys_Test.Columns.Title);
                QueryHelper.Like(qList, sq, Sys_Test.Columns.price);
                QueryHelper.Like(qList, sq, Sys_Test.Columns.AdminId);
                QueryHelper.Like(qList, sq, Sys_Test.Columns.OtherMemo);
            }
            QueryHelper.IsEqualTo(qList, sq, Sys_Test.Columns.count);
            //QueryHelper.IsGreaterThanOrEqualTo(qList, sq, Sys_Test.Columns.PubDate);  
            //QueryHelper.IsLessThanOrEqualTo(qList, sq, Sys_Test.Columns.PubDate);  

            return sq;
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
        public JsonResult Create(Sys_Test model)
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
            //return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Test entity = new Sys_Test(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Test model)
        {
            try
            {
                Sys_Test entity = new Sys_Test(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    entity.Name = model.Name;
                    entity.Title = model.Title;
                    entity.price = model.price;
                    entity.count = model.count;
                    entity.PubDate = model.PubDate;
                    entity.AdminId = model.AdminId;
                    entity.OtherMemo = model.OtherMemo;
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
            return ControllerHelper.jsonresult(status, msg);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    //这里书写需要删除的逻辑代码  
                    Sys_Test.Delete(id);
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
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region 导出到PDF EXCEL WORD
        [PowerFilter]
        public ActionResult Export(string type, string queryStr)
        {
            List<QueryModel> qList = c.getQList(queryStr);
            SqlQuery sq = GetQuery(qList);
            List<Sys_Test> list = sq.ExecuteTypedList<Sys_Test>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/Test.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("DataSet", list);
                localReport.DataSources.Add(reportDataSource);
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
                string ExportName = "测试";
                switch (type.ToLower())
                {
                    case "pdf":
                        ExportName = "";
                        break;
                    case "image":
                        ExportName += ".png";
                        break;
                }
                return File(renderedBytes, mimeType, ExportName);
            }
            catch
            {
                return View("/views/export/error.cshtml");
            }
        }
        #endregion
    }
}