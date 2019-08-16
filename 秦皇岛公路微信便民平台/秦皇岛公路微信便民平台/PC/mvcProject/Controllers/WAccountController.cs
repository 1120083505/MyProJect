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
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Configuration;
using System.Text;

using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Exceptions;
using Newtonsoft.Json;
using System.Net;
namespace mvcProject.Controllers
{
    public class WAccountController : Controller
    {
        public string msg = "";
        public int status = 1;
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult NoPower()
        {
            return View();
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

            Utils.WriteFileContinue("D:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001--SSSS");
            string appId = ConfigurationManager.AppSettings["appId"].ToString();
            string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"].ToString();
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=http://" + redirect_uri + "/WAccount/WXIndex?tar=" + tar + "&response_type=code&scope=snsapi_userinfo&#wechat_redirect";
            Utils.WriteFileContinue("D:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001--" + url);
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
            Utils.WriteFileContinue("D:\\IIS", "test.txt", "=notice================================" + DateTime.Now + "[ok]:" + "001" + tar);
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
                return Redirect("/WeChat/WXHighwayMap/NearbyRetrieval");
             
            }
            else if (tar == 1)
            {
                return Redirect("/WeChat/WXHighwayMap/NearbyRetrieval");
            }
            else if (tar == 2)
            {
                return Redirect("/WeChat/WXHighwayMap/RoadCondition");
            }
            else if (tar == 3)
            {
                return RedirectToAction("GCMap", "WXHome");
            }
            else if (tar == 4)
            {
                return Redirect("/WeChat/PublicReport/Create");
            }
            else if (tar == 5)
            {
                return RedirectToAction("Index", "WXHome");
            }
            else if (tar == 6)
            {
                return Redirect("/WeChat/WXDrunkenRoad/Index");
            }
            //else if (tar == 7)
            //{
            //    return Redirect("http://115.47.143.25:8085/WeChat/Index?id="+ Session["openId"]);
            //}
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

    }
}
