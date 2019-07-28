using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Identity;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories.EF
{
    public class EFIdentityUnitOfWork<C> : IIdentityUnitOfWork<C>
        where C : IdentityDbContext<User>
    {
        private IdentityContext context;
        private bool disposed = false;

        public EFIdentityUnitOfWork(string connectionString)
        {
            context = new IdentityContext(connectionString);
            UserManager = new UserManager(new UserStore<User>(context));
            RoleManager = new RoleManager(new RoleStore<Role>(context));
            ClientManager = new ClientManager(context);
        }

        public UserManager UserManager { get; }

        public IClientManager ClientManager { get; }

        public RoleManager RoleManager { get; }

        public async Task SaveIdentityAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
