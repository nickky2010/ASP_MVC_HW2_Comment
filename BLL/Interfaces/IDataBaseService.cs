using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDataBaseService<TDTO> : IDisposable
        where TDTO : class
    {
        void Add(TDTO entity, string userId);
        Task<TDTO> UpdateAsync(TDTO entity);
        Task<TDTO> FindAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<TDTO>> GetAllAsync();
    }
}
