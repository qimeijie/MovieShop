namespace ApplicationCore.Models
{
    public class MoviePurchaseModel
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? PosterUrl { get; set; }
        public Guid? PurchaseNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
