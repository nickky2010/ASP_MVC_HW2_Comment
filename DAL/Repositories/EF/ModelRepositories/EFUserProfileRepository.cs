using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.EF.ModelRepositories
{
    public class EFUserProfileRepository : IRepository<UserProfile>
    {
        protected DbContext context;
        private DbSet<UserProfile> dbSet;

        public EFUserProfileRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<UserProfile>();
        }

        public void Add(UserProfile entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(ICollection<UserProfile> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(UserProfile entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(UserProfile entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<UserProfile> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public async Task<ICollection<UserProfile>> GetAllAsync()
        {
            return await dbSet.AsNoTracking()
                .Include(b => b.Comments)
                .ToListAsync();
        }

        public async Task<UserProfile> GetAsync(Expression<Func<UserProfile, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(where);
        }

        public async Task<ICollection<UserProfile>> GetAllAsync(Expression<Func<UserProfile, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Comments)
                .Where(where)
                .ToListAsync();
        }

        public async Task<UserProfile> GetLastItemAsync()
        {
            return await Task.Run(() =>
            dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Comments)
                .LastOrDefault());
        }

        public async Task<UserProfile> FindAsync(Expression<Func<UserProfile, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(where);
        }
    }
}
