using ASP_MVC_HW2_Comment.Infrastructure.Mapping;
using BLL.Infrastructure.Dependencies;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASP_MVC_HW2_Comment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Obsolete]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule interfacesRegistrationsBLL = new InterfacesRegistrations("ApplicationAboutPokemon");
            var kernel = new StandardKernel(interfacesRegistrationsBLL);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            AutoMapperConfiguration.Configure();
        }
    }
}
