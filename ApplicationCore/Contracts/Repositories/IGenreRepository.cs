using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Genre? GetByIdWithMovie(int id);
    }
}
