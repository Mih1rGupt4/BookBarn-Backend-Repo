using BookBarn.Data.Repositories;
using BookBarn.Domain.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BookBarn.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IBooksRepository, BooksRepository>();
            container.RegisterType<IWishlistRepository, WishlistRepository>();



            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}