using ASP_MVC_HW2_Comment.DAL.Models;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork<C> : IDisposable
        where C : DbContext
    {
        IRepository<Comment> Comments { get; }
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Role> Roles { get; }
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
