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
    public class DrunkenRoadController : Controller
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
            VWeChat_DrunkenRoad entity = new VWeChat_DrunkenRoad(VWeChat_DrunkenRoad.Columns.Id,id);
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
            query.TableName = VWeChat_DrunkenRoad.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<VWeChat_DrunkenRoad> list = query.Paged(ref total).ExecuteTypedList<VWeChat_DrunkenRoad>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    RoadName = r.RoadName,
                    RoadNum = r.RoadNum,
                    RoadVotes = r.RoadVotes,
                    RoadMemo = r.RoadMemo,
                    RoadState = r.RoadState,
                    AdminId = r.RealName,
                    Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                    EditAdminId = r.EditRealName,
                    EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
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
            SqlQuery sq = new Select().From<WeChat_DrunkenRoad>();
            List<WeChat_DrunkenRoad> list = sq.ExecuteTypedList<WeChat_DrunkenRoad>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            RoadName = r.RoadName,
                            RoadNum = r.RoadNum,
                            RoadVotes = r.RoadVotes,
                            RoadMemo = r.RoadMemo,
                            RoadState = r.RoadState,
                            AdminId = r.AdminId,
                            Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
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
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.Id);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.RoadName);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.RoadMemo);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.AdminId);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.EditAdminId);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.Ext1);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.Ext2);
                query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.Ext3);

            }
            else
            {
                //模糊查询  
                query.Like(qList, WeChat_DrunkenRoad.Columns.Id);
                query.Like(qList, WeChat_DrunkenRoad.Columns.RoadName);
                query.Like(qList, WeChat_DrunkenRoad.Columns.RoadMemo);
                query.Like(qList, WeChat_DrunkenRoad.Columns.AdminId);
                query.Like(qList, WeChat_DrunkenRoad.Columns.EditAdminId);
                query.Like(qList, WeChat_DrunkenRoad.Columns.Ext1);
                query.Like(qList, WeChat_DrunkenRoad.Columns.Ext2);
                query.Like(qList, WeChat_DrunkenRoad.Columns.Ext3);
            }
            query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.RoadNum);
            query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.RoadVotes);
            query.IsEqualTo(qList, WeChat_DrunkenRoad.Columns.RoadState);
            //query.IsGreaterThanOrEqualTo(qList, WeChat_DrunkenRoad.Columns.Pubdate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_DrunkenRoad.Columns.Pubdate);  
            //query.IsGreaterThanOrEqualTo(qList, WeChat_DrunkenRoad.Columns.EditPubDate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_DrunkenRoad.Columns.EditPubDate);  

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
        public JsonResult Create(WeChat_DrunkenRoad model, string FileUrl, string FileName, string FileType)
        {
            try
            {
                SqlQuery sq = new Select().From<WeChat_DrunkenRoad>().Where(WeChat_DrunkenRoad.Columns.RoadName).IsEqualTo(model.RoadName);
                List<WeChat_DrunkenRoad> list = sq.ExecuteTypedList<WeChat_DrunkenRoad>();
                if (list.Count > 0)
                {
                    status = 0;
                    msg = Tip.InsertFail + "名称已存在！";
                    return ControllerHelper.jsonresult(status, msg);
                }
                int Num = 1;
                SqlQuery sqlnum = new Select().Top("1").From<WeChat_DrunkenRoad>().OrderDesc(WeChat_DrunkenRoad.Columns.RoadNum);
                List<WeChat_DrunkenRoad> Numlist = sqlnum.ExecuteTypedList<WeChat_DrunkenRoad>();
                if (Numlist.Count>0)
                {
                    Num= int.Parse( Numlist[0].RoadNum.ToString()) + 1;
                }
                model.Id = Utils.GetNewDateID();
                model.AdminId = LoginInfo.AdminID;
                model.Pubdate = DateTime.Now;
                model.EditAdminId = LoginInfo.AdminID;
                model.EditPubDate = DateTime.Now;
                model.RoadNum = Num;
                model.RoadState = 0;
                model.RoadVotes = 0;
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
            GUI.InsertLog("醉美公路", "新增", msg + ":" + model.Id + ",公路名称:" + model.RoadName + ",公路编号:" + model.RoadNum + ",公路得票数:" + model.RoadVotes + ",公路简介:" + model.RoadMemo + ",状态:" + model.RoadState + ",录入人:" + model.AdminId + ",创建时间:" + model.Pubdate + ",修改人:" + model.EditAdminId + ",修改时间:" + model.EditPubDate + ",:" + model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            WeChat_DrunkenRoad entity = new WeChat_DrunkenRoad(id);
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
        public JsonResult Edit(WeChat_DrunkenRoad model, string FileUrl, string FileName, string FileType)
        {
            try
            {
                WeChat_DrunkenRoad entity = new WeChat_DrunkenRoad(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",公路名称:" + model.RoadName
                 + ",公路编号:" + model.RoadNum
                 + ",公路得票数:" + model.RoadVotes
                 + ",公路简介:" + model.RoadMemo
                 + ",状态:" + model.RoadState
                 + ",录入人:" + model.AdminId
                 + ",创建时间:" + model.Pubdate
                 + ",修改人:" + LoginInfo.AdminID
                 + ",修改时间:" + DateTime.Now
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                 + ",:" + model.Ext3
                    + "";
                    entity.RoadName = model.RoadName;
                    //entity.RoadNum = model.RoadNum;
                    //entity.RoadVotes = model.RoadVotes;
                    entity.RoadMemo = model.RoadMemo;
                    //entity.RoadState = model.RoadState;
                    //entity.AdminId = model.AdminId;
                    //entity.Pubdate = model.Pubdate;
                    entity.EditAdminId = LoginInfo.AdminID;
                    entity.EditPubDate = DateTime.Now;
                    //entity.Ext1 = model.Ext1;
                    //entity.Ext2 = model.Ext2;
                    //entity.Ext3 = model.Ext3;
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
            GUI.InsertLog("醉美公路", "编辑", msg + LogStr);
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
                    new Delete().From<WeChat_DrunkenRoad>().Where(WeChat_DrunkenRoad.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("醉美公路", "删除", msg + LogStr);
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
            query.TableName = WeChat_DrunkenRoad.Schema;
            query.init();
            GetQuery(qList);
            List<WeChat_DrunkenRoad> list = query.Paged().ExecuteTypedList<WeChat_DrunkenRoad>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/WeChat_DrunkenRoad.rdlc");
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
                string ExportName = "醉美公路";
                GUI.InsertLog("醉美公路", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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