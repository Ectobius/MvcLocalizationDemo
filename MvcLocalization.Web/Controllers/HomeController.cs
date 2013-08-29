using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLocalization.Utils;

namespace MvcLocalization.Web.Controllers
{
    public class HomeController : LocalizationController
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 86400, VaryByParam = "*")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
