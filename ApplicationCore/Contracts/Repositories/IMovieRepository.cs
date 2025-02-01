using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie? GetByIdWithCastTrailer(int id);
        IEnumerable<Movie> GetAllWithCastTrailer();
    }
}
