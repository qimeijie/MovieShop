namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        IEnumerable<T> Search(Func<T, bool> predicate);
    }
}
