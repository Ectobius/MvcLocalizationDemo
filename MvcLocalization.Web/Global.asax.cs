using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Optimization;
using System.Web.Routing;
using MvcLocalization.Utils;
using MvcLocalization.Web.Models;

namespace MvcLocalization.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Database.SetInitializer(new MvcLocalizationDbInitializer());

            DefaultModelBinder.ResourceClassKey = "ErrorMessages";
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ErrorMessages";

            ViewEngines.Engines.Remove(ViewEngines.Engines.FirstOrDefault(e => e is RazorViewEngine));
            ViewEngines.Engines.Add(new RazorGlobalizationViewEngine());
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom.Equals("lang"))
            {
                string cultureName = "";
                var cultureCookie = context.Request.Cookies[Utils.Constants.CultureCookieName];

                if (cultureCookie != null)
                {
                    cultureName = cultureCookie.Value;
                }
                else if (context.Request.UserLanguages != null)
                {
                    cultureName = context.Request.UserLanguages[0];
                }

                return cultureName;
            }
            return base.GetVaryByCustomString(context, custom);
        }
    }
}