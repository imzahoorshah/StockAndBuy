using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBuy.EF.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Int64 id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
