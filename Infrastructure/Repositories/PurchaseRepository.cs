using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public PurchaseRepository(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }
        public IEnumerable<MoviePurchaseCountModel> GetMoviesOrderedByPurchaseCount(int page, int pageSize, DateTime? purchaseStart = null, DateTime? purchaseEnd = null)
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

            var purchaseCounts = query
                .GroupBy(p => p.MovieId)
                .Select(g => new
                {
                    MovieId = g.Key,
                    PurchaseCount = g.Count()
                })
                .OrderByDescending(g => g.PurchaseCount)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var movieIds = purchaseCounts.Select(x => x.MovieId).ToList();
            var movies = _movieDbContext.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToList();

            var result = movies.Select(m => new MoviePurchaseCountModel()
            {
                MovieId = m.Id,
                MovieTitle = m.Title??string.Empty,
                PurchaseCount = purchaseCounts.FirstOrDefault(pc => pc.MovieId == m.Id)?.PurchaseCount ?? 0
            }).OrderByDescending(m => m.PurchaseCount).ToList();
            
            return result;
        }
        public int GetTotalMoviesCount(DateTime? purchaseStart= null, DateTime? purchaseEnd = null, int? userId = null)
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
                .ToList().Count;
            
            return purchaseCounts;
        }

        public IEnumerable<MoviePurchaseModel> GetMoviesPurchasedByUser(int userId, int page, int pageSize)
        {
            var movieIds = _movieDbContext.Purchases.AsNoTracking()
                .Where(p => p.UserId == userId)
                .Select(p => p.MovieId)
                .Distinct()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            var movies = _movieDbContext.Movies.AsNoTracking()
                .Where(m => movieIds.Contains(m.Id))
                .ToList();

            var result = movies.Select(m => {
                    var p = _movieDbContext.Purchases.FirstOrDefault(p => p.UserId == userId && p.MovieId == m.Id);
                    return new MoviePurchaseModel()
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
    }
}
