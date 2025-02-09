using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepositoryAsync : IRepositoryAsync<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int page, int pageSize, int? genreId = null);
        Task<int> GetTotalMoviesCountAsync(int? genreId = null, DateTime? purchaseStart = null, DateTime? purchaseEnd = null);
        Task<Movie?> GetMovieDetailsAsync(int movieId);
        Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds);
    }
}
