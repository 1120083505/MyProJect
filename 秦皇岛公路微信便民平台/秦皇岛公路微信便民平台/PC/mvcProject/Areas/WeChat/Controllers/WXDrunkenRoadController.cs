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
using System.Reflection;

namespace mvcProject.Areas.WeChat.Controllers
{
    public class WXDrunkenRoadController : Controller
    {
        //
        // GET: /WeChat/WXDrunkenRoad/

        public ActionResult Index()
        {
            SqlQuery sq = new Select().From<WeChat_DrunkenRoad>();
            List<WeChat_DrunkenRoad> list = sq.ExecuteTypedList<WeChat_DrunkenRoad>();
            ViewBag.NUM = list.Count;
            SqlQuery sql = new Select().From<WeChat_ActivityInfo>();
            List<WeChat_ActivityInfo> Aclist = sql.ExecuteTypedList<WeChat_ActivityInfo>();
            ViewBag.Title = Aclist[0].ActivityTitle;
            ViewBag.Content = Aclist[0].ActivityContent;
            ViewBag.StarTime = Aclist[0].StarTime;
            ViewBag.EndTime = Aclist[0].EndTime;
            ViewBag.ActivityMemo = Aclist[0].ActivityMemo;
            return View();
        }
        //[HttpPost]
        public ActionResult QueryInfo(string Id)
        {
            SqlQuery sq = new Select().From<WeChat_DrunkenRoad>();
            List<WeChat_DrunkenRoad> list = sq.ExecuteTypedList<WeChat_DrunkenRoad>();
            ViewBag.NUM = list.Count;
            SqlQuery sql = new Select().From<WeChat_ActivityInfo>();
            List<WeChat_ActivityInfo> Aclist = sql.ExecuteTypedList<WeChat_ActivityInfo>();
            ViewBag.Title = Aclist[0].ActivityTitle;
            ViewBag.Content = Aclist[0].ActivityContent;
            ViewBag.StarTime = Aclist[0].StarTime;
            ViewBag.EndTime = Aclist[0].EndTime;
            ViewBag.ActivityMemo = Aclist[0].ActivityMemo;
            ViewBag.ID = Id;
            return View();
        }
        public ActionResult Ranking()
        {
            return View();
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
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetPMList()
        {
            SqlQuery sq = new Select().From<WeChat_DrunkenRoad>().OrderDesc(WeChat_DrunkenRoad.Columns.RoadVotes);
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
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
        }
        [HttpPost]
        public ActionResult CXPMList(string Id)
        {
            SqlQuery sq = new Select().From<WeChat_DrunkenRoad>().Where(WeChat_DrunkenRoad.Columns.RoadName).Like(Id);
            string sql = "Select *  FROM  WeChat_DrunkenRoad  where RoadName LIKE '"+ Id + "%' ";
            DataTable dt = DataService.GetDataSet(new QueryCommand(sql)).Tables[0];
            List<WeChat_DrunkenRoad> list = ModelConvertHelper<WeChat_DrunkenRoad>.ConvertToModel(dt);
            //List<WeChat_DrunkenRoad> list = sq.ExecuteTypedList<WeChat_DrunkenRoad>();
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
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
        }
        public ActionResult Vote(string Id)
        {
            SqlQuery sq = new Select().From<WeChat_RoadVoteInfo>().Where(WeChat_RoadVoteInfo.Columns.OpenId).IsEqualTo(Session["openId"].ToString())
               .And(WeChat_RoadVoteInfo.Columns.Pubdate).IsLessThanOrEqualTo(DateTime.Now.AddDays(1).ToShortDateString())
               .And(WeChat_RoadVoteInfo.Columns.Pubdate).IsGreaterThanOrEqualTo(DateTime.Now.ToShortDateString());
            List<WeChat_RoadVoteInfo> list = sq.ExecuteTypedList<WeChat_RoadVoteInfo>();
            if (list.Count>0)
            {
                return Content("Repeat");
            }
            else
            {                
                WeChat_DrunkenRoad WDR = new WeChat_DrunkenRoad(Id);
                if (!string.IsNullOrWhiteSpace(WDR.Id))
                {
                    WDR.RoadVotes++;
                    WDR.Save();
                    WeChat_RoadVoteInfo WRV = new WeChat_RoadVoteInfo();
                    WRV.Id = Utils.GetNewDateID();
                    WRV.OpenId = Session["openId"].ToString();
                    WRV.Pubdate = DateTime.Now;
                    WRV.FromId = WDR.Id;
                    WRV.Save();
                    return Content("OK");
                }
                else
                {
                    return Content("error");
                }
            }
            
        }
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
    }
    public class ModelConvertHelper<T> where T : new()
    {
        public static List<T> ConvertToModel(DataTable dt)
        {
            try
            {
                // 定义集合    
                List<T> ts = new List<T>();
                // 获得此模型的类型   
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得此模型的公共属性      
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;  // 检查DataTable是否包含此列    
                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter      
                            if (!pi.CanWrite) continue;

                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
            catch (Exception ex)
            {

                return null;
                throw;
            }

        }
    }
   }
