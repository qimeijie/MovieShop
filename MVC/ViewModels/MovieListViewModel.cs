namespace MVC.ViewModels
{
    public class MovieListViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int? GenreId { get; set; } = null;
        public IEnumerable<MovieCardViewModel> MovieCards { get; set; } = Enumerable.Empty<MovieCardViewModel>();
    }
}
