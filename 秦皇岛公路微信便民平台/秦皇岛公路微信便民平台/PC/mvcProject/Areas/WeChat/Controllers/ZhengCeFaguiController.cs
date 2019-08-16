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
    public class ZhengCeFaguiController : Controller
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
            VWeChat_ZhengCeFagui entity = new VWeChat_ZhengCeFagui(VWeChat_ZhengCeFagui.Columns.Id,id);
            #region 照片
            SqlQuery sq = new Select().From<Assist_Resources>()
                .Where(Assist_Resources.Columns.FromId)
                .IsEqualTo(id)
                .And(Assist_Resources.Columns.FileType).IsEqualTo("1");
            if (sq.GetRecordCount() > 0)
            {
                List<Assist_Resources> list = sq.ExecuteTypedList<Assist_Resources>();
                ViewBag.FileUrl = list[0].Url;
                ViewBag.FileName = list[0].Name;
                ViewBag.FileType = list[0].FileType;
            }
            else
            {
                ViewBag.FileUrl = "";
                ViewBag.FileName = "";
                ViewBag.FileType = "";
            }

            #endregion
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
            query.TableName = VWeChat_ZhengCeFagui.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<VWeChat_ZhengCeFagui> list = query.Paged(ref total).ExecuteTypedList<VWeChat_ZhengCeFagui>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Title = r.Title,
                    AdminId = r.RealName,
                    Conetent = r.Conetent,
                    PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                    EditAdminId = r.EditRealName,
                    EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                    Memo = r.Memo,
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
            SqlQuery sq = new Select().From<WeChat_ZhengCeFagui>();
            List<WeChat_ZhengCeFagui> list = sq.ExecuteTypedList<WeChat_ZhengCeFagui>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Title = r.Title,
                            AdminId = r.AdminId,
                            Conetent = r.Conetent,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                            Memo = r.Memo,
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
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Id);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Title);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.AdminId);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Conetent);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.EditAdminId);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Memo);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Ext1);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Ext2);
                query.IsEqualTo(qList, WeChat_ZhengCeFagui.Columns.Ext3);

            }
            else
            {
                //模糊查询  
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Id);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Title);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.AdminId);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Conetent);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.EditAdminId);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Memo);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Ext1);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Ext2);
                query.Like(qList, WeChat_ZhengCeFagui.Columns.Ext3);
            }
            //query.IsGreaterThanOrEqualTo(qList, WeChat_ZhengCeFagui.Columns.PubDate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_ZhengCeFagui.Columns.PubDate);  
            //query.IsGreaterThanOrEqualTo(qList, WeChat_ZhengCeFagui.Columns.EditPubDate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_ZhengCeFagui.Columns.EditPubDate);  

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
        [ValidateInput(false)]
        public JsonResult Create(WeChat_ZhengCeFagui model, string FileUrl, string FileName, string FileType)
        {
            try
            {
                SqlQuery sq = new Select().From<WeChat_ZhengCeFagui>().Where(WeChat_ZhengCeFagui.Columns.Title).IsEqualTo(model.Title);
                List<WeChat_ZhengCeFagui> list = sq.ExecuteTypedList<WeChat_ZhengCeFagui>();
                if (list.Count > 0)
                {
                    status = 0;
                    msg = Tip.InsertFail + "标题名已存在！";
                    return ControllerHelper.jsonresult(status, msg);
                }
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
                model.PubDate = DateTime.Now;
                model.EditAdminId = LoginInfo.AdminID;
                model.EditPubDate = DateTime.Now;
                model.Save();
                status = 1;
                msg = Tip.InsertSucceed;
                if (FileUrl != "")//图片保存
                {
                    Assist_Resources entity = new Assist_Resources();
                    entity.Id = Utils.GetNewDateID();
                    entity.FromId = model.Id;
                    entity.Url = FileUrl;
                    entity.Name = FileName;
                    entity.Suddix = FileType;
                    entity.FileType = "1";
                    entity.FromType = 1;
                    entity.AdminId = LoginInfo.AdminID;
                    entity.PubDate = DateTime.Now;
                    entity.EditPubDate = DateTime.Now;
                    entity.EditAdminId = LoginInfo.AdminID;
                    entity.Save();
                }
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog("政策法规", "新增", msg + ":" + model.Id + ",标题:" + model.Title + ",录入人:" + model.AdminId + ",内容:" + model.Conetent + ",录入时间:" + model.PubDate + ",修改人:" + model.EditAdminId + ",修改时间:" + model.EditPubDate + ",备注:" + model.Memo + ",:" + model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            WeChat_ZhengCeFagui entity = new WeChat_ZhengCeFagui(id);
            #region 照片
            SqlQuery sq = new Select().From<Assist_Resources>()
                .Where(Assist_Resources.Columns.FromId)
                .IsEqualTo(id)
                .And(Assist_Resources.Columns.FileType).IsEqualTo("1");
            if (sq.GetRecordCount() > 0)
            {
                List<Assist_Resources> list = sq.ExecuteTypedList<Assist_Resources>();
                ViewBag.FileUrl = list[0].Url;
                ViewBag.FileName = list[0].Name;
                ViewBag.FileType = list[0].FileType;
            }
            else
            {
                ViewBag.FileUrl = "";
                ViewBag.FileName = "";
                ViewBag.FileType = "";
            }
            #endregion
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        [ValidateInput(false)]
        public JsonResult Edit(WeChat_ZhengCeFagui model, string FileUrl, string FileName, string FileType)
        {
            try
            {
                WeChat_ZhengCeFagui entity = new WeChat_ZhengCeFagui(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    SqlQuery sql = new Select().From<WeChat_ZhengCeFagui>().Where(WeChat_ZhengCeFagui.Columns.Title).IsEqualTo(model.Title)
                  .And(WeChat_ZhengCeFagui.Columns.Id).IsNotEqualTo(entity.Id);
                    List<WeChat_ZhengCeFagui> list = sql.ExecuteTypedList<WeChat_ZhengCeFagui>();
                    if (list.Count > 0)
                    {
                        status = 0;
                        msg = Tip.EditFail + "标题名已存在！";
                        return ControllerHelper.jsonresult(status, msg);
                    }
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",标题:" + model.Title
                 + ",录入人:" + model.AdminId
                 + ",内容:" + model.Conetent
                 + ",录入时间:" + model.PubDate
                 + ",修改人:" + LoginInfo.AdminID
                 + ",修改时间:" + DateTime.Now
                 + ",备注:" + model.Memo
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                 + ",:" + model.Ext3
                    + "";
                    entity.Title = model.Title;
                    //entity.AdminId = model.AdminId;
                    entity.Conetent = model.Conetent;
                    //entity.PubDate = model.PubDate;
                    entity.EditAdminId = LoginInfo.AdminID;
                    entity.EditPubDate = DateTime.Now;
                    entity.Memo = model.Memo;
                    entity.Ext1 = model.Ext1;
                    entity.Ext2 = model.Ext2;
                    entity.Ext3 = model.Ext3;
                    entity.Save();
                    status = 1;
                    msg = Tip.EditSucceed;
                    #region 照片
                    if (FileUrl != "")
                    {
                        SqlQuery sq = new Select().From<Assist_Resources>().Where(Assist_Resources.Columns.FromId).IsEqualTo(model.Id)
                           .And(Assist_Resources.Columns.FileType).IsEqualTo(1);
                        if (sq.GetRecordCount() > 0)
                        {
                            Assist_Resources entityass = new Assist_Resources(sq.ExecuteSingle<Assist_Resources>().Id);
                            entityass.FromId = model.Id;
                            entityass.Url = FileUrl;
                            entityass.Name = FileName;
                            entityass.EditPubDate = DateTime.Now;
                            entityass.EditAdminId = LoginInfo.AdminID;
                            entityass.Save();
                        }
                        else
                        {
                            Assist_Resources entity_1 = new Assist_Resources();
                            entity_1.Id = Utils.GetNewDateID();
                            entity_1.FromId = model.Id;
                            entity_1.Url = FileUrl;
                            entity_1.Name = FileName;
                            entity_1.FileType = "1";
                            entity_1.FromType = 1;
                            entity_1.AdminId = LoginInfo.AdminID;
                            entity_1.PubDate = DateTime.Now;
                            entity_1.EditPubDate = DateTime.Now;
                            entity_1.EditAdminId = LoginInfo.AdminID;
                            entity_1.Save();
                        }
                    }
                    else
                    {
                        new Delete().From<Assist_Resources>().Where(Assist_Resources.Columns.FromId).IsEqualTo(model.Id)
                           .And(Assist_Resources.Columns.FileType).IsEqualTo(1)
                        .Execute();
                    }
                    #endregion
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
            GUI.InsertLog("政策法规", "编辑", msg + LogStr);
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
                    new Delete().From<WeChat_ZhengCeFagui>().Where(WeChat_ZhengCeFagui.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("政策法规", "删除", msg + LogStr);
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
            query.TableName = WeChat_ZhengCeFagui.Schema;
            query.init();
            GetQuery(qList);
            List<WeChat_ZhengCeFagui> list = query.Paged().ExecuteTypedList<WeChat_ZhengCeFagui>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/WeChat_ZhengCeFagui.rdlc");
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
                string ExportName = "政策法规";
                GUI.InsertLog("政策法规", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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