using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        
        public int Id { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string Name { get; set; } = string.Empty;

        //navigation prop
        public IEnumerable<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
