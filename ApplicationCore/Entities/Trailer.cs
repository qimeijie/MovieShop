using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [Column(TypeName = "NVARCHAR(2084)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(2084)")]
        public string TrailerUrl { get; set; } = string.Empty;

        //Navigation prop
        public Movie Movie { get; set; } = new Movie();
    }
}
