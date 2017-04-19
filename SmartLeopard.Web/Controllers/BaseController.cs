using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SmartLeopard.Client;
using SmartLeopard.Web.Helpers;

namespace SmartLeopard.Web.Controllers
{
    public class BaseController : Controller
    {
        private Lazy<ApiHelper> ApiHelperLazy { get; } = new Lazy<ApiHelper>(() => new ApiHelper(ConfigurationManager.AppSettings["apiUrl"]));

        public ApiHelper Api => ApiHelperLazy.Value;

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName;

            var cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0
                    ? Request.UserLanguages[0]
                    : null;

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}