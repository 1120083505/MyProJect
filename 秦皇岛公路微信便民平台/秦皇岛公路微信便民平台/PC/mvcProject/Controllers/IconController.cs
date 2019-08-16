using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProject.Controllers
{
    public class IconController : Controller
    {
        //
        // GET: /Icon/

        public ActionResult Index(string fontclass, string unicode)
        {
            ViewBag.Icon = 0;
            if (!string.IsNullOrEmpty(fontclass))
            {
                ViewBag.Icon = 1;
                ViewBag.SelectIcon = fontclass;
            }
            else if (!string.IsNullOrEmpty(unicode))
            {
                ViewBag.Icon = 2;
                ViewBag.SelectIcon = unicode;
            }
            return View();
        }

    }
}
