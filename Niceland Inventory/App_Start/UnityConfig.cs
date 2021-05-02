using Niceland_Inventory.Repository;
using Niceland_Inventory.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Niceland_Inventory
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IItemsRepository, ItemsRepository>();
            container.RegisterType<IItemValueService, ItemValueService>();
            container.RegisterType<IItemValueCalculatorFactory, ItemValueCalculatorFactory>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}