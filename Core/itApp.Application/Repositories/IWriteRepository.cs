using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entitys);

        bool Remove(T entity);
        bool RemoveRange(List<T> entitys);
        Task<bool> RemoveAsync(int id);

        bool Update(T entity);

        Task<int> SaveAsync();
    }
}
