namespace ApplicationCore.Models
{
    public class MoviePurchaseModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int PurchaseCount { get; set; }
    }
}
