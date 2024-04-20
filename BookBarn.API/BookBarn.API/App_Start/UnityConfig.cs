using BookBarn.Data.Repositories;
using BookBarn.Domain.Interfaces;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BookBarn.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IOrderRepository, OrderRepository>();

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}