using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMovies(int page, int pageSize, int? genreId = null);
        int GetTotalMoviesCount(int? genreId = null, DateTime? purchaseStart = null, DateTime? purchaseEnd = null);
        MovieDetailModel? GetMovieDetails(int movieId);
        IEnumerable<MovieTrailerModel> GetMovieTrailers(int movieId);
        IEnumerable<MovieCastModel> GetMoviesCast(int movieId);
    }
}
