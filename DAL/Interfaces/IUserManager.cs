using DAL.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL.Interfaces
{
    public interface IUserManager
    {
        UserManager CreateAppManager(IdentityFactoryOptions<UserManager> options, IOwinContext context);
    }
}
