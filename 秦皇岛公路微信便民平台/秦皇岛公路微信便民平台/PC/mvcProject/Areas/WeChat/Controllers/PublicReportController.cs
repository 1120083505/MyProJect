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
using Senparc.Weixin.MP.CommonAPIs;
using System.Configuration;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Helpers;

namespace mvcProject.Areas.WeChat.Controllers
{
    public class PublicReportController : Controller
    {
        public string msg = "";
        public int status = 1;
        string LogStr = "";
        string appId = ConfigurationManager.AppSettings["appId"].ToString();
        string secret = ConfigurationManager.AppSettings["appsecret"].ToString();
        string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"].ToString();
        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        [PowerFilter]
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult APPList()
        {

            return View();
        }
        public ActionResult List()
        {

            return View();
        }
        [PowerFilter]
        public ActionResult Info(string id)
        {
            WeChat_PublicReport entity = new WeChat_PublicReport(id);
            return View(entity);
        }
        [HttpPost]

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = WeChat_PublicReport.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<WeChat_PublicReport> list = query.Paged(ref total).ExecuteTypedList<WeChat_PublicReport>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Location = r.Location,
                    LngLat = r.LngLat,
                    Memo = r.Memo,
                    ReportPerson = r.ReportPerson,
                    Telephone = r.Telephone,
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
            SqlQuery sq = new Select().From<WeChat_PublicReport>();
            List<WeChat_PublicReport> list = sq.ExecuteTypedList<WeChat_PublicReport>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Location = r.Location,
                            LngLat = r.LngLat,
                            Memo = r.Memo,
                            ReportPerson = r.ReportPerson,
                            Telephone = r.Telephone,
                            Pubdate = string.Format("{0:yyyy-MM-dd}", r.Pubdate),
                            Ext1 = r.Ext1,
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3,
                            imgurl= GetImgUrl(r.Id),
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
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Id);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Location);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.LngLat);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Memo);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.ReportPerson);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Telephone);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Ext1);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Ext2);
                query.IsEqualTo(qList, WeChat_PublicReport.Columns.Ext3);

            }
            else
            {
                //模糊查询  
                query.Like(qList, WeChat_PublicReport.Columns.Id);
                query.Like(qList, WeChat_PublicReport.Columns.Location);
                query.Like(qList, WeChat_PublicReport.Columns.LngLat);
                query.Like(qList, WeChat_PublicReport.Columns.Memo);
                query.Like(qList, WeChat_PublicReport.Columns.ReportPerson);
                query.Like(qList, WeChat_PublicReport.Columns.Telephone);
                query.Like(qList, WeChat_PublicReport.Columns.Ext1);
                query.Like(qList, WeChat_PublicReport.Columns.Ext2);
                query.Like(qList, WeChat_PublicReport.Columns.Ext3);
            }
            //query.IsGreaterThanOrEqualTo(qList, WeChat_PublicReport.Columns.Pubdate);  
            //query.IsLessThanOrEqualTo(qList, WeChat_PublicReport.Columns.Pubdate);  

        }
        #endregion
        public static string GetImgUrl(string AboutId)
        {
            string ImgUrl = "";
            SqlQuery sq = new Select().Top("1").From<Assist_Resources>().Where(Assist_Resources.Columns.FileType).IsEqualTo(1)
                .And(Assist_Resources.Columns.FromId).IsEqualTo(AboutId);
            if (sq.GetRecordCount() > 0)
            {
                ImgUrl = sq.ExecuteSingle<Assist_Resources>().Url.Split(';')[0];
            }

            return ImgUrl;
        }

        public ActionResult GZSBInfo(string ID)
        {
            WeChat_PublicReport WCDT = new WeChat_PublicReport(ID);
            WCDT.Ext1 = GetImgUrl(WCDT.Id);
            return View(WCDT);
        }
        #region Create  
        public ActionResult Create()
        {
            var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, secret, Request.Url.AbsoluteUri.ToString());
            return View(jssdkUiPackage);
        }
        [HttpPost]
        public JsonResult Create(WeChat_PublicReport model, string Image)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.Pubdate = DateTime.Now;
                model.Save();
                if (!string.IsNullOrWhiteSpace(Image))
                {
                    //Core.Utils.WriteFileContinue("D:\\IIS", "info.txt", Image + model);
                    try
                    {
                        //图片上传
                        string[] imgids = Image.Split(',');
                        string imgurl = "";
                        string token = AccessTokenContainer.GetAccessToken(appId);
                        //微信端下载图片至服务器
                        for (int i = 0; i < imgids.Length; i++)
                        {
                            FileStream fileStream = null;
                            string fileName = Utils.GetNewDateID() + ".jpg";
                            string serverPath = Server.MapPath("/");
                            //+ serverPath + ""+DateTime.Now.Year+"" + serverPath + ""+DateTime.Now.ToString("MM-dd")+""
                            string saveFileName = serverPath + "Content/upload/" + DateTime.Now.Year + "/" + DateTime.Now.ToString("MM-dd") + "/" + fileName;
                            int iEnd = saveFileName.LastIndexOf("\\");
                            string strDivPath = saveFileName.Substring(0, iEnd);
                            string FileNames = strDivPath;
                            //+ serverPath + "" + DateTime.Now.Year + "" + serverPath + "" + DateTime.Now.ToString("MM-dd")
                            if (!Directory.Exists(serverPath + "Content/upload/" + DateTime.Now.Year + "/" + DateTime.Now.ToString("MM-dd")))
                            {
                                Directory.CreateDirectory(serverPath + "Content/upload/" + DateTime.Now.Year + "/" + DateTime.Now.ToString("MM-dd"));
                            }
                            fileStream = new FileStream(saveFileName, FileMode.Create, FileAccess.ReadWrite);
                            //if (!YuHou.ReUse.ImageOperation.IntelligentSaveImageFile(picup.InputStream, saveFileName, 300, true, "山东省青岛市黄岛区长江路街道江山南路458号城发大厦" + "\r\n" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), new Size(0, 0)))
                            MediaApi.Get(token, imgids[i], fileStream);//保存路径

                            imgurl += "/Content/upload/" + DateTime.Now.Year + "/" + DateTime.Now.ToString("MM-dd") + "/" + fileName + ";";




                            Assist_Resources Resources2 = new Assist_Resources();
                            Resources2.Id = Utils.GetNewDateID();
                            Resources2.Url = imgurl;
                            Resources2.Name = fileName;
                            Resources2.AdminId = "";
                            Resources2.FromId = model.Id;
                            Resources2.Suddix = ".png";
                            Resources2.PubDate = DateTime.Now;
                            Resources2.FileType = "1";
                            Resources2.FromType = 1;
                            Resources2.EditPubDate = DateTime.Now;
                            Resources2.EditAdminId = "";
                            Resources2.Save();
                        }

                        status = 1;
                        msg = Tip.InsertSucceed;
                    }
                    catch (Exception e)
                    {
                        Core.Utils.WriteFileContinue("D:\\IIS", "info.txt", e.ToString());
                        status = 0;
                        msg = Tip.InsertFail;
                    }
                }
            }
            catch(Exception e)
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            GUI.InsertLog("公众上报", "新增", msg + ":" + model.Id + ",位置:" + model.Location + ",经纬度:" + model.LngLat + ",情况描述:" + model.Memo + ",上报人:" + model.ReportPerson + ",联系方式:" + model.Telephone + ",上传时间:" + model.Pubdate + ",:" + model.Ext1 + ",:" + model.Ext2 + ",:" + model.Ext3 + "");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        #region Edit  
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            WeChat_PublicReport entity = new WeChat_PublicReport(id);
            return View(entity);
        }
        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(WeChat_PublicReport model)
        {
            try
            {
                WeChat_PublicReport entity = new WeChat_PublicReport(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    LogStr = ""
                 + "Id:" + model.Id
                 + ",位置:" + model.Location
                 + ",经纬度:" + model.LngLat
                 + ",情况描述:" + model.Memo
                 + ",上报人:" + model.ReportPerson
                 + ",联系方式:" + model.Telephone
                 + ",上传时间:" + model.Pubdate
                 + ",:" + model.Ext1
                 + ",:" + model.Ext2
                 + ",:" + model.Ext3
                    + "";
                    entity.Location = model.Location;
                    entity.LngLat = model.LngLat;
                    entity.Memo = model.Memo;
                    entity.ReportPerson = model.ReportPerson;
                    entity.Telephone = model.Telephone;
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
            GUI.InsertLog("公众上报", "编辑", msg + LogStr);
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
                    new Delete().From<WeChat_PublicReport>().Where(WeChat_PublicReport.Columns.Id).In(id.Split(','))
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
            GUI.InsertLog("公众上报", "删除", msg + LogStr);
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
            query.TableName = WeChat_PublicReport.Schema;
            query.init();
            GetQuery(qList);
            List<WeChat_PublicReport> list = query.Paged().ExecuteTypedList<WeChat_PublicReport>();
            LocalReport localReport = new LocalReport();
            try
            {
                localReport.ReportPath = Server.MapPath("~/Report/WeChat_PublicReport.rdlc");
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
                string ExportName = "公众上报";
                GUI.InsertLog("公众上报", "导出", "导出[" + ExportName + "]成功！[" + type.ToLower() + "]");
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