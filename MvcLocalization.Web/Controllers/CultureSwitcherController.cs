using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLocalization.Web.Controllers
{
    public class CultureSwitcherController : Controller
    {
        public ActionResult Switch(string cultureName)
        {
            var cookie = new HttpCookie(Utils.Constants.CultureCookieName);
            cookie.Value = cultureName;
            Response.Cookies.Add(cookie);

            Uri redirectUrl = Request.UrlReferrer;
            if (redirectUrl != null)
            {
                return Redirect(redirectUrl.ToString());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
