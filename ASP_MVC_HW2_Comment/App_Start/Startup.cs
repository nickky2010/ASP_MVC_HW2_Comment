using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using ASP_MVC_HW2_Comment.BLL.Interfaces;

[assembly: OwinStartup(typeof(ASP_MVC_HW2_Comment.App_Start.Startup))]

namespace ASP_MVC_HW2_Comment.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            //app.CreatePerOwinContext<PokemonContext>(PokemonContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

        }
        private static IUserService CreateUserService()
        {
            return (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        }
    }
}