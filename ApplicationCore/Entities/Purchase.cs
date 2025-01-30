using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime PurchaseDateTime { get; set; }
        public Guid PurchaseNumber { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal TotalPrice { get; set; }

        //navigation prop
        public Movie Movie { get; set; } = new Movie();
        public User User { get; set; } = new User();

    }
}
