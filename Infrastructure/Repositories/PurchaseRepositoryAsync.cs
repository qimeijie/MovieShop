using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Dtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepositoryAsync : IPurchaseRepositoryAsync
    {
        private readonly MovieDbContext _movieDbContext;
        public PurchaseRepositoryAsync(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }
        public async Task<IEnumerable<MoviePurchaseCountDto>> GetMoviesOrderedByPurchaseCountAsync(int page, int pageSize, DateTime? purchaseStart = null, DateTime? purchaseEnd = null)
        {
            var query = _movieDbContext.Purchases.AsNoTracking().AsQueryable();

            if (purchaseStart != null)
            {
                query = query.Where(p => p.PurchaseDateTime >= purchaseStart.Value);
            }
            if (purchaseEnd != null)
            {
                query = query.Where(p => p.PurchaseDateTime <= purchaseEnd.Value);
            }

            var purchaseCounts = await query
                .GroupBy(p => p.MovieId)
                .Select(g => new
                {
                    MovieId = g.Key,
                    PurchaseCount = g.Count()
                })
                .OrderByDescending(g => g.PurchaseCount)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var movieIds = purchaseCounts.Select(x => x.MovieId).ToList();
            var movies = await _movieDbContext.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            var result = movies.Select(m => new MoviePurchaseCountDto()
            {
                MovieId = m.Id,
                MovieTitle = m.Title??string.Empty,
                PurchaseCount = purchaseCounts.FirstOrDefault(pc => pc.MovieId == m.Id)?.PurchaseCount ?? 0
            }).OrderByDescending(m => m.PurchaseCount).ToList();
            
            return result;
        }

        public Task<int> GetTotalMoviesCountAsync(DateTime? purchaseStart= null, DateTime? purchaseEnd = null, int? userId = null)
        {
            var query = _movieDbContext.Purchases.AsNoTracking().AsQueryable();

            if (purchaseStart != null)
            {
                query = query.Where(p => p.PurchaseDateTime >= purchaseStart.Value);
            }
            if (purchaseEnd != null)
            {
                query = query.Where(p => p.PurchaseDateTime <= purchaseEnd.Value);
            }
            if (userId != null) { 
                query= query.Where(p => p.UserId == userId);
            }

            var purchaseCounts = query
                .Select(p => p.MovieId)
                .Distinct()
                .CountAsync();
            
            return purchaseCounts;
        }
        public async Task<IEnumerable<PurchaseWithMovieInfoDto>> GetMoviesPurchasedByUserAsync(int userId, int page, int pageSize)
        {
            var movieIds = await GetMovieIdsPurchasedByUserAsync(userId, page, pageSize);

            var movies = await _movieDbContext.Movies.AsNoTracking()
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            var result = movies.Select(m => {
                var p = _movieDbContext.Purchases.FirstOrDefault(p => p.UserId == userId && p.MovieId == m.Id);
                return new PurchaseWithMovieInfoDto()
                {
                    MovieId = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl,
                    TotalPrice = p?.TotalPrice,
                    PurchaseNumber = p?.PurchaseNumber,
                    PurchaseDate = p?.PurchaseDateTime
                };
            }).ToList();
            return result;
        }

        public async Task<IEnumerable<int>> GetMovieIdsPurchasedByUserAsync(int userId, int page, int pageSize)
        {
            return await _movieDbContext.Purchases.AsNoTracking()
                .Where(p => p.UserId == userId)
                .Select(p => p.MovieId)
                .Distinct()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
