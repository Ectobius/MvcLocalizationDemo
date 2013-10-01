using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcLocalization.Utils
{
    public sealed class RazorGlobalizationViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            partialPath = GlobalizeViewPath(controllerContext, partialPath);
            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            viewPath = GlobalizeViewPath(controllerContext, viewPath);
            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        private string GlobalizeViewPath(ControllerContext controllerContext, string viewPath)
        {
            var request = controllerContext.HttpContext.Request;
            var lang = request.Cookies[Constants.CultureCookieName];
            if (lang != null &&
                !string.IsNullOrEmpty(lang.Value) &&
                !string.Equals(lang.Value, "en", StringComparison.InvariantCultureIgnoreCase))
            {
                string localizedViewPath = Regex.Replace(
                    viewPath,
                    "^~/Views/",
                    string.Format("~/Views/Globalization/{0}/",
                    lang.Value
                    ));
                if (FileExists(controllerContext, localizedViewPath))
                {
                    viewPath = localizedViewPath;
                }
            }
            return viewPath;
        }
    }
}
