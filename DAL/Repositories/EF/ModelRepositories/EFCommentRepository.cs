using ASP_MVC_HW2_Comment.DAL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories.EF.ModelRepositories
{
    public class EFCommentRepository : IRepository<Comment>
    {
        protected DbContext context;
        private DbSet<Comment> dbSet;

        public EFCommentRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<Comment>();
        }

        public void Add(Comment entity)
        {
            dbSet.Add(entity);
        }        

        public void AddRange(ICollection<Comment> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Update(Comment entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Comment entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(ICollection<Comment> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public async Task<ICollection<Comment>> GetAllAsync()
        {
            return await dbSet.AsNoTracking()
                .Include(b => b.UserProfile)
                .ToListAsync();
        }

        public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(where);
        }

        public async Task<ICollection<Comment>> GetAllAsync(Expression<Func<Comment, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.UserProfile)
                .Where(where)
                .ToListAsync();
        }

        public async Task<Comment> GetLastItemAsync()
        {
            return await Task.Run(() => 
            dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.UserProfile)
                .LastOrDefault());            
        }

        public async Task<Comment> FindAsync(Expression<Func<Comment, bool>> where)
        {
            return await dbSet.AsNoTracking()
                .AsQueryable()
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(where);
        }
    }
}
