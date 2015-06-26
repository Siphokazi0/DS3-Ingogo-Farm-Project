using System;
using System.Web;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Batch_Management.Interface_Classes;
using Ingogo.BusinessLogic.Employee_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Employee_Management.Interface_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Interface_Classes;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes;
using Ingogo.MVC;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Animal_Management.Interface_Classes;
using Ingogo.Service.Batch_Management.Implementation_Classes;
using Ingogo.Service.Batch_Management.Interface_Classes;
using Ingogo.Service.Employee_Management.Implementation_Classes;
using Ingogo.Service.Employee_Management.Interface_Classes;
using Ingogo.Service.Purchase_Management.Implementation_Classes;
using Ingogo.Service.Purchase_Management.Interface_Classes;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Service.Treatment_Managemnt.Interface_Classes;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Ingogo.MVC
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            kernel.Bind<IBatchTypeRepository>().To<BatchTypeRepository>();
            kernel.Bind<IBatchTypeBl>().To<BatchTypeBl>();

            kernel.Bind<IBatchRepository>().To<BatchRepository>();
            kernel.Bind<IBatchBl>().To<BatchBl>();

            kernel.Bind<IFeedingStockRepository>().To<FeedingStockRepository>();
            kernel.Bind<IFeedingStockBussiness>().To<FeedingStockBussiness>();

            kernel.Bind<ITreatmentRepository>().To<TreatmentRepository>();
            kernel.Bind<ITreatmentBl>().To<TreatmentBl>();

            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IEmployeeBl>().To<EmployeeBl>();

            kernel.Bind<IAnimalRepository>().To<AnimalRepository>();
            kernel.Bind<IAnimalBusiness>().To<AnimalBusiness>();

           
        }        
    }
}
