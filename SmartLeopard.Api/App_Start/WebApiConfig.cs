using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using SmartLeopard.Api.App_Start;
using SmartLeopard.Api.Framework;

namespace SmartLeopard.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var kernel = NinjectWebCommon.GetKernel();

            // Web API configuration and services
            config.Filters.Add(kernel.Get<UnhandledExceptionFilterAttribute>());
            config.MessageHandlers.Add(kernel.Get<TracingHandler>());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
    