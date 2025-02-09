using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly MovieDbContext _movieDbContext;
        public BaseRepositoryAsync(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await _movieDbContext.Set<T>().FindAsync(id);
            if (result != null)
                _movieDbContext.Set<T>().Remove(result);

            return await _movieDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _movieDbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _movieDbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await _movieDbContext.Set<T>().AddAsync(entity);
            return await _movieDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _movieDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return await _movieDbContext.SaveChangesAsync();
        }
    }
}
