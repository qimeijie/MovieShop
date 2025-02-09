using ApplicationCore.Dtos;
using ApplicationCore.Models;

namespace MVC.ViewModels
{
    public class TopMoviesViewModel
    {
        public PaginatedResultSet<MoviePurchaseCountDto> PaginatedResultSet {  get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
    }
}
