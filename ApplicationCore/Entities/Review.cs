using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "DECIMAL(3,2)")]
        public Decimal Rating { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string ReviewText { get; set; } = string.Empty;

        //navigation prop
        public Movie Movie { get; set; } = new Movie();
        public User User { get; set; } = new User();
    }
}
