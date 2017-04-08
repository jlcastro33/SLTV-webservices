using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SmartLeopard.Bll;
using SmartLeopard.Dal;
using SmartLeopard.Bll.Services;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Api.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();


            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
          //  builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //  builder.InjectActionInvoker();


            builder.RegisterSmartLeopard();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterSmartLeopard(this ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(Repository<>).Assembly).AsClosedTypesOf(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(DataService<>).Assembly).AsClosedTypesOf(typeof(DataService<>)).InstancePerRequest();
        }

    }
}