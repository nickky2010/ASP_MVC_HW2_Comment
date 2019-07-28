using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIdentityUnitOfWork<C> : IDisposable
        where C : IdentityDbContext<User>
    {
        UserManager UserManager { get; }
        IClientManager ClientManager { get; }
        RoleManager RoleManager { get; }
        Task SaveIdentityAsync();
    }
}
