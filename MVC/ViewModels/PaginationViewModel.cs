namespace MVC.ViewModels
{
    public class PaginationViewModel
    {
        public int? GenreId { get; set; } = null;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
