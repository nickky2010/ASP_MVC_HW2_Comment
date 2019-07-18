using ASP_MVC_HW2_Comment.DAL.Models;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Interfaces;
using DAL.Repositories.EF.ModelRepositories;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Repositories.EF
{
    public class EFUnitOfWork<C> : IUnitOfWork<C>
        where C : DbContext
    {
        private C context;

        private Lazy<IRepository<Comment>> commentRepository;
        private Lazy<IRepository<UserProfile>> userProfileRepository;
        private Lazy<IRepository<Role>> roleRepository;
        private bool disposed = false;

        public EFUnitOfWork(C context)
        {
            this.context = context;
        }
        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new Lazy<IRepository<Comment>>(() => new EFCommentRepository(context));
                }
                return commentRepository.Value;
            }
        }
        public IRepository<UserProfile> UserProfiles
        {
            get
            {
                if (userProfileRepository == null)
                {
                    userProfileRepository = new Lazy<IRepository<UserProfile>>(() => new EFUserProfileRepository(context));
                }
                return userProfileRepository.Value;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new Lazy<IRepository<Role>>(() => new EFRoleRepository(context));
                }
                return roleRepository.Value;
            }
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
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
