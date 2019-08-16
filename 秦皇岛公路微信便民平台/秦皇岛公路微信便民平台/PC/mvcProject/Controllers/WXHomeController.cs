using Core;
using Newtonsoft.Json;
using Senparc.Weixin.MP;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZrSoft;

namespace mvcProject.Controllers
{
    public class WXHomeController : Controller
    {
        //
        // GET: /WXHome/

        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        //两学一做详情
        public ActionResult Info(string ID)
        {
            WeChat_TwoLearnTodo WCT = new WeChat_TwoLearnTodo(ID);
            WCT.Ext1 = GetImgUrl(WCT.Id);
            return View(WCT);      
        }
        //政策详情
        public ActionResult ZCInfo(string ID)
        {
            WeChat_ZhengCeFagui WCZC = new WeChat_ZhengCeFagui(ID);
            WCZC.Ext1 = GetImgUrl(WCZC.Id);
            return View(WCZC);
        }
        //动态详情
        public ActionResult DTInfo(string ID)
        {
            WeChat_HighwayDynamic WCDT = new WeChat_HighwayDynamic(ID);
            WCDT.Ext1 = GetImgUrl(WCDT.Id);
            return View(WCDT);
        }
        //获取公厕的点
        public JsonResult GetLngLat(string lat, string lng)
        {
            try
            {
                //120.38442818,36.1052149               
                string ActionName = "GetGCPoints";
                string Parameter = "lat=" + lat + "&lng=" + lng +"";
                string json = GetInterface.jieko(ActionName, Parameter);
                return Json(json);
            }
            catch (Exception e)
            {
                return Json("");
                throw;
            }
        }
        public ActionResult GCMap()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetTwoStudyList()
        {
            SqlQuery sq = new Select().From<VWeChat_TwoLearnTodo>();
            List<VWeChat_TwoLearnTodo> list = sq.ExecuteTypedList<VWeChat_TwoLearnTodo>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Conetent =Utils.NoHTML(r.Conetent),
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                            Memo = r.Memo,
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetZCList()
        {
            SqlQuery sq = new Select().From<VWeChat_ZhengCeFagui>();
            List<VWeChat_ZhengCeFagui> list = sq.ExecuteTypedList<VWeChat_ZhengCeFagui>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Conetent = Utils.NoHTML(r.Conetent),
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                            Memo = r.Memo,
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetDTList()
        {
            SqlQuery sq = new Select().From<VWeChat_HighwayDynamic>();
            List<VWeChat_HighwayDynamic> list = sq.ExecuteTypedList<VWeChat_HighwayDynamic>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Conetent = Utils.NoHTML(r.Conetent),
                            AdminId = r.AdminId,
                            PubDate = string.Format("{0:yyyy-MM-dd}", r.PubDate),
                            EditAdminId = r.EditAdminId,
                            EditPubDate = string.Format("{0:yyyy-MM-dd}", r.EditPubDate),
                            Memo = r.Memo,
                            Ext1 = GetImgUrl(r.Id),
                            Ext2 = r.Ext2,
                            Ext3 = r.Ext3

                        }
              ).ToArray()
            };
            return Json(json);
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
        #region 微信
        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CheckToken(string signature, string timestamp, string nonce, string echostr)
        {

            string Token = ConfigurationManager.AppSettings["Token"].ToString();//与微信公众账号后台的Token设置保持一致，区分大小写。

            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }


        /// <summary>
        /// 进入微信
        /// </summary>
        /// <param name="tar"></param>
        /// <returns></returns>
        public ActionResult In(int tar)
        {

            Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001--SSSS");
            string appId = ConfigurationManager.AppSettings["appId"].ToString();
            string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"].ToString();
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=http://" + redirect_uri + "/WAccount/WXIndex?tar=" + tar + "&response_type=code&scope=snsapi_userinfo&#wechat_redirect";
            Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001--" + url);
            Response.Redirect(url);
            return View();
        }
        /// <summary>
        /// 回调
        /// </summary>
        /// <param name="tar"></param>
        /// <returns></returns>
        public ActionResult WXIndex(int tar)
        {
            Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001" + tar);
            string code = Request.QueryString["code"];
            string appId = ConfigurationManager.AppSettings["appId"].ToString();
            string AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString();
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid="
                + appId + "&secret=" + AppSecret + "&code=" + code + "&grant_type=authorization_code";
            string ret = GetData(url);
            var jd = JsonConvert.DeserializeObject<OpenIdResult>(ret);
            var openId = jd.openid;
            var PopenId = openId;
            //Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + openId);
            var access_token = jd.access_token;
            //Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + access_token);
            //获取用户信息
            string url_1 = "https://api.weixin.qq.com/sns/userinfo?access_token=" + access_token + "&openid=" + openId + "&lang=zh_CN";
            string usinfo = GetData(url_1);
            var Info = JsonConvert.DeserializeObject<UserInfo>(usinfo);
            var nickname = Info.nickname;
            //Utils.WriteFileContinue("E:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + nickname);
            Session["openId"] = openId;
            Session["nickname"] = nickname;
            if (tar == 0)
            {
                return RedirectToAction("Index", "WAccount");
            }
            else if (tar == 1)
            {
                return RedirectToAction("Index", "WAccount");
            }
            return View();
        }

        #endregion
        #region 微信验证辅助
        private string GetData(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
        public class OpenIdResult
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
            public string refresh_token { get; set; }
            public string openid { get; set; }
            public string scope { get; set; }
            public string unionid { get; set; }
        }
        #endregion
        #region 微信类
        public class UserInfo
        {
            public string subscribe { get; set; } //用户是否关注
            public string openid { get; set; } //唯一标识
            public string nickname { get; set; } //用户名
            public string sex { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string province { get; set; }
            public string headimgurl { get; set; }
            public string subscribe_time { get; set; }  //关注时间
        }
        #endregion



        #region 公路情况
        /// <summary>
        /// 国道
        /// </summary>
        /// <returns></returns>
        public ActionResult HighWayRoadCountry()
        {
            return View();
        }
        public ActionResult RoadInfo(string id)
        {
            VHighWayRoad entity = new VHighWayRoad(VHighWayRoad.Columns.Id, id);
            entity.Ext1 = GetImgUrl(entity.Id);
            return View(entity);
        }
        /// <summary>
        /// 省道
        /// </summary>
        /// <returns></returns>
        public ActionResult HighWayRoadCountry1()
        {
            return View();
        }

        /// <summary>
        /// 高速公路
        /// </summary>
        /// <returns></returns>
        public ActionResult HighWayRoadCountry2()
        {
            return View();
        }
        /// <summary>
        /// 收费站
        /// </summary>
        /// <returns></returns>
        public ActionResult HighWayRoadCountry3()
        {
            return View();
        }
        /// <summary>
        /// 服务区
        /// </summary>
        /// <returns></returns>
        public ActionResult HighWayRoadCountry4()
        {
            return View();
        }
        #endregion
    }
}
