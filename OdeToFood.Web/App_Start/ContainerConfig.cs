using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    // The goal is to tell to the container about the different components and abstractions in the project.
    // The idea of using dependency injection and having an Inversion of Control container, those are all
    // generic design patterns that are implemented by many different type of libraries. Autofac is one of them.
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration )
        {
            var builder = new ContainerBuilder();
            // Need to tell to Autofac what assembly contains the controllers for my application
            // MvcApplication is is the class defined in Global.asax that represents this application.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>()
                   .SingleInstance();

            var container = builder.Build();
            // ASP.Net MVC uses a static method on the DependencyResolver class 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Web API uses an instance of httpConfiguration
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}