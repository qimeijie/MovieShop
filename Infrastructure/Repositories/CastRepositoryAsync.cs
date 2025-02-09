using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepositoryAsync : BaseRepositoryAsync<Cast>, ICastRepositoryAsync
    {
        private readonly MovieDbContext movieDbContext;

        public CastRepositoryAsync(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public async Task<IEnumerable<CastWithCharacterDto>> GetCastByMovieIdAsync(int movieId)
        {
            return await movieDbContext.MovieCasts.AsNoTracking()
               .Where(mc => mc.MovieId == movieId)
               .Select(mc => new CastWithCharacterDto
               {
                   ActorName = mc.Cast.Name,
                   CharacterName = mc.Character,
                   ProfilePath = mc.Cast.ProfilePath,
                   TmdbUrl = mc.Cast.TmdbUrl
               })
               .ToListAsync();
        }
    }
}
