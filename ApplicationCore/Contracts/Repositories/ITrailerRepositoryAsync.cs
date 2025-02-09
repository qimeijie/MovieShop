using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ITrailerRepositoryAsync
    {
        Task<IEnumerable<Trailer>> GetTrailersByMovieIdAsync(int movieId);
    }
}
