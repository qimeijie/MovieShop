using ApplicationCore.Entities;

namespace MVC.ViewModels
{
    public class MovieDetailViewModel
    {
        public bool IsPurchased { get; set; }
        public Movie Movie { get; set; } = new Movie();
        public IEnumerable<CastInfo> Casts { get; set; } = Enumerable.Empty<CastInfo>();
    }
    public class CastInfo {
        public string ProfileUrl { get; set; } = string.Empty;
        public string Character {  get; set; } = string.Empty;
        public string Actor {  get; set; } = string.Empty;
    }
}
