using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepositoryAsync : BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepositoryAsync(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int page, int pageSize, int? genreId)
        {
            var query = _movieDbContext.Movies.AsNoTracking().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public Task<int> GetTotalMoviesCountAsync(int? genreId, DateTime? purchaseStart, DateTime? purchaseEnd)
        {
            var query = _movieDbContext.Movies.AsNoTracking().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }
            if (purchaseStart != null)
            {
                query = query.Where(m => m.Purchases.Any(p => purchaseStart < p.PurchaseDateTime));
            }
            if (purchaseEnd != null)
            {
                query = query.Where(m => m.Purchases.Any(p => purchaseEnd > p.PurchaseDateTime));
            }
            return query.CountAsync();
        }

        public Task<Movie?> GetMovieDetailsAsync(int movieId)
        {
            return _movieDbContext.Movies.AsNoTracking()
                .Where(m => m.Id == movieId)
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<int> movieIds)
        {
            return await _movieDbContext.Movies.AsNoTracking()
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();
        }
    }
}
