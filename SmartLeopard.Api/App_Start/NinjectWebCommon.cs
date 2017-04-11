[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmartLeopard.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SmartLeopard.Api.App_Start.NinjectWebCommon), "Stop")]

namespace SmartLeopard.Api.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Dal.Framework;
    using Dal;
    using Framework;
    using Bll;
    using Dal.Entities;
    using Bll.Services;
    using Dal.Repositories;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static IKernel _kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        public static IKernel GetKernel()
        {
            return _kernel;
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                _kernel = kernel;
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        } 
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DatabaseContext>().ToSelf().InTransientScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InTransientScope();
            kernel.Bind(typeof(IDataService<>)).To(typeof(DataService<>)).InRequestScope();
            kernel.Bind<DeviceRepository>().ToSelf();
            kernel.Bind<DeviceService>().ToSelf();
            
            kernel.Bind<ILog>().To<NLogger>().WithConstructorArgument("currentClassName", x => x.Request.ParentContext?.Request.Service.FullName);
            kernel.Bind<UnhandledExceptionFilterAttribute>().ToSelf();
            kernel.Bind<TracingHandler>().ToSelf(); 
        }        
    }
}
