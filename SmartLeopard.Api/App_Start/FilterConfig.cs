using System.Web;
using System.Web.Mvc;
using SmartLeopard.Api.Framework;

namespace SmartLeopard.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
