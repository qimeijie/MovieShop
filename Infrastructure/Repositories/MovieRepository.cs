using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Azure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie? GetByIdWithCastTrailer(int id)
        {
            return _movieDbContext.Set<Movie>()
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMovies(int page, int pageSize, int? genreId = null)
        {
            var query = _movieDbContext.Set<Movie>().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetTotalMoviesCount(int? genreId = null)
        {
            var query = _movieDbContext.Set<Movie>().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return query.Count();
        }
        private IQueryable<Movie> GetMovies(DateTime? purchaseStart, DateTime? purchaseEnd)
        {
            return _movieDbContext.Set<Movie>()
                .Include(m => m.Purchases)
                .Where(m => m.Purchases.Any(p => purchaseStart == null || purchaseStart < p.PurchaseDateTime))
                .Where(m => m.Purchases.Any(p => purchaseEnd == null || purchaseEnd > p.PurchaseDateTime));
        }

        public int GetTotalMoviesCount(DateTime? purchaseStart, DateTime? purchaseEnd)
        {
            return GetMovies(purchaseStart, purchaseEnd).Count();
        }

        public IEnumerable<Movie> GetMoviesPurchasedByUser(int userId, int page, int pageSize)
        {
            return _movieDbContext.Set<Movie>()
                .Include(m => m.Purchases)
                .Where(m => m.Purchases.Any(p => p.UserId == userId))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();  
        }
        public int GetMoviesCountPurchasedByUser(int userId)
        {
            return _movieDbContext.Set<Movie>()
                .Include(m => m.Purchases)
                .Where(m => m.Purchases.Any(p => p.UserId == userId)).Count();
        }
    }
}
