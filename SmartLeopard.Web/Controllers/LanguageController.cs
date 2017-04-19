using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SmartLeopard.Web.Controllers
{
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index(string cultureName)
        { 
            var cultureCookie = Request.Cookies["_culture"] ?? new HttpCookie("_culture");
            cultureCookie.Value = cultureName;
            cultureCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cultureCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}