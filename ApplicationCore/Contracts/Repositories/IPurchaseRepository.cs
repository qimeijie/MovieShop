using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<MoviePurchaseModel> GetMoviesOrderedByPurchaseCount(DateTime? purchaseStart, DateTime? purchaseEnd, int page, int pageSize);
        int GetTotalMoviesCount(DateTime? purchaseStart, DateTime? purchaseEnd);
    }
}
