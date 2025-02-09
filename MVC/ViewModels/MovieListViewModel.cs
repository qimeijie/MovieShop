using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace MVC.ViewModels
{
    public class MovieListViewModel
    {
        public PaginatedResultSet<Movie> PaginatedResultSet { get; set; }
        public int? GenreId { get; set; } = null;
    }
}
