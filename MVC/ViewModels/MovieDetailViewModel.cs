using ApplicationCore.Dtos;
using ApplicationCore.Entities;

namespace MVC.ViewModels
{
    public class MovieDetailViewModel
    {
        public bool IsPurchased { get; set; }
        public Movie Movie { get; set; } = new Movie();
        public string? Rating { get; set; } 
        public int? ReleaseYear {  get; set; }
        public IEnumerable<Genre> Genres { get; set; } = Enumerable.Empty<Genre>();
        public IEnumerable<CastWithCharacterDto> Casts { get; set; } = Enumerable.Empty<CastWithCharacterDto>();
        public IEnumerable<Trailer> Trailers { get; set; } = Enumerable.Empty<Trailer>();
    }
}
