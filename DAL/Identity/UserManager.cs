using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL.Identity
{
    public class UserManager : UserManager<User>, IUserManager
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }
        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            IdentityDbContext<User> db = context.Get<IdentityDbContext<User>>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            return manager;
        }

        public UserManager CreateAppManager(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            return Create(options, context);
        }
    }
}
