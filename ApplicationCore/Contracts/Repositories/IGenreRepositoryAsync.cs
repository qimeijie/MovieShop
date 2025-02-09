using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepositoryAsync : IRepositoryAsync<Genre>
    {
        Task<IEnumerable<Genre>> GetGenresAsync(int movieId);
    }
}
