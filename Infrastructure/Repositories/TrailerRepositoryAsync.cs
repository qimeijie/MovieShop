using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TrailerRepositoryAsync : ITrailerRepositoryAsync
    {
        private readonly MovieDbContext movieDbContext;

        public TrailerRepositoryAsync(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        public async Task<IEnumerable<Trailer>> GetTrailersByMovieIdAsync(int movieId)
        {
            return await movieDbContext.Trailers.AsNoTracking()
                .Where(t => t.MovieId == movieId)
                .ToListAsync();
        }
    }
}
