using ApplicationCore.Models;

namespace MVC.ViewModels
{
    public class PurchasedMovieListViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<MoviePurchaseModel> MovieCards { get; set; } = Enumerable.Empty<MoviePurchaseModel>();
    }
}
