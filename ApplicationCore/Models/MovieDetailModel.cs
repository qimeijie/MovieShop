namespace ApplicationCore.Models
{
    public class MovieDetailModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TagLine { get; set; }
        public string? Overview { get; set; }
        public decimal? Price { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public decimal? BoxOffice { get; set; }
        public decimal? Budget { get; set; }
    }
}
