using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        [Column(TypeName= "NVARCHAR(MAX)")]
        public string Gender { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(128)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(2084)")]
        public string ProfilePath { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string TmdbUrl { get; set; } = string.Empty;

        //navigation prop
        public IEnumerable<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}
