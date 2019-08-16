using Core;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProject.Areas.WeChat.Controllers
{
    public class WXHighwayMapController : Controller
    {
        public string msg = "";
        public int status = 1;
        string appId = ConfigurationManager.AppSettings["appId"].ToString();
        string secret = ConfigurationManager.AppSettings["appsecret"].ToString();
        string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"].ToString();
        string openids = "";
        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        //
        // GET: /WeChat/WXHighwayMap/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GDRoadCondition()
        {
            return View();
        }
        public ActionResult RoadCondition()
        {
            var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, secret, Request.Url.AbsoluteUri.ToString());
            return View(jssdkUiPackage);
        }
        public ActionResult NearbyRetrieval()
        {

            var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, secret, Request.Url.AbsoluteUri.ToString());
            return View(jssdkUiPackage);

        }
        public ActionResult TestNearbyRetrieval()
        {
            return View();
        }
        public ActionResult ReportEvent()
        {
            try
            {
                var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, secret, Request.Url.AbsoluteUri.ToString());
                return View(jssdkUiPackage);
            }
            catch (Exception e)
            {
                return View();
            }

        }
    }
}
