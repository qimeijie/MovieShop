using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public int CastId { get; set; }
        [Column(TypeName = "NVARCHAR(450)")]
        public string Character { get; set; } = string.Empty;
        public int MovieId { get; set; }

        //navigation prop
        public Cast Cast { get; set; } = new Cast();
        public Movie Movie { get; set; } = new Movie();
    }
}
