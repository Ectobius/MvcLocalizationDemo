using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcLocalization.Utils
{
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        private void OnBeginRequest(object sender, EventArgs eventArgs)
        {
            string cultureName = "";
            var request = ((HttpApplication)sender).Context.Request;

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
        }

        public void Dispose()
        {

        }
    }
}
