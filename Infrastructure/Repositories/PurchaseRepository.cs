using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public PurchaseRepository(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }
        public IEnumerable<MoviePurchaseModel> GetMoviesOrderedByPurchaseCount(DateTime? purchaseStart, DateTime? purchaseEnd, int page, int pageSize)
        {
            var query = _movieDbContext.Set<Purchase>().AsQueryable();

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
            var result = movies.Select(m => new MoviePurchaseModel()
            {
                MovieId = m.Id,
                MovieTitle = m.Title??string.Empty,
                PurchaseCount = purchaseCounts.FirstOrDefault(pc => pc.MovieId == m.Id)?.PurchaseCount ?? 0
            }).OrderByDescending(m => m.PurchaseCount).ToList();
            
            return result;
        }
        public int GetTotalMoviesCount(DateTime? purchaseStart, DateTime? purchaseEnd)
        {
            var query = _movieDbContext.Set<Purchase>().AsQueryable();

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
                .ToList();

            var movieIds = purchaseCounts.Select(x => x.MovieId).Count();
            
            return movieIds;
        }
    }
}
