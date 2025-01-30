using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{

    public class Movie
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(2084)")]
        public string? BackdropUrl { get; set; }
        [Column(TypeName = "DECIMAL(18,4)")]
        public decimal? Budget { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "NVARCHAR(2084)")]
        public string? ImdbUrl { get; set; }
        [Column(TypeName = "NVARCHAR(64)")]
        public string? OriginalLanguage { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string? Overview { get; set; }
        [Column(TypeName = "NVARCHAR(2084)")]
        public string? PosterUrl { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? ReleaseDate { get; set; }
        [Column(TypeName = "DECIMAL(18,4)")]
        public decimal? Revenue { get; set; }
        public int? RunTime { get; set; }
        [Column(TypeName = "NVARCHAR(512)")]
        public string? Tagline { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string? Title { get; set; }
        [Column(TypeName = "NVARCHAR(2084)")]
        public string? TmdbUrl { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? UpdatedDate { get; set; }

        //navigation prop
        public IEnumerable<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public IEnumerable<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
        public IEnumerable<Trailer> Trailers { get; set; } = new List<Trailer>();
        public IEnumerable<Favorite> Favorites { get; set; } = new List<Favorite>();
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
