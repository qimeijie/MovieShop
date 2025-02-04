using ApplicationCore.Models;

namespace MVC.ViewModels
{
    public class MovieDetailViewModel
    {
        public bool IsPurchased { get; set; }
        public MovieDetailModel Movie { get; set; } = new MovieDetailModel();
        public IEnumerable<MovieCastModel> Casts { get; set; } = Enumerable.Empty<MovieCastModel>();
        public IEnumerable<MovieTrailerModel> Trailers { get; set; } = Enumerable.Empty<MovieTrailerModel>();
    }
}
