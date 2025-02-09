using ApplicationCore.Dtos;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICastRepositoryAsync : IRepositoryAsync<Cast>
    {
        Task<IEnumerable<CastWithCharacterDto>> GetCastByMovieIdAsync(int movieId);
    }
}
