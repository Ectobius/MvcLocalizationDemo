using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcLocalization.Utils
{
    public static class LocalizationHelpers
    {
        public static IHtmlString MetaAcceptLanguage<T>(this HtmlHelper<T> helper)
        {
            var acceptLanguage = HttpUtility.HtmlAttributeEncode(Thread.CurrentThread.CurrentUICulture.Name);
            return new HtmlString(String.Format("<meta name=\"accept-language\" content=\"{0}\">", acceptLanguage));
        }

        public static IHtmlString RenderForCurrentCulture<T>(this HtmlHelper<T> helper, string path)
        {
            var cultureName = HttpUtility.HtmlAttributeEncode(Thread.CurrentThread.CurrentUICulture.Name);
            var extension = Path.GetExtension(path);
            var newPath = Path.ChangeExtension(path, cultureName + extension);
            return new HtmlString(String.Format("<script src=\"{0}\"></script>", newPath));
        }
    }
}
