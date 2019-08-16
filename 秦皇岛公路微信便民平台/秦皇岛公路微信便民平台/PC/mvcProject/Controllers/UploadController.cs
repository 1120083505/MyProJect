using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace mvcProject.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index(UpLoad model)
        {
            //model.fileExt = "*.jpg;";
            //model.multi = true;
            if (string.IsNullOrEmpty(model.fileDesc))
            {
                model.fileDesc = model.fileExt;
            }
            return View(model);
        }

    }
}
