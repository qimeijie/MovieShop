using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepositoryAsync : BaseRepositoryAsync<Genre>, IGenreRepositoryAsync
    {
        private readonly MovieDbContext movieDbContext;

        public GenreRepositoryAsync(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync(int movieId)
        {
            return await movieDbContext.MovieGenres.AsNoTracking()
                .Where(mc => mc.MovieId == movieId)
                .Include(mc => mc.Genre)
                .Select(mc => mc.Genre)
                .ToListAsync();
        }
    }
}
