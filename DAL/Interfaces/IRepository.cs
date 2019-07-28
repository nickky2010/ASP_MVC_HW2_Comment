using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(ICollection<T> entities);
        Task<T> FindAsync(Expression<Func<T, bool>> where);
        Task<T> GetLastItemAsync();
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
    }
}
