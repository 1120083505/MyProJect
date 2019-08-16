using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProject.Controllers
{
    public class ExportController : Controller
    {
        //
        // GET: /Export/
        [ValidateInput(false)]
        public ActionResult Index(string url, string queryStr)
        {
            ViewBag.url = url;
            ViewBag.queryStr = queryStr;
            return View();
        }
        /// <summary>
        /// 错误页
        /// </summary>
        /// <returns></returns>
        public ActionResult error()
        {
            return View();
        }
        /// <summary>
        /// dev报表
        /// </summary>
        /// <returns></returns>
        public ActionResult DevExport()
        {
            return View();
        }
    }
}
