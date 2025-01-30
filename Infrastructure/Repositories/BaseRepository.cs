using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbContext _movieDbContext;
        public BaseRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public int Delete(int id)
        {
            var result = GetById(id);
            if (result != null)
                _movieDbContext.Set<T>().Remove(result);

            return _movieDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _movieDbContext.Set<T>();
        }

        public T? GetById(int id)
        {
            return _movieDbContext.Set<T>().Find(id);
        }

        public int Insert(T entity)
        {
            _movieDbContext.Set<T>().Add(entity);
            return _movieDbContext.SaveChanges();
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return _movieDbContext.Set<T>().Where(predicate);
        }

        public int Update(T entity)
        {
            _movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return _movieDbContext.SaveChanges();
        }
    }
}
