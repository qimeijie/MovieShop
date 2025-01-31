namespace MVC.ViewModels
{
    public class MovieListViewModel
    {
        public IEnumerable<MovieCardViewModel> MovieCards { get; set; } = Enumerable.Empty<MovieCardViewModel>();
        public PaginationViewModel Pagination { get; set; } = new PaginationViewModel();

    }
}
