using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBuy.EF.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BundleContext _bundleContext;

        public Repository(BundleContext bundleContext)
        {
            _bundleContext = bundleContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _bundleContext.Set<T>().AddAsync(entity);
            await _bundleContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _bundleContext.Set<T>().Remove(entity);
            await _bundleContext.SaveChangesAsync();
        }

        public void DeleteAllAsync()
        {
            List<T> all = _bundleContext.Set<T>().ToList();
            _bundleContext.Set<T>().RemoveRange(all);
            _bundleContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _bundleContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await _bundleContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
