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
    public class EFRoleRepository : IRepository<Role>
    {
        protected DbContext context;
        private DbSet<Role> dbSet;

        public EFRoleRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<Role>();
        }

        public void Add(Role entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(ICollection<Role> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(Role entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Role entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Role> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await dbSet.AsNoTracking()
                .Include(b => b.Users)
                .ToListAsync();
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Users)
                .FirstOrDefaultAsync(where);
        }

        public async Task<ICollection<Role>> GetAllAsync(Expression<Func<Role, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Users)
                .Where(where)
                .ToListAsync();
        }

        public async Task<Role> GetLastItemAsync()
        {
            return await Task.Run(() =>
            dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Users)
                .LastOrDefault());
        }

        public async Task<Role> FindAsync(Expression<Func<Role, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.Users)
                .FirstOrDefaultAsync(where);
        }
    }
}
