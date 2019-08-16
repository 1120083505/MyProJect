using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core;

namespace mvcProject
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*START--程序运行时的配置*/
            LoginInfo.proName = "QHDWechat";
            /*END---程序运行时的配置*/
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = false;
            /*定时执行时间*/
            System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            myTimer.Interval = 1000;
            myTimer.Enabled = true;

        }
        void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if ((now.Minute == 0 || now.Minute == 30) && now.Second == 0)
            {
                //Core.Wechat.Get_access_token();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            var httpStatusCode = (ex is HttpException) ? (ex as HttpException).GetHttpCode() : 500;
            switch (httpStatusCode)
            {
                case 404:
                    ////string old = HttpContext.Current.Request.Url.ToString();
                    ////string newSite = old.Replace("www", "old");
                    ////newSite = newSite.Replace("http://zrsoft.cn", "http://old.zrsoft.cn");
                    ////Response.Redirect(newSite);
                    break;

                default:
                    break;

            }
            Response.Redirect("/");

        }
    }
}