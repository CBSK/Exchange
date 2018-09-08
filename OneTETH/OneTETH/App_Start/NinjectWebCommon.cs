using System.Reflection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OneTETH.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OneTETH.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OneTETH.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using OneTETH.Repository.Interfaces;
    using OneTETH.Repository.Implementations;
    using OneTETH.Service.Implementations;
    using OneTETH.Service.Interfaces;
    using OneTETH.Repository;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel kernel { get; internal set; }
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

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
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
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<OneTEDBContext>().To<OneTEDBContext>().InTransientScope();
            kernel.Bind<IEZYMonitorExpHeaderRepository>().To<EZYMonitorExpHeaderRepository>();
            kernel.Bind<IEZYMonitorExpHeaderService>().To<EZYMonitorExpHeaderService>();
            kernel.Bind<IEzyInvoiceExpHeaderRepository>().To<EzyInvoiceExpHeaderRepository>();
            kernel.Bind<IEzyInvoiceExpHeaderService>().To<EzyInvoiceExpHeaderService>();
            kernel.Bind<ICustomsResponseDetailRepository>().To<CustomsResponseDetailRepository>();
            kernel.Bind<ICustomsResponseDetailService>().To<CustomsResponseDetailService>();
            kernel.Bind<IEzyInvoiceExpDetailRepository>().To<EzyInvoiceExpDetailRepository>();
            kernel.Bind<IEzyInvoiceExpDetailService>().To<EzyInvoiceExpDetailService>();
            kernel.Bind<IEzyExportPermitRepository>().To<EzyExportPermitRepository>();
            kernel.Bind<IEzyExportPermitService>().To<EzyExportPermitService>();
            kernel.Bind<IFTPFileDataListRepository>().To<FTPFileDataListRepository>();
            kernel.Bind<IFTPFileDataListService>().To<FTPFileDataListService>();
            kernel.Bind<IEzyExpRptRepository>().To<EzyExpRptRepository>();
            kernel.Bind<IEzyExpRptService>().To<EzyExpRptService>();
        }

        public static class ObjectFactory
        {
            public static T GetInstance<T>()
            {
                return kernel.Get<T>();
            }
        }
    }
   

}
