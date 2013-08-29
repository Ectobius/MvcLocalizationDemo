using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcLocalization.Utils
{
    public class LocalizationController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            string cultureName = "";
            HttpRequestBase request = requestContext.HttpContext.Request;

            var cultureCookie = request.Cookies[Constants.CultureCookieName];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else if (request.UserLanguages != null)
            {
                cultureName = request.UserLanguages[0];
            }

            CultureInfo culture = null;

            try
            {
                culture = new CultureInfo(cultureName);
            }
            catch (CultureNotFoundException)
            { }
            catch (ArgumentNullException)
            { }

            if (culture == null)
            {
                culture = new CultureInfo("");
            }

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            
            base.Initialize(requestContext);
        }
    }
}
