using ApplicationCore.Models;

namespace MVC.ViewModels
{
    public class TopMoviesViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public IEnumerable<MoviePurchaseCountModel> Movies { get; set; } = Enumerable.Empty<MoviePurchaseCountModel>();
    }
}
