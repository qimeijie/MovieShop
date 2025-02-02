using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMovies(int page, int pageSize, int? genreId = null);
        int GetTotalMoviesCount(int? genreId = null);
        Movie? GetByIdWithCastTrailer(int id);
    }
}
