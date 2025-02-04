using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<MoviePurchaseCountModel> GetMoviesOrderedByPurchaseCount(int page, int pageSize, DateTime? purchaseStart = null, DateTime? purchaseEnd = null);
        int GetTotalMoviesCount(DateTime? purchaseStart = null, DateTime? purchaseEnd = null, int? userId = null);
        IEnumerable<MoviePurchaseModel> GetMoviesPurchasedByUser(int userId, int page, int pageSize);
    }
}
