using ApplicationCore.Dtos;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepositoryAsync
    {
        Task<IEnumerable<MoviePurchaseCountDto>> GetMoviesOrderedByPurchaseCountAsync(int page, int pageSize, DateTime? purchaseStart = null, DateTime? purchaseEnd = null);
        Task<int> GetTotalMoviesCountAsync(DateTime? purchaseStart = null, DateTime? purchaseEnd = null, int? userId = null);
        Task<IEnumerable<PurchaseWithMovieInfoDto>> GetMoviesPurchasedByUserAsync(int userId, int page, int pageSize);
        Task<IEnumerable<int>> GetMovieIdsPurchasedByUserAsync(int userId, int page, int pageSize);
    }
}
